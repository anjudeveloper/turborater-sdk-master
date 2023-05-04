using System;

namespace TurboRater.Insurance
{
  /// <summary>
  /// rate-specific vehicle information for a comparison of rating
  /// </summary>
  [Serializable]
  public class ComparisonCar : ComparisonUnit
  {
  #pragma warning disable 1591 //dont' really need warnings about xml comments for the properties of this class

    public int LiabLimits1 { get; set; }
    public int LiabLimits2 { get; set; }
    public int LiabLimits3 { get; set; }
    public int PIPLimit { get; set; }
    public int MedPayLimit { get; set; }
    public int UIMBILimit1 { get; set; }
    public int UIMBILimit2 { get; set; }
    public int UninsBILimit1 { get; set; }
    public int UninsBILimit2 { get; set; }
    public string Territory { get; set; }
    public int CollDed { get; set; }
    public int CompDed { get; set; }
    public string Symbol { get; set; }
    public int TowingLimit { get; set; }
    public int UIMPDLimit { get; set; }
    public int UninsPDLimit { get; set; }
    public int RentalLimit { get; set; }
    public int UninsPDDed { get; set; }
    public double LiabBIPremium { get; set; }
    public double LiabPDPremium { get; set; }
    public double MedPayPremium { get; set; }
    public double PIPPremium { get; set; }
    public double RentalPremium { get; set; }
    public double TowingPremium { get; set; }
    public double UIMBIPremium { get; set; }
    public double UIMPDPremium { get; set; }
    public double UninsBIPremium { get; set; }
    public double UninsPDPremium { get; set; }
    public double CompPremium { get; set; }
    public double CollPremium { get; set; }
    public int OptionalBILImit1 { get; set; }
    public int OptionalBILimit2 { get; set; }
    public double OptionalBIPremium { get; set; }
    public int AccDeathLimit { get; set; }
    public double AccDeathPremium { get; set; }
    public int CustomEquipValue { get; set; } 
    public double CustomEquipPremium { get; set; }
    public int ExtraMedLimit { get; set; }
    public double ExtraMedPremium { get; set; }
    public bool FullGlass { get; set; }
    public double FullGlassPremium { get; set; }
    public bool GapCoverage { get; set; }
    public double GapPremium { get; set; }
    public int IncomeLossLimit { get; set; }
    public int IncomeLossLimit2 { get; set; }
    public double IncomeLossPremium { get; set; }
    public bool LegalExpense { get; set; }
    public double LegalExpensePremium { get; set; }
    public override ItemScope UnitScope { get { return ItemScope.Car; } }
  }
}
