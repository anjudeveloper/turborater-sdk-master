using System;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// Wrapper for an ITCRateEngineRequest with additional properties.
  /// </summary>
  public class ITCRateEngineRequestWrapper
  {
    /// <summary>
    /// The actual request.
    /// </summary>
    public ITCRateEngineRequest Request { get; set; }

    /// <summary>
    /// The request expiration date/time.
    /// </summary>
    public DateTime Expiration { get; set; }
  }
}
