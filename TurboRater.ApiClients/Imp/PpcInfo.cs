namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Represents protection class information for a property.
  /// </summary>
  public class PpcInfo
  {
    /// <summary>
    /// The state in which this residence is located.
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// Zip code.
    /// </summary>
    public string ZipCode { get; set; }

    /// <summary>
    /// City.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Street prefix. Ex: W 10th st (W would be the Pre)
    /// </summary>
    public string StreetPrefix { get; set; }

    /// <summary>
    /// Street postfix (suffix). Ex: 107th Ave W (W would be the Post).
    /// </summary>
    public string StreetPost { get; set; }

    /// <summary>
    /// Street type. Ex: LN for Lane, DR for Drive, etc.
    /// </summary>
    public string StreetType { get; set; }

    /// <summary>
    /// Occupational Exposure Band.
    /// </summary>
    public string OccupationalExposureBand { get; set; }

    /// <summary>
    /// Protection class.
    /// </summary>
    public string Ppc { get; set; }

    /// <summary>
    /// Fire Protection Area.
    /// </summary>
    public string FireProtectionArea { get; set; }

    /// <summary>
    /// Responding fire station.
    /// </summary>
    public string RespondingFireStation { get; set; }

    /// <summary>
    /// Alternate protection class.
    /// </summary>
    public string AlternatePpc { get; set; }

    /// <summary>
    /// Percentage match. Only used when there was no exact property match.
    /// </summary>
    public double? PercentMatch { get; set; }
  }
}
