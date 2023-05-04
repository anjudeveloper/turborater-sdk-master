//-----------------------------------------------------------------------
// <copyright file="DeletePolicyRequest.cs" company="ITC">
//     Copyright ITC. All rights reserved.
// </copyright>
//--------------------------------------------
namespace TurboRater.ApiClients.Imp
{
  #region Includes
  using global::System;
  using global::System.ComponentModel.DataAnnotations;
  #endregion

  /// <summary>
  /// Object for Request to IMP
  /// </summary>
  public class DeletePolicyRequest
  {
    #region required properties
    /// <summary>
    /// Gets or sets ID for policy to Delete
    /// </summary>
    [Required]
    [Range(1, Int32.MaxValue, ErrorMessage = "The value must be greater than 0")]
    public int PolicyId { get; set; }

    /// <summary>
    /// Gets or sets Type of policy HO / AU
    /// </summary>
    [Required]
    public string InsuranceLine { get; set; }

    /// <summary>
    ///  Gets or sets a Location Id indicating whether policy is allows save.
    /// </summary>
    public Guid? LocationId { get; set; }

    #endregion
  }
}
