namespace KeyCounter
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.notifyIconKeyCounter = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStripNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.fillCountTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openDebugWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startstopCountingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetCounterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timerUpdateUpTime = new System.Windows.Forms.Timer(this.components);
			this.timerHideForm = new System.Windows.Forms.Timer(this.components);
			this.contextMenuStripNotify.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIconKeyCounter
			// 
			this.notifyIconKeyCounter.ContextMenuStrip = this.contextMenuStripNotify;
			this.notifyIconKeyCounter.Text = "KeyCounter";
			this.notifyIconKeyCounter.Visible = true;
			this.notifyIconKeyCounter.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconKeyCounter_MouseDoubleClick);
			// 
			// contextMenuStripNotify
			// 
			this.contextMenuStripNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillCountTabToolStripMenuItem,
            this.openDebugWindowToolStripMenuItem,
            this.displayToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.startstopCountingToolStripMenuItem,
            this.resetCounterToolStripMenuItem,
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.contextMenuStripNotify.Name = "contextMenuStripNotify";
			this.contextMenuStripNotify.Size = new System.Drawing.Size(186, 186);
			// 
			// fillCountTabToolStripMenuItem
			// 
			this.fillCountTabToolStripMenuItem.Name = "fillCountTabToolStripMenuItem";
			this.fillCountTabToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.fillCountTabToolStripMenuItem.Text = "Fill countTab";
			this.fillCountTabToolStripMenuItem.Click += new System.EventHandler(this.fillCountTabToolStripMenuItem_Click);
			// 
			// openDebugWindowToolStripMenuItem
			// 
			this.openDebugWindowToolStripMenuItem.Name = "openDebugWindowToolStripMenuItem";
			this.openDebugWindowToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.openDebugWindowToolStripMenuItem.Text = "Open debug window";
			this.openDebugWindowToolStripMenuItem.Click += new System.EventHandler(this.openDebugWindowToolStripMenuItem_Click);
			// 
			// displayToolStripMenuItem
			// 
			this.displayToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
			this.displayToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.displayToolStripMenuItem.Text = "Display";
			this.displayToolStripMenuItem.Click += new System.EventHandler(this.displayToolStripMenuItem_Click);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.optionsToolStripMenuItem.Text = "Options";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
			// 
			// startstopCountingToolStripMenuItem
			// 
			this.startstopCountingToolStripMenuItem.Name = "startstopCountingToolStripMenuItem";
			this.startstopCountingToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.startstopCountingToolStripMenuItem.Text = "Stop counting";
			this.startstopCountingToolStripMenuItem.Click += new System.EventHandler(this.startstopCountingToolStripMenuItem_Click);
			// 
			// resetCounterToolStripMenuItem
			// 
			this.resetCounterToolStripMenuItem.Name = "resetCounterToolStripMenuItem";
			this.resetCounterToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.resetCounterToolStripMenuItem.Text = "Reset counter";
			this.resetCounterToolStripMenuItem.Click += new System.EventHandler(this.resetCounterToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(182, 6);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// timerUpdateUpTime
			// 
			this.timerUpdateUpTime.Tick += new System.EventHandler(this.timerUpdateUpTime_Tick);
			// 
			// timerHideForm
			// 
			this.timerHideForm.Interval = 1;
			this.timerHideForm.Tick += new System.EventHandler(this.timerHideForm_Tick);
			// 
			// FormMain
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(284, 264);
			this.Name = "FormMain";
			this.ShowInTaskbar = false;
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.contextMenuStripNotify.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon notifyIconKeyCounter;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripNotify;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startstopCountingToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openDebugWindowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fillCountTabToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetCounterToolStripMenuItem;
		private System.Windows.Forms.Timer timerUpdateUpTime;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.Timer timerHideForm;
	}
}

