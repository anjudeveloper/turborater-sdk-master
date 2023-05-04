using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using TurboRater.ApiClients.RateEngineApi;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// An AU response message sent back from retrieving rating results from the itc rate engine api.
  /// </summary>
  [XmlInclude(typeof(ITCRateEngineResponse))]
  public class ITCRateEngineResponse : ITCRateEngineResponseBase
  {
    private IList<string> m_rawTt2 = new List<string>();

    /// <summary>
    /// The amount of SR22 fee.
    /// </summary>
    public virtual double SR22Fee { get; set; }

    /// <summary>
    /// The amount of ATPAFee.
    /// </summary>
    public virtual double ATPAFee { get; set; }

    /// <summary>
    /// The amount of FR44 fee.
    /// </summary>
    public virtual double FR44Fee { get; set; }

    /// <summary>
    /// The cars on the policy and their information.
    /// </summary>
    public virtual List<ResponseCar> Cars { get; set; }

    /// <summary>
    /// The drivers on the policy and their information.
    /// </summary>
    public virtual List<ResponseDriver> Drivers { get; set; }

    /// <summary>
    /// returns the raw tt2
    /// </summary>
    /// <returns>the raw tt2</returns>
    public IList<string> GetRawTt2()
    {
      return m_rawTt2;
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public ITCRateEngineResponse() : base()
    {
    }

    /// <summary>
    /// constructor.
    /// </summary>
    /// <param name="initialize">If true, the initialize method will be called.</param>
    public ITCRateEngineResponse(bool initialize = false) : base(initialize)
    {
    }

    /// <summary>
    /// Initialize the response with defaulted values.
    /// </summary>
    public override void Initialize()
    {
      base.Initialize();
      this.SR22Fee = 0;
      this.ATPAFee = 0;
      this.FR44Fee = 0;
      this.Cars = new List<ResponseCar>();
      this.Drivers = new List<ResponseDriver>();
    }
  }
}
