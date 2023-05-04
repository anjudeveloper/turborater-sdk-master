using System;
using System.ComponentModel.DataAnnotations;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// An account within the ITC Rating API (an agency really not a rating account).
  /// </summary>
  public class ApiAccount
  {
    /// <summary>
    /// ITC AgencyId. This is the same as the AgencyId or AgencyGuid you'd find in the TurboRater account.
    /// </summary>
    [Key]
    public Guid AgencyId { get; set; }

    /// <summary>
    /// ITC UserId. This is the same as the UserId or UserGuid you'd find in the TurboRater account.
    /// </summary>
    private Guid? UserId { get; set; }

    /// <summary>
    /// Turborater profile record id that this account will use when rating through the API.
    /// This profile determines which companies are rated in which states for the account.
    /// </summary>
    private int ProfileRecordId { get; set; }

    /// <summary>
    /// Is this account using phone codes? If true, then this account will take advantage of 
    /// phone codes. This makes the phone code entry visible within TurboRater. If false,
    /// the account will not use phone codes and the menu item will not be visible.
    /// </summary>
    public bool AllowPhoneCode { get; set; }

    /// <summary>
    /// ITC TurboRater LocationId. If specified, this is the location that quotes will get 
    /// saved to when the quote is loaded up into TR via phone code.
    /// </summary>
    public Guid? LocationId { get; set; }
  }
}
