using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.Imp
{
  public class PolicyAuditModel
  {
    /// <summary>
    /// quote unique identifier
    /// </summary>
    public Guid QuoteUID { get; set; }

    /// <summary>
    /// agency id of of the quote
    /// </summary>
    public Guid AgencyId { get; set; }

    /// <summary>
    /// current location 
    /// </summary>
    public Guid LocationId { get; set; }

    /// <summary>
    /// current user doing something
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// datetime stamp of action
    /// </summary>
    public DateTime AuditDate { get; set; }

    /// <summary>
    /// ip 6 address
    /// </summary>
    public byte[] UserIP6Addr { get; set; }

    /// <summary>
    /// source product - TWE, TRfW, RateAPI etc.
    /// </summary>
    public TurboRater.Insurance.SourceProduct SourceProduct { get; set; }
    /// <summary>
    /// type of action
    /// </summary>
    public AuditAction PolicyAction { get; set; }

    /// <summary>
    /// simple description, like success/failure etc
    /// </summary>
    public string ActionDescription { get; set; }

    /// <summary>
    /// details, bridge details, policy changes etc
    /// </summary>
    public List<AuditDetail> AuditDetails { get; set; }
  }

  /// <summary>
  /// enum of details
  /// </summary>
  public enum AuditDetailType
  {
    [Description("Note")]
    Note,
    [Description("Policy Change")]
    PolicyChange,
    [Description("Bridge Details")]
    BridgeDetails,
    [Description("Rate Details")]
    RateDetails
  }

  /// <summary>
  /// container for detail item
  /// </summary>
  public class AuditDetail
  {
    public AuditDetailType DetailType { get; set; }

    /// <summary>
    /// for quote save, list of changes by field name, old, and new value - like vehicle 2 - old year 1998, new year 2014, old model Toyota, new Model Subaru, etc..
    /// </summary>
    public List<AuditDetailChangeItem> ChangeItems { get; set; }

    /// <summary>
    /// name value pairs for details, like bridged to company x, premium $400, down pay $100 etc. or rate compare data items
    /// </summary>
    public Dictionary<string, string> DetailItems { get; set; }
  }

  /// <summary>
  /// change item with field, old, and new values
  /// </summary>
  public class AuditDetailChangeItem
  {
    public string FieldName { get; set; }

    public string OldValue { get; set; }

    public string NewValue { get; set; }
  }

  /// <summary>
  /// enum of LogQuoteActivity actions
  /// </summary>
  public enum AuditAction
  {
    [Description("Create Quote")]
    CreateQuote,
    [Description("Save Quote")]
    SaveQuote,
    [Description("Open Quote")]
    OpenQuote,
    [Description("Order Prefill")]
    OrderPrefill,
    [Description("Order MVR")]
    OrderMVR,
    [Description("Delete Quote")]
    DeleteQuote,
    [Description("Bridge Quote")]
    BridgeQuote,
    [Description("Rate Quote")]
    RateQuote,
    [Description("Address Verification")]
    VerifyAddress
  }
}
