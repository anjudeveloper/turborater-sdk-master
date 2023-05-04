
namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// Bumping options for rating with our rating API.
  /// </summary>
  public enum RateEngineBumpingEnum 
  {
    bNoBumping,
    bBumpUp,
    bBumpDown
  }

  /// <summary>
  /// constants used for dealing with the rate engine api.
  /// </summary>
  public sealed class RateEngineApiConstants
  {
    /// <summary>
    /// Base URL of the live service.
    /// </summary>
    public const string BaseUrlLive = "https://www.itcratingservices.com/webservices/itcrateengineapi/";

    /// <summary>
    /// Base URL of the test service.
    /// </summary>
    public const string BaseUrlTest = "https://ratingqa.itcdataservices.com/webservices/itcrateengineapi/";

  }
}
