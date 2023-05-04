using System;
using System.ComponentModel.DataAnnotations;

namespace TurboRater.ApiClients
{
  /// <summary>
  /// Object for requesting a quote get unlocked in IMP. 
  /// </summary>
  public class UnlockPolicyRequest
  {
    /// <summary>
    /// Gets or sets ID for policy to Delete
    /// </summary>
    [Required]
    [Range(1, Int32.MaxValue, ErrorMessage = "The value must be greater than 0")]
    public int PolicyId { get; set; }

    /// <summary>
    /// Gets or sets Type of policy HO / AU
    /// </summary>
    [Required]
    public string InsuranceLine { get; set; }

    /// <summary>
    /// the quote state 
    /// </summary>
    public USState State { get; set; }

    /// <summary>
    /// The user id of the user making the request 
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// the location id of the user making the request
    /// </summary>
    public string LocationId { get; set; }
  }
}
