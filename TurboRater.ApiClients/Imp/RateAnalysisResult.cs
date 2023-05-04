using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Rating results for a policy
  /// </summary>
  public class RateAnalysisResult
  {
    /// <summary>
    /// Gets or sets Total premium.
    /// </summary>
    public double? TotalPremium { get; set; }

    /// <summary>
    /// Gets or sets Down payment amount.
    /// </summary>
    public double? DownPayment { get; set; }

    /// <summary>
    /// Gets or sets Individual payment amounts.
    /// </summary>
    public double? PaymentAmount { get; set; }

    /// <summary>
    /// Gets or sets Policy term.
    /// </summary>
    public int? Term { get; set; }

    /// <summary>
    /// Gets or sets Was the policy purchased/bridged?
    /// </summary>
    public bool? Purchased { get; set; }

    /// <summary>
    /// Gets or sets Date/time rated.
    /// </summary>
    public DateTime? RatedDate { get; set; }

    /// <summary>
    /// Gets or sets ITC company id of the rating company.
    /// </summary>
    public int? CompanyId { get; set; }

    /// <summary>
    /// Gets or sets Policy fee charged.
    /// </summary>
    public double? PolicyFee { get; set; }

    /// <summary>
    /// Gets or sets Number of payments quoted.
    /// </summary>
    public int? NumOfPayments { get; set; }

    /// <summary>
    /// Gets or sets Percent of down payment
    /// </summary>
    public double? PercentDown { get; set; }

    /// <summary>
    /// Gets or sets Total of all payments made.
    /// </summary>
    public double? PaymentTotal { get; set; }

    /// <summary>
    /// Gets or sets Amount financed.
    /// </summary>
    public double? FinanceAmount { get; set; }

    /// <summary>
    /// Gets or sets Rated company tier.
    /// </summary>
    public string Tier { get; set; }

    /// <summary>
    /// Gets or sets Rated company program.
    /// </summary>
    public string Program { get; set; }

    /// <summary>
    /// Gets or sets rated company name.
    /// </summary>
    public string CompanyName { get; set; }

    /// <summary>
    /// Gets or sets Expiration date of the policy
    /// </summary>
    public DateTime? ExpirationDate { get; set; }

    /// <summary>
    /// Gets or sets The rate iteration of this particular rate result record
    /// </summary>
    public int? RateIteration { get; set; }

    /// <summary>
    /// Gets or sets Is the policy bound?
    /// </summary>
    public bool? Bound { get; set; }

    /// <summary>
    /// Gets or sets the source system of the rate as a string
    /// </summary>
    public string RateSource { get; set; }

    /// <summary>
    /// Gets or sets the details about the source system of the rate as a string
    /// </summary>
    public string RateSourceDetail { get; set; }

    /// <summary>
    /// Gets or sets a list of cars that were rated
    /// </summary>
    public List<RateAnalysisCar> Cars { get; set; }
  }

}
