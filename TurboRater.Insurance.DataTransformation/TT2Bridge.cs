using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;

namespace TurboRater.Insurance.DataTransformation
{
  /// <summary>
  /// Represents a TT2 bridge...this class will be descended
  /// from for each Insurance Line. 
  /// </summary>
  public class TT2Bridge : InsBridge
  {
    TT2TagList m_tags = new TT2TagList();
    private bool m_excludeJobControlTags;
    private bool m_allowImportWarningsErrors = true;
    private bool m_allowImportDiscountsSurcharges = true;
    private bool m_treatInsuredAsDriver = true;
    private bool m_useWebInvalidDate = true;
    private bool m_stripZipCodeEditMask;
    private bool m_useWindowsBlankLimitValue;
    private bool m_exportInsuredWithInsScope;
    private bool m_excludeBridgeDataStorageTags = true;
    private bool m_exportIncludedPremiumString;
    private bool m_exportMailingAddressOnly;
    private bool m_applyExclusionCodeToData;
    private bool m_includeIgnoredDrivers;
    private bool m_includeIgnoredCars;

    /// <summary>
    /// Used for premiums that are included within some other premium
    /// </summary>
    public static string IncludedPremiumString = "id_included";

    #region Tag Name Constants
    public const string TAG_REALTIME_SHOW_PROCESS_WARNING = "rtrshowprocesswarning";
    #endregion Tag Name Constants

    /// <summary>
    /// Stored fields in this list are NOT export as part of a tt2 export.
    /// </summary>
    public static readonly string[] ExcludedExportTags = 
		{
			"CompanyDataStorage",
			"NonStoredDataStorage",
			"CompanyModuleContentsDataStorage",
			"CompanyQuestions",
			"Cars",
			"Drivers",
			"Errors",
			"Warnings",
			"DiscountMessage",
			"DiscountMessages",
			"SurchargeMessages",
			"Exclusions",
			"Violation",
			"ApplicationData",
			"ApplicationBlob",
			"Insured",
			"MailingAddress",
			"MiscPremiums",
			"Notes",
			"Policy",
			"Quote",
			"CoveragesByCar",
      "TT2Data",
      "ComparisonCars",
      "ParentPolicy",
      "SecondaryWarnings",
      "SecondaryDiscountMessages",
      "SecondarySurchargeMessages",
      "ComparisonDrivers",
      "UnitScope",
      "Symbol",
      "HighRisk",
      "DMVActions",
      "CarrierMessages",
      "CarrierReasonNotBoundList"
    };

    /// <summary>
    /// field names that will not be imported during a tt2 import
    /// </summary>
    public static string[] ExcludedImportTags = 
		{
			"TagName"
		};

    /// <summary>
    /// If you set this to true before you transform a policy into tt2 data,
    /// then none of the jc* tags will be exported. This includes tags such as
    /// jcBumpLimits, jcEmbedFiles, etc. These are all control tags used by the
    /// rate engine. Default false.
    /// </summary>
    public virtual bool ExcludeJobControlTags
    {
      get { return m_excludeJobControlTags; }
      set { m_excludeJobControlTags = value; }
    }


    /// <summary>
    /// If you set this to false before transforming the policy
    /// into tt2 data, then it will export the bd* tags.  bd* tags
    /// are bridge control tags used in two way bridging.  Default
    /// exclusion is true.  You need to set this to false to include
    /// them.
    /// </summary>
    public bool ExcludeBridgeDataStorageTags
    {
      get { return m_excludeBridgeDataStorageTags; }
      set { m_excludeBridgeDataStorageTags = value; }
    }


    /// <summary>
    /// If set to false, warning and error messages won't be imported when
    /// performing a tt2 file import. Defaults to true.
    /// </summary>
    public virtual bool AllowImportWarningsErrors
    {
      get { return m_allowImportWarningsErrors; }
      set { m_allowImportWarningsErrors = value; }
    }


    /// <summary>
    /// If set to false, discount and error messages won't be imported when
    /// performing a tt2 file import.  Defaults to true.
    /// </summary>
    public virtual bool AllowImportDiscountsSurcharges
    {
      get { return m_allowImportDiscountsSurcharges; }
      set { m_allowImportDiscountsSurcharges = value; }
    }


    /// <summary>
    /// True if Insured should be of type AUDriver,
    /// False if Insured should be of type Person.
    /// </summary>
    public bool TreatInsuredAsDriver
    {
      get { return m_treatInsuredAsDriver; }
      set { m_treatInsuredAsDriver = value; }
    }


    /// <summary>
    /// True if InvalidDate should be of web generation. (1/1/1753)
    /// False if InvalidDate should be of Windows generation. (4/7/3000)
    /// </summary>
    public bool UseWebInvalidDate
    {
      get { return m_useWebInvalidDate; }
      set { m_useWebInvalidDate = value; }
    }


    /// <summary>
    /// True if "-" should be stripped out of EMPTY zip code fields.
    /// False if "-" should be left in EMPTY zip code fields.
    /// </summary>
    public bool StripZipCodeEditMask
    {
      get { return m_stripZipCodeEditMask; }
      set { m_stripZipCodeEditMask = value; }
    }


    /// <summary>
    /// True if blank limits should be passed as 0.
    /// False if blank limits should be passed as 2147483645.
    /// </summary>
    public bool UseWindowsBlankLimitValue
    {
      get { return m_useWindowsBlankLimitValue; }
      set { m_useWindowsBlankLimitValue = value; }
    }

    /// <summary>
    /// True if IncludedPremiumString should be exported
    /// False if premium should be passed as 4294967295
    /// </summary>
    public bool ExportIncludedPremiumString
    {
      get { return m_exportIncludedPremiumString; }
      set { m_exportIncludedPremiumString = value; }
    }

    /// <summary>
    /// True if Policy.MailingAddress should be exported instead of Policy.Insured address information.
    /// False if both Policy.MailingAddress and Policy.Insured address tags should be exported.  
    /// Note: both will go out as pol0 scope.
    /// </summary>
    public bool ExportMailingAddressOnly
    {
      get { return m_exportMailingAddressOnly; }
      set { m_exportMailingAddressOnly = value; }
    }

    /// <summary>
    /// if true, will export the insured-level variables with
    /// "pol0" and "ins0" both. If false, just "pol0".
    /// </summary>
    public bool ExportInsuredWithInsScope
    {
      get { return m_exportInsuredWithInsScope; }
      set { m_exportInsuredWithInsScope = value; }
    }

    /// <summary>
    /// The sole purpose for this field is to prevent combined coverage data from either the primary or secondary
    /// (based on the exclusioncode) from going out in a COMPANY bridge.  It is defaulted to false and should stay 
    /// that way unless you are exporting a company bridge.  AMS bridges should not use an exclusioncode as they
    /// want the full data from both companies.
    /// Set to True if you want to apply the exclusion code.
    /// False if you do not.
    /// </summary>
    public bool ApplyExclusionCodeToData
    {
      get { return m_applyExclusionCodeToData; }
      set { m_applyExclusionCodeToData = value; }
    }

    /// <summary>
    /// If true, will export those drivers that are marked as
    /// ignored for rating purposes.  If false, those drivers
    /// will not be exported
    /// </summary>
    public bool IncludeIgnoredDrivers
    {
      get { return m_includeIgnoredDrivers; }
      set { m_includeIgnoredDrivers = value; }
    }

    /// <summary>
    /// If true, will export thos cars that are marked as
    /// ignored for rating purposes.  If false, those cars
    /// will not be exported
    /// </summary>
    public bool IncludeIgnoredCars
    {
      get { return m_includeIgnoredCars; }
      set { m_includeIgnoredCars = value; }
    }

    /// <summary>
    /// The TT2Tag objects generated by this bridge object
    /// </summary>
    public virtual TT2TagList Tags
    {
      get { return m_tags; }
      set { m_tags = value; }
    }


    /// <summary>
    /// Returns a string formatted as a date with leading 0's.  We are using an 
    /// object so that if something that is not a datetime is passed in, it will
    /// return what was passed in as a string, just not formatted.
    /// </summary>
    /// <param name="aDate">Date to format.</param>
    /// <returns>Returns a string formatted as a date with leading 0's.</returns>
    public static string TT2FormatDate(object aDate)
    {
      if (aDate is DateTime)
        return ((DateTime)aDate).ToString("MM/dd/yyyy");
      else
        return aDate.ToString();
    }


    /// <summary>
    /// Returns a string formatted as a time with leading 0's.  We are using an 
    /// object so that if something that is not a datetime is passed in, it will
    /// return what was passed in as a string, just not formatted.
    /// </summary>
    /// <param name="aTime">Time to format.</param>
    /// <returns>Returns a string formatted as a date time leading 0's.</returns>
    public static string TT2FormatTime(object aTime)
    {
      if (aTime is DateTime)
        return ((DateTime)aTime).ToString("hh:mm tt");
      else
        return aTime.ToString();
    }


    /// <summary>
    /// Returns a zipcode string unless the string contains ONLY an edit mask (-)
    /// in which case it returns a blank string.
    /// </summary>
    /// <param name="aZipCode">Zip Code to format.</param>
    /// <returns>Returns a zipcode string formatted as a TT2 file would expect it.</returns>
    public static string TT2FormatZipCode(string aZipCode)
    {
      if (aZipCode.Trim().Equals("-", StringComparison.OrdinalIgnoreCase))
        return "";
      else
        return aZipCode;
    }


    /// <summary>
    /// Returns true if the tag denoted by tagName should be excluded
    /// from the export, otherwise returns false.
    /// </summary>
    /// <param name="tagName">Name of the tag</param>
    /// <returns>See summary</returns>
    public virtual bool IsTagExcludedFromExport(string tagName)
    {
      //check if the tag is one that is explicitly excluded
      foreach (string tag in ExcludedExportTags)
        if (tag.Equals(tagName, StringComparison.OrdinalIgnoreCase))
          return true;
      //if we're suppposed to filter out job control tags (rate engine control tags) 
      //then check if the tag is a job control tag, if 
      if (((ExcludeJobControlTags) && (tagName.ToUpper().StartsWith("JC", StringComparison.OrdinalIgnoreCase))) ||
          ((ExcludeBridgeDataStorageTags) && (tagName.ToUpper().StartsWith("BridgeDataStorage", StringComparison.OrdinalIgnoreCase))))
        return true;

      // Check to see if we should be returning secondary company data.  The particular exclusion code doesn't matter because every primary company property is programmed to 
      // return the primary or secondary data based on the exclusion code.  We're checking to be sure the exclusioncode is not none just to be on the safe side.
      if ((ApplyExclusionCodeToData) && ((ExclusionCodes)Policy.ExclusionCode != ExclusionCodes.None) && (tagName.StartsWith("Secondary", StringComparison.OrdinalIgnoreCase)))
        return true;

      return false;
    }

    /// <summary>
    /// Puts together the tag lines for all the tags in the tt2 document.
    /// </summary>
    /// <returns>A string containing the tt2 data</returns>
    public override string ToString()
    {
      return Tags.ToString();
    }


    /// <summary>
    /// Exports a list of pay plans to TT2 data
    /// </summary>
    /// <param name="payPlans">The pay plans to export</param>
    /// <returns>TT2 string representation of the pay plans</returns>
    public virtual string ExportPayPlanInfo(PayPlanList payPlans)
    {
      return ExportPayPlanInfo(payPlans, null);
    }


    /// <summary>
    /// Exports a list of pay plans to TT2 data
    /// </summary>
    /// <param name="payPlans">The pay plans to export</param>
    /// <param name="showFactorsData">Include additional showfactors data (leave blank or null for none).</param>
    /// <returns>TT2 string representation of the pay plans</returns>
    public virtual string ExportPayPlanInfo(PayPlanList payPlans, string showFactorsData)
    {
      StringWriter sw = new StringWriter();
      int payPlanIndex = 0;

      PayPlan selectedPlan = null;
      foreach (PayPlan plan in payPlans)
        if (plan.IsSelected)
        {
          selectedPlan = plan;
          break;
        }
      if (selectedPlan == null)
        foreach (PayPlan plan in payPlans)
          if (plan.IsDefault)
          {
            selectedPlan = plan;
            break;
          }
      if (selectedPlan == null && payPlans.Count > 0)
        selectedPlan = payPlans[0];

      foreach (PayPlan payPlan in payPlans)
      {
        sw.WriteLine("\"RTRPayPlanIsSelected\",\"" + TT2Tag.GetScopeString(ItemScope.PayPlan) + payPlanIndex + "\",\"" + ITCConstants.BoolToYN(payPlan.IsSelected) + "\"");
        sw.WriteLine("\"RTRPayPlanIsDefault\",\"" + TT2Tag.GetScopeString(ItemScope.PayPlan) + payPlanIndex + "\",\"" + ITCConstants.BoolToYN(payPlan.IsDefault) + "\"");
        sw.WriteLine("\"RTRPayPlanDescription\",\"" + TT2Tag.GetScopeString(ItemScope.PayPlan) + payPlanIndex + "\",\"" + payPlan.Description + "\"");
        sw.WriteLine("\"RTRDownPaymentAmount\",\"" + TT2Tag.GetScopeString(ItemScope.PayPlan) + payPlanIndex + "\",\"" + payPlan.DownPaymentAmount + "\"");
        sw.WriteLine("\"RTRDownPaymentPercent\",\"" + TT2Tag.GetScopeString(ItemScope.PayPlan) + payPlanIndex + "\",\"" + payPlan.DownPaymentPercent + "\"");
        sw.WriteLine("\"RTRPayPlanTotalPremium\",\"" + TT2Tag.GetScopeString(ItemScope.PayPlan) + payPlanIndex + "\",\"" + payPlan.TotalPremium + "\"");
        sw.WriteLine("\"RTRNumOfPayments\",\"" + TT2Tag.GetScopeString(ItemScope.PayPlan) + payPlanIndex + "\",\"" + payPlan.NumOfPayments + "\"");
        sw.WriteLine("\"RTRPaymentAmount\",\"" + TT2Tag.GetScopeString(ItemScope.PayPlan) + payPlanIndex + "\",\"" + payPlan.PaymentAmount + "\"");
        sw.WriteLine("\"RTRTotalServiceFee\",\"" + TT2Tag.GetScopeString(ItemScope.PayPlan) + payPlanIndex + "\",\"" + payPlan.TotalServiceFee + "\"");
        payPlanIndex++;
      }
      sw.Flush();
      return sw.ToString();
    }

    /// <summary>
    /// Finds a list of all the TT2Tag objects matching the criteria
    /// passed in the parameters
    /// </summary>
    /// <param name="tagName">Name of the tags to find</param>
    /// <param name="tagScope">Scope of the tags to find</param>
    /// <param name="scopeNum">Scope number of the tags to find</param>
    /// <returns>List of TT2Tag objects</returns>
    public virtual TT2TagList FindMatchingTags(string tagName, ItemScope tagScope, int scopeNum)
    {
      TT2TagList tempResult = new TT2TagList();
      bool foundAny = false;
      foreach (TT2Tag tag in Tags)
      {
        bool nameMatches = tag.TagName.Equals(tagName, StringComparison.OrdinalIgnoreCase);
        if (nameMatches && (tag.TagScope == tagScope) && (tag.ScopeNum == scopeNum))
        {
          tempResult.Add(tag);
          foundAny = true;
        }
        else if (!nameMatches && foundAny && Tags.Sorted)
          break;
      }
      tempResult.Sorted = Tags.Sorted;
      return tempResult;
    }

    /// <summary>
    /// Finds a list of all the TT2Tag objects matching the criteria
    /// passed in the parameters
    /// </summary>
    /// <param name="tagName">Name of the tags to find</param>
    public virtual TT2TagList FindMatchingTagsByName(string tagName)
    {
      TT2TagList tempResult = new TT2TagList();
      bool foundAny = false;
      foreach (TT2Tag tag in Tags)
      {
        if (tag.TagName.Equals(tagName, StringComparison.OrdinalIgnoreCase))
        {
          tempResult.Add(tag);
          foundAny = true;
        }
        else if (foundAny && Tags.Sorted)
          break;
      }
      tempResult.Sorted = Tags.Sorted;
      return tempResult;
    }

    /// <summary>
    /// Finds a list of all the TT2Tag objects matching the criteria
    /// passed in the parameters
    /// </summary>
    /// <param name="tagScope">Scope of the tags to find</param>
    /// <param name="scopeNum">Scope number of the tags to find</param>
    /// <returns>List of TT2Tag objects</returns>
    public virtual TT2TagList FindMatchingTagsByScope(ItemScope tagScope, int scopeNum)
    {
      TT2TagList tempResult = new TT2TagList();
      foreach (TT2Tag tag in Tags)
        if ((tag.TagScope == tagScope) &&
          ((tag.ScopeNum == scopeNum) || (scopeNum == -1)))
          tempResult.Add(tag);
      tempResult.Sorted = Tags.Sorted;
      return tempResult;
    }

    /// <summary>
    /// Determines if there are any tags of the same scope and scopeNum within the tags list.
    /// </summary>
    /// <param name="tagScope">The tag scope we're looking for.</param>
    /// <param name="scopeNum">The scope num we're looking for.</param>
    /// <returns>True if any tags exist in the file that match the criteria, otherwise false.</returns>
    public virtual bool HasMatchingTagsByScope(ItemScope tagScope, int scopeNum)
    {
      foreach (TT2Tag tag in Tags)
        if ((tag.TagScope == tagScope) &&
          ((tag.ScopeNum == scopeNum) || (scopeNum == -1)))
          return true;
      return false;
    }

    /// <summary>
    /// Finds a list of all the TT2Tag objects matching the criteria
    /// passed in the parameters
    /// </summary>
    /// <param name="primaryScope">Primary Scope of the tags to find</param>
    /// <param name="primaryScopeNum">Primary Scope number of the tags to find</param>
    /// <param name="secondaryScope">Secondary Scope of the tags to find</param>
    /// <param name="secondaryScopeNum">Secondary Scope number of the tags to find</param>
    /// <returns>List of TT2Tag objects</returns>
    public virtual TT2TagList FindMatchingTagsByPrimaryAndSecondaryScope(ItemScope primaryScope, int primaryScopeNum, ItemScope secondaryScope, int secondaryScopeNum)
    {
      TT2TagList tempResult = new TT2TagList();
      foreach (TT2Tag tag in Tags)
        if ((tag.TagScope == primaryScope) && ((tag.ScopeNum == primaryScopeNum) || (primaryScopeNum == -1)) &&
            (tag.SecondaryScope == secondaryScope) && ((tag.SecondaryScopeNum == secondaryScopeNum) || (secondaryScopeNum == -1)))
          tempResult.Add(tag);
      tempResult.Sorted = Tags.Sorted;
      return tempResult;
    }

    /// <summary>
    /// Loads a TT2 string. The TT2 string is parsed and TT2Tag objects
    /// are created to represent the TT2 string data
    /// </summary>
    /// <param name="tt2">the tt2 info to load</param>
    public void LoadTT2String(string tt2)
    {
      Tags.Clear();
      StringReader sr = new StringReader(tt2);
      string line;
      while ((line = sr.ReadLine()) != null)
      {
        if ((!String.IsNullOrEmpty(line)) && (line.Trim().Length > 0))
          Tags.Add(new TT2Tag(line.Trim()));
      }
    }

    /// <summary>
    /// Loads a TT2 string. The TT2 lines are parsed and TT2Tag objects
    /// are created to represent the TT2 string data
    /// </summary>
    /// <param name="tt2">the tt2 info to load</param>
    public void LoadTT2Lines(List<string> tt2)
    {
      if (tt2 == null)
        return;
      Tags.Clear();
      foreach (string line in tt2)
      {
        if ((!String.IsNullOrEmpty(line)) && (line.Trim().Length > 0))
          Tags.Add(new TT2Tag(line.Trim()));
      }
    }

    /// <summary>
    /// A generic method for setting an object's property's value from
    /// the value of a tt2 tag. Uses reflection to set the value.
    /// </summary>
    /// <param name="target">The object who's property you
    /// wish to set</param>
    /// <param name="pinfo">The property info object that represents
    /// the property who's value you wish to set</param>
    /// <param name="tag">The tt2 tag with which we
    /// will set the object's property's value. Note that we use the
    /// first item in the Values list as the value.</param>
    protected virtual void SetObjectPropertyValueFromTag(Object target,
      PropertyDescriptor pinfo, TT2Tag tag)
    {
      if (tag.Values.Count == 0)
        throw new ApplicationException(String.Format("Tag '{0}' has no values. Property: '{1}'.", tag.TagLine, pinfo.Name));
      object tagValue = tag.Values[0];
      int defIntValue = 0;

      if (tagValue.ToString() == "windowsrecordid")
      {
        defIntValue = -1;
      }

      try
      {
        if (pinfo.PropertyType == typeof(string))
          pinfo.SetValue(target, tagValue.ToString());
        else if (pinfo.PropertyType == typeof(int))
          pinfo.SetValue(target, Convert.ToInt32(tagValue.ToString()));
        else if (pinfo.PropertyType == typeof(Int64))
          pinfo.SetValue(target, Convert.ToInt64(tagValue.ToString()));
        else if (pinfo.PropertyType == typeof(bool) || pinfo.PropertyType == typeof(bool?))
        {
          if (!String.IsNullOrEmpty(tagValue.ToString()))
            pinfo.SetValue(target, Convert.ToBoolean(tagValue.ToString().ToUpper() == "Y"));
        }
        else if (pinfo.PropertyType == typeof(double))
        {
          if (tagValue.ToString() == IncludedPremiumString)
            pinfo.SetValue(target, InsConstants.IncludedPremium);
          else
            pinfo.SetValue(target, Convert.ToDouble(tagValue.ToString()));
        }
        else if (pinfo.PropertyType == typeof(float))
          pinfo.SetValue(target, ITCConvert.ToFloat(tagValue, 0));
        else if (pinfo.PropertyType == typeof(DateTime))
          pinfo.SetValue(target, Convert.ToDateTime(tagValue.ToString()));
        else if (pinfo.PropertyType == typeof(USState))
          pinfo.SetValue(target, (USState)IndexLib.GetStringIndex(tagValue.ToString(), ITCConstants.StateAbbreviations, 0));
        else if (pinfo.PropertyType == typeof(Guid))
          pinfo.SetValue(target, new Guid(tagValue.ToString()));
        else if (pinfo.PropertyType == typeof(Guid?))
          pinfo.SetValue(target, ITCConvert.ToNullableGuid(tagValue, null));
        else //any other enumerated type variable
        {
          PropertyStorageAttribute pattr = (pinfo.Attributes[typeof(PropertyStorageAttribute)] as PropertyStorageAttribute);
          if (pattr != null)
          {
            if (pattr.EnumerationType != null)
            {
              //if it's an insuranceline enum property and the value passed in is an integer, convert the 
              if ((pinfo.PropertyType == typeof(InsuranceLine)) && (ITCConvert.ToInt32(tagValue, -1) != -1))
                tagValue = InsConstants.ConvertFromDelphiInsuranceLine(tagValue);

              //if the class defined an array of string values for the enumeration, use those
              if ((!String.IsNullOrEmpty(pattr.EnumerationValues)) && (pattr.EnumerationConstHolderType != null))
              {
                Type constType = pattr.EnumerationConstHolderType;
                FieldInfo subFieldInfo = constType.GetField(pattr.EnumerationValues);
                object[] staticArrayValues = (object[])subFieldInfo.GetValue(null);
                pinfo.SetValue(target,
                  Enum.Parse(pattr.EnumerationType, IndexLib.GetStringIndex(
                    tagValue.ToString(), (string[])staticArrayValues, 0).ToString()));
              }
              else //if the enum property doesn't have a "names/values" const array defined, then just attempt to parse the tag into the proper enum type (thanks try/catch :))
              {
                pinfo.SetValue(target,
                  Enum.Parse(pattr.EnumerationType, tagValue.ToString(), true));
              }
            }
          }
        }
      }
      catch  //if the value we're setting is of the wrong type, use a default value for the property
      {
        if (pinfo.PropertyType == typeof(string))
          pinfo.SetValue(target, "");
        else if (pinfo.PropertyType == typeof(int))
          pinfo.SetValue(target, defIntValue);
        else if (pinfo.PropertyType == typeof(bool))
          pinfo.SetValue(target, false);
        else if (pinfo.PropertyType == typeof(double))
          pinfo.SetValue(target, 0.0);
        else if (pinfo.PropertyType == typeof(DateTime))
          pinfo.SetValue(target, ITCConstants.InvalidDate);
        else if (pinfo.PropertyType == typeof(USState))
          pinfo.SetValue(target, ProductState);
        else if (pinfo.PropertyType == typeof(Guid))
          pinfo.SetValue(target, Guid.Empty);
      }
    }

    /// <summary>
    /// Imports notes from TT2 data into the policy
    /// </summary>
    public virtual void ImportTT2NotesPolicy()
    {
      TT2TagList noteTags;
      for (int TagIdx = 0; TagIdx < Policy.Quote.NumOfNotes; TagIdx++)
      {
        Type t = Policy.Quote.Notes[TagIdx].GetType();
        PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);

        //Get tags of Note scope (just the webrecordid)
        noteTags = FindMatchingTagsByScope(ItemScope.Notes, TagIdx + 1);
        foreach (PropertyDescriptor pdescriptor in pdescriptors)
        {
          TT2Tag ThisTag;
          if (pdescriptor.Name.ToUpper() == "RECORDID") //make sure we get the web's recordid, otherwise everything becomes a new record!!
            ThisTag = noteTags["WEBRECORDID"];
          else
            ThisTag = noteTags[pdescriptor.Name]; //default; pick up the tag w/same name as property

          if ((ThisTag != null) && (!pdescriptor.IsReadOnly))
          {
            for (int valueIndex = 0; valueIndex < ThisTag.Values.Count; valueIndex++)
              ThisTag.Values[valueIndex] = StringLib.ReplaceEx(ThisTag.Values[valueIndex].ToString(), "#13#10", "<br />");

            SetObjectPropertyValueFromTag(Policy.Quote.Notes[TagIdx], pdescriptor, ThisTag);
          }
        }
        noteTags.Clear();

        //Get tags of policy scope (all other note tags)
        noteTags = FindMatchingTagsByScope(ItemScope.Policy, TagIdx + 1);
        foreach (PropertyDescriptor pdescriptor in pdescriptors)
        {
          TT2Tag ThisTag;
          if ((pdescriptor.Name.ToUpper() == "RECORDID") ||
              (pdescriptor.Name.ToUpper() == "WEBAPPSTORAGE")) //don't import webrecordid at the policy level!
            ThisTag = null;
          else
            ThisTag = noteTags[pdescriptor.Name]; //default; pick up the tag w/same name as property

          if ((ThisTag != null) && (!pdescriptor.IsReadOnly))
          {
            for (int valueIndex = 0; valueIndex < ThisTag.Values.Count; valueIndex++)
              ThisTag.Values[valueIndex] = StringLib.ReplaceEx(ThisTag.Values[valueIndex].ToString(), "#13#10", "<br />");

            SetObjectPropertyValueFromTag(Policy.Quote.Notes[TagIdx], pdescriptor, ThisTag);
          }
        }
        noteTags.Clear();
        if (!Policy.Quote.Notes[TagIdx].OverrideTableName.ToUpper().Contains("NOTE"))
          Policy.Quote.Notes[TagIdx].OverrideTableName = "";
      }
    }

    /// <summary>
    /// Imports misc premiums from TT2 data into the policy
    /// </summary>
    public virtual void ImportTT2MiscPremiumsPolicy()
    {
      TT2TagList miscPremTags;
      for (int TagIdx = 0; TagIdx < Policy.NumOfMiscPremiums; TagIdx++)
      {
        Type t = Policy.MiscPremiums[TagIdx].GetType();
        PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
        miscPremTags = FindMatchingTagsByScope(ItemScope.MisPremium, TagIdx + 1);
        foreach (PropertyDescriptor pdescriptor in pdescriptors)
        {
          TT2Tag ThisTag;
          if (pdescriptor.Name.ToUpper() == "RECORDID") //make sure we get the web's recordid, otherwise everything becomes a new record!!
            ThisTag = miscPremTags["WEBRECORDID"];
          else
            ThisTag = miscPremTags[pdescriptor.Name]; //default; pick up the tag w/same name as property

          if ((ThisTag != null) && (!pdescriptor.IsReadOnly))
          {
            if ((pdescriptor.PropertyType == typeof(double)) && (ThisTag.Values[0].ToString() == IncludedPremiumString))
              pdescriptor.SetValue(Policy.MiscPremiums[TagIdx], InsConstants.IncludedPremium);
            else
              SetObjectPropertyValueFromTag(Policy.MiscPremiums[TagIdx],
                pdescriptor, ThisTag);
          }
        }
        miscPremTags.Clear();
      }
    }

    /// <summary>
    /// Sets the data of the Policy.Insured from TT2 data
    /// </summary>
    public virtual void ImportTT2PolicyInsuredToPolicyInsured()
    {
      Type t = Policy.Insured.GetType();
      PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
      TT2TagList PolicyTags = FindMatchingTagsByScope(ItemScope.Policy, 0);
      foreach (PropertyDescriptor pdescriptor in pdescriptors)
      {
        TT2Tag ThisTag;
        if (pdescriptor.Name.ToUpper() == "WEBAPPSTORAGE")
          ThisTag = null;
        else if (pdescriptor.Name.ToUpper() == "PHONE")
          ThisTag = PolicyTags["HOMEPHONE"];
        else if (pdescriptor.Name.ToUpper() == "EMPLOYERADDRESS1")
          ThisTag = PolicyTags["EMPLOYERADDR1"];
        else if (pdescriptor.Name.ToUpper() == "EMPLOYERADDRESS2")
          ThisTag = PolicyTags["EMPLOYERADDR2"];
        else if (pdescriptor.Name.ToUpper() == "PRIORADDRESS1")
          ThisTag = PolicyTags["PRIORADDR1"];
        else if (pdescriptor.Name.ToUpper() == "PRIORADDRESS2")
          ThisTag = PolicyTags["PRIORADDR2"];
        else
          ThisTag = PolicyTags[pdescriptor.Name]; //default; pick up the tag w/same name as property

        if ((ThisTag != null) && (!pdescriptor.IsReadOnly))
          SetObjectPropertyValueFromTag(Policy.Insured,
            pdescriptor, ThisTag);
      }
      PolicyTags.Clear();

      TT2TagList InsuredTags = FindMatchingTagsByScope(ItemScope.Insured, 0);
      foreach (PropertyDescriptor pdescriptor in pdescriptors)
      {
        TT2Tag ThisTag;
        if (pdescriptor.Name.ToUpper() == "RECORDID") //make sure we get the web's recordid, otherwise everything becomes a new record!!
          ThisTag = InsuredTags["WEBRECORDID"];
        else if (pdescriptor.Name.ToUpper() == "WEBAPPSTORAGE")
          ThisTag = null;
        else if (pdescriptor.Name.ToUpper() == "PHONE")
          ThisTag = InsuredTags["HOMEPHONE"];
        else if (pdescriptor.Name.ToUpper() == "EMPLOYERADDRESS1")
          ThisTag = InsuredTags["EMPLOYERADDR1"];
        else if (pdescriptor.Name.ToUpper() == "EMPLOYERADDRESS2")
          ThisTag = InsuredTags["EMPLOYERADDR2"];
        else if (pdescriptor.Name.ToUpper() == "PRIORADDRESS1")
          ThisTag = InsuredTags["PRIORADDR1"];
        else if (pdescriptor.Name.ToUpper() == "PRIORADDRESS2")
          ThisTag = InsuredTags["PRIORADDR2"];
        else
          ThisTag = InsuredTags[pdescriptor.Name]; //default; pick up the tag w/same name as property

        if ((ThisTag != null) && (!pdescriptor.IsReadOnly))
          SetObjectPropertyValueFromTag(Policy.Insured,
            pdescriptor, ThisTag);
      }
      InsuredTags.Clear();
    }

    /// <summary>
    /// Imports Policy Address information from TT2 data
    /// 
    /// </summary>
    public virtual void ImportTT2PolicyAddressToPolicyAddress()
    {
      Type t = Policy.MailingAddress.GetType();
      PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
      TT2TagList PolicyTags = FindMatchingTagsByScope(ItemScope.Policy, 0);
      foreach (PropertyDescriptor pdescriptor in pdescriptors)
      {
        TT2Tag ThisTag;
        if (pdescriptor.Name.ToUpper() == "RECORDID") //make sure we get the web's recordid, otherwise everything becomes a new record!!
          ThisTag = null;
        else
          ThisTag = PolicyTags[pdescriptor.Name]; //default; pick up the tag w/same name as property
        if ((ThisTag != null) && (!pdescriptor.IsReadOnly))
          SetObjectPropertyValueFromTag(Policy.MailingAddress,
            pdescriptor, ThisTag);
      }
      PolicyTags.Clear();

      TT2TagList AddressTags = FindMatchingTagsByScope(ItemScope.Address, 0);
      foreach (PropertyDescriptor pdescriptor in pdescriptors)
      {
        TT2Tag ThisTag;
        if (pdescriptor.Name.ToUpper() == "RECORDID") //make sure we get the web's recordid, otherwise everything becomes a new record!!
        {
          ThisTag = AddressTags["ADDRESSWEBRECORDID"];
          if (ThisTag == null)
            ThisTag = AddressTags["WEBRECORDID"];
        }
        else
          ThisTag = AddressTags[pdescriptor.Name]; //default; pick up the tag w/same name as property
        if ((ThisTag != null) && (!pdescriptor.IsReadOnly))
          SetObjectPropertyValueFromTag(Policy.MailingAddress,
            pdescriptor, ThisTag);
      }
      if (!Policy.MailingAddress.OverrideTableName.ToUpper().Contains("RESIDENCE"))
        Policy.MailingAddress.OverrideTableName = "";
      AddressTags.Clear();
    }

    /// <summary>
    /// Imports Policy Quote information from TT2 data
    /// </summary>
    public virtual void ImportTT2PolicyQuoteToPolicyQuote()
    {
      Type t = Policy.Quote.GetType();
      PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
      TT2TagList PolicyTags = FindMatchingTagsByScope(ItemScope.Policy, 0);
      foreach (PropertyDescriptor pdescriptor in pdescriptors)
      {
        TT2Tag ThisTag;
        if (pdescriptor.Name.ToUpper() == "WEBAPPSTORAGE")
          ThisTag = null;
        else if (pdescriptor.Name.ToUpper() == "COMPANYEFFECTIVEDATE")     // have to check and assign this separately because tt2 tag different from property name
          ThisTag = PolicyTags["COMPANYEFFDATE"];
        else if (pdescriptor.Name.ToUpper() == "EXPIRATIONDATE")     // have to check and assign this separately because tt2 tag different from property name
          ThisTag = PolicyTags["EXPDATE"];
        else if (pdescriptor.Name.ToUpper() == "EXPIRATIONTIME")     // have to check and assign this separately because tt2 tag different from property name
          ThisTag = PolicyTags["EXPTIME"];
        else if (pdescriptor.Name.ToUpper() == "EFFECTIVETIME")     // have to check and assign this separately because tt2 tag different from property name
          ThisTag = PolicyTags["EFFTIME"];
        else if (pdescriptor.Name.ToUpper() == "FINANCECOMPANYADDRESS1")     // have to check and assign this separately because tt2 tag different from property name
          ThisTag = PolicyTags["FINANCECOMPANYADDR1"];
        else if (pdescriptor.Name.ToUpper() == "SECONDARYCOMPANYEFFECTIVEDATE")     // have to check and assign this separately because tt2 tag different from property name
          ThisTag = PolicyTags["SECONDARYCOMPANYEFFDATE"];
        else if (pdescriptor.Name.ToUpper() == "FINANCECOMPANYADDRESS2")     // have to check and assign this separately because tt2 tag different from property name
          ThisTag = PolicyTags["FINANCECOMPANYADDR2"];
        else
          ThisTag = PolicyTags[pdescriptor.Name]; //default; pick up the tag w/same name as property

        if ((ThisTag != null) && (!pdescriptor.IsReadOnly))
          SetObjectPropertyValueFromTag(Policy.Quote,
            pdescriptor, ThisTag);
      }
      PolicyTags.Clear();

      TT2TagList QuoteTags = FindMatchingTagsByScope(ItemScope.Quote, 0);
      foreach (PropertyDescriptor pdescriptor in pdescriptors)
      {
        TT2Tag ThisTag;
        if (pdescriptor.Name.ToUpper() == "RECORDID") //make sure we get the web's recordid, otherwise everything becomes a new record!!
          ThisTag = QuoteTags["WEBRECORDID"];
        else
          ThisTag = QuoteTags[pdescriptor.Name]; //default; pick up the tag w/same name as property

        if ((ThisTag != null) && (!pdescriptor.IsReadOnly))
          SetObjectPropertyValueFromTag(Policy.Quote,
            pdescriptor, ThisTag);
      }
      if (!Policy.Quote.OverrideTableName.ToUpper().Contains("QUOTE"))
        Policy.Quote.OverrideTableName = "";
      QuoteTags.Clear();
    }

    /// <summary>
    /// Returns the percentage of this discount/surcharge from the discount/
    /// surcharge tag that matches the windows code of the discountmessage/
    /// surchargemessage tag.
    /// </summary>
    /// <param name="tagName">"discount" or "surcharge".</param>
    /// <param name="windowsCode">Windows Code of discountmessage/surchargemessage.</param>
    /// <returns>Returns the percentage of the discount/surcharge.</returns>
    public virtual double GetPercentageFromTag(string tagName, int windowsCode)
    {
      double percentage = 0.00;
      TT2TagList PolicyTags = this.FindMatchingTagsByName(tagName);

      foreach (TT2Tag tag in PolicyTags)
      {
        if (tag.Values.Count > 1 && ITCConvert.ToInt32(tag.Values[1].ToString(), 0) == windowsCode)
        {
          percentage = ITCConvert.ToDouble(tag.Values[0].ToString(), 0.00);
          break;
        }
      }

      return percentage;
    }


    /// <summary>
    /// Imports policy information from the TT2 into the Policy object
    /// </summary>
    public virtual void ImportTT2PolicyToPolicy()
    {
      //Create MiscPremium objects in the MiscPremiums property
      int NumOfMiscPremiums = 0;
      TT2TagList PolicyTags = FindMatchingTags("NumOfMiscPremiums", ItemScope.Policy, 0);
      if (PolicyTags.Count > 0)
      {
        TT2Tag ThisTag = PolicyTags[0];
        NumOfMiscPremiums = Convert.ToInt32(ThisTag.Values[0].ToString());
      }
      PolicyTags.Clear();
      while (Policy.MiscPremiums.Count < NumOfMiscPremiums)
      {
        MiscPremium AddMiscPremium = new MiscPremium();
        Policy.MiscPremiums.Add(AddMiscPremium);
      }

      if (m_allowImportWarningsErrors)
      {
        //add warning messages from the import file
        PolicyTags = this.FindMatchingTagsByName("warningmessage");
        foreach (TT2Tag tag in PolicyTags)
        {
          Message msg = new Message();
          msg.ScopeType = tag.TagScope;
          msg.Scope = tag.ScopeNum;
          if (tag.Values.Count > 1)
          {
            msg.Text = tag.Values[1].ToString();
            Policy.Warnings.Add(msg);
          }
        }
        PolicyTags.Clear();

        //add error messages from the import file
        PolicyTags = this.FindMatchingTagsByName("errormessage");
        foreach (TT2Tag tag in PolicyTags)
        {
          Message msg = new Message();
          msg.ScopeType = tag.TagScope;
          msg.Scope = tag.ScopeNum;
          if (tag.Values.Count > 1)
          {
            msg.Text = tag.Values[1].ToString();
            Policy.Errors.Add(msg);
          }
        }
        PolicyTags.Clear();
      }

      //Create InsNote objects in the Notes property
      int NumOfNotes = 0;
      PolicyTags = FindMatchingTags("NumOfNotes", ItemScope.Policy, 0);
      if (PolicyTags.Count > 0)
      {
        TT2Tag ThisTag = PolicyTags[0];
        NumOfNotes = Convert.ToInt32(ThisTag.Values[0].ToString());
      }
      PolicyTags.Clear();
      while (Policy.Quote.Notes.Count < NumOfNotes)
      {
        InsNote AddNote = new InsNote();
        Policy.Quote.Notes.Add(AddNote);
      }

      // Now import the policy tags
      Type t = Policy.GetType();
      PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
      PolicyTags = FindMatchingTagsByScope(ItemScope.Policy, 0);
      foreach (PropertyDescriptor pdescriptor in pdescriptors)
      {
        TT2Tag ThisTag;
        if (pdescriptor.Name.ToUpper() == "RECORDID") //make sure we get the web's recordid, otherwise everything becomes a new record!!
          ThisTag = PolicyTags["WEBRECORDID"];
        else if (pdescriptor.Name.ToUpper() == "EFFECTIVEDATE")     // have to check and assign this separately because tt2 tag different from property name
          ThisTag = PolicyTags["EFFDATE"];
        else if (pdescriptor.Name.ToUpper() == "TOTALPREMIUM")     // have to check and assign this separately because tt2 tag different from property name
          ThisTag = PolicyTags["TOTALPOLICYPREMIUM"];
        else
          ThisTag = PolicyTags[pdescriptor.Name]; //default; pick up the tag w/same name as property

        if ((ThisTag != null) && (!pdescriptor.IsReadOnly))
          SetObjectPropertyValueFromTag(Policy, pdescriptor, ThisTag);
      }
      if (!Policy.OverrideTableName.ToUpper().Contains("POLICY"))
        Policy.OverrideTableName = "";

      PolicyTags.Clear();
      ImportTT2PolicyInsuredToPolicyInsured();
      ImportTT2PolicyAddressToPolicyAddress();
      ImportTT2PolicyQuoteToPolicyQuote();

      //Create CarrierReasonNotBound objects
      var NumOfCarrierReasonNotBound = 0;
      var ThisTagList = FindMatchingTags("NumOfCarrierReasonNotBound", ItemScope.Policy, 0);
      if ((ThisTagList != null) && (ThisTagList.Count > 0))
        NumOfCarrierReasonNotBound = Convert.ToInt32(ThisTagList[0].Values[0].ToString());
      while (Policy.Quote.CarrierReasonNotBoundList.Count < NumOfCarrierReasonNotBound)
        Policy.Quote.CarrierReasonNotBoundList.Add(new CarrierReasonNotBound());

      ImportTT2CarrierReasonNotBoundPolicy();

      if (m_allowImportDiscountsSurcharges)
      {
        PolicyTags.Clear();
        //add discount messages from the import file
        PolicyTags = this.FindMatchingTagsByName("discountmessage");

        foreach (TT2Tag tag in PolicyTags)
        {
          Message msg = new Message();
          msg.ScopeType = tag.TagScope;
          msg.Scope = tag.ScopeNum;

          if (tag.Values.Count > 0)
          {
            msg.WindowsCode = ITCConvert.ToInt32(tag.Values[0].ToString(), 0);
            msg.Percentage = GetPercentageFromTag("discount", msg.WindowsCode);
          }

          if (tag.Values.Count > 1)
          {
            msg.Text = tag.Values[1].ToString();

            if (Policy.HasSecondaryData)
            {
              if (msg.Text.ToLower().Contains(Policy.Quote.SecondaryCompanyName.ToLower()))
              {
                msg.Text = msg.Text.Replace(Policy.Quote.SecondaryCompanyName + ": ", "");
                Policy.SecondaryDiscountMessages.Add(msg);
              }
              else
              {
                msg.Text = msg.Text.Replace(Policy.Quote.CompanyName + ": ", "");
                Policy.DiscountMessages.Add(msg);
              }
            }
            else
              Policy.DiscountMessages.Add(msg);
          }
        }
        PolicyTags.Clear();

        //add surcharge messages from the import file
        PolicyTags = this.FindMatchingTagsByName("surchargemessage");

        foreach (TT2Tag tag in PolicyTags)
        {
          Message msg = new Message();
          msg.ScopeType = tag.TagScope;
          msg.Scope = tag.ScopeNum;

          if (tag.Values.Count > 0)
          {
            msg.WindowsCode = ITCConvert.ToInt32(tag.Values[0].ToString(), 0);
            msg.Percentage = GetPercentageFromTag("surcharge", msg.WindowsCode);
          }

          if (tag.Values.Count > 1)
          {
            msg.Text = tag.Values[1].ToString();

            if (Policy.HasSecondaryData)
            {
              if (msg.Text.ToLower().Contains(Policy.Quote.SecondaryCompanyName.ToLower()))
              {
                msg.Text = msg.Text.Replace(Policy.Quote.SecondaryCompanyName + ": ", "");
                Policy.SecondarySurchargeMessages.Add(msg);
              }
              else
              {
                msg.Text = msg.Text.Replace(Policy.Quote.CompanyName + ": ", "");
                Policy.SurchargeMessages.Add(msg);
              }
            }
            else
              Policy.SurchargeMessages.Add(msg);
          }
        }
        PolicyTags.Clear();
        PolicyTags = this.FindMatchingTagsByName("carriermessage");

        foreach (TT2Tag tag in PolicyTags)
        {
          CarrierMessage msg = new CarrierMessage();
          msg.ScopeType = tag.TagScope;
          msg.Scope = tag.ScopeNum;

          if (tag.Values.Count > 1)
          {
            msg.Text = tag.Values[0].ToString();
            msg.LaunchUri = tag.Values[1].ToString();
            msg.LaunchUriDescription = tag.Values[2].ToString();
            Policy.Quote.CarrierMessages.Add(msg);
          }
        }
        PolicyTags.Clear();
      }

      ImportTT2MiscPremiumsPolicy();
      ImportTT2NotesPolicy();
    }


    /// <summary>
    /// Creates a tt2 tag line from a property info object.  This overload calls the original method and passes the 
    /// tagName based on information already kept in pinfo.Name.
    /// </summary>
    /// <param name="source">The object who's property we're going to spit out as tt2</param>
    /// <param name="pinfo">the property info of the property we're going to spit out as tt2</param>
    /// <param name="sw">StringWriter output</param>
    /// <param name="scope">Scope of the tag...pol0, drv3, etc.</param>
    protected void CreateTagLineFromProperty(Object source, PropertyDescriptor pinfo, ref StringWriter sw, string scope)
    {
      CreateTagLineFromProperty(source, pinfo, ref sw, scope, pinfo.Name);
    }

    /// <summary>
    /// Returns a boolean value indicating whether the tag name passed to the method is a time tag or not.
    /// </summary>
    /// <param name="tagName">Name of the tag you want to check.</param>
    /// <returns>Returns true if tag is a time tag.  Returns false if tag is not a time tag.</returns>
    protected static bool IsTimeTag(string tagName)
    {
      return (tagName.EndsWith("time", StringComparison.OrdinalIgnoreCase) && !tagName.EndsWith("datetime", StringComparison.OrdinalIgnoreCase) &&
              !tagName.Equals("residetime", StringComparison.OrdinalIgnoreCase) && !tagName.Equals("employedtime", StringComparison.OrdinalIgnoreCase));
    }


    /// <summary>
    /// Creates a tt2 tag line from a property info object.
    /// </summary>
    /// <param name="source">The object who's property we're going to spit out as tt2</param>
    /// <param name="pinfo">the property info of the property we're going to spit out as tt2</param>
    /// <param name="sw">StringWriter output</param>
    /// <param name="scope">Scope of the tag...pol0, drv3, etc.</param>
    /// <param name="tagName">Optional: name of the tag if not the same as pinfo.Name property...effdate, binderdate, etc.</param>
    protected void CreateTagLineFromProperty(Object source, PropertyDescriptor pinfo, ref StringWriter sw, string scope, string tagName)
    {
      tagName = tagName.ToLower();

      if (pinfo.PropertyType == typeof(DateTime))
      {
        // We need to check and see if we should be bridging Windows InvalidDate or WebInvalidDate.
        DateTime propertyDate = (DateTime)pinfo.GetValue(source);
        if (!ITCConstants.IsValidDate(propertyDate) && (!UseWebInvalidDate))
          propertyDate = ITCConstants.InvalidWindowsDate;
        if (IsTimeTag(tagName))
          sw.WriteLine("\"" + tagName + "\",\"" + scope + "\",\"" + TT2FormatTime(pinfo.GetValue(source)) + "\"");
        else
          sw.WriteLine("\"" + tagName + "\",\"" + scope + "\",\"" + TT2FormatDate(propertyDate) + "\"");
      }
      else if (pinfo.PropertyType == typeof(bool) || pinfo.PropertyType == typeof(bool?))
      {
        if (pinfo.PropertyType == typeof(bool?) && pinfo.GetValue(source) == null)
        {
          sw.WriteLine("\"" + tagName + "\",\"" + scope + "\",\"\"");
        }
        else if (Convert.ToBoolean(pinfo.GetValue(source)))
          sw.WriteLine("\"" + tagName + "\",\"" + scope + "\",\"Y\"");
        else
          sw.WriteLine("\"" + tagName + "\",\"" + scope + "\",\"N\"");
      }
      else if (pinfo.PropertyType == typeof(USState))
        sw.WriteLine("\"" + tagName + "\",\"" + scope + "\",\"" + ITCConstants.StateAbbreviations[(int)(USState)pinfo.GetValue(source)] + "\"");
      else if (pinfo.PropertyType == typeof(double))
      {
        if (tagName.ToLower().Contains("premium"))
        {
          if (ExportIncludedPremiumString)
          {
            if ((double)pinfo.GetValue(source) == InsConstants.IncludedPremium)
            {
              sw.WriteLine("\"" + tagName + "\",\"" + scope + "\",\"" + IncludedPremiumString + "\"");
            }
            else
            {
              sw.WriteLine("\"" + tagName + "\",\"" + scope + "\",\"" + pinfo.GetValue(source).ToString() + "\"");
            }
          }
          else
          {
            sw.WriteLine("\"" + tagName + "\",\"" + scope + "\",\"" + pinfo.GetValue(source).ToString() + "\"");
          }
        }
        else
        {
          sw.WriteLine("\"" + tagName + "\",\"" + scope + "\",\"" + pinfo.GetValue(source).ToString() + "\"");
        }
      }
      else if ((UseWindowsBlankLimitValue) && (pinfo.PropertyType == typeof(Int32)) && ((int)pinfo.GetValue(source) == InsConstants.BlankLimitVal))
        sw.WriteLine("\"" + tagName + "\",\"" + scope + "\",\"0\"");
      else
      {
        bool hasNameValuePair = false;
        PropertyStorageAttribute pattr = (pinfo.Attributes[typeof(PropertyStorageAttribute)] as PropertyStorageAttribute);
        if (pattr != null)
        {
          if (pattr.EnumerationType != null)
          {
            //if the class defined an array of string values for an enumeration, use those (if we haven't already spit out a line)
            if ((!String.IsNullOrEmpty(pattr.EnumerationValues)) && (pattr.EnumerationConstHolderType != null) && (!hasNameValuePair))
            {
              hasNameValuePair = true;
              Type constType = pattr.EnumerationConstHolderType;
              FieldInfo subFieldInfo = constType.GetField(pattr.EnumerationValues);
              object[] staticArrayValues = (object[])subFieldInfo.GetValue(null);
              sw.WriteLine("\"" + tagName + "\",\"" + scope + "\",\"" + staticArrayValues[(int)pinfo.GetValue(source)] + "\"");
            }
          }
        }
        if (!hasNameValuePair) //if the property doesn't have a "names/values" const array defined, then just spit out a "ToString()" of the tag value
        {
          object value = pinfo.GetValue(source);
          if (StripZipCodeEditMask && tagName.ToLower().Contains("zipcode"))
            sw.WriteLine("\"" + tagName + "\",\"" + scope + "\",\"" + TT2FormatZipCode(pinfo.GetValue(source).ToString()) + "\"");
          else
            sw.WriteLine("\"" + tagName + "\",\"" + scope + "\",\"" + (value == null ? String.Empty : value.ToString()) + "\"");
        }
      }
    }

    /// <summary>
    /// Names of properties for storing addresses in the Insured object.
    /// </summary>
    private static readonly string[] InsuredAddressProperties = 
		{
      "address1",
      "address2",
      "city",
      "county",
      "state",
      "zipcode"
		};

    /// <summary>
    /// Pre-cast List of InsuredAddressProperties string array for use by methods.
    /// </summary>
    public static readonly IList<string> InsuredAddressPropertiesList = new List<string>(InsuredAddressProperties);


    /// <summary>
    /// Exports the Policy.Insured to TT2 data
    /// </summary>
    /// <param name="sw">Contains the TT2 output</param>
    public virtual void ExportPolicyInsuredToTT2PolicyInsured(ref StringWriter sw)
    {
      Type tempType;

      if (TreatInsuredAsDriver)
        tempType = Policy.Insured.GetType();
      else
        tempType = typeof(Person);

      PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(tempType);

      foreach (PropertyDescriptor pdescriptor in pdescriptors)
      {
        if (!IsTagExcludedFromExport(pdescriptor.Name))
        {
          if (pdescriptor.Name.ToUpper() == "RECORDID")
            CreateTagLineFromProperty(Policy.Insured, pdescriptor, ref sw, "ins0", "WebRecordID");
          else if (pdescriptor.Name.ToUpper() == "EMPLOYERADDRESS1")
          {
            CreateTagLineFromProperty(Policy.Insured, pdescriptor, ref sw, "pol0", "EmployerAddr1");
            if (m_exportInsuredWithInsScope)
              CreateTagLineFromProperty(Policy.Insured, pdescriptor, ref sw, "ins0", "EmployerAddr1");
          }
          else if (pdescriptor.Name.ToUpper() == "EMPLOYERADDRESS2")
          {
            CreateTagLineFromProperty(Policy.Insured, pdescriptor, ref sw, "pol0", "EmployerAddr2");
            if (m_exportInsuredWithInsScope)
              CreateTagLineFromProperty(Policy.Insured, pdescriptor, ref sw, "ins0", "EmployerAddr2");
          }
          else if (pdescriptor.Name.ToUpper() == "PRIORADDRESS1")
          {
            CreateTagLineFromProperty(Policy.Insured, pdescriptor, ref sw, "pol0", "PriorAddr1");
            if (m_exportInsuredWithInsScope)
              CreateTagLineFromProperty(Policy.Insured, pdescriptor, ref sw, "ins0", "PriorAddr1");
          }
          else if (pdescriptor.Name.ToUpper() == "PRIORADDRESS2")
          {
            CreateTagLineFromProperty(Policy.Insured, pdescriptor, ref sw, "pol0", "PriorAddr2");
            if (m_exportInsuredWithInsScope)
              CreateTagLineFromProperty(Policy.Insured, pdescriptor, ref sw, "ins0", "PriorAddr2");
          }
          else if (pdescriptor.Name.ToUpper() == "PHONE")
          {
            CreateTagLineFromProperty(Policy.Insured, pdescriptor, ref sw, "pol0", "HomePhone");
            if (m_exportInsuredWithInsScope)
              CreateTagLineFromProperty(Policy.Insured, pdescriptor, ref sw, "ins0", "HomePhone");
          }
          else if (pdescriptor.Name.ToUpper() == "WEBAPPSTORAGE")
            CreateTagLineFromProperty(Policy.Insured, pdescriptor, ref sw, "ins0", "WebAppStorage");
          else if (pdescriptor.Name.ToUpper() == "BRIDGEDATASTORAGE")
            CreateTagLineFromProperty(Policy.Insured, pdescriptor, ref sw, "ins0");
          else if (InsuredAddressPropertiesList.Contains(pdescriptor.Name.ToLower()) && ExportMailingAddressOnly)
          {
            // In this case we still want to send the ins0 scope tag if that applies.
            if (m_exportInsuredWithInsScope)
              CreateTagLineFromProperty(Policy.Insured, pdescriptor, ref sw, "ins0");
          }
          else
          {
            CreateTagLineFromProperty(Policy.Insured, pdescriptor, ref sw, "pol0");
            if (m_exportInsuredWithInsScope)
              CreateTagLineFromProperty(Policy.Insured, pdescriptor, ref sw, "ins0");
          }
        }
      }
    }


    /// <summary>
    /// Exports the Policy.Quote to TT2 data
    /// </summary>
    /// <param name="sw">Contains the TT2 output</param>
    public virtual void ExportPolicyQuoteToTT2PolicyQuote(ref StringWriter sw)
    {
      Type t = Policy.Quote.GetType();
      PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
      foreach (PropertyDescriptor pdescriptor in pdescriptors)
      {
        if (!IsTagExcludedFromExport(pdescriptor.Name))
        {
          if (pdescriptor.Name.ToUpper() == "RECORDID")
            CreateTagLineFromProperty(Policy.Quote, pdescriptor, ref sw, "quo0", "WebRecordID");
          else if (pdescriptor.Name.ToUpper() == "EFFECTIVETIME")
            CreateTagLineFromProperty(Policy.Quote, pdescriptor, ref sw, "pol0", "efftime");
          else if (pdescriptor.Name.ToUpper() == "EXPIRATIONDATE")
            CreateTagLineFromProperty(Policy.Quote, pdescriptor, ref sw, "pol0", "expdate");
          else if (pdescriptor.Name.ToUpper() == "EXPIRATIONTIME")
            CreateTagLineFromProperty(Policy.Quote, pdescriptor, ref sw, "pol0", "exptime");
          else if (pdescriptor.Name.ToUpper() == "FINANCECOMPANYADDRESS1")
            CreateTagLineFromProperty(Policy.Quote, pdescriptor, ref sw, "pol0", "financecompanyaddr1");
          else if (pdescriptor.Name.ToUpper() == "FINANCECOMPANYADDRESS2")
            CreateTagLineFromProperty(Policy.Quote, pdescriptor, ref sw, "pol0", "financecompanyaddr2");
          else if (pdescriptor.PropertyType == typeof(DateTime) && pdescriptor.Name.ToUpper().EndsWith("TIME", StringComparison.OrdinalIgnoreCase))
            CreateTagLineFromProperty(Policy.Quote, pdescriptor, ref sw, "pol0");
          else if (pdescriptor.Name.ToUpper() == "COMPANYEFFECTIVEDATE")
            CreateTagLineFromProperty(Policy.Quote, pdescriptor, ref sw, "pol0", "companyeffdate");
          else if (pdescriptor.Name.ToUpper() == "SECONDARYCOMPANYEFFECTIVEDATE")
            CreateTagLineFromProperty(Policy.Quote, pdescriptor, ref sw, "pol0", "secondarycompanyeffdate");
          else if (pdescriptor.Name.ToUpper() == "WEBAPPSTORAGE")
            CreateTagLineFromProperty(Policy.Quote, pdescriptor, ref sw, "quo0", "WebAppStorage");
          else if (pdescriptor.Name.ToUpper() == "BRIDGEDATASTORAGE")
            CreateTagLineFromProperty(Policy.Quote, pdescriptor, ref sw, "quo0");
          else
            CreateTagLineFromProperty(Policy.Quote, pdescriptor, ref sw, "pol0");
        }
      }
    }

    /// <summary>
    /// Exports the misc premiums on the policy to TT2 data
    /// </summary>
    /// <param name="sw">Contains the TT2 output</param>
    public virtual void ExportPolicyMiscPremiumsToTT2(ref StringWriter sw)
    {
      for (int miscPremNum = 0; miscPremNum < Policy.NumOfMiscPremiums; miscPremNum++)
      {
        string ScopeString = (miscPremNum + 1).ToString();
        Type t = Policy.MiscPremiums[miscPremNum].GetType();
        PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
        foreach (PropertyDescriptor pdescriptor in pdescriptors)
        {
          if (!IsTagExcludedFromExport(pdescriptor.Name))
          {
            if (pdescriptor.Name.ToUpper() == "RECORDID")
              CreateTagLineFromProperty(Policy.MiscPremiums[miscPremNum], pdescriptor, ref sw, "mpr" + ScopeString, "WebRecordID");
            else
              CreateTagLineFromProperty(Policy.MiscPremiums[miscPremNum], pdescriptor, ref sw, "mpr" + ScopeString);
          }
        }
      }
    }

    /// <summary>
    /// Exports system information that can't be pulled from a policy.
    /// </summary>
    /// <param name="sw">Contains the TT2 output.</param>
    public virtual void ExportSystemTagsToTT2(ref StringWriter sw)
    {
      sw.WriteLine("\"integvers\",\"sys0\",\"2\",\"0\"");
      sw.WriteLine("\"integformat\",\"sys0\",\"TurboTags2\"");
    }

    /// <summary>
    /// Exports the notes on the policy to TT2 data
    /// </summary>
    /// <param name="sw">Contains the TT2 output</param>
    public virtual void ExportPolicyNotesToTT2(ref StringWriter sw)
    {
      for (int noteNum = 0; noteNum < Policy.Quote.NumOfNotes; noteNum++)
      {
        string ScopeString = (noteNum + 1).ToString();
        Type t = Policy.Quote.Notes[noteNum].GetType();
        PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
        foreach (PropertyDescriptor pdescriptor in pdescriptors)
        {
          if (!IsTagExcludedFromExport(pdescriptor.Name))
          {
            if (pdescriptor.Name.ToUpper() == "RECORDID")
              CreateTagLineFromProperty(Policy.Quote.Notes[noteNum], pdescriptor, ref sw, "not" + ScopeString, "WebRecordID");
            else if (pdescriptor.Name.ToUpper() == "WEBAPPSTORAGE")
              CreateTagLineFromProperty(Policy.Quote.Notes[noteNum], pdescriptor, ref sw, "not" + ScopeString, "WebAppStorage");
            else if (pdescriptor.Name.ToUpper() == "BRIDGEDATASTORAGE")
              CreateTagLineFromProperty(Policy.Quote.Notes[noteNum], pdescriptor, ref sw, "not" + ScopeString, "BridgeDataStorage");
            else
            {
              string originalNoteDescription = Policy.Quote.Notes[noteNum].Description;
              Policy.Quote.Notes[noteNum].Description = StringLib.ReplaceEx(Policy.Quote.Notes[noteNum].Description, "<br />", "#13#10");
              CreateTagLineFromProperty(Policy.Quote.Notes[noteNum], pdescriptor, ref sw, "pol" + ScopeString);
              Policy.Quote.Notes[noteNum].Description = originalNoteDescription;
            }
          }
        }
      }
    }

    public virtual void ExportPolicyCarrierMessagesToTT2(ref StringWriter sw)
    {
      int MsgIndex;
      for (MsgIndex = 0; MsgIndex < Policy.Quote.CarrierMessages.Count; MsgIndex++)
      {
        sw.WriteLine("\"carriermessage\",\"" + TT2Tag.GetScopeString(Policy.Quote.CarrierMessages[MsgIndex].ScopeType) + Policy.Quote.CarrierMessages[MsgIndex].Scope + "\",\"" + Policy.Quote.CarrierMessages[MsgIndex].Text + "\",\""
          + Policy.Quote.CarrierMessages[MsgIndex].LaunchUri + "\",\"" + Policy.Quote.CarrierMessages[MsgIndex].LaunchUriDescription + "\"");
      }
    }

    /// <summary>
    /// Exports the Policy address information to TT2 data
    /// </summary>
    /// <param name="sw">Contains the TT2 output</param>
    public virtual void ExportPolicyAddressToTT2Address(ref StringWriter sw)
    {
      Type t = Policy.MailingAddress.GetType();
      PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
      foreach (PropertyDescriptor pdescriptor in pdescriptors)
      {
        if (pdescriptor.Name.ToUpper() == "RECORDID")
        {
          CreateTagLineFromProperty(Policy.MailingAddress, pdescriptor, ref sw, "adr0", "WebRecordID");
          CreateTagLineFromProperty(Policy.MailingAddress, pdescriptor, ref sw, "adr0", "AddressWebRecordID");
        }
        else if (pdescriptor.Name.ToUpper() == "BRIDGEDATASTORAGE")
          CreateTagLineFromProperty(Policy.MailingAddress, pdescriptor, ref sw, "adr0");
        else if ((!IsTagExcludedFromExport(pdescriptor.Name)) && (pdescriptor.Name.ToUpper() != "WEBAPPSTORAGE"))
          CreateTagLineFromProperty(Policy.MailingAddress, pdescriptor, ref sw, "pol0");
      }
    }

    /// <summary>
    /// Exports the policy data to TT2 data
    /// </summary>
    /// <param name="sw">Contains the TT2 output</param>
    public virtual void ExportPolicyToTT2Policy(ref StringWriter sw)
    {
      Type t = Policy.GetType();
      PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
      foreach (PropertyDescriptor pdescriptor in pdescriptors)
      {
        if (pdescriptor.Name.ToUpper() == "INSURED")
          ExportPolicyInsuredToTT2PolicyInsured(ref sw);
        else if (pdescriptor.Name.ToUpper() == "QUOTE")
          ExportPolicyQuoteToTT2PolicyQuote(ref sw);
        else if (pdescriptor.Name.ToUpper() == "MISCPREMIUMS")
          ExportPolicyMiscPremiumsToTT2(ref sw);
        else if (pdescriptor.Name.ToUpper() == "MAILINGADDRESS")
          ExportPolicyAddressToTT2Address(ref sw);
        else if (pdescriptor.Name.ToUpper() == "TOTALPREMIUM")
          CreateTagLineFromProperty(Policy, pdescriptor, ref sw, "pol0", "TotalPolicyPremium");
        else if (pdescriptor.Name.ToUpper() == "EFFECTIVEDATE")
          CreateTagLineFromProperty(Policy, pdescriptor, ref sw, "pol0", "effdate");
        else if (pdescriptor.Name.ToUpper() == "RECORDID")
          CreateTagLineFromProperty(Policy, pdescriptor, ref sw, "pol0", "WebRecordID");
        else if (!IsTagExcludedFromExport(pdescriptor.Name))
        {
          CreateTagLineFromProperty(Policy, pdescriptor, ref sw, "pol0");
        }
      }
      ExportPolicyNotesToTT2(ref sw);
      ExportSystemTagsToTT2(ref sw);
      ExportPolicyCarrierMessagesToTT2(ref sw);
      ExportCarrierReasonNotBoundToTT2(ref sw);
    }

    /// <summary>
    /// Exports the CarrierReasonNotBound objects on the policy to TT2 data
    /// </summary>
    /// <param name="sw">Contains the TT2 output</param>
    public virtual void ExportCarrierReasonNotBoundToTT2(ref StringWriter sw)
    {
      for (var reasonNotBoundNum = 0; reasonNotBoundNum < Policy.Quote.CarrierReasonNotBoundList.Count; reasonNotBoundNum++)
      {
        var ScopeString = (reasonNotBoundNum + 1).ToString();
        var t = Policy.Quote.CarrierReasonNotBoundList[reasonNotBoundNum].GetType();
        var pdescriptors = TypeDescriptor.GetProperties(t);
        foreach (PropertyDescriptor pdescriptor in pdescriptors)
        {
          if (IsTagExcludedFromExport(pdescriptor.Name))
            continue;
          if (pdescriptor.Name.Equals("RECORDID", StringComparison.OrdinalIgnoreCase))
            CreateTagLineFromProperty(Policy.Quote.CarrierReasonNotBoundList[reasonNotBoundNum], pdescriptor, ref sw, EnumHelper.GetDescription(ItemScope.CarrierReasonNotBound) + ScopeString, "WebRecordID");
          else if (pdescriptor.Name.Equals("WEBAPPSTORAGE", StringComparison.OrdinalIgnoreCase))
            CreateTagLineFromProperty(Policy.Quote.CarrierReasonNotBoundList[reasonNotBoundNum], pdescriptor, ref sw, EnumHelper.GetDescription(ItemScope.CarrierReasonNotBound) + ScopeString, "WebAppStorage");
          else if (pdescriptor.Name.Equals("BRIDGEDATASTORAGE", StringComparison.OrdinalIgnoreCase))
            CreateTagLineFromProperty(Policy.Quote.CarrierReasonNotBoundList[reasonNotBoundNum], pdescriptor, ref sw, EnumHelper.GetDescription(ItemScope.CarrierReasonNotBound) + ScopeString, "BridgeDataStorage");
          else
            CreateTagLineFromProperty(Policy.Quote.CarrierReasonNotBoundList[reasonNotBoundNum], pdescriptor, ref sw, EnumHelper.GetDescription(ItemScope.CarrierReasonNotBound) + ScopeString);
        }
      }
    }

    /// <summary>
    /// Exports the tags for a list of comparison objects
    /// </summary>
    /// <param name="compareData">the list of CompareData objects to export</param>
    public virtual string ExportCompareData(List<CompareData> compareData)
    {
      StringWriter sw = new StringWriter();
      if (compareData.Count > 0)
      {
        Type t = typeof(CompareData);
        PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);

        int compareIndex = 0;
        foreach (CompareData compare in compareData)
        {
          //create tags for comparison object
          foreach (PropertyDescriptor pdescriptor in pdescriptors)
            if (!IsTagExcludedFromExport(pdescriptor.Name))
              CreateTagLineFromProperty(compare, pdescriptor, ref sw, "com" + (compareIndex + 1).ToString());

          compareIndex++;
        }
      }
      sw.Flush();
      return sw.ToString();
    }

    /// <summary>
    /// Imports any comparison tags from the tt2 data, returing a list of 
    /// comparison data objects as its result
    /// </summary>
    /// <returns>List of comparedata objects</returns>
    public virtual List<CompareData> ImportCompareData()
    {
      List<CompareData> result = new List<CompareData>();
      TT2TagList compareTags = FindMatchingTagsByScope(ItemScope.Comparison, -1);
      int numCompareItems = 0;
      foreach (TT2Tag tag in compareTags.Items)
        numCompareItems = Math.Max(numCompareItems, tag.ScopeNum);

      for (int itemIndex = 0; itemIndex < numCompareItems; itemIndex++)
      {
        compareTags.Clear();
        CompareData item = new CompareData();
        result.Add(item);
        Type t = item.GetType();
        PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
        compareTags = FindMatchingTagsByScope(ItemScope.Comparison, itemIndex + 1);
        foreach (PropertyDescriptor pdescriptor in pdescriptors)
        {
          TT2Tag ThisTag;
          if (pdescriptor.Name.ToUpper() == "RECORDID") //make sure we get the web's recordid, otherwise everything becomes a new record!!
            ThisTag = compareTags["WEBRECORDID"];
          else
            ThisTag = compareTags[pdescriptor.Name]; //default; pick up the tag w/same name as property

          if ((ThisTag != null) && (!pdescriptor.IsReadOnly))
          {
            if ((pdescriptor.PropertyType == typeof(double)) && (ThisTag.Values[0].ToString() == IncludedPremiumString))
              pdescriptor.SetValue(item, InsConstants.IncludedPremium);
            else
              SetObjectPropertyValueFromTag(item, pdescriptor, ThisTag);
          }
        }
      }
      return result;
    }

    /// <summary>
    /// Imports CarrierReasonNotBound from TT2 data into the policy
    /// </summary>
    public virtual void ImportTT2CarrierReasonNotBoundPolicy()
    {
      for (var TagIdx = 0; TagIdx < Policy.Quote.CarrierReasonNotBoundList.Count; TagIdx++)
      {
        var pdescriptors = TypeDescriptor.GetProperties(Policy.Quote.CarrierReasonNotBoundList[TagIdx].GetType());
        var carrierReasonNotBoundTags = FindMatchingTagsByScope(ItemScope.CarrierReasonNotBound, TagIdx + 1);
        foreach (PropertyDescriptor pdescriptor in pdescriptors)
        {
          if (pdescriptor.IsReadOnly)
            continue;
          var ThisTag = pdescriptor.Name.Equals("RecordID", StringComparison.OrdinalIgnoreCase) ? carrierReasonNotBoundTags["WEBRECORDID"] : carrierReasonNotBoundTags[pdescriptor.Name];
          if (ThisTag != null)
          {
            SetObjectPropertyValueFromTag(Policy.Quote.CarrierReasonNotBoundList[TagIdx], pdescriptor, ThisTag);
          }
        }
      }
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public TT2Bridge()
    {
    }
  }
}
