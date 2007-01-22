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
using KeyCounter.Counter;
using KeyCounter.Counter.Filters;

namespace KeyCounter
{
	public partial class FormDisplay : Form
	{
		private ITextDebugger textDebugger = null;
		private CounterEngine<int> counterEngine = null;
		private List<int> completeIndex = null;
		DataTable completeTabByDate = null;
		private string dateFormat = "yyyy-MM-dd";

		private bool tabSummaryDrawn = false;
		private bool tabDailyDrawn = false;
		private bool tabWeeklyDrawn = false;
		private bool tabMonthlyDrawn = false;
		private bool tabPerKeyDrawn = false;


		public FormDisplay(ITextDebugger textDebugger, CounterEngine<int> counterEngine)
		{
			InitializeComponent();

			this.Icon = KeyCounterIcons.iconKeyboardOn;
			this.textDebugger = textDebugger;
			this.counterEngine = counterEngine;

			completeIndex = counterEngine.IndexBuild();
			completeTabByDate = counterEngine.IndexCountByDate(completeIndex);

			dateTimePickerCustomStartDate.Value = counterEngine.lastReset;
			dateTimePickerCustomEndDate.Value = DateTime.Now.Date;

			comboBoxCustomGroupBy.SelectedItem = comboBoxCustomGroupBy.Items[0];
		}

		private void Debug(string msg, DebugLevel msgLevel)
		{
			if (this.textDebugger != null)
				textDebugger.Debug(msg, msgLevel);
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void UpdateSummary()
		{
			dataGridViewSummary.Rows.Clear();
			dataGridViewSummary.Columns.Clear();
			dataGridViewSummary.Columns.Add("Property", "Property");
			dataGridViewSummary.Columns.Add("Value", "Value");

			Debug("FormDisplay.UpdateSummary()", DebugLevel.Debug);

			DateTime today = DateTime.Today.Date;
			DateTime lastMonday;

			if (today.DayOfWeek != DayOfWeek.Sunday)
				lastMonday = today - new TimeSpan(((int)today.DayOfWeek) - 1, 0, 0, 0);
			else
				lastMonday = today - new TimeSpan(6, 0, 0, 0);

			DateTime oneWeekAgo = today - new TimeSpan(7, 0, 0, 0);
			DateTime thisMonth = new DateTime(today.Year, today.Month, 1);
			DateTime last30Days = today - new TimeSpan(30, 0, 0, 0);
			DateTime thisYear = new DateTime(today.Year, 1, 1);
			DateTime last365Days = today - new TimeSpan(365, 0, 0, 0);

			DataRow[] tempRows;

			tempRows = completeTabByDate.Select("date = '" + today + "'");
			if (tempRows.Length > 0)
				dataGridViewSummary.Rows.Add(new object[] { "Keys pressed today", tempRows[0]["count"] });

			tempRows = completeTabByDate.Select("date >= '" + lastMonday + "'");
			if (tempRows.Length > 0)
				dataGridViewSummary.Rows.Add(new object[] { "Keys pressed this week", SumDataRowColumn(tempRows, 1) });

			tempRows = completeTabByDate.Select("date >= '" + oneWeekAgo + "'");
			if (tempRows.Length > 0)
				dataGridViewSummary.Rows.Add(new object[] { "Keys pressed last 7 days", SumDataRowColumn(tempRows, 1) });

			tempRows = completeTabByDate.Select("date >= '" + thisMonth + "'");
			if (tempRows.Length > 0)
				dataGridViewSummary.Rows.Add(new object[] { "Keys pressed this month", SumDataRowColumn(tempRows, 1) });

			tempRows = completeTabByDate.Select("date >= '" + last30Days + "'");
			if (tempRows.Length > 0)
				dataGridViewSummary.Rows.Add(new object[] { "Keys pressed last 30 days", SumDataRowColumn(tempRows, 1) });

			tempRows = completeTabByDate.Select("date >= '" + thisYear + "'");
			if (tempRows.Length > 0)
				dataGridViewSummary.Rows.Add(new object[] { "Keys pressed this year", SumDataRowColumn(tempRows, 1) });

			tempRows = completeTabByDate.Select("date >= '" + last365Days + "'");
			if (tempRows.Length > 0)
				dataGridViewSummary.Rows.Add(new object[] { "Keys pressed last 365 days", SumDataRowColumn(tempRows, 1) });

			uint totalCount = counterEngine.IndexCountSum(completeIndex);
			dataGridViewSummary.Rows.Add(new object[] { "Keys pressed total", totalCount });
			dataGridViewSummary.Rows.Add(new object[] { "Last counter reset", counterEngine.lastReset.ToShortDateString() + " " + counterEngine.lastReset.ToShortTimeString() });
			dataGridViewSummary.Rows.Add(new object[] { "Last program start", counterEngine.lastStart.ToShortDateString() + " " + counterEngine.lastStart.ToShortTimeString() });
			dataGridViewSummary.Rows.Add(new object[] { "Uptime since last counter reset", FormatTimeSpan(counterEngine.uptimeSinceReset) });
			dataGridViewSummary.Rows.Add(new object[] { "Uptime since last program start", FormatTimeSpan(counterEngine.uptimeSinceStart) });
			dataGridViewSummary.Rows.Add(new object[] { "Uptime total", FormatTimeSpan(counterEngine.uptimeTotal) });
			dataGridViewSummary.Rows.Add(new object[] { "Average key hits per minute since last reset", counterEngine.uptimeSinceReset.TotalMinutes > 0 ? String.Format("{0:F2}", (float)totalCount / counterEngine.uptimeSinceReset.TotalMinutes) : String.Format("0") });

			tabSummaryDrawn = true;
		}

		public void UpdateDaily()
		{
			Debug("FormDisplay.UpdateDaily()", DebugLevel.Debug);

			dataGridViewDaily.Rows.Clear();
			dataGridViewDaily.Columns.Clear();
			dataGridViewDaily.Columns.Add("Day", "Day");
			dataGridViewDaily.Columns.Add("Count", "Count");

			for (int rowIndex = 0; rowIndex < completeTabByDate.Rows.Count; rowIndex++)
				dataGridViewDaily.Rows.Add(new object[] { ((DateTime)completeTabByDate.Rows[rowIndex][0]).ToString(dateFormat), completeTabByDate.Rows[rowIndex][1] });

			dataGridViewDaily.Sort(dataGridViewDaily.Columns[0], ListSortDirection.Descending);
			tabDailyDrawn = true;
		}

		public void UpdateWeekly()
		{
			DateTime today = DateTime.Now.Date;
			DateTime firstDay = counterEngine.lastReset.Date;
			DateTime weekFirstDay;
			DateTime weekLastDay;

			Debug("FormDisplay.UpdateWeekly()", DebugLevel.Debug);

			weekFirstDay = firstDay;
			if (weekFirstDay.DayOfWeek != DayOfWeek.Sunday)
				weekLastDay = weekFirstDay + new TimeSpan((7 - (int)weekFirstDay.DayOfWeek), 0, 0, 0);
			else
				weekLastDay = weekFirstDay;

			dataGridViewWeekly.Columns.Add("Week", "Week");
			dataGridViewWeekly.Columns.Add("Count", "Count");

			DataRow[] tempRows;
			for (; ; )
			{
				if (weekLastDay > today)
					weekLastDay = today;

				tempRows = completeTabByDate.Select("date >= '" + weekFirstDay + "' AND date <= '" + weekLastDay + "'");

				if (tempRows.Length > 0)
					dataGridViewWeekly.Rows.Add(new object[] { weekFirstDay.ToString(dateFormat) + " - " + weekLastDay.ToString(dateFormat), SumDataRowColumn(tempRows, 1) });

				if (weekLastDay == today)
					break;

				weekFirstDay = weekLastDay.AddDays(1);
				weekLastDay = weekLastDay.AddDays(7);
			}

			dataGridViewWeekly.Sort(dataGridViewWeekly.Columns[0], ListSortDirection.Descending);
			tabWeeklyDrawn = true;
		}

		private void UpdateMonthly()
		{
			DateTime today = DateTime.Now.Date;
			DateTime firstDay = counterEngine.lastReset.Date;
			DateTime monthFirstDay;
			DateTime monthLastDay;

			Debug("FormDisplay.UpdateMonthly()", DebugLevel.Debug);

			monthFirstDay = firstDay;
			monthLastDay = monthFirstDay.AddMonths(1);
			monthLastDay = monthLastDay.AddDays(-1);

			dataGridViewMonthly.Columns.Add("Month", "Month");
			dataGridViewMonthly.Columns.Add("Count", "Count");

			DataRow[] tempRows;
			for (; ; )
			{
				if (monthLastDay > today)
					monthLastDay = today;

				tempRows = completeTabByDate.Select("date >= '" + monthFirstDay + "' AND date <= '" + monthLastDay + "'");
				if (tempRows.Length > 0)
					dataGridViewMonthly.Rows.Add(new object[] { monthFirstDay.ToString(dateFormat) + " - " + monthLastDay.ToString(dateFormat), SumDataRowColumn(tempRows, 1) });

				if (monthLastDay == today)
					break;

				monthFirstDay = monthLastDay.AddDays(1);
				monthLastDay = monthFirstDay.AddMonths(1);
				monthLastDay = monthLastDay.AddDays(-1);
			}

			dataGridViewMonthly.Sort(dataGridViewMonthly.Columns[0], ListSortDirection.Descending);
			tabMonthlyDrawn = true;
		}

		private void UpdatePerKey()
		{
			double uptimeMinutes = counterEngine.uptimeSinceReset.TotalMinutes;
			Debug("FormDisplay.UpdatePerKey()", DebugLevel.Debug);

			dataGridViewPerKey.Rows.Clear();
			dataGridViewPerKey.Columns.Clear();
			dataGridViewPerKey.Columns.Add("Keyname", "Keyname");
			dataGridViewPerKey.Columns.Add("Count", "Count");

			if (uptimeMinutes > 0)
				dataGridViewPerKey.Columns.Add("Average hits per minute", "Average hits per minute");

			DataTable completeTabByKey = counterEngine.IndexCountByKey(completeIndex);
			DataRow tempRow;
			uint tempCount;

			for (int indexInTab = 0; indexInTab < completeTabByKey.Rows.Count; indexInTab++)
			{
				tempRow = completeTabByKey.Rows[indexInTab];
				tempCount = (uint)(tempRow[1]);

				if (uptimeMinutes > 0)
					dataGridViewPerKey.Rows.Add(new object[] { tempRow[0], tempCount, String.Format("{0:F2}", (double)tempCount / uptimeMinutes) });
				else
					dataGridViewPerKey.Rows.Add(new object[] { tempRow[0], tempCount });
			}

			dataGridViewPerKey.Sort(dataGridViewPerKey.Columns[1], ListSortDirection.Descending);
			tabPerKeyDrawn = true;
		}

		private string FormatTimeSpan(TimeSpan input)
		{
			return input.Days.ToString() + " days, " + input.Hours.ToString() + " hours, " + input.Minutes.ToString() + " minutes, " + input.Seconds.ToString() + " seconds";
		}

		private uint SumDataRowColumn(DataRow[] rows, int column)
		{
			uint result = 0;

			for (int index = 0; index < rows.Length; index++)
				result += (uint)rows[index][column];

			return result;
		}

		private void checkBoxDailyShowEmpty_CheckedChanged(object sender, EventArgs e)
		{
			UpdateDaily();
		}

		private void tabPageSummary_Enter(object sender, EventArgs e)
		{
			if (!tabSummaryDrawn)
				UpdateSummary();
		}

		private void tabPageDaily_Enter(object sender, EventArgs e)
		{
			if (!tabDailyDrawn)
				UpdateDaily();
		}

		private void tabPageWeekly_Enter(object sender, EventArgs e)
		{
			if (!tabWeeklyDrawn)
				UpdateWeekly();
		}

		private void tabPageMonthly_Enter(object sender, EventArgs e)
		{
			if (!tabMonthlyDrawn)
				UpdateMonthly();
		}

		private void tabPagePerKey_Enter(object sender, EventArgs e)
		{
			if (!tabPerKeyDrawn)
				UpdatePerKey();
		}

		private void buttonCustomUpdate_Click(object sender, EventArgs e)
		{
			List<int> tempIndex = new List<int>(completeIndex);
			FilterMatchDateRange<int> filter = new FilterMatchDateRange<int>(dateTimePickerCustomStartDate.Value, dateTimePickerCustomEndDate.Value, false);

			counterEngine.IndexApplyFilter(filter, tempIndex);

			if (comboBoxCustomGroupBy.Text == "Date")
			{
				DataTable tempTable = counterEngine.IndexCountByDate(tempIndex);
				dataGridViewCustom.DataSource = tempTable;
				dataGridViewCustom.Columns[0].HeaderText = "Date";
				dataGridViewCustom.Columns[1].HeaderText = "Count";
				dataGridViewCustom.Sort(dataGridViewCustom.Columns[0], ListSortDirection.Descending);
			}

			else if (comboBoxCustomGroupBy.Text == "Key")
			{
				DataTable tempTable = counterEngine.IndexCountByKey(tempIndex);
				dataGridViewCustom.DataSource = tempTable;
				dataGridViewCustom.Columns[0].HeaderText = "Date";
				dataGridViewCustom.Columns[1].HeaderText = "Count";
				dataGridViewCustom.Sort(dataGridViewCustom.Columns[1], ListSortDirection.Descending);
			}

			else if (comboBoxCustomGroupBy.Text == "Sum all")
			{
				uint count = counterEngine.IndexCountSum(tempIndex);
				dataGridViewCustom.DataSource = null;
				dataGridViewCustom.Rows.Clear();
				dataGridViewCustom.Columns.Clear();
				dataGridViewCustom.Columns.Add("Sum", "Sum");
				dataGridViewCustom.Rows.Add(new object[] { count });
			}

			else
			{
				DataTable tempTable = counterEngine.IndexCount(tempIndex);
				dataGridViewCustom.DataSource = tempTable;
				dataGridViewCustom.Columns[0].HeaderText = "Date";
				dataGridViewCustom.Columns[1].HeaderText = "Keyname";
				dataGridViewCustom.Columns[2].HeaderText = "Count";
			}
		}
	}
}