namespace TurboRater.ApiClients.Imp
{
  using global::System.ComponentModel.DataAnnotations;

  /// <summary>
  /// Location information suitable for use in Web API serialization.  Normal
  /// AgencyLocations have the [Serializable] attribute, which doesn't work
  /// well with Web API.  Both this and AgencyLocation implement IAgencyLocation.
  /// </summary>
  public class _ApiAgencyLocation : IAgencyLocation
  {
    /// <summary>
    /// String: The recordID of the Agency Location record
    /// </summary>
    [Key]
    public string AgencyLocationID { get; set; }

    /// <summary>
    /// String: The Record ID of the Agency record the location belong to.
    /// </summary>
    public string AgencyID { get; set; }

    /// <summary>
    /// foreign key link to the profile that this agency uses
    /// </summary>
    public int ProfileLinkID { get; set; }

    /// <summary>
    /// Bool: Whether the location is active or not.
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// String: The locatins description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// String: The Address 1 of the agency location.
    /// </summary>
    public string Address1 { get; set; }

    /// <summary>
    /// String: The Address 2 of the agency location.
    /// </summary>
    public string Address2 { get; set; }

    /// <summary>
    /// String: The City name of the agency location.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// String: The state abbrev of the agency location.
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// String: The zip code of the agency location.
    /// </summary>
    public string Zipcode { get; set; }

    /// <summary>
    /// String: The phone number of the agency location.
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// String: The Alternate phone number of the agency location.
    /// </summary>
    public string AlternatePhoneNumber { get; set; }

    /// <summary>
    /// String: The Fax number of the agency location.
    /// </summary>
    public string FaxNumber { get; set; }

    /// <summary>
    /// String: The tax ID of the agency location.
    /// </summary>
    public string TaxID { get; set; }

    /// <summary>
    /// String: The producer code of the agency location.
    /// </summary>
    public string ProducerCode { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string LocationName { get; set; }

    /// <summary>
    /// Producer Code for MGA/Broker sub-agents
    /// </summary>
    public string SubAgentProducerCode { get; set; }

    /// <summary>
    /// ITC account number for MGA/Broker sub-agents.
    /// </summary>
    public string SubAgentITCAccountNumber { get; set; }

    /// <summary>
    /// Latitude of the location for use in location based routing. 
    /// </summary>
    public decimal Latitude { get; set; }

    /// <summary>
    /// Longitude of the location for use in location based routing. 
    /// </summary>
    public decimal Longitude { get; set; }
  }
}
