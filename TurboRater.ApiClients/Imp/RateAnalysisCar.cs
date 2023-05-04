using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// Car used for list of cars on a policy
  /// </summary>
  public class RateAnalysisCar
  {
    /// <summary>
    /// Gets or sets 
    /// </summary>
    public string CoSym { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public string CoTerr { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public float? LiabBIPremium { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public float? LiabPDPremium { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public float? MedPayPremium { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public float? PIPPremium { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public float? RentalPremium { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public float? TowingPremium { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public float? UIMBIPremium { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public float? UIMPDPremium { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public float? UninsBIPremium { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public float? UninsPDPremium { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CoLiabLimits1 { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CoLiabLimits2 { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CoLiabLimits3 { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CoCollDed { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CoCompDed { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CoPIPLimit { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CoMedPayLimit { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CoUIMBILimits1 { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CoUIMBILimits2 { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CoTowingLimit { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CoUIMPDLimit { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CoUninsBILimits1 { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CoUninsBILimits2 { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CoUninsPDLimit { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CoRentalLimit { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CoUninsPDDed { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public float? CompPremium { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public float? CollPremium { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int IncludedCoverages { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public string VIN { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? ACV { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? AnnualMiles { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CollDed { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? CompDed { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public string County { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? MedPayLimit { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? Miles { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? Odometer { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? PercentToWork { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? PIPLimit { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? RentalLimit { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? TowingLimit { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? UIMPDLimit { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? UninsPDLimit { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public string Usage { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public string ZipCode { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public bool? Garaged { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public string GaragingZipCode { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public bool? LeasedVehicle { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? LiabLimits1 { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? LiabLimits2 { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? LiabLimits3 { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? UninsBILimits1 { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? UninsBILimits2 { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? UIMBILimits1 { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? UIMBILimits2 { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? PrimaryOperator { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public int? Year { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public string Maker { get; set; }

    /// <summary>
    /// Gets or sets 
    /// </summary>
    public string Model { get; set; }
  }
}
