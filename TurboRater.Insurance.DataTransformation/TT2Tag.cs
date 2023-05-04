using System;
using System.Collections;

namespace TurboRater.Insurance.DataTransformation
{
  /// <summary>
  /// Represents an individual TT2 tag line
  /// </summary>
  public class TT2Tag : IComparable
  {

    #region Private Variables
    private static readonly string TagDelimiter = "\",\"";
    private static readonly char ScopeDelimiter = ':';
    private string m_tagName = "";
    private ItemScope m_tagScope = ItemScope.Policy;
    private ItemScope m_secondaryScope = ItemScope.Policy;
    private int m_scopeNum;
    private int m_secondaryScopeNum;
    private ArrayList m_values = new ArrayList();
    #endregion Private Variables

    #region Public Properties
    /// <summary>
    /// Contains the values of the TT2 line
    /// </summary>
    public virtual ArrayList Values
    {
      get { return m_values; }
      set { m_values = value; }
    }

    /// <summary>
    /// The scope number of the tag
    /// </summary>
    public virtual int ScopeNum
    {
      get { return m_scopeNum; }
      set { m_scopeNum = value; }
    }

    /// <summary>
    /// The secondary scope number of the tag (tags can have two 
    /// scopes, such as violations that have a driver scope and a
    /// violation scope)
    /// </summary>
    public virtual int SecondaryScopeNum
    {
      get { return m_secondaryScopeNum; }
      set { m_secondaryScopeNum = value; }
    }

    /// <summary>
    /// The type of scope of the tag (policy, car, etc)
    /// </summary>
    public virtual ItemScope TagScope
    {
      get { return m_tagScope; }
      set { m_tagScope = value; }
    }

    /// <summary>
    /// The secondary scope type of the tag (tags can have two 
    /// scopes, such as violations that have a driver scope and a
    /// violation scope)
    /// </summary>
    public virtual ItemScope SecondaryScope
    {
      get { return m_secondaryScope; }
      set { m_secondaryScope = value; }
    }

    /// <summary>
    /// Tag's name 
    /// </summary>
    public virtual string TagName
    {
      get { return m_tagName; }
      set { m_tagName = value; }
    }

    /// <summary>
    /// A string representing the entire TT2 tag line
    /// </summary>
    public virtual string TagLine
    {
      get { return CalculateTagLine(); }
      set { ParseTagLine(value); }
    }
    #endregion Public Properties

    #region Methods
    /// <summary>
    /// Calculates the entire TT2 tag line; used by the property TagLine
    /// </summary>
    /// <returns></returns>
    public virtual string CalculateTagLine()
    {
      string tempResult = "";
      tempResult += "\"" + TagName + "\",";
      tempResult += "\"" + TT2Tag.GetScopeString(TagScope) + ScopeNum.ToString();
      if ((SecondaryScope == ItemScope.Violation) || (SecondaryScope == ItemScope.Suspension) || (SecondaryScope == ItemScope.Car))
        tempResult += ":" + TT2Tag.GetScopeString(SecondaryScope) + SecondaryScopeNum.ToString();
      tempResult += "\"";
      foreach (object value in Values)
        tempResult += ",\"" + value.ToString() + "\"";
      return tempResult;
    }

    /// <summary>
    /// Given a scope (the type of scope), returns a string 
    /// representing what that scope should look like in TT2 data.
    /// For example, if you pass in ItemScope.Policy, this will
    /// return "pol"
    /// </summary>
    /// <param name="scope">The scope to convert to a string</param>
    /// <returns>The TT2 string representation of the scope</returns>
    public static string GetScopeString(ItemScope scope)
    {
      switch (scope)
      {
        case ItemScope.Policy:
          return "pol";
        case ItemScope.Driver:
          return "drv";
        case ItemScope.Car:
          return "car";
        case ItemScope.Violation:
          return "vio";
        case ItemScope.Suspension:
          return "sus";
        case ItemScope.PayPlan:
          return "ppl";
        case ItemScope.Exclusion:
          return "exc";
        case ItemScope.System:
          return "sys";
        case ItemScope.Record:
          return "rec";
        case ItemScope.MisPremium:
          return "mpr";
        case ItemScope.Insured:
          return "ins";
        case ItemScope.Quote:
          return "quo";
        case ItemScope.Notes:
          return "not";
        case ItemScope.Address:
          return "adr";
        case ItemScope.Comparison:
          return "com";
      }
      return "pol";
    }

    /// <summary>
    /// Converts a scope type string (such as "POL") into an actual 
    /// tag scope (such as ItemScope.Policy)
    /// </summary>
    /// <param name="scopeTypeValue">The scope type string that 
    /// we're going to parse</param>
    /// <returns>The ItemScope value corresponding to the 
    /// passed in scopeTypeValue</returns>
    protected ItemScope ParseItemScopeTypeString(string scopeTypeValue)
    {
      switch (scopeTypeValue.ToUpper())
      {
        case "POL":
          return ItemScope.Policy;
        case "DRV":
          return ItemScope.Driver;
        case "CAR":
          return ItemScope.Car;
        case "VIO":
          return ItemScope.Violation;
        case "PPL":
          return ItemScope.PayPlan;
        case "EXC":
          return ItemScope.Exclusion;
        case "SYS":
          return ItemScope.System;
        case "REC":
          return ItemScope.Record;
        case "MPR":
          return ItemScope.MisPremium;
        case "INS":
          return ItemScope.Insured;
        case "QUO":
          return ItemScope.Quote;
        case "NOT":
          return ItemScope.Notes;
        case "ADR":
          return ItemScope.Address;
        case "COM":
          return ItemScope.Comparison;
        case "SUS":
          return ItemScope.Suspension;
        case "RNB":
          return ItemScope.CarrierReasonNotBound;
      }
      throw new Exception("Invalid scope type value '" + scopeTypeValue + "'.");
    }

    /// <summary>
    /// Parses a TT2 tag line (string) and plops it's data
    /// into this object's properties.
    /// </summary>
    /// <param name="tagLine">The TT2 tag line to parse</param>
    public virtual void ParseTagLine(string tagLine)
    {
      try
      {
        //get tag name
        string butcheredTag = tagLine;
        int rightDelimiter = -1;
        rightDelimiter = butcheredTag.IndexOf("\",", 0, StringComparison.OrdinalIgnoreCase);
        TagName = butcheredTag.Substring(1, rightDelimiter - 1);
        //if we ran into the header tag, just leave the method after adding an empty value
        if (TagName.Trim().Equals("tagname", StringComparison.OrdinalIgnoreCase))
        {
          if (Values.Count == 0)
            Values.Add("");
          return;
        }
        butcheredTag = butcheredTag.Substring(rightDelimiter);
        //get scope type and scope num
        rightDelimiter = butcheredTag.IndexOf("\",", 1, StringComparison.OrdinalIgnoreCase);
        int middleDelimiter = butcheredTag.IndexOf(":", 0, rightDelimiter, StringComparison.OrdinalIgnoreCase);
        string scopeTypeString = butcheredTag.Substring(3, 3);
        TagScope = ParseItemScopeTypeString(scopeTypeString);

        //peh-fix for having a scopenum with > 1 digit
        string scopeNum = butcheredTag.Substring(6, rightDelimiter - 6);
        if (middleDelimiter > -1)
          scopeNum = butcheredTag.Substring(6, middleDelimiter - 6);
        int baseScopeNumDigits = scopeNum.Length;

        try
        {
          ScopeNum = Int32.Parse(scopeNum);
        }
        catch (Exception ex)
        {
          throw new Exception(ex.Message + "::" + butcheredTag + "::" + scopeNum, ex);
        }
        //if there's a secondary scope, get it now too
        if (butcheredTag.Substring(0, rightDelimiter).IndexOf(":", StringComparison.OrdinalIgnoreCase) != -1)
        {
          string secondaryScopeTypeString = butcheredTag.Substring(8 + baseScopeNumDigits - 1, 3);
          SecondaryScope = ParseItemScopeTypeString(secondaryScopeTypeString);

          string secondaryScopeNum;
          if ((SecondaryScope == ItemScope.Violation) || (SecondaryScope == ItemScope.Suspension) || (SecondaryScope == ItemScope.Car))
          {
            secondaryScopeNum = butcheredTag.Substring(11 + baseScopeNumDigits - 1, rightDelimiter - 11);
          }
          else
          {
            secondaryScopeNum = butcheredTag.Substring(11 + baseScopeNumDigits - 1, 1);
          }
          try
          {
            SecondaryScopeNum = Int32.Parse(secondaryScopeNum.Replace("\"", ""));
          }
          catch (Exception ex)
          {
            throw new Exception(ex.Message + "::" + butcheredTag + "::" + secondaryScopeNum, ex);
          }
        }
        butcheredTag = butcheredTag.Substring(rightDelimiter);
        //get the values. this code assumes there will be at least 1 value
        do
        {
          rightDelimiter = butcheredTag.IndexOf("\",", 1, StringComparison.OrdinalIgnoreCase);
          //if there's more than one value, make sure we get all values
          if ((rightDelimiter != -1) && (!butcheredTag.StartsWith("\",\",", StringComparison.OrdinalIgnoreCase)))
          {
            Values.Add(butcheredTag.Substring(3, rightDelimiter - 3));
            butcheredTag = butcheredTag.Substring(rightDelimiter);
          }
          else
            rightDelimiter = -1;
        } while (rightDelimiter != -1);
        rightDelimiter = butcheredTag.Trim().Length;
        Values.Add(butcheredTag.Substring(3, rightDelimiter - 4));
        if (Values.Count > 0)
          Values[Values.Count - 1] = ((string)Values[Values.Count - 1]).Replace("\"", "'");
      }
      catch
      {
        if (Values.Count == 0)
          Values.Add("");
        //eat exceptions thrown by invalid lines. This way they'll just be ignored
      }
    }

    /// <summary>
    /// Determines if two tt2tag objects are the same, other than the tag's value
    /// </summary>
    /// <param name="target">the target tag</param>
    /// <returns>true if they're the same, otherwise false</returns>
    public virtual bool EqualsExceptValue(object target)
    {
      TT2Tag tempTag = (TT2Tag)target;
      bool tempResult = (this.ScopeNum == tempTag.ScopeNum) &&
        (this.SecondaryScope == tempTag.SecondaryScope) &&
        (this.SecondaryScopeNum == tempTag.SecondaryScopeNum) &&
        (this.TagName.ToUpper() == tempTag.TagName.ToUpper()) &&
        (this.TagScope == tempTag.TagScope);
      return tempResult;
    }

    /// <summary>
    /// Default compararer for sorting (by tag name).  Speeds up the sorting by a factor of 5 over the GenericObjectComparer
    /// </summary>
    /// <param name="obj">The object to compare to.</param>
    /// <returns></returns>
    public int CompareTo(object obj)
    {
      return String.Compare(this.TagName.Trim(), ((TT2Tag)obj).TagName.Trim(), StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>Formats parameters into a string that can be appended to a tt2.</summary>
    /// <remarks>Automatically adds surrounding quotation marks and a trailing Environment.NewLine</remarks>
    /// <param name="tagName">Name of tag</param>
    /// <param name="scope">Primary scope</param>
    /// <param name="scopeNum">Primary scope number</param>
    /// <param name="values">Value(s) of tag, can be null</param>
    /// <param name="valueDelimiter">Optional value delimiter</param>
    /// <returns>TT2 tag formatted as a string with newline.</returns>
    public static string FormatTT2(string tagName, ItemScope scope, int scopeNum, string[] values, bool addNewLine = true, string valueDelimiter = "\",\"")
    {
      string scopeStr = TT2Tag.GetScopeString(scope);
      string valuesStr;

      if (values == null)
        valuesStr = string.Empty;
      else
        valuesStr = string.Join(valueDelimiter, values);

      return "\"" + string.Join(TagDelimiter, new[] { tagName, scopeStr + scopeNum.ToString(), valuesStr }) + "\"" + Environment.NewLine;
    }

    /// <summary>Formats parameters into a string that can be appended to a tt2.</summary>
    /// <remarks>Automatically adds surrounding quotation marks and a trailing Environment.NewLine</remarks>
    /// <param name="tagName">Name of tag</param>
    /// <param name="primaryScope">Primary scope</param>
    /// <param name="primaryScopeNum">Primary scope number</param>
    /// <param name="secondaryScope">Seconary scope</param>
    /// <param name="secondaryScopeNum">Secondary scope number</param>
    /// <param name="values">Value(s) of tag, can be null</param>
    /// <param name="addNewLine">[Optional] Whether to add a new line (Default: True)</param>
    /// <param name="valueDelimiter">[Optional] value delimiter (Default: ",")</param>
    /// <returns>TT2 tag formatted as a string with newline.</returns>
    public static string FormatTT2(string tagName, ItemScope primaryScope, int primaryScopeNum, ItemScope secondaryScope, int secondaryScopeNum, string[] values, bool addNewLine = true, string valueDelimiter = "\",\"")
    {
      string scopeStr = TT2Tag.GetScopeString(primaryScope);
      string scope2Str = TT2Tag.GetScopeString(secondaryScope);
      string valuesStr;

      if (values == null)
        valuesStr = string.Empty;
      else
        valuesStr = string.Join(valueDelimiter, values);

      return "\"" + string.Join(TagDelimiter, new[] { tagName, scopeStr + primaryScopeNum.ToString() + ScopeDelimiter + scope2Str + secondaryScopeNum.ToString(), valuesStr }) + "\"" + Environment.NewLine;
    }

    #endregion Methods

    #region Constructors and Destructors
    /// <summary>
    /// Constructor
    /// </summary>
    public TT2Tag()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="tagLine"></param>
    public TT2Tag(string tagLine)
    {
      this.TagLine = tagLine;
    }
    #endregion Constructors and Destructors

  }
}
