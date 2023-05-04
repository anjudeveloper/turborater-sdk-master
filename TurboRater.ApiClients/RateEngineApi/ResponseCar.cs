using System;
using System.Collections.Generic;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// A rated car sent down in the rate engine api response
  /// </summary>
  public class ResponseCar
  {
    /// <summary>
    /// The number of the car.
    /// </summary>
    public int CarNumber { get; set; }
    /// <summary>
    /// The cars VIN.
    /// </summary>
    public string VIN { get; set; }
    /// <summary>
    /// The year model of the car.
    /// </summary>
    public int Year { get; set; }
    /// <summary>
    /// The make of the car.
    /// </summary>
    public string Make { get; set; }
    /// <summary>
    /// The model of the car.
    /// </summary>
    public string Model { get; set; }
    /// <summary>
    /// The symbol the carrier assigned to this car.
    /// </summary>
    public string Symbol { get; set; }
    /// <summary>
    /// A list of Coverage objects that define the coverages on the car. The following coverages, limits, deductible and premium may be returned:
    /// BI - LiabBI, OPTBI - OptionalBI, PD - LiabPD, LPD - Limited LiabPD, UM - UnInsuredBI, UMPD - UnInsuredPD, 
    /// UNDUM - UnderInsuredBI, UNDPD - UnderInsuredPD, PIP - PIP, MEDPM - Medical Payments, COMP - Comprehensive, 
    /// COLL - Collision, LCOL - Limited Collision, CWAIV: collision deductible waiver, TL - Towing and Labor, 
    /// RREIM - Rental Reimbursement, FG - Full Glass, WL - Work Loss, ADB - Accidental Death, GAP - Loan/Lease coverge,
    /// EXMED - Extra Medical.
    /// </summary>
    public List<Coverage> Coverages { get; set; }

    /// <summary>
    /// Ths default constructor.
    /// </summary>
    public ResponseCar()
    {
      this.Coverages = new List<Coverage>();
      this.Make = String.Empty;
      this.Model = String.Empty;
      this.VIN = String.Empty;
      this.Year = ITCConstants.InvalidNum;
    }
  }
}
