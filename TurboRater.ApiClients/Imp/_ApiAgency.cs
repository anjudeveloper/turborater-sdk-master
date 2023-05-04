namespace TurboRater.ApiClients.Imp
{
  using global::System.Collections.Generic;
  using global::System.ComponentModel.DataAnnotations;

  /// <summary>
  /// Agency information suitable for use in Web API serialization.  Normal
  /// Agency objects have the [Serializable] attribute, which doesn't work
  /// well with Web API.  Both this and AgencyLocation implement IAgencyLocation.
  /// </summary>
  public class _ApiAgency : IAgency
  {
    /// <summary>
    /// The Agency record ID on the SQL server.
    /// </summary>
    [Key]
    public string AgencyID { get; set; }

    /// <summary>
    /// The name of the agency.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The agency website address.
    /// </summary>
    public string WebsiteAddress { get; set; }

    /// <summary>
    /// The agency email address.
    /// </summary>
    public string EmailAddress { get; set; }

    /// <summary>
    /// Address Line 1 of this agency.
    /// </summary>
    public string Address1 { get; set; }

    /// <summary>
    /// Address Line 2 of this agency.
    /// </summary>
    public string Address2 { get; set; }

    /// <summary>
    /// The City name of this agency.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// The State of this agency.
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// The ZIP Code of this agency.
    /// </summary>
    public string Zipcode { get; set; }

    /// <summary>
    /// The Phone Number of this agency.
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// The Alternate phone number of this agency.
    /// </summary>
    public string AlternatePhoneNumber { get; set; }

    /// <summary>
    /// The Fax number of this agency.
    /// </summary>
    public string FaxNumber { get; set; }

    /// <summary>
    /// Denotes the branch path the agency is pointed at. Used to construct URLs for the appropriate branch. 
    /// </summary>
    public string BranchPath { get; set; }

    /// <summary>
    /// Locations within the agency.
    /// </summary>
    public List<_ApiAgencyLocation> Locations { get; set; }
  }
}