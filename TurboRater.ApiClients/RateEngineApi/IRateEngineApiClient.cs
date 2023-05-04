// -----------------------------------------------------------------------
// <copyright file="IRateEngineApiClient.cs" company="ITC">
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
  using System.Net.Http;
  using System.Threading.Tasks;

  /// <summary>
  /// Interface for dealing with clients to the rate engine <c>API</c>. 
  /// </summary>
  public interface IRateEngineApiClient
  {
    /// <summary>
    /// Gets or sets the base URL used to connect to the rate engine <c>API</c>.
    /// </summary>
    string BaseUrl { get; set; }

    /// <summary>
    /// Gets or sets ID used to authenticate with the rate engine <c>API</c>. Most methods don't require <c>auth</c>, but this used by those that do.
    /// </summary>
    string AuthId { get; set; }

    /// <summary>
    /// Gets or sets password used to authenticate with the rate engine <c>API</c>. Most methods don't require <c>auth</c>, but this used by those that do.
    /// </summary>
    string AuthPassword { get; set; }

    /// <summary>
    /// Should we add compression headers (gzip, deflate) to the http requests? Defaults to false.
    /// </summary>
    bool AddCompressionHeaders { get; set; }

    /// <summary>
    /// Gets or sets Custom message handler that we'll use for all requests to and responses from the rate engine <c>API</c>.
    /// We'll mostly use this for compression.
    /// </summary>
    HttpMessageHandler CustomMessageHandler { get; set; }

    /// <summary>
    /// Gets the last server used by this client.
    /// </summary>
    string LastServerUsed { get; }

    /// <summary>
    /// Requests rates from the <c>API</c>.
    /// </summary>
    /// <param name="request">the request object which contains all the necessary information for rating.</param>
    void RatePolicy(ITCRateEngineRequest request);

    /// <summary>
    /// Requests rates from the <c>API</c> asynchronously.
    /// </summary>
    /// <param name="request">the request object which contains all the necessary information for rating.</param>
    Task RatePolicyAsync(ITCRateEngineRequest request);

    /// <summary>
    /// Retrieves the rate results (whatever has finished rating so far) from a rate request.
    /// </summary>
    /// <param name="id">id of the rate request</param>
    /// <param name="returnAll">if true, this will return all the rates that have finished so far.
    /// If false, it will return only those rates that have finished and that have not yet been retrieved by a 
    /// previous call to GetRateResults.</param>
    /// <returns>the list of rate results</returns>
    List<ITCRateEngineResponse> GetRateResults(string id, bool returnAll = false);

    /// <summary>
    /// Retrieves Homeowner rate results (whatever has finished rating so far) from a rate request.
    /// </summary>
    /// <param name="id">id of the rate request</param>
    /// <param name="returnAll">if true, this will return all the rates that have finished so far.
    /// If false, it will return only those rates that have finished and that have not yet been retrieved by a 
    /// previous call to GetHORateResults.</param>
    /// <returns>the list of rate results</returns>
    List<ITCRateEngineResponseHO2> GetHORateResults(string id, bool returnAll = false);

    /// <summary>
    /// Gets a request object that somebody sent to the rate engine <c>API</c>
    /// </summary>
    /// <param name="accountId">the id of the TR account.</param>
    /// <param name="phoneCode">the phone code of the request or response</param>
    /// <returns>the rate engine request</returns>
    ITCRateEngineRequestWrapper GetRequest(Guid accountId, string phoneCode);

    /// <summary>
    /// Gets Company Information related to  request object that somebody sent to the rate engine <c>API</c>.
    /// </summary>
    /// <param name="infoRequest">Describes company to get information about.</param>
    /// <returns>the Company Info Response</returns>
    CompanyInfoResponse GetCompanyInfo(CompanyInfoRequest infoRequest);

    /// <summary>
    /// Gets a response object that we generated when somebody sent a request to the rate engine <c>API</c>.
    /// </summary>
    /// <param name="accountId">the id of the TR account.</param>
    /// <param name="phoneCode">the phone code of the request or response</param>
    /// <returns>the rate engine response</returns>
    ITCRateEngineResponseWrapper GetResponse(Guid accountId, string phoneCode);

    /// <summary>
    /// This returns all the responses for a given transaction by the account and phone code
    /// </summary>
    /// <param name="accountId">the id of the TR account.</param>
    /// <param name="phoneCode">the phone code of the request or response</param>
    /// <returns>A list of rate engine responses representing all transactions under a single phone code</returns>
    List<ITCRateEngineResponse> GetAllResponses(Guid accountId, string phoneCode);

    /// <summary>
    /// Loads rating <c>API</c> account information for the specified account. If not found, an exception is thrown.
    /// </summary>
    /// <param name="accountId">ID of the account (turbo rater and rating <c>API</c> account id).</param>
    /// <returns>the account.</returns>
    ApiAccount LoadAccount(Guid accountId);

    /// <summary>
    /// get a MarketBasketIDItemID from the Market Basket service
    /// </summary>
    /// <param name="policy">the policy object in question that'll have the market basket id to prefetch.</param>
    /// <param name="request">the request object which contains all the necessary information for rating.</param>
    RateEngineAPIMarketBasketResponse PreFetchMarketBasket(RateEngineAPIMarketBasketRequest request);
  }
}
