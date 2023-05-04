using System;

namespace TurboRater.Insurance
{
  /// <summary>
  /// The quote note class. These are user-entered notes on the quote.
  /// </summary>
  [Serializable]
  public class InsNote : BaseStoredRecord
  {

    private string m_description = "";
    private string m_whoEntered = "";
    private DateTime m_dateEntered = ITCConstants.InvalidDate;
    private bool m_reminder;
    private int m_quoteLinkID = ITCConstants.InvalidNum;
    private string m_modifiedBy = "";
    private DateTime m_dateCreated = ITCConstants.InvalidDate;
    private bool m_systemGenerated;

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
    /// The description of the note.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 500)]
    public virtual string Description
    {
      get { return m_description; }
      set { m_description = value; }
    }

    /// <summary>
    /// Who entered / created this note? The user name.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 105)]
    public virtual string WhoEntered
    {
      get { return m_whoEntered; }
      set { m_whoEntered = value; }
    }

    /// <summary>
    /// Who modified this note? The user name.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.VarChar, Size = 105)]
    public virtual string ModifiedBy
    {
      get { return m_modifiedBy; }
      set { m_modifiedBy = value; }
    }

    /// <summary>
    /// Date the note was entered
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime DateEntered
    {
      get { return m_dateEntered; }
      set { m_dateEntered = value; }
    }

    /// <summary>
    /// Should this note give a reminder?
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool Reminder
    {
      get { return m_reminder; }
      set { m_reminder = value; }
    }

    /// <summary>
    /// Date the note was created
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.DateTime)]
    public virtual DateTime DateCreated
    {
      get { return m_dateCreated; }
      set { m_dateCreated = value; }
    }

    /// <summary>
    /// Identifies whether or not the note was auto-inserted by the system
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Bit)]
    public virtual bool SystemGenerated
    {
      get { return m_systemGenerated; }
      set { m_systemGenerated = value; }
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public InsNote()
    {
    }
  }
}
