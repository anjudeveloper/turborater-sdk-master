using System;
using System.Data;

namespace TurboRater.Insurance.AU
{
  /// <summary>
  /// Repreents a DMV action taken against a driver
  /// This could be a license suspension or expiration
  /// </summary>
  /// <seealso cref="AUConstants">AUConstants has the
  /// definition of the DMV action types</seealso>
  public class DMVAction : BaseStoredRecord
  {
    private int m_driverLinkID = ITCConstants.InvalidNum;
    private DMVActions m_action = DMVActions.None;
    private DateTime m_dmvActionDate = ITCConstants.InvalidDate;
    private DateTime m_dmvReinstatementDate = ITCConstants.InvalidDate;
    private ViolationEntryStatus m_dmvActionEntryStatus = ViolationEntryStatus.Agent;

    /// <summary>
    /// Foreign key link to the driver object that owns this DMVAction object
    /// </summary>
    [PropertyStorage(SqlDbType.Int, ForeignKeyClassType = typeof(AUDriver))]
    public int DriverLinkID
    {
      get { return m_driverLinkID; }
      set { m_driverLinkID = value; }
    }

    /// <summary>
    /// DMV Action taken
    /// </summary>
    [PropertyStorage(SqlDbType.VarChar, Size = 25, EnumerationType = typeof(DMVActions))]
    public DMVActions Action
    {
      get { return m_action; }
      set { m_action = value; }
    }

    /// <summary>
    /// Date on which the DMV action was taken
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public DateTime DMVActionDate
    {
      get { return m_dmvActionDate; }
      set { m_dmvActionDate = value; }
    }

    /// <summary>
    /// Date on which the DMV reinstated/renewed the driver
    /// </summary>
    [PropertyStorage(SqlDbType.DateTime)]
    public DateTime DMVReinstatementDate
    {
      get { return m_dmvReinstatementDate; }
      set { m_dmvReinstatementDate = value; }
    }

    /// <summary>
    /// Entry status for this particular suspension object
    /// </summary>
    public ViolationEntryStatus DMVActionEntryStatus
    {
      get { return m_dmvActionEntryStatus; }
      set { m_dmvActionEntryStatus = value; }
    }
  }
}
