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
using KeyCounter.WinHook;
using KeyCounter.Counter;

namespace KeyCounter
{
  public partial class FormMain : Form
  {
    Icon iconOn = Properties.Resources.icon_keyb;
    Icon iconOff = Properties.Resources.keyb_off;
    private bool debugMode;
    private FormDebug formDebug;
    private ITextDebugger textDebugger;
    private List<UniversalHook> hookList;
    private CounterEngine<int> counterEngine;
    private bool hookEnabled = false;
    private string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + Properties.Settings.Default.fileName;
    private const int updateUpTimePeriodMs = 10000;
    
    public FormMain (FormDebug formDebug, List<UniversalHook> hookList)
    {      
      InitializeComponent();

      this.formDebug = formDebug;
      this.textDebugger = formDebug;
      this.hookList = hookList;
      this.debugMode = Properties.Settings.Default.debugModeEnabled;
      this.counterEngine = new CounterEngine<int>(new KeyTab<int>(GenerateKeyTab()), this.textDebugger);

      if (this.debugMode)
        textDebugger.SetLevel(DebugLevel.Debug);
      else
        textDebugger.SetLevel(DebugLevel.None);

      if (System.IO.File.Exists(this.filePath))
        LoadCounter(this.filePath);

      foreach (UniversalHook hookInList in hookList)
        hookInList.KeyIntercepted += new UniversalHook.HookEventHandler(OnKeyInterceptedHandler);      

      hookEnabled = true;
      timerUpdateUpTime.Interval = updateUpTimePeriodMs;
      timerUpdateUpTime.Enabled = true;

      Debug("Counter started", DebugLevel.Info);
      Debug("thread-id " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString(), DebugLevel.Debug);
    }

    private Dictionary<int, string> GenerateKeyTab ()
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

    private void LoadCounter (string filePath)
    {
      Debug("loading from " + filePath, DebugLevel.Info);
      bool hookWasEnabled = this.hookEnabled;
      this.hookEnabled = false;
      this.counterEngine.ReadBinary(filePath);
      this.hookEnabled = hookWasEnabled;
    }

    private void SaveCounter (string filePath)
    {
      Debug("saving to " + filePath, DebugLevel.Info);
      bool hookWasEnabled = this.hookEnabled;
      this.hookEnabled = false;
      this.counterEngine.SaveBinary(filePath);
      this.hookEnabled = hookWasEnabled;
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

    private void PreExit ()
    {
      SaveCounter(filePath);
    }

    private void UpdateGui ()
    {
      if (this.hookEnabled)
      {
        startstopCountingToolStripMenuItem.Text = "Stop counting";
        notifyIconKeyCounter.Icon = iconOn;
        startstopCountingToolStripMenuItem.Image = iconOff.ToBitmap();
      }
      else
      {
        startstopCountingToolStripMenuItem.Text = "Start counting";
        notifyIconKeyCounter.Icon = iconOff;
        startstopCountingToolStripMenuItem.Image = iconOn.ToBitmap();
      }
      
      openDebugWindowToolStripMenuItem.Visible = debugMode;
      fillCountTabToolStripMenuItem.Visible = debugMode;
    }

    private void FormMain_Load (object sender, EventArgs e)
    {
      Debug("FormMain loaded, we are in " + (debugMode?"debug":"release") + " mode", DebugLevel.Debug);
      notifyIconKeyCounter.Visible = true;
      Visible = false;
      UpdateGui();      
    }

    private void FormMain_FormClosing (object sender, FormClosingEventArgs e)
    {
      PreExit();
    }

    private void exitToolStripMenuItem_Click (object sender, EventArgs e)
    {
      PreExit();
      Close();
    }

    private void startstopCountingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.hookEnabled = !this.hookEnabled;
      UpdateGui();
    }

    private void aboutToolStripMenuItem_Click (object sender, EventArgs e)
    {
      AboutBox about = new AboutBox();
      about.ShowDialog();
    }

    private void displayToolStripMenuItem_Click (object sender, EventArgs e)
    {
      bool hookWasEnabled = this.hookEnabled;

      this.hookEnabled = false;
      //counterEngine.SaveBinary(this.filePath);
      FormDisplay formDisplay = new FormDisplay(this.textDebugger, this.counterEngine);
      formDisplay.ShowDialog();

      this.hookEnabled = hookWasEnabled;
    }

    private void openDebugWindowToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.formDebug.Show();
    }

    private void fillCountTabToolStripMenuItem_Click (object sender, EventArgs e)
    {
      int dayCount = 400;
      
      Random randomGen = new Random();
      DateTime dateTimeBuffer = DateTime.Now - new TimeSpan(dayCount+1, 0, 0, 0);
      List<int> keyIdList;

      counterEngine.lastReset = dateTimeBuffer;

      int keyCount = counterEngine.keyTab.RowCount();
      Debug("fill the counttab", DebugLevel.Info);
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

    private void resetCounterToolStripMenuItem_Click (object sender, EventArgs e)
    {
      if (MessageBox.Show("Do you really want to reset the counter?", "KeyCounter", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
      {
        counterEngine.ClearCounter();
        counterEngine.SaveBinary(this.filePath);
      }
    }

    private void timerUpdateUpTime_Tick (object sender, EventArgs e)
    {
      counterEngine.UpdateUpTime(updateUpTimePeriodMs);
    }
  }
}