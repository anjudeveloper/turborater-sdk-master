using System;

namespace TurboRater.ApiClients.RateEngineApi
{
  /// <summary>
  /// A rated driver
  /// </summary>
  public class ResponseDriver
  {
    /// <summary>
    /// The number of the driver.
    /// </summary>
    public int DriverNumber { get; set; }
    /// <summary>
    /// The number of points charged to the driver.
    /// </summary>
    public int Points { get; set; }
    /// <summary>
    /// The age of the driver.
    /// </summary>
    public int Age { get; set; }
    /// <summary>
    /// The sex of the driver. Male or Female.
    /// </summary>
    public string Sex { get; set; }
    /// <summary>
    /// The marital status of the driver. Married, Single, Divorced, Widowed, Separated, DomesticPartner, CommonLaw.
    /// </summary>
    public string Marital { get; set; }
    /// <summary>
    /// The realation of the driver to the insured. Insured, Spouse, Child,	OtherRelated,	OtherNonRelated, Parent.
    /// </summary>
    public string Relation { get; set; }
    /// <summary>
    /// The driverclass aggigned to the driver during rating.
    /// </summary>
    public string DriverClass { get; set; }
    /// <summary>
    /// The credit score used in rating if one was obtained. 
    /// </summary>
    public string CreditScore { get; set; }
    /// <summary>
    /// The car the driver is assigned to.
    /// </summary>
    public int AssignedCar { get; set; }

    /// <summary>
    /// The default constructor.
    /// </summary>
    public ResponseDriver()
    {
      this.Age = ITCConstants.InvalidNum;
      this.AssignedCar = ITCConstants.InvalidNum;
      this.CreditScore = String.Empty;
      this.DriverClass = String.Empty;
      this.DriverNumber = ITCConstants.InvalidNum;
      this.Marital = "Single";
      this.Points = 0;
      this.Relation = "Insured";
      this.Sex = "Male";
    }
  }
}
