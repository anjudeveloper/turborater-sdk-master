using System;
using System.Collections.Generic;
using TurboRater.Insurance;
using TurboRater.Insurance.DataTransformation;
using TurboRater.InterfaceSpecifications;
using TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage;
using System.Web.Script.Serialization;

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Interface to a client for connecting to the IMP coverage service.
  /// </summary>
  public interface IImpClient
  {
    /// <summary>
    /// JavaScript serializer used by many methods to serialize/deserialize data from our IMP API.
    /// </summary>
    JavaScriptSerializer JSSerializer { get; set; }

    /// <summary>
    /// The base URL used to connect to the service.
    /// </summary>
    string BaseUrl { get; set; }

    /// <summary>
    /// Returns all coverages for all states.
    /// </summary>
    /// <param name="line">The line of insurance to retrieve.</param>
    /// <param name="auth">The authorization credentials.</param>
    /// <returns>A list of state coverages available for the line of business specified.</returns>
    IList<ImpCoverageContainer> GetAllStateCoverages(InsuranceLine line, Guid auth);

    /// <summary>
    /// Returns all coverages for the specified state.
    /// </summary>
    /// <param name="line">The line of insurance to retrieve.</param>
    /// <param name="auth">The authorization credentials.</param>
    /// <param name="state">The state to retrieve.</param>
    /// <returns>A list of coverages available for the state and line of business specified.</returns>
    ImpCoverageContainer GetStateCoverages(InsuranceLine line, USState state, Guid auth);

    /// <summary>
    /// Gets the PPC code information for the specified address info. Note that if there is an exact address match you'll get just a single
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
    List<PpcInfo> Ppc(Guid auth, string state, string zipCode, string street, string streetType = "", string streetNumber = "",
      string streetPre = "", string streetPost = "");

    /// <summary>
    /// Gets the Fire Districts information for the specified state/county combination. Currently only used in CA/OK/PA
    /// </summary>
    /// <param name="auth">The authorization credentials.</param>
    /// <param name="state">the state in which this fire district is located</param>
    /// <param name="county">the county in which this fire district is located</param>
    /// <returns>Fire District information</returns>
    List<string> FireDistricts(Guid auth, string state, string county);

    /// <summary>
    /// Returns a list of states. If no zipcode is sent this returns all states. If a zipcode is sent, this returns all
    /// states that the zipcode is within
    /// </summary>
    /// <param name="auth">The authorization credentials.</param>
    /// <param name="zipCode">Optional. the zipcode contained by the returned states.</param>
    /// <returns>list of states, or empty list if no match on specified zipcode.</returns>
    IList<string> States(Guid auth, string zipCode = "");

    /// <summary>
    /// Returns a list of counties that match the specified state and zipCode
    /// </summary>
    /// <param name="auth">The authorization credentials.</param>
    /// <param name="state">the state</param>
    /// <param name="zipCode">the zipcode contained by the returned states.</param>
    /// <returns>list of counties, or empty list if no match on specified criteria.</returns>
    IList<string> Counties(Guid auth, string state, string zipCode);

    /// <summary>
    /// Returns a JSON representation of the turborater interface 
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.  If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="lineOfBusiness">Line of business.</param>
    /// <param name="stateCode">The state abbreviation.</param>
    /// <returns>a JSON representation of the turborater interface </returns>
    InterfaceDefinition GetTurboRaterInterfaceSpecifications(string bearerToken, Guid impAccountId, string lineOfBusiness, string stateCode);

    /// <summary>
    /// Validates the specified tt2 data.
    /// </summary>
    /// <param name="auth">The IMP account ID. If you leave this null, no IMP acct is used for auth.</param>
    /// <param name="policy">Request containing tt2 data and other things.</param>
    /// <returns>TT2ValidationError list containing any validation failures.</returns>
    List<TT2ValidationError> ValidationTurboRater(Guid? auth, ValidatePolicyRequest policy);

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
    string UnlockPolicy(string bearerToken, int policyId, InsuranceLine line, USState state, Guid userId, Guid locationId);

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
    string UnlockPolicy(Guid impAccountId, int policyId, InsuranceLine line, USState state, Guid userId, Guid locationId);

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
    string UnlockPolicy(string bearerToken, Guid impAccountId, int policyId, InsuranceLine line, USState state, Guid userId, Guid locationId);

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
    SavePolicyResponse SavePolicy(Guid impAccountId, InsPolicy policy, bool lockPolicyForUser = false, bool overrideExistingLock = false,
      Guid? locationId = null, Guid? userId = null);

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
    SavePolicyResponse SavePolicy(string bearerToken, InsPolicy policy, bool lockPolicyForUser = false, bool overrideExistingLock = false,
      Guid? locationId = null, Guid? userId = null);

    /// <summary>
    /// Loads a policy from online storage by bearer token, using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="line">The line of insurance of the policy to retrieve.</param>
    /// <param name="id">The id of the policy to retrieve.</param>
    /// <param name="formatType">The formate of the response.  Defaults to tt2.</param>
    /// <returns>An object containing the full policy and the response data from IMP.</returns>
    QuoteLoadWrapper LoadPolicy(string bearerToken, InsuranceLine line, int id, BridgeContentType formatType = BridgeContentType.TT2);

    /// <summary>
    /// Loads a policy from online storage by Imp account id, using basic authentication. 
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="line">The line of insurance of the policy to retrieve.</param>
    /// <param name="id">The id of the policy to retrieve.</param>
    /// <param name="formatType">The formate of the response.  Defaults to tt2.</param>
    /// <returns>An object containing the full policy and the response data from IMP.</returns>
    QuoteLoadWrapper LoadPolicy(Guid impAccountId, InsuranceLine line, int id, BridgeContentType formatType = BridgeContentType.TT2);

    /// <summary>
    /// Deletes a policy by bearer token, using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="line">The line of insurance of the policy to delete.</param>
    /// <param name="policyId">The id of the policy to delete.</param>
    /// <returns>The record id of the policy if successful, -1 if not.</returns>
    int DeletePolicy(string bearerToken, InsuranceLine line, int policyId);

    /// <summary>
    /// Deletes a policy by imp account id, using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="line">The line of insurance of the policy to delete.</param>
    /// <param name="policyId">The id of the policy to delete.</param>
    /// <returns>The record id of the policy if successful, -1 if not.</returns>
    int DeletePolicy(Guid impAccountId, InsuranceLine line, int policyId);

    /// <summary>
    /// Searches online storage for insureds by bearer token using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="start">The quote modified/inserted date/time start for the date search range.</param>
    /// <param name="end">The quote modified/inserted date/time end for the date search range.</param>
    /// <param name="lines">Optional lines of insurance to search.</param>
    /// <returns>A list of insureds, each containing a list of policies.</returns>
    StorageSearchResult StorageSearch(string bearerToken, DateTime start, DateTime end, IEnumerable<InsuranceLine> lines);

    /// <summary>
    /// Searches online storage for insureds using imp account id and basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="start">The quote modified/inserted date/time start for the date search range.</param>
    /// <param name="end">The quote modified/inserted date/time end for the date search range.</param>
    /// <param name="lines">Optional lines of insurance to search.</param>
    /// <returns>A list of insureds, each containing a list of policies.</returns>
    StorageSearchResult StorageSearch(Guid impAccountId, DateTime start, DateTime end, IEnumerable<InsuranceLine> lines);

    /// <summary>
    /// Searches online storage for insureds and quotes using either form of authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.  If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="policy">The policy to validate.</param>
    /// <returns>A list of policy errors.</returns>
    List<TT2ValidationError> ValidatePolicy(string bearerToken, Guid impAccountId, InsPolicy policy);

    /// <summary>
    /// Searches online storage for insureds and quotes using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="policy">The policy to validate.</param>
    /// <returns>A list of policy errors.</returns>
    List<TT2ValidationError> ValidatePolicy(string bearerToken, InsPolicy policy);

    /// <summary>
    /// Searches online storage for insureds and quotes using basic auth.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="policy">The policy to validate.</param>
    /// <returns>A list of policy errors.</returns>
    List<TT2ValidationError> ValidatePolicy(Guid impAccountId, InsPolicy policy);

    /// <summary>
    /// Retrieves information about the authenticated agency using either form of authentication authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <returns>The authenticated agency.</returns>
    TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgency GetAgency(string bearerToken, Guid impAccountId);

    /// <summary>
    /// Retrieves information about the authenticated agency using BEARER authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <returns>The authenticated agency.</returns>
    TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgency GetAgency(string bearerToken);

    /// <summary>
    /// Retrieves information about the authenticated agency using BASIC authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <returns>The authenticated agency.</returns>
    TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgency GetAgency(Guid impAccountId);

    /// <summary>
    /// Retrieves information about a location within the authenticated agency using either form of authentication authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="locationId">The agency location ID.</param>
    /// <returns>The location we are looking for.</returns>
    TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation GetLocation(string bearerToken, Guid impAccountId, Guid locationId);

    /// <summary>
    /// Retrieves information about a location within the authenticated agency using BEARER authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="locationId">The agency location ID.</param>
    /// <returns>The location we are looking for.</returns>
    TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation GetLocation(string bearerToken, Guid locationId);

    /// <summary>
    /// Retrieves information about a location within the authenticated agency using BASIC authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="locationId">The agency location ID.</param>
    /// <returns>The location we are looking for.</returns>
    TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation GetLocation(Guid impAccountId, Guid locationId);

    /// <summary>
    /// Adds a location to the authenticated agency.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="location">The agency location to add to the agency.</param>
    void AddLocation(string bearerToken, Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation location);

    /// <summary>
    /// Adds a location to the authenticated agency using BEARER authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="location">The agency location to add to the agency.</param>
    void AddLocation(string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation location);

    /// <summary>
    /// Adds a location to the authenticated agency using BASIC authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="location">The agency location to add to the agency.</param>
    void AddLocation(Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation location);

    /// <summary>
    /// Updates a location within the authenticated agency.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="location">The agency location to update within the agency.</param>
    void UpdateLocation(string bearerToken, Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation location);

    /// <summary>
    /// Updates a location within the authenticated agency using BEARER authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="location">The agency location to update within the agency.</param>
    void UpdateLocation(string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation location);

    /// <summary>
    /// Updates a location within the authenticated agency using BASIC authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="location">The agency location to update within the agency.</param>
    void UpdateLocation(Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyLocation location);

    /// <summary>
    /// Deletes a location within the authenticated agency using either form of authentication authentication.
    /// Note that deletes are soft deletes, so the location will still exist after deletion. The Active property
    /// will be set to false.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="locationId">The agency location ID.</param>
    void DeleteLocation(string bearerToken, Guid impAccountId, Guid locationId);

    /// <summary>
    /// Deletes a location within the authenticated agency using BEARER authentication.
    /// Note that deletes are soft deletes, so the location will still exist after deletion. The Active property
    /// will be set to false.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="locationId">The agency location ID.</param>
    void DeleteLocation(string bearerToken, Guid locationId);

    /// <summary>
    /// Deletes a location within the authenticated agency using BASIC authentication.
    /// Note that deletes are soft deletes, so the location will still exist after deletion. The Active property
    /// will be set to false.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="locationId">The agency location ID.</param>
    void DeleteLocation(Guid impAccountId, Guid locationId);

    /// <summary>
    /// Retrieves information about a user within the authenticated agency using either form of authentication authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="userId">The agency user ID.</param>
    /// <returns>The user we are looking for.</returns>
    TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser GetUser(string bearerToken, Guid impAccountId, Guid userId);

    /// <summary>
    /// Retrieves information about a user within the authenticated agency using BEARER authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="userId">The agency user ID.</param>
    /// <returns>The user we are looking for.</returns>
    TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser GetUser(string bearerToken, Guid userId);

    /// <summary>
    /// Retrieves information about a user within the authenticated agency using BASIC authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="userId">The agency user ID.</param>
    /// <returns>The user we are looking for.</returns>
    TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser GetUser(Guid impAccountId, Guid userId);

    /// <summary>
    /// Adds a user to the authenticated agency.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="user">The agency user to add to the agency.</param>
    void AddUser(string bearerToken, Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser user);

    /// <summary>
    /// Adds a user to the authenticated agency using BEARER authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="user">The agency user to add to the agency.</param>
    void AddUser(string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser user);

    /// <summary>
    /// Adds a user to the authenticated agency using BASIC authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="user">The agency user to add to the agency.</param>
    void AddUser(Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser user);

    /// <summary>
    /// Updates a user within the authenticated agency.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="user">The agency user to update within the agency.</param>
    void UpdateUser(string bearerToken, Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser user);

    /// <summary>
    /// Updates a user within the authenticated agency using BEARER authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="user">The agency user to update within the agency.</param>
    void UpdateUser(string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser user);

    /// <summary>
    /// Updates a user within the authenticated agency using BASIC authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="user">The agency user to update within the agency.</param>
    void UpdateUser(Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAgencyUser user);

    /// <summary>
    /// Deletes a user within the authenticated agency using either form of authentication authentication.
    /// Note that deletes are soft deletes, so the user will still exist after deletion. The Active property
    /// will be set to false.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="userId">The agency user ID.</param>
    void DeleteUser(string bearerToken, Guid impAccountId, Guid userId);

    /// <summary>
    /// Deletes a user within the authenticated agency using BEARER authentication.
    /// Note that deletes are soft deletes, so the user will still exist after deletion. The Active property
    /// will be set to false.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="userId">The agency user ID.</param>
    void DeleteUser(string bearerToken, Guid userId);

    /// <summary>
    /// Deletes a user within the authenticated agency using BASIC authentication.
    /// Note that deletes are soft deletes, so the user will still exist after deletion. The Active property
    /// will be set to false.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="userId">The agency user ID.</param>
    void DeleteUser(Guid impAccountId, Guid userId);

    /// <summary>
    /// Generates a TurboRater auto-login token that can be used to auto-login a specific TurboRater user into the 
    /// TurboRater GUI using either BEARER or BASIC auth.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="userId">The agency user ID.</param>
    Guid TurboRaterLogin(string bearerToken, Guid impAccountId, Guid userId);

    /// <summary>
    /// Generates a TurboRater auto-login token that can be used to auto-login a specific TurboRater user into the 
    /// TurboRater GUI using BEARER auth.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="userId">The agency user ID.</param>
    Guid TurboRaterLogin(string bearerToken, Guid userId);

    /// <summary>
    /// Generates a TurboRater auto-login token that can be used to auto-login a specific TurboRater user into the 
    /// TurboRater GUI using BASIC auth.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="userId">The agency user ID.</param>
    Guid TurboRaterLogin(Guid impAccountId, Guid userId);

    /// <summary>
    /// Retrieves information about a company group within the authenticated agency using either form of authentication authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="companyGroupId">The company group ID.</param>
    /// <returns>The comany group we are looking for.</returns>
    TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup GetCompanyGroup(string bearerToken, Guid impAccountId, int companyGroupId);

    /// <summary>
    /// Retrieves information about a company group within the authenticated agency using BEARER authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="companyGroupId">The company group ID.</param>
    /// <returns>The company group we are looking for.</returns>
    TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup GetCompanyGroup(string bearerToken, int companyGroupId);

    /// <summary>
    /// Retrieves information about a company group within the authenticated agency using BASIC authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="companyGroupId">The company group ID.</param>
    /// <returns>The company group we are looking for.</returns>
    TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup GetCompanyGroup(Guid impAccountId, int companyGroupId);

    /// <summary>
    /// Retrieves information about a TurboRater custom CSS.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="cssId">The ID of the CSS record.</param>
    /// <returns>The TurboRater custom CSS we are looking for.</returns>
    TurboRater.ApiClients.Imp.Itc.EFContexts.TurboRaterCustomCss GetTurboRaterCustomCss(Guid impAccountId, int cssId);

    /// <summary>
    /// Adds a TurboRater custom CSS.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="customCss">The TurboRater custom CSS to add.</param>
    void AddTurboRaterCustomCss(Guid impAccountId, TurboRater.ApiClients.Imp.Itc.EFContexts.TurboRaterCustomCss customCss);

    /// <summary>
    /// Updates a TurboRater custom CSS.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="customCss">The TurboRater custom CSS to update.</param>
    void UpdateTurboRaterCustomCss(Guid impAccountId, TurboRater.ApiClients.Imp.Itc.EFContexts.TurboRaterCustomCss customCss);

    /// <summary>
    /// Deletes a TurboRater custom CSS.
    /// Deletes are hard deletes, there is no recover of the record after deletion.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="cssId">The TurboRater custom CSS ID.</param>
    void DeleteTurboRaterCustomCss(Guid impAccountId, int cssId);

    /// <summary>
    /// Adds a new company group to the account.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="companyGroup">The new company group to add.</param>
    void AddCompanyGroup(Guid impAccountId, string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup companyGroup);

    /// <summary>
    /// Adds a new company group to the account using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="companyGroup">The new company group to add.</param>
    void AddCompanyGroup(Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup companyGroup);

    /// <summary>
    /// Adds a new company group to the account using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="companyGroup">The new company group to add.</param>
    void AddCompanyGroup(string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup companyGroup);

    /// <summary>
    /// Updates an existing company group.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="companyGroup">The company group to update.</param>
    void UpdateCompanyGroup(Guid impAccountId, string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup companyGroup);

    /// <summary>
    /// Updates an existing company group using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="companyGroup">The company group to update.</param>
    void UpdateCompanyGroup(Guid impAccountId, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup companyGroup);

    /// <summary>
    /// Updates an existing company group using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>    
    /// <param name="companyGroup">The company group to update.</param>
    void UpdateCompanyGroup(string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiCompanyGroup companyGroup);

    /// <summary>
    /// Deletes an existing company group.  Deletes are soft deletes, the company group is only marked as inactive.
    /// If the company group is in use by a TurboRater user or location, TFW, or Rate API, the function will fail with a 409 conflict error.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="companyGroupId">The id of the company group to delete.</param>
    void DeleteCompanyGroup(Guid impAccountId, string bearerToken, int companyGroupId);

    /// <summary>
    /// Deletes an existing company group using basic authentication.  Deletes are soft deletes, the company group is only marked as inactive.
    /// If the company group is in use by a TurboRater user or location, TFW, or Rate API, the function will fail with a 409 conflict error.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="companyGroupId">The id of the company group to delete.</param>
    void DeleteCompanyGroup(Guid impAccountId, int companyGroupId);

    /// <summary>
    /// Deletes an existing company group using bearer authentication.  Deletes are soft deletes, the company group is only marked as inactive.
    /// If the company group is in use by a TurboRater user or location, TFW, or Rate API, the function will fail with a 409 conflict error.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="companyGroupId">The id of the company group to delete.</param>
    void DeleteCompanyGroup(string bearerToken, int companyGroupId);

    /// <summary>
    /// Generates/retrieves a bearer token for usage in BEARER storage authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="integrationKey">Integration key supplied by ITC.</param>
    /// <returns>Bearer token used for BEARER auth storage operations.</returns>
    string GetBearerToken(Guid impAccountId, string integrationKey);

    /// <summary>
    /// Retrieves information about an AMS configuration within the authenticated agency using either form of authentication authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="amsConfigId">The AMS configuration ID.</param>
    /// <returns>The AMS configuration we are looking for.</returns>
    ApiAmsConfiguration GetAmsConfiguration(string bearerToken, Guid impAccountId, int amsConfigId);

    /// <summary>
    /// Retrieves information about an AMS configuration within the authenticated agency using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="amsConfigId">The AMS configuration ID.</param>
    /// <returns>The AMS configuration we are looking for.</returns>
    ApiAmsConfiguration GetAmsConfiguration(Guid impAccountId, int amsConfigId);

    /// <summary>
    /// Retrieves information about an AMS configuration within the authenticated agency using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="amsConfigId">The AMS configuration ID.</param>
    /// <returns>The AMS configuration we are looking for.</returns>
    ApiAmsConfiguration GetAmsConfiguration(string bearerToken, int amsConfigId);

    /// <summary>
    /// Adds a new AMS configuration to the account.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="amsConfig">The new AMS configuration to add.</param>
    void AddAmsConfiguration(Guid impAccountId, string bearerToken, ApiAmsConfiguration amsConfig);

    /// <summary>
    /// Adds a new AMS configuration to the account using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="amsConfig">The new AMS configuration to add.</param>
    void AddAmsConfiguration(Guid impAccountId, ApiAmsConfiguration amsConfig);

    /// <summary>
    /// Adds a new AMS configuration to the account using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate.</param>
    /// <param name="amsConfig">The new AMS configuration to add.</param>
    void AddAmsConfiguration(string bearerToken, ApiAmsConfiguration amsConfig);

    /// <summary>
    /// Updates an existing AMS configuration.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="amsConfig">The AMS configuration to update.</param>
    void UpdateAmsConfiguration(Guid impAccountId, string bearerToken, TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage.ApiAmsConfiguration amsConfig);

    /// <summary>
    /// Updates an existing AMS configuration using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="amsConfig">The AMS configuration to update.</param>
    void UpdateAmsConfiguration(Guid impAccountId, ApiAmsConfiguration amsConfig);

    /// <summary>
    /// Updates an existing AMS configuration using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="amsConfig">The AMS configuration to update.</param>
    void UpdateAmsConfiguration(string bearerToken, ApiAmsConfiguration amsConfig);

    /// <summary>
    /// Deletes an existing AMS configuration.   Note: this is a hard delete.
    /// If the AMS configuration is in use by a TurboRater user or location, the function will fail with a 409 conflict error.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="amsConfigId">The id of the AMS configuration to delete.</param>
    void DeleteAmsConfiguration(Guid impAccountId, string bearerToken, int amsConfigId);

    /// <summary>
    /// Deletes an existing AMS configuration using basic authentication.   Note: this is a hard delete.
    /// If the AMS configuration is in use by a TurboRater user or location, the function will fail with a 409 conflict error.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="amsConfigId">The id of the AMS configuration to delete.</param>
    void DeleteAmsConfiguration(Guid impAccountId, int amsConfigId);

    /// <summary>
    /// Deletes an existing AMS configuration using bearer authentication.   Note: this is a hard delete.
    /// If the AMS configuration is in use by a TurboRater user or location, the function will fail with a 409 conflict error.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="amsConfigId">The id of the AMS configuration to delete.</param>
    void DeleteAmsConfiguration(string bearerToken, int amsConfigId);

    /// <summary>
    /// Adds an embedded rating agency into the TurboRater.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="agency">The agency to add.</param>
    void AddEmbeddedRatingAgency(Guid impAccountId, string bearerToken, ApiEmbeddedRatingAgency agency);

    /// <summary>
    /// Adds an embedded rating agency into the TurboRater, using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="agency">The agency to add.</param>
    void AddEmbeddedRatingAgency(Guid impAccountId, ApiEmbeddedRatingAgency agency);

    /// <summary>
    /// Adds an embedded rating agency into the TurboRater, using bearer authentication.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="agency">The agency to add.</param>
    void AddEmbeddedRatingAgency(string bearerToken, ApiEmbeddedRatingAgency agency);

    /// <summary>
    /// Sets the TurboRater maximum user count for the agency associated with the bearer token.
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="newUserCount">The new user count for the account associated with the bearer token.</param>
    void SetEmbeddedRatingUserCount(string bearerToken, int newUserCount);

    /// <summary>
    /// Gets a list of supported model years supported by the vehicle database.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <returns>A list of years supported by the vehicle database.</returns>
    List<int> GetVehicleYears(Guid impAccountId);

    /// <summary>
    /// Gets a list of vehicle makes for a specific year.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="year">The model year of the vehicle.</param>
    /// <returns>A list of vehicle makes for a specific year.</returns>
    List<string> GetVehicleMakes(Guid impAccountId, int year);

    /// <summary>
    /// Gets a list of vehicle models for a specific year and make.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="year">The model year of the vehicle.</param>
    /// <param name="make">The vehicle make.</param>
    /// <returns>A list of vehicle models for a specific year and make.</returns>
    List<string> GetVehicleModels(Guid impAccountId, int year, string make);

    /// <summary>
    /// Gets a list of vehicle detail information for a specific year, make and model.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="year">The model year of the vehicle.</param>
    /// <param name="make">The vehicle make.</param>
    /// <param name="model">The vehicle model.</param>
    /// <returns>A list of vehicle detail information for a specific year, make and model</returns>
    List<ImpVinResponse> GetVehicleDetails(Guid impAccountId, int year, string make, string model);

    /// <summary>
    /// GGets vehicle detail information for a specific vehicle by 10 digit partial VIN pr 17 digit full VIN.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="vin">The VIN of the vehicle.</param>
    /// <returns>Vehicle detail information for a specific vehicle by VIN.</returns>
    ImpVinResponse GetVehicleDetailByVin(Guid impAccountId, string vin);

    /// <summary>
    /// Returns a set of all default limits for a state.  Optionally returns a single set of defaults based on a set of liability limits.
    /// </summary>
    /// <param name="line">The insurance line.</param>
    /// <param name="state">The state being rated.</param>
    /// <param name="liabLimit1">Optional per person liability limit (for example, 25 in 25/50).</param>
    /// <param name="liabLimit2">Optional per accident liability limit (for example, 50 in 25/50).</param>
    /// <returns>The defaults for coverages for one or more liability limits.</returns>
    List<LimitDefaultGroup> GetDefaultLimits(InsuranceLine line, USState state, int? liabLimit1 = null, int? liabLimit2 = null);

    /// <summary>
    /// Return a premium valuation for a given property
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="request">the premium valuation request object</param>
    /// <param name="forLookup">valuation versus lookup (estimate versus prefill)</param>
    /// <returns>premium valuation for a given property</returns>
    PremiumValuationResponse GetPremiumValuation(Guid impAccountId, PremiumValuationRequest request, bool forLookup = false);

    /// <summary>
    /// Returns a list of quote policy audit data.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="quoteUid">The id of the quote.</param>
    /// <returns>the list of quote policy audit data associated w/ the requested policy</returns>
    List<PolicyAuditModel> GetPolicyModelData(Guid impAccountId, Guid quoteUid);

    /// <summary>
    /// Adds a quote template into TurboRater, using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account.</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="template">The quote template to add.</param>
    void AddQuoteTemplate(Guid impAccountId, string bearerToken, QuoteTemplate template);

    /// <summary>
    /// Get a quote template from TurboRater
    /// </summary>
    /// <param name="impAccountId">Guid Agency Account</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="recordId">quote template record id</param>
    /// <returns>A single quote template object</returns>
    QuoteTemplate GetQuoteTemplate(Guid impAccountId, string bearerToken, int recordId);

    /// <summary>
    /// Get quote templates from TurboRater
    /// </summary>
    /// <param name="impAccountId">Guid Agency Account</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <returns>A list of quote template objects for a given agency account</returns>
    List<QuoteTemplate> GetQuoteTemplates(Guid impAccountId, string bearerToken);

    /// <summary>
    /// Updates an existing quote template using basic authentication.
    /// </summary>
    /// <param name="impAccountId">The id of the imp account. Should be Guid.Empty if bearer token is used.</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="template">The quote template to update.</param>
    void UpdateQuoteTemplate(Guid impAccountId, string bearerToken, QuoteTemplate template);

    /// <summary>
    /// Deletes a quote template. note this is a hard delete
    /// </summary>
    /// <param name="impAccountId">Guid Agency Account</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="recordId">quote template record id</param>
    void DeleteQuoteTemplate(Guid impAccountId, string bearerToken, int recordId);


    /// <summary>
    /// Applies a quote template to a policy. 
    /// </summary>
    /// <param name="impAccountId">The id used to authenticate the request.</param>
    /// <param name="bearerToken">The bearer token used to authenticate the request.</param>
    /// <param name="request">The request to send.</param>
    /// <returns>Serialized copy of the policy with the template defaults applied to it.</returns>
    string ApplyQuoteTemplate(Guid impAccountId, string bearerToken, ApplyTemplateRequest request);

    /// <summary>
    /// Applies a quote template to a policy. 
    /// </summary>
    /// <param name="impAccountId">Guid Agency Account</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="policy">the policy to have the template applied to.</param>
    /// <param name="quoteTemplateId">the quote template to apply.</param>
    /// <returns>The requested policy after having the template defaults applied to it.</returns>
    InsPolicy ApplyQuoteTemplate(Guid impAccountId, string bearerToken, InsPolicy policy, int quoteTemplateId);

    /// <summary>
    /// Adds an agency quote storage notification url 
    /// </summary>
    /// <param name="impAccountId">Guid Agency Account</param>
    /// <param name="notificationUrl">the notification url</param>
    /// <param name="httpMethod">the http method to use for the notification</param>
    /// <param name="notificationDelay">the delay before sending the notification</param>
    void SetAgencyQuoteStorageNotificationUrl(Guid impAccountId, string notificationUrl, HttpMethods httpMethod, int notificationDelay);

    /// <summary>
    /// Adds an agency quote storage notification url 
    /// </summary>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="notificationUrl">the notification url</param>
    /// <param name="httpMethod">the http method to use for the notification</param>
    /// <param name="notificationDelay">the delay before sending the notification</param>
    void SetAgencyQuoteStorageNotificationUrl(string bearerToken, string notificationUrl, HttpMethods httpMethod, int notificationDelay);

    /// <summary>
    /// Adds an agency quote storage notification url 
    /// </summary>
    /// <param name="impAccountId">Guid Agency Account</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    /// <param name="notificationUrl">the notification url</param>
    /// <param name="httpMethod">the http method to use for the notification</param>
    /// <param name="notificationDelay">the delay before sending the notification</param>
    void SetAgencyQuoteStorageNotificationUrl(Guid impAccountId, string bearerToken, string notificationUrl, HttpMethods httpMethod, int notificationDelay);
        
    /// <summary>
    /// Gets a list of violations for the current state.
    /// </summary>
    /// <param name="state">The state </param>
    List<Item> GetViolationsForState(USState state); 

    /// <summary>
    /// Adds the appropriate embedded rating purchased product code to the authenticated agency in CRM.
    /// The appropriate embedded rating purchased product code is determined by a setting in the IMP account.
    /// An exampl of embedded rating pprod code is CPAAER for AccuAgency embedded rating.
    /// </summary>
    /// <param name="impAccountId">Guid Agency Account</param>
    /// <param name="bearerToken">The bearer token used to authenticate. If null, impAccountId is used.</param>
    void AddEmbeddedRatingPurchasedProduct(Guid impAccountId, string bearerToken);
  }
}
