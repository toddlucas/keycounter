/*
   Counter classes for automated key counting and data evaluation
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
/*
 * for users: 
 *  Try to avoid any direct manipulation of private data structures within the classes,
 *  because otherwise the counter values may become wrong.
 *  Its recommended to use the supplied public methods.
 * 
 *  Warning: To achieve the best performance it is only guaranteed that the Count-functions
 *  consolidate those entries in countTab that are not preceded by any entry with a later
 *  date than the one to be added. Especially consider that in case you want to add data from
 *  earlier records using the Count-functions.
 *  Maybe an extra interface for such tasks will be added later.
 * 
 * THX to UNCLE JAMAL for inspiration, testing and all classes that went into KeyCounter.WinHook 
 * namespace (plus a demo program) !
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;

namespace KeyCounter.Counter
{
  namespace Filters
  {
    abstract public class FilterBasic<TKeyId>
    {
      public bool removeOnMatch = false;

      public FilterBasic(bool removeOnMatch)
      {
        this.removeOnMatch = removeOnMatch;
      }

      /* 
       * Basic prototype for a filter function
       * The parameter 'countTabEntry' is tested against the internal filter settings,
       * returns true if countTabEntry matches the filter, false otherwise
       */
      abstract public bool Filter(CountTabEntry<TKeyId> countTabEntry);

      /*
       * Test if the supplied 'countTabEntry' should be removed; the decision is based on
       * the result of Filter()
       */
      public bool ShouldRemove(CountTabEntry<TKeyId> countTabEntry)
      {
        bool filterResult = Filter(countTabEntry);
        bool shouldRemove = false;

        if (this.removeOnMatch)
          shouldRemove = filterResult;
        else
          shouldRemove = !filterResult;

        return shouldRemove;
      }
    }

    public class FilterMatchDate<TKeyId> : FilterBasic<TKeyId>
    {
      public DateTime dateToMatch;

      public FilterMatchDate(DateTime dateToMatch, bool removeOnMatch)
        : base(removeOnMatch)
      {
        this.dateToMatch = dateToMatch;
      }

      public override bool Filter(CountTabEntry<TKeyId> countTabEntry)
      {
        bool result = false;

        if (this.dateToMatch == countTabEntry.dateTime.Date)
          result = true;

        return result;
      }
    }

    public class FilterMatchDateList<TKeyId> : FilterBasic<TKeyId>
    {
      public List<DateTime> dateListToMatch = null;

      public FilterMatchDateList(List<DateTime> dateListToMatch, bool removeOnMatch)
        : base(removeOnMatch)
      {
        this.dateListToMatch = dateListToMatch;
      }

      public override bool Filter(CountTabEntry<TKeyId> countTabEntry)
      {
        bool result = false;

        foreach (DateTime dateInList in this.dateListToMatch)
        {
          if (countTabEntry.dateTime.Date == dateInList.Date)
          {
            result = true;
            break;
          }
        }

        return result;
      }
    }

    public class FilterMatchDateRange<TKeyId> : FilterBasic<TKeyId>
    {
      public DateTime startDate;
      public DateTime endDate;

      public FilterMatchDateRange(DateTime startDate, DateTime endDate, bool removeOnMatch)
        : base(removeOnMatch)
      {
        this.startDate = startDate.Date;
        this.endDate = endDate.Date;
      }

      public override bool Filter(CountTabEntry<TKeyId> countTabEntry)
      {
        bool result = false;

        if ((countTabEntry.dateTime.Date >= this.startDate.Date) && (countTabEntry.dateTime.Date <= this.endDate.Date))
          result = true;

        return result;
      }
    }

    public class FilterMatchDateLessOrEqual<TKeyId> : FilterBasic<TKeyId>
    {
      public DateTime dateMaximum;

      public FilterMatchDateLessOrEqual(DateTime dateMaximum, bool removeOnMatch)
        : base(removeOnMatch)
      {
        this.dateMaximum = dateMaximum.Date;
      }

      public override bool Filter(CountTabEntry<TKeyId> countTabEntry)
      {
        bool result = false;

        if (countTabEntry.dateTime.Date <= this.dateMaximum.Date)
          result = true;

        return result;
      }
    }

    public class FilterMatchDateBigger<TKeyId> : FilterBasic<TKeyId>
    {
      public DateTime dateMinimum;

      public FilterMatchDateBigger(DateTime dateMinimum, bool removeOnMatch)
        : base(removeOnMatch)
      {
        this.dateMinimum = dateMinimum.Date;
      }

      public override bool Filter(CountTabEntry<TKeyId> countTabEntry)
      {
        bool result = false;

        if (countTabEntry.dateTime.Date > this.dateMinimum.Date)
          result = true;

        return result;
      }
    }

    public class FilterMatchKey<TKeyId> : FilterBasic<TKeyId>
    {
      public TKeyId keyToMatch;

      public FilterMatchKey(TKeyId keyToMatch, bool removeOnMatch)
        : base(removeOnMatch)
      {
        this.keyToMatch = keyToMatch;
      }

      public override bool Filter(CountTabEntry<TKeyId> countTabEntry)
      {
        bool result = false;

        if (countTabEntry.keyId.Equals(this.keyToMatch))
          result = true;

        return result;
      }
    }

    public class FilterMatchKeyList<TKeyId> : FilterBasic<TKeyId>
    {
      public List<TKeyId> keyListToMatch = null;

      public FilterMatchKeyList(List<TKeyId> keyListToMatch, bool removeOnMatch)
        : base(removeOnMatch)
      {
        this.keyListToMatch = keyListToMatch;
      }

      public override bool Filter(CountTabEntry<TKeyId> countTabEntry)
      {
        bool result = false;

        foreach (TKeyId keyInList in keyListToMatch)
        {
          if (countTabEntry.keyId.Equals(keyInList))
          {
            result = true;
            break;
          }
        }

        return result;
      }
    }
  }

  // one entry for the CountTab:
  [Serializable()]
  public class CountTabEntry<TKeyId>
  {
    public DateTime dateTime;
    public TKeyId keyId;
    public uint count;
    public bool isSummarized;

    public CountTabEntry(DateTime dateTime, TKeyId keyId, uint count, bool isSummarized)
    {
      this.dateTime = dateTime;
      this.keyId = keyId;
      this.count = count;
      this.isSummarized = isSummarized;
    }
  }

  [Serializable()]
  public class CountTab<TKeyId>
  {
    private List<CountTabEntry<TKeyId>> countTab = null;

    public CountTab()
    {
      this.countTab = new List<CountTabEntry<TKeyId>>();
    }

    public CountTab(CountTab<TKeyId> oldTab)
    {
      this.countTab = new List<CountTabEntry<TKeyId>>(oldTab.countTab);
    }

    public void Count(DateTime date, TKeyId keyId, uint ticks)
    {
      DateTime dateOnly = date.Date;
      bool foundEntry = false;
      int index = 0;

      if (countTab.Count > 0)
      {
        for (index = countTab.Count - 1; index >= 0; index--)
        {
          if (countTab[index].dateTime.Date < dateOnly)
            break;

          if ((countTab[index].keyId.Equals(keyId)) && (countTab[index].dateTime.Date == dateOnly))
          {
            foundEntry = true;
            break;
          }
        }
      }

      if (foundEntry)
      {
        countTab[index].count += ticks;
      }
      else
        countTab.Add(new CountTabEntry<TKeyId>(dateOnly, keyId, ticks, false));
    }

    public void Clear()
    {
      countTab.Clear();
    }

    public int RowCount()
    {
      return countTab.Count;
    }

    public CountTabEntry<TKeyId> this[int index]
    {
      get
      {
        return this.countTab[index];
      }
    }
  }

  [Serializable()]
  public class KeyTab<TKeyId>
  {
    private Dictionary<TKeyId, string> keyIdToName = null;
    private Dictionary<string, TKeyId> keyNameToId = null;

    public KeyTab(Dictionary<TKeyId, string> keyIdToName)
    {
      this.keyIdToName = keyIdToName;
      keyNameToId = new Dictionary<string, TKeyId>();
      UpdateDictKeyIdToName(keyIdToName);
    }

    public KeyTab(Dictionary<string, TKeyId> keyNameToId)
    {
      this.keyNameToId = keyNameToId;
      keyIdToName = new Dictionary<TKeyId, string>();
      UpdateDictKeyNameToId(keyNameToId);
    }

    //Determine if KeyTab knows about a specific keyName. Returns true for known keys, false otherwise.
    public bool ContainsKeyName(string keyName)
    {
      return this.keyNameToId.ContainsKey(keyName);
    }

    //Determine if KeyTab knows about a specific keyId. Returns true for known keys, false otherwise.
    public bool ContainsKeyId(TKeyId keyId)
    {
      return this.keyIdToName.ContainsKey(keyId);
    }

    //Try to find a keyName in KeyTab; returns true for known keys, false for unknown ones; keyId is used as keyId output
    public bool TryGetKeyId(string keyName, out TKeyId keyId)
    {
      if (keyNameToId.TryGetValue(keyName, out keyId))
        return true;
      else
        return false;
    }

    //Try to find a keyId in KeyTab; returns true for known keys, false for unknown ones; keyId is used as keyId output
    public bool TryGetKeyName(TKeyId keyId, out string keyName)
    {
      if (keyIdToName.TryGetValue(keyId, out keyName))
        return true;
      else
        return false;
    }

    //Find out how many keys are registred in keyTab
    public int RowCount()
    {
      return keyIdToName.Count;
    }

    //Return a complete list of registered keyIDs; same order as NameList
    public List<TKeyId> KeyIdList()
    {
      List<TKeyId> fullIdList = new List<TKeyId>();
      Dictionary<TKeyId, string>.KeyCollection keyColl = this.keyIdToName.Keys;

      foreach (TKeyId singleId in keyColl)
        fullIdList.Add(singleId);

      return fullIdList;
    }

    //Return a complete list of registered keyNames; same order as IdList
    public List<string> KeyNameList()
    {
      List<string> fullNameList = new List<string>();
      Dictionary<string, TKeyId>.KeyCollection keyColl = this.keyNameToId.Keys;

      foreach (string singleName in keyColl)
        fullNameList.Add(singleName);

      return fullNameList;
    }

    private void UpdateDictKeyIdToName(Dictionary<TKeyId, string> keyIdToName)
    {
      this.keyNameToId.Clear();

      foreach (KeyValuePair<TKeyId, string> buffer in keyIdToName)
        this.keyNameToId.Add(buffer.Value, buffer.Key);
    }

    private void UpdateDictKeyNameToId(Dictionary<string, TKeyId> keyNameToId)
    {
      this.keyIdToName.Clear();

      foreach (KeyValuePair<string, TKeyId> buffer in keyNameToId)
        this.keyIdToName.Add(buffer.Value, buffer.Key);
    }
  }

  public class NoKeyEntryException : Exception
  {
    private string keyInfo = "";

    public NoKeyEntryException()
    {
    }

    public NoKeyEntryException(string keyInfo)
    {
      this.keyInfo = keyInfo;
    }

    public override string ToString()
    {
      return base.ToString() + " key: " + keyInfo;
    }
  }

  public class CounterEngine<TKeyId>
  {
    public CountTab<TKeyId> countTab = null;  //actual key-counter
    public KeyTab<TKeyId> keyTab = null;  //assignment of keyname->id and vice versa
    public DateTime tempCounterStart;
    public DateTime lastReset;    
    public DateTime lastStart;
    public DateTime lastUptimeCount;
    public TimeSpan uptimeSinceReset;
    public TimeSpan uptimeSinceStart;
    public TimeSpan uptimeTotal;
    public ITextDebugger textDebugger = null;

    public CounterEngine(KeyTab<TKeyId> keyTab, ITextDebugger textDebugger)
      : this(keyTab, new CountTab<TKeyId>(), textDebugger)
    {
    }

    private CounterEngine(KeyTab<TKeyId> keyTab, CountTab<TKeyId> countTab, ITextDebugger textDebugger)
    {
      this.countTab = countTab;
      this.keyTab = keyTab;
      this.tempCounterStart = DateTime.Now.Date;
      this.lastReset = DateTime.Now;
      this.lastStart = DateTime.Now;
      this.lastUptimeCount = DateTime.Now;
      this.uptimeSinceReset = new TimeSpan(0);
      this.uptimeSinceStart = new TimeSpan(0);
      this.uptimeTotal = new TimeSpan(0);
      this.textDebugger = textDebugger;
    }

    private void Debug (string msg, DebugLevel msgLevel)
    {
      if (this.textDebugger != null)
        textDebugger.Debug(msg, msgLevel);
    }
    
    public void UpdateUpTime (int estimatedTimeMs)
    {
      TimeSpan additionalUptime = DateTime.Now - lastUptimeCount;
      lastUptimeCount = DateTime.Now;

      if (additionalUptime > (new TimeSpan(0)))
      {
        if ((Math.Abs(estimatedTimeMs - additionalUptime.TotalMilliseconds) < (0.5 * estimatedTimeMs)) || (estimatedTimeMs == 0))
        {
          this.uptimeSinceReset += additionalUptime;
          this.uptimeSinceStart += additionalUptime;
          this.uptimeTotal += additionalUptime;
          Debug("CounterEngine.UpdateUpTime() successful", DebugLevel.Debug);
        }
        else
          Debug(String.Format("CounterEngine.UpdateUpTime() rejected due to time deviation: {0:F3}s", additionalUptime.TotalSeconds - ((double)estimatedTimeMs / 1000)), DebugLevel.Debug);
      }
      else
        Debug(String.Format("CounterEngine.UpdateUpTime() rejected due to negative/null additionalUptime: {0:F3}s", additionalUptime.TotalSeconds), DebugLevel.Warning);      
    }

    #region COUNTTAB-MANIPULATION
    public void Count(DateTime date, TKeyId keyId, uint ticks)
    {
      if (!keyTab.ContainsKeyId(keyId))
        throw new NoKeyEntryException("key with keyId=" + keyId.ToString() + " not found");

      countTab.Count(date, keyId, ticks);
    }

    public void Count(DateTime date, string keyName, uint ticks)
    {
      TKeyId keyId;

      if (!keyTab.ContainsKeyName(keyName))
        throw new NoKeyEntryException("key with keyName=" + keyName + " not found");
      else
        keyTab.TryGetKeyId(keyName, out keyId);

      Count(date, keyId, ticks);
    }

    public void ClearCounter()
    {
      this.countTab.Clear();

      this.lastUptimeCount = DateTime.Now;
      this.tempCounterStart = DateTime.Now.Date;
      this.lastReset = DateTime.Now;
      this.uptimeSinceReset = new TimeSpan(0);
    }

    public void ClearTempCounter()
    {
      this.tempCounterStart = DateTime.Now.Date;
    }

    #endregion

    #region QUERIES
    public List<int> IndexBuild()
    {
      List<int> output = new List<int>();
      int numOfRows = countTab.RowCount();

      for (int index = 0; index < numOfRows; index++)
        output.Add(index);

      return output;
    }

    public void IndexApplyFilter(Filters.FilterBasic<TKeyId> filter, List<int> countTabIndex)
    {
      for (int listIndex = countTabIndex.Count - 1; listIndex >= 0; listIndex--)
      {
        if (filter.ShouldRemove(countTab[countTabIndex[listIndex]]))
          countTabIndex.Remove(listIndex);
      }
    }

    public void IndexApplyFilter(List<Filters.FilterBasic<TKeyId>> filterList, List<int> countTabIndex)
    {
      foreach (Filters.FilterBasic<TKeyId> filterInList in filterList)
        IndexApplyFilter(filterInList, countTabIndex);
    }

    public uint IndexCountSum(List<int> countTabIndex)
    {
      uint count = 0;

      foreach (int indexInCounttab in countTabIndex)
        count += this.countTab[indexInCounttab].count;

      return count;
    }

    public DataTable CompleteTable()
    {
      DataTable table = new DataTable();
      table.Columns.Clear();
      table.Columns.Add("date", typeof(DateTime));
      table.Columns.Add("keyId", typeof(TKeyId));
      table.Columns.Add("count", typeof(uint));

      for (int index=0; index<countTab.RowCount(); index++)
        table.Rows.Add(new object[] { countTab[index].dateTime.Date, countTab[index].keyId, countTab[index].count });
      
      return table;
    }

    public DataTable IndexCount (List<int> countTabIndex)
    {
      DataTable table = new DataTable();
      int index;
      TKeyId keyId;
      string keyName;

      table.Columns.Clear();
      table.Columns.Add("date", typeof(DateTime));
      table.Columns.Add("key", typeof(string));
      table.Columns.Add("count", typeof(uint));

      for (int indexInIndex = 0; indexInIndex < countTabIndex.Count; indexInIndex++)
      {
        index = countTabIndex[indexInIndex];
        keyId = countTab[index].keyId;
        keyTab.TryGetKeyName(keyId, out keyName);

        table.Rows.Add(new object[] { countTab[index].dateTime.Date, keyName, countTab[index].count });
      }

      return table;
    }

    public DataTable IndexCountByDate(List<int> countTabIndex)
    {
      uint tempCount;
      int indexInIndex;

      DataTable table = new DataTable();
      table.Clear();
      table.Columns.Add("date", typeof(DateTime));
      table.Columns.Add("count", typeof(uint));
      table.Rows.Clear();

      List<int> indexListCopy = new List<int>(countTabIndex);

      while (indexListCopy.Count > 0)
      {
        tempCount = 0;
        indexInIndex = indexListCopy.Count - 1;
        DateTime dateBuffer = this.countTab[indexListCopy[indexInIndex]].dateTime.Date;

        while (indexInIndex >= 0)
        {
          if (this.countTab[indexListCopy[indexInIndex]].dateTime.Date == dateBuffer)
          {
            tempCount += this.countTab[indexListCopy[indexInIndex]].count;
            indexListCopy.RemoveAt(indexInIndex);
          }

          indexInIndex--;
        }

        if (tempCount > 0)
          table.Rows.Add(new object[] { dateBuffer.Date, tempCount });
      }

      return table;
    }

    public DataTable IndexCountByKey(List<int> countTabIndex)
    {
      uint tempCount;
      int indexInIndex;

      DataTable table = new DataTable();
      table.Clear();
      table.Columns.Add("key", typeof(string));
      table.Columns.Add("count", typeof(uint));
      table.Rows.Clear();

      List<int> indexListCopy = new List<int>(countTabIndex);

      while (indexListCopy.Count > 0)
      {
        tempCount = 0;
        indexInIndex = indexListCopy.Count - 1;
        TKeyId keyIdBuffer = this.countTab[indexListCopy[indexInIndex]].keyId;
        string keyNameBuffer;
        keyTab.TryGetKeyName(keyIdBuffer, out keyNameBuffer);

        while (indexInIndex >= 0)
        {
          if (this.countTab[indexListCopy[indexInIndex]].keyId.Equals(keyIdBuffer))
          {
            tempCount += this.countTab[indexListCopy[indexInIndex]].count;
            indexListCopy.RemoveAt(indexInIndex);
          }

          indexInIndex--;
        }

        if (tempCount > 0)
          table.Rows.Add(new object[] { keyNameBuffer, tempCount });
      }

      return table;
    }
    #endregion

    #region FILEHANDLING
    public void SaveBinary (string filePath)
    {
      UpdateUpTime(0);

      FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
      BinaryFormatter formatter = new BinaryFormatter();
      formatter.Serialize(stream, this.countTab);
      formatter.Serialize(stream, this.keyTab);
      formatter.Serialize(stream, this.lastReset);
      formatter.Serialize(stream, this.tempCounterStart);
      formatter.Serialize(stream, this.uptimeTotal);
      formatter.Serialize(stream, this.uptimeSinceReset);
      stream.Close();
    }

    public void ReadBinary(string filePath)
    {
      FileStream stream = null;

      stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
      BinaryFormatter formatter = new BinaryFormatter();
      this.countTab = (CountTab<TKeyId>)formatter.Deserialize(stream);
      this.keyTab = (KeyTab<TKeyId>)formatter.Deserialize(stream);
      this.lastReset = (DateTime)formatter.Deserialize(stream);
      this.tempCounterStart = (DateTime)formatter.Deserialize(stream);
      this.uptimeTotal = (TimeSpan)formatter.Deserialize(stream);
      this.uptimeSinceReset = (TimeSpan)formatter.Deserialize(stream);

      stream.Close();
    }
    #endregion
  }
}
