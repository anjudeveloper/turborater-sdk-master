using System;

namespace TurboRater
{
  /// <summary>
  /// A base class from which all stored classes will inherit. This 
  /// defines the basic storage fields and interfaces for any class
  /// that needs to be persisted in a database table. Used as the base 
  /// for policies, drivers, cars, etc.
  /// </summary>
  [Serializable]
  public class BaseStoredRecord
  {

    [PropertyStorage(System.Data.SqlDbType.Int, IsSaveable = false, IsKeyField = true)]
    public virtual int RecordID
    {
      get { return m_recordID; }
      set { m_recordID = value; }
    }

    /// <summary>
    /// The date/time the record was first created in the database
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime OriginalSaveDate
    {
      get { return m_originalSaveDate; }
      set { m_originalSaveDate = value; }
    }

    /// <summary>
    /// Not used. This property is maintained only for backwards compatability
    /// with the Windows storage/TT2 mechanism
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool HasSecondaryData
    {
      get { return m_hasSecondaryData; }
      set { m_hasSecondaryData = value; }
    }

    /// <summary>
    /// Not used. This property is maintained only for backwards compatability
    /// with the Windows storage/TT2 mechanism
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool UseSecondaryData
    {
      get { return m_useSecondaryData; }
      set { m_useSecondaryData = value; }
    }

    /// <summary>
    /// Company data field...mimicks the CompanyData from the Windows world.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Text)]
    public virtual string CompanyDataStorage
    {
      get { return m_companyDataStorage; }
      set { m_companyDataStorage = value; }
    }

    /// <summary>
    /// Bridge data field.  Mimics CompanyDataStorage but is specific 
    /// to storing information for two way bridging.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Text)]
    public virtual string BridgeDataStorage
    {
      get { return m_bridgeDataStorage; }
      set { m_bridgeDataStorage = value; }
    }

    /// <summary>
    /// Mimics the NonStoredData field from the Windows world.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Text)]
    public virtual string NonStoredDataStorage
    {
      get { return m_nonStoredDataStorage; }
      set { m_nonStoredDataStorage = value; }
    }

    /// <summary>
    /// Company module contents field...mimics the CompanyModuleContents
    /// field from the Windows world.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Text)]
    public virtual string CompanyModuleContentsDataStorage
    {
      get { return m_companyModuleContentsDataStorage; }
      set { m_companyModuleContentsDataStorage = value; }
    }

    /// <summary>
    /// tag=value format. This stores any company-specific application
    /// information for web-based applications.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Text)]
    public virtual string WebAppStorage
    {
      get { return m_webAppStorage; }
      set { m_webAppStorage = value; }
    }

    /// <summary>
    /// If you specify a value here, then this value will be used
    /// as the name of the table for loading/saving/deleting operations.
    /// normally you should just use the class attribute to specify the table
    /// name, but sometimes you may need to override that value. in such cases,
    /// use this property.
    /// </summary>
    public virtual string OverrideTableName
    {
      get { return m_overrideTableName; }
      set { m_overrideTableName = value; }
    }

    /// <summary>
    /// Sets an application data field value.
    /// </summary>
    /// <param name="companyId">The company ID for the application.</param>
    /// <param name="fieldName">The name of the field to store.</param>
    /// <param name="value">The value to be stored in the field.</param>
    public virtual void SetApplicationData(int companyId, string fieldName, object value)
    {
      string tempString = m_webAppStorage;
      StringLib.SetTaggedField(ref tempString, fieldName + companyId, value);
      m_webAppStorage = tempString;
    }

    /// <summary>
    /// Retrieves an application data string from application data storage.
    /// </summary>
    /// <param name="companyId">The company ID for the application data.</param>
    /// <param name="fieldName">The name of the field to return.</param>
    /// <returns>The value of the field.</returns>
    public virtual string GetApplicationDataAsString(int companyId, string fieldName)
    {
      return StringLib.GetTaggedFieldAsString(m_webAppStorage, fieldName + companyId);
    }

    /// <summary>
    /// Retrieves an application data integer from application data storage.
    /// </summary>
    /// <param name="companyId">The company ID for the application data.</param>
    /// <param name="fieldName">The name of the field to return.</param>
    /// <param name="defaultValue">The default value to return if no data is found or is not a valid integer.</param>
    /// <returns>The value of the field.</returns>
    public virtual int GetApplicationDataAsInt(int companyId, string fieldName, int defaultValue)
    {
      return StringLib.GetTaggedFieldAsInteger(m_webAppStorage, fieldName + companyId, defaultValue);
    }

    /// <summary>
    /// Retrieves an application data double from application data storage.
    /// </summary>
    /// <param name="companyId">The company ID for the application data.</param>
    /// <param name="fieldName">The name of the field to return.</param>
    /// <param name="defaultValue">The default value to return if no data is found or is not a valid double.</param>
    /// <returns>The value of the field.</returns>
    public virtual double GetApplicationDataAsDouble(int companyId, string fieldName, double defaultValue)
    {
      return StringLib.GetTaggedFieldAsDouble(m_webAppStorage, fieldName + companyId, defaultValue);
    }

    /// <summary>
    /// Retrieves an application data boolean from application data storage.  Returns "true" for data values of 
    /// "true", "Yes", "Y" and integers greater than 0.
    /// </summary>
    /// <param name="companyId">The company ID for the application data.</param>
    /// <param name="fieldName">The name of the field to return.</param>
    /// <param name="defaultValue">The default value to return if no data is found or is not a valid boolean.</param>
    /// <returns>The value of the field.</returns>
    public virtual bool GetApplicationDataAsBoolean(int companyId, string fieldName, bool defaultValue)
    {
      return StringLib.GetTaggedFieldAsBoolean(m_webAppStorage, fieldName + companyId, defaultValue);
    }

    /// <summary>
    /// Retrieves an application DateTime integer from application data storage.
    /// </summary>
    /// <param name="companyId">The company ID for the application data.</param>
    /// <param name="fieldName">The name of the field to return.</param>
    /// <param name="defaultValue">The default value to return if no data is found or is not a valid DateTime.</param>
    /// <returns>The value of the field.</returns>
    public virtual DateTime GetApplicationDataAsDateTime(int companyId, string fieldName, DateTime defaultValue)
    {
      return StringLib.GetTaggedFieldAsDateTime(m_webAppStorage, fieldName + companyId, defaultValue);
    }

    /// <summary>
    /// Retrieves an application data Date from application data storage.
    /// </summary>
    /// <param name="companyId">The company ID for the application data.</param>
    /// <param name="fieldName">The name of the field to return.</param>
    /// <param name="defaultValue">The default value to return if no data is found or is not a valid DateTime.</param>
    /// <returns>The value of the field.</returns>
    public virtual DateTime GetApplicationDataAsDate(int companyId, string fieldName, DateTime defaultValue)
    {
      return StringLib.GetTaggedFieldAsDate(m_webAppStorage, fieldName + companyId, defaultValue);
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public BaseStoredRecord()
    {
    }

    /// <summary>
    /// constructor where you can pass in the overridden table name
    /// </summary>
    /// <param name="overrideTableName">the table name to use for storage, if you want to use
    /// something other than the default table name.</param>
    public BaseStoredRecord(string overrideTableName)
    {
      m_overrideTableName = overrideTableName;
    }

    private int m_recordID = ITCConstants.InvalidNum;
    private DateTime m_originalSaveDate = ITCConstants.InvalidDate;
    private bool m_hasSecondaryData;
    private bool m_useSecondaryData;
    private string m_companyDataStorage = String.Empty;
    private string m_bridgeDataStorage = String.Empty;
    private string m_nonStoredDataStorage = String.Empty;
    private string m_companyModuleContentsDataStorage = String.Empty;
    private string m_webAppStorage = String.Empty;
    private string m_overrideTableName = String.Empty;
  }
}
