// -----------------------------------------------------------------------
// <copyright file="CompanyInfoRequest.cs" company="ITC">
// Copyright ITC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
// Class used for getting company information from the rate engine <c>api</c>.
// </summary>

namespace TurboRater.ApiClients.RateEngineApi
{
  using System;
  using System.Collections.Generic;
  using System.Text;
  using System.Xml.Serialization;

  /// <summary>
  /// Class used for getting company information from the rate engine <c>api</c>.
  /// </summary>
  [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/ITC.WebApiClients.RateEngineApi")]
  public class CompanyInfoRequest
  {
    /// <summary>
    /// Gets or sets The account name provided by ITC for accessing the rating service.
    /// </summary>
    public string AccountName { get; set; }

    /// <summary>
    /// Gets or sets The account number provided by ITC for accessing the rating service.
    /// </summary>
    public string AccountNumber { get; set; }

    /// <summary>
    /// Gets or sets The access ID provided by ITC for accessing the rating service.
    /// </summary>
    public string AccessID { get; set; }

    /// <summary>
    /// Gets or sets The state abbreviation you want company information for. 
    /// </summary>
    public string State { get; set; }

    /// <summary>
    /// Gets or sets The type of rates you want information for.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether or not to include the company questions.
    /// </summary>
    public bool IncludeCompanyQuestions { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether or not to include the company credits for HO.
    /// </summary>
    public bool? IncludeCompanyCredits { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether or not to include the company endorsements for HO.
    /// </summary>
    public bool? IncludeCompanyEndorsements { get; set; }

    /// <summary>
    /// The insurance line to include (HO for homeowner or PA for auto, ALL for all).
    /// </summary>
    public string InsuranceLine { get; set; }

    /// <summary>
    /// Optional. The agency whose information we're going to look up when determining if products are active
    /// in the agency's rating API company group. If this value is null, we won't set the Active flag
    /// of the response CompanyInfo objects.
    /// </summary>
    public Guid? AgencyId { get; set; }
  }
}
