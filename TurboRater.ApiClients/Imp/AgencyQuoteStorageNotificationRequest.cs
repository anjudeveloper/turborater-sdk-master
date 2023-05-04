using System.ComponentModel.DataAnnotations;

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Request object used to insert a new notification url for an agency 
  /// </summary>
  public class AgencyQuoteStorageNotificationRequest
  {
    /// <summary>
    /// the notification url you are trying to set up
    /// </summary>
    [Required]
    public string NotificationUrl { get; set; }

    /// <summary>
    /// the http method you would like the notication to be made in. 
    /// </summary>
    [Required]
    public string HttpMethod { get; set; }

    /// <summary>
    /// the delay before sending the notification. (used to allow market basket to finish saving before notifying) 
    /// </summary>
    public int NotificationDelay { get; set; }
  }
}
