// -----------------------------------------------------------------------
// <copyright file="RateEngineApiClient.cs" company="ITC">
// Copyright ITC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
// <summary>
// Client for working with rate engine <c>API</c>.
// </summary>

namespace TurboRater.ApiClients.RateEngineApi
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net.Http;
  using System.Net.Http.Headers;
  using System.Text;
  using System.Threading.Tasks;
  using System.Web;
  using System.Web.Script.Serialization;

  /// <summary>
  /// Client class used for calling the Rate Engine API
  /// </summary>
  public class RateEngineApiClient : IRateEngineApiClient
  {
    private string m_lastServerUsed = String.Empty;

    /// <summary>
    ///  Initializes a new instance of the <see cref="RateEngineApiClient" /> class.
    /// </summary>
    public RateEngineApiClient()
    {
      JavaScriptSerializer = new JavaScriptSerializer();
    }

    /// <summary>
    /// Gets or sets the base URL used to connect to the rate engine API.
    /// </summary>
    public string BaseUrl { get; set; }

    /// <summary>
    /// Gets or sets ID used to authenticate with the rate engine API. Most methods don't require <c>auth</c>, but this used by those that do.
    /// </summary>
    public string AuthId { get; set; }

    /// <summary>
    /// Gets or sets Password used to authenticate with the rate engine <c>api</c>. Most methods don't require <c>auth</c>, but this used by those that do.
    /// </summary>
    public string AuthPassword { get; set; }

    /// <summary>
    /// Should we add compression headers (gzip, deflate) to the http requests? Defaults to false.
    /// </summary>
    public bool AddCompressionHeaders { get; set; }

    /// <summary>
    /// Gets the last server used by this client.
    /// </summary>
    public string LastServerUsed { get { return m_lastServerUsed; } }

    /// <summary>
    /// Sets the last server used based on a header in the response message.
    /// </summary>
    /// <param name="response">Response from the most recent hit to the server.</param>
    private void SetLastServerUsed(HttpResponseMessage response)
    {
      m_lastServerUsed = String.Empty;
      if (response != null && response.Headers != null)
      {
        IEnumerable<string> values;
        if (response.Headers.TryGetValues("itc-server", out values))
        {
          m_lastServerUsed = values.First();
        }
      }
    }

    /// <summary>
    /// Gets or sets Custom message handler that we'll use for all requests to and responses from the rate engine <c>api</c>.
    /// We'll mostly use this for compression.
    /// </summary>
    public HttpMessageHandler CustomMessageHandler { get; set; }

    /// <summary>
    /// Gets or sets JS serialization object
    /// </summary>
    protected JavaScriptSerializer JavaScriptSerializer { get; set; }

    /// <summary>
    /// Requests rates from the <c>api</c>.
    /// </summary>
    /// <param name="request">the request object which contains all the necessary information for rating.</param>
    public void RatePolicy(ITCRateEngineRequest request)
    {
      using (var client = CustomMessageHandler != null ? new HttpClient(CustomMessageHandler) : new HttpClient())
      {
        SetupHttpClient(client);
        var content = new StringContent(JavaScriptSerializer.Serialize(request), Encoding.UTF8, ITCConstants.GetMediaType(MediaType.Json));
        HttpResponseMessage response = client.PostAsync("api/rates/", content).Result;
        SetLastServerUsed(response);
        if (!response.IsSuccessStatusCode)
        {
          string responseText = response.Content != null ? response.Content.ReadAsStringAsync().Result : String.Empty;
          throw new HttpException((int)response.StatusCode, String.IsNullOrWhiteSpace(responseText) ? "Error sending rate request: " + response.StatusCode + ": " + response.ReasonPhrase : responseText);
        }
      }
    }

    /// <summary>
    /// Requests rates from the <c>API</c> asynchronously.
    /// </summary>
    /// <param name="request">the request object which contains all the necessary information for rating.</param>
    public async Task RatePolicyAsync(ITCRateEngineRequest request)
    {
      using (var client = CustomMessageHandler != null ? new HttpClient(CustomMessageHandler) : new HttpClient())
      {
        SetupHttpClient(client);
        var content = new StringContent(JavaScriptSerializer.Serialize(request), Encoding.UTF8, ITCConstants.GetMediaType(MediaType.Json));
        var response = await client.PostAsync("api/rates/", content);
        if (!response.IsSuccessStatusCode)
        {
          string responseText = response.Content != null ? response.Content.ReadAsStringAsync().Result : String.Empty;
          throw new HttpException((int)response.StatusCode, String.IsNullOrWhiteSpace(responseText) ? "Error sending rate request: " + response.StatusCode + ": " + response.ReasonPhrase : responseText);
        }
      }
    }

    /// <summary>
    /// Retrieves the rate results (whatever has finished rating so far) from a rate request.
    /// </summary>
    /// <param name="id">id of the rate request</param>
    /// <param name="returnAll">if true, this will return all the rates that have finished so far.
    /// If false, it will return only those rates that have finished and that have not yet been retrieved by a 
    /// previous call to GetRateResults.</param>
    /// <returns>the list of rate results</returns>
    public List<ITCRateEngineResponse> GetRateResults(string id, bool returnAll = false)
    {
      using (var client = CustomMessageHandler != null ? new HttpClient(CustomMessageHandler) : new HttpClient())
      {
        SetupHttpClient(client);
        HttpResponseMessage response =
          client.GetAsync(string.Format("api/rates/{0}?returnall={1}", HttpUtility.UrlEncode(id.ToString()), HttpUtility.UrlEncode(returnAll.ToString()))).Result;
        SetLastServerUsed(response);
        if (response.IsSuccessStatusCode)
        {
          var responseText = response.Content.ReadAsStringAsync().Result;
          return JavaScriptSerializer.Deserialize<List<ITCRateEngineResponse>>(responseText);
        }
        else
          throw new HttpException((int)response.StatusCode, "Error retrieving company information: " + response.StatusCode + ": " + response.ReasonPhrase);
      }
    }

    /// <summary>
    /// Retrieves Homeowner rate results (whatever has finished rating so far) from a rate request.
    /// </summary>
    /// <param name="id">id of the rate request</param>
    /// <param name="returnAll">if true, this will return all the rates that have finished so far.
    /// If false, it will return only those rates that have finished and that have not yet been retrieved by a 
    /// previous call to GetHORateResults.</param>
    /// <returns>the list of rate results</returns>
    public List<ITCRateEngineResponseHO2> GetHORateResults(string id, bool returnAll = false)
    {
      using (var client = CustomMessageHandler != null ? new HttpClient(CustomMessageHandler) : new HttpClient())
      {
        SetupHttpClient(client);
        HttpResponseMessage response =
          client.GetAsync(string.Format("api/rates/{0}?returnall={1}", HttpUtility.UrlEncode(id.ToString()), HttpUtility.UrlEncode(returnAll.ToString()))).Result;
        SetLastServerUsed(response);
        if (response.IsSuccessStatusCode)
        {
          var responseText = response.Content.ReadAsStringAsync().Result;
          return JavaScriptSerializer.Deserialize<List<ITCRateEngineResponseHO2>>(responseText);
        }
        else
          throw new HttpException((int)response.StatusCode, "Error retrieving company information: " + response.StatusCode + ": " + response.ReasonPhrase);
      }
    }

    /// <summary>
    /// Gets a request object that somebody sent to the rate engine <c>api</c>.
    /// </summary>
    /// <param name="accountId">the id of the TR account.</param>
    /// <param name="phoneCode">the phone code of the request or response</param>
    /// <returns>the rate engine request</returns>
    public ITCRateEngineRequestWrapper GetRequest(Guid accountId, string phoneCode)
    {
      using (var client = CustomMessageHandler != null ? new HttpClient(CustomMessageHandler) : new HttpClient())
      {
        SetupHttpClient(client);
        HttpResponseMessage response =
          client.GetAsync(string.Format("api/rates/getrequest/{0}/{1}", HttpUtility.UrlEncode(accountId.ToString()), HttpUtility.UrlEncode(phoneCode))).Result;
        SetLastServerUsed(response);
        if (response.IsSuccessStatusCode)
        {
          var responseText = response.Content.ReadAsStringAsync().Result;
          return JavaScriptSerializer.Deserialize<ITCRateEngineRequestWrapper>(responseText);
        }
        else
          throw new HttpException((int)response.StatusCode, "Error retrieving rating API request: " + response.StatusCode + ": " + response.ReasonPhrase);
      }
    }

    /// <summary>
    /// Gets Company Information related to  request object that somebody sent to the rate engine <c>api</c>.
    /// </summary>
    /// <param name="infoRequest">Describes company to get information about.</param>
    /// <returns>the Company Info Response</returns>
    public CompanyInfoResponse GetCompanyInfo(CompanyInfoRequest infoRequest)
    {
      HttpResponseMessage response = null;
      using (var client = CustomMessageHandler != null ? new HttpClient(CustomMessageHandler) : new HttpClient())
      {
        SetupHttpClient(client);
        var content = new StringContent(JavaScriptSerializer.Serialize(infoRequest), Encoding.UTF8, ITCConstants.GetMediaType(MediaType.Json));
        response = client.PostAsync("api/companyinfo/getcompanyinfo/", content).Result;
        SetLastServerUsed(response);
        if (response.IsSuccessStatusCode)
        {
          var responseText = response.Content.ReadAsStringAsync().Result;
          return JavaScriptSerializer.Deserialize<CompanyInfoResponse>(responseText);
        }
        else
          throw new HttpException((int)response.StatusCode, "Error retrieving rating API response: " + response.StatusCode + ": " + response.ReasonPhrase);
      }
    }

    /// <summary>
    /// Gets a response object that we generated when somebody sent a request to the rate engine <c>api</c>.
    /// </summary>
    /// <param name="accountId">the id of the TR account.</param>
    /// <param name="phoneCode">the phone code of the request or response</param>
    /// <returns>the rate engine response</returns>
    public ITCRateEngineResponseWrapper GetResponse(Guid accountId, string phoneCode)
    {
      using (var client = CustomMessageHandler != null ? new HttpClient(CustomMessageHandler) : new HttpClient())
      {
        SetupHttpClient(client);
        HttpResponseMessage response =
          client.GetAsync(string.Format("api/rates/getresponse/{0}/{1}", HttpUtility.UrlEncode(accountId.ToString()), HttpUtility.UrlEncode(phoneCode))).Result;
        SetLastServerUsed(response);
        if (response.IsSuccessStatusCode)
        {
          var responseText = response.Content.ReadAsStringAsync().Result;
          return JavaScriptSerializer.Deserialize<ITCRateEngineResponseWrapper>(responseText);
        }
        else
          throw new HttpException((int)response.StatusCode, "Error retrieving rating API response: " + response.StatusCode + ": " + response.ReasonPhrase);
      }
    }

    /// <summary>
    /// Gets a response object that we generated when somebody sent a request to the rate engine <c>api</c>.
    /// </summary>
    /// <param name="accountId">the id of the TR account.</param>
    /// <param name="phoneCode">the phone code of the request or response</param>
    /// <returns>the rate engine response</returns>
    public IList<ITCRateEngineResponseWrapper> GetResponses(Guid accountId, string phoneCode)
    {
      using (var client = CustomMessageHandler != null ? new HttpClient(CustomMessageHandler) : new HttpClient())
      {
        SetupHttpClient(client);
        HttpResponseMessage response =
          client.GetAsync(string.Format("api/rates/getresponses/{0}/{1}", HttpUtility.UrlEncode(accountId.ToString()), HttpUtility.UrlEncode(phoneCode))).Result;
        SetLastServerUsed(response);
        if (response.IsSuccessStatusCode)
        {
          var responseText = response.Content.ReadAsStringAsync().Result;
          return JavaScriptSerializer.Deserialize<List<ITCRateEngineResponseWrapper>>(responseText);
        }
        else
          throw new HttpException((int)response.StatusCode, "Error retrieving rating API response: " + response.StatusCode + ": " + response.ReasonPhrase);
      }
    }

    /// <summary>
    /// This returns all the responses for a given transaction by the account and phone code.
    /// </summary>
    /// <param name="accountId">the id of the TR account.</param>
    /// <param name="phoneCode">the phone code of the request or response</param>
    /// <returns>A list of rate engine responses representing all transactions under a single phone code</returns>
    public List<ITCRateEngineResponse> GetAllResponses(Guid accountId, string phoneCode)
    {
      //get the transaction id for this phone code for this company then use it to get all the rates
      using (var client = CustomMessageHandler != null ? new HttpClient(CustomMessageHandler) : new HttpClient())
      {
        SetupHttpClient(client);
        HttpResponseMessage response =
          client.GetAsync(string.Format("api/rates/getresponse/{0}/{1}", HttpUtility.UrlEncode(accountId.ToString()), HttpUtility.UrlEncode(phoneCode))).Result;
        SetLastServerUsed(response);
        if (response.IsSuccessStatusCode)
        {
          var responseText = response.Content.ReadAsStringAsync().Result;
          ITCRateEngineResponseWrapper result = JavaScriptSerializer.Deserialize<ITCRateEngineResponseWrapper>(responseText);
          string responseTransactionId = result.Response.TransactionID;
          string addToURL = "";
          addToURL = responseTransactionId + "/?returnAll=true";
          HttpResponseMessage responseWithAll = client.GetAsync("api/rates/" + addToURL).Result;
          if (responseWithAll.IsSuccessStatusCode)
          {
            return JavaScriptSerializer.Deserialize<List<ITCRateEngineResponse>>(responseWithAll.Content.ReadAsStringAsync().Result);
          }
          else
            throw new HttpException((int)response.StatusCode, "Error retrieving rating API response: " + response.StatusCode + ": " + response.ReasonPhrase);
        }
        else
          throw new HttpException((int)response.StatusCode, "Error retrieving rating API response: " + response.StatusCode + ": " + response.ReasonPhrase);
      }
    }

    /// <summary>
    /// Loads rating API account information for the specified account. If not found, an exception is thrown.
    /// </summary>
    /// <param name="accountId">ID of the account (<c>turborater</c> and rating API account id).</param>
    /// <returns>the account.</returns>
    public ApiAccount LoadAccount(Guid accountId)
    {
      using (var client = CustomMessageHandler != null ? new HttpClient(CustomMessageHandler) : new HttpClient())
      {
        SetupHttpClient(client);
        HttpResponseMessage response = client.GetAsync(string.Format("api/account/{0}", HttpUtility.UrlEncode(accountId.ToString()))).Result;
        SetLastServerUsed(response);
        if (response.IsSuccessStatusCode)
        {
          var responseText = response.Content.ReadAsStringAsync().Result;
          return JavaScriptSerializer.Deserialize<ApiAccount>(responseText);
        }
        else
          throw new HttpException((int)response.StatusCode, "Error retrieving account information: " + response.StatusCode + ": " + response.ReasonPhrase);
      }
    }

    /// <summary>
    /// Performs common setup tasks that we need whenever we use an HttpClient object to hit the rating <c>api</c>.
    /// </summary>
    /// <param name="client">the HttpClient object we'll configure.</param>
    protected void SetupHttpClient(HttpClient client)
    {
      client.BaseAddress = new Uri(BaseUrl);
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ITCConstants.GetMediaType(MediaType.Json)));
      client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(AuthId + ":" + AuthPassword)));
      if (AddCompressionHeaders)
      {
        client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
        client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
      }
    }

    /// <summary>
    /// get a MarketBasketIDItemID from the Market Basket service
    /// </summary>
    /// <param name="policy">the policy object in question that'll have the market basket id to prefetch.</param>
    /// <param name="request">the request object which contains all the necessary information for rating.</param>
    public RateEngineAPIMarketBasketResponse PreFetchMarketBasket(RateEngineAPIMarketBasketRequest request)
    {
      RateEngineAPIMarketBasketResponse reMarketBasketResponse = new RateEngineAPIMarketBasketResponse();
      using (HttpClient client = CustomMessageHandler != null ? new HttpClient(CustomMessageHandler) : new HttpClient())
      {
        SetupHttpClient(client);
        var serializedRequest = new StringContent(JavaScriptSerializer.Serialize(request), Encoding.UTF8, ITCConstants.GetMediaType(MediaType.Json));
        HttpResponseMessage response = client.PostAsync("api/rates/prefetchmarketbasket", serializedRequest).Result;
        SetLastServerUsed(response);
        if (response.IsSuccessStatusCode)
        {
          reMarketBasketResponse = JavaScriptSerializer.Deserialize<RateEngineAPIMarketBasketResponse>(response.Content.ReadAsStringAsync().Result);
        }
        else
          throw new HttpException((int)response.StatusCode, "Error retrieving rating API response: " + response.StatusCode + ": " + response.ReasonPhrase);
        return reMarketBasketResponse;
      }
    }
  }
}