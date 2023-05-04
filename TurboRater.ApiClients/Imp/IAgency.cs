namespace TurboRater.ApiClients.Imp
{
  using global::System.ComponentModel.DataAnnotations;

  /// <summary>
  /// The Remote Storage Agency Class. Encompasses Users and locations under that 
  /// Agency.
  /// </summary>
  public interface IAgency
  {
    /// <summary>
    /// The Agency record ID on the SQL server.
    /// </summary>
    [Key]
    string AgencyID { get; set; }

    /// <summary>
    /// The name of the agency.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// The agency website address.
    /// </summary>
    string WebsiteAddress { get; set; }

    /// <summary>
    /// The agency email address.
    /// </summary>
    string EmailAddress { get; set; }

    /// <summary>
    /// Address Line 1 of this agency.
    /// </summary>
    string Address1 { get; set; }

    /// <summary>
    /// Address Line 2 of this agency.
    /// </summary>
    string Address2 { get; set; }

    /// <summary>
    /// The City name of this agency.
    /// </summary>
    string City { get; set; }

    /// <summary>
    /// The State of this agency.
    /// </summary>
    string State { get; set; }

    /// <summary>
    /// The ZIP Code of this agency.
    /// </summary>
    string Zipcode { get; set; }

    /// <summary>
    /// The Phone Number of this agency.
    /// </summary>
    string PhoneNumber { get; set; }

    /// <summary>
    /// The Alternate phone number of this agency.
    /// </summary>
    string AlternatePhoneNumber { get; set; }

    /// <summary>
    /// The Fax number of this agency.
    /// </summary>
    string FaxNumber { get; set; }

    /// <summary>
    /// Denotes the branch path the agency is pointed at. Used to construct URLs for the appropriate branch. 
    /// </summary>
    string BranchPath { get; set; }
  }
}