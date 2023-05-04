using System;
using System.Collections.Generic;
using System.Text;

namespace TurboRater.Insurance.DataTransformation
{
  /// <summary>
  /// Contains constants related to Integration Customization bridging.
  /// </summary>
  class IntegrationCustomizationConstants
  {
    /// <summary>
    /// The number of connections that will be attempted if there is a connection failure.
    /// </summary>
    public const int MaxConnectionAttempts = 3;

    /// <summary>
    /// The amount of time we're willing to wait, in milliseconds, for
    /// a response.
    /// </summary>
    public const int ConnectionTimeout = 60000;

    /// <summary>
    /// The timeout, in milliseconds, between connection retries if there is a
    /// connection failure to the server.
    /// </summary>
    public const int ConnectionRetryTimeout = 1000;

    /// <summary>
    /// Hiding the Default Constructor.
    /// </summary>
    private IntegrationCustomizationConstants()
    {
    }
  }

  /// <summary>
  /// The type of data contained in a bridge transaction
  /// </summary>
  public enum BridgeContentType
  {
    TT2,
    Custom,
    XML,
    AL3,
    TBR,  // TBR = NetQuote
    IntegrationCustomization,
    TAM  // TAM = Applied Flat File 
  }
}
