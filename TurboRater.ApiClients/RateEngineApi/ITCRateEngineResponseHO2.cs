using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// A HO response message sent back from retrieving rating results from the itc rate engine api.
  /// </summary>
  [XmlInclude(typeof(ITCRateEngineResponseHO2))]
  public class ITCRateEngineResponseHO2 : ITCRateEngineResponseBase
  {
    /// <summary>
    /// The pure XML data.
    /// </summary>
    private string m_rawXml = string.Empty;

    /// <summary>
    /// A list of Coverage objects that define the coverages on the quote. 
    /// </summary>
    public List<Coverage> Coverages { get; set; }

    /// <summary>
    /// A list of endorsements rated on the quote.
    /// </summary>
    public List<Endorsement2> Endorsements { get; set; }

    /// <summary>
    /// A list of endorsements rated for this specific company.
    /// </summary>
    public List<Endorsement2> CompanyEndorsements { get; set; }

    /// <summary>
    /// Basic property deductibles.
    /// </summary>
    public List<HODeductible> Deductibles { get; set; }

    /// <summary>
    /// The rated policy form.
    /// </summary>
    public string Form { get; set; }

    /// <summary>
    /// Gets the raw XML.
    /// </summary>
    /// <returns>The raw XML.</returns>
    public string GetRawXml()
    {
      return m_rawXml;
    }

    /// <summary>
    /// Sets the raw XML.
    /// </summary>
    /// <param name="xml">The raw XML.</param>
    public void SetRawXml(string xml)
    {
      m_rawXml = xml;
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public ITCRateEngineResponseHO2()
      : base()
    {
    }

    /// <summary>
    /// constructor.
    /// </summary>
    /// <param name="initialize">If true, the initialize method will be called.</param>
    public ITCRateEngineResponseHO2(bool initialize = false)
      : base(initialize)
    {
    }

    /// <summary>
    /// Initialize the response with defaulted values.
    /// </summary>
    public override void Initialize()
    {
      base.Initialize();
      this.Coverages = new List<Coverage>();
      this.Endorsements = new List<Endorsement2>();
      this.CompanyEndorsements = new List<Endorsement2>();
      this.Deductibles = new List<HODeductible>();
    }

  }
}
