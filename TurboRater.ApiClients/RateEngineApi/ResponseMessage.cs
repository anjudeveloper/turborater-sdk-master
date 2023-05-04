using System;
using System.Collections.Generic;
using TurboRater.Insurance;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// A single warning/error/info message on a rate response. There can be multiple of these per rated product.
  /// </summary>
  public class ResponseMessage
  {
    /// <summary>
    /// The amount of discount or surcharge if given.
    /// </summary>
    public double Amount { get; set; }
    /// <summary>
    /// The Text describing the discount, warning or surcharge.
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// The percentage of the surcharge or discount if given.
    /// </summary>
    public double Percentage { get; set; }
    /// <summary>
    /// The scope of the discount, warning, or surcharge. Policy = 0, Driver = 1, Car = 2, Violation = 3.
    /// </summary>
    public ItemScope Scope { get; set; }
    /// <summary>
    /// The driver, car or violation number. Policy scopenum is always 0. If this applies to more than one driver, car  or violation 
    /// there will be multiple values here.
    /// </summary>
    public List<int> ScopeNum { get; set; }
    /// <summary>
    /// The message code.
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// Default constructor
    /// </summary>
    public ResponseMessage()
    {
      this.Amount = ITCConstants.InvalidNum;
      this.Text = String.Empty;
      this.Scope = ItemScope.Policy;
      this.Percentage = ITCConstants.InvalidNum;
      this.ScopeNum = new List<int>();
      this.Code = ITCConstants.InvalidNum;
    }

    /// <summary>
    /// Determines whether two Message instances are equal.
    /// </summary>
    /// <param name="obj">The Message to compare to the current message</param>
    /// <returns>true if the objects are equal, otherwise false</returns>
    public override bool Equals(object obj)
    {
      //Added try/catch for JSON serialization.
      try
      {
        ResponseMessage objMessage = obj as ResponseMessage;
        if ((obj == null) || (this == null))
          return false;
        return (this.GetHashCode() == objMessage.GetHashCode());
      }
      catch (Exception)
      {
        return false;
      }
    }

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    /// <returns>A 32-bit signed integer hash code</returns>
    public override int GetHashCode()
    {
      return ((int)this.Scope.GetHashCode() ^ this.Percentage.GetHashCode() ^ this.Amount.GetHashCode() ^ this.Code.GetHashCode() ^
        this.Text.ToUpper().GetHashCode());
    }

  }
}
