using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SdkRater
{
  /// <summary>
  /// User/machine specific data for local storage.
  /// </summary>
  public class ApiUserData
  {
    /// <summary>
    /// Reference to the currently loaded user.
    /// </summary>
    public static ApiUserData Current { get; set; }

    /// <summary>
    /// Test Imp Account Id
    /// </summary>
    public string ImpAccountID { get; set; }

    /// <summary>
    /// Test Imp Integration Key
    /// </summary>
    public string ImpIntegrationKey { get; set; }

    /// <summary>
    /// Test ITC Rate Engine Account Id
    /// </summary>
    public string ItcRateEngineAccountID { get; set; }

    /// <summary>
    /// Test Agency ID used during LoadPolicy, used to build the company request
    /// </summary>
    public string TestAgencyID { get; set; }

    /// <summary>
    /// Test Account Name used during LoadPolicy, used to build the company request
    /// </summary>
    public string TestAccountName { get; set; }

    /// <summary>
    /// Live Imp Account Id
    /// </summary>
    public string LiveImpAccountID { get; set; }

    /// <summary>
    /// Live Imp Integration Key
    /// </summary>
    public string LiveImpIntegrationKey { get; set; }

    /// <summary>
    /// Live ITC Rate Engine Account Id
    /// </summary>
    public string LiveItcRateEngineAccountID { get; set; }

    /// <summary>
    /// Live Agency ID used during LoadPolicy, used to build the company request
    /// </summary>
    public string LiveAgencyID { get; set; }

    /// <summary>
    /// Live Account Name used during LoadPolicy, used to build the company request
    /// </summary>
    public string LiveAccountName { get; set; }

    /// <summary>
    /// Authentication type, select between Basic and Bearer
    /// </summary>
    public string AuthenticationType { get; set; }

    /// <summary>
    /// Distinguish between hitting the Live and Test rating environments.
    /// </summary>
    public bool LiveSite { get; set; }

    /// <summary>
    /// If true, they have successfully validated and bridged at some point.
    /// </summary>
    public bool ValidCredentials { get; set; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ApiUserData()
    {
      ImpAccountID = String.Empty;
      ImpIntegrationKey = String.Empty;
      TestAccountName = String.Empty;
      TestAgencyID = String.Empty;
      LiveImpAccountID = String.Empty;
      LiveImpIntegrationKey = String.Empty;
      ItcRateEngineAccountID = String.Empty;
      LiveAccountName = String.Empty;
      LiveAgencyID = String.Empty;
      AuthenticationType = String.Empty;
    }
  }
}
