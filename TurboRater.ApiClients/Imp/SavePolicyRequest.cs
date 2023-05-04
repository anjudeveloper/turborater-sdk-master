//-----------------------------------------------------------------------
// <copyright file="SavePolicyRequest.cs" company="ITC">
//     Copyright ITC. All rights reserved.
// </copyright>
//--------------------------------------------
namespace TurboRater.ApiClients.Imp
{
  #region Includes
  using global::System;
  using global::System.ComponentModel.DataAnnotations;
  using global::System.ComponentModel;
  #endregion

  /// <summary>
  /// Object for Request to IMP
  /// </summary>
  public class SavePolicyRequest
  {
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
    ///  Gets or sets the user of policy.
    /// </summary>
    [StringLength(0, ErrorMessage = "This field is no longer used.  It has been replaced by UserId ")]
    public string User { get; set; }

    #endregion

    #region optional
    /// <summary>
    /// Gets or sets a value indicating whether policy is locked .
    /// </summary>
    public bool LockPolicyForUser { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether policy is allows override.
    /// </summary>
    public bool OverrideExistingLock { get; set; }

    /// <summary>
    /// Gets or sets users id of request.
    /// </summary>
    [DefaultValue(null)]
    public Guid? UserId { get; set; }

    /// <summary>
    /// Gets or sets a Location Id indicating whether policy is allows save.
    /// </summary>
    [DefaultValue(null)]
    public Guid? LocationId { get; set; }

    #endregion
  }
}
