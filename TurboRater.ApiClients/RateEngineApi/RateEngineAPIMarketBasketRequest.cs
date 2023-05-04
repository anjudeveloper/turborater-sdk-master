using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurboRater.Insurance;

namespace TurboRater.ApiClients.RateEngineApi
{
  public class RateEngineAPIMarketBasketRequest
  {
    /// <summary>
    /// The actual request.
    /// </summary>
    public string PolicyData { get; set; }

    /// <summary>
    /// This is a unique token to associate the transaction with the customer. This is
    /// a required field.
    /// </summary>
    public string CustomerID { get; set; }

    /// <summary>
    /// Test flag for transactions.
    /// </summary>
    public bool Test { get; set; }

    /// <summary>
    /// Rate Service account number associated with the transaction.  This is
    /// a required field.
    /// </summary>
    public string AccountNumber { get; set; }
  }
}
