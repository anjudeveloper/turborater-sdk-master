using System.ComponentModel;

namespace TurboRater.Insurance.HO
{
  /// <summary>
  /// Homeowner usage type.
  /// </summary>
  public enum HOUsageType
  {
    Primary,
    Secondary
  }

  /// <summary>
  /// Type of construction of the property
  /// </summary>
  public enum Construction
  {
    Brick,
    BrickVeneer,
    Stucco,
    FireResistant,
    Frame,
    SemiWindResistive,
    WindResistive,
    Superior
  }

  /// <summary>
  /// Occupancy type for the dwelling
  /// </summary>
  public enum Occupancy
  {
    OwnerOccupied,
    TenantOccupied
  }

  /// <summary>
  /// The type of watercraft
  /// </summary>
  public enum TypeOfWatercraft
  {
    Inboard,
    Outboard,
    Sailboat
  }

  /// <summary>
  /// The type of alarm on a home
  /// </summary>
  public enum AlarmType
  {
    [Description("None")]
    None,
    [Description("Central")]
    Central,
    [Description("Local")]
    Local
  }

  /// <summary>
  /// The type of sprinklers
  /// </summary>
  public enum SprinklerType
  {
    [Description("None")]
    None,
    [Description("Partial")]
    Partial,
    [Description("Full")]
    Full
  }

  /// <summary>
  /// Class of UL Impact
  /// </summary>
  public enum ULImpactType
  {
    [Description("None")]
    None,
    [Description("Class 1")]
    Class1,
    [Description("Class 2")]
    Class2,
    [Description("Class 3")]
    Class3,
    [Description("Class 4")]
    Class4
  }

  /// <summary>
  /// Class of UL Fire
  /// </summary>
  public enum ULFireType
  {
    [Description("None")]
    None,
    [Description("Class A")]
    ClassA,
    [Description("Class B")]
    ClassB,
    [Description("Class C")]
    ClassC
  }

  /// <summary>
  /// Gated Community types
  /// </summary>
  public enum GatedCommunityType
  {
    [Description("Not Gated")]
    None,
    [Description("Single Entry Gated")]
    SingleGate,
    [Description("24-Hour Security Patrol")]
    SecurityPatrol,
    [Description("24-Hour Manned Gates")]
    MannedGates,
    [Description("Pass-Key Gates")]
    PassKeyGates
  }

  /// <summary>
	/// The roof composition on a home
	/// </summary>
	public enum RoofComposition
  {
    CompositeShingle,
    WoodShingle,
    Aluminum,
    Steel,
    Copper,
    RollRoofing,
    TarAndGravel,
    Tile,
    Slate,
    Concrete,
    Plastic,
    Recycled,
    SinglePlayMembraneSystems,
    Other,
    Asphalt,
    ConcreteTile,
    Fiberglass,
    Gravel,
    Metal,
    Plywood,
    ReinforcedConcrete,
    SpanishTile,
    Tin,
    WoodShake,
    Asbestos,
    CedarShake,
    CedarShingle,
    Rubber,
    Rock,
    PorcelainSteel
  }

  /// <summary>
  /// The type of foundation a home/dwelling is built on
  /// </summary>
  public enum FoundationType
  {
    [Description("Slab")]
    Slab,
    [Description("Basement - Finished")]
    FinishedBasement,
    [Description("Basement - Partially Finished")]
    PartiallyFinishedBasement,
    [Description("Basement - Unfinished")]
    UnfinishedBasement,
    [Description("Basement - Walkout")]
    WalkoutBasement,
    [Description("Crawlspace")]
    Crawlspace,
    [Description("Pier And Beam")]
    PierAndBeam,
    [Description("Other")]
    Other
  }

  /// <summary>
  /// The number of stories in building
  /// </summary>
  public enum StoryType
  {
    [Description("1 Story")]
    OneStory,
    [Description("1-1/2 Stories")]
    OneAndOneHalfStories,
    [Description("2 Stories")]
    TwoStories,
    [Description("2-1/2 Stories")]
    TwoAndOneHalfStories,
    [Description("3 Stories")]
    ThreeStories,
    [Description("4 or More Stories")]
    FourOrMoreStories,
    [Description("Bi-Level")]
    BiLevel,
    [Description("Split-Level")]
    SplitLevel,
    [Description("Tri-Level")]
    TriLevel
  }

  /// <summary>
  /// Roof covering.
  /// </summary>
  public enum RoofCovering
  {
    [Description("Select One")]
    None,
    [Description("Non-FBC Equivalent")]
    LevelA,
    [Description("FBC Equivalent")]
    LevelB,
    [Description("Non-GBC Equivalent")]
    LevelC,
    [Description("GBC Equivalent")]
    LevelD,
    [Description("Reinforced Concrete")]
    ReinC
  }

  /// <summary>
  /// Roof deck attachment.
  /// </summary>
  public enum RoofDeckAttachment
  {
    [Description("Select One")]
    None,
    [Description("Reinforced Concrete")]
    RCon,
    [Description("Type A")]
    STA,
    [Description("Type B")]
    STB,
    [Description("Typc C")]
    STC,
    [Description("Type D")]
    STD,
    [Description("Unknown")]
    Un
  }

  /// <summary>
  /// Roof wall connection.
  /// </summary>
  public enum RoofWallConnection
  {
    [Description("Select One")]
    None,
    [Description("Clips")]
    Clip,
    [Description("Double Wraps")]
    WrapD,
    [Description("Single Wraps")]
    WrapS,
    [Description("Toe Nails")]
    Nail,
    [Description("Unknown")]
    Un,
    [Description("Structural/Reinforced Concrete")]
    Structure
  }

  /// <summary>
  /// Openting Protection.
  /// </summary>
  public enum OpeningProtection
  {
    [Description("None")]
    None,
    [Description("Basic")]
    Basic,
    [Description("Hurricane")]
    Hurricane,
    [Description("All Openings SFBC/SSTD 12/ASTM E 1996")]
    AllOpeningsSFBC
  }

  /// <summary>
  /// Terrain exposure.
  /// </summary>
  public enum TerrainExposure
  {
    [Description("Select One")]
    None,
    [Description("B")]
    ExposureB,
    [Description("C")]
    ExposureC,
  }

  /// <summary>
  /// Wind speed.
  /// </summary>
  public enum WindSpeed
  {
    [Description("Select One")]
    None,
    [Description(">= 100")]
    gte100,
    [Description(">= 110")]
    gte110,
    [Description(">= 120")]
    gte120,
    [Description("Unknown")]
    Unknown
  }

  /// <summary>
  /// Wind design.
  /// </summary>
  public enum WindDesign
  {
    [Description("Select One")]
    None,
    [Description(">= 100")]
    gte100,
    [Description(">= 110")]
    gte110,
    [Description(">= 120")]
    gte20,
    [Description("Unknown")]
    Unknown
  }

  public enum InternalPressureDesign
  {
    [Description("Select One")]
    None,
    [Description("Partially Enclosed")]
    PartiallyEnclosed,
    [Description("Enclosed")]
    Enclosed
  }

  /// <summary>
  /// Wind mitigation form.
  /// </summary>
  public enum WindMitigationForm
  {
    [Description("2012")]
    wmf2012
  }

  /// <summary>
  /// The coverages to be rated on Dwelling Fire Form 1 policy
  /// </summary>
  public enum CoveredPerils
  {
    [Description("Fire Only")]
    FireOnly,
    [Description("Fire & EC Only")]
    FireECOnly,
    [Description("Fire, EC & V&MM")]
    FireECAndVMM
  }

  /// <summary>
  /// Type of liability rated on a Dwelling Fire policy
  /// </summary>
  public enum LiabilityType
  {
    [Description("CPL")]
    CPL,
    [Description("OLT")]
    OLT
  }

  /// <summary>
  /// Special Dwelling Types for TX Dwelling Fire
  /// </summary>
  public enum SpecialDwellingType
  {
    [Description("Not a Special Type")]
    None,
    [Description("Mobile Home")]
    MobileHome,
    [Description("Public Housing Authority")]
    PublicHousingAuthority
  }

  /// <summary>
  /// Watercraft type.
  /// </summary>
  public enum WatercraftType
  {
    [Description("None")]
    None,
    [Description("Outboard")]
    Outboard,
    [Description("Inboard")]
    Inboard,
    [Description("Inboard-Outdrive")]
    InboardOutdrive,
    [Description("Sailboat")]
    Sailboat
  }

  /// <summary>
  /// Exterior wall construction materials.
  /// </summary>
  public enum ExteriorWallMaterial
  {
    [Description("Select One")]
    SelectOne,
    [Description("Wood Framing")]
    F,
    [Description("Light Gauge Steel Framing")]
    SteelF,
    [Description("Timber Framing")]
    L,
    [Description("Solid Brick Construction")]
    BrkSol,
    [Description("Concrete Block")]
    B,
    [Description("Pre-Engineered - Metal")]
    PreMetal,
    [Description("Standard Pole Framed")]
    Pole,
    [Description("Adobe Block")]
    G
  }

  /// <summary>
  /// Roof shape.
  /// </summary>
  public enum RoofShape
  {
    [Description("Select One")]
    SelectOne,
    [Description("Gable")]
    GABLE,
    [Description("Hip")]
    HIP,
    [Description("Gambrel")]
    GAMBREL,
    [Description("Mansard")]
    MANSARD,
    [Description("Complex/Custom")]
    COMPLEX,
    [Description("Flat")]
    FLAT,
    [Description("Shed")]
    SHED
  }

  /// <summary>
  /// Flood zone code.
  /// </summary>
  public enum FloodZoneCode
  {
    [Description("Unknown")]
    Unknown,
    [Description("A")]
    A,
    [Description("B")]
    B,
    [Description("C")]
    C,
    [Description("D")]
    D,
    [Description("V")]
    V,
    [Description("X")]
    X
  }

  /// <summary>
  /// Building code effectiveness grade.
  /// </summary>
  public enum BCEGS
  {
    [Description("Select One")]
    SelectOne,
    [Description("1")]
    BCEGS_1,
    [Description("2")]
    BCEGS_2,
    [Description("3")]
    BCEGS_3,
    [Description("4")]
    BCEGS_4,
    [Description("5")]
    BCEGS_5,
    [Description("6")]
    BCEGS_6,
    [Description("7")]
    BCEGS_7,
    [Description("8")]
    BCEGS_8,
    [Description("9")]
    BCEGS_9,
    [Description("10")]
    BCEGS_10,
    [Description("98")]
    BCEGS_98,
    [Description("99")]
    BCEGS_99
  }

  /// <summary>
  /// Roof grade.
  /// </summary>
  public enum RoofGrade
  {
    [Description("Standard")]
    Standard,
    [Description("Heavy")]
    Heavy
  }

  /// <summary>
  /// Spa type.
  /// </summary>
  public enum SpaType
  {
    [Description("In Ground")]
    InGround,
    [Description("Above Ground")]
    AboveGround
  }


  /// <summary>
  /// Animals.
  /// </summary>
  public enum Animals
  {
    [Description("None")]
    None,
    [Description("Dog - Akita")]
    Akita,
    [Description("Dog - Alaskan Malamute")]
    AlaskanMalamute,
    [Description("Dog - American Bull Terrier")]
    AmericanBullTerrier,
    [Description("Dog - American Staffordshire Terrier")]
    AmericanStaffordshireTerrier,
    [Description("Dog - Bull Mastiff")]
    BullMastiff,
    [Description("Dog - Chow")]
    Chow,
    [Description("Dog - Dingo")]
    Dingo,
    [Description("Dog - Doberman")]
    Doberman,
    [Description("Dog - German Shepherd")]
    Gsheperd,
    [Description("Dog - Husky")]
    Husky,
    [Description("Dog - Pit Bull")]
    PitBull,
    [Description("Dog - Pit Bull Terrier")]
    PitBullTerrier,
    [Description("Dog - Presa Canario")]
    PresaCanario,
    [Description("Dog - Mix")]
    Mix,
    [Description("Dog - Rottweiler")]
    Rottweiler,
    [Description("Dog - Staffordshire Bull Terrier")]
    StaffordshireBullTerrier,
    [Description("Dog - Wolf Hybrid")]
    WolfHybrid,
    [Description("Dog - Other Breed")]
    Other,
    [Description("Livestock - Cow")]
    Cow,
    [Description("Livestock - Horse")]
    Horse,
    [Description("Livestock - Other")]
    OtherLivestock
  };


  /// <summary>
  /// Different types of porches
  /// </summary>
  public enum PorchTypeCd
  {
    [Description("None")]
    None,
    [Description("Covered Stoop")]
    CovStoop,
    [Description("Enclosed")]
    E,
    [Description("Open")]
    O,
    [Description("Open Wall 1 story")]
    OW1,
    [Description("Open Wall, 1 story with Deck")]
    OW1Deck,
    [Description("Open Wall, 2 story")]
    OW2,
    [Description("Screened Porch")]
    Screen
  }

  /// <summary>
  /// Different payment methods.
  /// </summary>
  public enum PaymentMethod
  {
    [Description("Mortgage Billed / PIF")]
    MortgageBilledPIF,
    [Description("Installments")]
    Installments,
    [Description("Installments EFT")]
    InstallmentsEFT,
    [Description("Mortgage Billed")]
    MortgageBilled
  }

  /// <summary>
  /// Level of update for Roof, Plumbing, Heating or Electrical
  /// </summary>
  public enum UpdateLevel
  {
    [Description("None")]
    None,
    [Description("Partial")]
    Partial,
    [Description("Full")]
    Full
  }

  /// <summary>
  /// Type of Garage 
  /// </summary>
  public enum GarageType
  {
    [Description("None")]
    None,
    [Description("Attached")]
    Attached,
    [Description("Basement")]
    Basement,
    [Description("Carport")]
    Carport,
    [Description("Detached Carport")]
    DetachedCarport,
    [Description("Detached")]
    Detached,
    [Description("Detached w/Finished Area")]
    DetachedWithFinishedArea,
    [Description("Detached Victorian")]
    DetachedVictorian,
    [Description("Detached Victorian w/Finished Area")]
    DetachedVictorianWithFinishedArea,
    [Description("Detached w/Area Over")]
    DetachedWithAreaOver,
    [Description("Detached w/Adjacent Living Area")]
    DetachedWithAdjacentLivingArea,
    [Description("Detached w/Living Area Over")]
    DetachedWithLivingAreaOver
  }

  /// <summary>
  /// Number of stalls in a Garage
  /// </summary>
  public enum GarageStalls
  {
    [Description("Select One")]
    None,
    [Description("1 Car")]
    OneCar,
    [Description("1.5 Car")]
    OnePlusHalf,
    [Description("2 Car")]
    TwoCar,
    [Description("2.5 Car")]
    TwoPlusHalf,
    [Description("3 Car")]
    ThreeCar,
    [Description("3.5 Car")]
    ThreePlusHalf,
    [Description("4 Car")]
    FourCar,
    [Description("4.5 Car")]
    FourPlusHalf,
    [Description("5+ Car")]
    FivePlus
  }

  /// <summary>
  /// Type description of a fireplace
  /// </summary>
  public enum FireplaceType
  {
    [Description("Embedded")]
    Embedded,
    [Description("Gas Hook Up")]
    GasHook,
    [Description("Kiva")]
    Kiva,
    [Description("Marble Surround")]
    MarbSurrnd,
    [Description("Metal Insert")]
    MetalInsert,
    [Description("Multiface")]
    Multiface,
    [Description("Masonry")]
    Masonry,
    [Description("Prefab Metal")]
    PreFabMetal,
    [Description("Wood Surround")]
    WoodSurrnd,
    [Description("Zero Clearance")]
    ZeroClearance,
    [Description("Other")]
    Other
  }

  /// <summary>
	/// Constants used at the homeowners level
	/// </summary>
  public sealed class HOConstants
  {
    /// <summary>
    /// hiding the default constructor
    /// </summary>
    private HOConstants()
    {
    }

    /// <summary>
    /// Construction name strings.
    /// </summary>
    public static readonly string[] ConstructionName =
    {
      "Brick",
      "Brick Veneer",
      "Stucco",
      "Fire Resistant",
      "Frame",
      "Semi Wind-Resistive",
      "Wind-Resistive",
      "Superior"
    };

    /// <summary>
    /// Construction name characters.
    /// </summary>
    public static readonly string[] ConstructionChars =
    {
      "B",
      "V",
      "S",
      "R",
      "F",
      "M",
      "T",
      "P"
    };

    /// <summary>
    /// Watercraft names.
    /// </summary>
    public static readonly string[] WatercraftNames =
      {
        "Inboard",
        "Outboard",
        "Sailboat"
      };

    /// <summary>
    /// Watercraft characters.
    /// </summary>
    public static readonly string[] WatercraftChars =
      {
        "I",
        "O",
        "S"
      };

    /// <summary>
    /// Occupancy names.
    /// </summary>
    public static readonly string[] OccupancyNames =
      {
        "Owner Occupied",
        "Tenant"
      };

    /// <summary>
    /// Occupancy characters.
    /// </summary>
    public static readonly string[] OccupancyChars =
      {
        "O",
        "T"
      };

    /// <summary>
    /// Alarm type names.
    /// </summary>
    public static readonly string[] AlarmTypeNames =
    {
      "None",
      "Central",
      "Local"
    };

    /// <summary>
    /// Usage type names.
    /// </summary>
    public static readonly string[] UsageTypeNames =
    {
      "Primary",
      "Secondary"
    };

    /// <summary>
    /// Usage type characters.
    /// </summary>
    public static readonly string[] UsageTypeChars =
    {
      "P",
      "S"
    };

    /// <summary>
    /// Roof composition names.
    /// </summary>
    public static readonly string[] RoofCompositionNames =
    {
      "Composite Shingle",
      "Wood Shingle",
      "Aluminum",
      "Steel",
      "Copper",
      "Roll Roofing",
      "Tar And Gravel",
      "Clay Tile",
      "Slate",
      "Concrete",
      "Plastic",
      "Recycled",
      "Single Ply Membrane Systems",
      "Other",
      "Asphalt",
      "Concrete Tile",
      "Fiberglass",
      "Gravel",
      "Metal",
      "Plywood",
      "Reinforced Concrete",
      "Spanish Tile",
      "Tin",
      "Wood Shake",
      "Asbestos",
      "Cedar Shakes",
      "Cedar Shingles",
      "Rubber",
      "Rock",
      "Steel / Porcelain Shingles",
    };

    /// <summary>
    /// Roof composition characters.
    /// </summary>
    public static readonly string[] RoofCompositionChars =
    {
      "CS",     // Composite Shingle
			"WO",     // Wood Shingle
			"AL",     // Aluminum
			"ST",     // Steel
			"CO",     // Copper
			"RO",     // Roll Roofing
			"TA",     // Tar and Gravel
			"TI",     // Clay Tile
			"SL",     // Slate
			"CN",     // Concrete
			"PL",     // Plastic
			"RE",     // Recycled
			"SP",     // Single Ply Membrane Systems
			"OT",     // Other
      "AS",     // Asphalt
      "CT",     // Concrete Tile
      "FG",     // Fiberglass
      "GR",     // Gravel
      "MT",     // Metal
      "PY",     // Plywood
      "RC",     // Reinforced Concrete
      "SA",     // Spanish Tile
      "TN",     // Tin
      "WS",      // Wood Shake
      "AB",			//Asbestos
      "CR",			//Cedar Shakes
      "CL",			//Cedar Shingles
      "RB",			//Rubber
      "RK",			//Rock
      "PS",			//Steel / Porcelain Shingles
		};

    /// <summary>
    /// Conversion of story types to number of stories.
    /// </summary>
    public static readonly int[] StoryTypeToNumberOfStories =
    {
      1,
      2,
      2,
      3,
      3,
      4,
      2,
      1,
      3
    };

    /// <summary>
    /// The number of units in a fire division.
    /// </summary>
    public static readonly int[] UnitsInFireDivision =
    {
      1,
      2,
      3,
      4
    };

    /// <summary>
    /// The number of townhouse units.
    /// </summary>
    public static readonly int[] NumberOfTownhouseUnits =
    {
      1,
      2,
      3,
      4
    };

    /// <summary>
    /// Vacant or Unoccupied status of the dwelling
    /// </summary>
    public enum VacantUnoccupied
    {
      [Description("Not Vacant/Unoccupied")]
      NotVacantOrUnoccupied,
      [Description("Vacant")]
      Vacant,
      [Description("Unoccupied")]
      Unoccupied
    }
  }
}
