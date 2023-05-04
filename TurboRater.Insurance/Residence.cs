using System;

namespace TurboRater.Insurance
{
  /// <summary>
  /// A residence (house, apartment, etc)
  /// </summary>
  [Serializable]
  public class Residence : BaseStoredRecord
  {

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="aResidenceType">The type of residence</param>
    public Residence(TypeOfResidence aResidenceType)
    {
      ResidenceType = aResidenceType;
    }

    /// <summary>
    /// Default Constructor
    /// </summary>
    public Residence()
    {
    }

    /// <summary>
    /// Foreign key link to the policy
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int, ForeignKeyClassType = typeof(InsPolicy))]
    public virtual int PolicyLinkID
    {
      get { return m_policyLinkID; }
      set { m_policyLinkID = value; }
    }

    /// <summary>
    /// The type of residence. House, Townhouse, etc.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25, EnumerationType = typeof(TypeOfResidence))]
    public virtual TypeOfResidence ResidenceType
    {
      get { return m_residenceType; }
      set { m_residenceType = value; }
    }

    /// <summary>
    /// First part of the address
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.AddressLength)]
    public virtual string Address1
    {
      get { return m_address1; }
      set { m_address1 = value; }
    }

    /// <summary>
    /// Second part of the address
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.AddressLength)]
    public virtual string Address2
    {
      get { return m_address2; }
      set { m_address2 = value; }
    }

    /// <summary>
    /// Street number of the address
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 25)]
    public virtual string StreetNumber
    {
      get { return m_streetNumber; }
      set { m_streetNumber = value; }
    }

    /// <summary>
    /// Street name of the address
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 100)]
    public virtual string StreetName
    {
      get { return m_streetName; }
      set { m_streetName = value; }
    }

    /// <summary>
    /// street type of the residence (court, road, etc)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string StreetType
    {
      get { return m_streetType; }
      set { m_streetType = value; }
    }

    /// <summary>
    /// Apartment #
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string ApartmentNumber
    {
      get { return m_apartmentNumber; }
      set { m_apartmentNumber = value; }
    }

    /// <summary>
    /// City
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 75)]
    public virtual string City
    {
      get { return m_city; }
      set { m_city = value; }
    }

    /// <summary>
    /// State
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 50, EnumerationType = typeof(USState))]
    public virtual USState State
    {
      get { return m_state; }
      set { m_state = value; }
    }

    /// <summary>
    /// Zip Code 
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = StorageConstants.ZipCodeLength)]
    public virtual string ZipCode
    {
      get { return m_zipCode; }
      set { m_zipCode = value; }
    }

    /// <summary>
    /// County
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 75)]
    public virtual string County
    {
      get { return m_county; }
      set { m_county = value; }
    }

    /// <summary>
    /// Region
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 75)]
    public virtual string Region
    {
      get { return m_region; }
      set { m_region = value; }
    }

    /// <summary>
    /// Street Pre-Direction
    /// EX - NE 28th Street;
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string StreetPre
    {
      get { return m_streetPre; }
      set { m_streetPre = value; }
    }

    /// <summary>
    /// Street Post-Direction
    /// EX - 28th Street NE
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 20)]
    public virtual string StreetPost
    {
      get { return m_streetPost; }
      set { m_streetPost = value; }
    }

    /// <summary>
    /// Legal description of the property
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 500)]
    public virtual string LegalDescription
    {
      get { return m_legalDescription; }
      set { m_legalDescription = value; }
    }

    /// <summary>
    /// The type of policy
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 25, EnumerationType = typeof(InsuranceLine))]
    public virtual InsuranceLine PolicyType
    {
      get { return m_policyType; }
      set { m_policyType = value; }
    }

    /// <summary>
    /// Contains the latitude for the residence address.
    /// </summary>
		[PropertyStorage(System.Data.SqlDbType.Float)]
    public float Latitude
    {
      get { return m_latitude; }
      set { m_latitude = value; }
    }

    /// <summary>
    /// Contains the longitude for the residence address.
    /// </summary>
		[PropertyStorage(System.Data.SqlDbType.Float)]
    public float Longitude
    {
      get { return m_longitude; }
      set { m_longitude = value; }
    }


    /// <summary>
    /// Used by the ObjectSqlDbPersistence class to determine under what circumstances
    /// this object will be loaded from the database.
    /// </summary>
    /// <seealso>ConditionalLoadFieldName</seealso>
    /// <param name="checkValues0">The first value to check the condition of</param>
    /// <param name="checkValues1">The second value to check the condition of</param>
    /// <param name="parentField">The parent object of this current object</param>
    /// <returns>True if the state of the object matches that passed in the checkValues0,
    /// otherwise false</returns>
    public virtual bool ConditionalLoadCheck(object checkValues0, object checkValues1, object parentField)
    {
      bool tempResult = (ResidenceType.Equals(Enum.Parse(typeof(TypeOfResidence), checkValues0.ToString(), true)));
      tempResult = tempResult && (PolicyType.Equals(Enum.Parse(typeof(InsuranceLine), checkValues1.ToString(), true)));
      return tempResult;
    }

    /// <summary>
    /// The field to check against the conditional load value.
    /// </summary>
    /// <seealso>ConditionalLoadCheck</seealso>
    /// <returns>"ResidenceType"</returns>
    public virtual string ConditionalLoadFieldName()
    {
      return "ResidenceType,PolicyType";
    }

    private int m_policyLinkID = ITCConstants.InvalidNum;
    private TypeOfResidence m_residenceType = TypeOfResidence.MailingAddress;
    private string m_address1 = "";
    private string m_address2 = "";
    private string m_streetNumber = "";
    private string m_streetName = "";
    private string m_streetType = "";
    private string m_apartmentNumber = "";
    private string m_city = "";
    private USState m_state = USState.NoneSelected;
    private string m_zipCode = "";
    private string m_legalDescription = "";
    private string m_county = "";
    private string m_region = "";
    private string m_streetPre = "";
    private string m_streetPost = "";
    private InsuranceLine m_policyType = InsuranceLine.Homeowners;
    private float m_latitude;
    private float m_longitude;
  }
}
