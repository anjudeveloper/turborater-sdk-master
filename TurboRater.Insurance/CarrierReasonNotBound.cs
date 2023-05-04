using System;
using TurboRater;
using TurboRater.Insurance;

namespace TurboRater.Insurance
{
  /// <summary>
  /// A message from the carrier.  Initially intended for marketing messages.
  /// </summary>
  [Serializable]
  public class CarrierReasonNotBound : BaseStoredRecord
  {
    /// <summary>
    /// Foreign key link back to the quote
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int, ForeignKeyClassType = typeof(InsQuote))]
    public virtual int QuoteLinkID
    {
      get { return m_quoteLinkID; }
      set { m_quoteLinkID = value; }
    }

    /// <summary>
    /// The quoting company's company id#
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int CompanyID
    {
      get { return m_CompanyID; }
      set { m_CompanyID = value; }
    }

    /// <summary>
    /// The quoting company's program id#
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int)]
    public virtual int ProgramID
    {
      get { return m_programID; }
      set { m_programID = value; }
    }

    /// <summary>
    /// Reason the carrier was not bound.
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string ReasonNotBound
    {
      get { return m_reasonNotBound; }
      set { m_reasonNotBound = value; }
    }

    /// <summary>
    /// The carrier name.
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 50)]
    public virtual string CompanyName
    {
      get { return m_companyName; }
      set { m_companyName = value; }
    }

    /// <summary>
    /// Carrier rate effective date.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime RateEffectiveDate
    {
      get { return this.m_rateEffectiveDate; }
      set { this.m_rateEffectiveDate = value; }
    }

    private int m_quoteLinkID = ITCConstants.InvalidNum;
    private int m_CompanyID;
    private int m_programID;
    private string m_reasonNotBound = string.Empty;
    private string m_companyName = string.Empty;
    private DateTime m_rateEffectiveDate = ITCConstants.InvalidDate;
  }
}
