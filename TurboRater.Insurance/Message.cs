using System;
using System.Xml.Serialization;

namespace TurboRater.Insurance
{
    /// <summary>
  /// A message...usually a rating warning or error
  /// </summary>
  [Serializable]
  public class Message : BaseStoredRecord
  {
    /// <summary>
    /// Determines whether two Message instances are equal.
    /// </summary>
    /// <param name="obj">The Message to compare to the current message</param>
    /// <returns>true if the objects are equal, otherwise false</returns>
    public override bool Equals(object obj)
    {
      Message objMessage = obj as Message;
      if (obj == null)
        return false;
      return (this.GetHashCode() == objMessage.GetHashCode());
    }

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    /// <returns>A 32-bit signed integer hash code</returns>
    public override int GetHashCode()
    {
      return ((int)this.ScopeType.GetHashCode() ^ this.Scope.GetHashCode() ^
        this.Percentage.GetHashCode() ^ this.Amount.GetHashCode() ^ this.Code.GetHashCode() ^
        this.Text.ToUpper().GetHashCode() ^ this.WindowsCode.GetHashCode());
    }

    /// <summary>
    /// default constructor. Need one of these in order for the persistence code to function.
    /// </summary>
    public Message()
    {
    }

    /// <summary>
    /// Constructor that allows you to set some initial property values
    /// </summary>
    /// <param name="parentList">The MessageList object that owns this Message</param>
    /// <param name="messageType">Type of message (warning, error, discount, etc)</param>
    /// <param name="messageText">Text of the message</param>
    public Message(MessageList parentList, TypeOfMessage messageType, string messageText)
    {
      this.List = parentList;
      this.TypeOfMessage = messageType;
      this.Text = messageText;
    }

    /// <summary>
    /// Constructor that allows you to set all initial property values. Note that
    /// if you set the code and the text, the text gets tacked on after the standard
    /// message code text.
    /// </summary>
    /// <param name="parentList">The MessageList object that owns this Message</param>
    /// <param name="messageType">Type of message (warning, error, discount, etc)</param>
    /// <param name="messageText">Text of the message</param>
    /// <param name="scope">Scope of the message (driver#, car#, etc)</param>
    /// <param name="scopeType">Type of scope (policy, driver, car etc)</param>
    /// <param name="percentage">Percentage applied for message</param>
    /// <param name="amount">Premium change amount applied for the message</param>
    /// <param name="code">Standardized message code (if any)</param>
    public Message(MessageList parentList, TypeOfMessage messageType, string messageText,
      int scope, ItemScope scopeType, double percentage, double amount, StandardMessage code)
    {
      this.List = parentList;
      this.TypeOfMessage = messageType;
      this.Scope = scope;
      this.ScopeType = scopeType;
      this.Percentage = percentage;
      this.Amount = amount;
      this.Code = code;
      this.Text = InsConstants.StandardMessageTexts[(int)this.Code];
      this.Text += messageText;
    }

    /// <summary>
    /// Constructor that allows you to set a standard message code, which will in turn
    /// set the message text for you.
    /// </summary>
    /// <param name="parentList">The MessageList object that owns this Message</param>
    /// <param name="messageType">Type of message (warning, error, discount, etc)</param>
    /// <param name="scope">Scope of the message (driver#, car#, etc)</param>
    /// <param name="scopeType">Type of scope (policy, driver, car etc)</param>
    /// <param name="percentage">Percentage applied for message</param>
    /// <param name="amount">Premium change amount applied for the message</param>
    /// <param name="code">Standardized message code (if any)</param>
    public Message(MessageList parentList, TypeOfMessage messageType, int scope, ItemScope scopeType,
      double percentage, double amount, StandardMessage code)
    {
      this.List = parentList;
      this.TypeOfMessage = messageType;
      this.Scope = scope;
      this.ScopeType = scopeType;
      this.Percentage = percentage;
      this.Amount = amount;
      this.Code = code;
      this.Text = InsConstants.StandardMessageTexts[(int)this.Code];
    }


    /// <summary>
    /// Constructor that allows you to set the windows code of the message.  This
    /// is needed mostly for importing from the rate engine then exporting to non
    /// windows based bridging.  It also defaults the StandardMessage code to 
    /// NoStandardCode.
    /// </summary>
    /// <param name="parentList">The MessageList object that owns this Message.</param>
    /// <param name="messageType">Type of message. (warning, error, discount, etc)</param>
    /// <param name="messageText">Text of the message</param>
    /// <param name="scope">Scope of the message. (driver#, car#, etc)</param>
    /// <param name="scopeType">Type of scope. (policy, driver, car etc)</param>
    /// <param name="percentage">Percentage applied for message.</param>
    /// <param name="amount">Premium change amount applied for the message.</param>
    /// <param name="windowsCode"></param>
    public Message(MessageList parentList, TypeOfMessage messageType, string messageText,
      int scope, ItemScope scopeType, double percentage, double amount, int windowsCode)
    {
      this.List = parentList;
      this.TypeOfMessage = messageType;
      this.Scope = scope;
      this.ScopeType = scopeType;
      this.Percentage = percentage;
      this.Amount = amount;
      this.Text = messageText;
      this.WindowsCode = windowsCode;
    }


    /// <summary>
    /// Foreign key link to the policy
    /// </summary>
    public virtual int PolicyLinkID
    {
      get { return m_policyLinkID; }
      set { m_policyLinkID = value; }
    }

    /// <summary>
    /// Type of message. Warning, error, etc.
    /// </summary>
    public virtual TypeOfMessage TypeOfMessage
    {
      get { return m_typeOfMessage; }
      set { m_typeOfMessage = value; }
    }

    /// <summary>
    /// Text of the message
    /// </summary>
    public virtual string Text
    {
      get { return m_text; }
      set { m_text = value; }
    }

    /// <summary>
    /// Scope of the message. This would be the driver#, car#, etc.
    /// </summary>
    public virtual int Scope
    {
      get { return m_scope; }
      set { m_scope = value; }
    }

    /// <summary>
    /// Scope type of the message. Policy, Driver, Car, etc
    /// </summary>
    public virtual ItemScope ScopeType
    {
      get { return m_scopeType; }
      set { m_scopeType = value; }
    }

    /// <summary>
    /// Percentage applied for message. Applies to discounts, surcharges, etc.
    /// Note that this does not affect rating; it is used only for display purposes.
    /// </summary>
    public virtual double Percentage
    {
      get { return m_percentage; }
      set { m_percentage = value; }
    }

    /// <summary>
    /// Amount the premium decreased due to the message. Applies to discounts, surcharges, etc.
    /// Note that this does not affect rating; it is used only for display purposes.
    /// </summary>
    public virtual double Amount
    {
      get { return m_amount; }
      set { m_amount = value; }
    }

    /// <summary>
    /// Standardized code of the message. Currently used by real time rating.
    /// </summary>
    public virtual StandardMessage Code
    {
      get { return m_code; }
      set { m_code = value; }
    }

    /// <summary>
    /// Windows code of the message.  This is being used mostly for importing and
    /// exporting information between the rate engine and the windows products.
    /// </summary>
    public virtual int WindowsCode
    {
      get { return m_windowsCode; }
      set { m_windowsCode = value; }
    }

    /// <summary>
    /// Date/time of the creation of this message object.
    /// </summary>
    public virtual DateTime DateCreated
    {
      get { return m_dateCreated; }
      set { m_dateCreated = value; }
    }

    /// <summary>
    /// The parent list that owns this Message
    /// </summary>
    [XmlIgnore]
    public virtual MessageList List
    {
      get { return m_list; }
      set { m_list = value; }
    }

    private int m_policyLinkID = ITCConstants.InvalidNum;
    private TypeOfMessage m_typeOfMessage = TypeOfMessage.Warning;
    private string m_text = "";
    private int m_scope;
    private ItemScope m_scopeType = ItemScope.Policy;
    private double m_percentage;
    private double m_amount;
    private DateTime m_dateCreated = DateTime.Now;
    private StandardMessage m_code = StandardMessage.NoStandardCode;
    private MessageList m_list;
    private int m_windowsCode;
  }
}
