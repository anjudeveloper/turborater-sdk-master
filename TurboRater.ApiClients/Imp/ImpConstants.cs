using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.Imp
{
  public enum HttpMethods
  {
    GET, 
    POST
  }

  /// <summary>
  /// User security levels.
  /// </summary>
  public enum SecurityLevels
  {
    AgencyAdmin = 0,
    LocationAdmin = 1,
    StandardUser = 2,
    RestrictedUser = 3
  };

  /// <summary>
  /// User access levels (this is for restricted users from the SecurityLevels list).
  /// </summary>
  public enum AccessLevels
  {
    StandardAccess = 0,
    RestrictedEditing = 1,
    RestrictedViewing = 2
  };

  /// <summary>
  /// Constants related to Imp.
  /// </summary>
  public static class ImpConstants
  {
    /// <summary>
    /// Mapping of Imp LobCd to the InsuranceLine enum.
    /// </summary>
    public static string[] LobCodes =
    {
		  "DF", //DwellingFire
		  "HOME", // Homeowners
		  "AUTO", // PersonalAuto
		  "COMMAUTO", // CommercialAuto
		  "FLOOD", // Flood
      "UMBRELLA", // Umbrella
		  "FLCOMMWIND", // FLCommWind
	    "FLCOMMPROP", // FLCommProp
      "MULTIPLE", // MultipleLines
      "MOTORCYCLE" //Motorcycle
    };

    /// <summary>
    /// Imp test base url.
    /// </summary>
    public const string TestBaseUrl = "https://ratingqa.itcdataservices.com/webservices/imp/";

    /// <summary>
    /// Imp live base url.
    /// </summary>
    public const string LiveBaseUrl = "https://www.itcratingservices.com/webservices/imp/";

    /// <summary>
    /// Gets the applicable base url of the imp web service.
    /// </summary>
    public static string BaseUrl
    {
      get { return LiveBaseUrl; }
    }

    /// <summary>
    /// Guids of the security levels
    /// </summary>
    public static readonly string[] ValidSecurityLevelGUIDs =
															 {
																 "F57151C0-EDBB-4064-8A86-19F9F9E9066D", //Agency Admin
																 "0DF5E165-10CC-4922-8C6D-694F48D92854", //Location Admin
																 "D6306DA7-7BCA-41ED-9196-54C3CA407A47", //Standard User
                                 "DE21F879-FAEB-42DE-97BE-AE517163DC4A"  //Restricted User
															 };


    /// <summary>
    /// Guids of the various access rights levels
    /// </summary>
    public static readonly string[] ValidAccessLevelGUIDs =
                               {
                                 "0da852ca-8d14-48ca-844c-8752ebde8ea7", //Standard
                                 "ef5028d6-2fb4-4e55-b6c2-45b0caaeb4de", //Restricted Editing
                                 "aed33306-9f8e-4dc0-9f72-1bf2fd687a7c"  //Restricted Viewing
                               };

  }
}
