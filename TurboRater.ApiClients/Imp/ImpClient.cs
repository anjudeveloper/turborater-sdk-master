using Microsoft.OData.Client;
using Microsoft.OData.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using TurboRater.ApiClients.Imp.Itc.EFContexts;
using TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage;
using TurboRater.Insurance;
using TurboRater.Insurance.DataTransformation;
using TurboRater.InterfaceSpecifications;
using Newtonsoft.Json; 

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Client for connecting to the IMP coverage service.
  /// </summary>
  public class ImpClient : IImpClient
  {
    /// <summary>
    /// JavaScript serializer used by many methods to serialize/deserialize data from our IMP API.
    /// </summary>
    public JavaScriptSerializer JSSerializer { get; set; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ImpClient()
    {
      BaseUrl = ImpConstants.BaseUrl;
      JSSerializer = new JavaScriptSerializer() { MaxJsonLength = 50000000 }; //because quote load responses include rating data, they can get pretty huge. I've seen 10MB+.
    }

    /// <summary>
    /// The base URL used to connect to the service.
    /// </summary>
    public string BaseUrl { get; set; }

    /// <summary>
    /// Returns all coverages for all states.
    /// </summary>
    /// <param name="line">The line of insurance to retrieve.</param>
    /// <param name="auth">The authorization credentials.</param>
    /// <returns>A list of state coverages available for the line of business specified.</returns>
    public IList<ImpCoverageContainer> GetAllStateCoverages(InsuranceLine line, Guid auth)
    {
      using (var webClient = new WebClient())
      {
        webClient.Headers.Add("content-type", "application/json");
        webClient.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(auth.ToString() + ":" + auth.ToString())));

        string response = webClient.DownloadString(BaseUrl + "api/Coverages?lobCd=" + ImpConstants.LobCodes[(int)line]);
        var limits = JSSerializer.Deserialize<List<ImpCoverageContainer>>(response);
        return new List<ImpCoverageContainer>(limits);
      }
    }

    /// <summary>
    /// Returns all coverages for the specified state.
    /// </summary>
    /// <param name="line">The line of insurance to retrieve.</param>
    /// <param name="auth">The authorization credentials.</param>
    /// <param name="state">The state to retrieve.</param>
    /// <returns>A list of coverages available for the state and line of business specified.</returns>
    public ImpCoverageContainer GetStateCoverages(InsuranceLine line, USState state, Guid auth)
    {
      using (var webClient = new WebClient())
      {
        webClient.Headers.Add("content-type", "application/json");
        webClient.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(auth.ToString() + ":" + auth.ToString())));
        string stateAbbrev = ITCConstants.StateAbbreviations[(int)state];
        string response = webClient.DownloadString(BaseUrl + "api/Coverages?lobCd=" + ImpConstants.LobCodes[(int)line] + "&stateProvCd=" + stateAbbrev);
        var limits = JSSerializer.Deserialize<List<ImpCoverageContainer>>(response);
        if (limits != null && limits.Count > 0)
          return limits[0];
        throw new ArgumentException("Coverages not available for the specified line of business and state.");
      }
    }

    /// <summary>
    /// Gets the PPC code information for the specified address info. Note that if there is an exact addres match you'll get just a single
    /// object in the list of responses. If however there was not an exact match on the property you may get multiple responses. You likely just 
    /// want to use the one with the highest value for PercentMatch as it's the best match that could be found.
    /// </summary>
    /// <param name="auth">The authorization credentials.</param>
    /// <param name="state">the state in which this residence is located</param>
    /// <param name="zipCode">zip code</param>
    /// <param name="street">street name</param>
    /// <param name="streetType">street type. Ex: LN for Lane, etc</param>
    /// <param name="streetNumber">street number</param>
    /// <param name="streetPre">prefix for street. Ex: W 10th st (W would be the Pre)</param>
    /// <param name="streetPost">postfix (suffix) for street. Ex: 107th Ave W (W would be the Post)</param>
    /// <returns>PPC information.</returns>
    public List<PpcInfo> Ppc(Guid auth, string state, string zipCode, string street, string streetType = "", string streetNumber = "",
      string streetPre = "", string streetPost = "")
    {
      using (var webClient = new WebClient())
      {
        webClient.Headers.Add("content-type", "application/json");
        webClient.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(auth.ToString() + ":" + auth.ToString())));

        string url = BaseUrl + "api/territories/ppc";
        url += "?state=" + HttpUtility.UrlEncode(state) + "&zipcode=" + HttpUtility.UrlEncode(zipCode) + "&street=" + HttpUtility.UrlEncode(street);
        if (!String.IsNullOrWhiteSpace(streetType))
          url += "&streettype=" + streetType;
        if (!String.IsNullOrWhiteSpace(streetNumber))
          url += "&streetnumber=" + streetNumber;
        if (!String.IsNullOrWhiteSpace(streetPre))
          url += "&streetpre=" + streetPre;
        if (!String.IsNullOrWhiteSpace(streetPost))
          url += "&streetpost=" + streetPost;
        string response = webClient.DownloadString(url);
        return JSSerializer.Deserialize<List<PpcInfo>>(response);
      }
    }

    /// <summary>
    /// Gets the Fire Districts information for the specified state/county combination. Currently only used in CA/OK/PA
    /// </summary>
    /// <param name="auth">The authorization credentials.</param>
    /// <param name="state">the state in which this fire district is located</param>
    /// <param name="county">the county in which this fire district is located</param>
    /// <returns>Fire District information</returns>
    public List<string> FireDistricts(Guid auth, string state, string county)
    {
      using (var webClient = new WebClient())
      {
        webClient.Headers.Add("content-type", "application/json");
        webClient.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(auth.ToString() + ":" + auth.ToString())));

        string url = BaseUrl + "api/territories/firedistricts";
        url += "?state=" + HttpUtility.UrlEncode(state) + "&county=" + HttpUtility.UrlEncode(county);
        string response = webClient.DownloadString(url);
        return JSSerializer.Deserialize<List<string>>(response);
      }
    }

    /// <summary>
    /// Returns a list of states. If no zipcode is sent this returns all states. If a zipcode is sent, this returns all
    /// states that the zipcode is within
    /// </summary>
    /// <param name="auth">The authorization credentials.</param>
    /// <param name="zipCode">Optional. the zipcode contained by the returned states.</param>
    /// <returns>list of states, or empty list if no match on specified zipcode.</returns>
    public IList<string> States(Guid auth, string zipCode = "")
    {
      using (var webClient = new WebClient())
      {
        webClient.Headers.Add("content-type", "application/json");
        webClient.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(auth.ToString() + ":" + auth.ToString())));

        string url = BaseUrl + "api/territories/states";
        if (!String.IsNullOrWhiteSpace(zipCode))
          url += "?zipCode=" + HttpUtility.UrlEncode(zipCode);
        string response = webClient.DownloadString(url);
        var states = JSSerializer.Deserialize<string[]>(response);
        if (states != null)
        {
          //there are double-quotes around the names of states
          for (int stateIndex = 0; stateIndex < states.Length; stateIndex++)
            states[stateIndex] = states[stateIndex].Replace("\"", "");
          return states.ToList();
        }
        else
          return new List<string>();
      }
    }

    /// <summary>
    /// Returns a list of counties that match the specified state and zipCode
    /// </summary>
    /// <param name="auth">The authorization credentials.</param>
    /// <param name="state">the state</param>
    /// <param name="zipCode">the zipcode contained by the returned states.</param>
    /// <returns>list of counties, or empty list if no match on specified criteria.</returns>
    public IList<string> Counties(Guid auth, string state, string zipCode)
    {
      using (var webClient = new WebClient())
      {
        webClient.Headers.Add("content-type", "application/json");
        webClient.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(auth.ToString() + ":" + auth.ToString())));

        string url = BaseUrl + String.Format("api/territories/counties?state={0}&zipCode={1}", HttpUtility.UrlEncode(state), HttpUtility.UrlEncode(zipCode));
        string response = webClient.DownloadString(url);
        var counties = JSSerializer.Deserialize<string[]>(response);
        if (counties != null)
        {
          //there are double-quotes around the names of counties
          for (int countyIndex = 0; countyIndex < counties.Length; countyIndex++)
            counties[countyIndex] = counties[countyIndex].Replace("\"", "");
          return counties.ToList();
        }
        else
          return new List<string>();
      }
    }

    /// <summary>
    /// Returns a JSON representation of the turborater interface 
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.  If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="lineOfBusiness">Line of business.</param>
    /// <param name="stateCode">The state abbreviation.</param>
    /// <returns>a JSON representation of the turborater interface </returns>
    public InterfaceDefinition GetTurboRaterInterfaceSpecifications(string bearerToken, Guid impAccountId, string lineOfBusiness, string stateCode)
    {
      using (var webClient = new WebClient())
      {
        SetClientHeaders(webClient, bearerToken, impAccountId);
        var response = webClient.DownloadString(BaseUrl + string.Format("api/interface/rating/{0}/{1}", lineOfBusiness, stateCode));
        return JSSerializer.Deserialize<InterfaceDefinition>(response);
      }
    }

    /// <summary>
    /// Validates the specified tt2 data.
    /// </summary>
    /// <param name="auth">The IMP account ID. If you leave this null, no IMP acct is used for auth.</param>
    /// <param name="policy">Request containing tt2 data and other things.</param>
    /// <returns>TT2ValidationError list containing any validation failures, or nukll if no failures.</returns>
    public List<TT2ValidationError> ValidationTurboRater(Guid? auth, ValidatePolicyRequest policy)
    {
      using (var webClient = new WebClient())
      {
        webClient.Headers.Add("content-type", "application/json");
        if (auth != null && auth.HasValue)
          webClient.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(auth + ":" + auth)));

        string response = String.Empty;
        string serializedPolicy = string.Empty;
        try
        {
          serializedPolicy = JSSerializer.Serialize(policy);
        }
        catch (Exception)
        {
          List<TT2ValidationError> retList = new List<TT2ValidationError>();
          TT2ValidationError generalError = new TT2ValidationError() { ErrorCode = ValidationErrorType.InvalidTT2FileFormat, ExpectedValue = "Valid Policy Data.", FieldValue = "Request is invalid." };
          retList.Add(generalError);
          return retList;
        }

        try
        {
          response = webClient.UploadString(BaseUrl + "api/validation/turborater", serializedPolicy);
        }
        catch (WebException ex)
        {
          if (ex.Response != null && ex.Response.ContentLength > 0)
          {
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
              response = reader.ReadToEnd();
          }
          HttpWebResponse res = (HttpWebResponse)ex.Response;
          throw new HttpException((int)res.StatusCode, "Error validating TT2 data: " + res.StatusCode + "::" + response);
        }
        return String.IsNullOrWhiteSpace(response) ? null : JSSerializer.Deserialize<List<TT2ValidationError>>(response);
      }
    }

    /// <summary>
    /// Sets a WebClient headers based on bearer token or imp account id.
    /// </summary>
    /// <param name="client">The web client to modify.</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    private void SetClientHeaders(WebClient client, string bearerToken, Guid impAccountId)
    {
      client.Headers.Add("content-type", "application/json");
      if (string.IsNullOrWhiteSpace(bearerToken) && impAccountId != Guid.Empty)
        client.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(impAccountId + ":" + impAccountId)));
      else if (!string.IsNullOrWhiteSpace(bearerToken))
        client.Headers.Add("Authorization", "Bearer " + Convert.ToBase64String(Encoding.UTF8.GetBytes(bearerToken)));
      else
        throw new ArgumentException("bearerToken or impAccountId required.");
    }

    /// <summary>
    /// Sets client headers for an OData request.
    /// </summary>
    /// <param name="requestMessage">The odata request message.</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    public static void SetClientHeadersOData(IODataRequestMessage requestMessage, string bearerToken, Guid impAccountId)
    {
      if (string.IsNullOrWhiteSpace(bearerToken) && impAccountId != Guid.Empty)
        requestMessage.SetHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(impAccountId + ":" + impAccountId)));
      else if (!string.IsNullOrWhiteSpace(bearerToken))
        requestMessage.SetHeader("Authorization", "Bearer " + Convert.ToBase64String(Encoding.UTF8.GetBytes(bearerToken)));
      else
        throw new ArgumentException("bearerToken or impAccountId required.");
    }

    /// <summary>
    /// Unlocks a locked policy
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.  If null, impAccountId is used.</param>
    /// <param name="policyId">policy id for the policy to unlock</param>
    /// <param name="line">insurance line of the policy</param>
    /// <param name="state">the policy rating state</param>
    /// <param name="userId">Optional user under which to save the policy.  If null, the first is used.</param>
    /// <param name="locationId">Optional location under which to save the policy.  If null, the first is used.</param>
    /// <returns>an empty string if successful, and error message otherwise.</returns>
    public string UnlockPolicy(string bearerToken, int policyId, InsuranceLine line, USState state, Guid userId, Guid locationId)
    {
      return UnlockPolicy(bearerToken, Guid.Empty, policyId, line, state, userId, locationId); 
    }

    /// <summary>
    /// Unlocks a locked policy
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="policyId">policy id for the policy to unlock</param>
    /// <param name="line">insurance line of the policy</param>
    /// <param name="state">the policy rating state</param>
    /// <param name="userId">Optional user under which to save the policy.  If null, the first is used.</param>
    /// <param name="locationId">Optional location under which to save the policy.  If null, the first is used.</param>
    /// <returns>an empty string if successful, and error message otherwise.</returns>
    public string UnlockPolicy(Guid impAccountId, int policyId, InsuranceLine line, USState state, Guid userId, Guid locationId)
    {
      return UnlockPolicy(null, impAccountId, policyId, line, state, userId, locationId); 
    }

    /// <summary>
    /// Unlocks a locked policy
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.  If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="policyId">policy id for the policy to unlock</param>
    /// <param name="line">insurance line of the policy</param>
    /// <param name="state">the policy rating state</param>
    /// <param name="userId">Optional user under which to save the policy.  If null, the first is used.</param>
    /// <param name="locationId">Optional location under which to save the policy.  If null, the first is used.</param>
    /// <returns>an empty string if successful, and error message otherwise.</returns>
    public string UnlockPolicy(string bearerToken, Guid impAccountId, int policyId, InsuranceLine line, USState state, Guid userId, Guid locationId)
    {
      var request = new UnlockPolicyRequest()
      {
        InsuranceLine = InsConstants.InsuranceLineToShortString(line),
        LocationId = locationId.ToString(),
        UserId = userId.ToString(),
        State = state,
        PolicyId = policyId
      };

      using (var client = new WebClient())
      {
        SetClientHeaders(client, bearerToken, impAccountId);
        string url = BaseUrl + "api/storage/unlockquote";
        string postData = JSSerializer.Serialize(request);
        string response = client.UploadString(url, postData);
        return response;
      }
    }

    /// <summary>
    /// Saves a policy into online storage using either form of authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.  If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="policy">The policy to save.</param>
    /// <param name="lockPolicyForUser">If true, locks the policy after save.</param>
    /// <param name="overrideExistingLock">If true, ignores any existing lock when saving.</param>
    /// <param name="locationId">Optional location under which to save the policy.  If null, the first is used.</param>
    /// <param name="userId">Optional user under which to save the policy.  If null, the first is used.</param>
    /// <returns>A response object containting the policy id and other information, including validation errors if any.</returns>
    private SavePolicyResponse SavePolicy(string bearerToken, Guid impAccountId, InsPolicy policy, bool lockPolicyForUser = false, bool overrideExistingLock = false,
      Guid? locationId = null, Guid? userId = null)
    {
      var request = new SavePolicyRequest()
      {
        InsuranceLine = InsConstants.InsuranceLineToShortString(policy.LineOfInsurance),
        LocationId = locationId,
        UserId = userId,
        LockPolicyForUser = lockPolicyForUser,
        OverrideExistingLock = overrideExistingLock,
        PolicyData = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(TransformationHelper.SerializePolicy(policy)))
      };

      using (var client = new WebClient())
      {
        SetClientHeaders(client, bearerToken, impAccountId);
        string url = BaseUrl + "api/storage/savepolicy";
        string postData = JSSerializer.Serialize(request);
        string response = client.UploadString(url, postData);
        return JSSerializer.Deserialize<SavePolicyResponse>(response);
      }
    }

    /// <summary>
    /// Saves a policy into online storage by Imp account id, using basic authentication. 
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="policy">The policy to save.</param>
    /// <param name="lockPolicyForUser">If true, locks the policy after save.</param>
    /// <param name="overrideExistingLock">If true, ignores any existing lock when saving.</param>
    /// <param name="locationId">Optional location under which to save the policy.  If null, the first is used.</param>
    /// <param name="userId">Optional user under which to save the policy.  If null, the first is used.</param>
    /// <returns>A response object containting the policy id and other information, including validation errors if any.</returns>
    public SavePolicyResponse SavePolicy(Guid impAccountId, InsPolicy policy, bool lockPolicyForUser = false, bool overrideExistingLock = false,
      Guid? locationId = null, Guid? userId = null)
    {
      return SavePolicy(null, impAccountId, policy, lockPolicyForUser, overrideExistingLock, locationId, userId);
    }

    /// <summary>
    /// Saves a policy into online storage by bearer token, using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="policy">The policy to save.</param>
    /// <param name="lockPolicyForUser">If true, locks the policy after save.</param>
    /// <param name="overrideExistingLock">If true, ignores any existing lock when saving.</param>
    /// <param name="locationId">Optional location under which to save the policy.  If null, the first is used.</param>
    /// <param name="userId">Optional user under which to save the policy.  If null, the first is used.</param>
    /// <returns>A response object containting the policy id and other information, including validation errors if any.</returns>
    public SavePolicyResponse SavePolicy(string bearerToken, InsPolicy policy, bool lockPolicyForUser = false, bool overrideExistingLock = false,
      Guid? locationId = null, Guid? userId = null)
    {
      return SavePolicy(bearerToken, Guid.Empty, policy, lockPolicyForUser, overrideExistingLock, locationId, userId);
    }

    /// <summary>
    /// Loads a policy from online storage by using either form of authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.  If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="line">The line of insurance of the policy to retrieve.</param>
    /// <param name="id">The id of the policy to retrieve.</param>
    /// <param name="formatType">The formate of the response.  Defaults to tt2.</param>
    /// <returns>An object containing the full policy and the response data from IMP.</returns>
    private QuoteLoadWrapper LoadPolicy(string bearerToken, Guid impAccountId, InsuranceLine line, int id, BridgeContentType formatType = BridgeContentType.TT2)
    {
      using (var client = new WebClient())
      {
        string url = BaseUrl + string.Format("api/storage/quote/{0}/{1}/?formatType={2}", InsConstants.InsuranceLineToShortString(line), id, formatType);

        SetClientHeaders(client, bearerToken, impAccountId);
        string response = client.DownloadString(url);

        var result = new QuoteLoadWrapper();
        result.QuoteLoadInfo = JSSerializer.Deserialize<QuoteLoadResult>(response);
        result.Policy = TransformationHelper.DeserializePolicy(result.QuoteLoadInfo.QuoteData, line);

        return result;
      }
    }

    /// <summary>
    /// Loads a policy from online storage by bearer token, using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="line">The line of insurance of the policy to retrieve.</param>
    /// <param name="id">The id of the policy to retrieve.</param>
    /// <param name="formatType">The formate of the response.  Defaults to tt2.</param>
    /// <returns>An object containing the full policy and the response data from IMP.</returns>
    public QuoteLoadWrapper LoadPolicy(string bearerToken, InsuranceLine line, int id, BridgeContentType formatType = BridgeContentType.TT2)
    {
      return LoadPolicy(bearerToken, Guid.Empty, line, id, formatType);
    }

    /// <summary>
    /// Loads a policy from online storage by Imp account id, using basic authentication. 
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="line">The line of insurance of the policy to retrieve.</param>
    /// <param name="id">The id of the policy to retrieve.</param>
    /// <param name="formatType">The formate of the response.  Defaults to tt2.</param>
    /// <returns>An object containing the full policy and the response data from IMP.</returns>
    public QuoteLoadWrapper LoadPolicy(Guid impAccountId, InsuranceLine line, int id, BridgeContentType formatType = BridgeContentType.TT2)
    {
      return LoadPolicy(null, impAccountId, line, id, formatType);
    }

    /// <summary>
    /// Deletes a policy, using either form of authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.  If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="line">The line of insurance of the policy to delete.</param>
    /// <param name="policyId">The id of the policy to delete.</param>
    /// <returns>The record id of the policy if successful, -1 if not.</returns>
    private int DeletePolicy(string bearerToken, Guid impAccountId, InsuranceLine line, int policyId)
    {
      var request = new DeletePolicyRequest()
      {
        InsuranceLine = InsConstants.InsuranceLineToShortString(line),
        PolicyId = policyId
      };
      using (var client = new WebClient())
      {
        string url = BaseUrl + "api/storage/deletepolicy";
        string postData = JSSerializer.Serialize(request);
        SetClientHeaders(client, bearerToken, impAccountId);
        string response = client.UploadString(url, postData);
        return ITCConvert.ToInt32(response, -1);
      }
    }

    /// <summary>
    /// Deletes a policy by bearer token, using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="line">The line of insurance of the policy to delete.</param>
    /// <param name="policyId">The id of the policy to delete.</param>
    /// <returns>The record id of the policy if successful, -1 if not.</returns>
    public int DeletePolicy(string bearerToken, InsuranceLine line, int policyId)
    {
      return DeletePolicy(bearerToken, Guid.Empty, line, policyId);
    }

    /// <summary>
    /// Deletes a policy by imp account id, using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="line">The line of insurance of the policy to delete.</param>
    /// <param name="policyId">The id of the policy to delete.</param>
    /// <returns>The record id of the policy if successful, -1 if not.</returns>
    public int DeletePolicy(Guid impAccountId, InsuranceLine line, int policyId)
    {
      return DeletePolicy(null, impAccountId, line, policyId);
    }

    /// <summary>
    /// Searches online storage for insureds and quotes using either form of authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.  If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="start">The quote modified/inserted date/time start for the date search range.</param>
    /// <param name="end">The quote modified/inserted date/time end for the date search range.</param>
    /// <param name="lines">Optional lines of insurance to search.</param>
    /// <returns>A list of insureds, each containing a list of policies.</returns>
    private StorageSearchResult StorageSearch(string bearerToken, Guid impAccountId, DateTime start, DateTime end, IEnumerable<InsuranceLine> lines)
    {
      string lineList = string.Empty;
      if (lines.Count() > 0)
        lineList = "&insuranceLines=" + string.Join(",", lines.Select(line => InsConstants.InsuranceLineToShortString(line)));
      string url = BaseUrl + string.Format("api/storage/lookup?start={0}&end={1}{2}", start.ToString("s"), end.ToString("s"), lineList);
      using (var client = new WebClient())
      {
        SetClientHeaders(client, bearerToken, impAccountId);
        string response = client.DownloadString(url);
        return JSSerializer.Deserialize<StorageSearchResult>(response);
      }
    }

    /// <summary>
    /// Searches online storage for insureds by bearer token using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="start">The quote modified/inserted date/time start for the date search range.</param>
    /// <param name="end">The quote modified/inserted date/time end for the date search range.</param>
    /// <param name="lines">Optional lines of insurance to search.</param>
    /// <returns>A list of insureds, each containing a list of policies.</returns>
    public StorageSearchResult StorageSearch(string bearerToken, DateTime start, DateTime end, IEnumerable<InsuranceLine> lines)
    {
      return StorageSearch(bearerToken, Guid.Empty, start, end, lines);
    }

    /// <summary>
    /// Searches online storage for insureds using imp account id and basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="start">The quote modified/inserted date/time start for the date search range.</param>
    /// <param name="end">The quote modified/inserted date/time end for the date search range.</param>
    /// <param name="lines">Optional lines of insurance to search.</param>
    /// <returns>A list of insureds, each containing a list of policies.</returns>
    public StorageSearchResult StorageSearch(Guid impAccountId, DateTime start, DateTime end, IEnumerable<InsuranceLine> lines)
    {
      return StorageSearch(null, impAccountId, start, end, lines);
    }

    /// <summary>
    /// Searches online storage for insureds and quotes using either form of authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.  If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="policy">The policy to validate.</param>
    /// <returns>A list of policy errors.</returns>
    public List<TT2ValidationError> ValidatePolicy(string bearerToken, Guid impAccountId, InsPolicy policy)
    {
      using (var client = new WebClient())
      {
        SetClientHeaders(client, bearerToken, impAccountId);
        var request = new ValidatePolicyRequest(TransformationHelper.SerializePolicy(policy), InsConstants.InsuranceLineToShortString(policy.LineOfInsurance));
        string response = string.Empty;
        try
        {
          response = client.UploadString(BaseUrl + "api/validation/turborater", JSSerializer.Serialize(request));
        }
        catch (WebException ex)
        {
          if (ex.Response != null && ex.Response.ContentLength > 0)
          {
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
              response = reader.ReadToEnd();
          }
          HttpWebResponse res = (HttpWebResponse)ex.Response;
          throw new HttpException((int)res.StatusCode, "Error validating TT2 data: " + res.StatusCode + "::" + response);
        }
        return String.IsNullOrWhiteSpace(response) ? null : JSSerializer.Deserialize<List<TT2ValidationError>>(response);
      }
    }

    /// <summary>
    /// Searches online storage for insureds and quotes using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="policy">The policy to validate.</param>
    /// <returns>A list of policy errors.</returns>
    public List<TT2ValidationError> ValidatePolicy(string bearerToken, InsPolicy policy)
    {
      return ValidatePolicy(bearerToken, Guid.Empty, policy);
    }

    /// <summary>
    /// Searches online storage for insureds and quotes using basic auth.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="policy">The policy to validate.</param>
    /// <returns>A list of policy errors.</returns>
    public List<TT2ValidationError> ValidatePolicy(Guid impAccountId, InsPolicy policy)
    {
      return ValidatePolicy(null, impAccountId, policy);
    }

    /// <summary>
    /// Retrieves information about the authenticated agency using either form of authentication authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <returns>The authenticated agency.</returns>
    public TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgency GetAgency(string bearerToken, Guid impAccountId)
    {
      var odataClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(BaseUrl + "api"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, bearerToken, impAccountId);
      };
      return odataClient.Agencies.ByKey(Guid.NewGuid().ToString()).GetValue();
    }

    /// <summary>
    /// Retrieves information about the authenticated agency using BEARER authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <returns>The authenticated agency.</returns>
    public TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgency GetAgency(string bearerToken)
    {
      return GetAgency(bearerToken, Guid.Empty);
    }

    /// <summary>
    /// Retrieves information about the authenticated agency using BASIC authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <returns>The authenticated agency.</returns>
    public TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgency GetAgency(Guid impAccountId)
    {
      return GetAgency(null, impAccountId);
    }

    /// <summary>
    /// Retrieves information about a location within the authenticated agency using either form of authentication authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="locationId">The agency location ID.</param>
    /// <returns>The location we are looking for.</returns>
    public TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation GetLocation(string bearerToken, Guid impAccountId, Guid locationId)
    {
      var odataClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(BaseUrl + "api/agencies('0')"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, bearerToken, impAccountId);
      };
      return odataClient.Locations.ByKey(locationId.ToString()).GetValue();
    }

    /// <summary>
    /// Retrieves information about a location within the authenticated agency using BEARER authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="locationId">The agency location ID.</param>
    /// <returns>The location we are looking for.</returns>
    public TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation GetLocation(string bearerToken, Guid locationId)
    {
      return GetLocation(bearerToken, Guid.Empty, locationId);
    }

    /// <summary>
    /// Retrieves information about a location within the authenticated agency using BASIC authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="locationId">The agency location ID.</param>
    /// <returns>The location we are looking for.</returns>
    public TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation GetLocation(Guid impAccountId, Guid locationId)
    {
      return GetLocation(null, impAccountId, locationId);
    }

    /// <summary>
    /// Adds a location to the authenticated agency.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="location">The agency location to add to the agency.</param>
    public void AddLocation(string bearerToken, Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation location)
    {
      var odataClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(BaseUrl + "api/agencies('0')"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, bearerToken, impAccountId);
      };
      odataClient.AddToLocations(location);
      odataClient.SaveChanges();
    }

    /// <summary>
    /// Adds a location to the authenticated agency using BEARER authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="location">The agency location to add to the agency.</param>
    public void AddLocation(string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation location)
    {
      AddLocation(bearerToken, Guid.Empty, location);
    }

    /// <summary>
    /// Adds a location to the authenticated agency using BASIC authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="location">The agency location to add to the agency.</param>
    public void AddLocation(Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation location)
    {
      AddLocation(null, impAccountId, location);
    }

    /// <summary>
    /// Updates a location within the authenticated agency.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="location">The agency location to update within the agency.</param>
    public void UpdateLocation(string bearerToken, Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation location)
    {
      var odataClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(BaseUrl + "api/agencies('0')"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, bearerToken, impAccountId);
      };
      var existingLocation = odataClient.Locations.ByKey(location.AgencyLocationID).GetValue();
      existingLocation.Address1 = location.Address1;
      existingLocation.Address2 = location.Address2;
      existingLocation.AgencyID = location.AgencyID;
      existingLocation.AgencyLocationID = location.AgencyLocationID;
      existingLocation.AlternatePhoneNumber = location.AlternatePhoneNumber;
      existingLocation.City = location.City;
      existingLocation.Description = location.Description;
      existingLocation.FaxNumber = location.FaxNumber;
      existingLocation.LocationName = location.LocationName;
      existingLocation.PhoneNumber = location.PhoneNumber;
      existingLocation.ProfileLinkID = location.ProfileLinkID;
      existingLocation.State = location.State;
      existingLocation.SubAgentProducerCode = location.SubAgentProducerCode;
      existingLocation.Zipcode = location.Zipcode;
      odataClient.UpdateObject(existingLocation);
      odataClient.SaveChanges(SaveChangesOptions.ReplaceOnUpdate);
    }

    /// <summary>
    /// Updates a location within the authenticated agency using BEARER authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="location">The agency location to update within the agency.</param>
    public void UpdateLocation(string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation location)
    {
      UpdateLocation(bearerToken, Guid.Empty, location);
    }

    /// <summary>
    /// Updates a location within the authenticated agency using BASIC authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="location">The agency location to update within the agency.</param>
    public void UpdateLocation(Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation location)
    {
      UpdateLocation(null, impAccountId, location);
    }

    /// <summary>
    /// Deletes a location within the authenticated agency using either form of authentication authentication.
    /// Note that deletes are soft deletes, so the location will still exist after deletion. The Active property
    /// will be set to false.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="locationId">The agency location ID.</param>
    public void DeleteLocation(string bearerToken, Guid impAccountId, Guid locationId)
    {
      var odataClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(BaseUrl + "api/agencies('0')"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, bearerToken, impAccountId);
      };
      var location = odataClient.Locations.ByKey(locationId.ToString()).GetValue();
      odataClient.DeleteObject(location);
      odataClient.SaveChanges();
    }

    /// <summary>
    /// Deletes a location within the authenticated agency using BEARER authentication.
    /// Note that deletes are soft deletes, so the location will still exist after deletion. The Active property
    /// will be set to false.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="locationId">The agency location ID.</param>
    public void DeleteLocation(string bearerToken, Guid locationId)
    {
      DeleteLocation(bearerToken, Guid.Empty, locationId);
    }

    /// <summary>
    /// Deletes a location within the authenticated agency using BASIC authentication.
    /// Note that deletes are soft deletes, so the location will still exist after deletion. The Active property
    /// will be set to false.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="locationId">The agency location ID.</param>
    public void DeleteLocation(Guid impAccountId, Guid locationId)
    {
      DeleteLocation(null, impAccountId, locationId);
    }

    /// <summary>
    /// Retrieves information about a user within the authenticated agency using either form of authentication authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="userId">The agency user ID.</param>
    /// <returns>The user we are looking for.</returns>
    public TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser GetUser(string bearerToken, Guid impAccountId, Guid userId)
    {
      var odataClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(BaseUrl + "api/agencies('0')"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, bearerToken, impAccountId);
      };
      return odataClient.Users.ByKey(userId.ToString()).GetValue();
    }

    /// <summary>
    /// Retrieves information about a user within the authenticated agency using BEARER authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="userId">The agency user ID.</param>
    /// <returns>The user we are looking for.</returns>
    public TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser GetUser(string bearerToken, Guid userId)
    {
      return GetUser(bearerToken, Guid.Empty, userId);
    }

    /// <summary>
    /// Retrieves information about a user within the authenticated agency using BASIC authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="userId">The agency user ID.</param>
    /// <returns>The user we are looking for.</returns>
    public TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser GetUser(Guid impAccountId, Guid userId)
    {
      return GetUser(null, impAccountId, userId);
    }

    /// <summary>
    /// Adds a user to the authenticated agency.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="user">The agency user to add to the agency.</param>
    public void AddUser(string bearerToken, Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser user)
    {
      var odataClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(BaseUrl + "api/agencies('0')"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, bearerToken, impAccountId);
      };
      odataClient.AddToUsers(user);
      odataClient.SaveChanges();
    }

    /// <summary>
    /// Adds a user to the authenticated agency using BEARER authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="user">The agency user to add to the agency.</param>
    public void AddUser(string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser user)
    {
      AddUser(bearerToken, Guid.Empty, user);
    }

    /// <summary>
    /// Adds a user to the authenticated agency using BASIC authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="user">The agency user to add to the agency.</param>
    public void AddUser(Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser user)
    {
      AddUser(null, impAccountId, user);
    }

    /// <summary>
    /// Updates a user within the authenticated agency.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="user">The agency user to update within the agency.</param>
    public void UpdateUser(string bearerToken, Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser user)
    {
      var odataClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(BaseUrl + "api/agencies('0')"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, bearerToken, impAccountId);
      };
      var existingUser = odataClient.Users.ByKey(user.UserID).GetValue();
      existingUser.AccessAcordForms = user.AccessAcordForms;
      existingUser.AccessLevelID = user.AccessLevelID;
      existingUser.Active = user.Active;
      existingUser.AgencyID = user.AgencyID;
      existingUser.AgencyManagementLinkID = user.AgencyManagementLinkID;
      existingUser.AllowIDCard = user.AllowIDCard;
      existingUser.AllowMotorcycleIDCard = user.AllowMotorcycleIDCard;
      existingUser.AssignedLocationIds = user.AssignedLocationIds;
      existingUser.EMailAddress = user.EMailAddress;
      existingUser.EnableDwellingFireRating = user.EnableDwellingFireRating;
      existingUser.EnableHomeownerRating = user.EnableHomeownerRating;
      existingUser.EnableMotorcycleRating = user.EnableMotorcycleRating;
      existingUser.EnablePersonalAutoRating = user.EnablePersonalAutoRating;
      existingUser.EnablePolicyBinding = user.EnablePolicyBinding;
      existingUser.EnableReplacementCostValuation = user.EnableReplacementCostValuation;
      existingUser.FirstName = user.FirstName;
      existingUser.LastName = user.LastName;
      existingUser.Login = user.Login;
      existingUser.MiddleName = user.MiddleName;
      existingUser.Password = user.Password;
      existingUser.PreventAccessToCarrierWebsites = user.PreventAccessToCarrierWebsites;
      existingUser.PrintAutoBinder = user.PrintAutoBinder;
      existingUser.PrintDwellingFireBinder = user.PrintDwellingFireBinder;
      existingUser.PrintHomeBinder = user.PrintHomeBinder;
      existingUser.PrintMotorcycleBinder = user.PrintMotorcycleBinder;
      existingUser.ProfileLinkID = user.ProfileLinkID;
      existingUser.ReceiveReportCard = user.ReceiveReportCard;
      existingUser.RestrictLocationAdminToAssignedLocation = user.RestrictLocationAdminToAssignedLocation;
      existingUser.SecurityLevelID = user.SecurityLevelID;
      existingUser.UserID = user.UserID;
      odataClient.UpdateObject(existingUser);
      odataClient.SaveChanges(SaveChangesOptions.ReplaceOnUpdate);
    }

    /// <summary>
    /// Updates a user within the authenticated agency using BEARER authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="user">The agency user to update within the agency.</param>
    public void UpdateUser(string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser user)
    {
      UpdateUser(bearerToken, Guid.Empty, user);
    }

    /// <summary>
    /// Updates a user within the authenticated agency using BASIC authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="user">The agency user to update within the agency.</param>
    public void UpdateUser(Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser user)
    {
      UpdateUser(null, impAccountId, user);
    }

    /// <summary>
    /// Deletes a user within the authenticated agency using either form of authentication authentication.
    /// Note that deletes are soft deletes, so the user will still exist after deletion. The Active property
    /// will be set to false.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="userId">The agency user ID.</param>
    public void DeleteUser(string bearerToken, Guid impAccountId, Guid userId)
    {
      var odataClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(BaseUrl + "api/agencies('0')"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, bearerToken, impAccountId);
      };
      var user = odataClient.Users.ByKey(userId.ToString()).GetValue();
      odataClient.DeleteObject(user);
      odataClient.SaveChanges();
    }

    /// <summary>
    /// Deletes a user within the authenticated agency using BEARER authentication.
    /// Note that deletes are soft deletes, so the user will still exist after deletion. The Active property
    /// will be set to false.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="userId">The agency user ID.</param>
    public void DeleteUser(string bearerToken, Guid userId)
    {
      DeleteUser(bearerToken, Guid.Empty, userId);
    }

    /// <summary>
    /// Deletes a user within the authenticated agency using BASIC authentication.
    /// Note that deletes are soft deletes, so the user will still exist after deletion. The Active property
    /// will be set to false.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="userId">The agency user ID.</param>
    public void DeleteUser(Guid impAccountId, Guid userId)
    {
      DeleteUser(null, impAccountId, userId);
    }

    /// <summary>
    /// Generates a TurboRater auto-login token that can be used to auto-login a specific TurboRater user into the 
    /// TurboRater GUI using either BEARER or BASIC auth.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="userId">The agency user ID.</param>
    public Guid TurboRaterLogin(string bearerToken, Guid impAccountId, Guid userId)
    {
      using (var client = new WebClient())
      {
        string url = BaseUrl + string.Format("api/auth/turboraterlogin/{0}", userId);
        SetClientHeaders(client, bearerToken, impAccountId);
        string response = client.DownloadString(url);
        var result = JSSerializer.Deserialize<Guid>(response);
        return result;
      }
    }

    /// <summary>
    /// Generates a TurboRater auto-login token that can be used to auto-login a specific TurboRater user into the 
    /// TurboRater GUI using BEARER auth.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="userId">The agency user ID.</param>
    public Guid TurboRaterLogin(string bearerToken, Guid userId)
    {
      return TurboRaterLogin(bearerToken, Guid.Empty, userId);
    }

    /// <summary>
    /// Generates a TurboRater auto-login token that can be used to auto-login a specific TurboRater user into the 
    /// TurboRater GUI using BASIC auth.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="userId">The agency user ID.</param>
    public Guid TurboRaterLogin(Guid impAccountId, Guid userId)
    {
      return TurboRaterLogin(null, impAccountId, userId);
    }

    /// <summary>
    /// Retrieves information about a company group within the authenticated agency using either form of authentication authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="companyGroupId">The company group ID.</param>
    /// <returns>The comany group we are looking for.</returns>
    public TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup GetCompanyGroup(string bearerToken, Guid impAccountId, int companyGroupId)
    {
      var odataClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(BaseUrl + "api/agencies('0')"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, bearerToken, impAccountId);
      };
      return odataClient.CompanyGroups.ByKey(companyGroupId).Expand("Companies").GetValue();
    }

    /// <summary>
    /// Retrieves information about a company group within the authenticated agency using BEARER authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="companyGroupId">The company group ID.</param>
    /// <returns>The company group we are looking for.</returns>
    public TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup GetCompanyGroup(string bearerToken, int companyGroupId)
    {
      return GetCompanyGroup(bearerToken, Guid.Empty, companyGroupId);
    }

    /// <summary>
    /// Retrieves information about a company group within the authenticated agency using BASIC authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="companyGroupId">The company group ID.</param>
    /// <returns>The company group we are looking for.</returns>
    public TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup GetCompanyGroup(Guid impAccountId, int companyGroupId)
    {
      return GetCompanyGroup(null, impAccountId, companyGroupId);
    }

    /// <summary>
    /// Retrieves information about a TurboRater custom CSS.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="cssId">The ID of the CSS record.</param>
    /// <returns>The TurboRater custom CSS we are looking for.</returns>
    public TurboRater.ApiClients.Imp.Itc.EFContexts.TurboRaterCustomCss GetTurboRaterCustomCss(Guid impAccountId, int cssId)
    {
      var odataClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(BaseUrl + "api"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, null, impAccountId);
      };
      return odataClient.CustomCss.ByKey(cssId).GetValue();
    }

    /// <summary>
    /// Adds a TurboRater custom CSS.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="customCss">The TurboRater custom CSS to add.</param>
    public void AddTurboRaterCustomCss(Guid impAccountId, TurboRater.ApiClients.Imp.Itc.EFContexts.TurboRaterCustomCss customCss)
    {
      var odataClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(BaseUrl + "api"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, null, impAccountId);
      };
      odataClient.AddToCustomCss(customCss);
      odataClient.SaveChanges();
    }

    /// <summary>
    /// Updates a TurboRater custom CSS.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="customCss">The TurboRater custom CSS to update.</param>
    public void UpdateTurboRaterCustomCss(Guid impAccountId, TurboRater.ApiClients.Imp.Itc.EFContexts.TurboRaterCustomCss customCss)
    {
      var odataClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(BaseUrl + "api"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, null, impAccountId);
      };
      var existingCustomCss = odataClient.CustomCss.ByKey(customCss.RecordId).GetValue();
      existingCustomCss.CustomCssName = customCss.CustomCssName;
      existingCustomCss.CustomCss = customCss.CustomCss;
      existingCustomCss.MinimumTurboRaterVersion = customCss.MinimumTurboRaterVersion;
      odataClient.UpdateObject(existingCustomCss);
      odataClient.SaveChanges(SaveChangesOptions.ReplaceOnUpdate);
    }

    /// <summary>
    /// Deletes a TurboRater custom CSS.
    /// Deletes are hard deletes, there is no recover of the record after deletion.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="cssId">The TurboRater custom CSS ID.</param>
    public void DeleteTurboRaterCustomCss(Guid impAccountId, int cssId)
    {
      var odataClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(BaseUrl + "api"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, null, impAccountId);
      };
      var customCss = odataClient.CustomCss.ByKey(cssId).GetValue();
      odataClient.DeleteObject(customCss);
      odataClient.SaveChanges();
    }

    /// <summary>
    /// Adds a new company group to the account.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="companyGroup">The new company group to add.</param>
    public void AddCompanyGroup(Guid impAccountId, string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup companyGroup)
    {
      using (var client = new WebClient())
      {
        client.BaseAddress = BaseUrl + "api/agencies('0')/";
        SetClientHeaders(client, bearerToken, impAccountId);

        string request = JSSerializer.Serialize(companyGroup);

        var result = client.UploadString("CompanyGroups", request);
        var returnedGroup = JSSerializer.Deserialize<ApiCompanyGroup>(result);

        companyGroup.RecordID = returnedGroup.RecordID;
        companyGroup.AgencyLinkID = returnedGroup.AgencyLinkID;
      }
    }

    /// <summary>
    /// Adds a new company group to the account using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="companyGroup">The new company group to add.</param>
    public void AddCompanyGroup(Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup companyGroup)
    {
      AddCompanyGroup(impAccountId, null, companyGroup);
    }

    /// <summary>
    /// Adds a new company group to the account using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="companyGroup">The new company group to add.</param>
    public void AddCompanyGroup(string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup companyGroup)
    {
      AddCompanyGroup(Guid.Empty, bearerToken, companyGroup);
    }

    /// <summary>
    /// Updates an existing company group.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="companyGroup">The company group to update.</param>
    public void UpdateCompanyGroup(Guid impAccountId, string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup companyGroup)
    {
      if (companyGroup.RecordID <= 0)
        throw new ArgumentException("Company group RecordID must be provided.");
      using (var client = new WebClient())
      {
        client.BaseAddress = BaseUrl + "api/agencies('0')/";
        SetClientHeaders(client, bearerToken, impAccountId);

        string request = JSSerializer.Serialize(companyGroup);

        client.UploadString("CompanyGroups", "PUT", request);
      }
    }

    /// <summary>
    /// Updates an existing company group using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="companyGroup">The company group to update.</param>
    public void UpdateCompanyGroup(Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup companyGroup)
    {
      UpdateCompanyGroup(impAccountId, null, companyGroup);
    }

    /// <summary>
    /// Updates an existing company group using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>    
    /// <param name="companyGroup">The company group to update.</param>
    public void UpdateCompanyGroup(string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup companyGroup)
    {
      UpdateCompanyGroup(Guid.Empty, bearerToken, companyGroup);
    }

    /// <summary>
    /// Deletes an existing company group.  Deletes are soft deletes, the company group is only marked as inactive.
    /// If the company group is in use by a TurboRater user or location, TFW, or Rate API, the function will fail with a 409 conflict error.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="companyGroupId">The id of the company group to delete.</param>
    public void DeleteCompanyGroup(Guid impAccountId, string bearerToken, int companyGroupId)
    {
      var odataClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(BaseUrl + "api/agencies('0')"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, bearerToken, impAccountId);
      };
      var companyGroup = odataClient.CompanyGroups.ByKey(companyGroupId).GetValue();
      odataClient.DeleteObject(companyGroup);
      odataClient.SaveChanges();
    }

    /// <summary>
    /// Deletes an existing company group using basic authentication.  Deletes are soft deletes, the company group is only marked as inactive.
    /// If the company group is in use by a TurboRater user or location, TFW, or Rate API, the function will fail with a 409 conflict error.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="companyGroupId">The id of the company group to delete.</param>
    public void DeleteCompanyGroup(Guid impAccountId, int companyGroupId)
    {
      DeleteCompanyGroup(impAccountId, null, companyGroupId);
    }

    /// <summary>
    /// Deletes an existing company group using bearer authentication.  Deletes are soft deletes, the company group is only marked as inactive.
    /// If the company group is in use by a TurboRater user or location, TFW, or Rate API, the function will fail with a 409 conflict error.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="companyGroupId">The id of the company group to delete.</param>
    public void DeleteCompanyGroup(string bearerToken, int companyGroupId)
    {
      DeleteCompanyGroup(Guid.Empty, bearerToken, companyGroupId);
    }

    /// <summary>
    /// Retrieves information about an AMS configuration within the authenticated agency using either form of authentication authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="amsConfigId">The AMS configuration ID.</param>
    /// <returns>The AMS configuration we are looking for.</returns>
    public TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAmsConfiguration GetAmsConfiguration(string bearerToken, Guid impAccountId, int amsConfigId)
    {
      var odataClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(BaseUrl + "api/agencies('0')"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, bearerToken, impAccountId);
      };
      var result = odataClient.AmsConfigurations.ByKey(amsConfigId).Expand("Systems").GetValue();
      return result;
    }

    /// <summary>
    /// Retrieves information about an AMS configuration within the authenticated agency using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="amsConfigId">The AMS configuration ID.</param>
    /// <returns>The AMS configuration we are looking for.</returns>
    public TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAmsConfiguration GetAmsConfiguration(Guid impAccountId, int amsConfigId)
    {
      return GetAmsConfiguration(null, impAccountId, amsConfigId);
    }

    /// <summary>
    /// Retrieves information about an AMS configuration within the authenticated agency using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="amsConfigId">The AMS configuration ID.</param>
    /// <returns>The AMS configuration we are looking for.</returns>
    public TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAmsConfiguration GetAmsConfiguration(string bearerToken, int amsConfigId)
    {
      return GetAmsConfiguration(bearerToken, Guid.Empty, amsConfigId);
    }

    /// <summary>
    /// Adds a new AMS configuration to the account.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="amsConfig">The new AMS configuration to add.</param>
    public void AddAmsConfiguration(Guid impAccountId, string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAmsConfiguration amsConfig)
    {
      using (var client = new WebClient())
      {
        client.BaseAddress = BaseUrl + "api/agencies('0')/";
        SetClientHeaders(client, bearerToken, impAccountId);

        string request = JSSerializer.Serialize(amsConfig);

        var result = client.UploadString("AmsConfigurations", request);
        var returnedGroup = JSSerializer.Deserialize<ApiAmsConfiguration>(result);

        amsConfig.ConfigurationId = returnedGroup.ConfigurationId;
      }
    }

    /// <summary>
    /// Adds a new AMS configuration to the account using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="amsConfig">The new AMS configuration to add.</param>
    public void AddAmsConfiguration(Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAmsConfiguration amsConfig)
    {
      AddAmsConfiguration(impAccountId, null, amsConfig);
    }

    /// <summary>
    /// Adds a new AMS configuration to the account using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="amsConfig">The new AMS configuration to add.</param>
    public void AddAmsConfiguration(string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAmsConfiguration amsConfig)
    {
      AddAmsConfiguration(Guid.Empty, bearerToken, amsConfig);
    }

    /// <summary>
    /// Updates an existing AMS configuration.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="amsConfig">The AMS configuration to update.</param>
    public void UpdateAmsConfiguration(Guid impAccountId, string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAmsConfiguration amsConfig)
    {
      if (amsConfig.ConfigurationId <= 0)
        throw new ArgumentException("AMS ConfigurationId must be provided.");
      using (var client = new WebClient())
      {
        client.BaseAddress = BaseUrl + "api/agencies('0')/";
        SetClientHeaders(client, bearerToken, impAccountId);

        string request = JSSerializer.Serialize(amsConfig);

        client.UploadString("AmsConfigurations", "PUT", request);
      }
    }

    /// <summary>
    /// Updates an existing AMS configuration using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="amsConfig">The AMS configuration to update.</param>
    public void UpdateAmsConfiguration(Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAmsConfiguration amsConfig)
    {
      UpdateAmsConfiguration(impAccountId, null, amsConfig);
    }

    /// <summary>
    /// Updates an existing AMS configuration using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="amsConfig">The AMS configuration to update.</param>
    public void UpdateAmsConfiguration(string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAmsConfiguration amsConfig)
    {
      UpdateAmsConfiguration(Guid.Empty, bearerToken, amsConfig);
    }

    /// <summary>
    /// Deletes an existing AMS configuration.   Note: this is a hard delete.
    /// If the AMS configuration is in use by a TurboRater user or location, the function will fail with a 409 conflict error.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="amsConfigId">The id of the AMS configuration to delete.</param>
    public void DeleteAmsConfiguration(Guid impAccountId, string bearerToken, int amsConfigId)
    {
      var odataClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(BaseUrl + "api/agencies('0')"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, bearerToken, impAccountId);
      };
      var amsConfig = odataClient.AmsConfigurations.ByKey(amsConfigId).GetValue();
      odataClient.DeleteObject(amsConfig);
      odataClient.SaveChanges();
    }

    /// <summary>
    /// Deletes an existing AMS configuration using basic authentication.   Note: this is a hard delete.
    /// If the AMS configuration is in use by a TurboRater user or location, the function will fail with a 409 conflict error.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="amsConfigId">The id of the AMS configuration to delete.</param>
    public void DeleteAmsConfiguration(Guid impAccountId, int amsConfigId)
    {
      DeleteAmsConfiguration(impAccountId, null, amsConfigId);
    }

    /// <summary>
    /// Deletes an existing AMS configuration using bearer authentication.   Note: this is a hard delete.
    /// If the AMS configuration is in use by a TurboRater user or location, the function will fail with a 409 conflict error.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="amsConfigId">The id of the AMS configuration to delete.</param>
    public void DeleteAmsConfiguration(string bearerToken, int amsConfigId)
    {
      DeleteAmsConfiguration(Guid.Empty, bearerToken, amsConfigId);
    }

    /// <summary>
    /// Adds an embedded rating agency into the TurboRater.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="agency">The agency to add.</param>
    public void AddEmbeddedRatingAgency(Guid impAccountId, string bearerToken, ApiEmbeddedRatingAgency agency)
    {
      var odataClient = new Default.Container(new Uri(BaseUrl + "api"));
      odataClient.SendingRequest2 += (sender, eventArgs) =>
      {
        SetClientHeadersOData(eventArgs.RequestMessage, bearerToken, impAccountId);
      };
      odataClient.AddToEmbeddedRating(agency);
      odataClient.SaveChanges();
    }

    /// <summary>
    /// Adds an embedded rating agency into the TurboRater, using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="agency">The agency to add.</param>
    public void AddEmbeddedRatingAgency(Guid impAccountId, ApiEmbeddedRatingAgency agency)
    {
      AddEmbeddedRatingAgency(impAccountId, null, agency);
    }

    /// <summary>
    /// Adds an embedded rating agency into the TurboRater, using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="agency">The agency to add.</param>
    public void AddEmbeddedRatingAgency(string bearerToken, ApiEmbeddedRatingAgency agency)
    {
      AddEmbeddedRatingAgency(Guid.Empty, bearerToken, agency);
    }

    /// <summary>
    /// Sets the TurboRater maximum user count for the agency associated with the bearer token.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="newUserCount">The new user count for the account associated with the bearer token.</param>
    public void SetEmbeddedRatingUserCount(string bearerToken, int newUserCount)
    {
      if (newUserCount <= 0)
        throw new ArgumentException("Value must be greater than zero.", "newUserCount");
      if (newUserCount > 9999)
        throw new ArgumentException("Value must be greater less than 10000.", "newUserCount");
      var agency = new ApiEmbeddedRatingAgency();
      agency.AgencyID = string.Empty;
      agency.NumUsers = newUserCount;

      using (var client = new WebClient())
      {
        client.BaseAddress = BaseUrl + "api/";
        SetClientHeaders(client, bearerToken, Guid.Empty);

        string request = JSSerializer.Serialize(agency);

        client.UploadString("EmbeddedRating", "PUT", request);
      }

    }

    /// <summary>
    /// Generates/retrieves a bearer token for usage in BEARER storage authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="integrationKey">Integration key supplied by ITC.</param>
    /// <returns>Bearer token used for BEARER auth storage operations.</returns>
    public string GetBearerToken(Guid impAccountId, string integrationKey)
    {
      using (var client = new WebClient())
      {
        SetClientHeaders(client, String.Empty, impAccountId);
        var request = new ImpUser() { IntegrationKey = integrationKey };
        string response = string.Empty;
        try
        {
          response = client.UploadString(BaseUrl + "api/auth/turborater", JSSerializer.Serialize(request));
          response = JSSerializer.Deserialize<string>(response);
        }
        catch (WebException ex)
        {
          if (ex.Response != null && ex.Response.ContentLength > 0)
          {
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
              response = reader.ReadToEnd();
          }
          HttpWebResponse res = (HttpWebResponse)ex.Response;
          throw new HttpException((int)res.StatusCode, "Error retrieving bearer token: " + res.StatusCode + "::" + response);
        }
        return response;
      }
    }

    /// <summary>
    /// Gets a list of supported model years supported by the vehicle database.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <returns>A list of years supported by the vehicle database.</returns>
    public List<int> GetVehicleYears(Guid impAccountId)
    {
      using (var client = new WebClient())
      {
        client.Headers.Add("content-type", "application/json");
        client.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(impAccountId.ToString() + ":" + impAccountId.ToString())));

        string response = client.DownloadString(BaseUrl + "api/vehicles/years");
        return JSSerializer.Deserialize<List<int>>(response);
      }
    }

    /// <summary>
    /// Gets a list of vehicle makes for a specific year.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="year">The model year of the vehicle.</param>
    /// <returns>A list of vehicle makes for a specific year.</returns>
    public List<string> GetVehicleMakes(Guid impAccountId, int year)
    {
      using (var client = new WebClient())
      {
        client.Headers.Add("content-type", "application/json");
        client.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(impAccountId.ToString() + ":" + impAccountId.ToString())));

        string response = client.DownloadString(BaseUrl + "api/vehicles/" + year);
        return JSSerializer.Deserialize<List<string>>(response);
      }
    }

    /// <summary>
    /// Gets a list of vehicle models for a specific year and make.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="year">The model year of the vehicle.</param>
    /// <param name="make">The vehicle make.</param>
    /// <returns>A list of vehicle models for a specific year and make.</returns>
    public List<string> GetVehicleModels(Guid impAccountId, int year, string make)
    {
      if (make == null)
        throw new ArgumentNullException("make");
      using (var client = new WebClient())
      {
        client.Headers.Add("content-type", "application/json");
        client.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(impAccountId.ToString() + ":" + impAccountId.ToString())));

        string response = client.DownloadString(BaseUrl + "api/vehicles/" + year + "/" + make.Trim().ToUpper());
        return JSSerializer.Deserialize<List<string>>(response);
      }
    }

    /// <summary>
    /// Gets a list of vehicle detail information for a specific year, make and model.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="year">The model year of the vehicle.</param>
    /// <param name="make">The vehicle make.</param>
    /// <param name="model">The vehicle model.</param>
    /// <returns>A list of vehicle detail information for a specific year, make and model</returns>
    public List<ImpVinResponse> GetVehicleDetails(Guid impAccountId, int year, string make, string model)
    {
      if (make == null)
        throw new ArgumentNullException("make");
      if (model == null)
        throw new ArgumentNullException("model");
      using (var client = new WebClient())
      {
        client.Headers.Add("content-type", "application/json");
        client.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(impAccountId.ToString() + ":" + impAccountId.ToString())));

        string response = client.DownloadString(BaseUrl + "api/vehicles/" + year + "/" + make.Trim().ToUpper() + "/" + model.Trim().ToUpper());
        return JSSerializer.Deserialize<List<ImpVinResponse>>(response);
      }
    }

    /// <summary>
    /// Gets vehicle detail information for a specific vehicle by 10 digit partial VIN pr 17 digit full VIN.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="vin">The VIN of the vehicle.</param>
    /// <returns>Vehicle detail information for a specific vehicle by VIN.</returns>
    public ImpVinResponse GetVehicleDetailByVin(Guid impAccountId, string vin)
    {
      if (vin == null)
        throw new ArgumentNullException("make");
      using (var client = new WebClient())
      {
        client.Headers.Add("content-type", "application/json");
        client.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(impAccountId.ToString() + ":" + impAccountId.ToString())));

        string response = client.DownloadString(BaseUrl + "api/vehicles/detail/" + vin.Trim().ToUpper());
        return JSSerializer.Deserialize<ImpVinResponse>(response);
      }
    }

    /// <summary>
    /// Returns a set of all default limits for a state.  Optionally returns a single set of defaults based on a set of liability limits.
    /// </summary>
    /// <param name="line">The insurance line.</param>
    /// <param name="state">The state being rated.</param>
    /// <param name="liabLimit1">Optional per person liability limit (for example, 25 in 25/50).</param>
    /// <param name="liabLimit2">Optional per accident liability limit (for example, 50 in 25/50).</param>
    /// <returns>The defaults for coverages for one or more liability limits.</returns>
    public List<LimitDefaultGroup> GetDefaultLimits(InsuranceLine line, USState state, int? liabLimit1 = null, int? liabLimit2 = null)
    {
      using (var client = new WebClient())
      {
        client.Headers.Add("content-type", "application/json");
        string lineCd = ImpConstants.LobCodes[(int)line];
        string stateCd = ITCConstants.StateAbbreviations[(int)state];
        string limits = string.Empty;
        if (liabLimit1 != null && liabLimit2 != null)
          limits = "/" + liabLimit1.ToString() + ";" + liabLimit2.ToString();
        string response = client.DownloadString(BaseUrl + "api/coverages/defaults/" + lineCd + "/" + stateCd.ToUpper() + limits);
        return JSSerializer.Deserialize<List<LimitDefaultGroup>>(response);
      }
    }

    /// <summary>
    /// Return a premium valuation for a given property
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="request">the premium valuation request object</param>
    /// <param name="forLookup">valuation versus lookup (estimate versus prefill)</param>
    /// <returns>premium valuation for a given property</returns>
    public PremiumValuationResponse GetPremiumValuation(Guid impAccountId, PremiumValuationRequest request, bool forLookup = false)
    {
      if (request == null)
        throw new ArgumentNullException("request");
      using (var client = new WebClient())
      {
        client.Headers.Add("content-type", "application/json");
        client.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(impAccountId.ToString() + ":" + impAccountId.ToString())));

        string response = string.Empty;
        try
        {
          response = client.UploadString(BaseUrl + "api/PropertyValuation?forLookup=" + (forLookup ? "true" : "false"), JSSerializer.Serialize(request));
        }
        catch (WebException ex)
        {
          if (ex.Response != null && ex.Response.ContentLength > 0)
          {
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
              response = reader.ReadToEnd();
          }
          HttpWebResponse res = (HttpWebResponse)ex.Response;
          throw new HttpException((int)res.StatusCode, "Error getting premium valuation data: " + res.StatusCode + "::" + response);
        }
        return String.IsNullOrWhiteSpace(response) ? null : JSSerializer.Deserialize<PremiumValuationResponse>(response);
      }
    }

    /// <summary>
    /// Returns a list of quote policy audit data.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="quoteUid">The id of the quote.</param>
    /// <returns>the list of quote policy audit data associated w/ the requested policy</returns>
    public List<PolicyAuditModel> GetPolicyModelData(Guid impAccountId, Guid quoteUid)
    {
      using (var client = new WebClient())
      {
        client.Headers.Add("content-type", "application/json");
        client.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(impAccountId.ToString() + ":" + impAccountId.ToString())));

        string response = string.Empty;
        try
        {
          response = client.DownloadString(BaseUrl + "api/policyaudit/?quoteuid=" + quoteUid.ToString());
        }
        catch (WebException ex)
        {
          if (ex.Response != null && ex.Response.ContentLength > 0)
          {
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
              response = reader.ReadToEnd();
          }
          HttpWebResponse res = (HttpWebResponse)ex.Response;
          throw new HttpException((int)res.StatusCode, "Error getting premium valuation data: " + res.StatusCode + "::" + response);
        }
        return String.IsNullOrWhiteSpace(response) ? null : JSSerializer.Deserialize<List<PolicyAuditModel>>(response);
      }
    }

    /// <summary>
    /// Adds a quote template into TurboRater, using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="template">The quote template to add.</param>
    public void AddQuoteTemplate(Guid impAccountId, string bearerToken, QuoteTemplate template)
    {
      using (var client = new WebClient())
      {
        client.BaseAddress = BaseUrl + "api/";
        SetClientHeaders(client, bearerToken, impAccountId);
        string request = JSSerializer.Serialize(template);

        try
        {
          client.UploadString("templates", "POST", request);
        }
        catch (WebException ex)
        {
          string response = string.Empty;
          if (ex.Response != null && ex.Response.ContentLength > 0)
          {
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
              response = reader.ReadToEnd();
          }
          HttpWebResponse res = (HttpWebResponse)ex.Response;
          throw new HttpException((int)res.StatusCode, "Error adding quote template: " + res.StatusCode + "::" + response);
        }
      }
    }

    /// <summary>
    /// Get a quote template from TurboRater
    /// </summary>
    /// <param name="impAccountId">Guid Agency Account</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="recordId">quote template record id</param>
    /// <returns>A single quote template object</returns>
    public QuoteTemplate GetQuoteTemplate(Guid impAccountId, string bearerToken, int recordId)
    {
      using (var client = new WebClient())
      {
        client.Headers.Add("content-type", "application/json");
        SetClientHeaders(client, bearerToken, impAccountId);
        string response = string.Empty;

        try
        {
          string blah = BaseUrl + "api/templates?id=" + recordId.ToString();
          response = client.DownloadString(blah);
          return JSSerializer.Deserialize<QuoteTemplate>(response);
        }
        catch (WebException ex)
        {
          if (ex.Response != null && ex.Response.ContentLength > 0)
          {
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
              response = reader.ReadToEnd();
          }
          HttpWebResponse res = (HttpWebResponse)ex.Response;
          throw new HttpException((int)res.StatusCode, "Error getting quote template: " + res.StatusCode + "::" + response);
        }
      }
    }

    /// <summary>
    /// Get quote templates from TurboRater
    /// </summary>
    /// <param name="impAccountId">Guid Agency Account</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <returns>A list of quote template objects</returns>
    public List<QuoteTemplate> GetQuoteTemplates(Guid impAccountId, string bearerToken)
    {
      using (var client = new WebClient())
      {
        client.Headers.Add("content-type", "application/json");
        SetClientHeaders(client, bearerToken, impAccountId);
        string response = string.Empty;

        try
        {
          string blah = BaseUrl + "api/templates";
          response = client.DownloadString(blah);
          return JSSerializer.Deserialize<List<QuoteTemplate>>(response);
        }
        catch (WebException ex)
        {
          if (ex.Response != null && ex.Response.ContentLength > 0)
          {
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
              response = reader.ReadToEnd();
          }
          HttpWebResponse res = (HttpWebResponse)ex.Response;
          throw new HttpException((int)res.StatusCode, "Error getting quote templates: " + res.StatusCode + "::" + response);
        }
      }
    }

    /// <summary>
    /// Updates an existing quote template using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="template">The quote template to update.</param>
    public void UpdateQuoteTemplate(Guid impAccountId, string bearerToken, QuoteTemplate template)
    {
      if (template.RecordId <= 0)
        throw new ArgumentException("Template RecordID must be provided.");
      using (var client = new WebClient())
      {
        client.BaseAddress = BaseUrl + "api/";
        SetClientHeaders(client, bearerToken, impAccountId);

        try
        {
          string request = JSSerializer.Serialize(template);
          client.UploadString("templates", "PUT", request);
        }
        catch (WebException ex)
        {
          string response = string.Empty;
          if (ex.Response != null && ex.Response.ContentLength > 0)
          {
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
              response = reader.ReadToEnd();
          }
          HttpWebResponse res = (HttpWebResponse)ex.Response;
          throw new HttpException((int)res.StatusCode, "Error getting quote template: " + res.StatusCode + "::" + response);
        }

      }
    }

    /// <summary>
    /// Deletes a quote template. note this is a hard delete
    /// </summary>
    /// <param name="impAccountId">Guid Agency Account</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="recordId">quote template record id</param>
    public void DeleteQuoteTemplate(Guid impAccountId, string bearerToken, int recordId)
    {
      if (recordId <= 0)
        throw new ArgumentException("Template RecordID must be provided.");
      using (var client = new WebClient())
      {
        client.BaseAddress = BaseUrl + "api/";
        SetClientHeaders(client, bearerToken, impAccountId);
        try
        {
          client.UploadString("templates/(" + recordId.ToString() + ")", "DELETE", "");
        }
        catch (WebException ex)
        {
          string response = string.Empty;
          if (ex.Response != null && ex.Response.ContentLength > 0)
          {
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
              response = reader.ReadToEnd();
          }
          HttpWebResponse res = (HttpWebResponse)ex.Response;
          throw new HttpException((int)res.StatusCode, "Error getting quote template: " + res.StatusCode + "::" + response);
        }

      }
    }

    /// <summary>
    /// Applies a quote template to a policy. 
    /// </summary>
    /// <param name="impAccountId">Guid Agency Account</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="request">Returns a serialized copy of the policy with quote template changes applied.</param>
    /// <returns>Policy data with quote template defaults applied to it</returns>
    public string ApplyQuoteTemplate(Guid impAccountId, string bearerToken, ApplyTemplateRequest request)
    {
      if (request == null)
        throw new ArgumentException("ApplyTemplateRequest must be provided.");
      if (request.TemplateId <= 0)
        throw new ArgumentException("Template RecordID must be provided.");
      if (string.IsNullOrWhiteSpace(request.PolicyData))
        throw new ArgumentException("A policy must be provided.");
      using (var client = new WebClient())
      {
        client.BaseAddress = BaseUrl + "api/";
        SetClientHeaders(client, bearerToken, impAccountId);
        return client.UploadString("Templates/Apply", "POST", JsonConvert.SerializeObject(request));
      }
    }

    /// <summary>
    /// Applies a quote template to a policy. 
    /// </summary>
    /// <param name="impAccountId">Guid Agency Account</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="policy">the policy to have the template applied to.</param>
    /// <param name="quoteTemplateId">the quote template to apply.</param>
    /// <returns>The requested policy after having the template defaults applied to it.</returns>
    public InsPolicy ApplyQuoteTemplate(Guid impAccountId, string bearerToken, InsPolicy policy, int quoteTemplateId)
    {
      if (policy == null)
        throw new ArgumentException("A policy must be provided.");
      if (quoteTemplateId <= 0)
        throw new ArgumentException("A quote template ID must be provided.");
      using (var client = new WebClient())
      {
        var request = new ApplyTemplateRequest { PolicyData = TransformationHelper.SerializePolicy(policy), TemplateId = quoteTemplateId };
        client.BaseAddress = BaseUrl + "api/";
        SetClientHeaders(client, bearerToken, impAccountId);
        var result = client.UploadString("Templates/Apply", "POST", JsonConvert.SerializeObject(request));
        return TransformationHelper.DeserializePolicy(result, policy.LineOfInsurance);
      }
    }

    /// <summary>
    /// Adds an agency quote storage notification url 
    /// </summary>
    /// <param name="impAccountId">Guid Agency Account</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="notificationUrl">the notification url</param>
    /// <param name="httpMethod">the http method to use for the notification</param>
    /// <param name="notificationDelay">the delay before sending the notification</param>
    public void SetAgencyQuoteStorageNotificationUrl(string bearerToken, string notificationUrl, HttpMethods httpMethod = HttpMethods.GET, int notificationDelay = 0)
    {
      SetAgencyQuoteStorageNotificationUrl(Guid.Empty, bearerToken, notificationUrl, httpMethod, notificationDelay); 
    }

    /// <summary>
    /// Adds an agency quote storage notification url 
    /// </summary>
    /// <param name="impAccountId">Guid Agency Account</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="notificationUrl">the notification url</param>
    /// <param name="httpMethod">the http method to use for the notification</param>
    /// <param name="notificationDelay">the delay before sending the notification</param>
    public void SetAgencyQuoteStorageNotificationUrl(Guid impAccountId, string notificationUrl, HttpMethods httpMethod = HttpMethods.GET, int notificationDelay = 0)
    {
      SetAgencyQuoteStorageNotificationUrl(impAccountId, null, notificationUrl, httpMethod, notificationDelay);
    }

    /// <summary>
    /// Adds an agency quote storage notification url 
    /// </summary>
    /// <param name="impAccountId">Guid Agency Account</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="notificationUrl">the notification url</param>
    /// <param name="httpMethod">the http method to use for the notification</param>
    /// <param name="notificationDelay">the delay before sending the notification</param>
    public void SetAgencyQuoteStorageNotificationUrl(Guid impAccountId, string bearerToken, string notificationUrl, HttpMethods httpMethod = HttpMethods.GET, int notificationDelay = 0)
    {
      if (string.IsNullOrWhiteSpace(notificationUrl))
        throw new ArgumentException("NotificationUrl must be provided.");
      if (!notificationUrl.ToLower().Contains("https")) 
        throw new ArgumentException("Invalid Notification URL: https is required.");

      var request = new AgencyQuoteStorageNotificationRequest {
        NotificationUrl = notificationUrl, 
        NotificationDelay = notificationDelay, 
        HttpMethod = httpMethod.ToString()
      };

      using (var client = new WebClient())
      {
        client.BaseAddress = BaseUrl + "api/";
        SetClientHeaders(client, bearerToken, impAccountId);
        client.UploadString("agencies/notifications", "POST", JsonConvert.SerializeObject(request));
      }
    }

    /// <summary>
    /// Gets a list of violations for the current state.
    /// </summary>
    /// <param name="state">The state </param>
    /// <returns>list of violations for the state</returns>
    public List<Item> GetViolationsForState(USState state)
    {
      if (state == USState.NoneSelected)
        throw new ArgumentException("A valid state is required.");

      using (var client = new WebClient())
      {
        client.BaseAddress = BaseUrl + "api/";
        client.Headers.Add("content-type", "application/json");        
        var result = client.DownloadString($"violations?stateProvCd={ITCConstants.StateAbbreviations[(int)state]}");
        return JSSerializer.Deserialize<List<Item>>(result);
      }
    }

    /// <summary>
    /// Adds the appropriate embedded rating purchased product code to the authenticated agency in CRM.
    /// The appropriate embedded rating purchased product code is determined by a setting in the IMP account.
    /// An exampl of embedded rating pprod code is CPAAER for AccuAgency embedded rating.
    /// </summary>
    /// <param name="impAccountId">Guid Agency Account</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    public void AddEmbeddedRatingPurchasedProduct(Guid impAccountId, string bearerToken)
    {
      using (var client = new WebClient())
      {
        client.BaseAddress = BaseUrl + "api/";
        SetClientHeaders(client, bearerToken, impAccountId);
        try
        {
          client.UploadData($"embeddedrating/AddEmbeddedRatingPurchasedProduct", "POST", new byte[0]);
        }
        catch (WebException ex)
        {
          string response = string.Empty;
          if (ex.Response != null && ex.Response.ContentLength > 0)
          {
            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
              response = reader.ReadToEnd();
          }
          HttpWebResponse res = (HttpWebResponse)ex.Response;
          throw new HttpException((int)res.StatusCode, "Error adding embedded rating purchased product: " + res.StatusCode + "::" + response);
        }
      }
    }

  }
}
