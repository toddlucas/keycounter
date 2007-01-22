namespace KeyCounter
{
	partial class FormDisplay
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
			this.tabControlReports = new System.Windows.Forms.TabControl();
			this.tabPageSummary = new System.Windows.Forms.TabPage();
			this.dataGridViewSummary = new System.Windows.Forms.DataGridView();
			this.tabPageDaily = new System.Windows.Forms.TabPage();
			this.dataGridViewDaily = new System.Windows.Forms.DataGridView();
			this.tabPageWeekly = new System.Windows.Forms.TabPage();
			this.dataGridViewWeekly = new System.Windows.Forms.DataGridView();
			this.tabPageMonthly = new System.Windows.Forms.TabPage();
			this.dataGridViewMonthly = new System.Windows.Forms.DataGridView();
			this.tabPagePerKey = new System.Windows.Forms.TabPage();
			this.dataGridViewPerKey = new System.Windows.Forms.DataGridView();
			this.tabPageCustom = new System.Windows.Forms.TabPage();
			this.tableLayoutPanelCustom = new System.Windows.Forms.TableLayoutPanel();
			this.dataGridViewCustom = new System.Windows.Forms.DataGridView();
			this.flowLayoutPanelCustomStartDate = new System.Windows.Forms.FlowLayoutPanel();
			this.labelCustomStartDate = new System.Windows.Forms.Label();
			this.dateTimePickerCustomStartDate = new System.Windows.Forms.DateTimePicker();
			this.flowLayoutPanelCustomEndDate = new System.Windows.Forms.FlowLayoutPanel();
			this.labelCustomEndDate = new System.Windows.Forms.Label();
			this.dateTimePickerCustomEndDate = new System.Windows.Forms.DateTimePicker();
			this.flowLayoutPanelCustomGroupBy = new System.Windows.Forms.FlowLayoutPanel();
			this.labelCustomGroupBy = new System.Windows.Forms.Label();
			this.comboBoxCustomGroupBy = new System.Windows.Forms.ComboBox();
			this.buttonCustomUpdate = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.tableLayoutPanelReports = new System.Windows.Forms.TableLayoutPanel();
			this.tabControlReports.SuspendLayout();
			this.tabPageSummary.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSummary)).BeginInit();
			this.tabPageDaily.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDaily)).BeginInit();
			this.tabPageWeekly.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeekly)).BeginInit();
			this.tabPageMonthly.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewMonthly)).BeginInit();
			this.tabPagePerKey.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPerKey)).BeginInit();
			this.tabPageCustom.SuspendLayout();
			this.tableLayoutPanelCustom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustom)).BeginInit();
			this.flowLayoutPanelCustomStartDate.SuspendLayout();
			this.flowLayoutPanelCustomEndDate.SuspendLayout();
			this.flowLayoutPanelCustomGroupBy.SuspendLayout();
			this.tableLayoutPanelReports.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControlReports
			// 
			this.tabControlReports.Controls.Add(this.tabPageSummary);
			this.tabControlReports.Controls.Add(this.tabPageDaily);
			this.tabControlReports.Controls.Add(this.tabPageWeekly);
			this.tabControlReports.Controls.Add(this.tabPageMonthly);
			this.tabControlReports.Controls.Add(this.tabPagePerKey);
			this.tabControlReports.Controls.Add(this.tabPageCustom);
			this.tabControlReports.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlReports.Location = new System.Drawing.Point(3, 3);
			this.tabControlReports.Name = "tabControlReports";
			this.tabControlReports.SelectedIndex = 0;
			this.tabControlReports.Size = new System.Drawing.Size(600, 447);
			this.tabControlReports.TabIndex = 0;
			// 
			// tabPageSummary
			// 
			this.tabPageSummary.Controls.Add(this.dataGridViewSummary);
			this.tabPageSummary.Location = new System.Drawing.Point(4, 22);
			this.tabPageSummary.Name = "tabPageSummary";
			this.tabPageSummary.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSummary.Size = new System.Drawing.Size(592, 421);
			this.tabPageSummary.TabIndex = 0;
			this.tabPageSummary.Text = "Summary";
			this.tabPageSummary.UseVisualStyleBackColor = true;
			this.tabPageSummary.Enter += new System.EventHandler(this.tabPageSummary_Enter);
			// 
			// dataGridViewSummary
			// 
			this.dataGridViewSummary.AllowUserToAddRows = false;
			this.dataGridViewSummary.AllowUserToDeleteRows = false;
			this.dataGridViewSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewSummary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewSummary.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewSummary.Name = "dataGridViewSummary";
			this.dataGridViewSummary.ReadOnly = true;
			this.dataGridViewSummary.Size = new System.Drawing.Size(586, 415);
			this.dataGridViewSummary.TabIndex = 1;
			// 
			// tabPageDaily
			// 
			this.tabPageDaily.Controls.Add(this.dataGridViewDaily);
			this.tabPageDaily.Location = new System.Drawing.Point(4, 22);
			this.tabPageDaily.Name = "tabPageDaily";
			this.tabPageDaily.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageDaily.Size = new System.Drawing.Size(592, 421);
			this.tabPageDaily.TabIndex = 1;
			this.tabPageDaily.Text = "Daily reports";
			this.tabPageDaily.UseVisualStyleBackColor = true;
			this.tabPageDaily.Enter += new System.EventHandler(this.tabPageDaily_Enter);
			// 
			// dataGridViewDaily
			// 
			this.dataGridViewDaily.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewDaily.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewDaily.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewDaily.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewDaily.Name = "dataGridViewDaily";
			this.dataGridViewDaily.ReadOnly = true;
			this.dataGridViewDaily.Size = new System.Drawing.Size(586, 415);
			this.dataGridViewDaily.TabIndex = 2;
			// 
			// tabPageWeekly
			// 
			this.tabPageWeekly.Controls.Add(this.dataGridViewWeekly);
			this.tabPageWeekly.Location = new System.Drawing.Point(4, 22);
			this.tabPageWeekly.Name = "tabPageWeekly";
			this.tabPageWeekly.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageWeekly.Size = new System.Drawing.Size(592, 421);
			this.tabPageWeekly.TabIndex = 2;
			this.tabPageWeekly.Text = "Weekly reports";
			this.tabPageWeekly.UseVisualStyleBackColor = true;
			this.tabPageWeekly.Enter += new System.EventHandler(this.tabPageWeekly_Enter);
			// 
			// dataGridViewWeekly
			// 
			this.dataGridViewWeekly.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewWeekly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewWeekly.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewWeekly.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewWeekly.Name = "dataGridViewWeekly";
			this.dataGridViewWeekly.ReadOnly = true;
			this.dataGridViewWeekly.Size = new System.Drawing.Size(586, 415);
			this.dataGridViewWeekly.TabIndex = 2;
			// 
			// tabPageMonthly
			// 
			this.tabPageMonthly.Controls.Add(this.dataGridViewMonthly);
			this.tabPageMonthly.Location = new System.Drawing.Point(4, 22);
			this.tabPageMonthly.Name = "tabPageMonthly";
			this.tabPageMonthly.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageMonthly.Size = new System.Drawing.Size(592, 421);
			this.tabPageMonthly.TabIndex = 3;
			this.tabPageMonthly.Text = "Monthly reports";
			this.tabPageMonthly.UseVisualStyleBackColor = true;
			this.tabPageMonthly.Enter += new System.EventHandler(this.tabPageMonthly_Enter);
			// 
			// dataGridViewMonthly
			// 
			this.dataGridViewMonthly.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewMonthly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewMonthly.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewMonthly.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewMonthly.Name = "dataGridViewMonthly";
			this.dataGridViewMonthly.ReadOnly = true;
			this.dataGridViewMonthly.Size = new System.Drawing.Size(586, 415);
			this.dataGridViewMonthly.TabIndex = 2;
			// 
			// tabPagePerKey
			// 
			this.tabPagePerKey.Controls.Add(this.dataGridViewPerKey);
			this.tabPagePerKey.Location = new System.Drawing.Point(4, 22);
			this.tabPagePerKey.Name = "tabPagePerKey";
			this.tabPagePerKey.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePerKey.Size = new System.Drawing.Size(592, 421);
			this.tabPagePerKey.TabIndex = 4;
			this.tabPagePerKey.Text = "Reports per key";
			this.tabPagePerKey.UseVisualStyleBackColor = true;
			this.tabPagePerKey.Enter += new System.EventHandler(this.tabPagePerKey_Enter);
			// 
			// dataGridViewPerKey
			// 
			this.dataGridViewPerKey.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewPerKey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewPerKey.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewPerKey.Location = new System.Drawing.Point(3, 3);
			this.dataGridViewPerKey.Name = "dataGridViewPerKey";
			this.dataGridViewPerKey.ReadOnly = true;
			this.dataGridViewPerKey.Size = new System.Drawing.Size(586, 415);
			this.dataGridViewPerKey.TabIndex = 2;
			// 
			// tabPageCustom
			// 
			this.tabPageCustom.Controls.Add(this.tableLayoutPanelCustom);
			this.tabPageCustom.Location = new System.Drawing.Point(4, 22);
			this.tabPageCustom.Name = "tabPageCustom";
			this.tabPageCustom.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageCustom.Size = new System.Drawing.Size(592, 421);
			this.tabPageCustom.TabIndex = 5;
			this.tabPageCustom.Text = "Custom";
			this.tabPageCustom.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanelCustom
			// 
			this.tableLayoutPanelCustom.ColumnCount = 4;
			this.tableLayoutPanelCustom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanelCustom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanelCustom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanelCustom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanelCustom.Controls.Add(this.dataGridViewCustom, 0, 1);
			this.tableLayoutPanelCustom.Controls.Add(this.flowLayoutPanelCustomStartDate, 0, 0);
			this.tableLayoutPanelCustom.Controls.Add(this.flowLayoutPanelCustomEndDate, 1, 0);
			this.tableLayoutPanelCustom.Controls.Add(this.flowLayoutPanelCustomGroupBy, 2, 0);
			this.tableLayoutPanelCustom.Controls.Add(this.buttonCustomUpdate, 3, 0);
			this.tableLayoutPanelCustom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelCustom.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanelCustom.Name = "tableLayoutPanelCustom";
			this.tableLayoutPanelCustom.RowCount = 2;
			this.tableLayoutPanelCustom.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelCustom.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelCustom.Size = new System.Drawing.Size(586, 415);
			this.tableLayoutPanelCustom.TabIndex = 3;
			// 
			// dataGridViewCustom
			// 
			this.dataGridViewCustom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridViewCustom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tableLayoutPanelCustom.SetColumnSpan(this.dataGridViewCustom, 4);
			this.dataGridViewCustom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewCustom.Location = new System.Drawing.Point(3, 49);
			this.dataGridViewCustom.Name = "dataGridViewCustom";
			this.dataGridViewCustom.ReadOnly = true;
			this.dataGridViewCustom.Size = new System.Drawing.Size(580, 379);
			this.dataGridViewCustom.TabIndex = 2;
			// 
			// flowLayoutPanelCustomStartDate
			// 
			this.flowLayoutPanelCustomStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanelCustomStartDate.Controls.Add(this.labelCustomStartDate);
			this.flowLayoutPanelCustomStartDate.Controls.Add(this.dateTimePickerCustomStartDate);
			this.flowLayoutPanelCustomStartDate.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelCustomStartDate.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanelCustomStartDate.Name = "flowLayoutPanelCustomStartDate";
			this.flowLayoutPanelCustomStartDate.Size = new System.Drawing.Size(140, 39);
			this.flowLayoutPanelCustomStartDate.TabIndex = 3;
			// 
			// labelCustomStartDate
			// 
			this.labelCustomStartDate.AutoSize = true;
			this.labelCustomStartDate.Location = new System.Drawing.Point(3, 0);
			this.labelCustomStartDate.Name = "labelCustomStartDate";
			this.labelCustomStartDate.Size = new System.Drawing.Size(56, 13);
			this.labelCustomStartDate.TabIndex = 0;
			this.labelCustomStartDate.Text = "Start date:";
			// 
			// dateTimePickerCustomStartDate
			// 
			this.dateTimePickerCustomStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerCustomStartDate.Location = new System.Drawing.Point(3, 16);
			this.dateTimePickerCustomStartDate.Name = "dateTimePickerCustomStartDate";
			this.dateTimePickerCustomStartDate.Size = new System.Drawing.Size(120, 20);
			this.dateTimePickerCustomStartDate.TabIndex = 1;
			// 
			// flowLayoutPanelCustomEndDate
			// 
			this.flowLayoutPanelCustomEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanelCustomEndDate.AutoSize = true;
			this.flowLayoutPanelCustomEndDate.Controls.Add(this.labelCustomEndDate);
			this.flowLayoutPanelCustomEndDate.Controls.Add(this.dateTimePickerCustomEndDate);
			this.flowLayoutPanelCustomEndDate.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelCustomEndDate.Location = new System.Drawing.Point(149, 3);
			this.flowLayoutPanelCustomEndDate.Name = "flowLayoutPanelCustomEndDate";
			this.flowLayoutPanelCustomEndDate.Size = new System.Drawing.Size(140, 39);
			this.flowLayoutPanelCustomEndDate.TabIndex = 4;
			// 
			// labelCustomEndDate
			// 
			this.labelCustomEndDate.AutoSize = true;
			this.labelCustomEndDate.Location = new System.Drawing.Point(3, 0);
			this.labelCustomEndDate.Name = "labelCustomEndDate";
			this.labelCustomEndDate.Size = new System.Drawing.Size(53, 13);
			this.labelCustomEndDate.TabIndex = 0;
			this.labelCustomEndDate.Text = "End date:";
			// 
			// dateTimePickerCustomEndDate
			// 
			this.dateTimePickerCustomEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePickerCustomEndDate.Location = new System.Drawing.Point(3, 16);
			this.dateTimePickerCustomEndDate.Name = "dateTimePickerCustomEndDate";
			this.dateTimePickerCustomEndDate.Size = new System.Drawing.Size(120, 20);
			this.dateTimePickerCustomEndDate.TabIndex = 1;
			// 
			// flowLayoutPanelCustomGroupBy
			// 
			this.flowLayoutPanelCustomGroupBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanelCustomGroupBy.AutoSize = true;
			this.flowLayoutPanelCustomGroupBy.Controls.Add(this.labelCustomGroupBy);
			this.flowLayoutPanelCustomGroupBy.Controls.Add(this.comboBoxCustomGroupBy);
			this.flowLayoutPanelCustomGroupBy.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelCustomGroupBy.Location = new System.Drawing.Point(295, 3);
			this.flowLayoutPanelCustomGroupBy.Name = "flowLayoutPanelCustomGroupBy";
			this.flowLayoutPanelCustomGroupBy.Size = new System.Drawing.Size(140, 40);
			this.flowLayoutPanelCustomGroupBy.TabIndex = 5;
			// 
			// labelCustomGroupBy
			// 
			this.labelCustomGroupBy.AutoSize = true;
			this.labelCustomGroupBy.Location = new System.Drawing.Point(3, 0);
			this.labelCustomGroupBy.Name = "labelCustomGroupBy";
			this.labelCustomGroupBy.Size = new System.Drawing.Size(53, 13);
			this.labelCustomGroupBy.TabIndex = 0;
			this.labelCustomGroupBy.Text = "Group by:";
			// 
			// comboBoxCustomGroupBy
			// 
			this.comboBoxCustomGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCustomGroupBy.FormattingEnabled = true;
			this.comboBoxCustomGroupBy.Items.AddRange(new object[] {
            "Date",
            "Key",
            "Sum all",
            "None"});
			this.comboBoxCustomGroupBy.Location = new System.Drawing.Point(3, 16);
			this.comboBoxCustomGroupBy.Name = "comboBoxCustomGroupBy";
			this.comboBoxCustomGroupBy.Size = new System.Drawing.Size(120, 21);
			this.comboBoxCustomGroupBy.TabIndex = 1;
			// 
			// buttonCustomUpdate
			// 
			this.buttonCustomUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCustomUpdate.Location = new System.Drawing.Point(508, 20);
			this.buttonCustomUpdate.Name = "buttonCustomUpdate";
			this.buttonCustomUpdate.Size = new System.Drawing.Size(75, 23);
			this.buttonCustomUpdate.TabIndex = 6;
			this.buttonCustomUpdate.Text = "Update";
			this.buttonCustomUpdate.UseVisualStyleBackColor = true;
			this.buttonCustomUpdate.Click += new System.EventHandler(this.buttonCustomUpdate_Click);
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Location = new System.Drawing.Point(473, 456);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(130, 23);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// tableLayoutPanelReports
			// 
			this.tableLayoutPanelReports.ColumnCount = 1;
			this.tableLayoutPanelReports.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelReports.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelReports.Controls.Add(this.buttonOK, 0, 1);
			this.tableLayoutPanelReports.Controls.Add(this.tabControlReports, 0, 0);
			this.tableLayoutPanelReports.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelReports.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanelReports.Name = "tableLayoutPanelReports";
			this.tableLayoutPanelReports.RowCount = 2;
			this.tableLayoutPanelReports.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanelReports.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelReports.Size = new System.Drawing.Size(606, 482);
			this.tableLayoutPanelReports.TabIndex = 2;
			// 
			// FormDisplay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(606, 482);
			this.ControlBox = false;
			this.Controls.Add(this.tableLayoutPanelReports);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormDisplay";
			this.Text = "KeyCounter Reports";
			this.tabControlReports.ResumeLayout(false);
			this.tabPageSummary.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSummary)).EndInit();
			this.tabPageDaily.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewDaily)).EndInit();
			this.tabPageWeekly.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeekly)).EndInit();
			this.tabPageMonthly.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewMonthly)).EndInit();
			this.tabPagePerKey.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPerKey)).EndInit();
			this.tabPageCustom.ResumeLayout(false);
			this.tableLayoutPanelCustom.ResumeLayout(false);
			this.tableLayoutPanelCustom.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustom)).EndInit();
			this.flowLayoutPanelCustomStartDate.ResumeLayout(false);
			this.flowLayoutPanelCustomStartDate.PerformLayout();
			this.flowLayoutPanelCustomEndDate.ResumeLayout(false);
			this.flowLayoutPanelCustomEndDate.PerformLayout();
			this.flowLayoutPanelCustomGroupBy.ResumeLayout(false);
			this.flowLayoutPanelCustomGroupBy.PerformLayout();
			this.tableLayoutPanelReports.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControlReports;
		private System.Windows.Forms.TabPage tabPageDaily;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelReports;
		private System.Windows.Forms.TabPage tabPageSummary;
		private System.Windows.Forms.DataGridView dataGridViewSummary;
		private System.Windows.Forms.DataGridView dataGridViewDaily;
		private System.Windows.Forms.TabPage tabPageWeekly;
		private System.Windows.Forms.DataGridView dataGridViewWeekly;
		private System.Windows.Forms.TabPage tabPageMonthly;
		private System.Windows.Forms.DataGridView dataGridViewMonthly;
		private System.Windows.Forms.TabPage tabPagePerKey;
		private System.Windows.Forms.DataGridView dataGridViewPerKey;
		private System.Windows.Forms.TabPage tabPageCustom;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCustom;
		private System.Windows.Forms.DataGridView dataGridViewCustom;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCustomStartDate;
		private System.Windows.Forms.Label labelCustomStartDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerCustomStartDate;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCustomEndDate;
		private System.Windows.Forms.Label labelCustomEndDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerCustomEndDate;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCustomGroupBy;
		private System.Windows.Forms.Label labelCustomGroupBy;
		private System.Windows.Forms.ComboBox comboBoxCustomGroupBy;
		private System.Windows.Forms.Button buttonCustomUpdate;
	}
}