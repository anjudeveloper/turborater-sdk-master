using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurboRater.Insurance.AU;

namespace TurboRater.ApiClients.Imp
{
  /// <summary>
  /// A VIN lookup response from IMP.
  /// </summary>
  public class ImpVinResponse
  {
    /// <summary>
    /// The vehicle's anti-lock brake type.
    /// </summary>
    public string AntiLock { get; set; }

    /// <summary>
    /// The vehicle's body type.
    /// </summary>
    public string BodyType { get; set; }

    /// <summary>
    /// Is this vehicle turbo charged?
    /// </summary>
    public bool Turbo { get; set; }

    /// <summary>
    /// The fuel type of the vehicle.
    /// </summary>
    public string FuelType { get; set; }

    /// <summary>
    /// The vehicle's maker.
    /// </summary>
    public string Maker { get; set; }

    /// <summary>
    /// The vehicle's model.
    /// </summary>
    public string Model { get; set; }

    /// <summary>
    /// The model group code for the vehicle.
    /// </summary>
    public int ModelGroupCode { get; set; }

    /// <summary>
    /// The model code for the vehicle.
    /// </summary>
    public int ModelCode { get; set; }

    /// <summary>
    /// The type of passive seat restraint that this vehicle has.
    /// </summary>
    public string PassSeatRestraint { get; set; }

    /// <summary>
    /// The vehicle's type of air bags.
    /// </summary>
    public string AirBags { get; set; }

    /// <summary>
    /// The vehicle's anti-theft device type.
    /// </summary>
    public string AntiTheft { get; set; }

    /// <summary>
    /// Assuming the vehicle is a truck, this tells what size
    /// of truck it is. 1-ton, 1/2ton, etc.
    /// </summary>
    public string TruckSize { get; set; }

    /// <summary>
    /// Unique symbol code for this vehicle.
    /// </summary>
    public int UniqueSymCode { get; set; }

    /// <summary>
    /// The VIN of the vehicle.
    /// </summary>
    public string VIN { get; set; }

    /// <summary>
    /// The vehicle's year model.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Is this vehicle a convertible?
    /// </summary>
    public bool Convertible { get; set; }

    /// <summary>
    /// Is this vehicle a hatchback?
    /// </summary>
    public bool Hatchback { get; set; }

    /// <summary>
    /// Is this vehicle four wheel drive?
    /// </summary>
    public bool FourWheelDrive { get; set; }

    /// <summary>
    /// Is this vehicle front wheel drive?
    /// </summary>
    public bool FrontWD { get; set; }

    /// <summary>
    /// The vehicle's Manufacturer's Suggested Retail Price.
    /// </summary>
    public int MSRP { get; set; }

    /// <summary>
    /// Vehicle's number of cylinders.
    /// </summary>
    public int NumOfCyl { get; set; }

    /// <summary>
    /// Vehicle's number of doors.
    /// </summary>
    public int NumOfDoors { get; set; }

    /// <summary>
    /// The type of vehicle.
    /// </summary>
    public string VehicleType { get; set; }

    /// <summary>
    /// Initializes a new VinResponse object.
    /// </summary>
    public ImpVinResponse()
    {
    }

    /// <summary>
    /// Initializes a new VinResponse object using car data.
    /// </summary>
    /// <param name="car">The car to use to populate the VIN response.</param>
    public ImpVinResponse(AUCar car)
    {
      AntiLock = car.AntiLock ?? string.Empty;
      BodyType = car.BodyType ?? string.Empty;
      Turbo = car.Turbo;
      FuelType = car.FuelType ?? string.Empty;
      Maker = car.Maker ?? string.Empty;
      Model = car.Model ?? string.Empty;
      ModelCode = car.ModelCode;
      ModelGroupCode = car.ModelGroupCode;
      AirBags = car.AirBags ?? string.Empty;
      PassSeatRestraint = car.PassSeatRestraint ?? string.Empty;
      AntiTheft = car.AntiTheft ?? string.Empty;
      TruckSize = car.TruckSize ?? string.Empty;
      UniqueSymCode = car.UniqueSymCode;
      VIN = car.VIN ?? string.Empty;
      Year = car.Year;
      Convertible = car.Convertible;
      Hatchback = car.Hatchback;
      FrontWD = car.FrontWD;
      FourWheelDrive = car.FourWheelDrive;
      MSRP = car.MSRP;
      NumOfCyl = car.NumOfCyl;
      NumOfDoors = car.NumOfDoors;
      VehicleType = car.VehicleType;
    }
  }
}
