// -----------------------------------------------------------------------
// <summary>
// A class that contains wraps a validate policy request. 
// </summary>
// <copyright file="ValidatePolicyRequest.cs" company="ITC">
// Copyright ITC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace TurboRater.ApiClients.Imp
{
  using global::System.ComponentModel.DataAnnotations;
  using global::System.Text;

  /// <summary>
  /// A class that contains wraps a validate policy request. 
  /// </summary>
  public class ValidatePolicyRequest
  {
    /// <summary>
    ///  Initializes a new instance of the <see cref="ValidatePolicyRequest" /> class.
    /// </summary>
    /// <param name="policyData">TT2 data for policy.</param>
    /// <param name="lineOfInsurance">Line of insurance HO/AU</param>
    public ValidatePolicyRequest(string policyData, string lineOfInsurance)
    {
      this.PolicyData = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(policyData));
      this.State = USState.NoneSelected.ToString();
      this.InsuranceLine = lineOfInsurance;
    }

    #region required properties
    /// <summary>
    /// Gets or sets Data for policy submission
    /// FORMAT FOR POLICY DATA
    /// TT2 - AU/MC
    /// AccordXML
    /// XMLSerialize 
    /// </summary>
    [Required]
    public string PolicyData { get; set; }

    /// <summary>
    ///  Gets or sets Type of policy HO / AU etc.
    /// </summary>
    [Required]
    public string InsuranceLine { get; set; }

    /// <summary>
    ///  Gets or sets a Geographic State abbreviation the policy is in.
    /// </summary>
    [Required]
    public string State { get; set; }
    #endregion
  }
}
