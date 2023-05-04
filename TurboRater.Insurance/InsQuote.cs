using System;
using System.Data; 
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TurboRater.Insurance
{
  /// <summary>
  /// The quote class. The quote has a 1-1 relationship with a policy object.
  /// </summary>
  [Serializable]
  public class InsQuote : BaseStoredRecord
  {
    private string m_quoteAgencyAddress1 = "";
    private string m_quoteAgencyAddress2 = "";
    private string m_quoteAgencyCity = "";
    private USState m_quoteAgencyState = USState.Texas;
    private string m_quoteAgencyZipCode = "";
    private string m_quoteAgencyAlternatePhone = "";
    private string m_quoteAgencyFax = "";
    private string m_quoteAgencyPhone = "";
    private string m_quoteAgencyName = "";
    private string m_quoteAgencyTaxID = "";
    private string m_quoteAgencyLocationName = "";
    private string m_quotedByLastName = "";
    private string m_lastQuotedByLastName = "";
    private string m_lastQuotedByFirstName = "";
    private string m_lastQuotedByInitial = "";
    private DateTime m_lastQuotedDate = ITCConstants.InvalidDate;
    private string m_leadSource = "";
    private string m_contactSource = "";
    private string m_nAICCode = "";
    private string m_companyCode = "";
    private DateTime m_companyEffectiveDate = ITCConstants.InvalidDate;
    private int m_companyID = ITCConstants.InvalidNum;
    private int m_pFPayPlanID = ITCConstants.InvalidNum;
    private int m_pFProgramID = ITCConstants.InvalidNum;
    private int m_programID = ITCConstants.InvalidNum;
    private int m_windowsRecordID = ITCConstants.InvalidNum;
    private string m_programName = "";
    private string m_policyNumber = "";
    private string m_producerCode = "";
    private string m_companyName = "";
    private string m_companyPhone = "";
    private string m_quoteAgencyWebsiteURL = "";
    private string m_quoteDescription = "";
    private bool m_quoteTemplate;
    private DateTime m_secondaryBinderDate = ITCConstants.InvalidDate;
    private int m_secondaryBinderDays = ITCConstants.InvalidNum;
    private string m_secondaryBinderNumber = "";
    private DateTime m_secondaryBinderTime = ITCConstants.InvalidDate;
    private bool m_secondaryBound;
    private DateTime m_secondaryCompanyEffectiveDate = ITCConstants.InvalidDate;
    private int m_secondaryCompanyID = ITCConstants.InvalidNum;
    private DateTime m_secondaryExportTime = ITCConstants.InvalidDate;
    private string m_templateDescription = "";
    private int m_companyRateRevision = ITCConstants.InvalidNum;
    private string m_contractNumber = "";
    private DateTime m_dateQuoted = ITCConstants.InvalidDate;
    private DateTime m_effectiveTime = ITCConstants.InvalidDate;
    private DateTime m_expirationDate = ITCConstants.InvalidDate;
    private DateTime m_expirationTime = ITCConstants.InvalidDate;
    private DateTime m_exportDate = ITCConstants.InvalidDate;
    private DateTime m_exportTime = ITCConstants.InvalidDate;
    private int m_deletedNoteCount;
    private string m_financeCompanyAddress1 = "";
    private string m_financeCompanyAddress2 = "";
    private string m_financeCompanyCity = "";
    private string m_financeCompanyName = "";
    private USState m_financeCompanyState = USState.Texas;
    private string m_financeCompanyZipCode = "";
    private string m_quotedByFirstName = "";
    private string m_quotedByInitial = "";
    private bool m_bound;
    private string m_binderNumber = "";
    private int m_binderDays;
    private DateTime m_binderDate = ITCConstants.InvalidDate;
    private DateTime m_binderTime = ITCConstants.InvalidDate;
    private string m_writtenByLastName = "";
    private string m_writtenByFirstName = "";
    private string m_writtenByInitial = "";
    private int m_interfaceMajorRevision = ITCConstants.InvalidNum;
    private int m_interfaceMinorRevision = ITCConstants.InvalidNum;
    private int m_interfaceReleaseRevision = ITCConstants.InvalidNum;
    private int m_interfaceBuildRevision = ITCConstants.InvalidNum;
    private int m_interfaceRateRevision = ITCConstants.InvalidNum;
    private int m_companyMajorRevision = ITCConstants.InvalidNum;
    private int m_companyMinorRevision = ITCConstants.InvalidNum;
    private int m_companyReleaseRevision = ITCConstants.InvalidNum;
    private int m_companyBuildRevision = ITCConstants.InvalidNum;
    private int m_policyLinkID = ITCConstants.InvalidNum;
    private string m_batchGroup = "";
    private InsNoteList m_notes;
    private string m_exportedByFirstName = "";
    private string m_exportedByLastName = "";
    private string m_exportedByMiddleInitial = "";
    private string m_secondaryCompanyCode = "";
    private string m_secondaryCompanyName = "";
    private int m_secondaryCompanyRateRevision = ITCConstants.InvalidNum;
    private string m_secondaryContractNumber = "";
    private DateTime m_secondaryExportDate = ITCConstants.InvalidDate;
    private int m_secondaryPFPayPlanID = ITCConstants.InvalidNum;
    private int m_secondaryPFProgramID = ITCConstants.InvalidNum;
    private string m_secondaryPolicyNumber = "";
    private string m_secondaryProducerCode = "";
    private int m_secondaryProgramID = ITCConstants.InvalidNum;
    private string m_secondaryProgramName = "";
    private double m_endorsementUnearnedFactor;
    private bool m_jcBumpLimits;
    private bool m_jcEmbedFiles;
    private string m_jcErrorFile = "";
    private int m_jcEstimateTerm;
    private string m_jcLogFile = "";
    private int m_jcOrderCreditScore;
    private int m_jcReturnLowestCombo;
    private string m_secondaryThirdPartyCreditResponse = "";
    private string m_thirdPartyCreditResponse = "";
    private double m_lastTotalPremiumQuoted;
    private double m_lastDownPaymentQuoted;
    private string m_lastPayPlanQuoted = "";
    private double m_lastPaymentQuoted;
    private InsPolicy m_parentPolicy;
    private int m_secondaryCompanyReleaseRevision = ITCConstants.InvalidNum;
    private int m_secondaryCompanyMajorRevision = ITCConstants.InvalidNum;
    private int m_secondaryCompanyMinorRevision = ITCConstants.InvalidNum;
    private int m_secondaryCompanyBuildRevision = ITCConstants.InvalidNum;
    private string m_secondaryCompanyPhone = "";
    private string m_originatingLocationGUID = "";
    private string m_reasonNotBound = "";
    private string m_thirdPartyQuoteID = "";
    private Guid m_quotedByGUID = ITCConstants.BlankGuid;
    private Guid m_lastQuotedByGUID = ITCConstants.BlankGuid;
    private Guid m_writtenByGUID = ITCConstants.BlankGuid;
    private Guid m_exportedByGUID = ITCConstants.BlankGuid;
    private Guid m_mgaBindRequestSubmittedBy = ITCConstants.BlankGuid;
    private string m_mgaBindRequestSubmittedByFirstName = "";
    private string m_mgaBindRequestSubmittedByMiddleInitial = "";
    private string m_mgaBindRequestSubmittedByLastName = "";
    private DateTime m_mgaBindRequestSubmittedDate = ITCConstants.InvalidDate;
    private CarrierMessageList m_carrierMessages = new CarrierMessageList();
    private List<CarrierReasonNotBound> m_carrierReasonNotBoundList;
    private Guid m_assignedToGUID = ITCConstants.BlankGuid;
    private string m_marketingNumber = string.Empty;

    /// <summary>
    /// Foreign key link back to the policy
    /// </summary>
    [PropertyStorage(SqlDbType.Int, ForeignKeyClassType = typeof(InsPolicy))]
    public virtual int PolicyLinkID
    {
      get { return m_policyLinkID; }
      set { m_policyLinkID = value; }
    }

    /// <summary>
    /// The binder number for the policy
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 25)]
    public virtual string BinderNumber
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryBinderNumber;
        else
          return m_binderNumber;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryBinderNumber = value;
        else
          m_binderNumber = value;
      }
    }

    /// <summary>
    /// the batch group under which this quote was quoted last
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 20)]
    public virtual string BatchGroup
    {
      get { return m_batchGroup; }
      set { m_batchGroup = value; }
    }

    /// <summary>
    /// The notes on the quote. 
    /// </summary>
    [PropertyStorage(SqlDbType.Variant, IsArrayList = true, ListItemType = typeof(InsNote))]
    public virtual InsNoteList Notes
    {
      get { return m_notes; }
      set { m_notes = value; }
    }

    /// <summary>
    /// The # of notes stored on the policy
    /// </summary>
    public virtual int NumOfNotes
    {
      get { return m_notes.Count; }
    }

    /// <summary>
    /// Major revision# of the interface that the quote was rated/saved with
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int InterfaceMajorRevision
    {
      get { return m_interfaceMajorRevision; }
      set { m_interfaceMajorRevision = value; }
    }

    /// <summary>
    /// Minor revision# of the interface that the quote was rated/saved with
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int InterfaceMinorRevision
    {
      get { return m_interfaceMinorRevision; }
      set { m_interfaceMinorRevision = value; }
    }

    /// <summary>
    /// Release revision# of the interface that the quote was rated/saved with
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int InterfaceReleaseRevision
    {
      get { return m_interfaceReleaseRevision; }
      set { m_interfaceReleaseRevision = value; }
    }

    /// <summary>
    /// Build revision# of the interface that the quote was rated/saved with
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int InterfaceBuildRevision
    {
      get { return m_interfaceBuildRevision; }
      set { m_interfaceBuildRevision = value; }
    }

    /// <summary>
    /// Rate revision# of the interface that the quote was rated/saved with
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int InterfaceRateRevision
    {
      get { return m_interfaceRateRevision; }
      set { m_interfaceRateRevision = value; }
    }

    /// <summary>
    /// Major revision# of the company rate module that the quote was rated/saved with
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int CompanyMajorRevision
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryCompanyMajorRevision;
        else
          return m_companyMajorRevision;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryCompanyMajorRevision = value;
        else
          m_companyMajorRevision = value;
      }
    }

    /// <summary>
    /// Minor revision# of the company rate module that the quote was rated/saved with
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int CompanyMinorRevision
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryCompanyMinorRevision;
        else
          return m_companyMinorRevision;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryCompanyMinorRevision = value;
        else
          m_companyMinorRevision = value;
      }
    }

    /// <summary>
    /// Release revision# of the company rate module that the quote was rated/saved with
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int CompanyReleaseRevision
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryCompanyReleaseRevision;
        else
          return m_companyReleaseRevision;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryCompanyReleaseRevision = value;
        else
          m_companyReleaseRevision = value;
      }
    }

    /// <summary>
    /// Build revision# of the company rate module that the quote was rated/saved with
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int CompanyBuildRevision
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryCompanyBuildRevision;
        else
          return m_companyBuildRevision;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryCompanyBuildRevision = value;
        else
          m_companyBuildRevision = value;
      }
    }

    /// <summary>
    /// The last name of the CSR that wrote this quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 50)]
    public virtual string WrittenByLastName
    {
      get { return m_writtenByLastName; }
      set { m_writtenByLastName = value; }
    }

    /// <summary>
    /// The first name of the CSR that wrote this quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 50)]
    public virtual string WrittenByFirstName
    {
      get { return m_writtenByFirstName; }
      set { m_writtenByFirstName = value; }
    }

    /// <summary>
    /// The middle initial of the CSR that wrote this quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 1)]
    public virtual string WrittenByInitial
    {
      get { return m_writtenByInitial; }
      set { m_writtenByInitial = value; }
    }

    /// <summary>
    /// Date this quote was bound
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public virtual DateTime BinderDate
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryBinderDate;
        else
          return m_binderDate;
      }

      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryBinderDate = value;
        else
          m_binderDate = value;
      }
    }

    /// <summary>
    /// Time this quote was bound
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public virtual DateTime BinderTime
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryBinderTime;
        else
          return m_binderTime;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryBinderTime = value;
        else
          m_binderTime = value;
      }
    }

    /// <summary>
    /// # of Days that the binding of this quote will be in effect
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int BinderDays
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryBinderDays;
        else
          return m_binderDays;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryBinderDays = value;
        else
          m_binderDays = value;
      }
    }

    /// <summary>
    /// Is this quote bound?
    /// </summary>
    [PropertyStorage(SqlDbType.Bit)]
    public virtual bool Bound
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryBound;
        else
          return m_bound;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryBound = value;
        else
          m_bound = value;
      }
    }

    /// <summary>
    /// The quoting company's company code
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 20)]
    public virtual string CompanyCode
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryCompanyCode;
        else
          return m_companyCode;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryCompanyCode = value;
        else
          m_companyCode = value;
      }
    }

    /// <summary>
    /// The quoting company's effective date
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public virtual DateTime CompanyEffectiveDate
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryCompanyEffectiveDate;
        else
          return m_companyEffectiveDate;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryCompanyEffectiveDate = value;
        else
          m_companyEffectiveDate = value;
      }
    }

    /// <summary>
    /// The quoting company's company id#
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int CompanyID
    {
      // Windows/Desktop rater set this field to 0 whenever there was no
      // secondary data.  In TWE, we need it to be -1 when there is no
      // secondary data.  So, what we're doing is always retrieving -1
      // if the stored value is 0, and setting the stored value to -1
      // if it is attempted to set it to 0
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
        {
          if (m_secondaryCompanyID == 0)
            return ITCConstants.InvalidNum;
          else
            return m_secondaryCompanyID;
        }
        else
          return m_companyID;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
        {
          if (value == 0)
            m_secondaryCompanyID = ITCConstants.InvalidNum;
          else
            m_secondaryCompanyID = value;
        }
        else
          m_companyID = value;
      }
    }

    /// <summary>
    /// The premium finance payment plan ID
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int PFPayPlanID
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryPFPayPlanID;
        else
          return m_pFPayPlanID;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryPFPayPlanID = value;
        else
          m_pFPayPlanID = value;
      }
    }

    /// <summary>
    /// The premium finance program ID
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int PFProgramID
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryPFProgramID;
        else
          return m_pFProgramID;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryPFProgramID = value;
        else
          m_pFProgramID = value;
      }
    }

    /// <summary>
    /// The program id of the selected program for the selected company
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int ProgramID
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryProgramID;
        else
          return m_programID;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryProgramID = value;
        else
          m_programID = value;
      }
    }

    /// <summary>
    /// The quote ID (recordID) from the windows turborater system
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int WindowsRecordID
    {
      get { return m_windowsRecordID; }
      set { m_windowsRecordID = value; }
    }

    /// <summary>
    /// The program name of the selected program for the selected company
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 40)]
    public virtual string ProgramName
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryProgramName;
        else
          return m_programName;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryProgramName = value;
        else
          m_programName = value;
      }
    }

    /// <summary>
    /// The policy# of the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 25)]
    public virtual string PolicyNumber
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryPolicyNumber;
        else
          return m_policyNumber;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryPolicyNumber = value;
        else
          m_policyNumber = value;
      }
    }

    /// <summary>
    /// The producer code of the person/agency who quoted this quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 25)]
    public virtual string ProducerCode
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryProducerCode;
        else
          return m_producerCode;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryProducerCode = value;
        else
          m_producerCode = value;
      }
    }

    /// <summary>
    /// The quoting company's name
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 50)]
    public virtual string CompanyName
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryCompanyName;
        else
          return m_companyName;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryCompanyName = value;
        else
          m_companyName = value;
      }
    }

    /// <summary>
    /// The quoting company's phone#
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = StorageConstants.PhoneLength)]
    public virtual string CompanyPhone
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryCompanyPhone;
        else
          return m_companyPhone;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryCompanyPhone = value;
        else
          m_companyPhone = value;
      }
    }

    /// <summary>
    /// The quoting agency's website
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 200)]
    public virtual string QuoteAgencyWebsiteURL
    {
      get { return m_quoteAgencyWebsiteURL; }
      set { m_quoteAgencyWebsiteURL = value; }
    }

    /// <summary>
    /// A description for the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 60)]
    public virtual string QuoteDescription
    {
      get { return m_quoteDescription; }
      set { m_quoteDescription = value; }
    }

    /// <summary>
    /// Was the quote loaded from a quote template. (not the actual template itself) 
    /// </summary>
    [PropertyStorage(SqlDbType.Bit)]
    public virtual bool LoadedFromQuoteTemplate { get; set; }

    /// <summary>
    /// Is this a quote template?
    /// </summary>
    [PropertyStorage(SqlDbType.Bit)]
    public virtual bool QuoteTemplate
    {
      get { return m_quoteTemplate; }
      set { m_quoteTemplate = value; }
    }

    /// <summary>
    /// The date of the secondary binder for the policy
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public virtual DateTime SecondaryBinderDate
    {
      get { return m_secondaryBinderDate; }
      set { m_secondaryBinderDate = value; }
    }

    /// <summary>
    /// The # of days the secondary binder will be in effect
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int SecondaryBinderDays
    {
      get { return m_secondaryBinderDays; }
      set { m_secondaryBinderDays = value; }
    }

    /// <summary>
    /// The secondary binder #
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 25)]
    public virtual string SecondaryBinderNumber
    {
      get { return m_secondaryBinderNumber; }
      set { m_secondaryBinderNumber = value; }
    }

    /// <summary>
    /// The time of the secondary binder for the policy
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public virtual DateTime SecondaryBinderTime
    {
      get { return m_secondaryBinderTime; }
      set { m_secondaryBinderTime = value; }
    }

    /// <summary>
    /// Is the secondary quote info bound?
    /// </summary>
    [PropertyStorage(SqlDbType.Bit)]
    public virtual bool SecondaryBound
    {
      get { return m_secondaryBound; }
      set { m_secondaryBound = value; }
    }

    /// <summary>
    /// The effective date of the secondary company for this quote
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public virtual DateTime SecondaryCompanyEffectiveDate
    {
      get { return m_secondaryCompanyEffectiveDate; }
      set { m_secondaryCompanyEffectiveDate = value; }
    }

    /// <summary>
    /// The id of the secondary company for this quote
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int SecondaryCompanyID
    {
      get
      {
        if (m_secondaryCompanyID == 0)
          return ITCConstants.InvalidNum;
        else
          return m_secondaryCompanyID;
      }
      set
      {
        if (value == 0)
          m_secondaryCompanyID = ITCConstants.InvalidNum;
        else
          m_secondaryCompanyID = value;
      }
    }

    /// <summary>
    /// The time of export of the secondary quote stuff
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public virtual DateTime SecondaryExportTime
    {
      get { return m_secondaryExportTime; }
      set { m_secondaryExportTime = value; }
    }

    /// <summary>
    /// The description of the quote template
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 50)]
    public virtual string TemplateDescription
    {
      get { return m_templateDescription; }
      set { m_templateDescription = value; }
    }

    /// <summary>
    /// The quoting company's rate revision #
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int CompanyRateRevision
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryCompanyRateRevision;
        else
          return m_companyRateRevision;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryCompanyRateRevision = value;
        else
          m_companyRateRevision = value;
      }
    }

    /// <summary>
    /// The contract#. Usually set as part of the rate module.
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 20)]
    public virtual string ContractNumber
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryContractNumber;
        else
          return m_contractNumber;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryContractNumber = value;
        else
          m_contractNumber = value;
      }
    }

    /// <summary>
    /// The date the quote was quoted
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public virtual DateTime DateQuoted
    {
      get { return m_dateQuoted; }
      set { m_dateQuoted = value; }
    }

    /// <summary>
    /// The effective time of the quote
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public virtual DateTime EffectiveTime
    {
      get { return m_effectiveTime; }
      set { m_effectiveTime = value; }
    }

    /// <summary>
    /// The date the quote will/did expire
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public virtual DateTime ExpirationDate
    {
      get { return m_expirationDate; }
      set { m_expirationDate = value; }
    }

    /// <summary>
    /// The time the quote will/did expire
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public virtual DateTime ExpirationTime
    {
      get { return m_expirationTime; }
      set { m_expirationTime = value; }
    }

    /// <summary>
    /// The date the quote was last exported
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public virtual DateTime ExportDate
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryExportDate;
        else
          return m_exportDate;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryExportDate = value;
        else
          m_exportDate = value;
      }
    }

    /// <summary>
    /// The time the quote was last exported
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public virtual DateTime ExportTime
    {
      get
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          return m_secondaryExportTime;
        else
          return m_exportTime;
      }
      set
      {
        if ((this.ParentPolicy != null) && ((ExclusionCodes)this.ParentPolicy.ExclusionCode == ExclusionCodes.PAPDRestricted))
          m_secondaryExportTime = value;
        else
          m_exportTime = value;
      }
    }

    /// <summary>
    /// The # of notes that have been deleted from this quote throughout
    /// the history of time. I'm really not sure why we're storing this variable,
    /// seem like it should be a temporary thing.
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int DeletedNoteCount
    {
      get { return m_deletedNoteCount; }
      set { m_deletedNoteCount = value; }
    }

    /// <summary>
    /// Address part 1 of financing company
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = StorageConstants.AddressLength)]
    public virtual string FinanceCompanyAddress1
    {
      get { return m_financeCompanyAddress1; }
      set { m_financeCompanyAddress1 = value; }
    }

    /// <summary>
    /// Address part 2 of financing company
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = StorageConstants.AddressLength)]
    public virtual string FinanceCompanyAddress2
    {
      get { return m_financeCompanyAddress2; }
      set { m_financeCompanyAddress2 = value; }
    }

    /// <summary>
    /// City of financing company
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = StorageConstants.CityLength)]
    public virtual string FinanceCompanyCity
    {
      get { return m_financeCompanyCity; }
      set { m_financeCompanyCity = value; }
    }

    /// <summary>
    /// Name of financing company
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 50)]
    public virtual string FinanceCompanyName
    {
      get { return m_financeCompanyName; }
      set { m_financeCompanyName = value; }
    }

    /// <summary>
    /// State that the finance company is in
    /// </summary>
    [PropertyStorageAttribute(SqlDbType.VarChar, Size = 50, EnumerationType = typeof(USState))]
    public virtual USState FinanceCompanyState
    {
      get { return m_financeCompanyState; }
      set { m_financeCompanyState = value; }
    }

    /// <summary>
    /// Zip code of financing company
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = StorageConstants.ZipCodeLength)]
    public virtual string FinanceCompanyZipCode
    {
      get { return m_financeCompanyZipCode; }
      set { m_financeCompanyZipCode = value; }
    }

    /// <summary>
    /// Last name of the CSR that quoted this quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 50)]
    public virtual string QuotedByLastName
    {
      get { return m_quotedByLastName; }
      set { m_quotedByLastName = value; }
    }

    /// <summary>
    /// Last name of the CSR that quoted this quote the last time
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 50)]
    public virtual string LastQuotedByLastName
    {
      get { return m_lastQuotedByLastName; }
      set { m_lastQuotedByLastName = value; }
    }

    /// <summary>
    /// First name of the CSR that quoted this quote the last time
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 50)]
    public virtual string LastQuotedByFirstName
    {
      get { return m_lastQuotedByFirstName; }
      set { m_lastQuotedByFirstName = value; }
    }

    /// <summary>
    /// Middle initial of the CSR that quoted this quote the last time
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 1)]
    public virtual string LastQuotedByInitial
    {
      get { return m_lastQuotedByInitial; }
      set { m_lastQuotedByInitial = value; }
    }

    /// <summary>
    /// The date that this quote was last quoted
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public virtual DateTime LastQuotedDate
    {
      get { return m_lastQuotedDate; }
      set { m_lastQuotedDate = value; }
    }

    /// <summary>
    /// The source of the lead for the quote (yellow pages, internet ad, whatever)
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 255)]
    public virtual string LeadSource
    {
      get { return m_leadSource; }
      set { m_leadSource = value; }
    }

    /// <summary>
    /// Method by which the customer contacted the agency
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 255)]
    public virtual string ContactSource
    {
      get { return m_contactSource; }
      set { m_contactSource = value; }
    }

    /// <summary>
    /// The NAIC code for the rated company
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 20)]
    public virtual string NAICCode
    {
      get { return m_nAICCode; }
      set { m_nAICCode = value; }
    }

    /// <summary>
    /// First name of the CSR that quoted this quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 50)]
    public virtual string QuotedByFirstName
    {
      get { return m_quotedByFirstName; }
      set { m_quotedByFirstName = value; }
    }

    /// <summary>
    /// Middle initial name of the CSR that quoted this quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 1)]
    public virtual string QuotedByInitial
    {
      get { return m_quotedByInitial; }
      set { m_quotedByInitial = value; }
    }

    /// <summary>
    /// The Tax ID # of the agency that did the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 50)]
    public virtual string QuoteAgencyTaxID
    {
      get { return m_quoteAgencyTaxID; }
      set { m_quoteAgencyTaxID = value; }
    }

    /// <summary>
    /// The agency name of the location that owns this quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 100)]
    public virtual string QuoteAgencyLocationName
    {
      get { return m_quoteAgencyLocationName; }
      set { m_quoteAgencyLocationName = value; }
    }

    /// <summary>
    /// The name of the agency that did the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 100)]
    public virtual string QuoteAgencyName
    {
      get { return m_quoteAgencyName; }
      set { m_quoteAgencyName = value; }
    }

    /// <summary>
    /// The phone # of the agency that did the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = StorageConstants.PhoneLength)]
    public virtual string QuoteAgencyPhone
    {
      get { return m_quoteAgencyPhone; }
      set { m_quoteAgencyPhone = value; }
    }

    /// <summary>
    /// The fax # of the agency that did the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = StorageConstants.PhoneLength)]
    public virtual string QuoteAgencyFax
    {
      get { return m_quoteAgencyFax; }
      set { m_quoteAgencyFax = value; }
    }

    /// <summary>
    /// The alternate phone # of the agency that did the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = StorageConstants.PhoneLength)]
    public virtual string QuoteAgencyAlternatePhone
    {
      get { return m_quoteAgencyAlternatePhone; }
      set { m_quoteAgencyAlternatePhone = value; }
    }

    /// <summary>
    /// Address part 1 of the agency that did the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = StorageConstants.AddressLength)]
    public virtual string QuoteAgencyAddress1
    {
      get { return m_quoteAgencyAddress1; }
      set { m_quoteAgencyAddress1 = value; }
    }

    /// <summary>
    /// Address part 2 of the agency that did the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = StorageConstants.AddressLength)]
    public virtual string QuoteAgencyAddress2
    {
      get { return m_quoteAgencyAddress2; }
      set { m_quoteAgencyAddress2 = value; }
    }

    /// <summary>
    /// City of the agency that did the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = StorageConstants.CityLength)]
    public virtual string QuoteAgencyCity
    {
      get { return m_quoteAgencyCity; }
      set { m_quoteAgencyCity = value; }
    }

    /// <summary>
    /// State of the agency that did the quote
    /// </summary>
    [PropertyStorageAttribute(SqlDbType.VarChar, Size = 50, EnumerationType = typeof(USState))]
    public virtual USState QuoteAgencyState
    {
      get { return m_quoteAgencyState; }
      set { m_quoteAgencyState = value; }
    }

    /// <summary>
    /// Zip code of the agency that did the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = StorageConstants.ZipCodeLength)]
    public virtual string QuoteAgencyZipCode
    {
      get { return m_quoteAgencyZipCode; }
      set { m_quoteAgencyZipCode = value; }
    }

    /// <summary>
    /// First name of the person that exported the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 16)]
    public virtual string ExportedByFirstName
    {
      get { return m_exportedByFirstName; }
      set { m_exportedByFirstName = value; }
    }

    /// <summary>
    /// Last name of the person that exported the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 16)]
    public virtual string ExportedByLastName
    {
      get { return m_exportedByLastName; }
      set { m_exportedByLastName = value; }
    }

    /// <summary>
    /// Middle initial of the person that exported the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 16)]
    public virtual string ExportedByMiddleInitial
    {
      get { return m_exportedByMiddleInitial; }
      set { m_exportedByMiddleInitial = value; }
    }

    /// <summary>
    /// Code string of the secondary rated company for the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 16)]
    public virtual string SecondaryCompanyCode
    {
      get { return m_secondaryCompanyCode; }
      set { m_secondaryCompanyCode = value; }
    }

    /// <summary>
    /// Name of the secondary rated company for the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 35)]
    public virtual string SecondaryCompanyName
    {
      get { return m_secondaryCompanyName; }
      set { m_secondaryCompanyName = value; }
    }

    /// <summary>
    /// The rate revision# of the secondary rated company for the quote
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int SecondaryCompanyRateRevision
    {
      get { return m_secondaryCompanyRateRevision; }
      set { m_secondaryCompanyRateRevision = value; }
    }

    /// <summary>
    /// contract # for the secondary rated company for the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 16)]
    public virtual string SecondaryContractNumber
    {
      get { return m_secondaryContractNumber; }
      set { m_secondaryContractNumber = value; }
    }

    /// <summary>
    /// Date this quote was exported for the secondary rated company
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public virtual DateTime SecondaryExportDate
    {
      get { return m_secondaryExportDate; }
      set { m_secondaryExportDate = value; }
    }

    /// <summary>
    /// The premium finance payment plan id of the secondary rated company
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int SecondaryPFPayPlanID
    {
      get { return m_secondaryPFPayPlanID; }
      set { m_secondaryPFPayPlanID = value; }
    }

    /// <summary>
    /// The premium finance program id of the secondary rated company
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int SecondaryPFProgramID
    {
      get { return m_secondaryPFProgramID; }
      set { m_secondaryPFProgramID = value; }
    }

    /// <summary>
    /// policy # for the secondary rated company for the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 25)]
    public virtual string SecondaryPolicyNumber
    {
      get { return m_secondaryPolicyNumber; }
      set { m_secondaryPolicyNumber = value; }
    }

    /// <summary>
    /// producer code for the secondary rated company for the quote
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 20)]
    public virtual string SecondaryProducerCode
    {
      get { return m_secondaryProducerCode; }
      set { m_secondaryProducerCode = value; }
    }

    /// <summary>
    /// The program id of the secondary rated company
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int SecondaryProgramID
    {
      get { return m_secondaryProgramID; }
      set { m_secondaryProgramID = value; }
    }

    /// <summary>
    /// selected program name of the secondary rated company
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 35)]
    public virtual string SecondaryProgramName
    {
      get { return m_secondaryProgramName; }
      set { m_secondaryProgramName = value; }
    }

    /// <summary>
    /// The factor used to calculate unearned endorsements? (not really sure)
    /// </summary>
    [PropertyStorage(SqlDbType.Float)]
    public virtual double EndorsementUnearnedFactor
    {
      get { return m_endorsementUnearnedFactor; }
      set { m_endorsementUnearnedFactor = value; }
    }

    /// <summary>
    /// Job control tag...will we bump limits?
    /// </summary>
    [PropertyStorage(SqlDbType.Bit)]
    public virtual bool jcBumpLimits
    {
      get { return m_jcBumpLimits; }
      set { m_jcBumpLimits = value; }
    }

    /// <summary>
    /// Job control tag...will we embed files? 
    /// </summary>
    [PropertyStorage(SqlDbType.Bit)]
    public virtual bool jcEmbedFiles
    {
      get { return m_jcEmbedFiles; }
      set { m_jcEmbedFiles = value; }
    }

    /// <summary>
    /// Job control tag...the name of the file where errors are logged
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 16)]
    public virtual string jcErrorFile
    {
      get { return m_jcErrorFile; }
      set { m_jcErrorFile = value; }
    }

    /// <summary>
    /// Job control tag...what is the estimated term that will be used?
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int jcEstimateTerm
    {
      get { return m_jcEstimateTerm; }
      set { m_jcEstimateTerm = value; }
    }

    /// <summary>
    /// Job control tag...the name of the file where events are logged
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 16)]
    public virtual string jcLogFile
    {
      get { return m_jcLogFile; }
      set { m_jcLogFile = value; }
    }

    /// <summary>
    /// Job control tag...should we order a credit score?
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int jcOrderCreditScore
    {
      get { return m_jcOrderCreditScore; }
      set { m_jcOrderCreditScore = value; }
    }

    /// <summary>
    /// Job control tag...should we return the lowest rating combination (drivers+cars)?
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public virtual int jcReturnLowestCombo
    {
      get { return m_jcReturnLowestCombo; }
      set { m_jcReturnLowestCombo = value; }
    }

    /// <summary>
    /// third party credit response for the secondary policy
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 255)]
    public virtual string SecondaryThirdPartyCreditResponse
    {
      get { return m_secondaryThirdPartyCreditResponse; }
      set { m_secondaryThirdPartyCreditResponse = value; }
    }

    /// <summary>
    /// third party credit response for the primary policy
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 255)]
    public virtual string ThirdPartyCreditResponse
    {
      get { return m_thirdPartyCreditResponse; }
      set { m_thirdPartyCreditResponse = value; }
    }

    /// <summary>
    /// The total premium of the last quoted company
    /// </summary>
    [PropertyStorage(SqlDbType.Float)]
    public virtual double LastTotalPremiumQuoted
    {
      get { return m_lastTotalPremiumQuoted; }
      set { m_lastTotalPremiumQuoted = value; }
    }

    /// <summary>
    /// The down payment of the last quoted company
    /// </summary>
    [PropertyStorage(SqlDbType.Float)]
    public virtual double LastDownPaymentQuoted
    {
      get { return m_lastDownPaymentQuoted; }
      set { m_lastDownPaymentQuoted = value; }
    }

    /// <summary>
    /// The payment amount of the last quoted company
    /// </summary>
    [PropertyStorage(SqlDbType.Float)]
    public virtual double LastPaymentQuoted
    {
      get { return m_lastPaymentQuoted; }
      set { m_lastPaymentQuoted = value; }
    }

    /// <summary>
    /// The pay plan description that was last quoted.
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 255)]
    public virtual string LastPayPlanQuoted
    {
      get { return m_lastPayPlanQuoted; }
      set { m_lastPayPlanQuoted = value; }
    }

    /// <summary>
    /// Reference back to policy that owns this object.
    /// </summary>
    public InsPolicy ParentPolicy
    {
      get { return m_parentPolicy; }
      set { m_parentPolicy = value; }
    }

    /// <summary>
    /// Release revision# of the secondary company rate module that the quote was rated/saved with.
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public int SecondaryCompanyReleaseRevision
    {
      get { return m_secondaryCompanyReleaseRevision; }
      set { m_secondaryCompanyReleaseRevision = value; }
    }

    /// <summary>
    /// Major revision# of the secondary company rate module that the quote was rated/saved with.
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public int SecondaryCompanyMajorRevision
    {
      get { return m_secondaryCompanyMajorRevision; }
      set { m_secondaryCompanyMajorRevision = value; }
    }

    /// <summary>
    /// Minor revision# of the secondary company rate module that the quote was rated/saved with.
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public int SecondaryCompanyMinorRevision
    {
      get { return m_secondaryCompanyMinorRevision; }
      set { m_secondaryCompanyMinorRevision = value; }
    }

    /// <summary>
    /// Release build# of the secondary company rate module that the quote was rated/saved with.
    /// </summary>
    [PropertyStorage(SqlDbType.Int)]
    public int SecondaryCompanyBuildRevision
    {
      get { return m_secondaryCompanyBuildRevision; }
      set { m_secondaryCompanyBuildRevision = value; }
    }

    /// <summary>
    /// Phone number of secondary company.
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = StorageConstants.PhoneLength)]
    public string SecondaryCompanyPhone
    {
      get { return m_secondaryCompanyPhone; }
      set { m_secondaryCompanyPhone = value; }
    }

    /// <summary>
    /// Description of the agency location that originally created this quote
    /// </summary>
    [PropertyStorage(SqlDbType.UniqueIdentifier)]
    public string OriginatingLocationGUID
    {
      get { return m_originatingLocationGUID; }
      set { m_originatingLocationGUID = value; }
    }

    /// <summary>
    /// Reason why this quote is not bound
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 255)]
    public string ReasonNotBound
    {
      get { return m_reasonNotBound; }
      set { m_reasonNotBound = value; }
    }

    /// <summary>
    /// Quote ID sent by vendor.  Normally used by Agency Management Systems to identify their quote when bridging back to them.
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 80)]
    public string ThirdPartyQuoteID
    {
      get { return m_thirdPartyQuoteID; }
      set { m_thirdPartyQuoteID = value; }
    }

    /// <summary>
    /// User GUID identifying the user who originally quoted this policy
    /// </summary>
    [PropertyStorage(SqlDbType.UniqueIdentifier)]
    public Guid QuotedByGUID
    {
      get { return m_quotedByGUID; }
      set { m_quotedByGUID = value; }
    }

    /// <summary>
    /// User GUID identifying the user who was the last person to rate this quote
    /// </summary>
    [PropertyStorage(SqlDbType.UniqueIdentifier)]
    public Guid LastQuotedByGUID
    {
      get { return m_lastQuotedByGUID; }
      set { m_lastQuotedByGUID = value; }
    }

    /// <summary>
    /// User GUID identifying the user who bound this quote
    /// </summary>
    [PropertyStorage(SqlDbType.UniqueIdentifier)]
    public Guid WrittenByGUID
    {
      get { return m_writtenByGUID; }
      set { m_writtenByGUID = value; }
    }

    /// <summary>
    /// User GUID identifying the user who exported the quote
    /// </summary>
    [PropertyStorage(SqlDbType.UniqueIdentifier)]
    public Guid ExportedByGUID
    {
      get { return m_exportedByGUID; }
      set { m_exportedByGUID = value; }
    }

    /// <summary>
    /// User GUID identifying the MGA user who submitted the bind request to the MGA
    /// </summary>
    [PropertyStorage(SqlDbType.UniqueIdentifier)]
    public Guid MGABindRequestSubmittedBy
    {
      get { return m_mgaBindRequestSubmittedBy; }
      set { m_mgaBindRequestSubmittedBy = value; }
    }

    /// <summary>
    /// First Name of the user who submitted the bind request to the MGA
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 50)]
    public string MGABindRequestSubmittedByFirstName
    {
      get { return m_mgaBindRequestSubmittedByFirstName; }
      set { m_mgaBindRequestSubmittedByFirstName = value; }
    }

    /// <summary>
    /// Middle Name/Initial of the user who submitted the bind request to the MGA
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 50)]
    public string MGABindRequestSubmittedByMiddleInitial
    {
      get { return m_mgaBindRequestSubmittedByMiddleInitial; }
      set { m_mgaBindRequestSubmittedByMiddleInitial = value; }
    }

    /// <summary>
    /// Last Name of the user who submitted the bind request to the MGA
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 50)]
    public string MGABindRequestSubmittedByLastName
    {
      get { return m_mgaBindRequestSubmittedByLastName; }
      set { m_mgaBindRequestSubmittedByLastName = value; }
    }

    /// <summary>
    /// Date on which the user submitted the bind request to the MGA
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public DateTime MGABindRequestSubmittedDate
    {
      get { return m_mgaBindRequestSubmittedDate; }
      set { m_mgaBindRequestSubmittedDate = value; }
    }

    /// <summary>
    /// Carrier messages received during rating
    /// </summary>
    [PropertyStorage(SqlDbType.Variant, IsArrayList = true, ListItemType = typeof(CarrierMessage))]
    public virtual CarrierMessageList CarrierMessages
    {
      get { return m_carrierMessages; }
      set { m_carrierMessages = value; }
    }

    /// <summary>
    /// List of carriers this quote was not bound with.
    /// </summary>
    [PropertyStorage(SqlDbType.Variant, IsArrayList = true, ListItemType = typeof(CarrierReasonNotBound))]
    public virtual List<CarrierReasonNotBound> CarrierReasonNotBoundList
    {
      get { return m_carrierReasonNotBoundList; }
      set { m_carrierReasonNotBoundList = value; }
    }

    /// <summary>
    /// The user department that this quote is assigned to
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 50)]
    public virtual string AgencyDepartment { get; set; } = string.Empty;


    /// <summary>
    /// The Region that this quote is assigned to
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 50)]
    public virtual string AgencyRegion { get; set; } = string.Empty;

    /// <summary>
    /// User GUID identifying the user who the quote is assigned to
    /// </summary>
    [PropertyStorage(SqlDbType.UniqueIdentifier)]
    public Guid AssignedToGUID
    {
      get { return m_assignedToGUID; }
      set { m_assignedToGUID = value; }
    }

    /// <summary>
    /// Marketing campaign ID.  Marketing campaigns can have many
    /// lead sources: radio, newspaper, etc.. This gives us a way
    /// to tie different lead sources to one marketing drive.  
    /// (example: Vern Fonk media code)
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 30)]
    public string MarketingNumber
    {
      get { return m_marketingNumber; }
      set { m_marketingNumber = value; }
    }

    /// <summary>
    /// The # of carriers not bound on the policy
    /// </summary>
    [XmlIgnore]
    public virtual int NumOfCarrierReasonNotBound
    {
      get
      {
        return CarrierReasonNotBoundList.Count;
      }
    }

    [OnDeserialized()]
    internal void OnDeserialized(StreamingContext context)
    {
      if (m_carrierReasonNotBoundList == null)
        m_carrierReasonNotBoundList = new List<CarrierReasonNotBound>();
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public InsQuote()
    {
      m_notes = new InsNoteList();
      m_carrierMessages = new CarrierMessageList();
      m_carrierReasonNotBoundList = new List<CarrierReasonNotBound>();
    }
  }
}
