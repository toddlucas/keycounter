namespace KeyCounter
{
	partial class FormDebug
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
			this.buttonDebugClear = new System.Windows.Forms.Button();
			this.richTextBoxDebug = new System.Windows.Forms.RichTextBox();
			this.buttonDebugClose = new System.Windows.Forms.Button();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel = new System.Windows.Forms.ToolStripLabel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.toolStrip1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonDebugClear
			// 
			this.buttonDebugClear.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.buttonDebugClear.Location = new System.Drawing.Point(3, 280);
			this.buttonDebugClear.Name = "buttonDebugClear";
			this.buttonDebugClear.Size = new System.Drawing.Size(100, 23);
			this.buttonDebugClear.TabIndex = 0;
			this.buttonDebugClear.Text = "clear";
			this.buttonDebugClear.UseVisualStyleBackColor = true;
			this.buttonDebugClear.Click += new System.EventHandler(this.buttonDebugClear_Click);
			// 
			// richTextBoxDebug
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.richTextBoxDebug, 2);
			this.richTextBoxDebug.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBoxDebug.Location = new System.Drawing.Point(3, 3);
			this.richTextBoxDebug.Name = "richTextBoxDebug";
			this.richTextBoxDebug.Size = new System.Drawing.Size(420, 271);
			this.richTextBoxDebug.TabIndex = 1;
			this.richTextBoxDebug.Text = "";
			// 
			// buttonDebugClose
			// 
			this.buttonDebugClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.buttonDebugClose.Location = new System.Drawing.Point(323, 280);
			this.buttonDebugClose.Name = "buttonDebugClose";
			this.buttonDebugClose.Size = new System.Drawing.Size(100, 23);
			this.buttonDebugClose.TabIndex = 2;
			this.buttonDebugClose.Text = "close";
			this.buttonDebugClose.UseVisualStyleBackColor = true;
			this.buttonDebugClose.Click += new System.EventHandler(this.buttonDebugClose_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel});
			this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.toolStrip1.Location = new System.Drawing.Point(0, 307);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.toolStrip1.Size = new System.Drawing.Size(426, 16);
			this.toolStrip1.TabIndex = 4;
			// 
			// toolStripLabel
			// 
			this.toolStripLabel.Name = "toolStripLabel";
			this.toolStripLabel.Size = new System.Drawing.Size(215, 13);
			this.toolStripLabel.Text = "this is the ONE and ONLY debug-window ;-)";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.richTextBoxDebug, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonDebugClear, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.buttonDebugClose, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(426, 307);
			this.tableLayoutPanel1.TabIndex = 5;
			// 
			// FormDebug
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(426, 323);
			this.ControlBox = false;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.toolStrip1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormDebug";
			this.ShowInTaskbar = false;
			this.Text = "Debug";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonDebugClear;
		private System.Windows.Forms.RichTextBox richTextBoxDebug;
		private System.Windows.Forms.Button buttonDebugClose;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}