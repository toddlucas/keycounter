namespace KeyCounter
{
	partial class FormOptions
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent ()
		{
			this.components = new System.ComponentModel.Container();
			this.groupBoxLogfileSettings = new System.Windows.Forms.GroupBox();
			this.labelLogfileName = new System.Windows.Forms.Label();
			this.textBoxLogfileName = new System.Windows.Forms.TextBox();
			this.labelLogfilePath = new System.Windows.Forms.Label();
			this.buttonChooseDir = new System.Windows.Forms.Button();
			this.comboBoxLogfilePath = new System.Windows.Forms.ComboBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBoxAutostart = new System.Windows.Forms.GroupBox();
			this.checkBoxAutostart = new System.Windows.Forms.CheckBox();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.groupBoxLogfileSettings.SuspendLayout();
			this.groupBoxAutostart.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxLogfileSettings
			// 
			this.groupBoxLogfileSettings.AutoSize = true;
			this.groupBoxLogfileSettings.Controls.Add(this.labelLogfileName);
			this.groupBoxLogfileSettings.Controls.Add(this.textBoxLogfileName);
			this.groupBoxLogfileSettings.Controls.Add(this.labelLogfilePath);
			this.groupBoxLogfileSettings.Controls.Add(this.buttonChooseDir);
			this.groupBoxLogfileSettings.Controls.Add(this.comboBoxLogfilePath);
			this.groupBoxLogfileSettings.Location = new System.Drawing.Point(12, 12);
			this.groupBoxLogfileSettings.Name = "groupBoxLogfileSettings";
			this.groupBoxLogfileSettings.Size = new System.Drawing.Size(456, 112);
			this.groupBoxLogfileSettings.TabIndex = 0;
			this.groupBoxLogfileSettings.TabStop = false;
			this.groupBoxLogfileSettings.Text = "Logfile settings";
			// 
			// labelLogfileName
			// 
			this.labelLogfileName.AutoSize = true;
			this.labelLogfileName.Location = new System.Drawing.Point(3, 16);
			this.labelLogfileName.Name = "labelLogfileName";
			this.labelLogfileName.Size = new System.Drawing.Size(82, 13);
			this.labelLogfileName.TabIndex = 4;
			this.labelLogfileName.Text = "Filename (*.bin):";
			// 
			// textBoxLogfileName
			// 
			this.textBoxLogfileName.Location = new System.Drawing.Point(6, 32);
			this.textBoxLogfileName.Name = "textBoxLogfileName";
			this.textBoxLogfileName.Size = new System.Drawing.Size(388, 20);
			this.textBoxLogfileName.TabIndex = 0;
			this.textBoxLogfileName.TextChanged += new System.EventHandler(this.textBoxLogfileName_TextChanged);
			// 
			// labelLogfilePath
			// 
			this.labelLogfilePath.AutoSize = true;
			this.labelLogfilePath.Location = new System.Drawing.Point(3, 55);
			this.labelLogfilePath.Name = "labelLogfilePath";
			this.labelLogfilePath.Size = new System.Drawing.Size(32, 13);
			this.labelLogfilePath.TabIndex = 2;
			this.labelLogfilePath.Text = "Path:";
			// 
			// buttonChooseDir
			// 
			this.buttonChooseDir.Location = new System.Drawing.Point(395, 70);
			this.buttonChooseDir.Name = "buttonChooseDir";
			this.buttonChooseDir.Size = new System.Drawing.Size(26, 23);
			this.buttonChooseDir.TabIndex = 2;
			this.buttonChooseDir.Text = "...";
			this.buttonChooseDir.UseVisualStyleBackColor = true;
			this.buttonChooseDir.Click += new System.EventHandler(this.buttonChooseDir_Click);
			// 
			// comboBoxLogfilePath
			// 
			this.comboBoxLogfilePath.BackColor = System.Drawing.SystemColors.Window;
			this.comboBoxLogfilePath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxLogfilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxLogfilePath.FormattingEnabled = true;
			this.comboBoxLogfilePath.Location = new System.Drawing.Point(6, 71);
			this.comboBoxLogfilePath.Name = "comboBoxLogfilePath";
			this.comboBoxLogfilePath.Size = new System.Drawing.Size(388, 21);
			this.comboBoxLogfilePath.TabIndex = 1;
			this.comboBoxLogfilePath.SelectedIndexChanged += new System.EventHandler(this.comboBoxLogfilePath_SelectedIndexChanged);
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(312, 181);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 1;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(393, 181);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// groupBoxAutostart
			// 
			this.groupBoxAutostart.Controls.Add(this.checkBoxAutostart);
			this.groupBoxAutostart.Location = new System.Drawing.Point(12, 129);
			this.groupBoxAutostart.Name = "groupBoxAutostart";
			this.groupBoxAutostart.Size = new System.Drawing.Size(456, 46);
			this.groupBoxAutostart.TabIndex = 3;
			this.groupBoxAutostart.TabStop = false;
			this.groupBoxAutostart.Text = "Autostart settings";
			// 
			// checkBoxAutostart
			// 
			this.checkBoxAutostart.AutoSize = true;
			this.checkBoxAutostart.Location = new System.Drawing.Point(6, 19);
			this.checkBoxAutostart.Name = "checkBoxAutostart";
			this.checkBoxAutostart.Size = new System.Drawing.Size(147, 17);
			this.checkBoxAutostart.TabIndex = 0;
			this.checkBoxAutostart.Text = "Load on Windows startup";
			this.checkBoxAutostart.UseVisualStyleBackColor = true;
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// FormOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(480, 211);
			this.ControlBox = false;
			this.Controls.Add(this.groupBoxAutostart);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.groupBoxLogfileSettings);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormOptions";
			this.ShowInTaskbar = false;
			this.Text = "KeyCounter Options";
			this.groupBoxLogfileSettings.ResumeLayout(false);
			this.groupBoxLogfileSettings.PerformLayout();
			this.groupBoxAutostart.ResumeLayout(false);
			this.groupBoxAutostart.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxLogfileSettings;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.GroupBox groupBoxAutostart;
		private System.Windows.Forms.Label labelLogfilePath;
		private System.Windows.Forms.Button buttonChooseDir;
		private System.Windows.Forms.ComboBox comboBoxLogfilePath;
		private System.Windows.Forms.Label labelLogfileName;
		private System.Windows.Forms.TextBox textBoxLogfileName;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.CheckBox checkBoxAutostart;
	}
}

