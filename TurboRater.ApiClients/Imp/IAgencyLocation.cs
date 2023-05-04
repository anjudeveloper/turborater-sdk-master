namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Agency location interface.
  /// </summary>
  public interface IAgencyLocation
  {
    /// <summary>
    /// String: The recordID of the Agency Location record
    /// </summary>
    string AgencyLocationID { get; set; }

    /// <summary>
    /// String: The Record ID of the Agency record the location belong to.
    /// </summary>
    string AgencyID { get; set; }

    /// <summary>
    /// foreign key link to the profile that this agency uses
    /// </summary>
    int ProfileLinkID { get; set; }

    /// <summary>
    /// Bool: Whether the location is active or not.
    /// </summary>
    bool Active { get; set; }

    /// <summary>
    /// String: The locatins description
    /// </summary>
    string Description { get; set; }

    /// <summary>
    /// String: The Address 1 of the agency location.
    /// </summary>
    string Address1 { get; set; }

    /// <summary>
    /// String: The Address 2 of the agency location.
    /// </summary>
    string Address2 { get; set; }

    /// <summary>
    /// String: The City name of the agency location.
    /// </summary>
    string City { get; set; }

    /// <summary>
    /// String: The state abbrev of the agency location.
    /// </summary>
    string State { get; set; }

    /// <summary>
    /// String: The zip code of the agency location.
    /// </summary>
    string Zipcode { get; set; }

    /// <summary>
    /// String: The phone number of the agency location.
    /// </summary>
    string PhoneNumber { get; set; }

    /// <summary>
    /// String: The Alternate phone number of the agency location.
    /// </summary>
    string AlternatePhoneNumber { get; set; }

    /// <summary>
    /// String: The Fax number of the agency location.
    /// </summary>
    string FaxNumber { get; set; }

    /// <summary>
    /// String: The tax ID of the agency location.
    /// </summary>
    string TaxID { get; set; }

    /// <summary>
    /// String: The producer code of the agency location.
    /// </summary>
    string ProducerCode { get; set; }

    /// <summary>
    /// Name of the location...we actually use the description on the TR GUI.
    /// </summary>
    string LocationName { get; set; }

    /// <summary>
    /// Producer Code for MGA/Broker sub-agents
    /// </summary>
    string SubAgentProducerCode { get; set; }

    /// <summary>
    /// ITC account number for MGA/Broker sub-agents.
    /// </summary>
    string SubAgentITCAccountNumber { get; set; }

    /// <summary>
    /// Latitude of the location for use in location based routing. 
    /// </summary>
    decimal Latitude { get; set; }

    /// <summary>
    /// Longitude of the location for use in location based routing. 
    /// </summary>
    decimal Longitude { get; set; }
  }
}