using System;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// Wrapper for an ITCRateEngineResponse with additional properties.
  /// </summary>
  public class ITCRateEngineResponseWrapper
  {
    /// <summary>
    /// The actual response.
    /// </summary>
    public ITCRateEngineResponseBase Response { get; set; }

    /// <summary>
    /// The location for saving the policy.
    /// </summary>
    public Guid? LocationId { get; set; }

    /// <summary>
    /// The user for saving the user.
    /// </summary>
    public Guid? UserId { get; set; }

    /// <summary>
    /// If there is a lead source defined for this agency/account, this is it.
    /// </summary>
    public string LeadSource { get; set; }
  }
}
