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
using System.IO;

namespace KeyCounter
{
	public partial class FormOptions : Form
	{
		private string filenameNotValidMsg = "Filename not valid";
		private string directoryNotValidMsg = "Directory not valid";
		private string unautorizedMsg = "Access denied";
		private string illegalCharacterMsg = "Illegal character";
		private string otherErrorMsg = "Unknown error";
		private Color normalColor = Color.FromKnownColor(System.Drawing.KnownColor.Window);
		private Color errorColor = Color.FromArgb(252, 175, 185);

		private IFileAccessChecker fileAccessChecker;
		private string defaultLogfileExtension;
		private DialogResult dialogResult = DialogResult.Cancel;

		public FormOptions (FormOptionsParameters parameters, IFileAccessChecker fileAccessChecker)
		{
			InitializeComponent();
			this.Icon = KeyCounterIcons.iconKeyboardOn;

			this.fileAccessChecker = fileAccessChecker;
			ApplyParameters(parameters);
			UpdateGui();
		}

		public FormOptionsParameters Parameters
		{
			get { return ReadParameters(); }
			set { ApplyParameters(value); }
		}

		public DialogResult Result
		{
			get { return this.dialogResult; }
		}

		private void SetErrorProviderLogfileName (string msg) { errorProvider.SetError(textBoxLogfileName, msg); }

		private void ClearErrorProviderLogfileName () { errorProvider.SetError(textBoxLogfileName, String.Empty); }

		private void SetErrorProviderLogfilePath (string msg) { errorProvider.SetError(buttonChooseDir, msg); }

		private void ClearErrorProviderLogfilePath () { errorProvider.SetError(buttonChooseDir, String.Empty); }

		private void ApplyParameters (FormOptionsParameters settings)
		{
			checkBoxAutostart.Checked = settings.autostartEnabled;
			this.defaultLogfileExtension = settings.logfileDefaultExtension;
			textBoxLogfileName.Text = settings.logfileName;
			comboBoxLogfilePath.Items.Clear();
			comboBoxLogfilePath.Items.Add(settings.logfilePath);
			comboBoxLogfilePath.SelectedIndex = 0;
		}

		private FormOptionsParameters ReadParameters ()
		{
			FormOptionsParameters settings = new FormOptionsParameters();

			settings.autostartEnabled = checkBoxAutostart.Checked;
			settings.logfileDefaultExtension = this.defaultLogfileExtension;
			settings.logfileName = LogfileName;
			settings.logfilePath = LogfilePath;
			return settings;
		}

		private string LogfileName
		{
			get { return (Path.GetExtension(textBoxLogfileName.Text) == this.defaultLogfileExtension) ? textBoxLogfileName.Text : textBoxLogfileName.Text + this.defaultLogfileExtension; }
		}

		private string LogfilePath
		{
			get { return comboBoxLogfilePath.Text; }
		}

		private string LogfileCompletePath
		{
			get { return LogfilePath + "\\" + LogfileName; }
		}

		private void UpdateGui ()
		{
			string resultingLogfileName = LogfileName;

			if (Path.GetFileNameWithoutExtension(resultingLogfileName).Length == 0)
				resultingLogfileName = "*" + this.defaultLogfileExtension;

			labelLogfileName.Text = String.Format("Filename ({0}): ", resultingLogfileName);

			FileAccessError fileAccess = fileAccessChecker.CheckPathName(LogfilePath, LogfileName);

			switch (fileAccess)
			{
				case FileAccessError.None:
					ClearErrorProviderLogfileName();
					ClearErrorProviderLogfilePath();
					textBoxLogfileName.BackColor = normalColor;
					comboBoxLogfilePath.BackColor = normalColor;
					break;

				case FileAccessError.DirectoryNotValid:
					ClearErrorProviderLogfileName();
					SetErrorProviderLogfilePath(directoryNotValidMsg);
					textBoxLogfileName.BackColor = normalColor;
					comboBoxLogfilePath.BackColor = errorColor;
					break;

				case FileAccessError.FilenameNotValid:
					SetErrorProviderLogfileName(filenameNotValidMsg);
					ClearErrorProviderLogfilePath();
					textBoxLogfileName.BackColor = errorColor;
					comboBoxLogfilePath.BackColor = normalColor;
					break;

				case FileAccessError.Unauthorized:
					SetErrorProviderLogfileName(unautorizedMsg);
					SetErrorProviderLogfilePath(unautorizedMsg);
					textBoxLogfileName.BackColor = errorColor;
					comboBoxLogfilePath.BackColor = errorColor;
					break;

				case FileAccessError.IllegalCharacter:
					SetErrorProviderLogfileName(illegalCharacterMsg);
					ClearErrorProviderLogfilePath();
					textBoxLogfileName.BackColor = errorColor;
					comboBoxLogfilePath.BackColor = normalColor;
					break;

				default:
					SetErrorProviderLogfileName(otherErrorMsg);
					SetErrorProviderLogfilePath(otherErrorMsg);
					textBoxLogfileName.BackColor = errorColor;
					comboBoxLogfilePath.BackColor = errorColor;
					break;
			}

			if (fileAccess == FileAccessError.None)
				buttonOk.Enabled = true;
			else
				buttonOk.Enabled = false;
		}

		private void textBoxLogfileName_TextChanged (object sender, EventArgs e)
		{
			UpdateGui();
		}

		private void buttonOk_Click (object sender, EventArgs e)
		{
			this.dialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click (object sender, EventArgs e)
		{
			this.dialogResult = DialogResult.Cancel;
			Close();
		}

		private void buttonChooseDir_Click (object sender, EventArgs e)
		{
			folderBrowserDialog.Description = "Choose the folder where statistics will be saved";
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				if (!comboBoxLogfilePath.Items.Contains(folderBrowserDialog.SelectedPath))
					comboBoxLogfilePath.Items.Add(folderBrowserDialog.SelectedPath);

				comboBoxLogfilePath.SelectedItem = folderBrowserDialog.SelectedPath;
			}

			UpdateGui();
		}

		private void comboBoxLogfilePath_SelectedIndexChanged (object sender, EventArgs e)
		{
			UpdateGui();
		}
	}

	public class FormOptionsParameters
	{
		public string logfileDefaultExtension;
		public string logfileName;
		public string logfilePath;
		public bool autostartEnabled;
	}
}