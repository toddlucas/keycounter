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

namespace KeyCounter
{
  public partial class FormDebug : Form, ITextDebugger
  {
    private DebugLevel debugLevel = DebugLevel.Debug;
    
    public FormDebug()
    {
      InitializeComponent();
    }

    private void buttonDebugClear_Click(object sender, EventArgs e)
    {
      richTextBoxDebug.Clear();
    }

    private void buttonDebugClose_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    public void Debug(string msg)
    {
      Debug(msg, DebugLevel.Debug);
    }

    public void Debug(string msg, DebugLevel msgLevel)
    {
      if ((msgLevel == DebugLevel.None) || (msgLevel>debugLevel))
        return;

      Font oldFont = richTextBoxDebug.SelectionFont;
      Color oldForeColor = richTextBoxDebug.SelectionColor;
      Font newFont = oldFont;
      Color newForeColor = oldForeColor;

      switch (msgLevel)
      {
        case DebugLevel.Critical:
          newFont = new Font(oldFont, FontStyle.Bold);
          newForeColor = Color.Red;
          break;

        case DebugLevel.Error:
          newFont = new Font(oldFont, FontStyle.Regular);
          newForeColor = Color.Red;
          break;

        case DebugLevel.Warning:
          newFont = new Font(oldFont, FontStyle.Regular);
          newForeColor = Color.Orange;
          break;

        case DebugLevel.Info:
          newFont = new Font(oldFont, FontStyle.Regular);
          newForeColor = Color.LightGreen;
          break;

        case DebugLevel.Debug:
          newFont = new Font(oldFont, FontStyle.Regular);
          newForeColor = Color.MediumBlue;
          break;
      }

      richTextBoxDebug.SelectionFont = newFont;
      richTextBoxDebug.SelectionColor = newForeColor;
      richTextBoxDebug.AppendText(msg + Environment.NewLine);
      richTextBoxDebug.SelectionFont = oldFont;
      richTextBoxDebug.SelectionColor = oldForeColor;

      richTextBoxDebug.ScrollToCaret();
    }

    public void SetLevel(DebugLevel level)
    {
      this.debugLevel = level;
    }

    public DebugLevel GetLevel()
    {
      return this.debugLevel;
    }
  }
}