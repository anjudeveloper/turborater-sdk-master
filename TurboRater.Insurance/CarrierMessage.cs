using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TurboRater.Insurance
{
  /// <summary>
  /// A message from the carrier.  Initially intended for marketing messages.
  /// </summary>
  [Serializable]
  public class CarrierMessage : BaseStoredRecord
  {
    /// <summary>
    /// Foreign key link back to the quote
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Int, ForeignKeyClassType = typeof(TurboRater.Insurance.InsQuote))]
    public virtual int QuoteLinkID
    {
      get { return m_quoteLinkID; }
      set { m_quoteLinkID = value; }
    }

    /// <summary>
    /// Text of the message
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 255)]
    public virtual string Text
    {
      get { return m_text; }
      set { m_text = value; }
    }

    /// <summary>
    /// Launch Uri of the message
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 255)]
    public virtual string LaunchUri
    {
      get { return m_uri; }
      set { m_uri = value; }
    }

    /// <summary>
    /// Description of the launch uri
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 255)]
    public virtual string LaunchUriDescription
    {
      get { return m_uriDescription; }
      set { m_uriDescription = value; }
    }

    /// <summary>
    /// Scope of the message. This would be the driver#, car#, etc.
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.Int)]
    public virtual int Scope
    {
      get { return m_scope; }
      set { m_scope = value; }
    }

    /// <summary>
    /// Scope type of the message. Policy, Driver, Car, etc
    /// </summary>
    [PropertyStorageAttribute(System.Data.SqlDbType.VarChar, Size = 25, EnumerationType = typeof(ItemScope))]
    public virtual ItemScope ScopeType
    {
      get { return m_scopeType; }
      set { m_scopeType = value; }
    }

    /// <summary>
    /// The parent list that owns this Message
    /// </summary>
    [XmlIgnore]
    public virtual CarrierMessageList List
    {
      get { return m_list; }
      set { m_list = value; }
    }

    private int m_quoteLinkID = ITCConstants.InvalidNum;
    private int m_scope;
    private ItemScope m_scopeType = ItemScope.Policy;
    private string m_text = string.Empty;
    private string m_uri;
    private string m_uriDescription;
    private CarrierMessageList m_list;
  }
}
