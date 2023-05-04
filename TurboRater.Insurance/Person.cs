using System;
using System.Xml.Serialization;

namespace TurboRater.Insurance
{

  //turn off xml comment warnings for the enumerated types
  #pragma warning disable 1591
  /// <summary>
  /// The type of person. Named Insured, Other Insured, Other
  /// </summary>
  public enum TypeOfPerson
  {
    NamedInsured,
    OtherInsured,
    Other
  }
  //turn back on xml comment warnings
  #pragma warning restore 1591

  /// <summary>
  /// A base person class. This can be a driver, a named insured, etc.
  /// </summary>
  [Serializable]
  public class Person : BaseStoredRecord
  {
    /// <summary>
    /// Constructor that allows you to specify the type of person and the policy type.
    /// </summary>
    /// <param name="personType">the type of person</param>
    /// <param name="policyType">The type of policy this user is being created for.</param>
    public Person(TypeOfPerson personType, InsuranceLine policyType)
    {
      PersonType = personType;
      PolicyType = policyType;
    }

    /// <summary>
    /// Constructor that allows you to specify the policy type.
    /// </summary>
    /// <param name="policyType">The type of policy this user is being created for.</param>
    public Person(InsuranceLine policyType)
    {
      PolicyType = policyType;
    }

    /// <summary>
    /// Constructor that allows you to specify the type of person
    /// </summary>
    /// <param name="personType">the type of person</param>
    public Person(TypeOfPerson personType)
    {
      PersonType = personType;
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public Person()
    {
      PersonType = TypeOfPerson.Other;
    }

    /// <summary>
    /// foreign key link back to the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int, ForeignKeyClassType = typeof(InsPolicy))]
    public virtual int PolicyLinkID
    {
      get { return m_policyLinkID; }
      set { m_policyLinkID = value; }
    }

    /// <summary>
    /// The type of person that this is. Named Insured, etc.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25, EnumerationType = typeof(TypeOfPerson))]
    public virtual TypeOfPerson PersonType
    {
      get { return m_personType; }
      set { m_personType = value; }
    }

    /// <summary>
    /// The state product ID of the CMP product this insured belongs too. 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 10)]
    public virtual string ProductID
    {
      get { return m_productID; }
      set { m_productID = value; }
    }

    /// <summary>
    /// Person's first name
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string FirstName
    {
      get { return m_firstName; }
      set { m_firstName = value; }
    }

    /// <summary>
    /// Person's middle name
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string MiddleName
    {
      get { return m_middleName; }
      set { m_middleName = value; }
    }

    /// <summary>
    /// Person's last name
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string LastName
    {
      get { return m_lastName; }
      set { m_lastName = value; }
    }

    /// <summary>
    /// Person's home phone number
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 256, IsEncrypted = true)]
    public virtual string Phone
    {
      get { return m_phone; }
      set { m_phone = value; }
    }

    /// <summary>
    /// Person's work phone number
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 256, IsEncrypted = true)]
    public virtual string WorkPhone
    {
      get { return m_workPhone; }
      set { m_workPhone = value; }
    }

    /// <summary>
    /// Person's work phone extension
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 15)]
    public virtual string WorkPhoneExt
    {
      get { return m_workPhoneExt; }
      set { m_workPhoneExt = value; }
    }

    /// <summary>
    /// Person's cell phone number
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 256, IsEncrypted = true)]
    public virtual string CellPhone
    {
      get { return m_cellPhone; }
      set { m_cellPhone = value; }
    }

    /// <summary>
    /// Social security#
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 256, IsEncrypted = true)]
    public virtual string SSN
    {
      get { return m_sSN; }
      set { m_sSN = value; }
    }

    /// <summary>
    /// Person's fax#
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.PhoneLength)]
    public virtual string FaxNumber
    {
      get { return m_faxNumber; }
      set { m_faxNumber = value; }
    }

    /// <summary>
    /// Person's email address
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 75)]
    public virtual string EmailAddress
    {
      get { return m_emailAddress; }
      set { m_emailAddress = value; }
    }

    /// <summary>
    /// Indicator that the person does not have an email address
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool NoEmail
    {
      get { return m_noEmail; }
      set { m_noEmail = value; }
    }

    /// <summary>
    /// Indicator that the person does not have a phone, viable for AUTO and MC
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool NoPhone
    {
      get { return m_noPhone; }
      set { m_noPhone = value; }
    }

    /// <summary>
    /// Indicator that the person declined to provide an email address
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool DeclinedEmail
    {
      get { return m_declinedEmail; }
      set { m_declinedEmail = value; }
    }

    /// <summary>
    /// Person's prior address
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.AddressLength)]
    public virtual string PriorAddress1
    {
      get { return m_priorAddress1; }
      set { m_priorAddress1 = value; }
    }

    /// <summary>
    /// Person's prior address
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.AddressLength)]
    public virtual string PriorAddress2
    {
      get { return m_priorAddress2; }
      set { m_priorAddress2 = value; }
    }

    /// <summary>
    /// Person's prior street name
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.AddressLength)]
    public virtual string PriorStreetName
    {
      get { return m_priorStreetName; }
      set { m_priorStreetName = value; }
    }

    /// <summary>
    /// Person's prior street number
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25)]
    public virtual string PriorStreetNumber
    {
      get { return m_priorStreetNumber; }
      set { m_priorStreetNumber = value; }
    }

    /// <summary>
    /// Person's prior apartment#
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string PriorApartmentNumber
    {
      get { return m_priorApartmentNumber; }
      set { m_priorApartmentNumber = value; }
    }

    /// <summary>
    /// Person's prior street type (court, road, etc)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string PriorStreetType
    {
      get { return m_priorStreetType; }
      set { m_priorStreetType = value; }
    }

    /// <summary>
    /// Person's prior city
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 75)]
    public virtual string PriorCity
    {
      get { return m_priorCity; }
      set { m_priorCity = value; }
    }

    /// <summary>
    /// Person's prior state
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 50, EnumerationType = typeof(USState))]
    public virtual USState PriorState
    {
      get { return m_priorState; }
      set { m_priorState = value; }
    }

    /// <summary>
    /// Person's prior zip
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.ZipCodeLength)]
    public virtual string PriorZipCode
    {
      get { return m_priorZipCode; }
      set { m_priorZipCode = value; }
    }

    /// <summary>
    /// Length of time, in months, that the person has been with current employer
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int EmployedTime
    {
      get { return m_employedTime; }
      set { m_employedTime = value; }
    }

    /// <summary>
    /// Name of the person's employer
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string EmployerName
    {
      get { return m_employerName; }
      set { m_employerName = value; }
    }

    /// <summary>
    /// Address1 of the person's employer
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.AddressLength)]
    public virtual string EmployerAddress1
    {
      get { return m_employerAddress1; }
      set { m_employerAddress1 = value; }
    }

    /// <summary>
    /// Address2 of the person's employer
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.AddressLength)]
    public virtual string EmployerAddress2
    {
      get { return m_employerAddress2; }
      set { m_employerAddress2 = value; }
    }

    /// <summary>
    /// Phone# of the person's employer
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 256, IsEncrypted = true)]
    public virtual string EmployerPhone
    {
      get { return m_employerPhone; }
      set { m_employerPhone = value; }
    }

    /// <summary>
    /// Person's employer's city
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 75)]
    public virtual string EmployerCity
    {
      get { return m_employerCity; }
      set { m_employerCity = value; }
    }

    /// <summary>
    /// Person's employer's state
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 50, EnumerationType = typeof(USState))]
    public virtual USState EmployerState
    {
      get { return m_employerState; }
      set { m_employerState = value; }
    }

    /// <summary>
    /// Person's employer's zip code
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.ZipCodeLength)]
    public virtual string EmployerZipCode
    {
      get { return m_employerZipCode; }
      set { m_employerZipCode = value; }
    }

    /// <summary>
    /// Variable for storing the MVR Status
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25)]
    public virtual string MVRStatus
    {
      get { return m_mVRStatus; }
      set { m_mVRStatus = value; }
    }

    /// <summary>
    /// Variable for storing the company-specific MVR Status
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25)]
    public virtual string CoMVRStatus
    {
      get { return m_CoMVRStatus; }
      set { m_CoMVRStatus = value; }
    }

    /// <summary>
    /// Variable for storing the CLUE Status
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25)]
    public virtual string CLUEStatus
    {
      get { return m_cLUEStatus; }
      set { m_cLUEStatus = value; }
    }

    /// <summary>
    /// Variable for storing the company-specific CLUE Status
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25)]
    public virtual string CoCLUEStatus
    {
      get { return m_CoCLUEStatus; }
      set { m_CoCLUEStatus = value; }
    }

    /// <summary>
    /// Variable for storing the Current Carrier Status
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25)]
    public virtual string CurrentCarrierStatus
    {
      get { return m_currentCarrierStatus; }
      set { m_currentCarrierStatus = value; }
    }

    /// <summary>
    /// Variable for storing the company-specific Current Carrier Status
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25)]
    public virtual string CoCurrentCarrierStatus
    {
      get { return m_coCurrentCarrierStatus; }
      set { m_coCurrentCarrierStatus = value; }
    }

    /// <summary>
    /// The ambest # of the insured's current insurance carrier
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25)]
    public virtual string CurrentCarrierAmbestNum
    {
      get { return m_currentCarrierAmbestNum; }
      set { m_currentCarrierAmbestNum = value; }
    }

    /// <summary>
    /// The order # of the current carrier report for the insured
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25)]
    public virtual string CurrentCarrierOrderNum
    {
      get { return m_currentCarrierOrderNum; }
      set { m_currentCarrierOrderNum = value; }
    }

    /// <summary>
    /// The reference # of the current carrier report for the insured
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25)]
    public virtual string CurrentCarrierRefNum
    {
      get { return m_currentCarrierRefNum; }
      set { m_currentCarrierRefNum = value; }
    }

    /// <summary>
    /// The ChoicePoint MVR status for the person
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string MVRCPStatus
    {
      get { return m_mVRCPStatus; }
      set { m_mVRCPStatus = value; }
    }

    /// <summary>
    /// The ChoicePoint MVR status for the person, in the person's prior state
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string PriorStateMVRCPStatus
    {
      get { return m_priorStateMVRCPStatus; }
      set { m_priorStateMVRCPStatus = value; }
    }

    /// <summary>
    /// The date the MVR was ordered for the driver
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime MVRDateOrdered
    {
      get { return m_mVRDateOrdered; }
      set { m_mVRDateOrdered = value; }
    }

    /// <summary>
    /// The url at which you can find the MVR report for the person
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 200)]
    public virtual string MVRURL
    {
      get { return m_mVRURL; }
      set { m_mVRURL = value; }
    }

    /// <summary>
    /// Used by Winders to determine if the DB table needs restructuring
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool RestructureField
    {
      get { return m_restructureField; }
      set { m_restructureField = value; }
    }

    /// <summary>
    /// True if this person is actually a company name, otherwise false.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool IsACompany
    {
      get { return m_isACompany; }
      set { m_isACompany = value; }
    }

    /// <summary>
    /// The type of referral. Yellow pages, friend, etc
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25)]
    public virtual string Referral
    {
      get { return m_referral; }
      set { m_referral = value; }
    }

    /// <summary>
    /// Person's date of birth
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime DOB
    {
      get { return m_dob; }
      set { m_dob = value; }
    }

    /// <summary>
    /// The GUID of the agency record who owns this person.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.UniqueIdentifier)]
    public virtual string AgencyGUID
    {
      get { return m_agencyGUID; }
      set { m_agencyGUID = value; }
    }

    /// <summary>
    /// The GUID of the agency location record who owns this person.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.UniqueIdentifier)]
    public virtual string AgencyLocationGUID
    {
      get { return m_agencyLocationGUID; }
      set { m_agencyLocationGUID = value; }
    }

    /// <summary>
    /// The agency user GUID who owns this person. 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.UniqueIdentifier)]
    public virtual string AgencyUserGUID
    {
      get { return m_agencyUserGUID; }
      set { m_agencyUserGUID = value; }
    }

    /// <summary>
    /// The policy that this person is associated with, if any
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant)]
    [XmlIgnore]
    public virtual InsPolicy Policy
    {
      get { return m_policy; }
      set { m_policy = value; }
    }

    /// <summary>
    /// What type of policy is this? HO, Auto, etc.
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 25, EnumerationType = typeof(InsuranceLine))]
    public virtual InsuranceLine PolicyType
    {
      get { return m_policyType; }
      set { m_policyType = value; }
    }

    /// <summary>
    /// What country is this person from? 
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 10, EnumerationType = typeof(CountryOfOrigin),
       EnumerationConstHolderType = typeof(InsConstants), EnumerationValues = "CountryOfOriginChars")]
    public CountryOfOrigin CountryOfOrigin
    {
      get { return m_countryOfOrigin; }
      set { m_countryOfOrigin = value; }
    }

    /// <summary>
    /// person's address (part 1)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.SmallAddressLength)]
    public virtual string Address1
    {
      get { return m_address1; }
      set { m_address1 = value; }
    }

    /// <summary>
    /// person's address (part 2)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.SmallAddressLength)]
    public virtual string Address2
    {
      get { return m_address2; }
      set { m_address2 = value; }
    }

    /// <summary>
    /// person's city 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.CityLength)]
    public virtual string City
    {
      get { return m_city; }
      set { m_city = value; }
    }

    /// <summary>
    /// person's county
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 35)]
    public virtual string County
    {
      get { return m_county; }
      set { m_county = value; }
    }

    /// <summary>
    /// person's state of residence
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = StorageConstants.StateLength, EnumerationType = typeof(USState))]
    public virtual USState State
    {
      get { return m_state; }
      set { m_state = value; }
    }

    /// <summary>
    /// person's zip code
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.ZipCodeLength)]
    public virtual string ZipCode
    {
      get { return m_zipCode; }
      set { m_zipCode = value; }
    }

    /// <summary>
    /// insurance lead builder (agencybuzz) id of the insured. note that this field will be blank or all 0's if
    /// this insured has not yet been uploaded to ILB.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.UniqueIdentifier)]
    public virtual Guid ILBID
    {
      get { return m_ilbId; }
      set { m_ilbId = value; }
    }

    /// <summary>
    /// if this insured came from some sort of import cycle (quote merge, quote import, etc) then
    /// this is the cycle id on which it was imported.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.UniqueIdentifier)]
    public virtual Guid ImportCycleId
    {
      get { return m_importCycleId; }
      set { m_importCycleId = value; }
    }

    /// <summary>
    /// The company questions associated with the person.
    /// </summary>
    public virtual CompanyQuestionList CompanyQuestions
    {
      get { return m_companyQuestions; }
      set { m_companyQuestions = value; }
    }

    /// <summary>
    /// The person's native language.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50, EnumerationType = typeof(Language))]
    public virtual Language NativeLanguage
    {
      get { return m_nativeLanguage; }
      set { m_nativeLanguage = value; }
    }

    /// <summary>
    /// The person's relation to the insured
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string Relation
    {
      get { return m_relation; }
      set { m_relation = value; }
    }

    /// <summary>
    /// Person's gender
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string Sex
    {
      get { return m_sex; }
      set { m_sex = value; }
    }

    /// <summary>
    /// Person's gender
    /// Alternate storage field to account for inclusion of Non-Binary
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string Gender { get; set; } = "";

    /// <summary>
    /// Stores the gender with which the company rated the person
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string CoGender { get; set; } = "";

    /// <summary>
    /// Marital status of the person
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string Marital
    {
      get { return m_marital; }
      set { m_marital = value; }
    }

    /// <summary>
    /// The person's industry.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 3)]
    public virtual string IndustryOccupation
    {
      get { return m_industryOccupation; }
      set { m_industryOccupation = value; }
    }

    /// <summary>
    /// The person's occupation
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 30)]
    public virtual string Occupation
    {
      get { return m_occupation; }
      set { m_occupation = value; }
    }

    /// <summary>
    /// Level of education
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public string EducationLevel
    {
      get { return m_educationLevel; }
      set { m_educationLevel = value; }
    }

    /// <summary>
    /// The type of employment this driver enjoys heartily (snicker).
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 1)]
    public virtual string Employed
    {
      get { return m_employed; }
      set { m_employed = value; }
    }

    /// <summary>
    /// The date the driver was hired by his/her current employer
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime EmployedDate
    {
      get { return m_employedDate; }
      set { m_employedDate = value; }
    }

    /// <summary>
    /// Bankruptcy or any bank lines or judgement statements
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool BankLienJudgStat
    {
      get { return m_bankLienJudgStat; }
      set { m_bankLienJudgStat = value; }
    } 

    /// <summary>
    /// The person's age, as of the effective date of the associated
    /// policy. If the DOB is an invalid date, 0 is returned. If there
    /// is no associated policy, then today's date is used.
    /// </summary>
    public virtual int Age
    {
      get
      {
        DateTime toDate = DateTime.Now;
        if (!ITCConstants.IsValidDate(DOB))
          return 0;
        else
        {
          if ((this.Policy != null) && (ITCConstants.IsValidDate(this.Policy.EffectiveDate)))
            toDate = this.Policy.EffectiveDate;
          int years = toDate.Year - DOB.Year;
          if (DOB.AddYears(years) > toDate)
            years--;
          return years;
        }
      }
    }

    /// <summary>
    /// The Motor Club to which this person is a member
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50, EnumerationType = typeof(MotorClub))]
    public virtual MotorClub MotorClub 
    {
      get { return m_motorClub; }
      set { m_motorClub = value; }
    }

    /// <summary>
    /// The number of months this person has been a member of the Motor Club
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int MotorClubMonths 
    {
      get { return m_motorClubMonths; }
      set { m_motorClubMonths = value; }
    }

   /// <summary>
    /// True if user has consented to the Agency Disclosure
    /// False if user has explicitly not consented
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit, AllowNulls = true)]
    public virtual bool? AgencyDisclosureConsent { get; set; }

    /// <summary>
    /// Date when the user consented to Agency Disclosure
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime AgencyDisclosureConsentDate { get; set; }

    /// <summary>
    /// Username of person that marked Agency Disclosure consent
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string AgencyDisclosureConsentGatheredBy { get; set; } = string.Empty;

    /// <summary>
    /// True if user has consented to the FCRA
    /// False if user has explicitly not consented
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit, AllowNulls = true)]
    public virtual bool? FCRAConsent { get; set; }

    /// <summary>
    /// Date when the user consented to FCRA
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime FCRAConsentDate { get; set; }

    /// <summary>
    /// Username of person that marked FCRA consent
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string FCRAConsentGatheredBy { get; set; } = string.Empty;

    /// <summary>
    /// True if user has consented to the TCPA
    /// False if user has explicitly not consented
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit, AllowNulls = true)]
    public virtual bool? TCPAConsent { get; set; }

    /// <summary>
    /// Date when the user consented to TCPA
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime TCPAConsentDate { get; set; }

    /// <summary>
    /// Username of person that marked TCPA consent
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string TCPAConsentGatheredBy { get; set; } = string.Empty;    

    /// <summary>
    /// The field to check against the conditional load value.
    /// </summary>
    /// <seealso>ConditionalLoadCheck</seealso>
    /// <returns>"ResidenceType"</returns>
    public virtual string ConditionalLoadFieldName()
    {
      return "PolicyType";
    }

    /// <summary>
    /// Used by the ObjectSqlDbPersistence class to determine under what circumstances
    /// this object will be loaded from the database.
    /// </summary>
    /// <seealso>ConditionalLoadFieldName</seealso>
    /// <param name="checkValue">The value to check the condition of</param>
    /// <param name="parentField">The parent object of this current object</param>
    /// <returns>True if the state of the object matches that passed in the checkValue,
    /// otherwise false</returns>
    public virtual bool ConditionalLoadCheck(object checkValue, object parentField)
    {
      return (PolicyType.Equals(Enum.Parse(typeof(InsuranceLine), checkValue.ToString(), true)));
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

    private int m_policyLinkID = ITCConstants.InvalidNum;
    private TypeOfPerson m_personType = TypeOfPerson.NamedInsured;
    private string m_productID = "";
    private string m_firstName = "";
    private string m_middleName = "";
    private string m_lastName = "";
    private string m_phone = "";
    private string m_workPhone = "";
    private string m_workPhoneExt = "";
    private string m_cellPhone = "";
    private string m_sSN = "";
    private DateTime m_dob = ITCConstants.InvalidDate;
    private string m_faxNumber = "";
    private string m_emailAddress = "";
    private bool m_noEmail;
    private bool m_noPhone;
    private bool m_declinedEmail;
    private string m_priorAddress1 = "";
    private string m_priorAddress2 = "";
    private string m_priorStreetName = "";
    private string m_priorStreetNumber = "";
    private string m_priorApartmentNumber = "";
    private string m_priorStreetType = "";
    private string m_priorCity = "";
    private USState m_priorState = USState.NoneSelected;
    private string m_priorZipCode = "";
    private int m_employedTime;
    private string m_employerName = "";
    private string m_employerAddress1 = "";
    private string m_employerAddress2 = "";
    private string m_employerPhone = "";
    private string m_employerCity = "";
    private USState m_employerState = USState.NoneSelected;
    private string m_employerZipCode = "";
    private string m_mVRStatus = "N";
    private string m_CoMVRStatus = "N";
    private string m_cLUEStatus = "N";
    private string m_CoCLUEStatus = "N";
    private string m_currentCarrierStatus = "N";
    private string m_coCurrentCarrierStatus = "N";
    private string m_currentCarrierAmbestNum = "";
    private string m_currentCarrierOrderNum = "";
    private bool m_isACompany;
    private string m_referral = "";
    private string m_currentCarrierRefNum = "";
    private string m_mVRCPStatus = "";
    private string m_priorStateMVRCPStatus = "";
    private DateTime m_mVRDateOrdered = ITCConstants.InvalidDate;
    private string m_mVRURL = "";
    private bool m_restructureField;
    private CountryOfOrigin m_countryOfOrigin;
    private InsPolicy m_policy;
    private InsuranceLine m_policyType = InsuranceLine.Homeowners;
    private CompanyQuestionList m_companyQuestions = new CompanyQuestionList();
    private string m_agencyGUID = "";
    private string m_agencyLocationGUID = "";
    private string m_agencyUserGUID = "";
    private string m_address1 = "";
    private string m_address2 = "";
    private string m_city = "";
    private string m_county = "";
    private string m_zipCode = "";
    private USState m_state = USState.NoneSelected;
    private Guid m_ilbId = Guid.Empty;
    private Guid m_importCycleId = Guid.Empty;
    private Language m_nativeLanguage = Language.English;
    private string m_marital = "S";
    private string m_relation = "I";
    private string m_sex = "M";
    private string m_industryOccupation = "";
    private string m_occupation = "";
    private string m_educationLevel = string.Empty;
    private string m_employed = "E";
    private DateTime m_employedDate = ITCConstants.InvalidDate;
    private bool m_bankLienJudgStat;
    private MotorClub m_motorClub = MotorClub.None;
    private int m_motorClubMonths;
  }
}
