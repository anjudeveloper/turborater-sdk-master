using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using TurboRater.Insurance.AU;

namespace TurboRater.Insurance.DataTransformation
{
  /// <summary>
  /// Represents the bridging (import and export) of an Auto policy
  /// AUPolicy with the TT2 format
  /// </summary>
  public class TT2AUBridge : TT2Bridge
  {
    private string m_tT2String = "";
    private AUPolicy m_policy;
    private bool m_ignoreCompanyQuestions;
    private bool m_useCMCCompanyQuestions = true;
    private bool m_useNSDCompanyQuestions = true;
    private List<string> m_tt2Lines = new List<string>();

    /// <summary>
    /// The TT2 string to be imported, if any
    /// </summary>
    public virtual string TT2String
    {
      get { return m_tT2String; }
      set { m_tT2String = value; }
    }

    /// <summary>
    /// A string list to be imported, if any
    /// </summary>
    public List<string> TT2Lines
    {
      get { return m_tt2Lines; }
      set { m_tt2Lines = value; }
    }

    /// <summary>
    /// The AUPolicy associated with this bridge object
    /// </summary>
    public new AUPolicy Policy
    {
      get { return m_policy; }
      set { m_policy = value; base.Policy = value; }
    }

    public virtual bool IgnoreImportCompanyQuestions
    {
      get { return m_ignoreCompanyQuestions; }
      set { m_ignoreCompanyQuestions = value; }
    }

    public virtual bool UseCMCCompanyQuestions
    {
      get { return m_useCMCCompanyQuestions; }
      set { m_useCMCCompanyQuestions = value; }
    }

    public virtual bool UseNSDCompanyQuestions
    {
      get { return m_useNSDCompanyQuestions; }
      set { m_useNSDCompanyQuestions = value; }
    }

    /// <summary>
    /// Imports TT2 policy data into the policy
    /// </summary>
    public override void ImportTT2PolicyToPolicy()
    {
      base.ImportTT2PolicyToPolicy();

      TT2TagList PolicyTags = FindMatchingTags("NumOfCars", ItemScope.Policy, 0);
      TT2Tag ThisTag;
      int NumOfCars = 0;
      int NumOfDrivers = 0;
      int NumOfExclusions = 0;
      if (PolicyTags.Count > 0)
      {
        ThisTag = PolicyTags[0];
        NumOfCars = Convert.ToInt32(ThisTag.Values[0].ToString());
      }     // if (PolicyTags.Count > 0)
      PolicyTags.Clear();

      PolicyTags = FindMatchingTags("NumOfDrivers", ItemScope.Policy, 0);
      if (PolicyTags.Count > 0)
      {
        ThisTag = PolicyTags[0];
        NumOfDrivers = Convert.ToInt32(ThisTag.Values[0].ToString());
      }     // if (PolicyTags.Count > 0)
      PolicyTags.Clear();

      PolicyTags = FindMatchingTags("NumOfExclusions", ItemScope.Policy, 0);
      if (PolicyTags.Count > 0)
      {
        ThisTag = PolicyTags[0];
        NumOfExclusions = Convert.ToInt32(ThisTag.Values[0].ToString());
      }     // if (PolicyTags.Count > 0)
      PolicyTags.Clear();

      while (Policy.Cars.Count < NumOfCars)
      {
        AUCar AddCar = new AUCar();
        AddCar.ParentPolicy = Policy;
        Policy.Cars.Add(AddCar);
      }     // while (Policy.Cars.Count < NumOfCars

      while (Policy.Drivers.Count < NumOfDrivers)
      {
        AUDriver AddDriver;
        if (Policy.Drivers.Count > 0)
        {
          AddDriver = new AUDriver(TypeOfPerson.Other);
          AddDriver.ParentPolicy = Policy;
          AddDriver.PolicyType = InsuranceLine.PersonalAuto;
        }
        else
        {
          AddDriver = new AUDriver(TypeOfPerson.NamedInsured);
          AddDriver.ParentPolicy = Policy;
          AddDriver.PolicyType = InsuranceLine.PersonalAuto;
        }
        Policy.Drivers.Add(AddDriver);
      }

      while (Policy.Exclusions.Count < NumOfExclusions)
      {
        AUDriver AddDriver;
        AddDriver = new AUDriver(TypeOfPerson.Other);
        AddDriver.ParentPolicy = Policy;
        AddDriver.Excluded = true;
        AddDriver.PolicyType = InsuranceLine.PersonalAuto;
        Policy.Exclusions.Add(AddDriver);
      }
    }

    /// <summary>
    /// Imports bridge data storage from TT2 into the policy.
    /// </summary>
    public virtual void ImportBridgeDataStorage()
    {
      foreach (TT2Tag thisTag in Tags)
      {
        if (thisTag.TagName.StartsWith("BridgeDataStorage", StringComparison.OrdinalIgnoreCase))
        {
          switch (thisTag.TagScope)
          {
            case ItemScope.Policy:
              if (thisTag.Values.Count > 0)
                Policy.BridgeDataStorage = thisTag.Values[0].ToString();
              break;
            case ItemScope.Quote:
              if (thisTag.Values.Count > 0)
                Policy.Quote.BridgeDataStorage = thisTag.Values[0].ToString();
              break;
            case ItemScope.Insured:
              if (thisTag.Values.Count > 0)
                Policy.Insured.BridgeDataStorage = thisTag.Values[0].ToString();
              break;
            case ItemScope.Address:
              if (thisTag.Values.Count > 0)
                Policy.MailingAddress.BridgeDataStorage = thisTag.Values[0].ToString();
              break;
            case ItemScope.Driver:
              if ((thisTag.Values.Count > 0) && (Policy.NumOfDrivers >= thisTag.ScopeNum))
                Policy.Drivers[thisTag.ScopeNum - 1].BridgeDataStorage = thisTag.Values[0].ToString();
              break;
            case ItemScope.Exclusion:
              if ((thisTag.Values.Count > 0) && (Policy.NumOfExclusions >= thisTag.ScopeNum))
                Policy.Exclusions[thisTag.ScopeNum - 1].BridgeDataStorage = thisTag.Values[0].ToString();
              break;
            case ItemScope.Car:
              if ((thisTag.Values.Count > 0) && (Policy.NumOfCars >= thisTag.ScopeNum))
                Policy.Cars[thisTag.ScopeNum - 1].BridgeDataStorage = thisTag.Values[0].ToString();
              break;
            case ItemScope.Violation:
              if ((thisTag.Values.Count > 0) && (Policy.NumOfDrivers >= thisTag.ScopeNum) && (Policy.Drivers[thisTag.ScopeNum - 1].NumOfViols >= thisTag.SecondaryScopeNum))
                Policy.Drivers[thisTag.ScopeNum - 1].Violation[thisTag.SecondaryScopeNum - 1].BridgeDataStorage = thisTag.Values[0].ToString();
              break;
          }
        }
      }
    }

    /// <summary>
    /// Imports company questions from TT2 into the policy
    /// </summary>
    public virtual void ImportTT2CompanyQuestionsToPolicyQuestions()
    {
      // This deletes all company questions before importing new ones.  Only deletes the questions if there are real questions in the TT2.  
      // This prevents the questions from being deleted when importing small tt2 files, such as online storage responses, that don't contain 
      // real questions.  If the questions are NOT deleted for real files, it will produce dupicates.
      bool found = false;

      foreach (TT2Tag tag in Tags)
        if (tag.TagName.StartsWith("TF_CD_", StringComparison.OrdinalIgnoreCase) || tag.TagName.StartsWith("TF_CMC_", StringComparison.OrdinalIgnoreCase) || tag.TagName.StartsWith("TF_NSD_", StringComparison.OrdinalIgnoreCase))
        {
          found = true;
          break;
        }
      if (found)
      {
        if (Policy.CompanyQuestions != null)
          Policy.CompanyQuestions.Clear();
        foreach (AUDriver driver in Policy.Drivers)
          if (driver != null)
            driver.CompanyQuestions.Clear();
        foreach (AUCar car in Policy.Cars)
          if (car != null)
            car.CompanyQuestions.Clear();
      }

      foreach (TT2Tag thisTag in Tags)
      {
        if (thisTag.TagName.StartsWith("TF_CD_", StringComparison.OrdinalIgnoreCase))
        {
          // Check for corrupt values.  As of 11/09/2012 we are only checking for manualcreditscore but feel free to add other
          // specific tags if there is a need for it.  If the value is corrupt don't create a company question for this tag.
          bool corruptValue = false;

          if (thisTag.TagName.Equals("tf_cd_manualcreditscore", StringComparison.OrdinalIgnoreCase))
          {
            int validInt = ITCConstants.InvalidNum;

            if (thisTag.Values.Count > 0)
            {
              validInt = ITCConvert.ToInt32(StringLib.TaggedFieldDataDecode(thisTag.Values[0].ToString()), ITCConstants.InvalidNum);
            }

            if (validInt == ITCConstants.InvalidNum)
              corruptValue = true;
          }

          if (!corruptValue)
          {
            CompanyQuestion newQuestion = new CompanyQuestion();

            newQuestion.Name = thisTag.TagName;
            if (newQuestion.Name.ToUpper().IndexOf(InsConstants.CompanyQuestionCategoryPrefixes[(int)CompanyQuestionCategory.CompanyData].ToUpper(), StringComparison.OrdinalIgnoreCase) != -1)
              newQuestion.CompanyQuestionCategory = CompanyQuestionCategory.CompanyData;
            if (newQuestion.Name.ToUpper().IndexOf(InsConstants.CompanyQuestionCategoryPrefixes[(int)CompanyQuestionCategory.CompanyModuleContents].ToUpper(), StringComparison.OrdinalIgnoreCase) != -1)
              newQuestion.CompanyQuestionCategory = CompanyQuestionCategory.CompanyModuleContents;
            if (newQuestion.Name.ToUpper().IndexOf(InsConstants.CompanyQuestionCategoryPrefixes[(int)CompanyQuestionCategory.NonStoredData].ToUpper(), StringComparison.OrdinalIgnoreCase) != -1)
              newQuestion.CompanyQuestionCategory = CompanyQuestionCategory.NonStoredData;
            newQuestion.Name = newQuestion.Name.ToLower().Replace("tf_cd_", "");
            if (thisTag.Values.Count > 0)
              newQuestion.Value = StringLib.TaggedFieldDataDecode(thisTag.Values[0].ToString());
            switch (thisTag.TagScope)
            {
              case ItemScope.Policy:
                newQuestion.Scope = ItemScope.Policy;
                Policy.CompanyQuestions.Add(newQuestion);
                break;
              case ItemScope.Driver:
                newQuestion.Scope = ItemScope.Driver;
                if (Policy.NumOfDrivers >= thisTag.ScopeNum)
                  Policy.Drivers[thisTag.ScopeNum - 1].CompanyQuestions.Add(newQuestion);
                break;
              case ItemScope.Car:
                newQuestion.Scope = ItemScope.Car;
                if (Policy.NumOfCars >= thisTag.ScopeNum)
                  Policy.Cars[thisTag.ScopeNum - 1].CompanyQuestions.Add(newQuestion);
                break;
            }
          }
        }
        if (UseCMCCompanyQuestions)
        {
          if (thisTag.TagName.StartsWith("TF_CMC_", StringComparison.OrdinalIgnoreCase))
          {
            CompanyQuestion newQuestion = new CompanyQuestion();
            newQuestion.Name = thisTag.TagName;
            if (newQuestion.Name.ToUpper().IndexOf(InsConstants.CompanyQuestionCategoryPrefixes[(int)CompanyQuestionCategory.CompanyData].ToUpper(), StringComparison.OrdinalIgnoreCase) != -1)
              newQuestion.CompanyQuestionCategory = CompanyQuestionCategory.CompanyData;
            if (newQuestion.Name.ToUpper().IndexOf(InsConstants.CompanyQuestionCategoryPrefixes[(int)CompanyQuestionCategory.CompanyModuleContents].ToUpper(), StringComparison.OrdinalIgnoreCase) != -1)
              newQuestion.CompanyQuestionCategory = CompanyQuestionCategory.CompanyModuleContents;
            if (newQuestion.Name.ToUpper().IndexOf(InsConstants.CompanyQuestionCategoryPrefixes[(int)CompanyQuestionCategory.NonStoredData].ToUpper(), StringComparison.OrdinalIgnoreCase) != -1)
              newQuestion.CompanyQuestionCategory = CompanyQuestionCategory.NonStoredData;
            newQuestion.Name = newQuestion.Name.ToLower().Replace("tf_cmc_", "");
            if (thisTag.Values.Count > 0)
              newQuestion.Value = StringLib.TaggedFieldDataDecode(thisTag.Values[0].ToString());
            switch (thisTag.TagScope)
            {
              case ItemScope.Policy:
                newQuestion.Scope = ItemScope.Policy;
                Policy.CompanyQuestions.Add(newQuestion);
                break;
              case ItemScope.Driver:
                newQuestion.Scope = ItemScope.Driver;
                if (Policy.NumOfDrivers >= thisTag.ScopeNum)
                  Policy.Drivers[thisTag.ScopeNum - 1].CompanyQuestions.Add(newQuestion);
                break;
              case ItemScope.Car:
                newQuestion.Scope = ItemScope.Car;
                if (Policy.NumOfCars >= thisTag.ScopeNum)
                  Policy.Cars[thisTag.ScopeNum - 1].CompanyQuestions.Add(newQuestion);
                break;
            }
          }
        }
        if (UseNSDCompanyQuestions)
        {
          if (thisTag.TagName.StartsWith("TF_NSD_", StringComparison.OrdinalIgnoreCase))
          {
            CompanyQuestion newQuestion = new CompanyQuestion();
            newQuestion.Name = thisTag.TagName;
            if (newQuestion.Name.ToUpper().IndexOf(InsConstants.CompanyQuestionCategoryPrefixes[(int)CompanyQuestionCategory.CompanyData].ToUpper(), StringComparison.OrdinalIgnoreCase) != -1)
              newQuestion.CompanyQuestionCategory = CompanyQuestionCategory.CompanyData;
            if (newQuestion.Name.ToUpper().IndexOf(InsConstants.CompanyQuestionCategoryPrefixes[(int)CompanyQuestionCategory.CompanyModuleContents].ToUpper(), StringComparison.OrdinalIgnoreCase) != -1)
              newQuestion.CompanyQuestionCategory = CompanyQuestionCategory.CompanyModuleContents;
            if (newQuestion.Name.ToUpper().IndexOf(InsConstants.CompanyQuestionCategoryPrefixes[(int)CompanyQuestionCategory.NonStoredData].ToUpper(), StringComparison.OrdinalIgnoreCase) != -1)
              newQuestion.CompanyQuestionCategory = CompanyQuestionCategory.NonStoredData;
            newQuestion.Name = newQuestion.Name.ToLower().Replace("tf_nsd_", "");
            if (thisTag.Values.Count > 0)
              newQuestion.Value = StringLib.TaggedFieldDataDecode(thisTag.Values[0].ToString());
            switch (thisTag.TagScope)
            {
              case ItemScope.Policy:
                newQuestion.Scope = ItemScope.Policy;
                Policy.CompanyQuestions.Add(newQuestion);
                break;
              case ItemScope.Driver:
                newQuestion.Scope = ItemScope.Driver;
                if (Policy.NumOfDrivers >= thisTag.ScopeNum)
                  Policy.Drivers[thisTag.ScopeNum - 1].CompanyQuestions.Add(newQuestion);
                break;
              case ItemScope.Car:
                newQuestion.Scope = ItemScope.Car;
                if (Policy.NumOfCars >= thisTag.ScopeNum)
                  Policy.Cars[thisTag.ScopeNum - 1].CompanyQuestions.Add(newQuestion);
                break;
            }
          }
        }
      }

      // Remove duplicate manual credit score company questions.
      List<CompanyQuestion> manualCreditScoreQuestions = Policy.CompanyQuestions.FindAll(question => question.Name.Equals("ManualCreditScore", StringComparison.OrdinalIgnoreCase));

      if (manualCreditScoreQuestions.Count > 1)
      {
        // Store the question we want to keep.
        CompanyQuestion lastManualCreditScoreQuestion = Policy.CompanyQuestions.FindLast(question => question.Name.Equals("ManualCreditScore", StringComparison.OrdinalIgnoreCase));
        // Remove all "ManualCreditScore" tags.
        Policy.CompanyQuestions.RemoveAll(question => question.Name.Equals("ManualCreditScore", StringComparison.OrdinalIgnoreCase));
        // Restore the original.
        Policy.CompanyQuestions.Add(lastManualCreditScoreQuestion);
      }
    }

    /// <summary>
    /// Imports cars from TT2 data into the policy
    /// </summary>
    public virtual void ImportTT2CarsToPolicy()
    {
      TT2TagList CarTags;
      for (int TagIdx = 0; TagIdx < Policy.NumOfCars; TagIdx++)
      {
        Type t = Policy.Cars[TagIdx].GetType();
        PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
        CarTags = FindMatchingTagsByScope(ItemScope.Car, TagIdx + 1);
        foreach (PropertyDescriptor pdescriptor in pdescriptors)
        {
          TT2Tag ThisTag;
          if (pdescriptor.Name.ToUpper() == "RECORDID") //make sure we get the web's recordid, otherwise everything becomes a new record!!
            ThisTag = CarTags["WEBRECORDID"];
          else if (pdescriptor.Name.ToUpper() == "FOREIGNCAR") //make sure we get the web's recordid, otherwise everything becomes a new record!!
            ThisTag = CarTags["FOREIGN"];
          else if (pdescriptor.Name.ToUpper() == "LIENHOLDERADDRESS1") //make sure we get the web's recordid, otherwise everything becomes a new record!!
            ThisTag = CarTags["LIENHOLDERADDR1"];
          else if (pdescriptor.Name.ToUpper() == "LIENHOLDERADDRESS12") //make sure we get the web's recordid, otherwise everything becomes a new record!!
            ThisTag = CarTags["LIENHOLDERADDR12"];
          else if (pdescriptor.Name.ToUpper() == "LIENHOLDERADDRESS2") //make sure we get the web's recordid, otherwise everything becomes a new record!!
            ThisTag = CarTags["LIENHOLDERADDR2"];
          else if (pdescriptor.Name.ToUpper() == "LIENHOLDERADDRESS22") //make sure we get the web's recordid, otherwise everything becomes a new record!!
            ThisTag = CarTags["LIENHOLDERADDR22"];
          else
            ThisTag = CarTags[pdescriptor.Name]; //default; pick up the tag w/same name as property

          if ((ThisTag != null) && (!pdescriptor.IsReadOnly))
            SetObjectPropertyValueFromTag(Policy.Cars[TagIdx], pdescriptor, ThisTag);
        }

        foreach (TT2Tag thisTag in CarTags)
        {
          string tagName = thisTag.TagName.ToLower();
          if (tagName.Contains("pointsctaccdeath"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.AccDeath] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.AccDeath] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctbuybackpip"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.BuyBackPIP] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.BuyBackPIP] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctcoll"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.Coll] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.Coll] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctcombfirstparty"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.CombFirstParty] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.CombFirstParty] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctcomp"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.Comp] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.Comp] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctequipment"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.Equipment] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.Equipment] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctextramed"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.ExtraMed] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.ExtraMed] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctfulladdtlpip"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.FullAddtlPIP] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.FullAddtlPIP] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctfuneral"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.Funeral] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.Funeral] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctguestpip"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.GuestPIP] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.GuestPIP] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctincloss"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.IncLoss] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.IncLoss] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctliabbi"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.LiabBI] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.LiabBI] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctliabpd"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.LiabPD] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.LiabPD] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctlienholder"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.LienHolder] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.LienHolder] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctlimitedliabpd"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.LimitedLiabPD] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.LimitedLiabPD] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctmedexpense"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.MedExpense] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.MedExpense] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctmedicare"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.Medicare] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.Medicare] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctmedpay"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.MedPay] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.MedPay] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctmexico"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.Mexico] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.Mexico] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctobel"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.OBEL] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.OBEL] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctoutstatepip"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.OutStatePIP] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.OutStatePIP] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctpip"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.PIP] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.PIP] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctppi"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.PPI] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.PPI] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctrental"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.Rental] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.Rental] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctsum"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.SUM] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.SUM] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointscttowing"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.Towing] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.Towing] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctuimbi"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.UIMBI] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.UIMBI] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctuimpd"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.UIMPD] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.UIMPD] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctuninsbi"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.UninsBI] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.UninsBI] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctuninspd"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.UninsPD] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.UninsPD] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctwaivedpip"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.WaivedPIP] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.WaivedPIP] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctworkloss"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.WorkLoss] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.WorkLoss] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
          else if (tagName.Contains("pointsctgap"))
          {
            if (tagName.StartsWith("secondary", StringComparison.OrdinalIgnoreCase))
              Policy.Cars[TagIdx].SecondaryCoveragePoints[(int)CoverageType.Gap] = ITCConvert.ToInt32(thisTag.Values[0], 0);
            else
              Policy.Cars[TagIdx].CoveragePoints[(int)CoverageType.Gap] = ITCConvert.ToInt32(thisTag.Values[0], 0);
          }
        }

        CarTags.Clear();
      }
    }

    /// <summary>
    /// Gets the state of the policy represented by the TT2
    /// </summary>
    /// <returns>The product state of this policy</returns>
    protected USState GetBridgeState()
    {
      USState result = USState.NoneSelected;
      TT2Tag tag = null;
      TT2TagList tags = FindMatchingTags("productid", ItemScope.Policy, 0);
      if (tags.Count > 0)
        tag = tags[0];

      if (tag != null)
      {
        int productID = ITCConvert.ToInt32(tag.Values[0].ToString().Trim(), ITCConstants.InvalidNum);
        if (productID > 0)
          result = ITCConvert.CMPProductNumberToUSState(productID);
      }

      if (result == USState.NoneSelected)
      {
        tag = Tags["stateabbr"];
        if (tag != null)
          result = ITCConvert.StateAbbrevToEnum(tag.Values[0].ToString().Trim());

        if (result == USState.NoneSelected)
        {
          if (FindMatchingTags("state", ItemScope.Policy, 0).Count > 0)
            tag = FindMatchingTags("state", ItemScope.Policy, 0)[0];
          if (tag != null)
            result = ITCConvert.StateAbbrevToEnum(tag.Values[0].ToString().Trim());
        }
      }
      return result;
    }

    /// <summary>
    /// Imports violations from TT2 to the specified driver in the policy
    /// </summary>
    /// <param name="driverNum">The index of the driver in the policy (0-based)</param>
    /// <param name="numOfViols">The # of violations we wish to import</param>
    public virtual void ImportTT2ViolationsToPolicyDriver(int driverNum, int numOfViols)
    {
      USState productState = GetBridgeState();
      if (driverNum == int.MaxValue)
        throw new ArgumentOutOfRangeException("driverNum", "driverNum must be less than Int32.MaxValue");

      int minViolCode = (productState == USState.California) ? AUConstants.vcCAFirstViolCode : AUConstants.vcFirstViolCode;
      int maxViolCode = (productState == USState.California) ? AUConstants.vcCALastViolCode : AUConstants.vcLastViolCode;

      TT2TagList ViolTags;
      for (int CurrViol = 0; CurrViol < numOfViols; CurrViol++)
      {
        ViolTags = FindMatchingTagsByPrimaryAndSecondaryScope(ItemScope.Driver, driverNum + 1, ItemScope.Violation, CurrViol + 1);
        Type t = Policy.Drivers[driverNum].Violation[CurrViol].GetType();
        PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
        foreach (PropertyDescriptor pdescriptor in pdescriptors)
        {
          TT2Tag ThisTag;
          if (pdescriptor.Name.ToUpper() == "RECORDID") //make sure we get the web's recordid, otherwise everything becomes a new record!!
            ThisTag = ViolTags["WEBRECORDID"];
          else
            ThisTag = ViolTags[pdescriptor.Name]; //default; pick up the tag w/same name as property

          if ((ThisTag != null) && (!pdescriptor.IsReadOnly))
          {
            SetObjectPropertyValueFromTag(Policy.Drivers[driverNum].Violation[CurrViol], pdescriptor, ThisTag);
            if (ThisTag.TagName.Equals("violcode", StringComparison.OrdinalIgnoreCase))
            {
              int violCode = ITCConvert.ToInt32(ThisTag.Values[0], 0);
              if (violCode < minViolCode || violCode > maxViolCode)
              {
                violCode = AUConstants.GetViolCodeFromWrongStateCode(productState, violCode);
                Policy.Drivers[driverNum].Violation[CurrViol].ViolCode = violCode;
              }
              if (violCode < minViolCode || violCode > maxViolCode)
                Policy.Drivers[driverNum].Violation[CurrViol].ViolCode = (productState == USState.California) ? AUConstants.vcAllOtherMovingViolations : AUConstants.vcMiscMovingViol;
            }
          }
        }
        ViolTags.Clear();
      }
    }

    public virtual void ImportTT2SuspensionsToPolicyDriver(int driverNum, int numOfSusps)
    {
      if (driverNum == Int32.MaxValue)
        throw new ArgumentOutOfRangeException("driverNum", "driverNum must be less than Int32.MaxValue");

      TT2TagList SuspTags;
      for (int CurrSusp = 0; CurrSusp < numOfSusps; CurrSusp++)
      {
        SuspTags = FindMatchingTagsByPrimaryAndSecondaryScope(ItemScope.Driver, driverNum + 1, ItemScope.Suspension, CurrSusp + 1);
        Type t = Policy.Drivers[driverNum].DMVActions[CurrSusp].GetType();
        PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
        foreach (PropertyDescriptor pdescriptor in pdescriptors)
        {
          TT2Tag ThisTag;
          if (pdescriptor.Name.Equals("RecordID", StringComparison.OrdinalIgnoreCase))
            ThisTag = SuspTags["WEBRECORDID"];
          else
            ThisTag = SuspTags[pdescriptor.Name];
          if ((ThisTag != null) && (!pdescriptor.IsReadOnly))
            SetObjectPropertyValueFromTag(Policy.Drivers[driverNum].DMVActions[CurrSusp], pdescriptor, ThisTag);
        }
        SuspTags.Clear();
      }
    }

    /// <summary>
    /// Imports drivers from TT2 data into the policy. Also can import
    /// exclusions too if the parameter exclusions is set to true.
    /// </summary>
    /// <param name="exclusions">If true, we are importing exclusions.
    /// If false, we're importing plain old drivers.</param>
    public virtual void ImportTT2DriversToPolicy(bool exclusions)
    {
      TT2TagList DriverTags;
      int NumOfViols;
      int NumOfSusps;
      int NumOfUnits = Policy.NumOfDrivers;

      if (exclusions)
        NumOfUnits = Policy.NumOfExclusions;
      for (int TagIdx = 0; TagIdx < NumOfUnits; TagIdx++)
      {
        NumOfViols = 0;
        NumOfSusps = 0;
        Type t = Policy.Drivers[0].GetType();
        PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
        AUDriver driverOrExclusion;
        if (exclusions)
          driverOrExclusion = Policy.Exclusions[TagIdx];
        else
          driverOrExclusion = Policy.Drivers[TagIdx];
        if (!exclusions)
          DriverTags = FindMatchingTagsByPrimaryAndSecondaryScope(ItemScope.Driver, TagIdx + 1, ItemScope.Policy, 0);
        else
          DriverTags = FindMatchingTagsByPrimaryAndSecondaryScope(ItemScope.Exclusion, TagIdx + 1, ItemScope.Policy, 0);

        // This deletes all violations before importing new ones.  Only deletes the violations if there are real violations with
        // viol codes in the import tt2 string.  This prevents the viols from being deleted when importing small tt2 files, such as 
        // online storage responses, that don't contain real violations.  If the viols are NOT deleted for real files, it will produce
        // dupicates.
        bool found = false;
        foreach (TT2Tag tag in Tags)
          if (tag.TagScope == ItemScope.Driver && tag.SecondaryScope == ItemScope.Violation && tag.TagName.Trim() == "violcode")
          {
            found = true;
            break;
          }
        if (found)
        {
          if (driverOrExclusion.Violation != null)
            driverOrExclusion.Violation.Clear();
        }

        found = false;
        foreach (TT2Tag tag in Tags)
          if (tag.TagScope == ItemScope.Driver && tag.SecondaryScope == ItemScope.Suspension && tag.TagName.Trim().Equals("action", StringComparison.OrdinalIgnoreCase))
          {
            found = true;
            break;
          }
        if (found)
        {
          if (driverOrExclusion.DMVActions != null)
            driverOrExclusion.DMVActions.Clear();
        }

        TT2Tag ThisTag;
        ThisTag = DriverTags["NumOfViols"];
        if (ThisTag != null)
        {
          if (!exclusions)
          {
            NumOfViols = Convert.ToInt32(ThisTag.Values[0].ToString());
            for (int I = 1; I <= NumOfViols; I++)
            {
              AUViolation AddViol = new AUViolation();
              driverOrExclusion.Violation.Add(AddViol);
            }
          }
        }

        ThisTag = DriverTags["NumOfSusps"];
        if (ThisTag != null)
        {
          if (!exclusions)
          {
            NumOfSusps = Convert.ToInt32(ThisTag.Values[0].ToString());
            for (int I = 1; I <= NumOfSusps; I++)
            {
              DMVAction AddAction = new DMVAction();
              driverOrExclusion.DMVActions.Add(AddAction);
            }
          }
        }

        //get all property info imported for viols
        foreach (PropertyDescriptor pdescriptor in pdescriptors)
        {
          if (pdescriptor.Name.ToUpper() == "RECORDID") //make sure we get the web's recordid, otherwise everything becomes a new record!!
            ThisTag = DriverTags["WEBRECORDID"];
          else if (pdescriptor.Name.ToUpper() == "PHONE") //make sure we get the web's recordid, otherwise everything becomes a new record!!
            ThisTag = DriverTags["HOMEPHONE"];
          else if (pdescriptor.Name.ToUpper() == "DRUGAWARENESS") //make sure we get the web's recordid, otherwise everything becomes a new record!!
            ThisTag = DriverTags["DRUGAWARNESS"];
          else if (pdescriptor.Name.ToUpper() == "EMPLOYERADDRESS1") //make sure we get the web's recordid, otherwise everything becomes a new record!!
            ThisTag = DriverTags["EMPLOYERADDR1"];
          else if (pdescriptor.Name.ToUpper() == "EMPLOYERADDRESS2") //make sure we get the web's recordid, otherwise everything becomes a new record!!
            ThisTag = DriverTags["EMPLOYERADDR2"];
          else if (pdescriptor.Name.ToUpper() == "RELATION")
          {
            ThisTag = DriverTags["RELATION"];
            if ((ThisTag != null) && (ThisTag.TagLine.Contains("drv1")))
              if (ThisTag.Values != null && ThisTag.Values.Count > 0)
                ThisTag.Values[0] = "I";

            if (ThisTag != null)
            {
              if (!exclusions && Policy.NumOfDrivers >= 2)
              {
                for (int TagIndex = 2; TagIndex <= Policy.NumOfDrivers; TagIndex++)
                  if (ThisTag.TagLine.Contains("drv" + TagIndex))
                    if (ThisTag.Values != null && ThisTag.Values.Count > 0)
                      if (ThisTag.Values[0].ToString() == "I")
                        ThisTag.Values[0] = "R";
              }

              if (exclusions && Policy.NumOfExclusions > 0)
              {
                for (int TagIndex = 1; TagIndex <= Policy.NumOfExclusions; TagIndex++)
                {
                  if (ThisTag.TagLine.Contains("exc" + TagIndex))
                    if (ThisTag.Values != null && ThisTag.Values.Count > 0)
                      if (ThisTag.Values[0].ToString() == "I")
                        ThisTag.Values[0] = "R";
                }
              }
            }
          }
          else if (pdescriptor.Name.ToUpper() == "DOB")
          {
            ThisTag = DriverTags["DOB"];
            if (ThisTag != null)
            {
              if (ITCConvert.ToDateTime(ThisTag.Values[0].ToString(), ITCConstants.InvalidDate) > DateTime.Today)
                ThisTag.Values[0] = ITCConstants.InvalidDate.ToShortDateString();
            }
          }
          else
            ThisTag = DriverTags[pdescriptor.Name]; //default; pick up the tag w/same name as property

          if ((ThisTag != null) && (!pdescriptor.IsReadOnly))
            SetObjectPropertyValueFromTag(driverOrExclusion, pdescriptor, ThisTag);
        }

        // If MonthsLicensed tag is not passed into the file, set it if possible based on DateLicensed or DOB.  We will need
        // MonthsLicensed set to get the DateLicensed in the next step.
        if ((DriverTags["MONTHSLICENSED"] == null) && (ITCConstants.IsValidDate(Policy.EffectiveDate)))
        {
          if ((DriverTags["DATELICENSED"] != null) && (ITCConstants.IsValidDate(driverOrExclusion.DateLicensed)))
            driverOrExclusion.MonthsLicensed = DateLib.MonthsDifference(driverOrExclusion.DateLicensed, Policy.EffectiveDate);
          else if (ITCConstants.IsValidDate(driverOrExclusion.DOB) && !ITCConstants.IsValidDate(driverOrExclusion.DateLicensed))
          {
            driverOrExclusion.DateLicensed = driverOrExclusion.DOB.AddMonths(192);
            driverOrExclusion.MonthsLicensed = DateLib.MonthsDifference(driverOrExclusion.DateLicensed, Policy.EffectiveDate);
          }
        }

        if (DriverTags["MONTHSLICENSEDSTATE"] == null)
          driverOrExclusion.MonthsLicensedState = driverOrExclusion.MonthsLicensed;

        if (DriverTags["MONTHSMVREXPER"] == null)
          driverOrExclusion.MonthsMVRExper = driverOrExclusion.MonthsLicensed;

        // Set DateLicensed based on months licensed and effective date.
        try
        {
          if (!ITCConstants.IsValidDate(driverOrExclusion.DateLicensed))
            if (ITCConstants.IsValidDate(Policy.EffectiveDate) && (driverOrExclusion.MonthsLicensed != ITCConstants.InvalidNum) &&
              (driverOrExclusion.MonthsLicensed >= 0) && (driverOrExclusion.MonthsLicensed <= driverOrExclusion.Age * 12))
              driverOrExclusion.DateLicensed = Policy.EffectiveDate.AddMonths(-driverOrExclusion.MonthsLicensed);
        }
        catch
        {
          //eat it...if we tried to set to an invalid date, just ignore problems
        }

        DriverTags.Clear();

        if (!exclusions)
        {
          ImportTT2ViolationsToPolicyDriver(TagIdx, NumOfViols);
          ImportTT2SuspensionsToPolicyDriver(TagIdx, NumOfSusps);
        }
      }
    }

    /// <summary>
    /// Looks in the import tags for the special tag importbridgedatastorage.
    /// If this tag exists, it uses the value of the tag to set ExcludeBridgeDataStorage.
    /// By default, ExcludeBridgeDataStorage is true, so BridgeDataStorage will not import,
    /// and this allows the TT2 itself to force the import.
    /// </summary>
    protected void SetExcludeBridgeDataStorageFromTag()
    {
      TT2TagList importBridgeDataStorageTags = FindMatchingTags("ImportBridgeDataStorage", ItemScope.System, 0);
      if (importBridgeDataStorageTags.Count > 0)
      {
        TT2Tag theTag = importBridgeDataStorageTags[0];
        ExcludeBridgeDataStorageTags = !ITCConvert.ToBoolean(theTag.Values[0], false);
      }
    }

    /// <summary>
    /// Imports the entire set of policy information (cars, drivers, etc)
    /// from TT2 into the Policy and related objects
    /// </summary>
    public override void ImportPolicyInfo()
    {
      SetExcludeBridgeDataStorageFromTag();

      ImportTT2PolicyToPolicy();
      ImportTT2CarsToPolicy();
      ImportTT2DriversToPolicy(false); //drivers
      ImportTT2DriversToPolicy(true);  //excluded drivers

      if (!IgnoreImportCompanyQuestions)
        ImportTT2CompanyQuestionsToPolicyQuestions();

      if (!ExcludeBridgeDataStorageTags)
        ImportBridgeDataStorage();
    }

    /// <summary>
    /// Exports an AUPolicy to TT2 data; the TT2 gets placed in the 
    /// sw ref parameter
    /// </summary>
    /// <param name="sw">Contains the TT2 output</param>
    public override void ExportPolicyToTT2Policy(ref StringWriter sw)
    {
      base.ExportPolicyToTT2Policy(ref sw);

      //turns out we don't need to do anything but call the base. go figure! the ins level
      //bridge exports the policy as whatever policy type it really is, so at the ins level
      //we're getting even the auto level tags too

      /*Type t = Policy.GetType();
      // BindingFlags.DeclaredOnly keeps us from sending the same tags for InsPolicy as we already inherited in AUPolicy.  07/27/2009 AMJ
      //PropertyInfo[] pinfos = t.GetProperties(BindingFlags.DeclaredOnly);
      PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
      foreach (PropertyDescriptor pdescriptor in pdescriptors)
      {
        if (!IsTagExcludedFromExport(pdescriptor.Name))
        {
          //only write out properties that are in this main type, not in the types it's descended from; those are already created in the call to the base method above
          if (t.GetProperty(pdescriptor.Name).DeclaringType == t)
            CreateTagLineFromProperty(Policy, pdescriptor, ref sw, "pol0");
        }
      } */
    }

    /// <summary>
    /// Checks a question value to see if it's a date.  If it is a date, and it's an invalid
    /// date, it returns the invalid date constant that's appropriate to whether or not 
    /// UseWebInvalidDate is true.
    /// </summary>
    /// <param name="questionName">Name of the question.</param>
    /// <param name="questionValue">Value of the question.</param>
    /// <returns>Returns original value if string is anything but an invalid datetime.
    /// If this value is an invalid datetime, it returns ITCConstants.InvalidDate if
    /// UseWebInvalidDate is true, or ITCConstants.InvalidWindowsDate if it is false.</returns>
    public virtual string GetQuestionValue(string questionName, string questionValue)
    {
      string returnValue = questionValue;
      DateTime attemptedDate;

      // Check to see if this is a DateTime value.
      if (DateTime.TryParse(returnValue, out attemptedDate))
      {
        if (!ITCConstants.IsValidDate(attemptedDate))
        {
          if (UseWebInvalidDate)
            attemptedDate = ITCConstants.InvalidDate;
          else
            attemptedDate = ITCConstants.InvalidWindowsDate;

          if (IsTimeTag(questionName))
            returnValue = TT2FormatTime(returnValue);
          else
          {
            if (UseWebInvalidDate)
              returnValue = TT2FormatDate(ITCConstants.InvalidDate);
            else
              returnValue = TT2FormatDate(ITCConstants.InvalidWindowsDate);
          }
        }
      }

      return returnValue;
    }


    /// <summary>
    /// Exports policy, driver and car company questions to TT2 data
    /// </summary>
    /// <param name="sw">Contains the TT2 output</param>
    public virtual void ExportCompanyQuestionsToTT2Questions(ref StringWriter sw)
    {
      //peh-added the lock 3-3-10 because we keep running into threading issues in twe
      lock (Policy.CompanyQuestions)
      {
        foreach (CompanyQuestion question in Policy.CompanyQuestions)
        {
          string questionPrefix = InsConstants.CompanyQuestionCategoryPrefixes[(int)question.CompanyQuestionCategory];
          sw.WriteLine("\"tf_" + questionPrefix.ToLower() + question.Name.ToLower() + "\",\"" + TT2Tag.GetScopeString(ItemScope.Policy) + "0\",\"" +
            StringLib.TaggedFieldDataEncode(GetQuestionValue(question.Name, question.Value)) + "\"");
        }
      }
      int driverIndex = 1;
      foreach (AUDriver driver in Policy.Drivers)
      {
        if (!driver.Ignored || IncludeIgnoredDrivers)
        {
          foreach (CompanyQuestion question in driver.CompanyQuestions)
          {
            string questionPrefix = InsConstants.CompanyQuestionCategoryPrefixes[(int)question.CompanyQuestionCategory];
            sw.WriteLine("\"tf_" + questionPrefix.ToLower() + question.Name.ToLower() + "\",\"" + TT2Tag.GetScopeString(ItemScope.Driver) + driverIndex.ToString() + "\",\"" +
              StringLib.TaggedFieldDataEncode(GetQuestionValue(question.Name, question.Value)) + "\"");
          }
          driverIndex++;
        }
      }
      int carIndex = 1;
      foreach (AUCar car in Policy.Cars)
      {
        if (!car.Ignored || IncludeIgnoredCars)
        {
          foreach (CompanyQuestion question in car.CompanyQuestions)
          {
            string questionPrefix = InsConstants.CompanyQuestionCategoryPrefixes[(int)question.CompanyQuestionCategory];
            sw.WriteLine("\"tf_" + questionPrefix.ToLower() + question.Name.ToLower() + "\",\"" + TT2Tag.GetScopeString(ItemScope.Car) + carIndex.ToString() + "\",\"" +
              StringLib.TaggedFieldDataEncode(GetQuestionValue(question.Name, question.Value)) + "\"");
          }
          carIndex++;
        }
      }
    }

    /// <summary>
    /// Exports the vehicles on the policy to TT2 data
    /// </summary>
    /// <param name="sw">Contains the TT2 output</param>
    public virtual void ExportPolicyCarsToTT2(ref StringWriter sw)
    {
      int scope = 0;
      for (int CarNum = 0; CarNum < Policy.NumOfCars; CarNum++)
      {
        if (!Policy.Cars[CarNum].Ignored || IncludeIgnoredCars)
        {
          scope += 1;
          string ScopeString = scope.ToString()/*(CarNum + 1).ToString()*/;
          Type t = Policy.Cars[CarNum].GetType();
          //PropertyInfo[] pinfos = t.GetProperties();
          PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
          foreach (PropertyDescriptor pdescriptor in pdescriptors)
          {
            if (!IsTagExcludedFromExport(pdescriptor.Name))
            {
              if (pdescriptor.Name.ToUpper() == "FOREIGNCAR") //foreign (the winders one) is a sql reserved word
                CreateTagLineFromProperty(Policy.Cars[CarNum], pdescriptor, ref sw, "car" + ScopeString, "Foreign");
              else if (pdescriptor.Name.ToUpper() == "LIENHOLDERADDRESS1")
                CreateTagLineFromProperty(Policy.Cars[CarNum], pdescriptor, ref sw, "car" + ScopeString, "LienHolderAddr1");
              else if (pdescriptor.Name.ToUpper() == "LIENHOLDERADDRESS12")
                CreateTagLineFromProperty(Policy.Cars[CarNum], pdescriptor, ref sw, "car" + ScopeString, "LienHolderAddr12");
              else if (pdescriptor.Name.ToUpper() == "LIENHOLDERADDRESS2")
                CreateTagLineFromProperty(Policy.Cars[CarNum], pdescriptor, ref sw, "car" + ScopeString, "LienHolderAddr2");
              else if (pdescriptor.Name.ToUpper() == "LIENHOLDERADDRESS22")
                CreateTagLineFromProperty(Policy.Cars[CarNum], pdescriptor, ref sw, "car" + ScopeString, "LienHolderAddr22");
              else if (pdescriptor.Name.ToUpper() == "RECORDID")
                CreateTagLineFromProperty(Policy.Cars[CarNum], pdescriptor, ref sw, "car" + ScopeString, "WebRecordID");
              else if (pdescriptor.Name.ToUpper() == "LIENHOLDERTYPE")
                CreateTagLineFromProperty(Policy.Cars[CarNum], pdescriptor, ref sw, "car" + ScopeString, "LienHolderType");
              else if (pdescriptor.Name.ToUpper() == "LIENHOLDERTYPE2")
                CreateTagLineFromProperty(Policy.Cars[CarNum], pdescriptor, ref sw, "car" + ScopeString, "LienHolderType2");
              else if (pdescriptor.Name.ToUpper() == "COVERAGEPOINTS")
              {
                for (CoverageType covType = CoverageType.Liab; covType <= CoverageType.Gap; covType++)
                {
                  sw.WriteLine("\"pointsct" + covType.ToString() + "\",\"car" + ScopeString + "\",\"" + Policy.Cars[CarNum].CoveragePoints[(int)covType].ToString() + "\"");
                }
              }
              else if (pdescriptor.Name.ToUpper() == "SECONDARYCOVERAGEPOINTS")
              {
                for (CoverageType covType = CoverageType.Liab; covType <= CoverageType.Gap; covType++)
                  sw.WriteLine("\"secondarypointsct" + covType.ToString() + "\",\"car" + ScopeString + "\",\"" + Policy.Cars[CarNum].SecondaryCoveragePoints[(int)covType].ToString() + "\"");
              }
              else
                CreateTagLineFromProperty(Policy.Cars[CarNum], pdescriptor, ref sw, "car" + ScopeString);
            }
          }
        }
      }
    }

    /// <summary>
    /// Exports all driver violations to TT2 data
    /// </summary>
    /// <param name="sw">Contains the TT2 output</param>
    public virtual void ExportPolicyDriverViolationsToTT2(ref StringWriter sw)
    {
      int DriverNum = 0;
      foreach (AUDriver currentDriver in Policy.Drivers)
      {
        if (!currentDriver.Ignored || IncludeIgnoredDrivers)
        {
          string DriverScope = (DriverNum + 1).ToString();
          for (int ViolNum = 0; ViolNum < currentDriver.NumOfViols; ViolNum++)
          {
            string ViolScope = (ViolNum + 1).ToString();
            Type t = currentDriver.Violation[ViolNum].GetType();
            PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
            foreach (PropertyDescriptor pdescriptor in pdescriptors)
            {
              if (!IsTagExcludedFromExport(pdescriptor.Name))
              {
                if (pdescriptor.Name.ToUpper() == "RECORDID")
                  CreateTagLineFromProperty(currentDriver.Violation[ViolNum], pdescriptor, ref sw,
                    "drv" + DriverScope + ":vio" + ViolScope, "WebRecordID");
                else
                  CreateTagLineFromProperty(currentDriver.Violation[ViolNum], pdescriptor, ref sw,
                    "drv" + DriverScope + ":vio" + ViolScope);
              }
            }
            // this is here so that the export of driver violations matches the desktop;
            // the desktop exports this tag, even though it shouldn't.
            sw.WriteLine("\"customviolationdescription\",\"drv" +
                         DriverScope + "\",\"" + currentDriver.Violation[ViolNum].ViolCode.ToString() +
                         "\",\"" +
                         AUConstants.ViolNameByCode(currentDriver.Violation[ViolNum].ViolCode,
                           ITCConvert.StateAbbrevToEnum(currentDriver.Violation[ViolNum].LocationState))
                           .Replace(",", "") + "\"");
          }
          DriverNum++;
        }
      }
    }

    /// <summary>
    /// Exports all driver suspensions to TT2 data
    /// </summary>
    /// <param name="sw">Contains the TT2 output</param>
    public virtual void ExportPolicyDriverSuspensionsToTT2(ref StringWriter sw)
    {
      int DriverNum = 0;
      foreach (AUDriver currentDriver in Policy.Drivers)
      {
        if (!currentDriver.Ignored || IncludeIgnoredDrivers)
        {
          string DriverScope = (DriverNum + 1).ToString();
          for (int SuspNum = 0; SuspNum < currentDriver.DMVActions.Count; SuspNum++)
          {
            string SuspScope = (SuspNum + 1).ToString();
            Type t = currentDriver.DMVActions[SuspNum].GetType();
            PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
            foreach (PropertyDescriptor pdescriptor in pdescriptors)
            {
              if (!IsTagExcludedFromExport(pdescriptor.Name))
              {
                if (pdescriptor.Name.Equals("RecordID", StringComparison.OrdinalIgnoreCase))
                  CreateTagLineFromProperty(currentDriver.DMVActions[SuspNum], pdescriptor, ref sw,
                    "drv" + DriverScope + ":sus" + SuspScope, "WebRecordID");
                else
                {
                  CreateTagLineFromProperty(currentDriver.DMVActions[SuspNum], pdescriptor, ref sw,
                    "drv" + DriverScope + ":sus" + SuspScope);
                }
              }
            }
          }
          DriverNum++;
        }
      }
    }

    /// <summary>
    /// Exports just the points for all driver violations to TT2 data
    /// </summary>
    /// <param name="sw">Contains the TT2 output</param>
    public virtual void ExportViolationPointsToTT2(ref StringWriter sw)
    {
      for (int DriverNum = 0; DriverNum < Policy.NumOfDrivers; DriverNum++)
      {
        string DriverScope = (DriverNum + 1).ToString();
        for (int ViolNum = 0; ViolNum < Policy.Drivers[DriverNum].NumOfViols; ViolNum++)
        {
          string ViolScope = (ViolNum + 1).ToString();
          Type t = Policy.Drivers[DriverNum].Violation[ViolNum].GetType();
          PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
          foreach (PropertyDescriptor pdescriptor in pdescriptors)
            if (pdescriptor.Name.ToUpper() == "VIOLPOINTS")
              CreateTagLineFromProperty(Policy.Drivers[DriverNum].Violation[ViolNum], pdescriptor, ref sw, "drv" + DriverScope + ":vio" + ViolScope);
        }
      }
    }

    /// <summary>
    /// Exports the drivers on the policy to TT2 data
    /// </summary>
    /// <param name="sw">Contains the TT2 output</param>
    /// <param name="exclusions">If true, we are exporting the excluded drivers list. 
    /// If false, we are exporting the normal drivers list</param>
    public virtual void ExportPolicyDriversToTT2(ref StringWriter sw, bool exclusions)
    {
      string scopeString = "drv";
      if (exclusions)
        scopeString = "exc";
      int numUnits = Policy.NumOfDrivers;
      if (exclusions)
        numUnits = Policy.NumOfExclusions;
      int scope = 0;
      for (int DriverNum = 0; DriverNum < numUnits; DriverNum++)
      {
        Type t = typeof(AUDriver);
        if (Policy.Drivers.Count > 0)
          t = Policy.Drivers[0].GetType();
        else if (Policy.Exclusions.Count > 0)
          t = Policy.Exclusions[0].GetType();
        PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
        AUDriver driverOrExclusion;
        if (exclusions)
          driverOrExclusion = Policy.Exclusions[DriverNum];
        else
          driverOrExclusion = Policy.Drivers[DriverNum];
        if (!driverOrExclusion.Ignored || IncludeIgnoredDrivers)
        {
          scope += 1;
          string ScopeString = scope.ToString()/*(DriverNum + 1).ToString()*/;
          foreach (PropertyDescriptor pdescriptor in pdescriptors)
          {
            if (!IsTagExcludedFromExport(pdescriptor.Name))
            {
              if (pdescriptor.Name.ToUpper() == "DRUGAWARENESS")
                CreateTagLineFromProperty(driverOrExclusion, pdescriptor, ref sw, scopeString + ScopeString, "DrugAwarness");
              else if (pdescriptor.Name.ToUpper() == "EMPLOYERADDRESS1")
                CreateTagLineFromProperty(driverOrExclusion, pdescriptor, ref sw, scopeString + ScopeString, "EmployerAddr1");
              else if (pdescriptor.Name.ToUpper() == "EMPLOYERADDRESS2")
                CreateTagLineFromProperty(driverOrExclusion, pdescriptor, ref sw, scopeString + ScopeString, "EmployerAddr2");
              else if (pdescriptor.Name.ToUpper() == "PHONE")
                CreateTagLineFromProperty(driverOrExclusion, pdescriptor, ref sw, scopeString + ScopeString, "HomePhone");
              else if (pdescriptor.Name.ToUpper() == "RECORDID")
                CreateTagLineFromProperty(driverOrExclusion, pdescriptor, ref sw, scopeString + ScopeString, "WebRecordID");
              else if (!IsTagExcludedFromExport(pdescriptor.Name))
                CreateTagLineFromProperty(driverOrExclusion, pdescriptor, ref sw, scopeString + ScopeString);
            }
          }
        }
      }
    }


    /// <summary>
    /// Exports policy warning, error, surcharge, and discount messages to TT2 data
    /// </summary>
    /// <param name="sw">Contains the TT2 output</param>
    public virtual void ExportPolicyMessagesToTT2(ref StringWriter sw)
    {
      int MsgIndex;
      for (MsgIndex = 0; MsgIndex < Policy.Errors.Count; MsgIndex++)
        sw.WriteLine("\"errormessage\",\"" + TT2Tag.GetScopeString(Policy.Errors[MsgIndex].ScopeType) + Policy.Errors[MsgIndex].Scope.ToString() + "\",\"1000\",\"" + Policy.Errors[MsgIndex].Text + "\"");

      for (MsgIndex = 0; MsgIndex < Policy.Warnings.Count; MsgIndex++)
        sw.WriteLine("\"warningmessage\",\"" + TT2Tag.GetScopeString(Policy.Warnings[MsgIndex].ScopeType) + Policy.Warnings[MsgIndex].Scope.ToString() + "\",\"1\",\"" + Policy.Warnings[MsgIndex].Text + "\"");

      for (MsgIndex = 0; MsgIndex < Policy.DiscountMessages.Count; MsgIndex++)
      {
        sw.WriteLine("\"discount\",\"" + TT2Tag.GetScopeString(Policy.DiscountMessages[MsgIndex].ScopeType) + Policy.DiscountMessages[MsgIndex].Scope.ToString() + "\",\"" + Policy.DiscountMessages[MsgIndex].Percentage.ToString() + "\",\"" + Policy.DiscountMessages[MsgIndex].WindowsCode.ToString() + "\"");
        sw.WriteLine("\"discountmessage\",\"" + TT2Tag.GetScopeString(Policy.DiscountMessages[MsgIndex].ScopeType) + Policy.DiscountMessages[MsgIndex].Scope.ToString() + "\",\"" + Policy.DiscountMessages[MsgIndex].WindowsCode.ToString() + "\",\"" + Policy.DiscountMessages[MsgIndex].Text + "\"");
      }

      for (MsgIndex = 0; MsgIndex < Policy.SurchargeMessages.Count; MsgIndex++)
      {
        sw.WriteLine("\"surcharge\",\"" + TT2Tag.GetScopeString(Policy.SurchargeMessages[MsgIndex].ScopeType) + Policy.SurchargeMessages[MsgIndex].Scope.ToString() + "\",\"" + Policy.SurchargeMessages[MsgIndex].Percentage.ToString() + "\",\"" + Policy.SurchargeMessages[MsgIndex].WindowsCode.ToString() + "\"");
        sw.WriteLine("\"surchargemessage\",\"" + TT2Tag.GetScopeString(Policy.SurchargeMessages[MsgIndex].ScopeType) + Policy.SurchargeMessages[MsgIndex].Scope.ToString() + "\",\"" + Policy.SurchargeMessages[MsgIndex].WindowsCode.ToString() + "\",\"" + Policy.SurchargeMessages[MsgIndex].Text + "\"");
      }
    }


    /// <summary>
    /// Exports the AUPolicy to TT2 info...this is the big method
    /// that does all the work of calling the little methods. If you want
    /// to export an entire policy and all the sub-objects under it,
    /// use this method
    /// </summary>
    /// <returns>The TT2 data representing the entire set of Policy TT2 data</returns>
    public override string ExportPolicyInfo()
    {
      string Result = "";
      StringWriter sw = new StringWriter();
      ExportPolicyToTT2Policy(ref sw);
      ExportPolicyCarsToTT2(ref sw);
      ExportPolicyDriversToTT2(ref sw, false);
      ExportPolicyDriversToTT2(ref sw, true);
      ExportPolicyDriverViolationsToTT2(ref sw);
      ExportPolicyDriverSuspensionsToTT2(ref sw);
      ExportPolicyMessagesToTT2(ref sw);
      ExportCompanyQuestionsToTT2Questions(ref sw);
      Result = sw.ToString();

      TT2AUBridge tempBridge = new TT2AUBridge();
      tempBridge.LoadTT2String(Result);
      int carCount = 0;
      int driverCount = 0;
      for (int index = 0; index < Policy.Cars.Count; index++)
      {
        if (!Policy.Cars[index].Ignored || this.IncludeIgnoredCars)
          carCount += 1;
      }
      for (int index = 0; index < Policy.Drivers.Count; index++)
      {
        if (!Policy.Drivers[index].Ignored || this.IncludeIgnoredDrivers)
          driverCount += 1;
      }
      TT2Tag carCountTag = tempBridge.FindMatchingTagsByName("numofcars")[0];
      carCountTag.Values[0] = carCount;
      TT2Tag driverCountTag = tempBridge.FindMatchingTagsByName("numofdrivers")[0];
      driverCountTag.Values[0] = driverCount;

      //TT2TagList primaryOperatorTags = tempBridge.FindMatchingTagsByName("primaryoperator");
      //foreach (TT2Tag operatorTag in primaryOperatorTags)
      //{
      //  int carNum = operatorTag.ScopeNum;
      //  if (carNum <= driverCount)
      //  {
      //    operatorTag.Values[0] = carNum;
      //    TT2Tag driverIDTag = tempBridge.FindMatchingTags("driverid", ItemScope.Driver, carNum)[0];
      //    TT2Tag primaryOperatorIDTag = tempBridge.FindMatchingTags("primaryoperatorid", ItemScope.Car, carNum)[0];
      //    primaryOperatorIDTag.Values[0] = driverIDTag.Values[0];
      //  }
      //  else
      //  {
      //    operatorTag.Values[0] = 1;
      //    TT2Tag driverIDTag = tempBridge.FindMatchingTags("driverid", ItemScope.Driver, carNum)[0];
      //    TT2Tag primaryOperatorIDTag = tempBridge.FindMatchingTags("primaryoperatorid", ItemScope.Car, carNum)[0];
      //    primaryOperatorIDTag.Values[0] = driverIDTag.Values[0];
      //  }

      //}

      Result = tempBridge.Tags.ToString();

      return Result;
    }

    /// <summary>
    /// Exports comparison data for a policy unit (driver, car, etc).
    /// </summary>
    /// <typeparam name="TUnit">The ComparisonUnit type to export.</typeparam>
    /// <param name="comparisonUnits">The list containing the comparison units to export.</param>
    /// <param name="scopeIndex">The index of the current comparison item.</param>
    /// <param name="sw">The string writer currently containing the tt2 data.</param>
    protected virtual void ExportComparisonUnitData<TUnit>(List<TUnit> comparisonUnits, StringWriter sw, int scopeIndex) where TUnit : ComparisonUnit
    {
      PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(typeof(TUnit));

      int compareIndex = 0;
      foreach (TUnit compairsonUnit in comparisonUnits)
      {
        foreach (PropertyDescriptor pdescriptor in pdescriptors)
          if (!IsTagExcludedFromExport(pdescriptor.Name))
            CreateTagLineFromProperty(compairsonUnit, pdescriptor, ref sw, "com" + (scopeIndex + 1).ToString() + ":" + TT2Tag.GetScopeString(compairsonUnit.UnitScope) + (compareIndex + 1).ToString());
        compareIndex++;
      }
    }

    /// <summary>
    /// Exports the tags for a list of comparison objects
    /// </summary>
    /// <param name="compareData">the list of CompareData objects to export</param>
    public override string ExportCompareData(List<CompareData> compareData)
    {
      string baseCompareData = base.ExportCompareData(compareData);
      StringWriter sw = new StringWriter();
      if (compareData.Count > 0)
      {
        int compareIndex = 0;
        foreach (CompareData compare in compareData)
        {
          // export cars
          ExportComparisonUnitData(compare.ComparisonCars, sw, compareIndex);
          // export drivers
          ExportComparisonUnitData(compare.ComparisonDrivers, sw, compareIndex);

          compareIndex++;
        }
      }
      sw.Flush();
      return baseCompareData + sw.ToString();
    }

    /// <summary>
    /// Imports comparison units (cars, drivers, etc) into a comparison object.
    /// </summary>
    /// <typeparam name="TUnit">The type of unit it import.</typeparam>
    /// <param name="comparisonUnits">The list of comparison units to import.</param>
    /// <param name="comparisonIndex">The index of the current comparison item.</param>
    protected virtual void ImportComparisonUnitData<TUnit>(List<TUnit> comparisonUnits, int comparisonIndex) where TUnit : ComparisonUnit, new()
    {
      TT2TagList compareUnitTags = FindMatchingTagsByPrimaryAndSecondaryScope(ItemScope.Comparison, comparisonIndex + 1, new TUnit().UnitScope, -1);
      int numCompareUnitItems = 0;
      foreach (TT2Tag tag in compareUnitTags.Items)
        numCompareUnitItems = Math.Max(numCompareUnitItems, tag.SecondaryScopeNum);

      for (int itemIndex = 0; itemIndex < numCompareUnitItems; itemIndex++)
      {
        compareUnitTags.Clear();
        TUnit item = new TUnit();
        comparisonUnits.Add(item);
        Type t = item.GetType();
        PropertyDescriptorCollection pdescriptors = TypeDescriptor.GetProperties(t);
        compareUnitTags = FindMatchingTagsByPrimaryAndSecondaryScope(ItemScope.Comparison, comparisonIndex + 1, item.UnitScope, itemIndex + 1);
        foreach (PropertyDescriptor pdescriptor in pdescriptors)
        {
          TT2Tag ThisTag;
          if (pdescriptor.Name.ToUpper() == "RECORDID") //make sure we get the web's recordid, otherwise everything becomes a new record!!
            ThisTag = compareUnitTags["WEBRECORDID"];
          else
            ThisTag = compareUnitTags[pdescriptor.Name]; //default; pick up the tag w/same name as property

          if ((ThisTag != null) && (!pdescriptor.IsReadOnly))
          {
            if ((pdescriptor.PropertyType == typeof(double)) && (ThisTag.Values[0].ToString() == IncludedPremiumString))
              pdescriptor.SetValue(item, InsConstants.IncludedPremium);
            else
              SetObjectPropertyValueFromTag(item, pdescriptor, ThisTag);
          }
        }
      }
    }

    /// <summary>
    /// Import the comparison cars too!!
    /// </summary>
    /// <returns>List of comparedata objects</returns>
    public override List<CompareData> ImportCompareData()
    {
      List<CompareData> result = base.ImportCompareData();
      int compareIndex = 0;
      foreach (CompareData compare in result)
      {
        ImportComparisonUnitData(compare.ComparisonCars, compareIndex);
        ImportComparisonUnitData(compare.ComparisonDrivers, compareIndex);
        compareIndex++;
      }
      return result;
    }

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="tt2">TT2 data to be imported. 
    /// Leave blank if you don't want to immediately import TT2 data into the
    /// policy.</param>
    /// <param name="policy">The AUPolicy object that this bridge object
    /// will work with</param>
    public TT2AUBridge(string tt2, AUPolicy policy)
    {
      TT2String = tt2;
      Policy = policy;
      LoadTT2String(TT2String);
    }

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="tt2">TT2 data to be imported. 
    /// Leave null if you don't want to immediately import TT2 data into the
    /// policy.</param>
    /// <param name="policy">The AUPolicy object that this bridge object
    /// will work with</param>
    public TT2AUBridge(List<string> tt2, AUPolicy policy)
    {
      if (tt2 != null)
        TT2Lines.AddRange(tt2);
      Policy = policy;
      LoadTT2Lines(TT2Lines);
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public TT2AUBridge()
    {
    }

  }
}
