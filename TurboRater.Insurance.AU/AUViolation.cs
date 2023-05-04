using System;

namespace TurboRater.Insurance.AU
{
  /// <summary>
  /// Represents a violation as it relates to an insurance policy/driver.
  /// This could be a speeding ticket, an at-fault accident, etc.
  /// </summary>
  /// <seealso cref="AUConstants">AUConstants has the violation 
  /// codes as integer values</seealso>
  /// <seealso cref="AUViolationList">AUViolationList</seealso>
  public class AUViolation : BaseStoredRecord
  {
    #region Private Vars
    private int m_driverLinkID = ITCConstants.InvalidNum;
    private bool m_atFault;
    private bool m_convicted;
    private DateTime m_convictedDate = ITCConstants.InvalidDate;
    private string m_location = "";
    private string m_locationCity = "";
    private string m_locationState = "";
    private bool m_mvrAppeal;
    private bool m_policeReport;
    private bool m_prayerForJudgement;
    private bool m_sameDay;
    private int m_violCode = ITCConstants.InvalidNum;
    private DateTime m_violDate = ITCConstants.InvalidDate;
    private int m_violPoints;
    private double m_violAttr1;
    private double m_violAttr2;
    private double m_violAttr3;
    private int m_customViolCode;
    private int m_secondaryViolPoints;
    private ViolationEntryStatus m_violationEntryStatus = ViolationEntryStatus.Agent;
    #endregion Private Vars

    #region Public Properties

    /// <summary>
    /// Links to the drivers table in the database
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int, ForeignKeyClassType = typeof(AUDriver))]
    public virtual int DriverLinkID
    {
      get { return m_driverLinkID; }
      set { m_driverLinkID = value; }
    }

    /// <summary>
    /// Is the violation the driver's fault?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool AtFault
    {
      get { return m_atFault; }
      set { m_atFault = value; }
    }

    /// <summary>
    /// Was the driver convicted of this violation?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Convicted
    {
      get { return m_convicted; }
      set { m_convicted = value; }
    }

    /// <summary>
    /// Date the driver was convicted of this violation
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime ConvictedDate
    {
      get { return m_convictedDate; }
      set { m_convictedDate = value; }
    }

    /// <summary>
    /// Location in which this violation took place
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 30)]
    public virtual string Location
    {
      get { return m_location; }
      set { m_location = value; }
    }

    /// <summary>
    /// City in which this violation took place
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 40)]
    public virtual string LocationCity
    {
      get { return m_locationCity; }
      set { m_locationCity = value; }
    }

    /// <summary>
    /// State in which this violation took place (2-char abbrev)
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 2)]
    public virtual string LocationState
    {
      get { return m_locationState; }
      set { m_locationState = value; }
    }

    /// <summary>
    /// Did the driver appeal this violation on their MVR?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool MVRAppeal
    {
      get { return m_mvrAppeal; }
      set { m_mvrAppeal = value; }
    }

    /// <summary>
    /// Does this violation come complete with a complementary
    /// police report?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool PoliceReport
    {
      get { return m_policeReport; }
      set { m_policeReport = value; }
    }

    /// <summary>
    /// Did the driver pray for judgement for this violation?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool PrayerForJudgement
    {
      get { return m_prayerForJudgement; }
      set { m_prayerForJudgement = value; }
    }

    /// <summary>
    /// Did this viol occur on the same day as another violation(s)?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool SameDay
    {
      get { return m_sameDay; }
      set { m_sameDay = value; }
    }

    /// <summary>
    /// ITC violation code. 
    /// </summary>
    /// <seealso cref="AUConstants">AUConstants has the violation 
    /// codes as integer values</seealso>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ViolCode
    {
      get { return m_violCode; }
      set { m_violCode = value; }
    }

    /// <summary>
    /// Date the violation took place
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime ViolDate
    {
      get { return m_violDate; }
      set { m_violDate = value; }
    }

    /// <summary>
    /// Number of points assigned to the driver as a result
    /// of this violation
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ViolPoints
    {
      get { return m_violPoints; }
      set { m_violPoints = value; }
    }

    /// <summary>
    /// Violation attributes (1). The meaning of each attribute varies
    /// by violation code
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double ViolAttr1
    {
      get { return m_violAttr1; }
      set { m_violAttr1 = value; }
    }

    /// <summary>
    /// Violation attributes (2). The meaning of each attribute varies
    /// by violation code
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double ViolAttr2
    {
      get { return m_violAttr2; }
      set { m_violAttr2 = value; }
    }

    /// <summary>
    /// Violation attributes (3). The meaning of each attribute varies
    /// by violation code
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Float)]
    public virtual double ViolAttr3
    {
      get { return m_violAttr3; }
      set { m_violAttr3 = value; }
    }

    /// <summary>
    /// ITC custom violation code. used by POS products mostly.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CustomViolCode
    {
      get { return m_customViolCode; }
      set { m_customViolCode = value; }
    }

    /// <summary>
    /// # of points the secondary rated company assigned for this violation
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int SecondaryViolPoints
    {
      get { return m_secondaryViolPoints; }
      set { m_secondaryViolPoints = value; }
    }

    /// <summary>
    /// Entry status for this particular violation object
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 1, EnumerationType = typeof(ViolationEntryStatus),
       EnumerationConstHolderType = typeof(AUConstants), EnumerationValues = "ViolationEntryStatusChars")]
    public virtual ViolationEntryStatus ViolationEntryStatus
    {
      get { return m_violationEntryStatus; }
      set { m_violationEntryStatus = value; }
    }

    #endregion Public Properties

    #region Constructors and Destructors
    public AUViolation()
    {
    }
    #endregion Constructors and Destructors
  }
}
