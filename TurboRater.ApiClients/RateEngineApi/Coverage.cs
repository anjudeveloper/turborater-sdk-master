using System;
using System.Collections.Generic;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// A single coverage (liab, pip, etc)
  /// </summary>
  public class Coverage
  {
    /// <summary>
    /// The name of the coverage. LiabBI, LiabPD, PIP, MedPay, UnInsBI, UnInsPD, UIMBI, UIMPD, 
    ///	Comp, Coll, Towing, Rental, ADD, FullGlass.
    /// </summary>
    public string CoverageName { get; set; }
    /// <summary>
    /// List of limits for the coverage.
    /// </summary>
    public List<int> Limit { get; set; }
    /// <summary>
    /// The coverage deductible if one applies.
    /// </summary>
    public double Deductible { get; set; }
    /// <summary>
    /// The premium for the coverage.
    /// </summary>
    public double Premium { get; set; }

    /// <summary>
    /// The default constructor.
    /// </summary>
    public Coverage()
    {
      this.CoverageName = String.Empty;
      this.Deductible = ITCConstants.InvalidNum;
      this.Limit = new List<int>();
      this.Premium = 0;
    }
  }
}
