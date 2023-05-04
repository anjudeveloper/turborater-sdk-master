using System;
using System.Reflection;
using System.Xml.Serialization;

namespace TurboRater.Insurance
{
  /// <summary>
  /// Policy initialization delegate type. Clients of this class can pass one of these
  /// delegate methods into the policy constructor to process custom initialization for the 
  /// class. See the constructors for more info.
  /// </summary>
  public delegate void PolicyInitializeCallback();


  /// <summary>
  /// Base policy class
  /// </summary>
  [Serializable]
  public class InsPolicy : BaseStoredRecord
  {

    /// <summary>
    /// Default constructor
    /// </summary>
    public InsPolicy()
    {
      InitializePolicy();
    }

    /// <summary>
    /// constructor. Allows you to pass in an initalization delegate.
    /// </summary>
    /// <param name="initializeMethod">An initialization delegate that gets
    /// called at the end of the constructor.</param>
    public InsPolicy(PolicyInitializeCallback initializeMethod)
    {
      InitializePolicy();
      if (initializeMethod != null)
        initializeMethod();
    }

    /// <summary>
    /// Initializes the sub-objects within the policy object
    /// </summary>
    public virtual void InitializePolicy()
    {
      MailingAddress = new Residence(TypeOfResidence.MailingAddress);
      Warnings = new MessageList(this);
      Errors = new MessageList(this);
      DiscountMessages = new MessageList(this);
      SurchargeMessages = new MessageList(this);
      SecondaryWarnings = new MessageList(this);
      SecondaryDiscountMessages = new MessageList(this);
      SecondarySurchargeMessages = new MessageList(this);
      CoSurchargeFees = new MessageList(this);
      m_quote = new InsQuote();
      m_quote.ParentPolicy = this;
      m_companyQuestions = new CompanyQuestionList();
      m_miscPremiums = new MiscPremiumList(this);
    }

    /// <summary>
    /// Calculates the total amount of all fees on the policy
    /// </summary>
    /// <returns>The total amount of all fees on the policy</returns>
    public virtual double CalculateFees()
    {
      double ratedPolicyFee = ((this.HasSecondaryData) && (this.UseSecondaryData)) ? this.SecondaryPolicyFee : this.PolicyFee;
      return (ratedPolicyFee + this.StatutoryAssessmentFee + this.FHCFEmergencyAssessmentSurcharge + this.ProgramRebate);
    }

    /// <summary>
    /// Calculates the total premiums for all misc premiums on the policy.
    /// will not take into account any taxes if they exist on the policy
    /// </summary>
    /// <returns>The total premium for all misc premiums on the policy</returns>
    public virtual double CalculateMiscPremiumAmount()
    {
      return CalculateMiscPremiumAmount(true);
    }

    /// <summary>
    /// Calculates the total premiums for all misc premiums on the policy.
    /// will not take into account any taxes if they exist on the policy
    /// </summary>
    /// <param name="includeAppliedToDown">If true, calculates the amount normally; if false, it excludes premiums applied to down.</param>
    /// <returns>The total premium for all misc premiums on the policy</returns>
    public virtual double CalculateMiscPremiumAmount(bool includeAppliedToDown)
    {
      double tempResult = 0.0;
      double tempPremium = 0.0;

      if (this.Errors.Count == 0)
      {
        if (this.ExclusionCode == (int)ExclusionCodes.PAPDRestricted)
        {
          for (int count = 0; count < this.NumOfMiscPremiums; count++)
            //percent premium
            if (this.MiscPremiums[count].PercentOfTotal && (includeAppliedToDown || !this.MiscPremiums[count].ApplyToDownPayment))
            {
              tempPremium = ((this.MiscPremiums[count].PercentOfTotalAmount / 100) * (this.TotalPremium - this.CalculateFees()));
              if (this.MiscPremiums[count].Amount > tempPremium)
                this.MiscPremiums[count].PremiumAmount = this.MiscPremiums[count].Amount;
              else
                this.MiscPremiums[count].PremiumAmount = tempPremium;
              tempResult += this.MiscPremiums[count].PremiumAmount;
            }
        }
        else
        {
          for (int count = 0; count < this.NumOfMiscPremiums; count++)
          {
            if (includeAppliedToDown || !this.MiscPremiums[count].ApplyToDownPayment)
            {
              //policy premium
              if (this.MiscPremiums[count].ApplyToPolicy)
                tempResult += this.MiscPremiums[count].Amount;
              //driver premium
              if (this.MiscPremiums[count].ApplyToDriver)
                tempResult += this.MiscPremiums[count].PremiumAmount;
              //vehicle premium
              if (this.MiscPremiums[count].ApplyToVehicle)
                tempResult += this.MiscPremiums[count].PremiumAmount;
            }
          }
          for (int count = 0; count < this.NumOfMiscPremiums; count++)
          {
            if (includeAppliedToDown || !this.MiscPremiums[count].ApplyToDownPayment)
            {
              //percent premium
              if (this.MiscPremiums[count].PercentOfTotal)
              {
                tempPremium = ((this.MiscPremiums[count].PercentOfTotalAmount / 100) * (this.TotalPremium - this.CalculateFees() - tempResult));
                if (this.MiscPremiums[count].Amount > tempPremium)
                  this.MiscPremiums[count].PremiumAmount = this.MiscPremiums[count].Amount;
                else
                  this.MiscPremiums[count].PremiumAmount = tempPremium;
                tempResult += this.MiscPremiums[count].PremiumAmount;
              }
              //let's process old misc premiums as well...
              if ((!this.MiscPremiums[count].ApplyToPolicy) &&
                (!this.MiscPremiums[count].ApplyToDriver) &&
                (!this.MiscPremiums[count].ApplyToVehicle) &&
                (!this.MiscPremiums[count].PercentOfTotal))
                tempResult += this.MiscPremiums[count].Amount;
            }
          }
        }
      }
      return tempResult;
    }

    /// <summary>
    /// Finds any property of type double that ends with "PREMIUM", and sets
    /// it to 0.0.
    /// </summary>
    public virtual void ZeroPremiums()
    {
      Type t = this.GetType();
      PropertyInfo[] pinfos = t.GetProperties();
      foreach (PropertyInfo pinfo in pinfos)
      {
        if ((pinfo.PropertyType == typeof(double)) && (pinfo.Name.ToUpper().EndsWith("PREMIUM", StringComparison.OrdinalIgnoreCase)))
          pinfo.SetValue(this, 0.0, null);
        if ((pinfo.PropertyType == typeof(double)) && (pinfo.Name.ToUpper().EndsWith("FEE", StringComparison.OrdinalIgnoreCase)))
          pinfo.SetValue(this, 0.0, null);
      }
    }

    /// <summary>
    /// foreign key link to the insured
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int, ForeignKeyClassType = typeof(Person))]
    public virtual int InsuredLinkID
    {
      get { return m_insuredLinkID; }
      set { m_insuredLinkID = value; }
    }

    /// <summary>
    /// Link to the user that saved the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int UserLinkID
    {
      get { return m_userLinkID; }
      set { m_userLinkID = value; }
    }

    /// <summary>
    /// I don't believe this is actually used...
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int GroupLinkID
    {
      get { return m_groupLinkID; }
      set { m_groupLinkID = value; }
    }

    /// <summary>
    /// Policy term. No unit of time measurement is implied, that is a separate property.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int Term
    {
      get { return m_term; }
      set { m_term = value; }
    }

    /// <summary>
    /// Company-specific policy term. No unit of time measurement is implied, that is a separate property.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CoTerm
    {
      get { return m_coTerm; }
      set { m_coTerm = value; }
    }

    /// <summary>
    /// The unit of time measurement applied to the term. Months, Years, etc.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25, EnumerationType = typeof(Duration))]
    public virtual Duration TermDuration
    {
      get { return m_termDuration; }
      set { m_termDuration = value; }
    }

    /// <summary>
    /// Company-specific unit of time measurement applied to the term. Months, Years, etc.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25, EnumerationType = typeof(Duration))]
    public virtual Duration CoTermDuration
    {
      get { return m_coTermDuration; }
      set { m_coTermDuration = value; }
    }

    /// <summary>
    /// Remarks about the policy, as entered by an agent.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1024)]
    public virtual string Remarks
    {
      get { return m_remarks; }
      set { m_remarks = value; }
    }

    /// <summary>
    /// Effective date of the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime EffectiveDate
    {
      get { return m_effectiveDate; }
      set { m_effectiveDate = value; }
    }

    /// <summary>
    /// Binder effective date of the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime BinderEffectiveDate
    {
      get { return m_binderEffectiveDate; }
      set { m_binderEffectiveDate = value; }
    }

    /// <summary>
    /// Binder expiration date of the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime BinderExpirationDate
    {
      get { return m_binderExpirationDate; }
      set { m_binderExpirationDate = value; }
    }

    /// <summary>
    /// Policy fee applied to the policy during rating
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double PolicyFee
    {
      get
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          return m_secondaryPolicyFee;
        else
          return m_policyFee;
      }
      set
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          m_secondaryPolicyFee = value;
        else
          m_policyFee = value;
      }
    }

    /// <summary>
    /// agent's commission %age on the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double CommissionPercent
    {
      get { return m_commissionPercent; }
      set { m_commissionPercent = value; }
    }

    /// <summary>
    /// The amount of commission the agent earned for this policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double CommissionPremium
    {
      get { return m_commissionPremium; }
      set { m_commissionPremium = value; }
    }

    /// <summary>
    /// Total premium applied to the policy during rating
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double TotalPremium
    {
      get { return m_totalPremium; }
      set { m_totalPremium = value; }
    }

    /// <summary>
    /// Credit score of the named insured
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string CreditScore
    {
      get
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          return m_secondaryCreditScore;
        else
          return m_creditScore;
      }
      set
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          m_secondaryCreditScore = value;
        else
          m_creditScore = value;
      }
    }

    /// <summary>
    /// Exclusion code for the policy. Used internally for split coverage situations
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ExclusionCode
    {
      get { return m_exclusionCode; }
      set { m_exclusionCode = value; }
    }

    /// <summary>
    /// Company-specific Credit score of the named insured
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string CoCreditScore
    {
      get
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          return m_secondaryCoCreditScore;
        else
          return m_coCreditScore;
      }
      set
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          m_secondaryCoCreditScore = value;
        else
          m_coCreditScore = value;
      }
    }

    /// <summary>
    /// Company-specific Credit score of the named insured, as bridged in
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string CoBridgedCreditScore
    {
      get { return m_coBridgedCreditScore; }
      set { m_coBridgedCreditScore = value; }
    }

    /// <summary>
    /// Variable for storing the UDD Status
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25)]
    public virtual string UDDStatus
    {
      get { return m_uDDStatus; }
      set { m_uDDStatus = value; }
    }

    /// <summary>
    /// Variable for storing the Company-specific UDD Status
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25)]
    public virtual string CoUDDStatus
    {
      get { return m_coUDDStatus; }
      set { m_coUDDStatus = value; }
    }

    /// <summary>
    /// Variable for storing the HOV Status
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25)]
    public virtual string HOVStatus
    {
      get { return m_hOVStatus; }
      set { m_hOVStatus = value; }
    }

    /// <summary>
    /// Variable for storing the company-specific HOV Status
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25)]
    public virtual string CoHOVStatus
    {
      get { return m_coHOVStatus; }
      set { m_coHOVStatus = value; }
    }

    /// <summary>
    /// Credit score verification number of the named insured
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string CreditVerification
    {
      get
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          return m_secondaryCreditVerification;
        else
          return m_creditVerification;
      }
      set
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          m_secondaryCreditVerification = value;
        else
          m_creditVerification = value;
      }
    }

    /// <summary>
    /// Credit score verification number of the named insured, as bridged in (company-specific)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string CoBridgedCreditVerification
    {
      get { return m_coBridgedCreditVerification; }
      set { m_coBridgedCreditVerification = value; }
    }

    /// <summary>
    /// Company-specific credit score verification number of the named insured
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string CoCreditVerification
    {
      get
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          return m_secondaryCoCreditVerification;
        else
          return m_coCreditVerification;
      }
      set
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          m_secondaryCoCreditVerification = value;
        else
          m_coCreditVerification = value;
      }
    }

    /// <summary>
    /// Date/time the credit score was last ordered
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime CreditScoreDateTime
    {
      get { return m_creditScoreDateTime; }
      set { m_creditScoreDateTime = value; }
    }

    /// <summary>
    /// ITC transaction ID of the credit score
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CreditScoreTransactionID
    {
      get { return m_creditScoreTransactionID; }
      set { m_creditScoreTransactionID = value; }
    }

    /// <summary>
    /// Date/time the credit score was last ordered
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime InsuranceScoreEntryDoneDate
    {
      get { return m_insuranceScoreEntryDoneDate; }
      set { m_insuranceScoreEntryDoneDate = value; }
    }

    /// <summary>
    /// The tier applied to the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 15)]
    public virtual string Tier
    {
      get { return m_tier; }
      set { m_tier = value; }
    }

    /// <summary>
    /// The Date/time the policy was created on the server
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime DateCreated
    {
      get { return m_dateCreated; }
      set { m_dateCreated = value; }
    }

    /// <summary>
    /// Prior insurance carrier name
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string PriorCarrierName
    {
      get { return m_priorCarrierName; }
      set { m_priorCarrierName = value; }
    }

    /// <summary>
    /// Prior insurance policy effective date
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime PriorEffDate
    {
      get { return m_priorEffDate; }
      set { m_priorEffDate = value; }
    }

    /// <summary>
    /// Effective time of the prior insurance policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime PriorEffTime
    {
      get { return m_priorEffTime; }
      set { m_priorEffTime = value; }
    }

    /// <summary>
    /// Expiration date of the prior insurance policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime PriorExpDate
    {
      get { return m_priorExpDate; }
      set { m_priorExpDate = value; }
    }

    /// <summary>
    /// Expiration time of the prior insurance policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime PriorExpTime
    {
      get { return m_priorExpTime; }
      set { m_priorExpTime = value; }
    }

    /// <summary>
    /// Was the prior insurance policy in the same agency?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool PriorInAgency
    {
      get { return m_priorInAgency; }
      set { m_priorInAgency = value; }
    }

    /// <summary>
    /// Will this policy allow changes in pay plans?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool AllowPayPlanChange
    {
      get { return m_allowPayPlanChange; }
      set { m_allowPayPlanChange = value; }
    }

    /// <summary>
    /// Annual Percentage Rate for the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double APR
    {
      get { return m_aPR; }
      set { m_aPR = value; }
    }

    /// <summary>
    /// Policy number of the prior insurance policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string PriorPolicyNumber
    {
      get { return m_priorPolicyNumber; }
      set { m_priorPolicyNumber = value; }
    }

    /// <summary>
    /// the number of payments in the pay plan selected
    /// for this policy.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int NumOfPayments
    {
      get { return m_numOfPayments; }
      set { m_numOfPayments = value; }
    }

    /// <summary>
    /// If the user overrode the number of payments, this is that amount
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int NumOfPaymentsOverride
    {
      get { return m_numOfPaymentsOverride; }
      set { m_numOfPaymentsOverride = value; }
    }

    /// <summary>
    /// The # of misc premiums stored with this policy
    /// </summary>
    public virtual int NumOfMiscPremiums
    {
      get { return MiscPremiums.Count; }
    }

    /// <summary>
    /// the down payment percent in the pay plan selected
    /// for this policy.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double PercentDown
    {
      get { return m_percentDown; }
      set { m_percentDown = value; }
    }

    /// <summary>
    /// The amount per payment for the selected pay plan. 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double PaymentAmount1
    {
      get { return m_paymentAmount; }
      set { m_paymentAmount = value; }
    }

    /// <summary>
    /// the payment plan description for the pay plan selected
    /// for this policy.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string PayPlanDescription
    {
      get { return m_payPlanDescription; }
      set { m_payPlanDescription = value; }
    }

    /// <summary>
    /// The company-specific tier string the policy is assigned to
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string CoTierStr
    {
      get
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          return m_secondaryCoTierStr;
        else
          return m_coTierStr;
      }
      set
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          m_secondaryCoTierStr = value;
        else
          m_coTierStr = value;
      }
    }

    /// <summary>
    /// True if the insured has declined to have credit ordered on themselves,
    /// otherwise false. Defaults to false under the assumption that credit
    /// will be ordered for the policy. Note that this is only set to true
    /// if the agent sees the FCRA and declines to order credit based on feedback
    /// from the insured.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool InsuredDeclinedCredit
    {
      get { return m_insuredDeclinedCredit; }
      set { m_insuredDeclinedCredit = value; }
    }

    /// <summary>
    /// Is this a bi-monthly policy?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool BiMonthly
    {
      get { return m_biMonthly; }
      set { m_biMonthly = value; }
    }

    /// <summary>
    /// Was this policy object created by the universal upload utility?
    /// Note that this variable is just a throwback from the Windows storage,
    /// we don't use it for anything here on the web.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool CreatedByUniversalUpload
    {
      get { return m_createdByUniversalUpload; }
      set { m_createdByUniversalUpload = value; }
    }

    /// <summary>
    /// The serverID from which the credit score was ordered.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 3)]
    public virtual string CreditScoreServerID
    {
      get { return m_creditScoreServerID; }
      set { m_creditScoreServerID = value; }
    }

    /// <summary>
    /// The down payment amount that the company would like the insured to
    /// make on the policy, based on the defaults set in the pay plan.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double DownPayment
    {
      get { return m_downPayment; }
      set { m_downPayment = value; }
    }

    /// <summary>
    /// If the user overrode the down payment, this is that amount
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double DownPaymentOverride
    {
      get { return m_downPaymentOverride; }
      set { m_downPaymentOverride = value; }
    }

    /// <summary>
    /// The original premium, by term, of any policy endorsement currently
    /// being used.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double EndorsementOriginalTermPremium
    {
      get { return m_endorsementOriginalTermPremium; }
      set { m_endorsementOriginalTermPremium = value; }
    }

    /// <summary>
    /// The HomeOwners Verification report order number
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 30)]
    public virtual string HOVOrderNum
    {
      get { return m_hOVOrderNum; }
      set { m_hOVOrderNum = value; }
    }

    /// <summary>
    /// The HomeOwners Verification report reference number
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 30)]
    public virtual string HOVRefNum
    {
      get { return m_hOVRefNum; }
      set { m_hOVRefNum = value; }
    }

    /// <summary>
    /// The CompanyID of the interface, or something
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int InterfaceCompanyID
    {
      get { return m_interfaceCompanyID; }
      set { m_interfaceCompanyID = value; }
    }

    /// <summary>
    /// Is this policy financed on a monthly basis (monthly payments)?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool MonthlyFinanced
    {
      get { return m_monthlyFinanced; }
      set { m_monthlyFinanced = value; }
    }

    /// <summary>
    /// The total amount of all payments for the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double PaymentTotal
    {
      get { return m_paymentTotal; }
      set { m_paymentTotal = value; }
    }

    /// <summary>
    /// Is this the insured's primary auto policy?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool PrimaryPolicy
    {
      get { return m_primaryPolicy; }
      set { m_primaryPolicy = value; }
    }

    /// <summary>
    /// Address part 1 of the prior insurance carrier
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.SmallAddressLength)]
    public virtual string PriorCarrierAddress1
    {
      get { return m_priorCarrierAddress1; }
      set { m_priorCarrierAddress1 = value; }
    }

    /// <summary>
    /// Address part 2 of the prior insurance carrier
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.SmallAddressLength)]
    public virtual string PriorCarrierAddress2
    {
      get { return m_priorCarrierAddress2; }
      set { m_priorCarrierAddress2 = value; }
    }

    /// <summary>
    /// City of the prior insurance carrier
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.CityLength)]
    public virtual string PriorCarrierCity
    {
      get { return m_priorCarrierCity; }
      set { m_priorCarrierCity = value; }
    }

    /// <summary>
    /// Insured's policy# with the prior carrier
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string PriorCarrierPolicyNumberString
    {
      get { return m_priorCarrierPolicyNumberString; }
      set { m_priorCarrierPolicyNumberString = value; }
    }

    /// <summary>
    /// The state of the insured's prior insurance carrier
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 50, EnumerationType = typeof(USState))]
    public virtual USState PriorCarrierState
    {
      get { return m_priorCarrierState; }
      set { m_priorCarrierState = value; }
    }

    /// <summary>
    /// The zip code of the insured's prior insurance carrier
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.ZipCodeLength)]
    public virtual string PriorCarrierZipCode
    {
      get { return m_priorCarrierZipCode; }
      set { m_priorCarrierZipCode = value; }
    }

    /// <summary>
    /// Real-Time Rating, company transaction ID as assigned by ITC
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 200)]
    public virtual string RTRITCCompanyTransactionID
    {
      get { return m_rTRITCCompanyTransactionID; }
      set { m_rTRITCCompanyTransactionID = value; }
    }

    /// <summary>
    /// Real-Time Rating, group transaction ID as assigned by ITC
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 200)]
    public virtual string RTRITCGroupTransactionID
    {
      get { return m_rTRITCGroupTransactionID; }
      set { m_rTRITCGroupTransactionID = value; }
    }

    /// <summary>
    /// Real-Time Rating, the quote URL as sent back from the company
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 300)]
    public virtual string RTRThirdPartyQuoteURL
    {
      get { return m_rTRThirdPartyQuoteURL; }
      set { m_rTRThirdPartyQuoteURL = value; }
    }

    /// <summary>
    /// Real-Time Rating, the transactionID sent back from the company
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 200)]
    public virtual string RTRThirdPartyTransactionID
    {
      get { return m_rTRThirdPartyTransactionID; }
      set { m_rTRThirdPartyTransactionID = value; }
    }

    /// <summary>
    /// Secondary-Company-specific Credit score of the named insured
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string SecondaryCoCreditScore
    {
      get { return m_secondaryCoCreditScore; }
      set { m_secondaryCoCreditScore = value; }
    }

    /// <summary>
    /// Secondary company-specific credit score verification number of the named insured
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string SecondaryCoCreditVerification
    {
      get { return m_secondaryCoCreditVerification; }
      set { m_secondaryCoCreditVerification = value; }
    }

    /// <summary>
    /// Secondary credit score of the named insured
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string SecondaryCreditScore
    {
      get { return m_secondaryCreditScore; }
      set { m_secondaryCreditScore = value; }
    }

    /// <summary>
    /// Secondary credit score verification number of the named insured
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string SecondaryCreditVerification
    {
      get { return m_secondaryCreditVerification; }
      set { m_secondaryCreditVerification = value; }
    }

    /// <summary>
    /// Secondary policy fee amount
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double SecondaryPolicyFee
    {
      get { return m_secondaryPolicyFee; }
      set { m_secondaryPolicyFee = value; }
    }

    /// <summary>
    /// The amount of taxable premium on the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double TaxablePremium
    {
      get { return m_taxablePremium; }
      set { m_taxablePremium = value; }
    }

    /// <summary>
    /// the date that UDD was ordered for the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime UDDTransactionDate
    {
      get { return m_uDDTransactionDate; }
      set { m_uDDTransactionDate = value; }
    }

    /// <summary>
    /// the undisclosed driver transaction ID
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string UDDTransactionID
    {
      get { return m_uDDTransactionID; }
      set { m_uDDTransactionID = value; }
    }

    /// <summary>
    /// A blob field containing a bunch of real-time rating data
    /// for the policy such as transaction#'s, dates, etc.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Text)]
    public virtual string RealTimeRatingData
    {
      get { return this.m_realTimeRatingData; }
      set { this.m_realTimeRatingData = value; }
    }

    /// <summary>
    /// A blob field containing the third party credit response
    /// data. Contains scores, tranny#'s, status fields, etc.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Text)]
    public virtual string ThirdPartyCreditResponseData
    {
      get
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          return this.m_secondaryThirdPartyCreditResponseData;
        else
          return this.m_thirdPartyCreditResponseData;
      }
      set
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          this.m_secondaryThirdPartyCreditResponseData = value;
        else
          this.m_thirdPartyCreditResponseData = value;
      }
    }

    /// <summary>
    /// A blob field containing notes that can be entered
    /// for undisclosed driver reports. As of 11/06, this field
    /// is only used by the defunct Unitrin Windows POS.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Text)]
    public virtual string UDRNotes
    {
      get { return this.m_uDRNotes; }
      set { this.m_uDRNotes = value; }
    }

    /// <summary>
    /// The amount being financed
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double FinanceAmount
    {
      get { return m_financeAmount; }
      set { m_financeAmount = value; }
    }

    /// <summary>
    /// The finance charge (extra money) charged on each payment of 
    /// the chosen payment plan.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double FinanceCharge
    {
      get { return m_financeCharge; }
      set { m_financeCharge = value; }
    }

    /// <summary>
    /// Any messages spit out by the finance, based on the chosen finance/pay plan
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string FinanceMessage
    {
      get { return m_financeMessage; }
      set { m_financeMessage = value; }
    }

    /// <summary>
    /// Does the policy qualify for the chosen financing plan?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool FinanceQualified
    {
      get { return m_financeQualified; }
      set { m_financeQualified = value; }
    }

    /// <summary>
    /// Does the require an FR-Bond thingie?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool FRBond
    {
      get { return m_fRBond; }
      set { m_fRBond = value; }
    }

    /// <summary>
    /// Is this policy locked?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Locked
    {
      get { return this.m_locked; }
      set { this.m_locked = value; }
    }

    /// <summary>
    /// Who last locked the quote? the GUID of the user 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string LockedBy
    {
      get { return this.m_lockedBy; }
      set { this.m_lockedBy = value; }
    }

    /// <summary>
    /// Who last locked the quote? the full name of the user 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 110)]
    public virtual string LockedByUserName
    {
      get { return this.m_lockedByUserName; }
      set { this.m_lockedByUserName = value; }
    }

    /// <summary>
    /// When was the quote last locked?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime LockedDateTime
    {
      get { return this.m_lockedDateTime; }
      set { this.m_lockedDateTime = value; }
    }

    /// <summary>
    /// Has this quote been marked for deletion?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Deleted
    {
      get { return this.m_deleted; }
      set { this.m_deleted = value; }
    }

    /// <summary>
    /// Who marked this quote for deletion?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string DeletedBy
    {
      get { return this.m_deletedBy; }
      set { this.m_deletedBy = value; }
    }

    /// <summary>
    /// When was this quote deleted?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime DeletedDateTime
    {
      get { return this.m_deletedDateTime; }
      set { this.m_deletedDateTime = value; }
    }

    /// <summary>
    /// Application data for the entire policy. Includes data for
    /// policy, cars, drivers, everything. Used to store app data
    /// in remote storage, the application information that came
    /// from the windows CMP client
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Image)]
    public virtual byte[] ApplicationBlob
    {
      get { return this.m_applicationBlob; }
      set { this.m_applicationBlob = value; }
    }

    /// <summary>
    /// This contains the insurance score information for the various
    /// carriers that have a credit score. This is the translated info
    /// that the itc raters use in rating.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Text)]
    public virtual string InsuranceScoreData
    {
      get { return m_insuranceScoreData; }
      set { m_insuranceScoreData = value; }
    }

    /// <summary>
    /// Which product created this policy? win cmp, web cmp, eturborater, etc
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, EnumerationType = typeof(SourceProduct), Size = 30)]
    public virtual SourceProduct SourceProduct
    {
      get { return m_sourceProduct; }
      set { m_sourceProduct = value; }
    }

    /// <summary>
    /// Mailing address of the insured for the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant)]
    public virtual Residence MailingAddress
    {
      get { return m_mailingAddress; }
      set { m_mailingAddress = value; }
    }

    /// <summary>
    /// The named insured for the policy
    /// </summary>
    public virtual Person Insured
    {
      get { return m_insured; }
      set { m_insured = value; }
    }

    /// <summary>
    /// Warnings applied to the policy during rating
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant, IsArrayList = true, ListItemType = typeof(Message))]
    public virtual MessageList Warnings
    {
      get
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          return m_secondaryWarnings;
        else
          return m_warnings;
      }
      set
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          m_secondaryWarnings = value;
        else
          m_warnings = value;
      }
    }

    /// <summary>
    /// Errors applied to the policy during rating
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant, IsArrayList = true, ListItemType = typeof(Message))]
    public virtual MessageList Errors
    {
      get { return m_errors; }
      set { m_errors = value; }
    }

    /// <summary>
    /// Discounts applied to the policy during rating. Includes all discounts 
    /// applied to the policy, regardless of scope.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant, IsArrayList = true, ListItemType = typeof(Message))]
    public virtual MessageList DiscountMessages
    {
      get
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          return m_secondaryDiscountMessages;
        else
          return m_discountMessages;
      }
      set
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          m_secondaryDiscountMessages = value;
        else
          m_discountMessages = value;
      }
    }

    /// <summary>
    /// Surcharges applied to the policy during rating. Includes all surcharges
    /// applied to the policy, regardless of scope.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant, IsArrayList = true, ListItemType = typeof(Message))]
    public virtual MessageList SurchargeMessages
    {
      get
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          return m_secondarySurchargeMessages;
        else
          return m_surchargeMessages;
      }
      set
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          m_secondarySurchargeMessages = value;
        else
          m_surchargeMessages = value;
      }
    }

    /// <summary>
    /// CoSurcharges applied to the policy during rating.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant, IsArrayList = true, ListItemType = typeof(Message))]
    public virtual MessageList CoSurchargeFees
    {
      get { return m_coSurchargeFees; }
      set { m_coSurchargeFees = value; }
    }


    /// <summary>
    /// Expiration date of the policy. This is a calculated read-only field based
    /// on the Effective date, term, and term duration.
    /// </summary>
    public virtual DateTime ExpirationDate
    {
      get { return GenericLib.AddDateDuration(EffectiveDate, TermDuration, Term); }
    }

    /// <summary>
    /// The quote object to keep track of individual quotes for a policy.
    /// Added to storage in 10/06
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant)]
    [XmlIgnore]
    public virtual InsQuote Quote
    {
      get { return m_quote; }
      set { m_quote = value; }
    }

    /// <summary>
    /// The company questions associated with the policy
    /// This is not stored yet! Peter says so.
    /// </summary>
    public virtual CompanyQuestionList CompanyQuestions
    {
      get { return m_companyQuestions; }
      set { m_companyQuestions = value; }
    }

    /// <summary>
    /// The miscellaneous premiums associated with the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant, IsArrayList = true, ListItemType = typeof(MiscPremium))]
    public virtual MiscPremiumList MiscPremiums
    {
      get
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          return new MiscPremiumList(this);
        else
          return m_miscPremiums;
      }
      set { m_miscPremiums = value; }
    }

    /// <summary>
    /// the market basket item identifier for this policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.BigInt)]
    public virtual long MarketBasketItemID
    {
      get { return m_marketBasketItemID; }
      set { m_marketBasketItemID = value; }
    }

    /// <summary>
    /// Indicates that this policy used outside financing instead of company pay plans
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool IndependentlyFinanced
    {
      get { return m_independentlyFinanced; }
      set { m_independentlyFinanced = value; }
    }

    /// <summary>
    /// a unique identifier for the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.UniqueIdentifier)]
    public virtual Guid PolicyUID
    {
      get { return m_policyUID; }
      set { m_policyUID = value; }
    }

    /// <summary>
    /// The caesar guid for the policy (client-side-rating mechanism). Note that
    /// most policies won't have one; only policies rated through caesar.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.UniqueIdentifier)]
    public virtual Guid CaesarId
    {
      get { return m_caesarId; }
      set { m_caesarId = value; }
    }

    /// <summary>
    /// Name of the import file, used with Applied AMS to determine if a file was imported before exporting.
    /// This file does not need to be stored as it was never a stored field in the Windows comparative.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1024)]
    public virtual string ImportFileName
    {
      get { return m_ImportFileName; }
      set { m_ImportFileName = value; }
    }

    /// <summary>
    /// The company-specific tier string the policy is assigned to
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string SecondaryCoTierStr
    {
      get { return m_secondaryCoTierStr; }
      set { m_secondaryCoTierStr = value; }
    }

    /// <summary>
    /// A blob field containing the secondary company's third party credit
    /// response data. Contains scores, tranny#'s, status fields, etc.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Text)]
    public virtual string SecondaryThirdPartyCreditResponseData
    {
      get { return this.m_secondaryThirdPartyCreditResponseData; }
      set { this.m_secondaryThirdPartyCreditResponseData = value; }
    }

    /// <summary>
    /// Warnings applied to the policy during rating on secondary policy.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant, IsArrayList = true, ListItemType = typeof(Message))]
    public MessageList SecondaryWarnings
    {
      get { return m_secondaryWarnings; }
      set { m_secondaryWarnings = value; }
    }

    /// <summary>
    /// Discounts applied to the policy during rating on secondary policy. 
    /// Includes all discounts applied to the policy, regardless of scope.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant, IsArrayList = true, ListItemType = typeof(Message))]
    public MessageList SecondaryDiscountMessages
    {
      get { return m_secondaryDiscountMessages; }
      set { m_secondaryDiscountMessages = value; }
    }

    /// <summary>
    /// Surcharges applied to the policy during rating on secondary policy. 
    /// Includes all surcharges applied to the policy, regardless of scope.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant, IsArrayList = true, ListItemType = typeof(Message))]
    public MessageList SecondarySurchargeMessages
    {
      get { return m_secondarySurchargeMessages; }
      set { m_secondarySurchargeMessages = value; }
    }

    /// <summary>
    /// ID of the primary policy within Agency Buzz
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public int AgencyBuzzPolicyID
    {
      get
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          return m_secondaryAgencyBuzzPolicyID;
        else
          return m_agencyBuzzPolicyID;
      }
      set
      {
        if ((ExclusionCodes)this.ExclusionCode == ExclusionCodes.PAPDRestricted)
          m_secondaryAgencyBuzzPolicyID = value;
        else
          m_agencyBuzzPolicyID = value;
      }
    }

    /// <summary>
    /// ID of the secondary policy in Agency Buzz
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public int SecondaryAgencyBuzzPolicyID
    {
      get { return m_secondaryAgencyBuzzPolicyID; }
      set { m_secondaryAgencyBuzzPolicyID = value; }
    }

    /// <summary>
    /// Line of insurance for this policy.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25, EnumerationType = typeof(InsuranceLine))]
    public InsuranceLine LineOfInsurance
    {
      get { return m_lineOfInsurance; }
      set { m_lineOfInsurance = value; }
    }

    /// <summary>
    /// Real-Time Rating, whether the carrier ordered credit on their end or not.  Defaults to NoDataReceived.  
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 14, EnumerationType = typeof(RTRCreditOrderStatus))]
    public RTRCreditOrderStatus RTRThirdPartyCreditOrderStatus
    {
      get { return m_rTRThirdPartyCreditOrderStatus; }
      set { m_rTRThirdPartyCreditOrderStatus = value; }
    }

    /// <summary>
    /// assuming this policy was bridged in from a 3rd party system, this field should represent the name of
    /// said system. Field added late 2014 so it won't be very heavily populated for quite some time.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 100)]
    public string ThirdPartySystemName
    {
      get { return m_thirdPartySystemName; }
      set { m_thirdPartySystemName = value; }
    }

    /// <summary>
    /// assuming this policy was bridged in from a 3rd party system, this field should represent the id of
    /// the policy within said system. Field added late 2014 so it won't be very heavily populated for quite some time.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 100)]
    public string ThirdPartyId
    {
      get { return m_thirdPartyId; }
      set { m_thirdPartyId = value; }
    }

    /// <summary>
    /// Has the address been validated by Melissa Data
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public bool AddressValidated
    {
      get { return m_addressValidated; }
      set { m_addressValidated = value; }
    }

    /// <summary>
    /// Statutory assessment fee
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double StatutoryAssessmentFee
    {
      get { return m_statutoryAssessmentFee; }
      set { m_statutoryAssessmentFee = value; }
    }

    /// <summary>
    /// The optional Rate API Phone Code.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public string PhoneCode
    {
      get { return m_phoneCode; }
      set { m_phoneCode = value; }
    }

    /// <summary>
    /// The optiona Rate API Phone Code expiration.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public DateTime PhoneCodeExpiration
    {
      get { return m_phoneCodeExpiration; }
      set { m_phoneCodeExpiration = value; }
    }

    /// <summary>
    /// If a custom lead source is defined for this policy, it will override anything
    /// chosen by the user.  Used mainly for the Rate API for accounts with a custom lead source.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 255)]
    public string CustomLeadSource
    {
      get { return m_customLeadSource; }
      set { m_customLeadSource = value; }
    }

    /// <summary>
    /// Adds a warning to the list of policy warnings
    /// </summary>
    /// <param name="code">Standard message code that will determine the message text</param>
    public virtual void AddWarningMessage(StandardMessage code)
    {
      Warnings.Add(new Message(Warnings, TypeOfMessage.Warning, 0, ItemScope.Policy, 0.0, 0.0, code));
    }

    /// <summary>
    /// Adds a warning to the list of policy warnings
    /// </summary>
    /// <param name="text">Text of the warning message</param>
    public virtual void AddWarningMessage(string text)
    {
      Warnings.Add(new Message(Warnings, TypeOfMessage.Warning, text));
    }

    /// <summary>
    /// Adds a warning to the list of policy warnings
    /// </summary>
    /// <param name="code">Standard message code that will determine the message text</param>
    /// <param name="extraText">Extra text that gets tacked on at the end of the
    /// standard error message text</param>
    /// <param name="scopeNumber">The scope number for the new error</param>
    /// <param name="scope">The scope for the new error</param>
    public virtual void AddWarningMessage(StandardMessage code, string extraText, int scopeNumber, ItemScope scope)
    {
      Warnings.Add(new Message(Warnings, TypeOfMessage.Warning, extraText, scopeNumber, scope, 0.0, 0.0, code));
    }

    /// <summary>
    /// Adds a warning to the list of policy warnings
    /// </summary>
    /// <param name="text">Text of the warning message</param>
    /// <param name="scope">The scope of the warning (policy, car, driver, etc)</param>
    /// <param name="scopeNumber">The scope number of the warning</param>
    public virtual void AddWarningMessage(string text, int scopeNumber, ItemScope scope)
    {
      Warnings.Add(new Message(Warnings, TypeOfMessage.Warning, text, scopeNumber, scope, 0.0, 0.0, StandardMessage.NoStandardCode));
    }

    /// <summary>
    /// Adds an error to the list of policy errors
    /// </summary>
    /// <param name="code">Standard message code that will determine the message text</param>
    public virtual void AddErrorMessage(StandardMessage code)
    {
      Errors.Add(new Message(Errors, TypeOfMessage.Error, 0, ItemScope.Policy, 0.0, 0.0, code));
    }

    /// <summary>
    /// Adds an error to the list of policy errors
    /// </summary>
    /// <param name="code">Standard message code that will determine the message text</param>
    /// <param name="extraText">Extra text that gets tacked on at the end of the
    /// standard error message text</param>
    public virtual void AddErrorMessage(StandardMessage code, string extraText)
    {
      Errors.Add(new Message(Errors, TypeOfMessage.Error, extraText, 0, ItemScope.Policy, 0.0, 0.0, code));
    }

    /// <summary>
    /// Adds an error to the list of policy errors
    /// </summary>
    /// <param name="code">Standard message code that will determine the message text</param>
    /// <param name="extraText">Extra text that gets tacked on at the end of the
    /// standard error message text</param>
    /// <param name="scopeNumber">The scope number for the new error</param>
    /// <param name="scope">The scope for the new error</param>
    public virtual void AddErrorMessage(StandardMessage code, string extraText, int scopeNumber, ItemScope scope)
    {
      Errors.Add(new Message(Errors, TypeOfMessage.Error, extraText, scopeNumber, scope, 0.0, 0.0, code));
    }

    /// <summary>
    /// Adds an error to the list of policy errors
    /// </summary>
    /// <param name="text">Text of the error message</param>
    public virtual void AddErrorMessage(string text)
    {
      Errors.Add(new Message(Errors, TypeOfMessage.Error, text));
    }

    /// <summary>
    /// Adds an error to the list of policy errors
    /// </summary>
    /// <param name="code">Standard message code that will determine the message text</param>
    /// <param name="scope">The scope of the error (policy, car, driver, etc)</param>
    /// <param name="scopeNumber">The scope number of the error</param>
    public virtual void AddErrorMessage(StandardMessage code, int scopeNumber, ItemScope scope)
    {
      Errors.Add(new Message(Errors, TypeOfMessage.Error, scopeNumber, scope, 0.0, 0.0, code));
    }

    /// <summary>
    /// Adds an error to the list of policy errors
    /// </summary>
    /// <param name="text">Text of the error message</param>
    /// <param name="scope">The scope of the error (policy, car, driver, etc)</param>
    /// <param name="scopeNumber">The scope number of the error</param>
    public virtual void AddErrorMessage(string text, int scopeNumber, ItemScope scope)
    {
      Errors.Add(new Message(Errors, TypeOfMessage.Error, text, scopeNumber, scope, 0.0, 0.0, StandardMessage.NoStandardCode));
    }

    /// <summary>
    /// Adds a discount to the list of policy discount messages
    /// </summary>
    /// <param name="code">Standard message code that will determine the message text</param>
    /// <param name="scopeNumber">The scope number of the error</param>
    /// <param name="scope">The scope of the error (policy, car, driver, etc)</param>
    public virtual void AddDiscountMessage(StandardMessage code, int scopeNumber, ItemScope scope)
    {
      DiscountMessages.Add(new Message(DiscountMessages, TypeOfMessage.Discount, scopeNumber, scope, 0.0, 0.0, code));
    }

    /// <summary>
    /// Adds a discount to the list of policy discount messages
    /// </summary>
    /// <param name="code">Standard message code that will determine the message text</param>
    public virtual void AddDiscountMessage(StandardMessage code)
    {
      DiscountMessages.Add(new Message(DiscountMessages, TypeOfMessage.Discount, 0, ItemScope.Policy, 0.0, 0.0, code));
    }

    /// <summary>
    /// Adds a discount to the list of policy discount messages
    /// </summary>
    /// <param name="text">Text of the warning message</param>
    public virtual void AddDiscountMessage(string text)
    {
      DiscountMessages.Add(new Message(DiscountMessages, TypeOfMessage.Discount, text));
    }

    /// <summary>
    /// Adds a discount to the list of policy discount messages
    /// </summary>
    /// <param name="code">Standard message code that will determine the message text</param>
    /// <param name="percentage">the discount percentage applied</param>
    public virtual void AddDiscountMessage(StandardMessage code, double percentage)
    {
      DiscountMessages.Add(new Message(DiscountMessages, TypeOfMessage.Discount, 0, ItemScope.Policy, percentage, 0.0, code));
    }

    /// <summary>
    /// Adds a discount to the list of policy discount messages
    /// </summary>
    /// <param name="text">Text of the warning message</param>
    /// <param name="percentage">the discount percentage applied</param>
    public virtual void AddDiscountMessage(string text, double percentage)
    {
      DiscountMessages.Add(new Message(DiscountMessages, TypeOfMessage.Discount, text, 0,
        ItemScope.Policy, percentage, 0.0, StandardMessage.NoStandardCode));
    }

    /// <summary>
    /// Adds a discount to the list of policy discount messages
    /// </summary>
    /// <param name="code">Standard message code that will determine the message text</param>
    /// <param name="percentage">the discount percentage applied</param>
    /// <param name="amount">the discount amount applied</param>
    public virtual void AddDiscountMessage(StandardMessage code, double percentage, double amount)
    {
      DiscountMessages.Add(new Message(DiscountMessages, TypeOfMessage.Discount, 0, ItemScope.Policy, percentage, amount, code));
    }

    /// <summary>
    /// Adds a discount to the list of policy discount messages
    /// </summary>
    /// <param name="code">Standard message code that will determine the message text</param>
    /// <param name="percentage">the discount percentage applied</param>
    /// <param name="amount">the discount amount applied</param>
    /// <param name="extraText">Extra text to tack on at the end of the standard message text</param>
    public virtual void AddDiscountMessage(StandardMessage code, double percentage, double amount, string extraText)
    {
      Message tempMsg = new Message(DiscountMessages, TypeOfMessage.Discount, 0, ItemScope.Policy, percentage, amount, code);
      tempMsg.Text += extraText;
      DiscountMessages.Add(tempMsg);
    }

    /// <summary>
    /// Adds a discount to the list of policy discount messages
    /// </summary>
    /// <param name="text">Text of the warning message</param>
    /// <param name="percentage">the discount percentage applied</param>
    /// <param name="amount">the discount amount applied</param>
    public virtual void AddDiscountMessage(string text, double percentage, double amount)
    {
      DiscountMessages.Add(new Message(DiscountMessages, TypeOfMessage.Discount, text, 0,
        ItemScope.Policy, percentage, amount, StandardMessage.NoStandardCode));
    }

    //----------- BOB
    /// <summary>
    /// Adds a surcharge to the list of policy surcharge messages
    /// </summary>
    /// <param name="code">Standard message code that will determine the message text</param>
    public virtual void AddSurchargeMessage(StandardMessage code)
    {
      SurchargeMessages.Add(new Message(SurchargeMessages, TypeOfMessage.Surcharge, 0, ItemScope.Policy, 0.0, 0.0, code));
    }

    /// <summary>
    /// Adds a surcharge to the list of policy surcharge messages
    /// </summary>
    /// <param name="text">Text of the surcharge message</param>
    public virtual void AddSurchargeMessage(string text)
    {
      SurchargeMessages.Add(new Message(SurchargeMessages, TypeOfMessage.Surcharge, text));
    }

    /// <summary>
    /// Adds a surcharge to the list of policy surcharge messages
    /// </summary>
    /// <param name="code">Standard message code that will determine the message text</param>
    /// <param name="percentage">the surcharge percentage applied</param>
    public virtual void AddSurchargeMessage(StandardMessage code, double percentage)
    {
      SurchargeMessages.Add(new Message(SurchargeMessages, TypeOfMessage.Surcharge, 0, ItemScope.Policy, percentage, 0.0, code));
    }

    /// <summary>
    /// Adds a surcharge to the list of policy surcharge messages
    /// </summary>
    /// <param name="text">Text of the surcharge message</param>
    /// <param name="percentage">the surcharge percentage applied</param>
    public virtual void AddSurchargeMessage(string text, double percentage)
    {
      SurchargeMessages.Add(new Message(SurchargeMessages, TypeOfMessage.Surcharge, text, 0,
        ItemScope.Policy, percentage, 0.0, StandardMessage.NoStandardCode));
    }

    /// <summary>
    /// Adds a surcharge to the list of policy surcharge messages
    /// </summary>
    /// <param name="code">Standard message code that will determine the message text</param>
    /// <param name="percentage">the surcharge percentage applied</param>
    /// <param name="amount">the surcharge amount applied</param>
    public virtual void AddSurchargeMessage(StandardMessage code, double percentage, double amount)
    {
      SurchargeMessages.Add(new Message(SurchargeMessages, TypeOfMessage.Surcharge, 0, ItemScope.Policy, percentage, amount, code));
    }

    /// <summary>
    /// Adds a surcharge to the list of policy discount messages
    /// </summary>
    /// <param name="code">Standard message code that will determine the message text</param>
    /// <param name="percentage">the surcharge percentage applied</param>
    /// <param name="amount">the surcharge amount applied</param>
    /// <param name="extraText">Extra text to tack on at the end of the standard message text</param>
    public virtual void AddSurchargeMessage(StandardMessage code, double percentage, double amount, string extraText)
    {
      Message tempMsg = new Message(SurchargeMessages, TypeOfMessage.Surcharge, 0, ItemScope.Policy, percentage, amount, code);
      tempMsg.Text += extraText;
      SurchargeMessages.Add(tempMsg);
    }

    /// <summary>
    /// Adds a surcharge to the list of policy surcharge messages
    /// </summary>
    /// <param name="text">Text of the surcharge message</param>
    /// <param name="percentage">the surcharge percentage applied</param>
    /// <param name="amount">the surcharge amount applied</param>
    public virtual void AddSurchargeMessage(string text, double percentage, double amount)
    {
      SurchargeMessages.Add(new Message(SurchargeMessages, TypeOfMessage.Surcharge, text, 0,
        ItemScope.Policy, percentage, amount, StandardMessage.NoStandardCode));
    }

    /// <summary>
    /// Adds a surcharge to the list of policy surcharges
    /// </summary>
    /// <param name="code">Standard message code that will determine the message text</param>
    /// <param name="scopeNumber">The scope number for the new surcharge</param>
    /// <param name="scope">The scope for the new surcharge</param>
    public virtual void AddSurchargeMessage(StandardMessage code, int scopeNumber, ItemScope scope)
    {
      SurchargeMessages.Add(new Message(SurchargeMessages, TypeOfMessage.Surcharge, scopeNumber, scope, 0.0, 0.0, code));
    }

    /// <summary>
    /// Adds a surcharge to the list of policy surcharges
    /// </summary>
    /// <param name="text">Text of the surcharge message</param>
    /// <param name="scope">The scope of the surcharge (policy, car, driver, etc)</param>
    /// <param name="scopeNumber">The scope number of the surcharge</param>
    public virtual void AddSurchargeMessage(string text, int scopeNumber, ItemScope scope)
    {
      SurchargeMessages.Add(new Message(SurchargeMessages, TypeOfMessage.Surcharge, text, scopeNumber, scope, 0.0, 0.0, StandardMessage.NoStandardCode));
    }

    /// <summary>
    /// Florida Hurricane Catastrophe Fund.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double FHCFEmergencyAssessmentSurcharge
    {
      get { return m_FHCFEmergencyAssessmentSurcharge; }
      set { m_FHCFEmergencyAssessmentSurcharge = value; }
    }     // FHCFEmergencyAssessmentSurcharge property

    /// <summary>
    /// Program rebate.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double ProgramRebate
    {
      get { return m_programRebate; }
      set { m_programRebate = value; }
    }

    /// <summary>
    /// Determines if the user has opted not to use a validated address and instead 
    /// would like to use the address they entered. Address will be re-validated if / when they change 
    /// their address. 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool AddressEnteredSelected { get; set; }

    /// <summary>
    /// Is this policy being rated for multiple agencies? This is normally false. It should only be set to true
    /// when you are rating through a unique 3rd party api, where a single policy and rate iteration
    /// can be done for multiple insurance agencies.
    /// </summary>
    public virtual bool IsRatingForMultipleAgencies
    {
      get { return m_isRatingForMultipleAgencies; }
      set { m_isRatingForMultipleAgencies = value; }
    }

    /// <summary>
    /// This property is related to the RateSource property. For example, if RateSource is set to API, then this might
    /// be set to "InsuranceZebra" or something like that.
    /// </summary>
    public virtual string RateSourceDetail
    {
      get { return m_rateSourceDetail; }
      set { m_rateSourceDetail = value; }
    }

    /// <summary>
    /// Used by the ObjectSqlDbPersistence class. This method is here
    /// so that we can perform some pre-save operations on the object.
    /// </summary>
    public virtual void PreSave()
    {
      CompanyDataStorage = CompanyQuestions.GenerateBlobField(CompanyQuestionCategory.CompanyData);
      NonStoredDataStorage = CompanyQuestions.GenerateBlobField(CompanyQuestionCategory.NonStoredData);
      CompanyModuleContentsDataStorage = CompanyQuestions.GenerateBlobField(CompanyQuestionCategory.CompanyModuleContents);
    }

    /// <summary>
    /// Used by the ObjectSqlDbPersistence class. This method is here
    /// so that we can perform some post-load operations on the object.
    /// </summary>
    public virtual void PostLoad()
    {
      CompanyQuestions.ParseBlobField(CompanyDataStorage, CompanyQuestionCategory.CompanyData);
      CompanyQuestions.ParseBlobField(NonStoredDataStorage, CompanyQuestionCategory.NonStoredData);
      CompanyQuestions.ParseBlobField(CompanyModuleContentsDataStorage, CompanyQuestionCategory.CompanyModuleContents);
    }

    private int m_insuredLinkID = ITCConstants.InvalidNum;
    private int m_userLinkID = ITCConstants.InvalidNum;
    private int m_groupLinkID = ITCConstants.InvalidNum;
    private int m_term = 1;
    private Duration m_termDuration = Duration.Years;
    private int m_coTerm = 1;
    private Duration m_coTermDuration = Duration.Years;
    private string m_remarks = "";
    private DateTime m_effectiveDate = DateTime.Now;
    private DateTime m_binderEffectiveDate = DateTime.Now;
    private DateTime m_binderExpirationDate = DateTime.Now.AddDays(30);
    private double m_policyFee;
    private double m_commissionPercent;
    private double m_commissionPremium;
    private double m_totalPremium;
    private string m_creditScore = "";
    private int m_exclusionCode;
    private string m_coCreditScore = "";
    private string m_coBridgedCreditScore = "";
    private string m_creditVerification = "";
    private string m_coCreditVerification = "";
    private string m_coBridgedCreditVerification = "";
    private string m_uDDStatus = "N";
    private string m_coUDDStatus = "N";
    private string m_hOVStatus = "N";
    private string m_coHOVStatus = "N";
    private DateTime m_creditScoreDateTime = ITCConstants.InvalidDate;
    private int m_creditScoreTransactionID = ITCConstants.InvalidNum;
    private DateTime m_insuranceScoreEntryDoneDate = ITCConstants.InvalidDate;
    private string m_tier = "";
    private string m_coTierStr = "";
    private DateTime m_dateCreated = DateTime.Now;
    private string m_priorCarrierName = "";
    private DateTime m_priorEffDate = ITCConstants.InvalidDate;
    private DateTime m_priorEffTime = ITCConstants.InvalidDate;
    private DateTime m_priorExpDate = ITCConstants.InvalidDate;
    private DateTime m_priorExpTime = ITCConstants.InvalidDate;
    private bool m_priorInAgency;
    private bool m_allowPayPlanChange = true;
    private double m_aPR;
    private string m_priorPolicyNumber = "";
    private int m_numOfPayments;
    private int m_numOfPaymentsOverride;
    private double m_percentDown = 100;
    private double m_paymentAmount;
    private string m_payPlanDescription = "";
    private bool m_insuredDeclinedCredit;
    private bool m_biMonthly;
    private bool m_createdByUniversalUpload;
    private string m_creditScoreServerID = "";
    private double m_financeAmount;
    private double m_financeCharge;
    private string m_financeMessage = "";
    private bool m_financeQualified = true;
    private bool m_fRBond;
    private double m_downPayment;
    private double m_downPaymentOverride;
    private double m_endorsementOriginalTermPremium;
    private string m_hOVOrderNum = "";
    private string m_hOVRefNum = "";
    private int m_interfaceCompanyID = ITCConstants.InvalidNum;
    private bool m_monthlyFinanced;
    private double m_paymentTotal;
    private bool m_primaryPolicy = true;
    private string m_priorCarrierAddress1 = "";
    private string m_priorCarrierAddress2 = "";
    private string m_priorCarrierCity = "";
    private string m_priorCarrierPolicyNumberString = "";
    private USState m_priorCarrierState = USState.NoneSelected;
    private string m_priorCarrierZipCode = "";
    private string m_rTRITCCompanyTransactionID = "";
    private string m_rTRITCGroupTransactionID = "";
    private string m_rTRThirdPartyQuoteURL = "";
    private string m_rTRThirdPartyTransactionID = "";
    private string m_secondaryCoCreditScore = "";
    private string m_secondaryCoCreditVerification = "";
    private string m_secondaryCreditScore = "";
    private string m_secondaryCreditVerification = "";
    private double m_secondaryPolicyFee;
    private double m_taxablePremium;
    private DateTime m_uDDTransactionDate = ITCConstants.InvalidDate;
    private string m_uDDTransactionID = "";
    private string m_realTimeRatingData = "";
    private string m_thirdPartyCreditResponseData = "";
    private string m_uDRNotes = "";
    private bool m_locked;
    private string m_lockedBy = "";
    private string m_lockedByUserName = "";
    private DateTime m_lockedDateTime = ITCConstants.InvalidDate;
    private bool m_deleted;
    private string m_deletedBy = "";
    private DateTime m_deletedDateTime = ITCConstants.InvalidDate;
    private byte[] m_applicationBlob = new byte[0]; //MUST be initialized for saving to work!!
    private string m_insuranceScoreData = "";
    private SourceProduct m_sourceProduct = SourceProduct.WindowsComparative;
    private Residence m_mailingAddress;
    private Person m_insured;
    private MessageList m_warnings;
    private MessageList m_errors;
    private MessageList m_discountMessages;
    private MessageList m_surchargeMessages;
    private InsQuote m_quote;
    private CompanyQuestionList m_companyQuestions;
    private MiscPremiumList m_miscPremiums;
    private string m_ImportFileName = "";
    private long m_marketBasketItemID = ITCConstants.InvalidNum;
    private bool m_independentlyFinanced;
    private Guid m_policyUID = Guid.NewGuid();
    private Guid m_caesarId;
    private string m_secondaryCoTierStr = "";
    private string m_secondaryThirdPartyCreditResponseData = "";
    private MessageList m_secondaryWarnings;
    private MessageList m_secondaryDiscountMessages;
    private MessageList m_secondarySurchargeMessages;
    private int m_agencyBuzzPolicyID = ITCConstants.InvalidNum;
    private int m_secondaryAgencyBuzzPolicyID = ITCConstants.InvalidNum;
    private InsuranceLine m_lineOfInsurance;
    private RTRCreditOrderStatus m_rTRThirdPartyCreditOrderStatus = RTRCreditOrderStatus.NoDataReceived;
    private string m_thirdPartySystemName = String.Empty;
    private string m_thirdPartyId = String.Empty;
    private bool m_addressValidated;
    private double m_statutoryAssessmentFee;
    private double m_FHCFEmergencyAssessmentSurcharge;
    private double m_programRebate;
    private bool m_isRatingForMultipleAgencies;
    private string m_rateSourceDetail = String.Empty;
    private string m_phoneCode = string.Empty;
    private DateTime m_phoneCodeExpiration = ITCConstants.InvalidDate;
    private string m_customLeadSource = null;
    private MessageList m_coSurchargeFees;
  }
}
