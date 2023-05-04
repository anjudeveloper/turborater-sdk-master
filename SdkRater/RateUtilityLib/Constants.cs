using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboRater.ApiClients.Imp;

namespace SdkRater.RateUtilityLib
{
  public class Constants
  {
    /// <summary>
    /// Thread timeout in seconds
    /// </summary>
    public static TimeSpan RateTimeout
    {
      get { return TimeSpan.FromSeconds(30); }
    }

    /// <summary>
    /// Determine basic or bearer authentication
    /// </summary>
    public static bool BearerAuthorization { get; set; }
    
    /// <summary>
    /// URL to hit IMP with
    /// </summary>
    public static string ImpConstantsUrl
    {
      get { return LiveSite ? ImpConstants.LiveBaseUrl : ImpConstants.TestBaseUrl; }
    }

    /// <summary>
    /// Imp Account Id for the test site
    /// </summary>
    public static string TestImpAccountId { get; set; }

    /// <summary>
    /// Imp Account Id for the live site
    /// </summary>
    public static string LiveImpAccountId { get; set; }

    /// <summary>
    /// Imp Account Id used to load agency information
    /// </summary>
    public static string ImpAccountId
    {
      get { return LiveSite ? LiveImpAccountId : TestImpAccountId; }
    }

    /// <summary>
    /// Test Agency ID
    /// </summary>
    public static string TestAgencyId { get; set; }

    /// <summary>
    /// Live Agency ID
    /// </summary>
    public static string LiveAgencyId { get; set; }

    /// <summary>
    /// Agency ID, used during the quote request
    /// </summary>
    public static string AgencyId
    {
      get { return LiveSite ? LiveAgencyId : TestAgencyId; }
    }

    /// <summary>
    /// Test Agency Account Name
    /// </summary>
    public static string TestAgencyAccountName { get; set; }

    /// <summary>
    /// Live Agency Account Name
    /// </summary>
    public static string LiveAgencyAccountName { get; set; }

    /// <summary>
    /// Agency Account Name, used during the quote request
    /// </summary>
    public static string AgencyAccountName
    {
      get { return LiveSite ? LiveAgencyAccountName : TestAgencyAccountName; }
    }

    /// <summary>
    /// determination for hitting the ITC Test or Live rating envioronment
    /// </summary>
    public static bool LiveSite { get; set; }

    /// <summary>
    /// token used for Bearer authentication
    /// </summary>
    public static string BearerToken { get; set; }

    /// <summary>
    /// Test integration key used to pull a bearer token back
    /// </summary>
    public static string TestImpIntegrationKey { get; set; }

    /// <summary>
    /// Live integration key used to pull a bearer token back
    /// </summary>
    public static string LiveImpIntegrationKey { get; set; }

    /// <summary>
    /// Integration key used w/ Bearer authentication, whether it's in the Live or Test environment
    /// </summary>
    public static string ImpIntegrationKey 
    {
      get { return LiveSite ? LiveImpIntegrationKey : TestImpIntegrationKey; }
    }

    /// <summary>
    /// ITC Rating Service Account Id used for the ITC test rating environment
    /// </summary>
    public static string TestItcRatingServiceAccountId { get; set; }

    /// <summary>
    /// ITC Rating Service Account Id used for the ITC live rating environment
    /// </summary>
    public static string LiveItcRatingServiceAccountId { get; set; }

    /// <summary>
    /// ITC rating service account id to load carrier information with, whether it's from the Live or Test environment
    /// </summary>
    public static string ItcRatingServiceAccountId
    {
      get { return LiveSite ? LiveItcRatingServiceAccountId : TestItcRatingServiceAccountId; }
    }

    /// <summary>
    /// Last name of the insured to search by
    /// </summary>
    public static string SearchLastName { get; set; }

    /// <summary>
    /// First name of the insured to search by
    /// </summary>
    public static string SearchFirstName { get; set; }

    /// <summary>
    /// Phone number of the insured to search by
    /// </summary>
    public static string SearchPhoneNumber { get; set; }

    /// <summary>
    /// Product state of the insured to search by
    /// </summary>
    public static string SearchProductState { get; set; }
  }
}
