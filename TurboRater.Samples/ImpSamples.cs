using Microsoft.OData.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using TurboRater.ApiClients.Imp;
using TurboRater.ApiClients.Imp.Itc.EFContexts;
using TurboRater.ApiClients.Imp.ITC.Insurance.RemoteStorage;
using TurboRater.Insurance;
using TurboRater.Insurance.AU;
using TurboRater.Insurance.DataTransformation;
using TurboRater.Insurance.HO;

namespace TurboRater.Samples
{
  [TestClass]
  public class ImpSamples
  {
    public ImpSamples()
    {
      ServicePointManager.SecurityProtocol = (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
    }

    /// <summary>
    /// Creates an AU-based policy of the specified LOB. 
    /// (note: both automobile and motorcycle policies are of the AUPolicy type.)
    /// </summary>
    /// <param name="lob">Line of Business.</param>
    /// <returns>the newly minted policy.</returns>
    public AUPolicy CreatePolicy(InsuranceLine lob)
    {
      var policy = new AUPolicy(lob);
      var insured = new AUDriver(TypeOfPerson.NamedInsured, lob);
      policy.Insured = insured;
      insured.Policy = policy;
      policy.Cars.Add(new AUCar() { Year = 2015, Maker = "Toyota", Model = "Camry" });
      policy.Drivers.Add(new AUDriver() { FirstName = "IMP_Tests_First", LastName = "IMP_Tests_Last", Relation = AUConstants.RelationChar[(int)Relation.Insured].ToString(), State = USState.Texas, ZipCode = "75006" });
      policy.MailingAddress.State = USState.Texas;
      policy.CopyInsuredDriverInfoToInsured();
      return policy;
    }

    /// <summary>
    /// Creates an HO-based policy of the specified LOB. 
    /// (note: both homeowners and dwelling fire policies are of the HOPolicy type.)
    /// </summary>
    /// <param name="lob">Line of Business.</param>
    /// <returns>the newly minted policy.</returns>
    public HOPolicy CreateHOPolicy(InsuranceLine lob)
    {
      var policy = new HOPolicy();
      var insured = new PropertyPerson(TypeOfPerson.NamedInsured, lob);
      insured.Policy = policy;
      policy.Insured = insured;
      insured.PolicyType = InsuranceLine.Homeowners;

      //Some sort of work-around
      policy.OtherInsured = new PropertyPerson(TypeOfPerson.OtherInsured);

      insured.FirstName = "Test";
      insured.LastName = "Client";
      insured.Relation = ITCConstants.RelationChars[(int)Relation.Insured];
      insured.DOB = DateTime.Today.AddYears(-30);
      insured.Sex = ITCConstants.GenderChars[(int)TurboRater.Gender.Male];
      insured.Gender = ITCConstants.GenderChars[(int)TurboRater.Gender.Male];
      insured.Address1 = "1234 Test Street";
      insured.City = "Carrollton";
      insured.State = USState.Texas;
      insured.County = "Denton";
      insured.ZipCode = "75006";
      policy.EffectiveDate = DateTime.Today;

      policy.MailingAddress.Address1 = insured.Address1;
      policy.MailingAddress.City = insured.City;
      policy.MailingAddress.State = insured.State;
      policy.MailingAddress.County = insured.County;
      policy.MailingAddress.ZipCode = insured.ZipCode;

      policy.InsuredProperty.Address1 = insured.Address1;
      policy.InsuredProperty.City = insured.City;
      policy.InsuredProperty.State = insured.State;
      policy.InsuredProperty.County = insured.County;
      policy.InsuredProperty.ZipCode = insured.ZipCode;

      policy.YearOfConstruction = 1980;
      policy.SquareFootage = 2000;
      policy.PurchaseDate = new DateTime(1990, 1, 1);

      policy.Term = 1;
      policy.TermDuration = Duration.Years;
      policy.PriorEffDate = ITCConstants.InvalidWindowsDate;
      policy.Form = "B";
      policy.Construction = HOConstants.ConstructionChars[(int)Construction.Brick];
      policy.DwellingUse = InsConstants.DwellingUseChars[(int)DwellingUse.Dwelling];      
      policy.Occupancy = HOConstants.OccupancyChars[(int)Occupancy.OwnerOccupied];
      policy.RoofComposition = HOConstants.RoofCompositionChars[(int)RoofComposition.CompositeShingle];
      policy.Deductible1 = "1";
      policy.Deductible2 = "4";
      policy.Deductible3 = "250";
      policy.ProtectionClass = "0";
      policy.LiabLimit = 25000;
      policy.MedPayLimit = 1000;
      policy.DwellingAmt = 740000;
      policy.ContentsAmt = 296000;
      policy.LossOfUseAmt = 370000;

      policy.TXEndorsements.HO0455 = true;
      policy.TXEndorsements.HO160 = true;
      policy.TXEndorsements.HO160Cameras = 1000;
      policy.TXEndorsements.HO160MusicalInstruments = 1000;

      return policy;

    }

    /// <summary>
    /// Runs a TR policy through data validation.
    /// </summary>
    //[TestMethod]
    public void ValidateAUPolicyBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      AUPolicy policy = CreatePolicy(InsuranceLine.PersonalAuto);
      policy.MailingAddress.State = USState.Washington;
      policy.Cars[0].Coll = true;
      policy.Cars[0].CollDed = 500;
      var tt2Data = TransformationHelper.SerializePolicy(policy);
      ValidatePolicyRequest validationRequest = new ValidatePolicyRequest(tt2Data, "AU") { State = "WA" };
      var validationErrors = impClient.ValidationTurboRater(new Guid("[YOUR IMP ACCOUNT ID GOES HERE]"), validationRequest);
      foreach (var validationError in validationErrors)
        Debug.Write(validationError.ToString());
    }

    /// <summary>
    /// Saves a HO policy using IMP, with BEARER authentication.
    /// </summary>
    //[TestMethod]
    public void SaveHOPolicyBearer()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      var policy = CreateHOPolicy(InsuranceLine.Homeowners);
      try
      {
        var response = impClient.SavePolicy("[YOUR BEARER TOKEN GOES HERE]", policy, false, true);
        //Policy validation errors to take care of.
        if (response.ValidationErrors != null && response.ValidationErrors.Count > 0)
          response.ValidationErrors.ForEach(error => Debug.WriteLine(String.Format("{0}.{1}.{2}: {3}", error.Scope, error.ScopeNum, error.TagName, error.Message)));
        //Success! Note: the policy will still save even if there are validation errors.
        if (response.PolicyId > 0)
        {
          Debug.WriteLine(String.Format("policyid: {0}", response.PolicyId));
          //Upon successful save, we should immediately reload our policy based on the ID returned so that we can pull the recordids into our object structure. This has been factored out of the sample for brevity.
          //On successful save, we would also do something with the 3 urls in the response object. Likely load them in a browser window.
        }
      }
      catch (WebException ex)
      {
        //Handle web exceptions appropriately.
      }
      catch (Exception ex)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Saves an AU policy using IMP, with BASIC authentication.
    /// </summary>
    //[TestMethod]
    public void SaveAUPolicyBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      var policy = CreatePolicy(InsuranceLine.PersonalAuto);
      try
      {
        var response = impClient.SavePolicy(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), policy, false, true);
        //Policy validation errors to take care of.
        if (response.ValidationErrors != null && response.ValidationErrors.Count > 0)
          response.ValidationErrors.ForEach(error => Debug.WriteLine(String.Format("{0}.{1}.{2}: {3}", error.Scope, error.ScopeNum, error.TagName, error.Message)));
        //Success! Note: the policy will still save even if there are validation errors.
        if (response.PolicyId > 0)
        {
          Debug.WriteLine(String.Format("policyid: {0}", response.PolicyId));
          //Upon successful save, we should immediately reload our policy based on the ID returned so that we can pull the recordids into our object structure. This has been factored out of the sample for brevity.
          //On successful save, we would also do something with the 3 urls in the response object. Likely load them in a browser window.
        }
      }
      catch (WebException ex)
      {
        //Handle web exceptions appropriately.
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Unlocks a policy 
    /// </summary>
    //[TestMethod]
    public void UnlockPolicy()
    {
      var impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        // overwrite with you policyid 
        var policyid = 1234;
        // overwrite with your IMP id 
        var impAccountId = Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]");
        // overwrite with the insurance line of this policy 
        var line = InsuranceLine.PersonalAuto;
        // overwrite with the policy rating state
        var state = USState.Texas;
        // overwrite with the user id of the user who locked the policy or an admin with sufficient privileges 
        var userId = Guid.Parse("[USER ID GOES HERE]");
        // overwrite with the location id of the users location 
        var locationId = Guid.Parse("[LOCATION ID GOES HERE]");

        var response = impClient.UnlockPolicy(impAccountId, policyid, line, state, userId, locationId);
        
        // any errors that happen attempting to unlock the policy will be returned in the response.
        if (!string.IsNullOrWhiteSpace(response))
          Debug.WriteLine(response);
        else //Success! 
          Debug.WriteLine(String.Format("policyid: {0} was successfully unlocked", policyid));
      }
      catch (WebException ex)
      {
        //Handle web exceptions appropriately.
      }
      catch (Exception ex)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Retrieves a bearer token for IMP storage authentication, using the supplied integration key.
    /// </summary>
    //[TestMethod]
    public void GetBearerTokenFromIntegrationKey()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var bearerToken = impClient.GetBearerToken(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), "[YOUR IMP INTEGRATION KEY FOR THE CURRENT AGENCY GOES HERE]");
        if (String.IsNullOrWhiteSpace(bearerToken))
        {
          //We failed to get a bearer token, handle appropriately.
        }
        else
          //We got a valid bearer token; store it so we can use the same bearer token for many many storage requests with the same agency.
          Debug.WriteLine(String.Format("success! bearer token: {0}", bearerToken));
      }
      catch (WebException ex)
      {
        //Handle web exceptions appropriately.
      }
      catch (Exception ex)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Saves an AU policy using IMP, with BEARER authentication.
    /// </summary>
    //[TestMethod]
    public void SaveAUPolicyBearer()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      var policy = CreatePolicy(InsuranceLine.PersonalAuto);
      try
      {
        var response = impClient.SavePolicy("[YOUR BEARER TOKEN FOR THE CURRENT AGENCY GOES HERE]", policy, false, true);
        //Policy validation errors to take care of.
        if (response.ValidationErrors != null && response.ValidationErrors.Count > 0)
          response.ValidationErrors.ForEach(error => Debug.WriteLine(String.Format("{0}.{1}.{2}: {3}", error.Scope, error.ScopeNum, error.TagName, error.Message)));
        //Success! Note: the policy will still save even if there are validation errors.
        if (response.PolicyId > 0)
        {
          Debug.WriteLine(String.Format("policyid: {0}", response.PolicyId));
          //Upon successful save, we should immediately reload our policy based on the ID returned so that we can pull the recordids into our object structure. This has been factored out of the sample for brevity.
          //On successful save, we would also do something with the 3 urls in the response object. Likely load them in a browser window.
        }
      }
      catch (WebException ex)
      {
        //Handle web exceptions appropriately.
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Loads an AU policy using IMP, with BASIC authentication.
    /// </summary>
    //[TestMethod]
    public void LoadAUPolicyBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        int policyId = -1; //Your PolicyId goes here.
        var response = impClient.LoadPolicy(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), InsuranceLine.PersonalAuto, policyId);
        if (response.Policy != null && response.QuoteLoadInfo != null)
        {
          Debug.WriteLine(response.QuoteLoadInfo.CompareUrl); //This URL will load the quote in TurboRater and take the user directly to the rating comparison screen.
          Debug.WriteLine(response.QuoteLoadInfo.QuoteUrl); //This URL will load the quote in TurboRater and take the user to the quote entry page.
          Debug.WriteLine(response.QuoteLoadInfo.BreakdownUrl); //This URL will load the quote in TurboRater and take the user to the quote breakdown page, if the quote has been previously rated.
          //Do something with the policy returned.
        }
      }
      catch (WebException)
      {
        //Handle web exceptions appropriately.
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Loads an HO policy using IMP, with BASIC authentication.
    /// </summary>
    //[TestMethod]
    public void LoadHOPolicyBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        int policyId = -1; //Your PolicyId goes here.
        var response = impClient.LoadPolicy(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), InsuranceLine.Homeowners, policyId, BridgeContentType.Custom);
        if (response.Policy != null && response.QuoteLoadInfo != null)
        {
          Debug.WriteLine(response.QuoteLoadInfo.CompareUrl); //This URL will load the quote in TurboRater and take the user directly to the rating comparison screen.
          Debug.WriteLine(response.QuoteLoadInfo.QuoteUrl); //This URL will load the quote in TurboRater and take the user to the quote entry page.
          Debug.WriteLine(response.QuoteLoadInfo.BreakdownUrl); //This URL will load the quote in TurboRater and take the user to the quote breakdown page, if the quote has been previously rated.
          //Do something with the policy returned.
        }
      }
      catch (WebException)
      {
        //Handle web exceptions appropriately.
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Retrieves agency information using BASIC authentication.
    /// </summary>
    //[TestMethod]
    public void GetAgencyBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var response = impClient.GetAgency(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"));
        //Success!
        Debug.WriteLine(String.Format("location: {0},{1}", response.AgencyID, response.Name));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Retrieves location information using BASIC authentication.
    /// </summary>
    //[TestMethod]
    public void GetLocationBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var response = impClient.GetLocation(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), Guid.Parse("[AN AGENCY LOCATION ID GOES HERE]"));
        //Success!
        Debug.WriteLine(String.Format("location: {0},{1}", response.AgencyLocationID, response.Description));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Searches through locations using BASIC authentication.
    /// </summary>
    //[TestMethod]
    public void SearchLocationsBasic()
    {
      var impClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(ImpConstants.TestBaseUrl + "api/agencies('0')"));
      try
      {
        impClient.SendingRequest2 += (sender, eventArgs) =>
        {
          ImpClient.SetClientHeadersOData(eventArgs.RequestMessage, null, Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"));
        };
        //More query options can be found here: http://odata.github.io/odata.net/#04-02-query-options
        var locations = impClient.Locations.Where(loc => loc.Active).OrderBy(loc => loc.Zipcode);
        foreach (var loc in locations)
          Debug.WriteLine(String.Format("Location: {0}, {1}", loc.Description, loc.Zipcode));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Adds a location using BASIC authentication.
    /// </summary>
    //[TestMethod]
    public void AddLocationBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var location = new ApiAgencyLocation() { Description = "sdk test location", Address1 = "1234 sss", City = "Carrollton", PhoneNumber = "111-222-3333", State = "TX", Zipcode = "75007", Active = true, AgencyLocationID = String.Empty, AgencyManagementLinkID = -1 };
        impClient.AddLocation(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), location);
        //Success!
        Debug.WriteLine(String.Format("location: {0},{1}", location.AgencyLocationID, location.Description));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Updates a location using BASIC authentication.
    /// </summary>
    //[TestMethod]
    public void UpdateLocationBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var location = new ApiAgencyLocation() { Description = "sdk test location x", Address1 = "1234 sss", City = "Carrollton", PhoneNumber = "111-222-3333", State = "TX", Zipcode = "75007", AgencyManagementLinkID = -1 };
        location.AgencyLocationID = "[AN EXISTING AGENCY LOCATION ID GOES HERE]";
        impClient.UpdateLocation(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), location);
        //Success!
        Debug.WriteLine(String.Format("location: {0},{1}", location.AgencyLocationID, location.Description));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Deletes a location using BASIC authentication.
    /// Note that deletes are only soft deletes, so the location will still
    /// exist after deletion. It will just be have it's Active flag set to false.
    /// </summary>
    //[TestMethod]
    public void DeleteLocationBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        impClient.DeleteLocation(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), Guid.Parse("[AN EXISTING AGENCY LOCATION ID GOES HERE]"));
        //Success!
        Debug.WriteLine("Location deleted.");
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Retrieves user information using BASIC authentication.
    /// </summary>
    //[TestMethod]
    public void GetUserBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var response = impClient.GetUser(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), Guid.Parse("[YOUR USER ID GOES HERE]"));
        //Success!
        Debug.WriteLine(String.Format("User: {0},{1}", response.UserID, response.Login));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Searches through users using BASIC authentication.
    /// </summary>
    //[TestMethod]
    public void SearchUsersBasic()
    {
      var impClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(ImpConstants.TestBaseUrl + "api/agencies('0')"));
      try
      {
        impClient.SendingRequest2 += (sender, eventArgs) =>
        {
          ImpClient.SetClientHeadersOData(eventArgs.RequestMessage, null, Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"));
        };
        //More query options can be found here: http://odata.github.io/odata.net/#04-02-query-options
        var users = impClient.Users.Where(user => user.Active).OrderBy(user => user.Login);
        foreach (var user in users)
          Debug.WriteLine(String.Format("User: {0}, {1}", user.UserID, user.Login));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Adds a user using BASIC authentication.
    /// </summary>
    //[TestMethod]
    public void AddUserBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var user = new ApiAgencyUser() { Active = true, AccessLevelID = ImpConstants.ValidAccessLevelGUIDs[(int)AccessLevels.StandardAccess], EMailAddress = "sample@getitc.com", FirstName = "Sample", LastName = "ApiUser", Login = "sample_getitc", Password = "abcD~1234!", ProfileLinkID = -1, SecurityLevelID = ImpConstants.ValidSecurityLevelGUIDs[(int)SecurityLevels.StandardUser], UserID = String.Empty, AgencyManagementLinkID = -1 };
        impClient.AddUser(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), user);
        //Success!
        Debug.WriteLine(String.Format("User: {0},{1}", user.UserID, user.Login));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Updates a user using BASIC authentication.
    /// </summary>
    //[TestMethod]
    public void UpdateUserBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        //NOTE: on an update, if you leave the password empty then the password of the user will not change. It will remain what it was before the update was processed. This prevents clients from being forced to know the user's password.
        var user = new ApiAgencyUser() { Active = true, AccessLevelID = ImpConstants.ValidAccessLevelGUIDs[(int)AccessLevels.StandardAccess], EMailAddress = "sample@getitc.com", FirstName = "SampleNC", LastName = "ApiUserNC", Login = "sample_getitc", Password = String.Empty, ProfileLinkID = -1, SecurityLevelID = ImpConstants.ValidSecurityLevelGUIDs[(int)SecurityLevels.StandardUser], UserID = String.Empty };
        //user.AssignedLocationIds = new System.Collections.ObjectModel.ObservableCollection<Guid>(); //Creating a new empty list (or just leaving it empty, which is the default) will blank out the list of locations this user is allowed to access.
        //user.AssignedLocationIds.Add(Guid.Parse("[IF THE USER IS RESTRICTED TO SPECIFIC LOCATIONS, PUT A LOCATIONID HERE]"));
        user.UserID = "[AN EXISTING AGENCY USER ID GOES HERE]";
        impClient.UpdateUser(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), user);
        //Success!
        Debug.WriteLine(String.Format("User: {0},{1}", user.UserID, user.Login));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Deletes a user using BASIC authentication.
    /// Note that deletes are only soft deletes, so the user will still
    /// exist after deletion. It will just be have it's Active flag set to false.
    /// </summary>
    //[TestMethod]
    public void DeleteUserBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        impClient.DeleteUser(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), Guid.Parse("[AN EXISTING AGENCY USER ID GOES HERE]"));
        //Success!
        Debug.WriteLine("User deleted.");
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Gets a TurboRater auto-login token for a specific TurboRater user using BASIC authentication.
    /// </summary>
    //[TestMethod]
    public void GetTurboRaterAutoLoginTokenBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var autoLoginToken = impClient.TurboRaterLogin(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), Guid.Parse("[AN EXISTING AGENCY USER ID GOES HERE]"));
        //Success!
        Debug.WriteLine(String.Format("Auto-login token retrieved:{0}", autoLoginToken));
      }
      catch (WebException)
      {
        //Handle web exceptions appropriately.
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Gets the top 10 clients with a bound auto policy, and expands the 
    /// AutoPolicy list to include them in the result set, ordered by last name.
    /// </summary>
    //[TestMethod]
    public void SearchClientsBasic()
    {
      var impClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(ImpConstants.TestBaseUrl + "api"));
      try
      {
        impClient.SendingRequest2 += (sender, eventArgs) =>
        {
          ImpClient.SetClientHeadersOData(eventArgs.RequestMessage, null, Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE])"));
        };
        //More query options can be found here: http://odata.github.io/odata.net/#04-02-query-options

        var clients = impClient.Clients
          .Expand("AutoPolicies")
          .Where(client => client.AutoPolicies.Any(policy => policy.Bound))
          .OrderBy(client => client.LastName)
          .Take(10);

        foreach (var client in clients)
          Debug.WriteLine(String.Format("Client: {0}, {1}", client.LastName, client.FirstName));

      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Retrieves user information using BASIC authentication.
    /// </summary>
    //[TestMethod]
    public void GetCompanyGroupBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var response = impClient.GetCompanyGroup(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), -1/*[A VALID COMPANY GROUP ID WITHIN THE AGENCY GOES HERE]*/);
        //Success!
        Debug.WriteLine(String.Format("Company Group: {0},{1},{2}", response.RecordID, response.Name, response.Active));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Searches through company groups using BASIC authentication.
    /// </summary>
    //[TestMethod]
    public void SearchCompanyGroupsBasic()
    {
      var impClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(ImpConstants.TestBaseUrl + "api/agencies('0')"));
      try
      {
        impClient.SendingRequest2 += (sender, eventArgs) =>
        {
          ImpClient.SetClientHeadersOData(eventArgs.RequestMessage, null, Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"));
        };
        //More query options can be found here: http://odata.github.io/odata.net/#04-02-query-options
        var companyGroups = impClient.CompanyGroups.Where(group => !group.Active).OrderBy(group => group.Name);
        foreach (var companyGroup in companyGroups)
          Debug.WriteLine(String.Format("Company Group: {0},{1},{2}", companyGroup.RecordID, companyGroup.Name, companyGroup.Active));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Retrieves TurboRater custom CSS information.
    /// </summary>
    //[TestMethod]
    public void GetTurboRaterCustomCss()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var response = impClient.GetTurboRaterCustomCss(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), -1 /*[AN EXISTING CUSTOM CSS RECORDID BELONGING TO YOUR ACCOUNT GOES HERE]*/);
        //Success!
        Debug.WriteLine(String.Format("customcss: {0},{1}", response.RecordId, response.CustomCssName));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Searches through TurboRater custom CSS.
    /// </summary>
    //[TestMethod]
    public void SearchTurboRaterCustomCss()
    {
      var impClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(ImpConstants.TestBaseUrl + "api"));
      try
      {
        impClient.SendingRequest2 += (sender, eventArgs) =>
        {
          ImpClient.SetClientHeadersOData(eventArgs.RequestMessage, null, Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"));
        };
        //More query options can be found here: http://odata.github.io/odata.net/#04-02-query-options
        var cssEntities = impClient.CustomCss.Where(css => css.CustomCssName.Equals("SDKSampleCSS")).OrderBy(css => css.RecordId);
        foreach (var css in cssEntities)
          Debug.WriteLine(String.Format("customcss: {0}, {1}", css.RecordId, css.CustomCssName));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Adds a TurboRater custom CSS.
    /// </summary>
    //[TestMethod]
    public void AddTurboRaterCustomCss()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var css = new TurboRaterCustomCss() { CustomCssName = "SDKSampleCSS", ImpAccountId = Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), CustomCss = null, MinimumTurboRaterVersion = "1.0.0.1" };
        impClient.AddTurboRaterCustomCss(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), css);
        //Success!
        Debug.WriteLine(String.Format("customcss: {0},{1}", css.RecordId, css.CustomCssName));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Updates a TurboRater custom CSS.
    /// </summary>
    //[TestMethod]
    public void UpdateTurboRaterCustomCss()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var css = new TurboRaterCustomCss()
        {
          CustomCssName = "SDKSampleCSS",
          RecordId = -1 /*[AN EXISTING CUSTOM CSS RECORDID BELONGING TO YOUR ACCOUNT GOES HERE]*/, 
          ImpAccountId = Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), 
          MinimumTurboRaterVersion = "1.0.0.1",
          CustomCss = ".sampleClass { color: green; }" };
        impClient.UpdateTurboRaterCustomCss(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), css);
        //Success!
        Debug.WriteLine(String.Format("customcss: {0},{1}", css.RecordId, css.CustomCssName));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Deletes a TurboRater custom CSS.
    /// Note that deletes are hard deletes, there is no recovery after deletion!
    /// </summary>
    //[TestMethod]
    public void DeleteTurboRaterCustomCss()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        impClient.DeleteTurboRaterCustomCss(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), -1 /*[AN EXISTING CUSTOM CSS RECORDID BELONGING TO YOUR ACCOUNT GOES HERE]*/);
        //Success!
        Debug.WriteLine("TurboRater custom CSS deleted.");
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// gets a list of rating products available in the TurboRater system.
    /// </summary>
    //[TestMethod]
    public void GetRatingProductsBasic()
    {
      var impClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(ImpConstants.TestBaseUrl + "api"));
      try
      {
        impClient.SendingRequest2 += (sender, eventArgs) =>
        {
          ImpClient.SetClientHeadersOData(eventArgs.RequestMessage, null, Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"));
        };
        //More query options can be found here: http://odata.github.io/odata.net/#04-02-query-options
        var companies = impClient.CompanyRegistry.Where(comp => comp.TurboRaterActive && comp.State.Equals("TX", StringComparison.OrdinalIgnoreCase));
        foreach (var company in companies)
          Debug.WriteLine(String.Format("Company: {0}, {1}", company.Name, company.CompanyId));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Adds a new company group to the account.
    /// </summary>
    //[TestMethod]
    public void AddCompanyGroupBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var companyGroup = new ApiCompanyGroup() {  Active = true, Name = "Sample Company Group" };

        companyGroup.Companies.Add(new ApiCompany()
        {          
          Active = true,
          CompanyId = 98175044,
          Password = "Password",
          UserId = "UserId",
          ProducerCode = "12345",
          SubProducerCode = "54321"
        });

        impClient.AddCompanyGroup(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), companyGroup);       

        //Success!
        Debug.WriteLine(String.Format("company group: {0},{1}", companyGroup.RecordID, companyGroup.Name));
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Updates a company group.
    /// </summary>
    //[TestMethod]
    public void UpdateCompanyGroupBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var companyGroup = impClient.GetCompanyGroup(new Guid("[YOUR IMP ACCOUNT ID GOES HERE]"), 9999 /*existing company group id*/);

        companyGroup.Companies.Add(new ApiCompany()
        {
          Active = true,
          CompanyId = 95160659,
          Password = "Password",
          UserId = "UserId",
          ProducerCode = "12345",
          SubProducerCode = "54321"
        });

        impClient.UpdateCompanyGroup(new Guid("[YOUR IMP ACCOUNT ID GOES HERE]"), companyGroup);

        //Success!
        Debug.WriteLine(String.Format("company group: {0},{1}", companyGroup.RecordID, companyGroup.Name));
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Deletes a TurboRater company group.
    /// </summary>
    //[TestMethod]
    public void DeleteCompanyGroupBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        impClient.DeleteCompanyGroup(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), -1 /*[AN EXISTING COMPANY GROUP RECORDID BELONGING TO YOUR ACCOUNT GOES HERE]*/);

        //Success!
        Debug.WriteLine("Company group deleted.");
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// gets a list of available AMS's to use for ApiAmsConfiguration objects.
    /// </summary>
    //[TestMethod]
    public void GetAvailableAmsBasic()
    {
      var impClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(ImpConstants.TestBaseUrl + "api"));
      try
      {
        impClient.SendingRequest2 += (sender, eventArgs) =>
        {
          ImpClient.SetClientHeadersOData(eventArgs.RequestMessage, null, Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"));
        };
        //More query options can be found here: http://odata.github.io/odata.net/#04-02-query-options
        var availableAms = impClient.AvailableAms;
        foreach (var ams in availableAms)
          Debug.WriteLine(String.Format("Available AMS: {0}, {1}", ams.SystemName, ams.ExecutableName));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Retrieves user information using BASIC authentication.
    /// </summary>
    //[TestMethod]
    public void GetAmsConfigurationBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var response = impClient.GetAmsConfiguration(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), -1/*[A VALID AMS CONFIGURATION ID WITHIN THE AGENCY GOES HERE]*/);
        //Success!
        Debug.WriteLine(String.Format("AMS configuration {0}, {1}", response.ConfigurationId, response.Name));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// tests add agency quote storage noticiation url with basic authenciation 
    /// </summary>
    [TestMethod]
    public void SetAgencyQuoteStorageNotificationUrlBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var notificationURL = "https://www.test.com";
        impClient.SetAgencyQuoteStorageNotificationUrl(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), notificationURL, HttpMethods.POST, 0);
        
        //Success!
        Debug.WriteLine(String.Format("Added Agency Quote Storage Notification: {0} added", notificationURL));
      }
      catch (Exception ex)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// tests add agency quote storage noticiation url with bearer authenciation 
    /// </summary>
    [TestMethod]
    public void SetAgencyQuoteStorageNotificationUrlBearer()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var notificationURL = "https://www.test1.com";
        var token = impClient.GetBearerToken(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), "[INTEGRATION KEY FOR AGENCY GOES HERE]");
        impClient.SetAgencyQuoteStorageNotificationUrl(token, notificationURL, HttpMethods.GET, 180);

        //Success!
        Debug.WriteLine(String.Format("Added Agency Quote Storage Notification: {0} added", notificationURL));
      }
      catch (Exception ex)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Adds a new AMS Configuration to the account.
    /// </summary>
    //[TestMethod]
    public void AddAmsConfigurationBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var amsConfig = new ApiAmsConfiguration() { Name = "Sample AMS configuration" };

        amsConfig.Systems.Add(new ApiAms()
        {
          AccountNumber = "AccountNumber",
          AvailableAmsId = 24,
          Password = "Password",
          UserName = "UserName",
          PrimaryManagementSystem = true
        });

        impClient.AddAmsConfiguration(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), amsConfig);

        //Success!
        Debug.WriteLine(String.Format("AMS configuration: {0},{1}", amsConfig.ConfigurationId, amsConfig.Name));
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Updates an AMS configuration.
    /// </summary>
    //[TestMethod]
    public void UpdateAmsConfigurationBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var amsConfig = new ApiAmsConfiguration()
        {
          Name = "New Sample AMS Configuration Name",
          ConfigurationId = -1 // An actual existing configuration ID goes here
        };
        impClient.UpdateAmsConfiguration(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), amsConfig);

        //Success!
        Debug.WriteLine(String.Format("AMS configuration: {0},{1}", amsConfig.ConfigurationId, amsConfig.Name));
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Deletes a TurboRater AMS configuration.
    /// Note that deletes are hard deletes, there is no recovery after deletion!
    /// </summary>
    //[TestMethod]
    public void DeleteAmsConfigurationBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        impClient.DeleteAmsConfiguration(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), -1 /*[AN EXISTING AMS CONFIGURATION ID BELONGING TO YOUR ACCOUNT GOES HERE]*/);

        //Success!
        Debug.WriteLine("AMS configuration deleted.");
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Adds a new embedded rating agency.
    /// </summary>
    //[TestMethod]
    public void AddEmbeddedRatingAgencyBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var agency = new ApiEmbeddedRatingAgency()
        {
          AgencyID = string.Empty,
          IntegrationKey = Guid.Empty,
          Address1 = "123 Testing St",
          Address2 = "Suite 10",
          AlternatePhoneNumber = "1111111111",
          City = "Carrollton",
          EmailAddress = "some@email.com",
          FaxNumber = "2222222222",
          Name = "SDK Test Agency",
          PhoneNumber = "3333333333",
          State = "TX",
          WebsiteAddress = "www.google.com",
          Zipcode = "75007",
          IsTwoFactorAuthEnabled = false,
          AllowRemember2FA = false,
          NumUsers = 10,
          AgencyContactFirstName = "John",
          AgencyContactLastName = "Doe",
          Package = "Pro"
        };
        impClient.AddEmbeddedRatingAgency(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), null, agency);

        //Success!
        Debug.WriteLine(String.Format("Agency: {0},{1}", agency.IntegrationKey, agency.AgencyID));
      } 
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Adds a new embedded rating agency.
    /// </summary>
    //[TestMethod]
    public void ChangeEmbeddedRatingAgencyUserCountBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var token = impClient.GetBearerToken(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), "[INTEGRATION KEY FOR AGENCY GOES HERE]");

        impClient.SetEmbeddedRatingUserCount(token, 10);
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Gets the years supported by the vehicle database.
    /// </summary>
    //[TestMethod]
    public void GetVehicleYears()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var years = impClient.GetVehicleYears(new Guid("[YOUR IMP ACCOUNT ID GOES HERE]"));

        // Success!
        Debug.WriteLine(String.Format("Year: ", years.First()));
      }
      catch (WebException)
      {
        // Handle web exceptions appropriately.
      }
      catch (Exception)
      {
        // Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Gets vehicle makes for a specific year.
    /// </summary>
    //[TestMethod]
    public void GetVehicleMakes()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var makes = impClient.GetVehicleMakes(new Guid("[YOUR IMP ACCOUNT ID GOES HERE]"), 2005);

        // Success!
        Debug.WriteLine(String.Format("Make: ", makes.First()));
      }
      catch (WebException)
      {
        // Handle web exceptions appropriately.
      }
      catch (Exception)
      {
        // Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Gets vehicle models for a specific year and make.
    /// </summary>
    //[TestMethod]
    public void GetVehicleModels()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var models = impClient.GetVehicleModels(new Guid("[YOUR IMP ACCOUNT ID GOES HERE]"), 2005, "honda");

        // Success!
        Debug.WriteLine(String.Format("Model: ", models.First()));
      }
      catch (WebException)
      {
        // Handle web exceptions appropriately.
      }
      catch (Exception)
      {
        // Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Gets vehicle detail information for a specific year, make and model.
    /// </summary>
    [TestMethod]
    public void GetVehicleDetails()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var details = impClient.GetVehicleDetails(new Guid("[YOUR IMP ACCOUNT ID GOES HERE]"), 2005, "honda", "accord ex");

        // Success!
        Debug.WriteLine(String.Format("MSRP: ", details.First().MSRP));
      }
      catch (WebException)
      {
        // Handle web exceptions appropriately.
      }
      catch (Exception)
      {
        // Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Gets vehicle detail information for a specific year, make and model.
    /// </summary>
    //[TestMethod]
    public void GetVehicleDetailByVin()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var details = impClient.GetVehicleDetailByVin(new Guid("[YOUR IMP ACCOUNT ID GOES HERE]"), "1GCM81705");

        // Success!
        Debug.WriteLine(String.Format("MSRP: ", details.MSRP));
      }
      catch (WebException)
      {
        // Handle web exceptions appropriately.
      }
      catch (Exception)
      {
        // Handle all other exception types appropriately.
      }
    }  
    
    /// <summary>
    /// Tests retrieval of all default limits for a state.
    /// </summary>
    //[TestMethod]
    public void GetDefaultLimits()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var limits = impClient.GetDefaultLimits(InsuranceLine.PersonalAuto, USState.Arizona);

        // Success!
        Debug.WriteLine(String.Format("First Liability Limit: ", limits[0].LiabilityBILimits[0]));
      }
      catch (WebException)
      {
        // Handle web exceptions appropriately.
      }
      catch (Exception)
      {
        // Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Tests retrieval of a single set of default limits for a state.
    /// </summary>
    //[TestMethod]
    public void GetSingleDefaultLimit()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var limits = impClient.GetDefaultLimits(InsuranceLine.PersonalAuto, USState.Arizona, 20, 40);

        // Success!
        Debug.WriteLine(String.Format("First Liability Limit: ", limits[0].LiabilityBILimits[0]));
      }
      catch (WebException)
      {
        // Handle web exceptions appropriately.
      }
      catch (Exception)
      {
        // Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// PPC lookup using basic authentication.
    /// </summary>
    //[TestMethod]
    public void PpcBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var ppcResults = impClient.Ppc(new Guid("[YOUR IMP ACCOUNT ID GOES HERE]"), "TX", "[VALID ZIP CODE HERE]", "[VALID STREET NAME HERE]", "[VALID STREET TYPE HERE]", "[VALID STREET NUMBER HERE]");

        // Success!
        if (ppcResults != null && ppcResults.Count == 1)
          Debug.WriteLine("Exact match found. PPC: " + ppcResults[0].Ppc);
        else if (ppcResults != null && ppcResults.Count > 1)
        {
          Debug.WriteLine("No exact match, used Zip Code Results for PPC.");
          foreach (var ppcResult in ppcResults)
            Debug.WriteLine("PPC:" + ppcResult.Ppc);
        }
      }
      catch (WebException)
      {
        // Handle web exceptions appropriately.
      }
      catch (Exception)
      {
        // Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Fire District lookup using basic authentication.
    /// </summary>
    //[TestMethod]
    public void FireDistrictBasic()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var fireDistrictsResults = impClient.FireDistricts(new Guid("[YOUR IMP ACCOUNT ID GOES HERE]"), "[VALID STATE INITIALS HERE]", "[VALID COUNTY HERE]");

        // Success!
        if (fireDistrictsResults != null && fireDistrictsResults.Count == 1)
          Debug.WriteLine("Exact match found. Fire District: " + fireDistrictsResults[0]);
        else if (fireDistrictsResults != null && fireDistrictsResults.Count > 1)
        {
          Debug.WriteLine("No exact match, used Zip Code Results for PPC.");
          foreach (string fireDistrict in fireDistrictsResults)
            Debug.WriteLine("Fire District:" + fireDistrict);
        }
      }
      catch (WebException)
      {
        // Handle web exceptions appropriately.
      }
      catch (Exception)
      {
        // Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// property valuation using basic authentication
    /// </summary>
    //[TestMethod]
    public void PropertyValuationEstimation()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var propertyValuationRequest = new PremiumValuationRequest()
        {
          Address1 = "274 Woodlands drive",
          Address2 = "",
          City = "Kingston Springs",
          State = "TN",
          ZipCode = "37082",
          YearOfConstruction = 1974,
          SquareFootage = 2150,
          NumberOfFamilies = 1,
          NumberOfStories = 2,
          StoryType = StoryType.TwoStories
        };
        var propertyValuationResult = impClient.GetPremiumValuation(new Guid("[YOUR IMP ACCOUNT ID GOES HERE]"), propertyValuationRequest, false);
        if (propertyValuationResult != null && propertyValuationResult.WasSuccessful)
          Debug.WriteLine("Property valuation found");
      }
      catch (WebException)
      {
        // Handle web exceptions appropriately.
      }
      catch (Exception)
      {
        // Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// get policy audit data using basic authentication.
    /// </summary>
    //[TestMethod]
    public void GetPolicyAuditData()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.BaseUrl };
      try
      {
        var policyModelDataResult = impClient.GetPolicyModelData(new Guid("[YOUR IMP ACCOUNT ID GOES HERE]"), new Guid("[YOUR QUOTE UID GOES HERE]"));
        if (policyModelDataResult != null)
          Debug.WriteLine("Policy model data found");
      }
      catch (WebException)
      {
        // Handle web exceptions appropriately.
      }
      catch (Exception)
      {
        // Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Search for quote templates using filter(s), basic authentication.
    /// </summary>
    //[TestMethod]
    public void SearchTemplates()
    {
      var impClient = new TurboRater.ApiClients.Imp.Default.Container(new Uri(ImpConstants.TestBaseUrl + "api"));
      try
      {
        impClient.SendingRequest2 += (sender, eventArgs) =>
        {
          ImpClient.SetClientHeadersOData(eventArgs.RequestMessage, null, Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"));
        };
        //More query options can be found here: http://odata.github.io/odata.net/#04-02-query-options
        var templates = impClient.Templates.Where(template => template.LineOfInsurance == ApiClients.Imp.ITC.Insurance.InsuranceLine.PersonalAuto && template.State == ApiClients.Imp.ITC.Utilities.USState.Texas).OrderBy(template => template.Name).Take(10);
        foreach (var template in templates)
          Debug.WriteLine(String.Format("Template: {0}, {1}", template.Name, template.LineOfInsurance.ToString()));
      }
      catch (DataServiceQueryException ex)
      {
        //Handle odata query exceptions appropriately.
        Debug.WriteLine(ex.Message);
        //Note that the innerexception will have detailed failure information. 
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// add quote template using basic authentication.
    /// </summary>
    //[TestMethod]
    public void AddQuoteTemplate()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var template = new QuoteTemplate()
        {
          RecordId = -1,
          DateCreated = DateTime.Now,
          LastModifiedDate = new DateTime(1, 1, 1),
          AgencyId = Guid.Parse("[YOUR AGENCY ID GOES HERE]"),
          AgencyLocationId = Guid.Parse("[YOUR AGENCY LOCATION ID GOES HERE]"),
          ConvertedFromQuoteID = -1,
          State = USState.Texas,
          LineOfInsurance = InsuranceLine.PersonalAuto,
          QuoteTemplateId = new Guid(),
          QuoteTemplateItems = new System.Collections.Generic.List<QuoteTemplateItem>()
          {
            new QuoteTemplateItem()
            {
              Action = QuoteTemplateAction.Show,
              DefaultValue = "",
              RecordId = -1,
              FieldName = "[YOUR FIELD NAME HERE]",
              QuoteTemplateLinkId = -1,  // same recordid as the main RecordId field
              Scope = ItemScope.Policy  // scope of the template item to default
            }
          }
        };

        impClient.AddQuoteTemplate(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), "[YOUR BEARER TOKEN GOES HERE]", template);

        //Success!
        Debug.WriteLine(String.Format("Quote template: {0},{1}", template.RecordId, template.Name));
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// get quote template using basic authentication.
    /// </summary>
    //[TestMethod]
    public void GetQuoteTemplate()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        int recordId = -1;  // quote template id to get
        var template = impClient.GetQuoteTemplate(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), "[YOUR BEARER TOKEN GOES HERE]", recordId);

        //Success!
        Debug.WriteLine(String.Format("Quote template: {0},{1}", template.RecordId, template.Name));
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// get all quote templates using basic authentication.
    /// </summary>
    //[TestMethod]
    public void GetQuoteTemplates()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        int recordId = -1;  // quote template id to get
        var templates = impClient.GetQuoteTemplates(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), "[YOUR BEARER TOKEN GOES HERE]");

        //Success!
        if (templates != null && templates.Count > 0)
          Debug.WriteLine("Templates found. Name: " + templates[0].Name);
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// update quote template using basic authentication.
    /// </summary>
    //[TestMethod]
    public void UpdateQuoteTempate()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var template = new QuoteTemplate()
        {
          RecordId = -1,  // quote template id to update
          DateCreated = DateTime.Now,  // the date the quote template was created
          LastModifiedDate = DateTime.Now,
          AgencyId = Guid.Parse("[YOUR AGENCY ID GOES HERE]"),
          AgencyLocationId = Guid.Parse("[YOUR AGENCY LOCATION ID GOES HERE]"),
          ConvertedFromQuoteID = -1,
          State = USState.Texas,
          LineOfInsurance = InsuranceLine.PersonalAuto,
          QuoteTemplateId = new Guid(),
          QuoteTemplateItems = new System.Collections.Generic.List<QuoteTemplateItem>()
          {
            new QuoteTemplateItem()
            {
              Action = QuoteTemplateAction.Show,
              DefaultValue = "",
              RecordId = -1,
              FieldName = "[YOUR FIELD NAME HERE]",
              QuoteTemplateLinkId = -1,  // same recordid as the main RecordId field
              Scope = ItemScope.Policy  // scope of the template item to default
            }
          }
        };

        impClient.UpdateQuoteTemplate(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), "[YOUR BEARER TOKEN GOES HERE]", template);

        //Success!
        Debug.WriteLine(String.Format("Quote template: {0},{1}", template.RecordId, template.Name));
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// delete quote template using basic authentication.
    /// </summary>
    //[TestMethod]
    public void DeleteQuoteTemplate()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        int recordId = -1;  // quote template id to delete
        impClient.DeleteQuoteTemplate(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), "[YOUR BEARER TOKEN GOES HERE]", recordId);

        //Success!
        Debug.WriteLine("Quote template deleted");
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Adds your ITC embedded rating purchased product code to the authenticating agency.
    /// This is used to associate a pre-existing TurboRater account with your Embedded Rating
    /// account.
    /// </summary>
    [TestMethod]
    public void AddEmbeddedRatingPurchasedProductBearer()
    {
      IImpClient impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        impClient.AddEmbeddedRatingPurchasedProduct(Guid.Parse("[YOUR IMP ACCOUNT ID GOES HERE]"), "[YOUR BEARER TOKEN GOES HERE]");

        //Success!
        Debug.WriteLine("Embedded rating purchased product added to agency.");
      }
      catch (Exception)
      {
        //Handle all other exception types appropriately.
      }
    }

    /// <summary>
    /// Retrieves violations for a given state 
    /// </summary>
    //[TestMethod]
    public void GetViolationsForState()
    {
      var impClient = new ImpClient() { BaseUrl = ImpConstants.TestBaseUrl };
      try
      {
        var results = impClient.GetViolationsForState(USState.Texas);

        // Success!
        if (results != null && results.Count > 0)
          Debug.WriteLine("Success! State violations found!");
      }
      catch (WebException ex)
      {
        // Handle web exceptions appropriately.
      }
      catch (Exception ex)
      {
        // Handle all other exception types appropriately.
      }
    }
  }
}
