/*
   Copyright (C) 2007 OBACHT & UNCLE JAMAL

   This program is free software; you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation; either version 2 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using KeyCounter.WinHook;
using KeyCounter.Counter;

namespace KeyCounter
{
	public partial class FormMain : Form
	{
		private FormDebug formDebug;
		private ITextDebugger textDebugger;
		private List<UniversalHook> hookList;
		private CounterEngine<int> counterEngine;
		private bool hookEnabled = false;
		private const int updateUpTimePeriodMs = 10000;
		private string logfileInvalidMsg = "The configured logfile is not accessible, please check the options dialog";

		//Settings buffer:
		private bool debugModeEnabled;
		private bool firstStart;
		private string logfilePath;
		private string logfileName;
		private string logfileDefaultExtension;
		private string registryAutostartKey;
		private string registryAutostartName;


		public FormMain(FormDebug formDebug, List<UniversalHook> hookList)
		{
			InitializeComponent();
			this.Hide();

			ReadSettings();

			this.formDebug = formDebug;
			this.textDebugger = formDebug;
			this.hookList = hookList;
			this.counterEngine = new CounterEngine<int>(new KeyTab<int>(GenerateKeyTable()), this.textDebugger);

			if (this.debugModeEnabled)
				textDebugger.SetLevel(DebugLevel.Debug);
			else
				textDebugger.SetLevel(DebugLevel.None);

			LoadCounter();
			if (counterEngine.fileAccessChecker.CheckPathName(this.logfilePath, this.logfileName) != FileAccessError.None)
				ShowBalloon(logfileInvalidMsg, ToolTipIcon.Warning);

			foreach (UniversalHook hookInList in hookList)
				hookInList.KeyIntercepted += new UniversalHook.HookEventHandler(OnKeyInterceptedHandler);

			hookEnabled = true;
			timerUpdateUpTime.Interval = updateUpTimePeriodMs;
			timerUpdateUpTime.Enabled = true;

			if (this.firstStart)
			{
				ShowBalloon("KeyCounter runs and is counting...", ToolTipIcon.Info);
				this.firstStart = false;
			}

			Debug("FormMain: KeyCounter started", DebugLevel.Info);
			Debug("FormMain loaded, we are in " + (debugModeEnabled ? "debug" : "release") + " mode", DebugLevel.Debug);
			UpdateGui();

			timerHideForm.Enabled = true;
		}

		private void ReadSettings()
		{
			this.debugModeEnabled = Properties.Settings.Default.debugModeEnabled;
			this.firstStart = Properties.Settings.Default.firstStart;
			this.logfilePath = Properties.Settings.Default.logfilePath;
			this.logfileName = Properties.Settings.Default.logfileName;
			this.logfileDefaultExtension = Properties.Settings.Default.logfileDefaultExtension;
			this.registryAutostartKey = Properties.Settings.Default.registryAutostartKey;
			this.registryAutostartName = Properties.Settings.Default.registryAutostartName;

			if (this.logfilePath.Length == 0)
				this.logfilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		}

		private void WriteSettings()
		{
			Properties.Settings.Default.firstStart = this.firstStart;
			Properties.Settings.Default.logfilePath = this.logfilePath;
			Properties.Settings.Default.logfileName = this.logfileName;
		}

		private Dictionary<int, string> GenerateKeyTable()
		{
			Dictionary<int, string> output = new Dictionary<int, string>();

			string[] keyNames = Enum.GetNames(typeof(System.Windows.Forms.Keys));
			Array keyValues = Enum.GetValues(typeof(System.Windows.Forms.Keys));

			for (int index = 0; index < keyNames.Length; index++)
			{
				if (!output.ContainsKey((int)keyValues.GetValue(index)))
					output.Add((int)keyValues.GetValue(index), keyNames[index]);
			}

			return output;
		}

		private bool LoadCounter()
		{
			Debug("FormMain.LoadCounter: reading from \"" + this.LogfileCompletePath + "\"", DebugLevel.Info);

			if (!System.IO.File.Exists(this.LogfileCompletePath))
			{
				Debug("FormMain.LoadCounter: Logfile does not exist", DebugLevel.Info);
				return true;
			}

			FileAccessError accessResult = this.counterEngine.fileAccessChecker.CheckPathName(this.logfilePath, this.logfileName);

			if (accessResult != FileAccessError.None)
			{
				Debug("FormMain.LoadCounter: FileAccessError=" + accessResult.ToString(), DebugLevel.Warning);
				return false;
			}

			bool hookWasEnabled = this.hookEnabled;
			this.hookEnabled = false;
			this.counterEngine.ReadBinary(LogfileCompletePath);
			this.hookEnabled = hookWasEnabled;
			return true;
		}

		private bool SaveCounter(string filePath)
		{
			Debug("FormMain.SaveCounter: saving to \"" + this.LogfileCompletePath + "\"", DebugLevel.Info);

			FileAccessError accessResult = this.counterEngine.fileAccessChecker.CheckPathName(this.logfilePath, this.logfileName);

			if (accessResult != FileAccessError.None)
			{
				Debug("FormMain.SaveCounter: FileAccessError=" + accessResult.ToString(), DebugLevel.Warning);
				return false;
			}

			bool hookWasEnabled = this.hookEnabled;
			this.hookEnabled = false;
			this.counterEngine.SaveBinary(LogfileCompletePath);
			this.hookEnabled = hookWasEnabled;
			return true;
		}

		private void OnKeyInterceptedHandler(UniversalHook.HookEventArgs e)
		{
			if (hookEnabled)
				counterEngine.countTab.Count(DateTime.Now.Date, e.vkCode, 1);
		}

		private void Debug(string msg, DebugLevel msgLevel)
		{
			if (this.textDebugger != null)
				textDebugger.Debug(msg, msgLevel);
		}

		private string LogfileCompletePath { get { return this.logfilePath + "\\" + this.logfileName; } }

		private void PreExit()
		{
			SaveCounter(LogfileCompletePath);
			WriteSettings();
			Properties.Settings.Default.Save();
		}

		private void UpdateGui()
		{
			displayToolStripMenuItem.Image = KeyCounterIcons.iconDisplay.ToBitmap();
			resetCounterToolStripMenuItem.Image = KeyCounterIcons.iconReset.ToBitmap();
			exitToolStripMenuItem.Image = KeyCounterIcons.iconExit.ToBitmap();
			aboutToolStripMenuItem.Image = KeyCounterIcons.iconAbout.ToBitmap();
			optionsToolStripMenuItem.Image = KeyCounterIcons.iconOptions.ToBitmap();

			if (this.hookEnabled)
			{
				startstopCountingToolStripMenuItem.Text = "Stop counting";
				notifyIconKeyCounter.Icon = KeyCounterIcons.iconKeyboardOn;
				startstopCountingToolStripMenuItem.Image = KeyCounterIcons.iconKeyboardOff.ToBitmap();
				notifyIconKeyCounter.Text = "KeyCounter is running...";
			}
			else
			{
				startstopCountingToolStripMenuItem.Text = "Start counting";
				notifyIconKeyCounter.Icon = KeyCounterIcons.iconKeyboardOff;
				startstopCountingToolStripMenuItem.Image = KeyCounterIcons.iconKeyboardOn.ToBitmap();
				notifyIconKeyCounter.Text = "KeyCounter stopped";
			}

			openDebugWindowToolStripMenuItem.Visible = debugModeEnabled;
			fillCountTabToolStripMenuItem.Visible = debugModeEnabled;
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			PreExit();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PreExit();
			Application.Exit();
		}

		private void startstopCountingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.hookEnabled = !this.hookEnabled;
			UpdateGui();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.NotifyIconEnabled = false;
			AboutBox about = new AboutBox();
			about.ShowDialog();
			this.NotifyIconEnabled = true;
		}

		private void displayToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool hookWasEnabled = this.hookEnabled;

			this.hookEnabled = false;
			this.NotifyIconEnabled = false;
			FormDisplay formDisplay = new FormDisplay(this.textDebugger, this.counterEngine);
			formDisplay.ShowDialog();
			this.NotifyIconEnabled = true;

			this.hookEnabled = hookWasEnabled;
		}

		private void openDebugWindowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.formDebug.Show();
		}

		private void fillCountTabToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int dayCount = 400;

			Random randomGen = new Random();
			DateTime dateTimeBuffer = DateTime.Now - new TimeSpan(dayCount + 1, 0, 0, 0);
			List<int> keyIdList;

			counterEngine.lastReset = dateTimeBuffer;

			int keyCount = counterEngine.keyTab.RowCount();
			Debug("FormMain: fill the counttab", DebugLevel.Info);
			Debug(keyCount.ToString() + " keys in keyTab", DebugLevel.Debug);

			keyIdList = counterEngine.keyTab.KeyIdList();

			for (int dayIndex = 0; dayIndex < dayCount; dayIndex++)
			{
				for (int keyIdIndex = 0; keyIdIndex < counterEngine.keyTab.RowCount(); keyIdIndex++)
					counterEngine.Count(dateTimeBuffer, keyIdList[keyIdIndex], (uint)10 + (uint)dayIndex);

				dateTimeBuffer = dateTimeBuffer.AddDays(1);
			}

			Debug("counttab filled with " + counterEngine.countTab.RowCount() + " rows", DebugLevel.Debug);
		}

		private void resetCounterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you really want to reset the counter?", "KeyCounter", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				counterEngine.ClearCounter();
				counterEngine.SaveBinary(LogfileCompletePath);
			}
		}

		private void timerUpdateUpTime_Tick(object sender, EventArgs e)
		{
			counterEngine.UpdateUpTime(updateUpTimePeriodMs);
		}

		private void ShowBalloon(string msg, ToolTipIcon icon)
		{
			notifyIconKeyCounter.ShowBalloonTip(10, "KeyCounter", msg, icon);
		}

		private bool NotifyIconEnabled
		{
			get { return contextMenuStripNotify.Enabled; }
			set { contextMenuStripNotify.Enabled = value; }
		}

		private bool ReadAutostartSetting()
		{
			bool bFoundAutostart = false;
			RegistryKey regHKCU = Registry.CurrentUser;
			RegistryKey regRun = regHKCU.OpenSubKey(this.registryAutostartKey, false);
			object regValue = regRun.GetValue(this.registryAutostartName);

			if (regValue != null)
			{
				bFoundAutostart = true;
				Debug("FormMain.ReadAutostartSetting: found autostart \"" + regValue.ToString() + "\"", DebugLevel.Debug);
			}
			else
				Debug("FormMaion.ReadAutostartSetting: no autostart found", DebugLevel.Debug);

			regRun.Close();
			regHKCU.Close();

			return bFoundAutostart;
		}

		private void WriteAutostartSetting(bool autostartEnabled)
		{
			Debug("FormMain.WriteAutostartSetting", DebugLevel.Debug);

			RegistryKey regHKCU = Registry.CurrentUser;
			RegistryKey regRun = regHKCU.OpenSubKey(this.registryAutostartKey, true);

			if (autostartEnabled)
				regRun.SetValue(registryAutostartName, System.Reflection.Assembly.GetExecutingAssembly().Location);
			else
			{
				object regValue = regRun.GetValue(this.registryAutostartName);
				if (regValue != null)
					regRun.DeleteValue(registryAutostartName);
			}

			regRun.Close();
			regHKCU.Close();
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormOptionsParameters currParams = new FormOptionsParameters();
			currParams.autostartEnabled = ReadAutostartSetting();
			currParams.logfileDefaultExtension = this.logfileDefaultExtension;
			currParams.logfileName = this.logfileName;
			currParams.logfilePath = this.logfilePath;

			FormOptions formOptions = new FormOptions(currParams, this.counterEngine.fileAccessChecker);
			this.NotifyIconEnabled = false;
			formOptions.ShowDialog();
			DialogResult dialogResult = formOptions.Result;

			if (dialogResult == DialogResult.OK)
			{
				FormOptionsParameters newParams = formOptions.Parameters;
				WriteAutostartSetting(newParams.autostartEnabled);
				this.logfileDefaultExtension = newParams.logfileDefaultExtension;
				this.logfileName = newParams.logfileName;
				this.logfilePath = newParams.logfilePath;
			}

			this.NotifyIconEnabled = true;
		}

		private void notifyIconKeyCounter_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (NotifyIconEnabled == true)
				displayToolStripMenuItem_Click(sender, e);
		}

		private void timerHideForm_Tick(object sender, EventArgs e)
		{
			this.Hide();
			timerHideForm.Enabled = false;
		}
	}
}