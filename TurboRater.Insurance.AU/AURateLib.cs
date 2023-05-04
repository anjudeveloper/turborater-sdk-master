using System;

namespace TurboRater.Insurance.AU
{
  /// <summary>
  /// Summary description for AURateLib.
  /// </summary>
  public class AURateLib : RateLib
  {
    /// <summary>
    /// The policy that this AURateLib object will act upon.
    /// </summary>
    public virtual AUPolicy Policy
    {
      get { return m_policy; }
      set { m_policy = value; }
    }

    /// <summary>
    /// Is the specified driver a homeowner?
    /// </summary>
    /// <param name="driverNum">The driver to check (0-based index)</param>
    /// <returns>true if the driver is a homeowner, otherwise false</returns>
    public virtual bool HomeOwner(int driverNum)
    {
      bool tempResult = false;
      if (Policy.NumOfDrivers > driverNum)
        tempResult = ((Policy.Drivers[driverNum].ResidencyType == AUConstants.ResidencyTypeChars[(int)ResidencyType.Home]) &&
          (Policy.Drivers[driverNum].ResidencyStatus == AUConstants.ResidencyStatusChars[(int)ResidencyStatus.Own]));
      return tempResult;
    }

    /// <summary>
    /// Is the specified driver a renter or leaser (of their property, not vehicle)?
    /// </summary>
    /// <param name="driverNum">The driver to check (0-based index)</param>
    /// <returns>true if the driver is a renter/leaser, otherwise false</returns>
    public virtual bool RentOrLease(int driverNum)
    {
      bool tempResult = false;
      if (Policy.NumOfDrivers > driverNum)
        tempResult = ((Policy.Drivers[driverNum].ResidencyStatus == AUConstants.ResidencyStatusChars[(int)ResidencyStatus.Rent]) ||
          (Policy.Drivers[driverNum].ResidencyStatus == AUConstants.ResidencyStatusChars[(int)ResidencyStatus.Lease]));
      return tempResult;
    }

    /// <summary>
    /// Is the specified driver a responsible resident? Defined as:
    /// * Has Property Insurance
    /// * Rents or leases the property
    /// </summary>
    /// <param name="driverNum">The driver to check (0-based index)</param>
    /// <returns>true if the driver is a responsible resident, otherwise false</returns>
    public virtual bool RespResident(int driverNum)
    {
      bool tempResult = false;
      if (Policy.NumOfDrivers > driverNum)
        tempResult = ((Policy.Drivers[driverNum].PropertyInsurance) && (RentOrLease(driverNum)));
      return tempResult;
    }

    /// <summary>
    /// Is this policy a short-term/daily-term policy?
    /// </summary>
    /// <returns>True if daily/short-term, false otherwise</returns>
    public virtual bool IsDailyTerm()
    {
      return (Policy.Term == 0);
    }

    /// <summary>
    /// Does any car have a valid limit/deductible for the specified coverage?
    /// note that for coverages who don't have a limit, we still return true if the coverage is turned on.
    /// </summary>
    /// <param name="coverage">the coverage</param>
    /// <returns>true if so, otherwise false</returns>
    public virtual bool AnyCarHasLimitOrDeductible(CoverageType coverage)
    {
      bool result = false;
      for (int carIndex = 0; carIndex < Policy.NumOfCars; carIndex++)
        if (CarHasLimitOrDeductible(coverage, carIndex))
          result = true;
      return result;
    }

    /// <summary>
    /// Does the specified car have a valid limit/deductible for the specified coverage?
    /// note that for coverages who don't have a limit, we still return true if the coverage is turned on.
    /// </summary>
    /// <param name="coverage">the coverage</param>
    /// <param name="aCarIndex">index of the car on the policy</param>
    /// <returns>true if so, otherwise false</returns>
    public virtual bool CarHasLimitOrDeductible(CoverageType coverage, int aCarIndex)
    {
      switch (coverage)
      {
        case CoverageType.Liab: return Policy.Cars[aCarIndex].LiabLimits1 != InsConstants.BlankLimitVal || Policy.Cars[aCarIndex].LiabLimits2 != InsConstants.BlankLimitVal || Policy.Cars[aCarIndex].LiabLimits3 != InsConstants.BlankLimitVal;
        case CoverageType.LiabBI: return Policy.Cars[aCarIndex].LiabLimits1 != InsConstants.BlankLimitVal && Policy.Cars[aCarIndex].LiabLimits2 != InsConstants.BlankLimitVal;
        case CoverageType.LiabPD: return Policy.Cars[aCarIndex].LiabLimits3 != InsConstants.BlankLimitVal;
        case CoverageType.LimitedLiabPD: return Policy.Cars[aCarIndex].LimitedLiabPDLimit != InsConstants.BlankLimitVal;
        case CoverageType.Comp: return Policy.Cars[aCarIndex].CompDed != InsConstants.BlankLimitVal;
        case CoverageType.Coll: return Policy.Cars[aCarIndex].CollDed != InsConstants.BlankLimitVal;
        case CoverageType.LienHolder: return false;  // Returns false because no such property exists.
        case CoverageType.Rental: return Policy.Cars[aCarIndex].RentalLimit != InsConstants.BlankLimitVal;
        case CoverageType.Towing: return Policy.Cars[aCarIndex].TowingLimit != InsConstants.BlankLimitVal;
        case CoverageType.Unins: return false;  // Returns false because no such property exists.
        case CoverageType.UninsBI: return Policy.Cars[aCarIndex].UninsBILimits1 != InsConstants.BlankLimitVal || Policy.Cars[aCarIndex].UninsBILimits2 != InsConstants.BlankLimitVal;
        case CoverageType.UninsPD: return Policy.Cars[aCarIndex].UninsPDLimit != InsConstants.BlankLimitVal || Policy.Cars[aCarIndex].UninsPDDed != InsConstants.BlankLimitVal;
        case CoverageType.UIM: return false;  // Returns false because no such property exists.
        case CoverageType.UIMBI: return Policy.Cars[aCarIndex].UIMBILimits1 != InsConstants.BlankLimitVal || Policy.Cars[aCarIndex].UIMBILimits2 != InsConstants.BlankLimitVal;
        case CoverageType.UIMPD: return Policy.Cars[aCarIndex].UIMPDLimit != InsConstants.BlankLimitVal;
        case CoverageType.SUM: return Policy.Cars[aCarIndex].SUMLimits1 != InsConstants.BlankLimitVal || Policy.Cars[aCarIndex].SUMLimits2 != InsConstants.BlankLimitVal;
        case CoverageType.MedPay: return Policy.Cars[aCarIndex].MedPayDed != InsConstants.BlankLimitVal || Policy.Cars[aCarIndex].MedPayLimit != InsConstants.BlankLimitVal;
        case CoverageType.ExtraMed: return Policy.Cars[aCarIndex].ExtraMedLimit != InsConstants.BlankLimitVal;
        case CoverageType.PPI: return Policy.Cars[aCarIndex].PPILimit != InsConstants.BlankLimitVal;
        case CoverageType.PIP: return Policy.Cars[aCarIndex].PIPDed != InsConstants.BlankLimitVal || Policy.Cars[aCarIndex].PIPLimit != InsConstants.BlankLimitVal;
        case CoverageType.GuestPIP: return Policy.Cars[aCarIndex].GuestPIP;
        case CoverageType.BuyBackPIP: return Policy.Cars[aCarIndex].BuyBackPIP;
        case CoverageType.OutStatePIP: return Policy.Cars[aCarIndex].OutStatePIP;
        case CoverageType.FullAddtlPIP: return Policy.Cars[aCarIndex].FullAddtlPIP;
        case CoverageType.IncLoss: return Policy.Cars[aCarIndex].IncomeLossLimit != InsConstants.BlankLimitVal;
        case CoverageType.AccDeath: return Policy.Cars[aCarIndex].AccDeathLimit != InsConstants.BlankLimitVal;
        case CoverageType.CombFirstParty: return Policy.Cars[aCarIndex].CombineBenLimit != InsConstants.BlankLimitVal;
        case CoverageType.Funeral: return Policy.Cars[aCarIndex].FuneralLimit != InsConstants.BlankLimitVal;
        case CoverageType.OBEL: return Policy.Cars[aCarIndex].OBELLimit != InsConstants.BlankLimitVal;
        case CoverageType.Medicare: return Policy.Cars[aCarIndex].Medicare;
        case CoverageType.MedExpense: return !String.IsNullOrEmpty(Policy.Cars[aCarIndex].MedExpense);
        case CoverageType.WorkLoss: return Policy.Cars[aCarIndex].WorkLoss;
        case CoverageType.Mexico: return Policy.Cars[aCarIndex].MexicoCoverage;
        case CoverageType.Equipment: return false;  // Returns false because no such property exists.
        case CoverageType.WaivedPIP: return Policy.Cars[aCarIndex].WaivedPIP;
        case CoverageType.Gap: return Policy.Cars[aCarIndex].GapCoverage;
        case CoverageType.FullGlass: return Policy.Cars[aCarIndex].FullGlass;
        case CoverageType.TripInterruption: return Policy.Cars[aCarIndex].TripInterruptionLimit != InsConstants.BlankLimitVal;
        case CoverageType.ReplacementCost: return Policy.Cars[aCarIndex].ReplacementCost;
        case CoverageType.TransportTrailer: return Policy.Cars[aCarIndex].TransportTrailer;
        case CoverageType.Tort: return Policy.Cars[aCarIndex].Tort;
        case CoverageType.LimitedColl: return Policy.Cars[aCarIndex].LimitedColl;
        case CoverageType.OptionalBI: return Policy.Cars[aCarIndex].OptionalBILimit1 != InsConstants.BlankLimitVal && Policy.Cars[aCarIndex].OptionalBILimit2 != InsConstants.BlankLimitVal;
        case CoverageType.LegalExpense: return Policy.Cars[aCarIndex].LegalExpense;
        case CoverageType.MedicalExpenseOnly: return Policy.Cars[aCarIndex].MedicalExpenseOnly;
        case CoverageType.ExtendedMedical: return Policy.Cars[aCarIndex].ExtendedMedicalLimit != InsConstants.BlankLimitVal;
        default: return false;
      }
    }

    /// <summary>
    /// Determines whether a vehicle's coverage boolean property is on or not.  
    /// This method does NOT take premiums into account NOR dependent coverages.
    /// </summary>
    /// <param name="aCoverage">The requested rated coverage.</param>
    /// <param name="aCarIndex">The vehicle number</param>
    /// <returns>Returns True or False based on the value of the car coverage boolean property.
    /// If there is no boolean property to represent this coverage, it also returns false.</returns>
    public virtual bool CarCoverageBooleanPropertyOn(CoverageType aCoverage, int aCarIndex)
    {
      switch (aCoverage)
      {
        case CoverageType.Liab: return Policy.Cars[aCarIndex].Liab;
        case CoverageType.LiabBI: return Policy.Cars[aCarIndex].LiabBI;
        case CoverageType.LiabPD: return Policy.Cars[aCarIndex].LiabPD;
        case CoverageType.LimitedLiabPD: return Policy.Cars[aCarIndex].LimitedLiabPD;
        case CoverageType.Comp: return Policy.Cars[aCarIndex].Comp;
        case CoverageType.Coll: return Policy.Cars[aCarIndex].Coll;
        case CoverageType.LienHolder: return false;  // Returns false because no such property exists.
        case CoverageType.Rental: return Policy.Cars[aCarIndex].Rental;
        case CoverageType.Towing: return Policy.Cars[aCarIndex].Towing;
        case CoverageType.Unins: return false;  // Returns false because no such property exists.
        case CoverageType.UninsBI: return Policy.Cars[aCarIndex].UninsBI;
        case CoverageType.UninsPD: return Policy.Cars[aCarIndex].UninsPD;
        case CoverageType.UIM: return false;  // Returns false because no such property exists.
        case CoverageType.UIMBI: return Policy.Cars[aCarIndex].UIMBI;
        case CoverageType.UIMPD: return Policy.Cars[aCarIndex].UIMPD;
        case CoverageType.SUM: return Policy.Cars[aCarIndex].SUM;
        case CoverageType.MedPay: return Policy.Cars[aCarIndex].MedPay;
        case CoverageType.ExtraMed: return Policy.Cars[aCarIndex].ExtraMed;
        case CoverageType.PPI: return Policy.Cars[aCarIndex].PPI;
        case CoverageType.PIP: return Policy.Cars[aCarIndex].PIP;
        case CoverageType.GuestPIP: return Policy.Cars[aCarIndex].GuestPIP;
        case CoverageType.BuyBackPIP: return Policy.Cars[aCarIndex].BuyBackPIP;
        case CoverageType.OutStatePIP: return Policy.Cars[aCarIndex].OutStatePIP;
        case CoverageType.FullAddtlPIP: return Policy.Cars[aCarIndex].FullAddtlPIP;
        case CoverageType.IncLoss: return Policy.Cars[aCarIndex].IncomeLoss;
        case CoverageType.AccDeath: return Policy.Cars[aCarIndex].AccDeath;
        case CoverageType.CombFirstParty: return Policy.Cars[aCarIndex].CombineBen;
        case CoverageType.Funeral: return Policy.Cars[aCarIndex].Funeral;
        case CoverageType.OBEL: return Policy.Cars[aCarIndex].OBEL;
        case CoverageType.Medicare: return Policy.Cars[aCarIndex].Medicare;
        case CoverageType.MedExpense: return !String.IsNullOrEmpty(Policy.Cars[aCarIndex].MedExpense);
        case CoverageType.WorkLoss: return Policy.Cars[aCarIndex].WorkLoss;
        case CoverageType.Mexico: return Policy.Cars[aCarIndex].MexicoCoverage;
        case CoverageType.Equipment: return false;  // Returns false because no such property exists.
        case CoverageType.WaivedPIP: return Policy.Cars[aCarIndex].WaivedPIP;
        case CoverageType.Gap: return Policy.Cars[aCarIndex].GapCoverage;
        case CoverageType.FullGlass: return Policy.Cars[aCarIndex].FullGlass;
        case CoverageType.TripInterruption: return Policy.Cars[aCarIndex].TripInterruption;
        case CoverageType.ReplacementCost: return Policy.Cars[aCarIndex].ReplacementCost;
        case CoverageType.TransportTrailer: return Policy.Cars[aCarIndex].TransportTrailer;
        case CoverageType.Tort: return Policy.Cars[aCarIndex].Tort;
        case CoverageType.LimitedColl: return Policy.Cars[aCarIndex].LimitedColl;
        case CoverageType.OptionalBI: return Policy.Cars[aCarIndex].OptionalBI;
        case CoverageType.LegalExpense: return Policy.Cars[aCarIndex].LegalExpense;
        case CoverageType.MedicalExpenseOnly: return Policy.Cars[aCarIndex].MedicalExpenseOnly;
        case CoverageType.ExtendedMedical: return Policy.Cars[aCarIndex].ExtendedMedical;
        default: return false;
      }
    }

    /// <summary>
    /// Determines whether any vehicle's coverage boolean property is on or not.  
    /// This method does NOT take premiums into account NOR dependent coverages.
    /// </summary>
    /// <param name="aCoverage">The requested rated coverage.</param>
    /// <returns>Returns True or False based on the value of the car coverage boolean property.
    /// If there is no boolean property to represent this coverage, it also returns false.</returns>
    public virtual bool AnyCarCoverageBooleanPropertyOn(CoverageType aCoverage)
    {
      bool result = false;
      for (int carIndex = 0; carIndex < Policy.NumOfCars; carIndex++)
        if (CarCoverageBooleanPropertyOn(aCoverage, carIndex))
          result = true;
      return result;
    }

    /// <summary>
    /// determines whether a vehicle's coverage is on or not.
    /// </summary>
    /// <param name="aCoverage">The requested rated coverage.</param>
    /// <param name="aCarIndex">The vehicle number</param>
    /// <returns>returns True or False based on the car coverage being turned on</returns>
    public virtual bool CarCoverageOn(CoverageType aCoverage, int aCarIndex)
    {
      switch (aCoverage)
      {
        //case CoverageType.Liab: return Policy.Cars[aCarIndex].Liab;
        case CoverageType.Liab: return false;
        case CoverageType.LiabBI: return (Policy.Cars[aCarIndex].LiabBI && (Policy.Cars[aCarIndex].LiabBIPremium > 0));
        case CoverageType.LiabPD: return (Policy.Cars[aCarIndex].LiabPD && (Policy.Cars[aCarIndex].LiabPDPremium > 0));
        case CoverageType.LimitedLiabPD: return (Policy.Cars[aCarIndex].LimitedLiabPD && (Policy.Cars[aCarIndex].LimitedLiabPDPremium > 0));
        case CoverageType.Comp: return (Policy.Cars[aCarIndex].Comp && (Policy.Cars[aCarIndex].CompPremium > 0));
        case CoverageType.Coll: return (Policy.Cars[aCarIndex].Coll && (Policy.Cars[aCarIndex].CollPremium > 0));
        case CoverageType.LienHolder: return false;  //policy.Cars[aCarIndex].LienHolderType
        case CoverageType.Rental: return ((Policy.Cars[aCarIndex].Rental && (Policy.Cars[aCarIndex].RentalPremium > 0)) || (Policy.Cars[aCarIndex].RentalPremium == InsConstants.IncludedPremium));
        case CoverageType.Towing: return ((Policy.Cars[aCarIndex].Towing && (Policy.Cars[aCarIndex].TowingPremium > 0)) || (Policy.Cars[aCarIndex].TowingPremium == InsConstants.IncludedPremium));
        //case CoverageType.Unins: return (Policy.Cars[aCarIndex].UninsBI || Policy.Cars[aCarIndex].UninsPD);
        case CoverageType.Unins: return false;
        case CoverageType.UninsBI: return (Policy.Cars[aCarIndex].UninsBI && (Policy.Cars[aCarIndex].UninsBIPremium > 0));
        case CoverageType.UninsPD: return (Policy.Cars[aCarIndex].UninsPD && (Policy.Cars[aCarIndex].UninsPDPremium > 0));
        case CoverageType.UIM: return (Policy.Cars[aCarIndex].UIMBI || Policy.Cars[aCarIndex].UIMPD || (Policy.Cars[aCarIndex].UIMBIPremium == InsConstants.IncludedPremium) ||
          (Policy.Cars[aCarIndex].UIMPDPremium == InsConstants.IncludedPremium));
        case CoverageType.UIMBI: return ((Policy.Cars[aCarIndex].UIMBI || (Policy.Cars[aCarIndex].UIMBIPremium > 0)) || (Policy.Cars[aCarIndex].UIMBIPremium == InsConstants.IncludedPremium));
        case CoverageType.UIMPD: return ((Policy.Cars[aCarIndex].UIMPD && (Policy.Cars[aCarIndex].UIMPDPremium > 0)) || (Policy.Cars[aCarIndex].UIMPDPremium == InsConstants.IncludedPremium));
        case CoverageType.SUM: return (Policy.Cars[aCarIndex].SUM && (Policy.Cars[aCarIndex].SUMPremium > 0));
        case CoverageType.MedPay: return (Policy.Cars[aCarIndex].MedPay && (Policy.Cars[aCarIndex].MedPayPremium > 0));
        case CoverageType.ExtraMed: return (Policy.Cars[aCarIndex].ExtraMed && (Policy.Cars[aCarIndex].ExtraMedPremium > 0));
        case CoverageType.PPI: return (Policy.Cars[aCarIndex].PPI && (Policy.Cars[aCarIndex].PPIPremium > 0));
        case CoverageType.PIP: return (Policy.Cars[aCarIndex].PIP && (Policy.Cars[aCarIndex].PIPPremium > 0));
        case CoverageType.GuestPIP: return (Policy.Cars[aCarIndex].GuestPIP && (Policy.Cars[aCarIndex].PIPPremium > 0));
        case CoverageType.BuyBackPIP: return (Policy.Cars[aCarIndex].BuyBackPIP && (Policy.Cars[aCarIndex].PIPPremium > 0));
        case CoverageType.OutStatePIP: return (Policy.Cars[aCarIndex].OutStatePIP && (Policy.Cars[aCarIndex].PIPPremium > 0));
        case CoverageType.FullAddtlPIP: return (Policy.Cars[aCarIndex].FullAddtlPIP && (Policy.Cars[aCarIndex].PIPPremium > 0));
        case CoverageType.IncLoss: return ((Policy.Cars[aCarIndex].IncomeLoss && (Policy.Cars[aCarIndex].IncomeLossPremium > 0)) || (Policy.Cars[aCarIndex].IncomeLossPremium == InsConstants.IncludedPremium));
        case CoverageType.AccDeath: return (Policy.Cars[aCarIndex].AccDeath && (Policy.Cars[aCarIndex].AccDeathPremium > 0));
        case CoverageType.CombFirstParty: return (Policy.Cars[aCarIndex].CombineBen && (Policy.Cars[aCarIndex].CombineBenPremium > 0));
        case CoverageType.Funeral: return (Policy.Cars[aCarIndex].Funeral && (Policy.Cars[aCarIndex].FuneralPremium > 0));
        case CoverageType.OBEL: return (Policy.Cars[aCarIndex].OBEL && (Policy.Cars[aCarIndex].OBELPremium > 0));
        case CoverageType.Medicare: return (Policy.Cars[aCarIndex].Medicare);
        case CoverageType.MedExpense: return ((!String.IsNullOrEmpty(Policy.Cars[aCarIndex].MedExpense)) && (Policy.Cars[aCarIndex].MedPayPremium > 0));
        case CoverageType.WorkLoss: return (Policy.Cars[aCarIndex].WorkLoss);
        case CoverageType.Mexico: return (Policy.Cars[aCarIndex].MexicoCoverage && (Policy.Cars[aCarIndex].MexicoPremium > 0));
        case CoverageType.Equipment: return ((Policy.Cars[aCarIndex].CustomEquipValue > 0) && (Policy.Cars[aCarIndex].CustomEquipPremium > 0));
        case CoverageType.WaivedPIP: return (Policy.Cars[aCarIndex].WaivedPIP && (Policy.Cars[aCarIndex].PIPPremium > 0));
        case CoverageType.Gap: return (Policy.Cars[aCarIndex].GapCoverage && (Policy.Cars[aCarIndex].GapPremium > 0));
        case CoverageType.FullGlass: return (Policy.Cars[aCarIndex].FullGlass && Policy.Cars[aCarIndex].Comp);
        case CoverageType.TripInterruption: return (Policy.Cars[aCarIndex].TripInterruption && (Policy.Cars[aCarIndex].TripInterruptionPremium > 0));
        case CoverageType.ReplacementCost: return (Policy.Cars[aCarIndex].ReplacementCost && (Policy.Cars[aCarIndex].ReplacementCostPremium > 0));
        case CoverageType.TransportTrailer: return (Policy.Cars[aCarIndex].TransportTrailer && (Policy.Cars[aCarIndex].TransportTrailerPremium > 0));
        case CoverageType.Tort: return Policy.Cars[aCarIndex].Tort && (Policy.Cars[aCarIndex].TortPremium > 0);
        case CoverageType.OptionalBI: return (Policy.Cars[aCarIndex].OptionalBI && (Policy.Cars[aCarIndex].OptionalBIPremium > 0));
        case CoverageType.LegalExpense: return (Policy.Cars[aCarIndex].LegalExpense && Policy.Cars[aCarIndex].LegalExpensePremium > 0);
        case CoverageType.MedicalExpenseOnly: return (Policy.Cars[aCarIndex].MedicalExpenseOnly && Policy.Cars[aCarIndex].MedicalExpenseOnlyPremium > 0);
        case CoverageType.ExtendedMedical: return (Policy.Cars[aCarIndex].ExtendedMedical && Policy.Cars[aCarIndex].ExtendedMedicalPremium > 0);
        case CoverageType.SpousalLiability: return (Policy.Cars[aCarIndex].SpousalLiability && Policy.Cars[aCarIndex].SpousalLiabilityPremium > 0);
        case CoverageType.PIPAttendantCareOption: return (Policy.Cars[aCarIndex].PIPAttendantCareOption && Policy.Cars[aCarIndex].PipAttendantCareOptionPremium > 0);
        default: return false;
      }
    }

    /// <summary>
    /// return the limit/deductible for the requested vehicle coverage.
    /// </summary>
    /// <param name="aCoverage">The requested rated coverage.</param>
    /// <param name="aCarIndex">The vehicle number</param>
    /// <returns>returns the limit/deductible based on the requested coverage</returns>
    public virtual string GetCarLimitDeductibleString(CoverageType aCoverage, int aCarIndex)
    {
      switch (aCoverage)
      {
        case CoverageType.Liab:
          {
            if (Policy.Cars[aCarIndex].CoLiabLimits2 < 0)
              return Policy.Cars[aCarIndex].CoLiabLimits1.ToString() + " CSL";
            else
              return Policy.Cars[aCarIndex].CoLiabLimits1.ToString() + "/" + Policy.Cars[aCarIndex].CoLiabLimits2.ToString() + "/" + Policy.Cars[aCarIndex].CoLiabLimits3.ToString();
          }
        case CoverageType.LiabBI:
          {
            if (Policy.Cars[aCarIndex].CoLiabLimits2 < 0)
              return Policy.Cars[aCarIndex].CoLiabLimits1.ToString() + " CSL";
            else
              return Policy.Cars[aCarIndex].CoLiabLimits1.ToString() + "/" + Policy.Cars[aCarIndex].CoLiabLimits2.ToString();
          }
        case CoverageType.LiabPD: return Policy.Cars[aCarIndex].CoLiabLimits3.ToString();
        case CoverageType.LimitedLiabPD: return Policy.Cars[aCarIndex].CoLimitedLiabPDLimit.ToString();
        case CoverageType.Comp: return Policy.Cars[aCarIndex].CoCompDed.ToString();  // car based
        case CoverageType.Coll: return Policy.Cars[aCarIndex].CoCollDed.ToString();  // car based
        case CoverageType.LienHolder: return "";  //policy.Cars[aCarIndex].LienHolderType
        case CoverageType.Rental: return Policy.Cars[aCarIndex].CoRentalLimit.ToString();  // car based
        case CoverageType.Towing: return Policy.Cars[aCarIndex].CoTowingLimit.ToString();  // car based
        case CoverageType.Unins:
          {
            if (Policy.Cars[aCarIndex].CoUninsBILimits2 < 0)
              return Policy.Cars[aCarIndex].CoUninsBILimits1.ToString() + " CSL";
            else
              return Policy.Cars[aCarIndex].CoUninsBILimits1.ToString() + "/" + Policy.Cars[aCarIndex].CoUninsBILimits2.ToString() + "/" + Policy.Cars[aCarIndex].CoUninsPDLimit.ToString();
          }
        case CoverageType.UninsBI:
          {
            if (Policy.Cars[aCarIndex].CoUninsBILimits2 < 0)
              return Policy.Cars[aCarIndex].CoUninsBILimits1.ToString() + " CSL";
            else
              return Policy.Cars[aCarIndex].CoUninsBILimits1.ToString() + "/" + Policy.Cars[aCarIndex].CoUninsBILimits2.ToString();
          }
        case CoverageType.UninsPD: return Policy.Cars[aCarIndex].CoUninsPDLimit.ToString();
        case CoverageType.UIM: return Policy.Cars[aCarIndex].CoUIMBILimits1.ToString() + "/" + Policy.Cars[aCarIndex].CoUIMBILimits2.ToString() + "/" + Policy.Cars[aCarIndex].CoUIMPDLimit.ToString();
        case CoverageType.UIMBI:
          {
            if (Policy.Cars[aCarIndex].CoUIMBILimits2 < 0)
              return Policy.Cars[aCarIndex].CoUIMBILimits1.ToString() + " CSL";
            else
              return Policy.Cars[aCarIndex].CoUIMBILimits1.ToString() + "/" + Policy.Cars[aCarIndex].CoUIMBILimits2.ToString();
          }
        case CoverageType.UIMPD: return Policy.Cars[aCarIndex].CoUIMPDLimit.ToString();
        case CoverageType.SUM: return Policy.Cars[aCarIndex].CoSUMLimits1.ToString() + "/" + Policy.Cars[aCarIndex].CoSUMLimits2.ToString();
        case CoverageType.MedPay: return Policy.Cars[aCarIndex].CoMedPayLimit.ToString();
        case CoverageType.ExtraMed: return Policy.Cars[aCarIndex].CoExtraMedLimit.ToString();
        case CoverageType.PPI: return Policy.Cars[aCarIndex].CoPPILimit.ToString();
        case CoverageType.PIP: return Policy.Cars[aCarIndex].CoPIPLimit.ToString();
        case CoverageType.GuestPIP: return Policy.Cars[aCarIndex].CoPIPLimit.ToString();
        case CoverageType.BuyBackPIP: return Policy.Cars[aCarIndex].CoPIPLimit.ToString();
        case CoverageType.OutStatePIP: return Policy.Cars[aCarIndex].CoPIPLimit.ToString();
        case CoverageType.FullAddtlPIP: return Policy.Cars[aCarIndex].AddtlPIPLimit1.ToString();
        case CoverageType.IncLoss:
          {
            if (Policy.Cars[aCarIndex].CoIncomeLossLimit2 != InsConstants.BlankLimitVal)
              return Policy.Cars[aCarIndex].CoIncomeLossLimit.ToString() + "/" + Policy.Cars[aCarIndex].CoIncomeLossLimit2.ToString();
            else
              return Policy.Cars[aCarIndex].CoIncomeLossLimit.ToString();
          }
        case CoverageType.AccDeath: return Policy.Cars[aCarIndex].CoAccDeathLimit.ToString();
        case CoverageType.CombFirstParty: return Policy.Cars[aCarIndex].CoCombineBenLimit.ToString();
        case CoverageType.Funeral: return Policy.Cars[aCarIndex].CoFuneralLimit.ToString();
        case CoverageType.OBEL: return Policy.Cars[aCarIndex].CoOBELLimit.ToString();
        case CoverageType.Medicare: return Policy.Cars[aCarIndex].Medicare.ToString();
        case CoverageType.MedExpense: return Policy.Cars[aCarIndex].MedExpense.Trim();
        case CoverageType.WorkLoss: return Policy.Cars[aCarIndex].CoWorkLoss.ToString();
        case CoverageType.Mexico: return Policy.Cars[aCarIndex].MexicoCoverage.ToString();
        case CoverageType.Equipment: return Policy.Cars[aCarIndex].CoCustomEquipValue.ToString();
        case CoverageType.WaivedPIP: return Policy.Cars[aCarIndex].CoPIPLimit.ToString();
        case CoverageType.Gap: return "";
        case CoverageType.FullGlass: return "";
        case CoverageType.TripInterruption: return Policy.Cars[aCarIndex].CoTripInterruptionLimit.ToString();
        case CoverageType.ReplacementCost: return "";
        case CoverageType.TransportTrailer: return Policy.Cars[aCarIndex].CoTransportTrailerValue.ToString();
        case CoverageType.Tort: return Policy.Cars[aCarIndex].CoTortLimit.ToString();
        case CoverageType.LimitedColl: return Policy.Cars[aCarIndex].CoLimitedCollDed.ToString();
        case CoverageType.OptionalBI:
          {
            if (Policy.Cars[aCarIndex].CoOptionalBILimit2 < 0)
              return Policy.Cars[aCarIndex].CoOptionalBILimit1.ToString() + " CSL";
            else
              return Policy.Cars[aCarIndex].CoOptionalBILimit1.ToString() + "/" + Policy.Cars[aCarIndex].CoOptionalBILimit2.ToString();
          }
        case CoverageType.LegalExpense: return "";
        case CoverageType.MedicalExpenseOnly: return "";
        case CoverageType.ExtendedMedical: return Policy.Cars[aCarIndex].CoExtendedMedicalLimit.ToString();
        case CoverageType.SpousalLiability: return "";
        case CoverageType.PIPAttendantCareOption: return Policy.Cars[aCarIndex].CoPIPAttendantCareOptionLimit.ToString();
        default: return "None";
      }
    }

    /// <summary>
    /// is there prior insurance on the policy?
    /// </summary>
    /// <returns>true or false based on prior insurance on policy</returns>
    public virtual bool AnyPriorInsuranceOnPolicy()
    {
      bool result = false;
      for (int drvIndex = 0; drvIndex < Policy.NumOfDrivers; drvIndex++)
        if (Policy.Drivers[drvIndex].PriorInsurance)
          result = true;
      return result;
    }

    /// <summary>
    /// returns true or false based on if any car has the requested coverage
    /// </summary>
    /// <param name="aCoverage">The requested rated coverage.</param>
    /// <returns>true or false based on if any car has the requested coverage</returns>
    public virtual bool AnyCarCoverageOn(CoverageType aCoverage)
    {
      bool result = false;
      for (int carIndex = 0; carIndex < Policy.NumOfCars; carIndex++)
        if (CarCoverageOn(aCoverage, carIndex))
          result = true;
      return result;
    }

    /// <summary>
    /// returns 0 or the requested premium for the car in question.
    /// </summary>
    /// <param name="aCoverage">The requested rated coverage.</param>
    /// <param name="aCarIndex">The vehicle number</param>
    /// <returns>the premium for the requested coverage</returns>
    public virtual double CarCoveragePremium(CoverageType aCoverage, int aCarIndex)
    {
      switch (aCoverage)
      {
        case CoverageType.Liab: return Policy.Cars[aCarIndex].LiabBIPremium + Policy.Cars[aCarIndex].LiabPDPremium;
        case CoverageType.LiabBI: return Policy.Cars[aCarIndex].LiabBIPremium;
        case CoverageType.LiabPD: return Policy.Cars[aCarIndex].LiabPDPremium;
        case CoverageType.LimitedLiabPD: return Policy.Cars[aCarIndex].LimitedLiabPDPremium;
        case CoverageType.Comp: return Policy.Cars[aCarIndex].CompPremium;
        case CoverageType.Coll: return Policy.Cars[aCarIndex].CollPremium;
        case CoverageType.LienHolder: return Policy.Cars[aCarIndex].LienHolderPremium;
        case CoverageType.Rental: return Policy.Cars[aCarIndex].RentalPremium;
        case CoverageType.Towing: return Policy.Cars[aCarIndex].TowingPremium;
        case CoverageType.Unins: return Policy.Cars[aCarIndex].UninsBIPremium + Policy.Cars[aCarIndex].UninsPDPremium;
        case CoverageType.UninsBI: return Policy.Cars[aCarIndex].UninsBIPremium;
        case CoverageType.UninsPD: return Policy.Cars[aCarIndex].UninsPDPremium;
        case CoverageType.UIM: return Policy.Cars[aCarIndex].UIMBIPremium + Policy.Cars[aCarIndex].UIMPDPremium;
        case CoverageType.UIMBI: return Policy.Cars[aCarIndex].UIMBIPremium;
        case CoverageType.UIMPD: return Policy.Cars[aCarIndex].UIMPDPremium;
        case CoverageType.SUM: return Policy.Cars[aCarIndex].SUMPremium;
        case CoverageType.MedPay: return Policy.Cars[aCarIndex].MedPayPremium;
        case CoverageType.ExtraMed: return Policy.Cars[aCarIndex].ExtraMedPremium;
        case CoverageType.PPI: return Policy.Cars[aCarIndex].PPIPremium;
        case CoverageType.PIP: return Policy.Cars[aCarIndex].PIPPremium;
        case CoverageType.GuestPIP: return Policy.Cars[aCarIndex].PIPPremium;
        case CoverageType.BuyBackPIP: return Policy.Cars[aCarIndex].PIPPremium;
        case CoverageType.OutStatePIP: return Policy.Cars[aCarIndex].OutStatePIPPremium;
        case CoverageType.FullAddtlPIP: return Policy.Cars[aCarIndex].AddtlPIPPremium;
        case CoverageType.IncLoss: return Policy.Cars[aCarIndex].IncomeLossPremium;
        case CoverageType.AccDeath: return Policy.Cars[aCarIndex].AccDeathPremium;
        case CoverageType.CombFirstParty: return Policy.Cars[aCarIndex].CombineBenPremium;
        case CoverageType.Funeral: return Policy.Cars[aCarIndex].FuneralPremium;
        case CoverageType.OBEL: return Policy.Cars[aCarIndex].OBELPremium;
        case CoverageType.Medicare: return Policy.Cars[aCarIndex].MedPayPremium;  // Medicare?
        case CoverageType.MedExpense: return Policy.Cars[aCarIndex].MedPayPremium;  // MedExpense?
        case CoverageType.WorkLoss: return Policy.Cars[aCarIndex].MedPayPremium;  // WorkLoss?
        case CoverageType.Mexico: return Policy.Cars[aCarIndex].MexicoPremium;
        case CoverageType.Equipment: return Policy.Cars[aCarIndex].CustomEquipPremium;
        case CoverageType.WaivedPIP: return Policy.Cars[aCarIndex].PIPPremium;
        case CoverageType.Gap: return Policy.Cars[aCarIndex].GapPremium;
        case CoverageType.FullGlass: return Policy.Cars[aCarIndex].FullGlassPremium;
        case CoverageType.TripInterruption: return Policy.Cars[aCarIndex].TripInterruptionPremium;
        case CoverageType.ReplacementCost: return Policy.Cars[aCarIndex].ReplacementCostPremium;
        case CoverageType.TransportTrailer: return Policy.Cars[aCarIndex].TransportTrailerPremium;
        case CoverageType.Tort: return Policy.Cars[aCarIndex].TortPremium;
        case CoverageType.OptionalBI: return Policy.Cars[aCarIndex].OptionalBIPremium;
        case CoverageType.LegalExpense: return Policy.Cars[aCarIndex].LegalExpensePremium;
        case CoverageType.MedicalExpenseOnly: return Policy.Cars[aCarIndex].MedicalExpenseOnlyPremium;
        case CoverageType.ExtendedMedical: return Policy.Cars[aCarIndex].ExtendedMedicalPremium;
        case CoverageType.SpousalLiability: return Policy.Cars[aCarIndex].SpousalLiabilityPremium;
        case CoverageType.PIPAttendantCareOption: return Policy.Cars[aCarIndex].PipAttendantCareOptionPremium;
        default: return 0;
      }
    }

    /// <summary>
    /// does any driver on the policy has a learners permit?
    /// </summary>
    /// <returns>returns true if a driver on the policy has a learners permit, false otherwise</returns>
    public virtual bool AnyDriverWithLearnersPermit()
    {
      foreach (AUDriver driver in Policy.Drivers)
        if (driver.LearnersPermit)
          return true;
      return false;
    }

    /// <summary>
    /// does any driver on the policy has a suspended license?
    /// </summary>
    /// <returns>returns true if a driver on the policy has a suspended license, false otherwise</returns>
    public virtual bool AnyDriverWithSuspendedLic()
    {
      foreach (AUDriver driver in Policy.Drivers)
        if (driver.SuspendedLic)
          return true;
      return false;
    }

    /// <summary>
    /// Does any driver on the policy have either a suspended or expired license?
    /// </summary>
    /// <returns>Returns true if a driver on the policy has either a suspended or expired license; false otherwise</returns>
    public virtual bool AnyDriverWithSuspendedExpiredLic()
    {
      foreach (AUDriver driver in Policy.Drivers)
        if (driver.SuspendedLic || driver.ExpiredLicense)
          return true;
      return false;
    }

    /// <summary>
    /// is any driver on the policy a single parent?
    /// </summary>
    /// <returns>returns true if a driver on the policy is a single parent, false otherwise</returns>
    public virtual bool AnySingleParentOnPolicy()
    {
      foreach (AUDriver driver in Policy.Drivers)
        if (driver.SingleParent)
          return true;
      return false;
    }

    /// <summary>
    /// Is any driver on the policy in a civil union
    /// </summary>
    /// <returns>returns true if a driver is in a civil union; false otherwise</returns>
    public virtual bool AnyCivilUnionOnPolicy()
    {
      foreach (AUDriver driver in Policy.Drivers)
        if (driver.CivilUnion)
          return true;
      return false;
    }

    /// <summary>
    /// does any driver on the policy qualify for a senior discount?
    /// </summary>
    /// <returns>returns true if a driver on the policy qualifies for a senior discount, false otherwise</returns>
    public virtual bool AnyDriverWithSeniorDisc()
    {
      foreach (AUDriver driver in Policy.Drivers)
        if (driver.SeniorDrvDisc)
          return true;
      return false;
    }

    /// <summary>
    /// is any driver on the policy in the military?
    /// </summary>
    /// <returns>returns true if a driver on the policy is in the military, false otherwise</returns>
    public virtual bool AnyDriverWithMilitary()
    {
      foreach (AUDriver driver in Policy.Drivers)
        if (driver.Employed == "M")
          return true;
      return false;
    }

    /// <summary>
    /// does any driver on the policy have property insurance?
    /// </summary>
    /// <returns>returns true if a driver on the policy has property insurance, false otherwise</returns>
    public virtual bool AnyDriverWithPropertyInsurance()
    {
      foreach (AUDriver driver in Policy.Drivers)
        if (driver.PropertyInsurance)
          return true;
      return false;
    }

    /// <summary>
    /// does any driver on the policy have a foreign license?
    /// </summary>
    /// <returns>returns true if a driver on the policy has a foreign license, false otherwise</returns>
    public virtual bool AnyDriverWithForeignLicense()
    {
      foreach (AUDriver driver in Policy.Drivers)
        if (driver.CountryOfOrigin != CountryOfOrigin.None)
          return true;
      return false;
    }

    /// <summary>
    /// Checks the number of drivers on a policy having an SR22. 
    /// </summary>
    /// <returns>Returns the number of drivers on a policy having an SR22.</returns>
    public virtual int NumberOfDriversWithSR22()
    {
      int driverCount = 0;

      foreach (AUDriver driver in Policy.Drivers)
      {
        if (driver.SR22)
          driverCount++;
      }

      return driverCount;
    }

    /// <summary>
    /// Checks the number of drivers on a policy having an SR22A. 
    /// </summary>
    /// <returns>Returns the number of drivers on a policy having an SR22A.</returns>
    public virtual int NumberOfDriversWithSR22A()
    {
      int driverCount = 0;

      foreach (AUDriver driver in Policy.Drivers)
      {
        if (driver.SR22A)
          driverCount++;
      }

      return driverCount;
    }

    /// <summary>
    /// Checks if any driver on the policy has an SR-22
    /// </summary>
    /// <returns>True if any driver on the policy has an SR-22; false otherwise</returns>
    public virtual bool AnyDriverWithSR22()
    {
      foreach (AUDriver driver in Policy.Drivers)
        if (driver.SR22)
          return true;
      return false;
    }

    /// <summary>
    /// Checks if any driver on the policy has an SR-22A
    /// </summary>
    /// <returns>True if any driver on the policy has an SR-22A; false otherwise</returns>
    public virtual bool AnyDriverWithSR22A()
    {
      foreach (AUDriver driver in Policy.Drivers)
        if (driver.SR22A)
          return true;
      return false;
    }

    /// <summary>
    /// Checks if any driver on the policy has an SR-1P
    /// </summary>
    /// <returns>True if any driver on the policy has an SR-1P; false otherwise</returns>
    public virtual bool AnyDriverWithSR1P()
    {
      foreach (AUDriver driver in Policy.Drivers)
        if (driver.SR1P)
          return true;
      return false;
    }

    /// <summary>
    /// Checks if any driver on the policy has an FR44
    /// </summary>
    /// <returns>True if any driver on the policy has an FR44; false otherwise</returns>
    public virtual bool AnyDriverWithFR44()
    {
      foreach (AUDriver driver in Policy.Drivers)
        if (driver.FR44)
          return true;
      return false;
    }

    /// <summary>
    /// Returns the first driver with a relation of "Spouse" or null if none found.
    /// </summary>
    public AUDriver SpouseDriver
    {
      get
      {
        foreach (AUDriver driver in Policy.Drivers)
          if (driver.Relation == AUConstants.RelationChar[(int)Relation.Spouse].ToString())
            return driver;
        foreach (AUDriver exclusion in Policy.Exclusions)
          if (exclusion.Relation == AUConstants.RelationChar[(int)Relation.Spouse].ToString())
            return exclusion;
        return null;
      }
    }

    /// <summary>
    /// Returns the driver object whose relation is Insured
    /// </summary>
    /// <returns>The insured driver</returns>
    public AUDriver GetInsuredDriver()
    {
      foreach (AUDriver driver in Policy.Drivers)
        if (driver.Relation == AUConstants.RelationChar[(int)Relation.Insured].ToString())
          return driver;
      return null;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="policy">The policy on which this AURateLib object will act</param>
    public AURateLib(AUPolicy policy)
    {
      Policy = policy;
    }

    private AUPolicy m_policy;
  }
}
