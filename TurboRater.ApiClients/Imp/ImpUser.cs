//-----------------------------------------------------------------------
// <summary>
// A class that contains info about user for authentication. 
// </summary>
// <copyright file="ImpUser.cs" company="ITC">
//     Copyright ITC. All rights reserved.
// </copyright>
//--------------------------------------------
namespace TurboRater.ApiClients.Imp
{
  using global::System.ComponentModel.DataAnnotations;

  /// <summary>
  /// A class containing user info to authenticate. 
  /// </summary>
  public class ImpUser
  {
    /// <summary>
    /// Gets or sets IntegrationKey.
    /// </summary>
    /// <value>The integration key supplied by ITC.</value>
    [Required]
    public string IntegrationKey { get; set; }
  }
}