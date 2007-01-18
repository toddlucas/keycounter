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
    protected override void Dispose (bool disposing)
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
    private void InitializeComponent ()
    {
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
        this.notifyIconKeyCounter = new System.Windows.Forms.NotifyIcon(this.components);
        this.contextMenuStripNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.fillCountTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.openDebugWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.startstopCountingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.resetCounterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
        this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.timerUpdateUpTime = new System.Windows.Forms.Timer(this.components);
        this.contextMenuStripNotify.SuspendLayout();
        this.SuspendLayout();
        // 
        // notifyIconKeyCounter
        // 
        this.notifyIconKeyCounter.ContextMenuStrip = this.contextMenuStripNotify;
        this.notifyIconKeyCounter.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconKeyCounter.Icon")));
        this.notifyIconKeyCounter.Text = "Key Counter";
        this.notifyIconKeyCounter.Visible = true;
        // 
        // contextMenuStripNotify
        // 
        this.contextMenuStripNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillCountTabToolStripMenuItem,
            this.openDebugWindowToolStripMenuItem,
            this.displayToolStripMenuItem,
            this.startstopCountingToolStripMenuItem,
            this.resetCounterToolStripMenuItem,
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
        this.contextMenuStripNotify.Name = "contextMenuStripNotify";
        this.contextMenuStripNotify.Size = new System.Drawing.Size(184, 164);
        // 
        // fillCountTabToolStripMenuItem
        // 
        this.fillCountTabToolStripMenuItem.Name = "fillCountTabToolStripMenuItem";
        this.fillCountTabToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
        this.fillCountTabToolStripMenuItem.Text = "Fill countTab";
        this.fillCountTabToolStripMenuItem.Click += new System.EventHandler(this.fillCountTabToolStripMenuItem_Click);
        // 
        // openDebugWindowToolStripMenuItem
        // 
        this.openDebugWindowToolStripMenuItem.Name = "openDebugWindowToolStripMenuItem";
        this.openDebugWindowToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
        this.openDebugWindowToolStripMenuItem.Text = "Open debug window";
        this.openDebugWindowToolStripMenuItem.Click += new System.EventHandler(this.openDebugWindowToolStripMenuItem_Click);
        // 
        // displayToolStripMenuItem
        // 
        this.displayToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("displayToolStripMenuItem.Image")));
        this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
        this.displayToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
        this.displayToolStripMenuItem.Text = "Display";
        this.displayToolStripMenuItem.Click += new System.EventHandler(this.displayToolStripMenuItem_Click);
        // 
        // startstopCountingToolStripMenuItem
        // 
        this.startstopCountingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startstopCountingToolStripMenuItem.Image")));
        this.startstopCountingToolStripMenuItem.Name = "startstopCountingToolStripMenuItem";
        this.startstopCountingToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
        this.startstopCountingToolStripMenuItem.Text = "Stop counting";
        this.startstopCountingToolStripMenuItem.Click += new System.EventHandler(this.startstopCountingToolStripMenuItem_Click);
        // 
        // resetCounterToolStripMenuItem
        // 
        this.resetCounterToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resetCounterToolStripMenuItem.Image")));
        this.resetCounterToolStripMenuItem.Name = "resetCounterToolStripMenuItem";
        this.resetCounterToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
        this.resetCounterToolStripMenuItem.Text = "Reset counter";
        this.resetCounterToolStripMenuItem.Click += new System.EventHandler(this.resetCounterToolStripMenuItem_Click);
        // 
        // toolStripMenuItem1
        // 
        this.toolStripMenuItem1.Name = "toolStripMenuItem1";
        this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 6);
        // 
        // aboutToolStripMenuItem
        // 
        this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
        this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        this.aboutToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
        this.aboutToolStripMenuItem.Text = "About";
        this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
        // 
        // exitToolStripMenuItem
        // 
        this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
        this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        this.exitToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
        this.exitToolStripMenuItem.Text = "Exit";
        this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
        // 
        // timerUpdateUpTime
        // 
        this.timerUpdateUpTime.Tick += new System.EventHandler(this.timerUpdateUpTime_Tick);
        // 
        // FormMain
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(580, 329);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FormMain";
        this.ShowInTaskbar = false;
        this.Text = "Key Counter";
        this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
        this.Load += new System.EventHandler(this.FormMain_Load);
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
  }
}

