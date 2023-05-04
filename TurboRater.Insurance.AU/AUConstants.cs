using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TurboRater.Insurance.AU
{
  public enum DMVActions
  {
    [Description("None")]
    None,
    [Description("Expired")]
    Expired,
    [Description("Suspended")]
    Suspended
  }

  public enum PaymentMethod
  {
    Standard,
    EFT,
    PIF,
    Default
  }

  public enum ViolationEntryStatus
  {
    Agent,
    MVR,
    MVRModified
  }

  public enum LienHolderType
  {
    NoLienHolder,
    Lease,
    Loan
  }

  public enum ResidencyType
  {
    Home,
    Apartment,
    Condo,
    Mobile,
    FixedMobile
  }

  public enum ResidencyStatus
  {
    Own,
    Rent,
    Lease
  }

  public enum PriorTransferLevel
  {
    NoPriorTransfer,
    TransferLevel1,
    TransferLevel2,
    TransferLevel3,
    TransferLevel4,
    TransferLevel5,
    TransferLevel6,
    TransferLevel7,
    TransferLevel8,
    TransferLevel9
  }

  public enum MedicalExpenseLevel
  {
    NoMedicalExpense,
    MedicalLevel1,
    MedicalLevel2
  }

  public enum UninsType
  {
    [Description("None")]
    None,
    [Description("Reduced")]
    Reduced,
    [Description("Added-On")]
    AddedOn
  }

  public enum FLPIPType
  {
    Basic,
    Extended
  }

  public enum MIPIPType
  {
    Primary,
    ExcessMedical,
    ExcessWage,
    ExcessBoth
  }

  public enum MIPIPWorkLossRejectionType
  {
    WorkLossIncluded,
    NamedInsured,
    NamedInsuredAndHousehold
  }

  public enum MDPIPType
  {
    PIP,
    Guest
  }

  /// <summary>
  /// PIP Work Loss Deductible.  
  /// </summary>
  public enum PIPWorkLossDeductible
  {
    [Description("No Ded")]
    NoDeductible,
    [Description("1 Week")]
    OneWeek,
    [Description("2 Weeks")]
    TwoWeeks
  }

  public enum FLPIPDedOption
  {
    [Description("I")]
    NamedInsured,
    [Description("R")]
    NamedInsuredResidentRelative
  }

  public enum COPIPType
  {
    BasicPIP,
    Limited,
    Option1,
    Option2,
    Option3
  }

  public enum KYPIPType
  {
    PIP,
    BuyBack,
    Guest,
    None
  }

  public enum ORPIPDedOption
  {
    [Description("I")]
    NamedInsured,
    [Description("R")]
    NamedInsuredResidentRelative
  }

  public enum MICollType
  {
    BroadForm,
    Standard,
    Limited
  }

  public enum VehicleUsage
  {
    Artisan,
    Business,
    Farm,
    Pleasure,
    ToWork
  }

  public enum CarBody
  {
    SedanTwoDoor,
    FormalHardtopTwoDoor,
    HatchbackTwoDoor,
    LiftbackThreeDoor,
    PillardHardtopTwoDoor,
    HardtopTwoDoor,
    TwoDoorWagonSportUtility,
    RunaboutThreeDoor,
    ThreeDoorExtendedCab,
    ThreeDoorExtendedCabAndChassis,
    SedanFourDoor,
    FourDoorExtendedCab,
    FourDoorExtendedCabAndChassis,
    HatchbackFourDoor,
    LiftbackFiveDoor,
    PillardHardtopFourDoor,
    HardtopFourDoor,
    FourDoorWagonSportUtility,
    SedanFiveDoor,
    EightPassengerSportVan,
    AutoCarrier,
    Ambulance,
    ArmoredTruck,
    Bus,
    CabAndChassis,
    ConventionalCab,
    CargoVan,
    CrewChassis,
    ClubChassis,
    ConcreteOrTransitMixer,
    Coupe,
    Crane,
    SuperCabChassisPickup,
    CustomPickup,
    Convertible,
    CargoCutaway,
    DumpTruck,
    TractorTruck1,
    ExtendedCargoVan,
    ExtendedSportVan,
    ExtendedVan,
    ExtendedWindowVan,
    FlatBedOrPlatform,
    ForwardControl,
    FireTruck,
    GarbageOrRefuse,
    Gliders,
    Grain,
    Hatchback,
    Hopper,
    Hearse,
    Hardtop,
    IncompleteChassis,
    IncompleteExtendedVan,
    Liftback,
    Logger,
    SuburbanAndCarryAll,
    Limousine,
    MotorizedHome,
    MultiPurpose,
    MaxiVan,
    MotorizedCutaway,
    Notchback,
    ClubCabPickup,
    ParcelDelivery,
    Pickup,
    PickupWithCamper,
    Panel,
    SuperCabPickup,
    Roadster,
    OneSeat,
    TwoSeat,
    SportHatchback,
    SportCoupe,
    Sedan,
    StepVan,
    SportPickup,
    StakeOrRack,
    SportVan,
    StationWagon,
    TiltCab,
    TiltTandem,
    Tandem,
    Tank,
    TractorTruck2,
    Utility,
    VanCamper,
    DisplayVan,
    Van,
    Vanette,
    WindowVan,
    TowTruckWrecker,
    WideWheelWagon,
    Travelall,
    Cutaway,
    CrewPickup
  }

  public enum PassiveRestraints
  {
    None,
    Driver,
    Both
  }

  public enum PurchaseType
  {
    New,
    Used
  }

  public enum FuelType
  {
    Gasoline2,
    Gasoline1,
    Diesel,
    Electric,
    Flexible,
    Ethanol,
    Methanol,
    NaturalGas,
    Propane,
    Hybrid
  }

  public enum AirBag
  {
    NoAirBags,
    DrverSideAirBag,
    BothSideAirBag
  }

  public enum AntiLockBrakes
  {
    NoAntiLock,
    FrontAntiLock,
    RearAntiLock,
    AllAntiLock
  }

  public enum AntiTheft
  {
    None,
    Level1,
    Level2,
    Level3,
    Level4,
    Level5,
    Level6,
    Level7,
    Level8,
    Level9
  }

  public enum MaritalStatus
  {
    Married,
    Single,
    Divorced,
    Widowed,
    Separated,
    DomesticPartner,
    CommonLaw
  }

  public enum VehicleType
  {
    Truck,
    Car,
    StationWagon,
    Utility,
    MiniVan,
    Van
  }

  public enum TruckSize
  {
    QuarterTon,
    HalfTon,
    ThreeQuarterTon,
    OneTon,
    OverOneTon
  }

  /// <summary>
  /// Motorcycle body types we can get back from POLK.
  /// </summary>
  public enum MotorcycleBody
  {
    [Description("All Terrain")]
    AllTerrain,
    [Description("Enduro")]
    Enduro,
    [Description("Mini Bike")]
    MiniBike,
    [Description("Mini Motocross")]
    MiniMotocross,
    [Description("Moped")]
    Moped,
    [Description("Mini Road/Trail")]
    MiniRoadTrail,
    [Description("Motor Scooter")]
    MotorScooter,
    [Description("Motocross")]
    Motocross,
    [Description("Mini Cycle")]
    MiniCycle,
    [Description("Racer")]
    Racer,
    [Description("Road/Street")]
    RoadStreet,
    [Description("Road/Trail")]
    RoadTrail,
    [Description("Dirt")]
    Dirt,
    [Description("Trail/Dirt")]
    TrailDirt,
    [Description("Trail")]
    Trail
  }

  /// <summary>
  /// Motorcycle vehicle usages.  Note: list is different than auto.
  /// </summary>
  public enum MotorcycleVehicleUsage
  {
    [Description("Artisan Use")]
    Artisan,
    [Description("Business Use")]
    Business,
    [Description("Farm")]
    Farm,
    [Description("Off Road")]
    OffRoad,
    [Description("Pleasure")]
    Pleasure,
    [Description("Work/School")]
    ToWork
  }

  /// <summary>
  /// Maker codes for vehicles.
  /// </summary>
  public enum MakerCode
  {
    All = 0,
    Acura = 1,
    Alfaromeo = 2,
    Amgeneral = 3,
    AmericanMotors = 4,
    Aro = 5,
    AstonMartin = 6,
    Audi = 7,
    Austin = 8,
    Avanti = 9,
    Bert = 10,
    Bertone = 68,
    Bmw = 11,
    Buick = 12,
    Cadillac = 13,
    Capri = 14,
    Checker = 15,
    Chevrolet = 16,
    Chrysler = 17,
    Daihatsu = 18,
    Delorean = 19,
    Dodge = 20,
    Eagle = 21,
    Ferrari = 22,
    Fiat = 23,
    Ford = 24,
    Geo = 25,
    Gm = 71,
    Gmc = 26,
    Hino = 72,
    Honda = 27,
    Hyundai = 28,
    Infiniti = 29,
    International = 30,
    Isuzu = 31,
    Jaguar = 32,
    Jeep = 33,
    Kia = 34,
    Lancia = 35,
    Landrover = 36,
    Lexus = 37,
    Lincoln = 38,
    Lotus = 39,
    Maserati = 40,
    Mazda = 41,
    MercedesBenz = 42,
    Mercury = 43,
    Merkur = 44,
    Mg = 45,
    Mitsubishi = 46,
    Nissan = 47,
    Oldsmobile = 48,
    Opel = 49,
    Peugeot = 50,
    Pini = 51,
    Plymouth = 52,
    Pontiac = 53,
    Porsche = 54,
    Renault = 55,
    Rover = 56,
    Saab = 57,
    Saturn = 58,
    Sterling = 59,
    Subaru = 60,
    Suzuki = 61,
    Toyota = 62,
    Triumph = 63,
    Tvr = 64,
    Ud = 74,
    Volkswagen = 65,
    Volvo = 66,
    Yugo = 67
  }

  /// <summary>
  /// Vehicle model codes.  Trnaslated from delphi, so the format might be a little weird.
  /// They all start with "m" since many are numbers, and enums cannot start with numbers.
  /// </summary>
  public enum ModelGroupCode
  {
    mAll = 0,
    m100series = 71,
    m110 = 410,
    m124 = 224,
    m128 = 225,
    m128x1_9 = 578,
    m131 = 226,
    m164series = 43,
    m1800 = 561,
    m18i = 491,
    m190series = 346,
    m200series = 74,
    m2000series = 179,
    m2002series = 84,
    m200sx = 394,
    m210 = 395,
    m220series = 347,
    m230series = 348,
    m240series = 349,
    m240sx = 396,
    m250series = 350,
    m260series = 351,
    m280series = 352,
    m300series = 85,
    m3000gt = 382,
    m300zx = 398,
    m310 = 399,
    m323 = 331,
    m350series = 353,
    m380series = 354,
    m400series = 180,
    m4000series = 75,
    m405 = 435,
    m420series = 568,
    m450series = 355,
    m4runner = 522,
    m500series = 86,
    m5000series = 76,
    m504 = 436,
    m505 = 437,
    m510 = 400,
    m560series = 356,
    m60special = 113,
    m600series = 87,
    m6000 = 461,
    m604 = 438,
    m610 = 401,
    m626 = 332,
    m700series = 88,
    m710 = 402,
    m750series = 89,
    m760series = 563,
    m780series = 564,
    m80series = 77,
    m800series = 90,
    m808 = 333,
    m810 = 405,
    m825 = 503,
    m827 = 504,
    m828 = 315,
    m850series = 579,
    m88 = 419,
    m90series = 78,
    m900series = 498,
    m9000series = 499,
    m911 = 483,
    m912 = 484,
    m914 = 485,
    m924 = 486,
    m928 = 487,
    m929 = 334,
    m930 = 488,
    m940series = 565,
    m944 = 489,
    m960 = 566,
    m968 = 490,
    m98 = 420,
    mAseries = 79,
    mA8series = 580,
    mAcadian = 121,
    mAccent = 289,
    mAcclaim = 439,
    mAccord = 282,
    mAchieva = 421,
    mAerostar = 232,
    mAlero = 613,
    mAlfetta = 44,
    mAllante = 114,
    mAlliance = 50,
    mAltima = 406,
    mAltra = 614,
    mAmbassador = 51,
    mAmigo = 296,
    mAmx = 52,
    mApollo = 96,
    mAries = 181,
    mArrow = 440,
    mAspen = 182,
    mAspire = 233,
    mAstre = 462,
    mAstrovan = 122,
    mAurora = 422,
    mAustin = 83,
    mAvalon = 523,
    mAvenger = 183,
    mAxxess = 407,
    mBseriespickup = 335,
    mBseries_ramvan = 185,
    mBseries_ramwagon = 187,
    mBseries_sportsmanvan = 184,
    mB210 = 408,
    mBarracuda = 441,
    mBeetle = 556,
    mBelair = 123,
    mBeretta = 124,
    mBerettagt_zz26 = 125,
    mBertone = 227,
    mBiscayne = 126,
    mBlankmodel = 577,
    mBlazer = 127,
    mBobcat = 361,
    mBonneville = 463,
    mBonnevillesse_i = 464,
    mBoxster = 596,
    mBrat = 505,
    mBrava = 228,
    mBravada = 423,
    mBreeze = 569,
    mBronco = 234,
    mBrougham = 362,
    mCclass = 357,
    mC_rseriespickups = 128,
    mCaballero = 268,
    mCabrio = 597,
    mCabriolet = 80,
    mCalais = 115,
    mCamaro = 131,
    mCamry = 524,
    mCapri = 120,
    mCaprice = 132,
    mCaravan = 188,
    mCaravelle = 442,
    mCarina = 525,
    mCatalina = 465,
    mCatera = 581,
    mCavalier = 133,
    mCavalierz24 = 134,
    mCelebrity = 135,
    mCelica = 526,
    mCenturion = 97,
    mCentury = 98,
    mChallenger = 189,
    mChamp = 443,
    mCharade = 177,
    mCharger = 190,
    mCherokee = 53,
    mChevelle = 136,
    mChevette = 137,
    mChrysler300 = 158,
    mCiera = 424,
    mCimarron = 570,
    mCirrus = 159,
    mCitation = 138,
    mCivic = 283,
    mCjseries = 54,
    mClseries = 36,
    mClubwagon = 235,
    mColonypark = 363,
    mColt = 191,
    mColtvista = 192,
    mComanche = 55,
    mComet = 364,
    mCommando = 582,
    mConcord = 56,
    mConcorde = 160,
    mConquest = 161,
    mContinental = 327,
    mContour = 236,
    mCordia = 383,
    mCordoba = 162,
    mCorolla = 527,
    mCorona = 528,
    mCoronet = 193,
    mCorrado = 542,
    mCorsica = 139,
    mCorvette = 140,
    mCosmo = 336,
    mCougar = 365,
    mCougarxr7 = 366,
    mCountrysquire = 237,
    mCoupe = 81,
    mCourier = 571,
    mCr_v = 611,
    mCressida = 529,
    mCricket = 444,
    mCrown = 572,
    mCrownvictoria = 238,
    mCrx = 284,
    mCustom = 239,
    mCutlass = 428,
    mCutlasscalais = 425,
    mCutlassciera = 426,
    mCutlasssupreme = 427,
    mDseriespickups = 194,
    mD50pickups = 195,
    mDakota = 196,
    mDart = 197,
    mDasher = 543,
    mDaytona = 163,
    mDefender = 317,
    mDelsol = 285,
    mDeluxe = 506,
    mDenali = 612,
    mDeville = 116,
    mDiamante = 384,
    mDiplomat = 198,
    mDiscovery = 318,
    mDjseries = 65,
    mDurango = 598,
    mDuster = 445,
    mDynasty = 164,
    mEclass = 358,
    mEagle = 57,
    mEclipse = 385,
    mEconolinevan = 240,
    mElcamino = 141,
    mElantra = 290,
    mEldorado = 117,
    mElectra = 99,
    mElite = 241,
    mEncore = 58,
    mEnvoy = 615,
    mEs250 = 320,
    mEs300 = 321,
    mEscalade = 616,
    mEscort = 242,
    mEsteem = 516,
    mEurovan = 544,
    mEvclass = 609,
    mEv1 = 591,
    mExcel = 291,
    mExecutive = 166,
    mExp = 243,
    mExpedition = 583,
    mExplorer = 244,
    mExpo = 199,
    mExpressvan = 142,
    mFseriespickup = 245,
    mF10 = 409,
    mFamodel = 592,
    mFairmont = 246,
    mFastbacksedan = 545,
    mFemodel = 610,
    mFestiva = 247,
    mFiero = 466,
    mFiesta = 248,
    mFifthavenue = 573,
    mFirebird = 467,
    mFirefly = 468,
    mFirenza = 429,
    mFleetwood = 118,
    mForester = 599,
    mFox = 546,
    mFrontier = 600,
    mFuego = 492,
    mFury = 446,
    mGseries_chevyvan = 144,
    mGseries_rallyvan = 271,
    mGseries_rallywagon = 272,
    mG20 = 294,
    mGalant = 386,
    mGalaxie = 249,
    mGl = 507,
    mGolf = 547,
    mGordini = 493,
    mGranada = 251,
    mGrandam = 469,
    mGrandlemans = 471,
    mGrandprix = 472,
    mGrandsport = 100,
    mGrandvitara = 622,
    mGrandville = 473,
    mGremlin = 60,
    mGs300 = 322,
    mGs400 = 601,
    mGt = 434,
    mGti = 548,
    mGtivr6 = 549,
    mGto = 474,
    mGtv = 45,
    mHombre = 297,
    mHorizon = 448,
    mHornet = 61,
    mI_mark = 298,
    mI30 = 299,
    mImpala = 145,
    mImperial = 167,
    mImpreza = 508,
    mImpulse = 303,
    mIntegra = 33,
    mIntrepid = 168,
    mIntrigue = 593,
    mJseriespickup = 62,
    mJ30 = 300,
    mJavelin = 63,
    mJeep = 64,
    mJetta = 550,
    mJimmy = 269,
    mJimmys1500 = 270,
    mJusty = 509,
    mK_vseriespickups = 129,
    mKarmannghia = 551,
    mKombi = 552,
    mLseries = 91,
    mLaguna = 146,
    mLancer = 200,
    mLancia = 316,
    mLandcruiser = 530,
    mLaser = 169,
    mLecar = 494,
    mLebaron = 170,
    mLegacy = 510,
    mLegend = 39,
    mLemans = 470,
    mLesabre = 101,
    mLhs = 171,
    mLn7 = 368,
    mLoyale = 511,
    mLs400 = 323,
    mLss = 430,
    mLtd = 252,
    mLumina = 147,
    mLuv = 148,
    mLxseries = 324,
    mLynx = 369,
    mMseries = 617,
    mM3 = 92,
    mM30 = 301,
    mM5 = 93,
    mM6 = 94,
    mMagnum = 201,
    mMalibu = 149,
    mMarkseries = 328,
    mMarquis = 367,
    mMatador = 66,
    mMaverick = 253,
    mMaxima = 404,
    mMedallion = 219,
    mMerkur = 380,
    mMetro = 264,
    mMg_mgb = 381,
    mMiata = 337,
    mMightymax = 387,
    mMilano = 46,
    mMillenia = 338,
    mMillionseries = 595,
    mMiniramvan = 186,
    mMirada = 202,
    mMirage = 388,
    mMlseries = 602,
    mMonaco = 203,
    mMonarch = 370,
    mMontana = 618,
    mMontecarlo = 150,
    mMontego = 371,
    mMonterey = 372,
    mMontero = 389,
    mMonza = 151,
    mMountaineer = 584,
    mMpv = 339,
    mMr2 = 531,
    mMustang = 254,
    mMxmark = 532,
    mMx3 = 340,
    mMx6 = 341,
    mMystique = 373,
    mNavajo = 342,
    mNavigator = 603,
    mNeon = 204,
    mNewyorker = 172,
    mNewport = 173,
    mNova = 152,
    mNqr = 619,
    mNsx = 40,
    mNx1600 = 411,
    mNx2000 = 412,
    mOasis = 304,
    mOdyssey = 286,
    mOmega = 431,
    mOmni = 205,
    mOpel = 102,
    mOpelsport_gt = 103,
    mOrvis = 585,
    mOutback = 512,
    mPacer = 67,
    mParisienne = 475,
    mParkavenue = 104,
    mPaseo = 533,
    mPassat = 553,
    mPassport = 287,
    mPathfinder = 413,
    mPbseries_voyager = 449,
    mPhoenix = 476,
    mPickup = 521,
    mPininfarina = 229,
    mPinto = 255,
    mPolara = 206,
    mPrecis = 390,
    mPrelude = 288,
    mPremier = 220,
    mPrevia = 534,
    mPrizm = 265,
    mProbe = 256,
    mProtege = 343,
    mProwler = 586,
    mPulsar = 414,
    mQ45 = 302,
    mQuantum = 554,
    mQuattro = 72,
    mQuest = 415,
    mQx4 = 587,
    mR17 = 496,
    mRabbit = 555,
    mRaider = 207,
    mRam50pickup = 209,
    mRampickup = 208,
    mRamwagon = 604,
    mRamcharger = 210,
    mRampage = 211,
    mRanchero = 257,
    mRangerover = 319,
    mRanger = 258,
    mRav4 = 535,
    mReatta = 105,
    mRegal = 106,
    mRegalt_type = 107,
    mReliant = 450,
    mRenault = 495,
    mRiviera = 108,
    mRlseries = 38,
    mRoadmaster = 109,
    mRocky = 178,
    mRodeo = 305,
    mRoyalvan = 212,
    mRx = 344,
    mRx7 = 345,
    mSclass = 359,
    mS10blazer = 154,
    mS10_s15pickup = 153,
    mS6 = 82,
    mSable = 374,
    mSafari = 273,
    mSamurai = 518,
    mSapporo = 451,
    mSatellite = 452,
    mSavanavan = 274,
    mSavanawagon = 275,
    mScseries = 500,
    mSc300 = 325,
    mSc400 = 326,
    mScamp = 453,
    mScirocco = 557,
    mScoupe = 292,
    mScout = 295,
    mScrambler = 68,
    mSebring = 174,
    mSentra = 416,
    mSephia = 313,
    mSeville = 119,
    mShadow = 213,
    mSidekick = 519,
    mSienna = 605,
    mSierra = 276,
    mSigma = 391,
    mSilhouette = 432,
    mSkyhawk = 110,
    mSkylark = 111,
    mSlclass = 360,
    mSlseries = 501,
    mSlk = 594,
    mSlx = 41,
    mSomerset = 112,
    mSonata = 293,
    mSonoma = 277,
    mSpectrum = 155,
    mSpider = 47,
    mSpirit = 69,
    mSport = 48,
    mSportage = 314,
    mSportvan = 143,
    mSportwagon = 497,
    mSprint = 49,
    mStregis = 214,
    mStandard = 513,
    mStanza = 417,
    mStarfire = 574,
    mStarion = 392,
    mStarlet = 575,
    mStealth = 215,
    mStorm = 266,
    mStrada = 230,
    mStratus = 216,
    mStylus = 306,
    mSuburban = 130,
    mSummit = 221,
    mSunbird = 477,
    mSundance = 454,
    mSunfire = 478,
    mSupra = 536,
    mSvx = 514,
    mSwseries = 502,
    mSwift = 517,
    mSwiftgt_gti = 576,
    mSyclone = 278,
    mT_1000 = 479,
    mT100 = 537,
    mTacoma = 538,
    mTahoe = 156,
    mTalon = 222,
    mTaurus = 259,
    mTaurussho = 260,
    mTc = 175,
    mTc3 = 455,
    mTempest = 480,
    mTempo = 261,
    mTercel = 539,
    mThing = 558,
    mThunderbird = 262,
    mTiburon = 588,
    mTlseries = 37,
    mTopaz = 375,
    mTorino = 250,
    mToronado = 433,
    mTown_country = 176,
    mTowncar = 329,
    mTracer = 376,
    mTracker = 267,
    mTrailduster = 456,
    mTranssport = 481,
    mTransporter = 559,
    mTravelall = 589,
    mTredia = 393,
    mTriumph = 540,
    mTrooper = 307,
    mTurismo = 457,
    mTyphoon = 279,
    mUdclass = 606,
    mV70 = 607,
    mValiant = 458,
    mVan = 418,
    mVanagon = 560,
    mVandura = 280,
    mVega = 157,
    mVehicross = 620,
    mVentura = 482,
    mVenture = 590,
    mVersailles = 330,
    mVigor = 42,
    mVillager = 377,
    mViper = 217,
    mVision = 223,
    mVitara = 621,
    mVolare = 459,
    mVoyager = 447,
    mWseriespickup = 218,
    mWagoneer = 59,
    mWindstar = 263,
    mWrangler = 70,
    mX1_9 = 231,
    mX90 = 520,
    mXj12 = 309,
    mXj6 = 308,
    mXj8 = 608,
    mXjs = 310,
    mXr3 = 378,
    mXtseries = 515,
    mYugo = 567,
    mYukon = 281,
    mZseries = 397,
    mZ3 = 95,
    mZephyr = 379
  }

  /// <summary>
  /// Total disability coverage types for the insured or insured and spouse.
  /// </summary>
  public enum TotalDisabilityType
  {
    [Description("None")]
    None,
    [Description("Insd and Spouse")]
    InsuredAndSpouse,
    [Description("Insured Only")]
    InsuredOnly
  }

  /// <summary>
  /// Reason why applicant currently has no insurance.
  /// </summary>
  public enum ReasonForNoInsurance
  {
    [Description("Select One")]
    NoReasonGiven,
    [Description("Car In Storage")]
    CarInStorage,
    [Description("Company Car")]
    CompanyCar,
    [Description("Deployed Military")]
    DeployedMilitary,
    [Description("Did Not Own Or Operate a Vehicle")]
    DidNotOwnVehicle,
    [Description("Driving Without Insurance")]
    DrivingWithoutInsurance,
    [Description("Incarcerated")]
    Incarcerated,
    [Description("No Insurance Required")]
    NoInsuranceRequired,
    [Description("Out of Country")]
    OutOfCountry,
    [Description("Physically Impaired/Ill")]
    PhysicallyImpaired,
    [Description("Self Insured")]
    SelfInsured,
    [Description("Under Someone Else's Policy")]
    UnderOthersPolicy,
    [Description("Other")]
    Other
  }

  /// <summary>
  /// Constants at the AU level
  /// </summary>
  public sealed class AUConstants
  {
    public static readonly string[] ExpiredLicenseStrings =
    {
      "None",
      "Expired",
      "Suspended"
    };

    public static readonly string[] ExpiredLicenseChar =
    {
      "N",
      "E",
      "S"
    };

    public static readonly string[] RelationStrings =
        {
            "Insured",
            "Spouse",
            "Child",
            "Other Related",
            "Other Non-Related",
            "Parent"
        };

    public static readonly char[] RelationChar =
        {
            'I',
            'S',
            'C',
            'R',
            'N',
            'P'
        };

    public static readonly string[] ViolationEntryStatusNames =
		{
			"Agent",
			"MVR",
			"MVR Modified"
		};

    public static readonly string[] ViolationEntryStatusChars =
		{
			"A",
			"M",
			"C"
		};

    public static readonly string[] LienHolderTypeNames =
		{
			"None",
			"Lease",
			"Loan"
		};

    public static readonly string[] LienHolderTypeChars =
		{
			"N",
			"S",
			"L"
		};

    public static readonly string[] AirBagNames =
		{
			"No Air Bag",
			"Driver Side",
			"Both Sides"
		};

    public static readonly string[] AirBagChars =
		{
			"N",
			"D",
			"B"
		};

    public static readonly string[] AntiLockBrakesNames =
		{
			"No Anti-Lock",
			"Front Anti-Lock",
			"Rear Anti-Lock",
			"All Anti-Lock"
		};

    public static readonly string[] AntiLockBrakesChars =
		{
			"N",
			"F",
			"R",
			"A"
		};

    public static readonly string[] AntiTheftNames =
		{
			"No Anti-Theft",
			"Anti-Theft Level 1",
			"Anti-Theft Level 2",
			"Anti-Theft Level 3",
			"Anti-Theft Level 4",
			"Anti-Theft Level 5",
			"Anti-Theft Level 6",
			"Anti-Theft Level 7",
			"Anti-Theft Level 8",
			"Anti-Theft Level 9"
		};

    public static readonly string[] AntiTheftChars =
		{
			"N",
			"1",
			"2",
			"3",
			"4",
			"5",
			"6",
			"7",
			"8",
			"9"
		};

    public static readonly string[] FuelTypeNames =
		{
			"Gas",
			"Gasoline",
			"Diesel",
			"Electric",
			"Flexible",
			"Ethanol",
			"Methanol",
			"Natural Gas",
			"Propane",
			"Hybrid"
		};

    public static readonly string[] FuelTypeChars =
		{
			"G",
			"C",
			"D",
			"E",
			"F",
			"H",
			"M",
			"N",
			"P",
			"B"
		};

    public static readonly string[] PurchaseTypeNames =
		{
			"New",
			"Used"
		};

    public static readonly string[] PurchaseTypeChars =
		{
			"N",
			"U"
		};

    public static readonly string[] PassiveRestraintsNames =
		{
			"No Passive Restraint",
			"Driver Side",
			"Both Sides"
		};

    public static readonly string[] PassiveRestraintsChars =
		{
			"N",
			"D",
			"B"
		};

    public static readonly string[] CarBodyNames =
		{
			"Sedan 2dr",
			"Formal Hardtop 2dr",
			"Hatchback 2dr",
			"Liftback 3dr",
			"Pillard Hardtop 2dr",
			"Hardtop 2dr",
			"2dr Wagon/Sport Utility",
			"Runabout 3dr",
			"3dr Extended Cab",
			"3dr Extended Cab & Chassis",
			"Sedan 4dr",
			"4dr Extended Cab",
			"4dr Extended Cab & Chassis",
			"Hatchback 4dr",
			"Liftback 5dr",
			"Pillard Hardtop 4dr",
			"Hardtop 4dr",
			"4dr Wagon/Sport Utility",
			"Sedan 5dr",
			"8 Passenger Sport Van",
			"Auto Carrier",
			"Ambulance",
			"Armored Truck",
			"Bus",
			"Cab & Chassis",
			"Conventional Cab",
			"Cargo Van",
			"Crew Chassis",
			"Club Chassis",
			"Concrete or Transit Mixer",
			"Coupe",
			"Crane",
			"Super Cab/Chassis Pickup",
			"Custom Pickup",
			"Convertible",
			"Cargo Cutaway",
			"Dump Truck",
			"Tractor Truck",
			"Extended Cargo Van",
			"Extended Sport Van",
			"Extended Van",
			"Extended Window Van",
			"Flat-bed or Platform",
			"Forward Control",
			"Fire Truck",
			"Garbage or Refuse",
			"Gliders",
			"Grain",
			"Hatchback",
			"Hopper",
			"Hearse",
			"Hardtop",
			"Incomplete Chassis",
			"Incomplete Extended Van",
			"Liftback",
			"Logger",
			"Suburban & Carry All",
			"Limousine",
			"Motorized Home",
			"Multi-purpose",
			"Maxi-Van",
			"Motorized Cutaway",
			"Notchback",
			"Club Cab Pickup",
			"Parcel Delivery",
			"Pickup",
			"Pickup with Camper",
			"Panel",
			"Super Cab Pickup",
			"Roadster",
			"One Seat",
			"Two Seat",
			"Sport Hatchback",
			"Sport Coupe",
			"Sedan",
			"Step Van",
			"Sport Pickup",
			"Stake or Rack",
			"Sport Van",
			"Station Wagon",
			"Tilt Cab",
			"Tilt Tandem",
			"Tandem",
			"Tank",
			"Tractor Truck",
			"Utility",
			"Van Camper",
			"Display Van",
			"Van",
			"Vanette",
			"Window Van",
			"Tow Truck Wrecker",
			"Wide Wheel Wagon",
			"Travelall",
			"Cutaway",
			"Crew Pickup"
		};

    public static readonly string[] CarBodyChars =
		{
			"2D",
			"2F",
			"2H",
			"2L",
			"2P",
			"2T",
			"2W",
			"3D",
			"3B",
			"3C",
			"4D",
			"4B",
			"4C",
			"4H",
			"4L",
			"4P",
			"4T",
			"4W",
			"5D",
			"8V",
			"AC",
			"AM",
			"AR",
			"BU",
			"CB",
			"CC",
			"CG",
			"CH",
			"CL",
			"CM",
			"CP",
			"CR",
			"CS",
			"CU",
			"CV",
			"CY",
			"DP",
			"DS",
			"EC",
			"ES",
			"EV",
			"EW",
			"FB",
			"FC",
			"FT",
			"GG",
			"GL",
			"GN",
			"HB",
			"HO",
			"HR",
			"HT",
			"IC",
			"IE",
			"LB",
			"LG",
			"LL",
			"LM",
			"MH",
			"MP",
			"MV",
			"MY",
			"NB",
			"PC",
			"PD",
			"PK",
			"PM",
			"PN",
			"PS",
			"RD",
			"S1",
			"S2",
			"SB",
			"SC",
			"SD",
			"SN",
			"SP",
			"ST",
			"SV",
			"SW",
			"TB",
			"TL",
			"TM",
			"TN",
			"TR",
			"UT",
			"VC",
			"VD",
			"VN",
			"VT",
			"VW",
			"WK",
			"WW",
			"XT",
			"YY",
			"CW"
		};

    public static readonly string[] VehicleUsageNames =
		{
			"Artisan Use",
			"Business Use",
			"Farm",
			"Pleasure",
			"Work/School"
		};

    public static readonly string[] GLVehicleUsageNames =
		{
			"GlArtisanUse",
			"GlBusinessUse",
			"GlFarm",
			"GlPleasure",
			"GlWorkSchool"
		};

    public static readonly string[] VehicleUsageChars =
		{
			"A",
			"B",
			"F",
			"P",
			"W"
		};

    public const int MaxLienHolders = 2;

    public static readonly USState[] TortStates =
		{
      USState.NewJersey,
			USState.Pennsylvania
		};

    public static readonly string[] MICollTypeNames =
		{
			"Broad Form",
			"Standard",
			"Limited"
		};

    public static readonly string[] MICollTypeChars =
		{
			"B",
			"S",
			"L"
		};

    public static readonly string[] COPIPTypeNames =
		{
			"Basic",
			"Limited",
			"Option 1/Addl Med",
			"Option 2/Addl Med/Work Loss",
			"Option 3/Addl Work Loss"
		};

    public static readonly string[] COPIPTypeChars =
		{
			"B",
			"L",
			"O",
			"T",
			"W"
		};

    public static readonly string[] KYPIPTypeNames =
    {
      "PIP",
      "Buy-back",
      "Guest",
      "None"
    };

    public static readonly string[] KYPIPTypeChars =
    {
      "P",
      "B",
      "G",
      "N"
    };

    public static readonly string[] FLPIPDedOptionNames =
		{
			"NI",
			"NIRR"
		};

    public static readonly string[] FLPIPDedOptionChars =
		{
			"I",
			"R"
		};

    public static readonly string[] MIPIPTypeNames =
		{
      "Primary",
      "Excess Medical",
      "Excess Work Loss",
      "Excess Both"
		};

    public static readonly string[] MIPIPTypeChars =
		{
      "P",
      "M",
      "W",
      "B"
		};

    public static readonly string[] MIPIPWorkLossRejectionChars = 
    {
      "N",   // Work loss not rejected.
      "I",   // Rejection of work loss by named insured.
      "R"    // Rejection of work loss by named insured and members of household.
    };

    public static readonly string[] MIPIPWorkLossRejectionStrings = 
    {
      "Work Loss Included",          // Work loss not rejected.
      "Named Insured",               // Rejection of work loss by named insured.
      "Named Insured & Household"    // Rejection of work loss by named insured and members of household.
    };

    public static readonly string[] MDPIPTypeNames =
		{
      "PIP",
      "Guest"
		};

    public static readonly string[] MDPIPTypeChars =
		{
      "A",  // Full
      "G"   // Guest
		};

    public static readonly string[] FLPIPTypeNames =
		{
			"Basic",
			"Extended"
		};

    public static readonly string[] FLPIPTypeChars =
		{
			"B",
			"E"
		};

    public static readonly string[] ORPIPDedOptionChars =
		{
			"I",
			"R"
		};

    public static readonly string[] ORPIPDedOptionNames =
		{
			"NI",
			"NIRR"
		};

    public static readonly string[] MedicalExpenseLevelNames =
		{
			"No Medical Expense",
			"Insured Only",
			"Household"
		};

    public static readonly string[] MedicalExpenseLevelChars =
		{
			"N",
			"1",
			"2"
		};

    public static readonly string[] ResidencyTypeNames =
		{
			"Home",
			"Apartment",
			"Condo",
			"Mobile Home",
			"Fixed Mobile Home"
		};

    public static readonly string[] ResidencyTypeChars =
		{
			"H",
			"A",
			"C",
			"M",
			"F"
		};

    public static readonly string[] ResidencyStatusNames =
		{
			"Own",
			"Rent",
			"Lease"
		};

    public static readonly string[] ResidencyStatusChars =
		{
			"O",
			"R",
			"L"
		};

    public static readonly string[] PriorTransferLevelNames =
		{
			"No Prior Transfer",
			"Prior Transfer Level 1",
			"Prior Transfer Level 2",
			"Prior Transfer Level 3",
			"Prior Transfer Level 4",
			"Prior Transfer Level 5",
			"Prior Transfer Level 6",
			"Prior Transfer Level 7",
			"Prior Transfer Level 8",
			"Prior Transfer Level 9"
		};

    public static readonly string[] PriorTransferLevelChars =
		{
			"N",
			"1",
			"2",
			"3",
			"4",
			"5",
			"6",
			"7",
			"8",
			"9"
		};

    public static readonly string[] MotorcycleBodyChars =
		{
			"AT",  // All Terrain
			"EN",  // Enduro
			"MK",  // Mini Bike
			"MM",  // Mini Motocross
			"MP",  // Moped
			"MR",  // Mini Road/Trail
			"MS",  // Motor Scooter
			"MX",  // Motocross
			"MY",  // Mini Cycle
			"RC",  // Racer
			"RS",  // Road/Street
			"RT",  // Road/Trail
			"T",   // Dirt
			"TL",  // Trail/Dirt
			"TR"   // Trail
    };

    public static readonly string[] MotorcycleClubNames =
    {
      "None",
      "AAA Roadside Member",
      "Abate",
      "Active or Retired Sworn Law Enforcement",
      "All-Terrain Vehicle Association",
      "American Gold Wing Association",
      "ALR (American Legion Riders)",
      "AMA (American Motorcycle Association)",
      "ARM",
      "American Voyager Association",
      "Armed Forces Member-Active or Retired",
      "Bike Bandit",
      "Bikernet Cantina Member ",
      "Blue Knights",
      "BMW Motorcycle Owners of America",
      "Brotherhood Aiming Toward Education",
      "Buell Riders Adventure Group",
      "CA-NV Snowmobile Association",
      "Cantina Member",
      "Christian Motorcycle Association",
      "Concours Owners Group",
      "Cycle World",
      "Desmo Owners Club",
      "Donahue Super Sports",
      "Ducati Desmo Club",
      "Ducati Desmo Owners",
      "Ducati Unlimited Connection",
      "FORR (Freedom of Road Riders)",
      "Gold Wing Road Riders Association",
      "Gold Wing Touring Association",
      "Harley Owners Group",
      "Honda Riders Association",
      "Honda Rider's Club of America",
      "Indian Riders Association",
      "Indian Riders Group",
      "Intl Star Riders Association",
      "Jesters Group",
      "JPMC (Johnny Pag MC)",
      "Legion Riders",
      "Liberty",
      "Lehman Pride",
      "Liberty Waves Group",
      "McCom",
      "Moto Guzzi National Owners Club",
      "Motorcycle.com Member",
      "Motorcycle Safety Foundation Instructor",
      "MSF Instructor",
      "MVP Member",
      "Other",
      "Rat",
      "Red Knights",
      "Rider's Association of Triumph",
      "Riders of Kawasaki",
      "Royal Star Touring and Riding Association",
      "SCOT (Scoot Club)",
      "Sentry Employees",
      "Serg",
      "Shriners",
      "Sparta",
      "STAR Touring and Riding Association",
      "Suzuki Owners Club",
      "Suzuki Owner's Club of America",
      "Sworn Law Enforcement",
      "USCA (United Sidecar Association)",
      "Watva",
      "Venturers Motorycle Club",
      "Venture Touring Society",
      "Victory Riders Association",
      "VMax Owners Association",
      "VRA (Vulcan Riders Association)",
      "VTS (Venture Touring Society)",
      "Vulcan Bagger Association",
      "Wind & Fire MC",
      "WOW (Women on Wheels)",
      "ZNTI (Zanotti Loyalty Member)"
    };

    public const int vcConsumingAlcohol = 1;      //  CONSUMING ALCOHOL WHILE DRIVING                  Alcohol
    public const int vcDrvBusWhileIntox = 2;      //  DRIVING SCHOOL BUS WHILE INTOXICATED             Alcohol
    public const int vcDUI = 3;      //  DUI ALCOHOL/LIQUOR                               Alcohol              Blood Alcohol
    public const int vcDWAI = 4;      //  DWAI                                             Alcohol              Blood Alcohol
    public const int vcDWI = 5;      //  DWI                                              Alcohol              Blood Alcohol
    public const int vcEdProgRequired = 6;      //  EDUCATIONAL PROGRAM REQUIRED (ARD)               Alcohol
    public const int vcIllegalTransport = 7;      //  ILLEGAL TRANSPORTATION OF ALCOHOL                Alcohol
    public const int vcImpliedConsent = 8;      //  IMPLIED CONSENT/REFUSE BREATH TEST               Alcohol
    public const int vcOpenContainer = 9;      //  OPEN CONTAINER VIOLATION                         Alcohol
    public const int vcOperWhileIntox = 10;      //  OWI                                              Alcohol
    public const int vcLiquorViol = 11;      //  VIOLATION OF LIQUOR LAW                          Alcohol
    public const int vcPedAcc = 12;      //  ACC., WITH PEDESTRIAN                            AtFault              Bodily Injury
    public const int vcAccAtFault = 13;      //  ACCIDENT, AT-FAULT                               AtFault              Bodily Injury
    public const int vcHomocide = 14;      //  HOMICIDE WITH A MOTOR VEHICLE                    Death
    public const int vcManslaughter = 15;      //  VEHICULAR MANSLAUGHTER                           Death
    public const int vcDUID = 16;      //  DUI DRUGS/OPIATES                                Drug
    public const int vcPossessionofSubst = 17;      //  POSSESSION OF CONTROLLED SUBSTANCE               Drug
    public const int vcHeadlightViol = 18;      //  LIGHT VIOLATIONS (HEAD, TAIL, ETC...)            Equipment
    public const int vcMotorcycleEquipViol = 19;      //  MOTORCYCLE EQUIPMENT VIOLATION                   Equipment
    public const int vcDefectiveEquip = 20;      //  OPERATING WITH DEFECTIVE EQUIPMENT               Equipment
    public const int vcOverheight = 21;      //  OVERHEIGHT VEHICLE                               Equipment
    public const int vcOverlength = 22;      //  OVERLENGTH VEHICLE                               Equipment
    public const int vcChangedLanesUnsafe = 23;      //  CHANGED LANES WHEN UNSAFE                        Lane
    public const int vcCrossingCenterMed = 24;      //  CROSSING CENTER MEDIAN                           Lane
    public const int vcCrossingDividedHwy = 25;      //  CROSSING DIVIDED HIGHWAY                         Lane
    public const int vcCrossingYellowLine = 26;      //  CROSSING YELLOW LINE                             Lane
    public const int vcDisregardNoPassZone = 27;      //  DISREGARD NO PASSING ZONE                        Lane
    public const int vcDrvOnLeftSide = 28;      //  DRIVING ON LEFT SIDE OF ROADWAY                  Lane
    public const int vcDrvOnShoulder = 29;      //  DRIVING ON SHOULDER                              Lane
    public const int vcDrvOnSidewalk = 30;      //  DRIVING ON SIDEWALK OR PARKWAY                   Lane
    public const int vcFailKeepRight = 31;      //  FAILURE TO KEEP RIGHT                            Lane
    public const int vcIllegalPass = 32;      //  ILLEGAL PASS ON RIGHT                            Lane
    public const int vcImproperMerging = 33;      //  IMPROPER MERGING INTO TRAFFIC                    Lane
    public const int vcImproperPass = 34;      //  IMPROPER PASSING                                 Lane
    public const int vcPassSchoolBus = 35;      //  IMPROPER PASSING OF A SCHOOL BUS                 Lane
    public const int vcImproperLaneUse = 36;      //  IMPROPER USE OF LANE                             Lane
    public const int vcOperWhereProhib = 37;      //  OPERATING WHERE PROHIBITED                       Lane
    public const int vcAllowUnlicensed = 38;      //  ALLOW UNLICENSED DRIVER TO DRIVE                 License
    public const int vcAlteredDL = 39;      //  DISPLAY ALTERED/COUNTERFEIT DL                   License
    public const int vcDisplayAnothersDL = 40;      //  DISPLAY ANOTHER PERSON'S DL                      License
    public const int vcLicSuspended = 41;      //  DRIVING WHILE SUSPENDED OR REVOKED               License
    public const int vcExpired = 42;      //  DRIVING WITH AN EXPIRED LICENSE                  License
    public const int vcNoLicense = 43;      //  DRIVING WITHOUT A LICENSE OR PERMIT              License
    public const int vcDuplicateDL = 44;      //  DUPLICATE DRIVERS LICENSE                        License
    public const int vcFailDisplayDL = 45;      //  FAIL TO DISPLAY DL                               License
    public const int vcFalseLicense = 46;      //  FALSE LICENSE OR REGISTRATION                    License
    public const int vcLoanedDL = 47;      //  LOANED DL TO ANOTHER PERSON                      License
    public const int vcNoChaufferLicense = 48;      //  NO CHAUFFEURS LICENSE                            License
    public const int vcNoDL = 49;      //  NO DRIVERS LICENSE                               License
    public const int vcNoMotorcycleQualif = 50;      //  NO MOTORCYCLE QUALIFICATION                      License
    public const int vcObtainByMisrep = 51;      //  OBTAINING LICENSE BY MISREPRESENTING             License
    public const int vcOperDuringSusp = 52;      //  OPERATING DURING LIFE SUSPENSION                 License
    public const int vcOperateOutOfClass = 53;      //  OPERATING OUT OF CLASS                           License
    public const int vcChargeableSuspension = 54;      //  SUSPENSION (Chargeable)                          License
    public const int vcViolateDLRestrict = 55;      //  VIOLATE DL RESTRICTION                           License
    public const int vcPermitViol = 56;      //  VIOLATION OF INSTRUCTION PERMIT                  License
    public const int vcNoLights = 57;      //  DRIVING AT NIGHT WITHOUT LIGHTS                  Light
    public const int vcFailDimHeadLights = 58;      //  FAILURE TO DIM HEADLIGHTS                        Light
    public const int vcAccNotAtFault = 59;      //  ACCIDENT, NOT AT-FAULT                           NoFault
    public const int vcDisobeyPolice = 60;      //  DISOBEY POLICE ORDER                             Police
    public const int vcEludPolice = 61;      //  ELUDING POLICE/EVADING ARREST                    Police
    public const int vcAvoidTrafficControl = 62;      //  AVOIDING TRAFFIC-CONTROL DEVICE                  Signal
    public const int vcFailToGiveSignal = 63;      //  FAIL TO GIVE STOP OR TURN SIGNAL                 Signal
    public const int vcFailToStopForTrain = 64;      //  FAIL TO STOP FOR APPROACHING TRAIN               Signal
    public const int vcFailObeyRailRoad = 65;      //  FAIL TO STOP FOR RAILROAD CROSSING               Signal
    public const int vcRunRedLight = 66;      //  FAIL TO STOP FOR RED LIGHT                       Signal
    public const int vcRunStopSign = 67;      //  FAIL TO STOP FOR STOP SIGN                       Signal
    public const int vcFailYieldPedestrian = 68;      //  FAIL TO YIELD (PEDESTRIAN)                       Signal
    public const int vcFailRightOfWay = 69;      //  FAIL TO YIELD RIGHT OF WAY                       Signal
    public const int vcFailEmergencyVeh = 70;      //  FAIL TO YIELD TO EMERGENCY VEHICLE               Signal
    public const int vcImproperSignal = 71;      //  GIVING IMPROPER SIGNAL                           Signal
    public const int vcTooFast = 72;      //  DRIVING TOO FAST FOR CONDITIONS                  Speed
    public const int vcTooSlowForConditions = 73;      //  DRIVING TOO SLOW FOR CONDITIONS                  Speed
    public const int vcDrvUnderMinimum = 74;      //  DRV UNDER MINIMUM SPEED LIMIT                    Speed
    public const int vcExcessAcceleration = 75;      //  EXCESSIVE ACCELERATION                           Speed
    public const int vcFailControlSpeed = 76;      //  FAIL TO CONTROL SPEED                            Speed
    public const int vcRacing = 77;      //  RACING/SPEED CONTEST                             Speed
    public const int vcSpeeding = 78;      //  SPEEDING                                         Speed                Mile Over Limit
    public const int vcSpeedSchoolZone = 79;      //  SPEEDING IN A SCHOOL ZONE                        Speed
    public const int vcUnsafeSpeed = 80;      //  UNSAFE SPEED                                     Speed
    public const int vcImproperStart = 81;      //  IMPROPER START                                   Start
    public const int vcSquealingTires = 82;      //  SQUEALING OR SCREECHING TIRES                    Start
    public const int vcUnsafeStart = 83;      //  UNSAFE START,PARK,STOP,STANDING                  Start
    public const int vcImproperTowing = 84;      //  IMPROPER TOWING OR PUSHING OF VEHICLE            Tow
    public const int vcTurnedAcrossDivided = 85;      //  TURNED ACROSS DIVIDED SECTION                   Turn
    public const int vcTurnedWhenUnsafe = 86;      //  TURNED WHEN UNSAFE                               Turn
    public const int vcDriveLeftOfCenter = 87;      //  DRIVE LEFT OF CENTER                             Wrong
    public const int vcWrongSideOfRoad = 88;      //  DRIVING ON WRONG SIDE OF ROAD                    Wrong
    public const int vcWrongWayOnOneway = 89;      //  DROVE WRONG WAY ON ONE-WAY                       Wrong
    public const int vcWrongWayIsland = 90;      //  WRONG DIRECTION AROUND TRAFFIC ISLAND            Wrong
    public const int vcWrongWayOnRoadway = 91;      //  WRONG DIRECTION DIVIDED STREET                   Wrong
    public const int vcAssaultWAuto = 92;      //  AGGRAVATED ASSAULT WITH AN AUTO
    public const int vcMiscMovingViol = 93;      //  ALL OTHER MOVING VIOLATIONS
    public const int vcMiscNonMovingViol = 94;      //  ALL OTHER NON-MOVING VIOLATIONS
    public const int vcAlteredVIN = 95;      //  ALTERED OR FORGED VIN
    public const int vcImproperBacking = 96;      //  BACKING IMPROPERLY
    public const int vcCarPoolViol = 97;      //  BUS/CAR POOL/ HOV - LANE VIOLATION
    public const int vcCarelessDriving = 98;     //  CARELESS AND IMPRUDENT DRIVING
    public const int vcChangeDriverMoving = 99;     //  CHANGING DRIVER IN MOVING VEHICLE
    public const int vcCoasting = 100;     //  COASTING WITH GEARS DISENGAGED
    public const int vcConvictionInsFraud = 101;     //  CONVICTION OF INSURANCE FRAUD
    public const int vcCriminalNegligence = 102;     //  CRIMINAL NEGLIGENCE
    public const int vcDisregardSafety = 103;     //  DISREGARD OF SAFETY
    public const int vcDriversViewObstruct = 104;     //  DRIVERS VIEW OBSTRUCTED
    public const int vcDriveOnFireHose = 105;     //  DRIVING OVER FIRE HOSE
    public const int vcDrvInSafetyZone = 106;     //  DRIVING THROUGH SAFETY ZONE
    public const int vcDrivingWOConsent = 107;     //  DRIVING W/O OWNERS CONSENT
    public const int vcFailControlVehicle = 108;     //  FAIL TO CONTROL VEHICLE
    public const int vcFailToExchangeInfo = 109;     //  FAIL TO EXCHANGE INFO AFTER ACCIDENT
    public const int vcNoPayToll = 110;     //  FAIL TO PAY TOLL
    public const int vcFailToWearBelt = 111;     //  FAIL TO WEAR SEAT BELT
    public const int vcFailureOfDuty = 112;     //  FAILURE OF DUTY
    public const int vcFailSoundHorn = 113;     //  FAILURE TO SOUND HORN
    public const int vcFelony = 114;     //  FELONY INVOLVING A MOTOR VEHICLE
    public const int vcFollowingImproper = 115;     //  FOLLOWING IMPROPERLY
    public const int vcFollowingTooClose = 116;     //  FOLLOWING TOO CLOSE
    public const int vcImpedingTraffic = 117;     //  IMPEDING TRAFFIC MOVEMENT
    public const int vcImproperDriving = 118;     //  IMPROPER DRIVING
    public const int vcBadTurnpikeStyle = 119;     //  IMPROPER ENTERING/LEAVING TURNPIKE
    public const int vcIncreaseWhilePassed = 120;     //  INCREASE SPEED WHILE BEING PASSED
    public const int vcUnattendedCar = 121;     //  LEAVE VEHICLE WITH ENGINE RUNNING
    public const int vcLeavingScene = 122;     //  LEAVING SCENE  /  HIT-AND-RUN
    public const int vcMVIViolation = 123;     //  MOTOR VEHICLE INSPECTION VIOL.
    public const int vcNegligentCollision = 124;     //  NEGLIGENT COLLISION
    public const int vcNegligentDriving = 125;     //  NEGLIGENT DRIVING
    public const int vcNoLiabInsurance = 126;     //  NO LIABILITY INSURANCE IN FORCE
    public const int vcParkingOnRoadway = 127;     //  PARKING ON ROADWAY
    public const int vcProhibUTurn = 128;     //  PROHIBITED U TURN
    public const int vcProtectiveHeadGear = 129;     //  PROTECTIVE HEAD GEAR VIOLATION
    public const int vcReckless = 130;     //  RECKLESS DRIVING
    public const int vcStealingAuto = 131;     //  STEALING AUTO
    public const int vcUnrestrainedChild = 132;     //  UNRESTRAINED CHILD                                                    Child Age
    public const int vcUnsafeOperator = 133;     //  UNSAFE OPERATOR
    public const int vcEmissionsViol = 134;     //  VEHICLE EMISSIONS SUSPENSION
    public const int vcVehiclularInjury = 135;     //  VEHICULAR INJURY
    public const int vcViolSafetyZone = 136;     //  VIOLATING SAFETY ZONE
    public const int vcViolatePromiseAppear = 137;     //  VIOLATION OF PROMISE TO APPEAR
    public const int vcCompClaim = 138;     //  COMPREHENSIVE CLAIM                                                   CLAIM AMOUNT
    public const int vcAllowUnlawfulOperation = 139;     //  Allow unlawful operation of vehicle
    public const int vcUMClaim = 140;     //  UM CLAIM                                                   CLAIM AMOUNT
    public const int vcUIMClaim = 141;     //  UIM CLAIM                                                  CLAIM AMOUNT
    public const int vcMedPayClaim = 142;     //  MED PAY CLAIM                                              CLAIM AMOUNT
    public const int vcPIPClaim = 143;
    public const int vcDrivingWOutHandsFree = 144;
    public const int vcTextingWhileDriving = 145;
    public const int vcIgnitionInterlock = 146;

    public const int vcAccidentWithPedestrian = 501;
    public const int vcAccidentAtFaultNoInjury = 502;
    public const int vcAccidentAtFaultInjury = 503;
    public const int vcFailureToReportAccident = 504;
    public const int vcAccidentNotAtFault = 505;
    public const int vcAggravatedAssaultWithAuto = 506;
    public const int vcAllOtherMovingViolations = 507;
    public const int vcAllOtherNonMovingViolations = 508;
    public const int vcAllowUnlawfulOperationOfVehicle = 509;
    public const int vcAllowUnlicensedDriver = 510;
    public const int vcAlteredForgedVIN = 511;
    public const int vcFailureToObeyTrafficDevice = 512;
    public const int vcUnsafeStartingBacking = 513;
    public const int vcDiamondLane = 514;
    public const int vcDiamondLaneCrossDoubleLine = 515;
    public const int vcCACarelessDriving = 516;
    public const int vcUnsafeLaneChange = 517;
    public const int vcChangingDriverMovingVehicle = 518;
    public const int vcCoastingGearsDisengaged = 519;
    public const int vcComprehensiveClaim = 520;
    public const int vcConsumingAlcoholWhileDriving = 521;
    public const int vcConvictionOfInsuranceFraud = 522;
    public const int vcCACriminalNegligence = 523;
    public const int vcCrossingCenterMedian = 524;
    public const int vcCrossingDividedHighway = 525;
    public const int vcCACrossingYellowLine = 526;
    public const int vcDisobeyPoliceOfficer = 527;
    public const int vcDisobeyTollHighwayOfficer = 528;
    public const int vcDisplayAlteredCounterfeitLicense = 529;
    public const int vcDisplayOtherPersonsLicense = 530;
    public const int vcDisregardNoPassingZone = 531;
    public const int vcDisregardOfSafety = 532;
    public const int vcDrivingLeftOfCenter = 533;
    public const int vcDriversViewObstructed = 534;
    public const int vcDrivingAtNightWithoutLights = 535;
    public const int vcDrivingOnLeftSideOfRoadway = 536;
    public const int vcDrivingOnShoulder = 537;
    public const int vcDrivingOnSidewalk = 538;
    public const int vcDrivingWrongSideOfRoad = 539;
    public const int vcDrivingOverFireHose = 540;
    public const int vcDrivingSchoolBusWhileIntoxicated = 541;
    public const int vcDrivingThroughSafetyZone = 542;
    public const int vcDrivingTooFastForConditions = 543;
    public const int vcDrivingTooSlowForConditions = 544;
    public const int vcDrivingWithoutOwnersConsent = 545;
    public const int vcDrivingWhileSuspendedRevoked = 546;
    public const int vcDrivingWithExpiredLicense = 547;
    public const int vcDrivingWithoutLicensePermit = 548;
    public const int vcDrivingWrongWayOneWay = 549;
    public const int vcDrivingWrongSideDividedHighway = 550;
    public const int vcDrivingUnderMinimum = 551;
    public const int vcDUIAlcoholDrugsNoInjury = 552;
    public const int vcDUIAlcoholDrugsInjuryOrDeath = 553;
    public const int vcMinorWithBACOverZeroFive = 554;
    public const int vcMinorWithBACOverZeroOne = 555;
    public const int vcDuplicateDriversLicense = 556;
    public const int vcEducationProgramRequired = 557;
    public const int vcEvadingPeaceOfficer = 558;
    public const int vcEvadingPeaceOfficerReckless = 559;
    public const int vcEvadingPeaceOfficerInjury = 560;
    public const int vcExcessiveAcceleration = 561;
    public const int vcFailToControlSpeed = 562;
    public const int vcFailToControlVehicle = 563;
    public const int vcFailToDisplayDriversLicense = 564;
    public const int vcFailToExchangeInformation = 565;
    public const int vcImproperTurnNoSignal = 566;
    public const int vcVehicleXingEvadingToll = 567;
    public const int vcFailToStopApproachingTrain = 568;
    public const int vcStopRequiredRailroadCrossing = 569;
    public const int vcFailToStopRedLight = 570;
    public const int vcFailToStopStopSign = 571;
    public const int vcFailToWearSeatBelt = 572;
    public const int vcYieldingRightOfWayPedestrian = 573;
    public const int vcFailureToYieldRightOfWay = 574;
    public const int vcFailureToYieldEmergencyVehicle = 575;
    public const int vcFailureOfDutyInjuryOrDeath = 576;
    public const int vcFailureToDimLights = 577;
    public const int vcFailureToKeepRight = 578;
    public const int vcFailureToSoundHorn = 579;
    public const int vcFalseEvidenceOfRegistration = 580;
    public const int vcFelonyInvolvingMotorVehicle = 581;
    public const int vcFollowingImproperly = 582;
    public const int vcFollowingTooClosely = 583;
    public const int vcDistanceBetweenVehicles = 584;
    public const int vcGivingImproperSignal = 585;
    public const int vcHomicideWithMotorVehicle = 586;
    public const int vcPassingOnRightOrShoulder = 587;
    public const int vcIllegalTransportationOfAlcohol = 588;
    public const int vcImpedingTrafficMovement = 589;
    public const int vcRefusalToSubmitToTest = 590;
    public const int vcCAImproperDriving = 591;
    public const int vcFreewayRampEnteringExiting = 592;
    public const int vcImproperMergingIntoTraffic = 593;
    public const int vcIllegalImproperUnsafePassing = 594;
    public const int vcStopForSchoolBus = 595;
    public const int vcCAImproperStart = 596;
    public const int vcImproperTowingRiding = 597;
    public const int vcCAImproperLaneUse = 598;
    public const int vcIncreaseSpeedWhileBeingPassed = 599;
    public const int vcLeaveEngineRunning = 600;
    public const int vcHitAndRunInjury = 601;
    public const int vcHitAndRunNoInjury = 602;
    public const int vcLightViolations = 603;
    public const int vcLoanLicenseToOther = 604;
    public const int vcClaimMedicalPayments = 605;
    public const int vcMotorVehicleInspection = 606;
    public const int vcMotorcyclePassengersEquipment = 607;
    public const int vcCANegligentCollision = 608;
    public const int vcCANegligentDriving = 609;
    public const int vcNoChauffeursLicense = 610;
    public const int vcNoDriversLicense = 611;
    public const int vcNoLiabilityInsurance = 612;
    public const int vcNoMotorcycleQualification = 613;
    public const int vcObtainLicenseByMisrepresentation = 614;
    public const int vcOpenContainerDriving = 615;
    public const int vcOpenContainerPossession = 616;
    public const int vcOperatingDuringLifeSuspension = 617;
    public const int vcOperatingOutOfClassification = 618;
    public const int vcOperatingWhereProhibited = 619;
    public const int vcUnsafeUnlawfullyEquippedVehicle = 620;
    public const int vcOverheightVehicle = 621;
    public const int vcOverlengthVehicle = 622;
    public const int vcCAParkingOnRoadway = 623;
    public const int vcPossessionControlledSubstance = 624;
    public const int vcIllegalTurnUTurn = 625;
    public const int vcIllegalTurnUTurnAtIntersection = 626;
    public const int vcCAProtectiveHeadGear = 627;
    public const int vcSpeedContestExhibitionOfSpeed = 628;
    public const int vcSpeedContestAidingAndAbetting = 629;
    public const int vcRecklessDrivingNoInjury = 630;
    public const int vcRecklessDrivingInjury = 631;
    public const int vcSpeeding65AndUnder = 632;
    public const int vcSpeedingOver65 = 633;
    public const int vcSpeedingOver100 = 634;
    public const int vcSpeedingTruckTractor = 635;
    public const int vcSpeedingConstructionZone = 636;
    public const int vcSpeedingWhileTowing = 637;
    public const int vcCommercialSpeedVehicle = 638;
    public const int vcSpeedingInSchoolZone = 639;
    public const int vcSquealingScreechingTires = 640;
    public const int vcCAStealingAuto = 641;
    public const int vcSuspensionChargeable = 642;
    public const int vcTurnAcrossDividedSection = 643;
    public const int vcUnsafeTurn = 644;
    public const int vcClaimUIM = 645;
    public const int vcClaimUM = 646;
    public const int vcChildPassengerRestraint = 647;
    public const int vcCAUnsafeOperator = 648;
    public const int vcRestrictedSpeedWeatherConditions = 649;
    public const int vcUnsafeStartParkStopStanding = 650;
    public const int vcVehicleEmissionsSuspension = 651;
    public const int vcVehicularInjury = 652;
    public const int vcVehicularManslaughterGrossNegligence = 653;
    public const int vcVehicularManslaughterNoGrossNegligence = 654;
    public const int vcViolationOfLicenseRestrictions = 655;
    public const int vcDrivingHoursEquipmentMaintenanceOperation = 656;
    public const int vcPermitDriverOutOfClassification = 657;
    public const int vcDrinkingInVehicle = 658;
    public const int vcPossessionOfAlcohol = 659;
    public const int vcViolationOfPromiseToAppear = 660;
    public const int vcWrongDirectionAroundTrafficIsland = 661;
    public const int vcWrongDirectionDividedStreet = 662;
    public const int vcClaimLiability = 663;
    public const int vcClaimCollision = 664;
    public const int vcClaimTowing = 665;
    public const int vcViolationOfSuspensionDUI = 666;
    public const int vcViolationOfRestrictionDUI = 667;
    public const int vcFalseStatement = 668;
    public const int vcFinancialResponsibility = 669;
    public const int vcBrakes = 670;
    public const int vcLicensePlate = 671;
    public const int vcExhaustModified = 672;
    public const int vcExplosivesTransportation = 673;
    public const int vcInterfereWithTrafficDevice = 674;
    public const int vcInterfereWithTrafficDeviceInjury = 675;
    public const int vcMaliciousMischiefTampering = 676;
    public const int vcMaliciousActsBodilyHarm = 677;
    public const int vcMaliciousActsRemoveMarker = 678;
    public const int vcThrowingSubstance = 679;
    public const int vcThrowingSubstanceInjury = 680;
    public const int vcThrowingLightedSubstance = 681;
    public const int vcThrowingMatterOnHighway = 682;
    public const int vcDisobeyConstructionSigns = 683;
    public const int vcPassingAnimals = 684;
    public const int vcPassCarStoppedForPedestrian = 685;
    public const int vcMaximumDesignatedSpeedVehicle = 686;
    public const int vcStopAtInoperativeSignal = 687;
    public const int vcTurnProhibitedBySign = 688;
    public const int vcTurnOnRedLight = 689;
    public const int vcUseOfTwoWayLeftTurnLane = 690;
    public const int vcTurnAcrossBicycleLane = 691;
    public const int vcYieldOnLeftTurn = 692;
    public const int vcYieldRightOfWayToBlindPedestrian = 693;
    public const int vcYieldWhenOvertaken = 694;
    public const int vcTranportingPersonInTruckLoadSpace = 695;
    public const int vcUnsafeOverweightLoad = 696;
    public const int vcUnsafeLoadNoPermit = 697;
    public const int vcEnterIntersectionWithoutSpace = 698;
    public const int vcTurnAtIntersectionWithoutSpace = 699;
    public const int vcAlteredLicensePlates = 700;
    public const int vcDoubleLinesOneBrokenLine = 701;
    public const int vcDrivingWithParkingLights = 702;
    public const int vcEnteringHighwayFromServiceRoad = 703;
    public const int vcOnRampExit = 704;
    public const int vcOpenDoor = 705;
    public const int vcRightOfOncomingVehicle = 706;
    public const int vcThreeLaneHighway = 707;
    public const int vcViolatingPromiseToCorrect = 708;
    public const int vcUsingWirelessPhone = 709;
    public const int vcUsingWirelessPhoneUnder18 = 710;
    public const int vcTexting = 711;
    public const int vcTurnLaneUse = 712;
    public const int vcYieldToVehicleInIntersection = 713;
    public const int vcFailureToStop = 714;
    public const int vcDUIDrugsNoInjury = 715;
    public const int vcFailToYieldEnteringHighway = 716;
    public const int vcInsufficientSpaceAtRRCrossing = 717;
    public const int vcCommercialSpeed = 718;
    public const int vcDrivingUnregistered = 719;
    public const int vcLighting = 720;
    public const int vcOtherEquipment = 721;
    public const int vcTransportingExplosives = 722;
    public const int vcPassingSubjectToSection = 723;
    public const int vcOtherYield = 724;
    public const int vcSpillingLoad = 725;
    public const int vcCommercialChargeable = 726;
    public const int vcCommercialChargeableMoving = 727;
    public const int vcCommercialNonChargeable = 728;
    public const int vcCommercialNonChargeableMoving = 729;
    public const int vcDrivingOnLevee = 730;
    public const int vcProhibitedBikePath = 731;
    public const int vcCoastingProhibited = 732;
    public const int vcRidingInTrailer = 733;
    public const int vcOperatingGolfCartOnHighway = 734;
    public const int vcClaimPIP = 735;
    public const int vcFailIgnitionInterlock = 736;

    public const int vcFirstViolCode = 1;
    public const int vcCAFirstViolCode = vcAccidentWithPedestrian;
    public const int vcLastViolCode = vcIgnitionInterlock;
    public const int vcCALastViolCode = vcFailIgnitionInterlock;
    public const int MaxViolations = vcLastViolCode;
    public const int CAMaxViolations = vcCALastViolCode;

    public const double StateATPAFee = 0.50;

    public static readonly string[] MaritalStatusNames =
		{
			"Married",
			"Single",
			"Divorced",
			"Widowed",
			"Separated",
            "Domestic Partner",
            "CommonLaw"
		};
    public static readonly string[] MaritalStatusChars =
		{
			"M",
			"S",
			"D",
			"W",
			"E",
            "C",
            "L"
		};

    public static readonly string[] TruckSizeChars =
  {
    "1",
    "2",
    "3",
    "F",
    "O"
  };

    public static readonly string[] TruckSizeString =
  {
    "Quarter Ton",
    "Half Ton",
    "Three Quarter Ton",
    "One Ton",
    "Over One Ton"
  };

    public static readonly string[] VehicleTypeChars =
  {
    "T",
    "C",
    "S",
    "U",
    "M",
    "V"
  };

    public static readonly string[] VehicleTypeString =
  {
    "Truck",
    "Car",
    "Station Wagon",
    "Utility",
    "Mini Van",
    "Van"
  };

    public static readonly string[] EmploymentTypeString =
  {
    "Employed",
    "Unemployed",
    "Military",
    "Retired",
    "Student",
    "HomeMaker",
    "Self Employed"
  };

    public static readonly string[] EmpoymentTypeChar =
  {
    "E",
    "U",
    "M",
    "R",
    "S",
    "H",
    "F"
  };

    /// <summary>
    /// Given a violation code, returns the string language id.
    /// </summary>
    /// <param name="code">The code to translate.</param>
    /// <param name="state">The state to use (since CO has at least one different viol).</param>
    /// <returns>The language id of the violcation.</returns>
    public static string TranslatedViolLanguageIdByCode(int code, USState state)
    {
      switch (code)
      {
        case 0: return "vcSelectViolation";
        // standard codes
        case AUConstants.vcConsumingAlcohol: return "vcConsumingAlcohol";
        case AUConstants.vcDrvBusWhileIntox: return "vcDrvBusWhileIntox";
        case AUConstants.vcDUI: return "vcDUI";
        case AUConstants.vcDWAI: return state == USState.Colorado ? "vcDefectiveVehicle" : "vcDWAI";
        case AUConstants.vcDWI: return "vcDWI";
        case AUConstants.vcEdProgRequired: return "vcEdProgRequired";
        case AUConstants.vcIllegalTransport: return "vcIllegalTransport";
        case AUConstants.vcImpliedConsent: return "vcImpliedConsent";
        case AUConstants.vcOpenContainer: return "vcOpenContainer";
        case AUConstants.vcOperWhileIntox: return "vcOperWhileIntox";
        case AUConstants.vcLiquorViol: return "vcLiquorViol";
        case AUConstants.vcPedAcc: return "vcPedAcc";
        case AUConstants.vcAccAtFault: return "vcAccAtFault";
        case AUConstants.vcHomocide: return "vcHomocide";
        case AUConstants.vcManslaughter: return "vcManslaughter";
        case AUConstants.vcDUID: return "vcDUID";
        case AUConstants.vcPossessionofSubst: return "vcPossessionofSubst";
        case AUConstants.vcHeadlightViol: return "vcHeadlightViol";
        case AUConstants.vcMotorcycleEquipViol: return "vcMotorcycleEquipViol";
        case AUConstants.vcDefectiveEquip: return "vcDefectiveEquip";
        case AUConstants.vcOverheight: return "vcOverheight";
        case AUConstants.vcOverlength: return "vcOverlength";
        case AUConstants.vcChangedLanesUnsafe: return "vcChangedLanesUnsafe";
        case AUConstants.vcCrossingCenterMed: return "vcCrossingCenterMed";
        case AUConstants.vcCrossingDividedHwy: return "vcCrossingDividedHwy";
        case AUConstants.vcCrossingYellowLine: return "vcCrossingYellowLine";
        case AUConstants.vcDisregardNoPassZone: return "vcDisregardNoPassZone";
        case AUConstants.vcDrvOnLeftSide: return "vcDrvOnLeftSide";
        case AUConstants.vcDrvOnShoulder: return "vcDrvOnShoulder";
        case AUConstants.vcDrvOnSidewalk: return "vcDrvOnSidewalk";
        case AUConstants.vcFailKeepRight: return "vcFailKeepRight";
        case AUConstants.vcIllegalPass: return "vcIllegalPass";
        case AUConstants.vcImproperMerging: return "vcImproperMerging";
        case AUConstants.vcImproperPass: return "vcImproperPass";
        case AUConstants.vcPassSchoolBus: return "vcPassSchoolBus";
        case AUConstants.vcImproperLaneUse: return "vcImproperLaneUse";
        case AUConstants.vcOperWhereProhib: return "vcOperWhereProhib";
        case AUConstants.vcAllowUnlicensed: return "vcAllowUnlicensed";
        case AUConstants.vcAlteredDL: return "vcAlteredDL";
        case AUConstants.vcDisplayAnothersDL: return "vcDisplayAnothersDL";
        case AUConstants.vcLicSuspended: return "vcLicSuspended";
        case AUConstants.vcExpired: return "vcExpired";
        case AUConstants.vcNoLicense: return "vcNoLicense";
        case AUConstants.vcDuplicateDL: return "vcDuplicateDL";
        case AUConstants.vcFailDisplayDL: return "vcFailDisplayDL";
        case AUConstants.vcFalseLicense: return "vcFalseLicense";
        case AUConstants.vcLoanedDL: return "vcLoanedDL";
        case AUConstants.vcNoChaufferLicense: return "vcNoChaufferLicense";
        case AUConstants.vcNoDL: return "vcNoDL";
        case AUConstants.vcNoMotorcycleQualif: return "vcNoMotorcycleQualif";
        case AUConstants.vcObtainByMisrep: return "vcObtainByMisrep";
        case AUConstants.vcOperDuringSusp: return "vcOperDuringSusp";
        case AUConstants.vcOperateOutOfClass: return "vcOperateOutOfClass";
        case AUConstants.vcChargeableSuspension: return "vcChargeableSuspension";
        case AUConstants.vcViolateDLRestrict: return "vcViolateDLRestrict";
        case AUConstants.vcPermitViol: return "vcPermitViol";
        case AUConstants.vcNoLights: return "vcNoLights";
        case AUConstants.vcFailDimHeadLights: return "vcFailDimHeadLights";
        case AUConstants.vcAccNotAtFault: return "vcAccNotAtFault";
        case AUConstants.vcDisobeyPolice: return "vcDisobeyPolice";
        case AUConstants.vcEludPolice: return "vcEludPolice";
        case AUConstants.vcAvoidTrafficControl: return "vcAvoidTrafficControl";
        case AUConstants.vcFailToGiveSignal: return "vcFailToGiveSignal";
        case AUConstants.vcFailToStopForTrain: return "vcFailToStopForTrain";
        case AUConstants.vcFailObeyRailRoad: return "vcFailObeyRailRoad";
        case AUConstants.vcRunRedLight: return "vcRunRedLight";
        case AUConstants.vcRunStopSign: return "vcRunStopSign";
        case AUConstants.vcFailYieldPedestrian: return "vcFailYieldPedestrian";
        case AUConstants.vcFailRightOfWay: return "vcFailRightOfWay";
        case AUConstants.vcFailEmergencyVeh: return "vcFailEmergencyVeh";
        case AUConstants.vcImproperSignal: return "vcImproperSignal";
        case AUConstants.vcTooFast: return "vcTooFast";
        case AUConstants.vcTooSlowForConditions: return "vcTooSlowForConditions";
        case AUConstants.vcDrvUnderMinimum: return "vcDrvUnderMinimum";
        case AUConstants.vcExcessAcceleration: return "vcExcessAcceleration";
        case AUConstants.vcFailControlSpeed: return "vcFailControlSpeed";
        case AUConstants.vcRacing: return "vcRacing";
        case AUConstants.vcSpeeding: return "vcSpeeding";
        case AUConstants.vcSpeedSchoolZone: return "vcSpeedSchoolZone";
        case AUConstants.vcUnsafeSpeed: return "vcUnsafeSpeed";
        case AUConstants.vcImproperStart: return "vcImproperStart";
        case AUConstants.vcSquealingTires: return "vcSquealingTires";
        case AUConstants.vcUnsafeStart: return "vcUnsafeStart";
        case AUConstants.vcImproperTowing: return "vcImproperTowing";
        case AUConstants.vcTurnedAcrossDivided: return "vcTurnedAcrossDivided";
        case AUConstants.vcTurnedWhenUnsafe: return "vcTurnedWhenUnsafe";
        case AUConstants.vcDriveLeftOfCenter: return "vcDriveLeftOfCenter";
        case AUConstants.vcWrongSideOfRoad: return "vcWrongSideOfRoad";
        case AUConstants.vcWrongWayOnOneway: return "vcWrongWayOnOneway";
        case AUConstants.vcWrongWayIsland: return "vcWrongWayIsland";
        case AUConstants.vcWrongWayOnRoadway: return "vcWrongWayOnRoadway";
        case AUConstants.vcAssaultWAuto: return "vcAssaultWAuto";
        case AUConstants.vcMiscMovingViol: return "vcMiscMovingViol";
        case AUConstants.vcMiscNonMovingViol: return "vcMiscNonMovingViol";
        case AUConstants.vcAlteredVIN: return "vcAlteredVIN";
        case AUConstants.vcImproperBacking: return "vcImproperBacking";
        case AUConstants.vcCarPoolViol: return "vcCarPoolViol";
        case AUConstants.vcCarelessDriving: return "vcCarelessDriving";
        case AUConstants.vcChangeDriverMoving: return "vcChangeDriverMoving";
        case AUConstants.vcCoasting: return "vcCoasting";
        case AUConstants.vcConvictionInsFraud: return "vcConvictionInsFraud";
        case AUConstants.vcCriminalNegligence: return "vcCriminalNegligence";
        case AUConstants.vcDisregardSafety: return "vcDisregardSafety";
        case AUConstants.vcDriversViewObstruct: return "vcDriversViewObstruct";
        case AUConstants.vcDriveOnFireHose: return "vcDriveOnFireHose";
        case AUConstants.vcDrvInSafetyZone: return "vcDrvInSafetyZone";
        case AUConstants.vcDrivingWOConsent: return "vcDrivingWOConsent";
        case AUConstants.vcFailControlVehicle: return "vcFailControlVehicle";
        case AUConstants.vcFailToExchangeInfo: return "vcFailToExchangeInfo";
        case AUConstants.vcNoPayToll: return "vcNoPayToll";
        case AUConstants.vcFailToWearBelt: return "vcFailToWearBelt";
        case AUConstants.vcFailureOfDuty: return "vcFailureOfDuty";
        case AUConstants.vcFailSoundHorn: return "vcFailSoundHorn";
        case AUConstants.vcFelony: return "vcFelony";
        case AUConstants.vcFollowingImproper: return "vcFollowingImproper";
        case AUConstants.vcFollowingTooClose: return "vcFollowingTooClose";
        case AUConstants.vcImpedingTraffic: return "vcImpedingTraffic";
        case AUConstants.vcImproperDriving: return "vcImproperDriving";
        case AUConstants.vcBadTurnpikeStyle: return "vcBadTurnpikeStyle";
        case AUConstants.vcIncreaseWhilePassed: return "vcIncreaseWhilePassed";
        case AUConstants.vcUnattendedCar: return "vcUnattendedCar";
        case AUConstants.vcLeavingScene: return "vcLeavingScene";
        case AUConstants.vcMVIViolation: return "vcMVIViolation";
        case AUConstants.vcNegligentCollision: return "vcNegligentCollision";
        case AUConstants.vcNegligentDriving: return "vcNegligentDriving";
        case AUConstants.vcNoLiabInsurance: return "vcNoLiabInsurance";
        case AUConstants.vcParkingOnRoadway: return "vcParkingOnRoadway";
        case AUConstants.vcProhibUTurn: return "vcProhibUTurn";
        case AUConstants.vcProtectiveHeadGear: return "vcProtectiveHeadGear";
        case AUConstants.vcReckless: return "vcReckless";
        case AUConstants.vcStealingAuto: return "vcStealingAuto";
        case AUConstants.vcUnrestrainedChild: return "vcUnrestrainedChild";
        case AUConstants.vcUnsafeOperator: return "vcUnsafeOperator";
        case AUConstants.vcEmissionsViol: return "vcEmissionsViol";
        case AUConstants.vcVehiclularInjury: return "vcVehiclularInjury";
        case AUConstants.vcViolSafetyZone: return "vcViolSafetyZone";
        case AUConstants.vcViolatePromiseAppear: return "vcViolatePromiseAppear";
        case AUConstants.vcCompClaim: return "vcCompClaim";
        case AUConstants.vcAllowUnlawfulOperation: return "vcAllowUnlawfulOperation";
        case AUConstants.vcUMClaim: return "vcUMClaim";
        case AUConstants.vcUIMClaim: return "vcUIMClaim";
        case AUConstants.vcMedPayClaim: return "vcMedPayClaim";
        case AUConstants.vcPIPClaim: return "vcPIPClaim";
        case AUConstants.vcDrivingWOutHandsFree: return "vcDrivingWOutHandsFree";
        case AUConstants.vcTextingWhileDriving: return "vcTextingWhileDriving";
        case AUConstants.vcIgnitionInterlock: return "vcIgnitionInterlock";

        // CA codes
        case AUConstants.vcAccidentWithPedestrian: return "vcAccidentWithPedestrian";
        case AUConstants.vcAccidentAtFaultNoInjury: return "vcAccidentAtFaultNoInjury";
        case AUConstants.vcAccidentAtFaultInjury: return "vcAccidentAtFaultInjury";
        case AUConstants.vcFailureToReportAccident: return "vcFailureToReportAccident";
        case AUConstants.vcAccidentNotAtFault: return "vcAccidentNotAtFault";
        case AUConstants.vcAggravatedAssaultWithAuto: return "vcAggravatedAssaultWithAuto";
        case AUConstants.vcAllOtherMovingViolations: return "vcAllOtherMovingViolations";
        case AUConstants.vcAllOtherNonMovingViolations: return "vcAllOtherNonMovingViolations";
        case AUConstants.vcAllowUnlawfulOperationOfVehicle: return "vcAllowUnlawfulOperationOfVehicle";
        case AUConstants.vcAllowUnlicensedDriver: return "vcAllowUnlicensedDriver";
        case AUConstants.vcAlteredForgedVIN: return "vcAlteredForgedVIN";
        case AUConstants.vcFailureToObeyTrafficDevice: return "vcFailureToObeyTrafficDevice";
        case AUConstants.vcUnsafeStartingBacking: return "vcUnsafeStartingBacking";
        case AUConstants.vcDiamondLane: return "vcDiamondLane";
        case AUConstants.vcDiamondLaneCrossDoubleLine: return "vcDiamondLaneCrossDoubleLine";
        case AUConstants.vcCACarelessDriving: return "vcCACarelessDriving";
        case AUConstants.vcUnsafeLaneChange: return "vcUnsafeLaneChange";
        case AUConstants.vcChangingDriverMovingVehicle: return "vcChangingDriverMovingVehicle";
        case AUConstants.vcCoastingGearsDisengaged: return "vcCoastingGearsDisengaged";
        case AUConstants.vcComprehensiveClaim: return "vcComprehensiveClaim";
        case AUConstants.vcConsumingAlcoholWhileDriving: return "vcConsumingAlcoholWhileDriving";
        case AUConstants.vcConvictionOfInsuranceFraud: return "vcConvictionOfInsuranceFraud";
        case AUConstants.vcCACriminalNegligence: return "vcCACriminalNegligence";
        case AUConstants.vcCrossingCenterMedian: return "vcCrossingCenterMedian";
        case AUConstants.vcCrossingDividedHighway: return "vcCrossingDividedHighway";
        case AUConstants.vcCACrossingYellowLine: return "vcCACrossingYellowLine";
        case AUConstants.vcDisobeyPoliceOfficer: return "vcDisobeyPoliceOfficer";
        case AUConstants.vcDisobeyTollHighwayOfficer: return "vcDisobeyTollHighwayOfficer";
        case AUConstants.vcDisplayAlteredCounterfeitLicense: return "vcDisplayAlteredCounterfeitLicense";
        case AUConstants.vcDisplayOtherPersonsLicense: return "vcDisplayOtherPersonsLicense";
        case AUConstants.vcDisregardNoPassingZone: return "vcDisregardNoPassingZone";
        case AUConstants.vcDisregardOfSafety: return "vcDisregardOfSafety";
        case AUConstants.vcDrivingLeftOfCenter: return "vcDrivingLeftOfCenter";
        case AUConstants.vcDriversViewObstructed: return "vcDriversViewObstructed";
        case AUConstants.vcDrivingAtNightWithoutLights: return "vcDrivingAtNightWithoutLights";
        case AUConstants.vcDrivingOnLeftSideOfRoadway: return "vcDrivingOnLeftSideOfRoadway";
        case AUConstants.vcDrivingOnShoulder: return "vcDrivingOnShoulder";
        case AUConstants.vcDrivingOnSidewalk: return "vcDrivingOnSidewalk";
        case AUConstants.vcDrivingWrongSideOfRoad: return "vcDrivingWrongSideOfRoad";
        case AUConstants.vcDrivingOverFireHose: return "vcDrivingOverFireHose";
        case AUConstants.vcDrivingSchoolBusWhileIntoxicated: return "vcDrivingSchoolBusWhileIntoxicated";
        case AUConstants.vcDrivingThroughSafetyZone: return "vcDrivingThroughSafetyZone";
        case AUConstants.vcDrivingTooFastForConditions: return "vcDrivingTooFastForConditions";
        case AUConstants.vcDrivingTooSlowForConditions: return "vcDrivingTooSlowForConditions";
        case AUConstants.vcDrivingWithoutOwnersConsent: return "vcDrivingWithoutOwnersConsent";
        case AUConstants.vcDrivingWhileSuspendedRevoked: return "vcDrivingWhileSuspendedRevoked";
        case AUConstants.vcDrivingWithExpiredLicense: return "vcDrivingWithExpiredLicense";
        case AUConstants.vcDrivingWithoutLicensePermit: return "vcDrivingWithoutLicensePermit";
        case AUConstants.vcDrivingWrongWayOneWay: return "vcDrivingWrongWayOneWay";
        case AUConstants.vcDrivingWrongSideDividedHighway: return "vcDrivingWrongSideDividedHighway";
        case AUConstants.vcDrivingUnderMinimum: return "vcDrivingUnderMinimum";
        case AUConstants.vcDUIAlcoholDrugsNoInjury: return "vcDUIAlcoholDrugsNoInjury";
        case AUConstants.vcDUIAlcoholDrugsInjuryOrDeath: return "vcDUIAlcoholDrugsInjuryOrDeath";
        case AUConstants.vcMinorWithBACOverZeroFive: return "vcMinorWithBACOverZeroFive";
        case AUConstants.vcMinorWithBACOverZeroOne: return "vcMinorWithBACOverZeroOne";
        case AUConstants.vcDuplicateDriversLicense: return "vcDuplicateDriversLicense";
        case AUConstants.vcEducationProgramRequired: return "vcEducationProgramRequired";
        case AUConstants.vcEvadingPeaceOfficer: return "vcEvadingPeaceOfficer";
        case AUConstants.vcEvadingPeaceOfficerReckless: return "vcEvadingPeaceOfficerReckless";
        case AUConstants.vcEvadingPeaceOfficerInjury: return "vcEvadingPeaceOfficerInjury";
        case AUConstants.vcExcessiveAcceleration: return "vcExcessiveAcceleration";
        case AUConstants.vcFailToControlSpeed: return "vcFailToControlSpeed";
        case AUConstants.vcFailToControlVehicle: return "vcFailToControlVehicle";
        case AUConstants.vcFailToDisplayDriversLicense: return "vcFailToDisplayDriversLicense";
        case AUConstants.vcFailToExchangeInformation: return "vcFailToExchangeInformation";
        case AUConstants.vcImproperTurnNoSignal: return "vcImproperTurnNoSignal";
        case AUConstants.vcVehicleXingEvadingToll: return "vcVehicleXingEvadingToll";
        case AUConstants.vcFailToStopApproachingTrain: return "vcFailToStopApproachingTrain";
        case AUConstants.vcStopRequiredRailroadCrossing: return "vcStopRequiredRailroadCrossing";
        case AUConstants.vcFailToStopRedLight: return "vcFailToStopRedLight";
        case AUConstants.vcFailToStopStopSign: return "vcFailToStopStopSign";
        case AUConstants.vcFailToWearSeatBelt: return "vcFailToWearSeatBelt";
        case AUConstants.vcYieldingRightOfWayPedestrian: return "vcYieldingRightOfWayPedestrian";
        case AUConstants.vcFailureToYieldRightOfWay: return "vcFailureToYieldRightOfWay";
        case AUConstants.vcFailureToYieldEmergencyVehicle: return "vcFailureToYieldEmergencyVehicle";
        case AUConstants.vcFailureOfDutyInjuryOrDeath: return "vcFailureOfDutyInjuryOrDeath";
        case AUConstants.vcFailureToDimLights: return "vcFailureToDimLights";
        case AUConstants.vcFailureToKeepRight: return "vcFailureToKeepRight";
        case AUConstants.vcFailureToSoundHorn: return "vcFailureToSoundHorn";
        case AUConstants.vcFalseEvidenceOfRegistration: return "vcFalseEvidenceOfRegistration";
        case AUConstants.vcFelonyInvolvingMotorVehicle: return "vcFelonyInvolvingMotorVehicle";
        case AUConstants.vcFollowingImproperly: return "vcFollowingImproperly";
        case AUConstants.vcFollowingTooClosely: return "vcFollowingTooClosely";
        case AUConstants.vcDistanceBetweenVehicles: return "vcDistanceBetweenVehicles";
        case AUConstants.vcGivingImproperSignal: return "vcGivingImproperSignal";
        case AUConstants.vcHomicideWithMotorVehicle: return "vcHomicideWithMotorVehicle";
        case AUConstants.vcPassingOnRightOrShoulder: return "vcPassingOnRightOrShoulder";
        case AUConstants.vcIllegalTransportationOfAlcohol: return "vcIllegalTransportationOfAlcohol";
        case AUConstants.vcImpedingTrafficMovement: return "vcImpedingTrafficMovement";
        case AUConstants.vcRefusalToSubmitToTest: return "vcRefusalToSubmitToTest";
        case AUConstants.vcCAImproperDriving: return "vcCAImproperDriving";
        case AUConstants.vcFreewayRampEnteringExiting: return "vcFreewayRampEnteringExiting";
        case AUConstants.vcImproperMergingIntoTraffic: return "vcImproperMergingIntoTraffic";
        case AUConstants.vcIllegalImproperUnsafePassing: return "vcIllegalImproperUnsafePassing";
        case AUConstants.vcStopForSchoolBus: return "vcStopForSchoolBus";
        case AUConstants.vcCAImproperStart: return "vcCAImproperStart";
        case AUConstants.vcImproperTowingRiding: return "vcImproperTowingRiding";
        case AUConstants.vcCAImproperLaneUse: return "vcCAImproperLaneUse";
        case AUConstants.vcIncreaseSpeedWhileBeingPassed: return "vcIncreaseSpeedWhileBeingPassed";
        case AUConstants.vcLeaveEngineRunning: return "vcLeaveEngineRunning";
        case AUConstants.vcHitAndRunInjury: return "vcHitAndRunInjury";
        case AUConstants.vcHitAndRunNoInjury: return "vcHitAndRunNoInjury";
        case AUConstants.vcLightViolations: return "vcLightViolations";
        case AUConstants.vcLoanLicenseToOther: return "vcLoanLicenseToOther";
        case AUConstants.vcClaimMedicalPayments: return "vcClaimMedicalPayments";
        case AUConstants.vcMotorVehicleInspection: return "vcMotorVehicleInspection";
        case AUConstants.vcMotorcyclePassengersEquipment: return "vcMotorcyclePassengersEquipment";
        case AUConstants.vcCANegligentCollision: return "vcCANegligentCollision";
        case AUConstants.vcCANegligentDriving: return "vcCANegligentDriving";
        case AUConstants.vcNoChauffeursLicense: return "vcNoChauffeursLicense";
        case AUConstants.vcNoDriversLicense: return "vcNoDriversLicense";
        case AUConstants.vcNoLiabilityInsurance: return "vcNoLiabilityInsurance";
        case AUConstants.vcNoMotorcycleQualification: return "vcNoMotorcycleQualification";
        case AUConstants.vcObtainLicenseByMisrepresentation: return "vcObtainLicenseByMisrepresentation";
        case AUConstants.vcOpenContainerDriving: return "vcOpenContainerDriving";
        case AUConstants.vcOpenContainerPossession: return "vcOpenContainerPossession";
        case AUConstants.vcOperatingDuringLifeSuspension: return "vcOperatingDuringLifeSuspension";
        case AUConstants.vcOperatingOutOfClassification: return "vcOperatingOutOfClassification";
        case AUConstants.vcOperatingWhereProhibited: return "vcOperatingWhereProhibited";
        case AUConstants.vcUnsafeUnlawfullyEquippedVehicle: return "vcUnsafeUnlawfullyEquippedVehicle";
        case AUConstants.vcOverheightVehicle: return "vcOverheightVehicle";
        case AUConstants.vcOverlengthVehicle: return "vcOverlengthVehicle";
        case AUConstants.vcCAParkingOnRoadway: return "vcCAParkingOnRoadway";
        case AUConstants.vcPossessionControlledSubstance: return "vcPossessionControlledSubstance";
        case AUConstants.vcIllegalTurnUTurn: return "vcIllegalTurnUTurn";
        case AUConstants.vcIllegalTurnUTurnAtIntersection: return "vcIllegalTurnUTurnAtIntersection";
        case AUConstants.vcCAProtectiveHeadGear: return "vcCAProtectiveHeadGear";
        case AUConstants.vcSpeedContestExhibitionOfSpeed: return "vcSpeedContestExhibitionOfSpeed";
        case AUConstants.vcSpeedContestAidingAndAbetting: return "vcSpeedContestAidingAndAbetting";
        case AUConstants.vcRecklessDrivingNoInjury: return "vcRecklessDrivingNoInjury";
        case AUConstants.vcRecklessDrivingInjury: return "vcRecklessDrivingInjury";
        case AUConstants.vcSpeeding65AndUnder: return "vcSpeeding65AndUnder";
        case AUConstants.vcSpeedingOver65: return "vcSpeedingOver65";
        case AUConstants.vcSpeedingOver100: return "vcSpeedingOver100";
        case AUConstants.vcSpeedingTruckTractor: return "vcSpeedingTruckTractor";
        case AUConstants.vcSpeedingConstructionZone: return "vcSpeedingConstructionZone";
        case AUConstants.vcSpeedingWhileTowing: return "vcSpeedingWhileTowing";
        case AUConstants.vcCommercialSpeedVehicle: return "vcCommercialSpeedVehicle";
        case AUConstants.vcSpeedingInSchoolZone: return "vcSpeedingInSchoolZone";
        case AUConstants.vcSquealingScreechingTires: return "vcSquealingScreechingTires";
        case AUConstants.vcCAStealingAuto: return "vcCAStealingAuto";
        case AUConstants.vcSuspensionChargeable: return "vcSuspensionChargeable";
        case AUConstants.vcTurnAcrossDividedSection: return "vcTurnAcrossDividedSection";
        case AUConstants.vcUnsafeTurn: return "vcUnsafeTurn";
        case AUConstants.vcClaimUIM: return "vcClaimUIM";
        case AUConstants.vcClaimUM: return "vcClaimUM";
        case AUConstants.vcChildPassengerRestraint: return "vcChildPassengerRestraint";
        case AUConstants.vcCAUnsafeOperator: return "vcCAUnsafeOperator";
        case AUConstants.vcRestrictedSpeedWeatherConditions: return "vcRestrictedSpeedWeatherConditions";
        case AUConstants.vcUnsafeStartParkStopStanding: return "vcUnsafeStartParkStopStanding";
        case AUConstants.vcVehicleEmissionsSuspension: return "vcVehicleEmissionsSuspension";
        case AUConstants.vcVehicularInjury: return "vcVehicularInjury";
        case AUConstants.vcVehicularManslaughterGrossNegligence: return "vcVehicularManslaughterGrossNegligence";
        case AUConstants.vcVehicularManslaughterNoGrossNegligence: return "vcVehicularManslaughterNoGrossNegligence";
        case AUConstants.vcViolationOfLicenseRestrictions: return "vcViolationOfLicenseRestrictions";
        case AUConstants.vcDrivingHoursEquipmentMaintenanceOperation: return "vcDrivingHoursEquipmentMaintenanceOperation";
        case AUConstants.vcPermitDriverOutOfClassification: return "vcPermitDriverOutOfClassification";
        case AUConstants.vcDrinkingInVehicle: return "vcDrinkingInVehicle";
        case AUConstants.vcPossessionOfAlcohol: return "vcPossessionOfAlcohol";
        case AUConstants.vcViolationOfPromiseToAppear: return "vcViolationOfPromiseToAppear";
        case AUConstants.vcWrongDirectionAroundTrafficIsland: return "vcWrongDirectionAroundTrafficIsland";
        case AUConstants.vcWrongDirectionDividedStreet: return "vcWrongDirectionDividedStreet";
        case AUConstants.vcClaimLiability: return "vcClaimLiability";
        case AUConstants.vcClaimCollision: return "vcClaimCollision";
        case AUConstants.vcClaimTowing: return "vcClaimTowing";
        case AUConstants.vcViolationOfSuspensionDUI: return "vcViolationOfSuspensionDUI";
        case AUConstants.vcViolationOfRestrictionDUI: return "vcViolationOfRestrictionDUI";
        case AUConstants.vcFalseStatement: return "vcFalseStatement";
        case AUConstants.vcFinancialResponsibility: return "vcFinancialResponsibility";
        case AUConstants.vcBrakes: return "vcBrakes";
        case AUConstants.vcLicensePlate: return "vcLicensePlate";
        case AUConstants.vcExhaustModified: return "vcExhaustModified";
        case AUConstants.vcExplosivesTransportation: return "vcExplosivesTransportation";
        case AUConstants.vcInterfereWithTrafficDevice: return "vcInterfereWithTrafficDevice";
        case AUConstants.vcInterfereWithTrafficDeviceInjury: return "vcInterfereWithTrafficDeviceInjury";
        case AUConstants.vcMaliciousMischiefTampering: return "vcMaliciousMischiefTampering";
        case AUConstants.vcMaliciousActsBodilyHarm: return "vcMaliciousActsBodilyHarm";
        case AUConstants.vcMaliciousActsRemoveMarker: return "vcMaliciousActsRemoveMarker";
        case AUConstants.vcThrowingSubstance: return "vcThrowingSubstance";
        case AUConstants.vcThrowingSubstanceInjury: return "vcThrowingSubstanceInjury";
        case AUConstants.vcThrowingLightedSubstance: return "vcThrowingLightedSubstance";
        case AUConstants.vcThrowingMatterOnHighway: return "vcThrowingMatterOnHighway";
        case AUConstants.vcDisobeyConstructionSigns: return "vcDisobeyConstructionSigns";
        case AUConstants.vcPassingAnimals: return "vcPassingAnimals";
        case AUConstants.vcPassCarStoppedForPedestrian: return "vcPassCarStoppedForPedestrian";
        case AUConstants.vcMaximumDesignatedSpeedVehicle: return "vcMaximumDesignatedSpeedVehicle";
        case AUConstants.vcStopAtInoperativeSignal: return "vcStopAtInoperativeSignal";
        case AUConstants.vcTurnProhibitedBySign: return "vcTurnProhibitedBySign";
        case AUConstants.vcTurnOnRedLight: return "vcTurnOnRedLight";
        case AUConstants.vcUseOfTwoWayLeftTurnLane: return "vcUseOfTwoWayLeftTurnLane";
        case AUConstants.vcTurnAcrossBicycleLane: return "vcTurnAcrossBicycleLane";
        case AUConstants.vcYieldOnLeftTurn: return "vcYieldOnLeftTurn";
        case AUConstants.vcYieldRightOfWayToBlindPedestrian: return "vcYieldRightOfWayToBlindPedestrian";
        case AUConstants.vcYieldWhenOvertaken: return "vcYieldWhenOvertaken";
        case AUConstants.vcTranportingPersonInTruckLoadSpace: return "vcTranportingPersonInTruckLoadSpace";
        case AUConstants.vcUnsafeOverweightLoad: return "vcUnsafeOverweightLoad";
        case AUConstants.vcUnsafeLoadNoPermit: return "vcUnsafeLoadNoPermit";
        case AUConstants.vcEnterIntersectionWithoutSpace: return "vcEnterIntersectionWithoutSpace";
        case AUConstants.vcTurnAtIntersectionWithoutSpace: return "vcTurnAtIntersectionWithoutSpace";
        case AUConstants.vcAlteredLicensePlates: return "vcAlteredLicensePlates";
        case AUConstants.vcDoubleLinesOneBrokenLine: return "vcDoubleLinesOneBrokenLine";
        case AUConstants.vcDrivingWithParkingLights: return "vcDrivingWithParkingLights";
        case AUConstants.vcEnteringHighwayFromServiceRoad: return "vcEnteringHighwayFromServiceRoad";
        case AUConstants.vcOnRampExit: return "vcOnRampExit";
        case AUConstants.vcOpenDoor: return "vcOpenDoor";
        case AUConstants.vcRightOfOncomingVehicle: return "vcRightOfOncomingVehicle";
        case AUConstants.vcThreeLaneHighway: return "vcThreeLaneHighway";
        case AUConstants.vcViolatingPromiseToCorrect: return "vcViolatingPromiseToCorrect";
        case AUConstants.vcUsingWirelessPhone: return "vcUsingWirelessPhone";
        case AUConstants.vcUsingWirelessPhoneUnder18: return "vcUsingWirelessPhoneUnder18";
        case AUConstants.vcTexting: return "vcTexting";
        case AUConstants.vcTurnLaneUse: return "vcTurnLaneUse";
        case AUConstants.vcYieldToVehicleInIntersection: return "vcYieldToVehicleInIntersection";
        case AUConstants.vcFailureToStop: return "vcFailureToStop";
        case AUConstants.vcDUIDrugsNoInjury: return "vcDUIDrugsNoInjury";
        case AUConstants.vcFailToYieldEnteringHighway: return "vcFailToYieldEnteringHighway";
        case AUConstants.vcInsufficientSpaceAtRRCrossing: return "vcInsufficientSpaceAtRRCrossing";
        case AUConstants.vcCommercialSpeed: return "vcCommercialSpeed";
        case AUConstants.vcDrivingUnregistered: return "vcDrivingUnregistered";
        case AUConstants.vcLighting: return "vcLighting";
        case AUConstants.vcOtherEquipment: return "vcOtherEquipment";
        case AUConstants.vcTransportingExplosives: return "vcTransportingExplosives";
        case AUConstants.vcPassingSubjectToSection: return "vcPassingSubjectToSection";
        case AUConstants.vcOtherYield: return "vcOtherYield";
        case AUConstants.vcSpillingLoad: return "vcSpillingLoad";
        case AUConstants.vcCommercialChargeable: return "vcCommercialChargeable";
        case AUConstants.vcCommercialChargeableMoving: return "vcCommercialChargeableMoving";
        case AUConstants.vcCommercialNonChargeable: return "vcCommercialNonChargeable";
        case AUConstants.vcCommercialNonChargeableMoving: return "vcCommercialNonChargeableMoving";
        case AUConstants.vcDrivingOnLevee: return "vcDrivingOnLevee";
        case AUConstants.vcProhibitedBikePath: return "vcProhibitedBikePath";
        case AUConstants.vcCoastingProhibited: return "vcCoastingProhibited";
        case AUConstants.vcRidingInTrailer: return "vcRidingInTrailer";
        case AUConstants.vcOperatingGolfCartOnHighway: return "vcOperatingGolfCartOnHighway";
        case AUConstants.vcClaimPIP: return "vcClaimPIP";
        case AUConstants.vcFailIgnitionInterlock: return "vcFailIgnitionInterlock";

        default:
          throw new ArgumentException("Viol code " + code + " has no language id defined in GlobalizationLib.");
      }
    }

    /// <summary>
    /// Use to switch a viol code between the "all states" and
    /// California codes.  Necessary when you have a quote that
    /// has a viol code from the other group (in CA, with an 
    /// "all states" code, or in any other state with a CA code)
    /// </summary>
    /// <param name="aState">The current "in use" state</param>
    /// <param name="aCode">Viol code we need to switch</param>
    /// <returns></returns>
    public static int GetViolCodeFromWrongStateCode(USState aState, int aCode)
    {
      switch (aCode)
      {
        case vcConsumingAlcohol: return vcConsumingAlcoholWhileDriving;
        case vcDrvBusWhileIntox: return vcDrivingSchoolBusWhileIntoxicated;
        case vcDUI:
        case vcDWAI:
        case vcDWI: return vcDUIAlcoholDrugsNoInjury;
        case vcEdProgRequired: return vcEducationProgramRequired;
        case vcIllegalTransport: return vcIllegalTransportationOfAlcohol;
        case vcImpliedConsent: return vcRefusalToSubmitToTest;
        case vcOpenContainer: return vcOpenContainerPossession;
        case vcOperWhileIntox: return vcDUIAlcoholDrugsNoInjury;
        case vcLiquorViol: return vcPossessionOfAlcohol;
        case vcPedAcc: return vcAccidentWithPedestrian;
        case vcAccAtFault: return vcAccidentAtFaultNoInjury;
        case vcHomocide: return vcHomicideWithMotorVehicle;
        case vcManslaughter: return vcVehicularManslaughterNoGrossNegligence;
        case vcDUID: return vcDUIDrugsNoInjury;
        case vcPossessionofSubst: return vcPossessionControlledSubstance;
        case vcHeadlightViol: return vcLightViolations;
        case vcMotorcycleEquipViol: return vcMotorcyclePassengersEquipment;
        case vcDefectiveEquip: return vcUnsafeUnlawfullyEquippedVehicle;
        case vcOverheight: return vcOverheightVehicle;
        case vcOverlength: return vcOverlengthVehicle;
        case vcChangedLanesUnsafe: return vcUnsafeLaneChange;
        case vcCrossingCenterMed: return vcCrossingCenterMedian;
        case vcCrossingDividedHwy: return vcCrossingDividedHighway;
        case vcCrossingYellowLine: return vcCACrossingYellowLine;
        case vcDisregardNoPassZone: return vcDisregardNoPassingZone;
        case vcDrvOnLeftSide: return vcDrivingLeftOfCenter;
        case vcDrvOnShoulder: return vcDrivingOnShoulder;
        case vcDrvOnSidewalk: return vcDrivingOnSidewalk;
        case vcFailKeepRight: return vcFailureToKeepRight;
        case vcIllegalPass: return vcPassingOnRightOrShoulder;
        case vcImproperMerging: return vcImproperMergingIntoTraffic;
        case vcImproperPass: return vcIllegalImproperUnsafePassing;
        case vcPassSchoolBus: return vcStopForSchoolBus;
        case vcImproperLaneUse: return vcCAImproperLaneUse;
        case vcOperWhereProhib: return vcOperatingWhereProhibited;
        case vcAllowUnlicensed: return vcAllowUnlicensedDriver;
        case vcAlteredDL: return vcDisplayAlteredCounterfeitLicense;
        case vcDisplayAnothersDL: return vcDisplayOtherPersonsLicense;
        case vcLicSuspended: return vcDrivingWhileSuspendedRevoked;
        case vcExpired: return vcDrivingWithExpiredLicense;
        case vcNoLicense: return vcDrivingWithoutLicensePermit;
        case vcDuplicateDL: return vcDuplicateDriversLicense;
        case vcFailDisplayDL: return vcFailToDisplayDriversLicense;
        case vcFalseLicense: return vcFalseEvidenceOfRegistration;
        case vcLoanedDL: return vcLoanLicenseToOther;
        case vcNoChaufferLicense: return vcNoChauffeursLicense;
        case vcNoDL: return vcNoDriversLicense;
        case vcNoMotorcycleQualif: return vcNoMotorcycleQualification;
        case vcObtainByMisrep: return vcObtainLicenseByMisrepresentation;
        case vcOperDuringSusp: return vcOperatingDuringLifeSuspension;
        case vcOperateOutOfClass: return vcOperatingOutOfClassification;
        case vcChargeableSuspension: return vcSuspensionChargeable;
        case vcViolateDLRestrict:
        case vcPermitViol: return vcViolationOfLicenseRestrictions;
        case vcNoLights: return vcDrivingAtNightWithoutLights;
        case vcFailDimHeadLights: return vcFailureToDimLights;
        case vcAccNotAtFault: return vcAccidentNotAtFault;
        case vcDisobeyPolice: return vcDisobeyPoliceOfficer;
        case vcEludPolice: return vcEvadingPeaceOfficer;
        case vcAvoidTrafficControl: return vcFailureToObeyTrafficDevice;
        case vcFailToGiveSignal: return vcImproperTurnNoSignal;
        case vcFailToStopForTrain: return vcFailToStopApproachingTrain;
        case vcFailObeyRailRoad: return vcStopRequiredRailroadCrossing;
        case vcRunRedLight: return vcFailToStopRedLight;
        case vcRunStopSign: return vcFailToStopStopSign;
        case vcFailYieldPedestrian: return vcYieldingRightOfWayPedestrian;
        case vcFailRightOfWay: return vcFailureToYieldRightOfWay;
        case vcFailEmergencyVeh: return vcFailureToYieldEmergencyVehicle;
        case vcImproperSignal: return vcGivingImproperSignal;
        case vcTooFast: return vcDrivingTooFastForConditions;
        case vcTooSlowForConditions: return vcDrivingTooSlowForConditions;
        case vcDrvUnderMinimum: return vcDrivingUnderMinimum;
        case vcExcessAcceleration: return vcExcessiveAcceleration;
        case vcFailControlSpeed: return vcFailToControlSpeed;
        case vcRacing: return vcSpeedContestExhibitionOfSpeed;
        case vcSpeeding: return vcSpeeding65AndUnder;
        case vcSpeedSchoolZone: return vcSpeedingInSchoolZone;
        case vcUnsafeSpeed: return vcSpeeding65AndUnder;
        case vcImproperStart: return vcCAImproperStart;
        case vcSquealingTires: return vcSquealingScreechingTires;
        case vcUnsafeStart: return vcUnsafeStartParkStopStanding;
        case vcImproperTowing: return vcImproperTowingRiding;
        case vcTurnedAcrossDivided: return vcTurnAcrossDividedSection;
        case vcTurnedWhenUnsafe: return vcUnsafeTurn;
        case vcDriveLeftOfCenter: return vcDrivingLeftOfCenter;
        case vcWrongSideOfRoad: return vcDrivingWrongSideOfRoad;
        case vcWrongWayOnOneway: return vcDrivingWrongWayOneWay;
        case vcWrongWayIsland: return vcWrongDirectionAroundTrafficIsland;
        case vcWrongWayOnRoadway: return vcWrongDirectionDividedStreet;
        case vcAssaultWAuto: return vcAggravatedAssaultWithAuto;
        case vcMiscMovingViol: return vcAllOtherMovingViolations;
        case vcMiscNonMovingViol: return vcAllOtherNonMovingViolations;
        case vcAlteredVIN: return vcAlteredForgedVIN;
        case vcImproperBacking: return vcUnsafeStartingBacking;
        case vcCarPoolViol: return vcCAImproperLaneUse;
        case vcCarelessDriving: return vcCACarelessDriving;
        case vcChangeDriverMoving: return vcChangingDriverMovingVehicle;
        case vcCoasting: return vcCoastingGearsDisengaged;
        case vcConvictionInsFraud: return vcConvictionOfInsuranceFraud;
        case vcCriminalNegligence: return vcCACriminalNegligence;
        case vcDisregardSafety: return vcDisregardOfSafety;
        case vcDriversViewObstruct: return vcDriversViewObstructed;
        case vcDriveOnFireHose: return vcDrivingOverFireHose;
        case vcDrvInSafetyZone: return vcDrivingThroughSafetyZone;
        case vcDrivingWOConsent: return vcDrivingWithoutOwnersConsent;
        case vcFailControlVehicle: return vcFailToControlVehicle;
        case vcFailToExchangeInfo: return vcFailToExchangeInformation;
        case vcNoPayToll: return vcVehicleXingEvadingToll;
        case vcFailToWearBelt: return vcFailToWearSeatBelt;
        case vcFailureOfDuty: return vcFailureOfDutyInjuryOrDeath;
        case vcFailSoundHorn: return vcFailureToSoundHorn;
        case vcFelony: return vcFelonyInvolvingMotorVehicle;
        case vcFollowingImproper: return vcFollowingImproperly;
        case vcFollowingTooClose: return vcFollowingTooClosely;
        case vcImpedingTraffic: return vcImpedingTrafficMovement;
        case vcImproperDriving: return vcCAImproperDriving;
        case vcBadTurnpikeStyle: return vcFreewayRampEnteringExiting;
        case vcIncreaseWhilePassed: return vcIncreaseSpeedWhileBeingPassed;
        case vcUnattendedCar: return vcLeaveEngineRunning;
        case vcLeavingScene: return vcHitAndRunNoInjury;
        case vcMVIViolation: return vcMotorVehicleInspection;
        case vcNegligentCollision: return vcCANegligentCollision;
        case vcNegligentDriving: return vcCANegligentDriving;
        case vcNoLiabInsurance: return vcNoLiabilityInsurance;
        case vcParkingOnRoadway: return vcCAParkingOnRoadway;
        case vcProhibUTurn: return vcIllegalTurnUTurn;
        case vcProtectiveHeadGear: return vcCAProtectiveHeadGear;
        case vcReckless: return vcRecklessDrivingNoInjury;
        case vcStealingAuto: return vcCAStealingAuto;
        case vcUnrestrainedChild: return vcChildPassengerRestraint;
        case vcUnsafeOperator: return vcCAUnsafeOperator;
        case vcEmissionsViol: return vcVehicleEmissionsSuspension;
        case vcVehiclularInjury: return vcVehicularInjury;
        case vcViolSafetyZone: return vcDrivingHoursEquipmentMaintenanceOperation;
        case vcViolatePromiseAppear: return vcViolationOfPromiseToAppear;
        case vcCompClaim: return vcComprehensiveClaim;
        case vcUMClaim: return vcClaimUM;
        case vcUIMClaim: return vcClaimUIM;
        case vcMedPayClaim: return vcClaimMedicalPayments;
        case vcPIPClaim: return vcClaimPIP;
        case vcDrivingWOutHandsFree:
        case vcTextingWhileDriving: return vcTexting;
        case vcIgnitionInterlock: return vcFailIgnitionInterlock;
        case vcAllowUnlawfulOperation: return vcAllowUnlawfulOperationOfVehicle;
        case vcAccidentWithPedestrian: return vcPedAcc;
        case vcAccidentAtFaultNoInjury:
        case vcAccidentAtFaultInjury: return vcAccAtFault;
        case vcFailureToReportAccident: return vcMiscNonMovingViol;
        case vcAccidentNotAtFault: return vcAccNotAtFault;
        case vcAggravatedAssaultWithAuto: return vcAssaultWAuto;
        case vcAllOtherMovingViolations: return vcMiscMovingViol;
        case vcAllOtherNonMovingViolations: return vcMiscNonMovingViol;
        case vcAllowUnlawfulOperationOfVehicle: return vcAllowUnlawfulOperation;
        case vcAlteredForgedVIN: return vcAlteredVIN;
        case vcFailureToObeyTrafficDevice: return vcAvoidTrafficControl;
        case vcUnsafeStartingBacking: return vcUnsafeStart;
        case vcDiamondLane: return vcImproperLaneUse;
        case vcDiamondLaneCrossDoubleLine: return vcChangedLanesUnsafe;
        case vcCACarelessDriving: return vcCarelessDriving;
        case vcUnsafeLaneChange: return vcChangedLanesUnsafe;
        case vcChangingDriverMovingVehicle: return vcChangeDriverMoving;
        case vcCoastingGearsDisengaged:
        case vcCoastingProhibited: return vcCoasting;
        case vcComprehensiveClaim: return vcCompClaim;
        case vcConsumingAlcoholWhileDriving: return vcConsumingAlcohol;
        case vcConvictionOfInsuranceFraud: return vcConvictionInsFraud;
        case vcCACriminalNegligence: return vcCriminalNegligence;
        case vcCrossingCenterMedian: return vcCrossingCenterMed;
        case vcCrossingDividedHighway: return vcCrossingDividedHwy;
        case vcCACrossingYellowLine: return vcCrossingYellowLine;
        case vcDisobeyPoliceOfficer:
        case vcDisobeyTollHighwayOfficer: return vcDisobeyPolice;
        case vcDisplayAlteredCounterfeitLicense: return vcAlteredDL;
        case vcDisplayOtherPersonsLicense: return vcDisplayAnothersDL;
        case vcDisregardNoPassingZone: return vcDisregardNoPassZone;
        case vcDisregardOfSafety: return vcDisregardSafety;
        case vcDrivingLeftOfCenter: return vcDriveLeftOfCenter;
        case vcDriversViewObstructed: return vcDriversViewObstruct;
        case vcDrivingAtNightWithoutLights: return vcNoLights;
        case vcDrivingOnLeftSideOfRoadway: return vcDrvOnLeftSide;
        case vcDrivingOnShoulder: return vcDrvOnShoulder;
        case vcDrivingOnSidewalk: return vcDrvOnSidewalk;
        case vcDrivingWrongSideOfRoad: return vcWrongSideOfRoad;
        case vcDrivingOverFireHose: return vcDriveOnFireHose;
        case vcDrivingSchoolBusWhileIntoxicated: return vcDrvBusWhileIntox;
        case vcDrivingThroughSafetyZone: return vcDrvInSafetyZone;
        case vcDrivingTooFastForConditions: return vcTooFast;
        case vcDrivingTooSlowForConditions: return vcTooSlowForConditions;
        case vcDrivingWithoutOwnersConsent: return vcDrivingWOConsent;
        case vcDrivingWhileSuspendedRevoked: return vcLicSuspended;
        case vcDrivingWithExpiredLicense: return vcExpired;
        case vcDrivingWithoutLicensePermit: return vcNoLicense;
        case vcDrivingWrongWayOneWay: return vcWrongWayOnOneway;
        case vcDrivingWrongSideDividedHighway: return vcWrongWayOnRoadway;
        case vcDrivingUnderMinimum: return vcDrvUnderMinimum;
        case vcDUIAlcoholDrugsNoInjury:
        case vcDUIAlcoholDrugsInjuryOrDeath:
        case vcMinorWithBACOverZeroFive:
        case vcMinorWithBACOverZeroOne: return vcDUI;
        case vcDuplicateDriversLicense: return vcDuplicateDL;
        case vcEducationProgramRequired: return vcEdProgRequired;
        case vcEvadingPeaceOfficer:
        case vcEvadingPeaceOfficerReckless:
        case vcEvadingPeaceOfficerInjury: return vcEludPolice;
        case vcExcessiveAcceleration: return vcExcessAcceleration;
        case vcFailToControlSpeed: return vcFailControlSpeed;
        case vcFailToControlVehicle: return vcFailControlVehicle;
        case vcFailToDisplayDriversLicense: return vcFailDisplayDL;
        case vcFailToExchangeInformation: return vcFailToExchangeInfo;
        case vcImproperTurnNoSignal: return vcFailToGiveSignal;
        case vcVehicleXingEvadingToll: return vcNoPayToll;
        case vcFailToStopApproachingTrain: return vcFailToStopForTrain;
        case vcStopRequiredRailroadCrossing: return vcFailObeyRailRoad;
        case vcFailToStopRedLight: return vcRunRedLight;
        case vcFailToStopStopSign: return vcRunStopSign;
        case vcFailToWearSeatBelt: return vcFailToWearBelt;
        case vcYieldingRightOfWayPedestrian: return vcFailYieldPedestrian;
        case vcFailureToYieldRightOfWay: return vcFailRightOfWay;
        case vcFailureToYieldEmergencyVehicle: return vcFailEmergencyVeh;
        case vcFailureOfDutyInjuryOrDeath: return vcFailureOfDuty;
        case vcFailureToDimLights: return vcFailDimHeadLights;
        case vcFailureToKeepRight: return vcFailKeepRight;
        case vcFailureToSoundHorn: return vcFailSoundHorn;
        case vcFalseEvidenceOfRegistration: return vcFalseLicense;
        case vcFelonyInvolvingMotorVehicle: return vcFelony;
        case vcFollowingImproperly: return vcFollowingImproper;
        case vcFollowingTooClosely:
        case vcDistanceBetweenVehicles: return vcFollowingTooClose;
        case vcGivingImproperSignal: return vcImproperSignal;
        case vcHomicideWithMotorVehicle: return vcHomocide;
        case vcPassingOnRightOrShoulder: return vcIllegalPass;
        case vcIllegalTransportationOfAlcohol: return vcIllegalTransport;
        case vcImpedingTrafficMovement: return vcImpedingTraffic;
        case vcRefusalToSubmitToTest: return vcImpliedConsent;
        case vcCAImproperDriving: return vcImproperDriving;
        case vcFreewayRampEnteringExiting: return vcBadTurnpikeStyle;
        case vcImproperMergingIntoTraffic: return vcImproperMerging;
        case vcIllegalImproperUnsafePassing: return vcImproperPass;
        case vcStopForSchoolBus: return vcPassSchoolBus;
        case vcCAImproperStart: return vcImproperStart;
        case vcImproperTowingRiding: return vcImproperTowing;
        case vcCAImproperLaneUse: return vcImproperLaneUse;
        case vcIncreaseSpeedWhileBeingPassed: return vcIncreaseWhilePassed;
        case vcLeaveEngineRunning: return vcUnattendedCar;
        case vcHitAndRunInjury:
        case vcHitAndRunNoInjury: return vcLeavingScene;
        case vcLightViolations: return vcHeadlightViol;
        case vcLoanLicenseToOther: return vcLoanedDL;
        case vcClaimMedicalPayments: return vcMedPayClaim;
        case vcMotorVehicleInspection: return vcMVIViolation;
        case vcMotorcyclePassengersEquipment: return vcMotorcycleEquipViol;
        case vcCANegligentCollision: return vcNegligentCollision;
        case vcCANegligentDriving: return vcNegligentDriving;
        case vcNoChauffeursLicense: return vcNoChaufferLicense;
        case vcNoDriversLicense: return vcNoDL;
        case vcNoLiabilityInsurance: return vcNoLiabInsurance;
        case vcNoMotorcycleQualification: return vcNoMotorcycleQualif;
        case vcObtainLicenseByMisrepresentation: return vcObtainByMisrep;
        case vcOpenContainerDriving:
        case vcOpenContainerPossession: return vcOpenContainer;
        case vcOperatingDuringLifeSuspension: return vcOperDuringSusp;
        case vcOperatingOutOfClassification: return vcOperateOutOfClass;
        case vcOperatingWhereProhibited:
        case vcDrivingOnLevee:
        case vcProhibitedBikePath:
        case vcOperatingGolfCartOnHighway: return vcOperWhereProhib;
        case vcUnsafeUnlawfullyEquippedVehicle: return vcDefectiveEquip;
        case vcOverheightVehicle: return vcOverheight;
        case vcOverlengthVehicle: return vcOverlength;
        case vcCAParkingOnRoadway: return vcParkingOnRoadway;
        case vcPossessionControlledSubstance: return vcPossessionofSubst;
        case vcIllegalTurnUTurn:
        case vcIllegalTurnUTurnAtIntersection: return vcProhibUTurn;
        case vcCAProtectiveHeadGear: return vcProtectiveHeadGear;
        case vcSpeedContestExhibitionOfSpeed:
        case vcSpeedContestAidingAndAbetting: return vcRacing;
        case vcRecklessDrivingNoInjury:
        case vcRecklessDrivingInjury: return vcReckless;
        case vcSpeeding65AndUnder:
        case vcSpeedingOver65:
        case vcSpeedingOver100:
        case vcSpeedingTruckTractor:
        case vcSpeedingConstructionZone:
        case vcSpeedingWhileTowing:
        case vcCommercialSpeedVehicle: return vcSpeeding;
        case vcSpeedingInSchoolZone: return vcSpeedSchoolZone;
        case vcSquealingScreechingTires: return vcSquealingTires;
        case vcCAStealingAuto: return vcStealingAuto;
        case vcSuspensionChargeable: return vcChargeableSuspension;
        case vcTurnAcrossDividedSection: return vcTurnedAcrossDivided;
        case vcUnsafeTurn: return vcTurnedWhenUnsafe;
        case vcClaimUIM: return vcUIMClaim;
        case vcClaimUM: return vcUMClaim;
        case vcChildPassengerRestraint: return vcUnrestrainedChild;
        case vcCAUnsafeOperator: return vcUnsafeOperator;
        case vcRestrictedSpeedWeatherConditions: return vcTooFast;
        case vcUnsafeStartParkStopStanding: return vcUnsafeStart;
        case vcVehicleEmissionsSuspension: return vcEmissionsViol;
        case vcVehicularInjury: return vcVehiclularInjury;
        case vcVehicularManslaughterGrossNegligence:
        case vcVehicularManslaughterNoGrossNegligence: return vcManslaughter;
        case vcViolationOfLicenseRestrictions: return vcPermitViol;
        case vcDrivingHoursEquipmentMaintenanceOperation: return vcViolSafetyZone;
        case vcPermitDriverOutOfClassification: return vcOperateOutOfClass;
        case vcDrinkingInVehicle: return vcConsumingAlcohol;
        case vcPossessionOfAlcohol: return vcPossessionofSubst;
        case vcViolationOfPromiseToAppear: return vcViolatePromiseAppear;
        case vcWrongDirectionAroundTrafficIsland: return vcWrongWayIsland;
        case vcWrongDirectionDividedStreet: return vcWrongWayOnRoadway;
        case vcClaimLiability:
        case vcClaimCollision:
        case vcClaimTowing: return vcMiscNonMovingViol;
        case vcViolationOfSuspensionDUI: return vcLicSuspended;
        case vcViolationOfRestrictionDUI: return vcViolateDLRestrict;
        case vcFalseStatement:
        case vcFinancialResponsibility: return vcMiscNonMovingViol;
        case vcBrakes:
        case vcExhaustModified:
        case vcExplosivesTransportation: return vcDefectiveEquip;
        case vcLicensePlate:
        case vcInterfereWithTrafficDevice:
        case vcInterfereWithTrafficDeviceInjury:
        case vcMaliciousMischiefTampering:
        case vcMaliciousActsBodilyHarm:
        case vcMaliciousActsRemoveMarker:
        case vcThrowingSubstance:
        case vcThrowingSubstanceInjury:
        case vcThrowingLightedSubstance:
        case vcThrowingMatterOnHighway:
        case vcAlteredLicensePlates:
        case vcViolatingPromiseToCorrect:
        case vcCommercialChargeable:
        case vcCommercialNonChargeable: return vcMiscNonMovingViol;
        case vcPassingAnimals:
        case vcPassCarStoppedForPedestrian:
        case vcMaximumDesignatedSpeedVehicle:
        case vcStopAtInoperativeSignal:
        case vcTurnProhibitedBySign:
        case vcTurnOnRedLight:
        case vcUseOfTwoWayLeftTurnLane:
        case vcTurnAcrossBicycleLane:
        case vcYieldOnLeftTurn:
        case vcYieldRightOfWayToBlindPedestrian:
        case vcYieldWhenOvertaken:
        case vcTranportingPersonInTruckLoadSpace:
        case vcUnsafeOverweightLoad:
        case vcUnsafeLoadNoPermit:
        case vcEnterIntersectionWithoutSpace:
        case vcTurnAtIntersectionWithoutSpace:
        case vcDoubleLinesOneBrokenLine:
        case vcDrivingWithParkingLights:
        case vcEnteringHighwayFromServiceRoad:
        case vcOnRampExit:
        case vcOpenDoor:
        case vcRightOfOncomingVehicle:
        case vcThreeLaneHighway:
        case vcUsingWirelessPhone:
        case vcUsingWirelessPhoneUnder18:
        case vcFailureToStop:
        case vcInsufficientSpaceAtRRCrossing:
        case vcCommercialSpeed:
        case vcDrivingUnregistered:
        case vcTransportingExplosives:
        case vcPassingSubjectToSection:
        case vcSpillingLoad:
        case vcCommercialChargeableMoving:
        case vcCommercialNonChargeableMoving:
        case vcRidingInTrailer: return vcMiscMovingViol;
        case vcTurnLaneUse: return vcImproperLaneUse;
        case vcYieldToVehicleInIntersection:
        case vcFailToYieldEnteringHighway:
        case vcOtherYield: return vcFailRightOfWay;
        case vcDUIDrugsNoInjury: return vcDUID;
        case vcLighting:
        case vcOtherEquipment: return vcDefectiveEquip;
        case vcTexting: return vcTextingWhileDriving;
        case vcClaimPIP: return vcPIPClaim;
        case vcFailIgnitionInterlock: return vcIgnitionInterlock;
        default: return aState == USState.California ? vcAllOtherNonMovingViolations : vcMiscNonMovingViol;
      }
    }

    /// <summary>
    /// Returns a viol name from it's code.  The name can be state dependent.
    /// </summary>
    /// <param name="code">The code of the violation.</param>
    /// <param name="state">The state for this violation name.</param>
    /// <returns>The name of the violation based on code.</returns>
    public static string ViolNameByCode(int code, USState state)
    {
      switch (code)
      {
        case 0: return "Select Violation";
        case vcConsumingAlcohol: return "Consuming Alcohol While Driving";
        case vcDrvBusWhileIntox: return "Driving School Bus While Intoxicated";
        case vcDUI: return "DUI Alcohol/Liquor";
        case vcDWAI:
          switch (state)
          {
            case USState.Colorado: return "Defective Vehicle";
            case USState.NoneSelected: return "DWAI (Defective Vehicle in CO)";
          }
          return "DWAI";
        case vcDWI: return "DWI";
        case vcEdProgRequired: return "Educational Program Required (ARD)";
        case vcIllegalTransport: return "Illegal Transportation of Alcohol";
        case vcImpliedConsent: return "Implied Consent/Refuse Breath Test";
        case vcOpenContainer: return "Open Container Violation";
        case vcOperWhileIntox: return "OWI";
        case vcLiquorViol: return "Violation of Liquor Law";
        case vcPedAcc: return "Accident, with Pedestrian";
        case vcAccAtFault: return "Accident, At-Fault";
        case vcHomocide: return "Homicide with a Motor Vehicle";
        case vcManslaughter: return "Vehicular Manslaughter";
        case vcDUID: return "DUI Drugs/Opiates";
        case vcPossessionofSubst: return "Possession of Controlled Substance";
        case vcHeadlightViol: return "Light Violations (Head, Tail, etc...)";
        case vcMotorcycleEquipViol: return "Motorcycle Equipment Violation";
        case vcDefectiveEquip: return "Operating with Defective Equipment";
        case vcOverheight: return "Overheight Vehicle";
        case vcOverlength: return "Overlength Vehicle";
        case vcChangedLanesUnsafe: return "Changing Lanes when Unsafe";
        case vcCrossingCenterMed: return "Crossing Center Median";
        case vcCrossingDividedHwy: return "Crossing Divided Highway";
        case vcCrossingYellowLine: return "Crossing Yellow Line";
        case vcDisregardNoPassZone: return "Disregard No Passing Zone";
        case vcDrvOnLeftSide: return "Driving on Left Side of Roadway";
        case vcDrvOnShoulder: return "Driving on Shoulder";
        case vcDrvOnSidewalk: return "Driving on Sidewalk or Parkway";
        case vcFailKeepRight: return "Failure to Keep Right";
        case vcIllegalPass: return "Illegal Pass on Right";
        case vcImproperMerging: return "Improper Merging Into Traffic";
        case vcImproperPass: return "Improper Passing";
        case vcPassSchoolBus: return "Improper Passing of a School Bus";
        case vcImproperLaneUse: return "Improper Use of Lane";
        case vcOperWhereProhib: return "Operating Where Prohibited";
        case vcAllowUnlicensed: return "Allow Unlicensed Driver to Drive";
        case vcAlteredDL: return "Display Altered/Counterfeit DL";
        case vcDisplayAnothersDL: return "Display Another Person's DL";
        case vcLicSuspended: return "Driving While Suspended or Revoked";
        case vcExpired: return "Driving With an Expired License";
        case vcNoLicense: return "Driving Without a License or Permit";
        case vcDuplicateDL: return "Duplicate Drivers License";
        case vcFailDisplayDL: return "Failure to Display DL";
        case vcFalseLicense: return "False License or Registration";
        case vcLoanedDL: return "Loaned DL to Another Person";
        case vcNoChaufferLicense: return "No Chauffeurs License";
        case vcNoDL: return "No Drivers License";
        case vcNoMotorcycleQualif: return "No Motorcycle Qualification";
        case vcObtainByMisrep: return "Obtaining License by Misrepresenting";
        case vcOperDuringSusp: return "Operating During Life Suspension";
        case vcOperateOutOfClass: return "Operating Out of Class";
        case vcChargeableSuspension: return "Suspension (Chargeable)";
        case vcViolateDLRestrict: return "Violation of DL Restriction";
        case vcPermitViol: return "Violation of Instruction Permit";
        case vcNoLights: return "Driving at Night Without Lights";
        case vcFailDimHeadLights: return "Failure to Dim Headlights";
        case vcAccNotAtFault: return "Accident, Not At-Fault";
        case vcDisobeyPolice: return "Disobey Police Order";
        case vcEludPolice: return "Eluding Police/Evading Arrest";
        case vcAvoidTrafficControl: return "Avoiding Traffic-Control Device";
        case vcFailToGiveSignal: return "Failure to Give Stop or Turn Signal";
        case vcFailToStopForTrain: return "Failure to Stop for Approaching Train";
        case vcFailObeyRailRoad: return "Failure to Stop for Railroad Crossing";
        case vcRunRedLight: return "Failure to Stop for Red Light";
        case vcRunStopSign: return "Failure to Stop for Stop Sign";
        case vcFailYieldPedestrian: return "Failure to Yield (Pedestrian)";
        case vcFailRightOfWay: return "Failure to Yield Right of Way";
        case vcFailEmergencyVeh: return "Failure to Yield to Emergency Vehicle";
        case vcImproperSignal: return "Giving Improper Signal";
        case vcTooFast: return "Driving Too Fast for Conditions";
        case vcTooSlowForConditions: return "Driving Too Slow for Conditions";
        case vcDrvUnderMinimum: return "Drv Under Minimum Speed Limit";
        case vcExcessAcceleration: return "Excessive Acceleration";
        case vcFailControlSpeed: return "Failure to Control Speed";
        case vcRacing: return "Racing/Speed Contest";
        case vcSpeeding: return "Speeding";
        case vcSpeedSchoolZone: return "Speeding in a School Zone";
        case vcUnsafeSpeed: return "Unsafe Speed";
        case vcImproperStart: return "Improper Start";
        case vcSquealingTires: return "Squealing or Screeching Tires";
        case vcUnsafeStart: return "Unsafe Start,Park,Stop,Standing";
        case vcImproperTowing: return "Improper Towing or Pushing of Vehicle";
        case vcTurnedAcrossDivided: return "Turned Across Divided Section";
        case vcTurnedWhenUnsafe: return "Turned When Unsafe";
        case vcDriveLeftOfCenter: return "Drive Left of Center";
        case vcWrongSideOfRoad: return "Driving on Wrong Side of Road";
        case vcWrongWayOnOneway: return "Driving Wrong Way on One-Way";
        case vcWrongWayIsland: return "Wrong Direction Around Traffic Island";
        case vcWrongWayOnRoadway: return "Wrong Direction Divided Street";
        case vcAssaultWAuto: return "Aggravated Assault with an Auto";
        case vcMiscMovingViol: return "All Other Moving Violations";
        case vcMiscNonMovingViol: return "All Other Non-Moving Violations";
        case vcAlteredVIN:
          switch (state)
          {
            case USState.Washington: return "Physical Control While Under Influence";
            default: return "Altered or Forged VIN";
          }
        case vcImproperBacking: return "Improperly Backing";
        case vcCarPoolViol: return "Bus/Car Pool/ Hov - Lane Violation";
        case vcCarelessDriving: return "Careless and Imprudent Driving";
        case vcChangeDriverMoving: return "Changing Driver in Moving Vehicle";
        case vcCoasting: return "Coasting with Gears Disengaged";
        case vcConvictionInsFraud: return "Conviction of Insurance Fraud";
        case vcCriminalNegligence: return "Criminal Negligence";
        case vcDisregardSafety: return "Disregard of Safety";
        case vcDriversViewObstruct: return "Drivers View Obstructed";
        case vcDriveOnFireHose: return "Driving Over Fire Hose";
        case vcDrvInSafetyZone: return "Driving Through Safety Zone";
        case vcDrivingWOConsent: return "Driving W/O Owners Consent";
        case vcFailControlVehicle: return "Failure to Control Vehicle";
        case vcFailToExchangeInfo: return "Failure to Exchange Info After Accident";
        case vcNoPayToll: return "Failure to Pay Toll";
        case vcFailToWearBelt: return "Failure to Wear Seat Belt";
        case vcFailureOfDuty: return "Failure of Duty";
        case vcFailSoundHorn: return "Failure to Sound Horn";
        case vcFelony: return "Felony Involving a Motor Vehicle";
        case vcFollowingImproper: return "Following Improperly";
        case vcFollowingTooClose: return "Following Too Close";
        case vcImpedingTraffic: return "Impeding Traffic Movement";
        case vcImproperDriving: return "Improper Driving";
        case vcBadTurnpikeStyle: return "Improper Entering/Leaving Turnpike";
        case vcIncreaseWhilePassed: return "Increase Speed While Being Passed";
        case vcUnattendedCar: return "Leave Vehicle With Engine Running";
        case vcLeavingScene: return "Leaving Scene  /  Hit-and-Run";
        case vcMVIViolation: return "Motor Vehicle Inspection Viol.";
        case vcNegligentCollision: return "Negligent Collision";
        case vcNegligentDriving: return "Negligent Driving";
        case vcNoLiabInsurance: return "No Liability Insurance in Force";
        case vcParkingOnRoadway: return "Parking on Roadway";
        case vcProhibUTurn: return "Prohibited U Turn";
        case vcProtectiveHeadGear: return "Protective Head Gear Violation";
        case vcReckless: return "Reckless Driving";
        case vcStealingAuto: return "Stealing Auto";
        case vcUnrestrainedChild: return "Unrestrained Child";
        case vcUnsafeOperator: return "Unsafe Operator";
        case vcEmissionsViol: return "Vehicle Emissions Suspension";
        case vcVehiclularInjury: return "Vehicular Injury";
        case vcViolSafetyZone: return "Violating Safety Zone";
        case vcViolatePromiseAppear: return "Violation of Promise to Appear";
        case vcCompClaim: return "Comprehensive Claim";
        case vcUMClaim: return "Uninsured Motorist Claim";
        case vcUIMClaim: return "Underinsured Motorist Claim";
        case vcMedPayClaim: return "Medical Payments Claim";
        case vcAllowUnlawfulOperation: return "Allow Unlawful Operation of Vehicle";
        case vcPIPClaim: return "PIP Claim";
        case vcDrivingWOutHandsFree: return "Use of Wireless Device without Handsfree while Driving";
        case vcTextingWhileDriving: return "Use of Wireless Dev for Text-Based Comm. While Driving";
        case vcIgnitionInterlock: return "Failure to Use Ignition Interlock Device";

        case vcAccidentWithPedestrian: return "Accident, with Pedestrian";
        case vcAccidentAtFaultNoInjury: return "Accident, At Fault - No Injury";
        case vcAccidentAtFaultInjury: return "Accident, At Fault - Injury";
        case vcFailureToReportAccident: return "Failed to Report Accident Within 24 Hours - 20008a";
        case vcAccidentNotAtFault: return "Accident, Not At Fault";
        case vcAggravatedAssaultWithAuto: return "Aggravated Assault with an Auto";
        case vcAllOtherMovingViolations: return "All Other Moving Violations";
        case vcAllOtherNonMovingViolations: return "All Other Non-Moving Violations";
        case vcAllowUnlawfulOperationOfVehicle: return "Allow Unlawful Operation of Vehicle";
        case vcAllowUnlicensedDriver: return "Allow Unlicensed Driver to Drive - 14607,14604a";
        case vcAlteredForgedVIN: return "Altered or Forged VIN";
        case vcFailureToObeyTrafficDevice: return "Failure to Obey Device - 21461,21462,23336,21461a,21454c";
        case vcUnsafeStartingBacking: return "Unsafe Starting/Backing of Vehicle - 22106";
        case vcDiamondLane: return "Diamond Lane - 21655.5";
        case vcDiamondLaneCrossDoubleLine: return "Diamond Lane - Cross Double Line - 21655.8";
        case vcCACarelessDriving: return "Careless Driving";
        case vcUnsafeLaneChange: return "Unsafe Lane Change - 21658a, 21658b";
        case vcChangingDriverMovingVehicle: return "Changing Driver in Moving Vehicle";
        case vcCoastingGearsDisengaged: return "Coasting with Gears Disengaged";
        case vcComprehensiveClaim: return "Claim - Comprehensive";
        case vcConsumingAlcoholWhileDriving: return "Consuming Alcohol While Driving - 23220";
        case vcConvictionOfInsuranceFraud: return "Conviction of Insurance Fraud";
        case vcCACriminalNegligence: return "Criminal Negligence";
        case vcCrossingCenterMedian: return "Crossing Center Median";
        case vcCrossingDividedHighway: return "Crossing Divided Highway - 21651a";
        case vcCACrossingYellowLine: return "Crossing Yellow Line - 21655.8a";
        case vcDisobeyPoliceOfficer: return "Disobey Policy Officer - 2800, 2817";
        case vcDisobeyTollHighwayOfficer: return "Disobey Toll Highway Officer - 23253";
        case vcDisplayAlteredCounterfeitLicense: return "Display Altered/Counterfeit Drivers License - 14610 a8";
        case vcDisplayOtherPersonsLicense: return "Display Another Persons Drivers License - 14610 a3";
        case vcDisregardNoPassingZone: return "Disregard No Passing Zone";
        case vcDisregardOfSafety: return "Disregard of Safety";
        case vcDrivingLeftOfCenter: return "Driving Left of Center - 21752a,21752b,21752c";
        case vcDriversViewObstructed: return "Driver's View Obstructed - 21700";
        case vcDrivingAtNightWithoutLights: return "Driving at Night Without Lights - 24250";
        case vcDrivingOnLeftSideOfRoadway: return "Driving on Left Side of Roadway";
        case vcDrivingOnShoulder: return "Driving on Shoulder - 21755a";
        case vcDrivingOnSidewalk: return "Driving on Sidewalk - 21663";
        case vcDrivingWrongSideOfRoad: return "Driving on Wrong Side of Road";
        case vcDrivingOverFireHose: return "Driving Over Fire Hose - 21708";
        case vcDrivingSchoolBusWhileIntoxicated: return "Driving School Bus While Intoxicated";
        case vcDrivingThroughSafetyZone: return "Driving Through Safety Zone - 21709";
        case vcDrivingTooFastForConditions: return "Driving Too Fast for Conditions";
        case vcDrivingTooSlowForConditions: return "Driving Too Slow for Conditions - 22400a,22400b,21654a";
        case vcDrivingWithoutOwnersConsent: return "Driving Without Owners Consent";
        case vcDrivingWhileSuspendedRevoked: return "Driving While Suspended/Revoked - 14601a,14601.1";
        case vcDrivingWithExpiredLicense: return "Driving with Expired License/Registration - 4152.5, 4152a";
        case vcDrivingWithoutLicensePermit: return "Driving Without a License or Permit - 12500a,12509c,12509d";
        case vcDrivingWrongWayOneWay: return "Driving Wrong Way on One-Way - 21657";
        case vcDrivingWrongSideDividedHighway: return "Driving Wrong Side/ Divided Highway - 21651b,21651c";
        case vcDrivingUnderMinimum: return "Driving Under Minimum Speed Limit - 22400";
        case vcDUIAlcoholDrugsNoInjury: return "DUI, Alcohol - No Injury - 23152a,23152b,23152d";
        case vcDUIAlcoholDrugsInjuryOrDeath: return "DUI, Alcohol or Drugs - Injury or Death - 23153a,23153b,23153d";
        case vcMinorWithBACOverZeroFive: return "Minor Driving with BAC of .05% or More - 23140a,23140b";
        case vcMinorWithBACOverZeroOne: return "Minor BAC .01% or More - 23136";
        case vcDuplicateDriversLicense: return "Duplicate Drivers License - 14610 a7";
        case vcEducationProgramRequired: return "Education Program Required";
        case vcEvadingPeaceOfficer: return "Evade Peace Officer - No Injury 2800.1";
        case vcEvadingPeaceOfficerReckless: return "Evade Peace Officer - Reckless Driving - 2800.2";
        case vcEvadingPeaceOfficerInjury: return "Evade Peace Officer - Injury - 2800.3";
        case vcExcessiveAcceleration: return "Excessive Acceleration";
        case vcFailToControlSpeed: return "Fail to Control Speed";
        case vcFailToControlVehicle: return "Fail to Control Vehicle";
        case vcFailToDisplayDriversLicense: return "Failure to Display Drivers License - 12952";
        case vcFailToExchangeInformation: return "Failure to Exchange Information after Accident - 16025a";
        case vcImproperTurnNoSignal: return "Improper Turn or No Signal - 22108,22110,22111a,22111b";
        case vcVehicleXingEvadingToll: return "Vehicle Xing, Evading Toll - 23302";
        case vcFailToStopApproachingTrain: return "Fail to Stop for Approaching Train - 22451a,22451b";
        case vcStopRequiredRailroadCrossing: return "Stop Required/Railroad Crossing - 22450b,22452b,22452c";
        case vcFailToStopRedLight: return "Fail to Stop for Red Light - 21453a,21453c";
        case vcFailToStopStopSign: return "Fail to Stop for Stop Sign - 22450a";
        case vcFailToWearSeatBelt: return "Fail to Wear Seat Belt - 27315d,27315e";
        case vcYieldingRightOfWayPedestrian: return "Yielding Right-of-Way to Pedestrian-21952,21950a,21945b";
        case vcFailureToYieldRightOfWay: return "Failure to Yield Right of Way - 21661,21802,21803";
        case vcFailureToYieldEmergencyVehicle: return "Failure to Yield to Emergency Vehicle - 21806a";
        case vcFailureOfDutyInjuryOrDeath: return "Failure of Duty upon Injury or Death-20003a,20003b,20004";
        case vcFailureToDimLights: return "Failure to Dim Lights - 24409, 24409a,24409b";
        case vcFailureToKeepRight: return "Failure to Keep Right - 21650";
        case vcFailureToSoundHorn: return "Failure to Sound Horn - 27001a";
        case vcFalseEvidenceOfRegistration: return "False Evidence of Registration - 4462.5,4463a";
        case vcFelonyInvolvingMotorVehicle: return "Felony Involving a Motor Vehicle";
        case vcFollowingImproperly: return "Following Improperly";
        case vcFollowingTooClosely: return "Following Too Closely - 21703";
        case vcDistanceBetweenVehicles: return "Distance Between Vehicles - 21704,21705,21706";
        case vcGivingImproperSignal: return "Giving Improper Signal - 22111";
        case vcHomicideWithMotorVehicle: return "Homicide with a Motor Vehicle";
        case vcPassingOnRightOrShoulder: return "Passing on Right/Shoulder - 21754,21755";
        case vcIllegalTransportationOfAlcohol: return "Illegal Transportation of Alcohol";
        case vcImpedingTrafficMovement: return "Impeding Traffic Movement - 22400a";
        case vcRefusalToSubmitToTest: return "Refusal to Submit to Test - 13353,13353a,23157";
        case vcCAImproperDriving: return "Improper Driving";
        case vcFreewayRampEnteringExiting: return "Freeway Ramp/Entering/Exiting - 21664";
        case vcImproperMergingIntoTraffic: return "Improper Merging into Traffic";
        case vcIllegalImproperUnsafePassing: return "Passing - 21750,21756,21757,21758,21751,21756a,21756b";
        case vcStopForSchoolBus: return "Stop for School Bus - 22454";
        case vcCAImproperStart: return "Improper Start";
        case vcImproperTowingRiding: return "Improper Towing or Riding - 21712a";
        case vcCAImproperLaneUse: return "Improper Lane Use - 21656";
        case vcIncreaseSpeedWhileBeingPassed: return "Increase Speed While Being Passed";
        case vcLeaveEngineRunning: return "Leave Vehicle with Engine Running";
        case vcHitAndRunInjury: return "Hit and Run - Injury - 20001a";
        case vcHitAndRunNoInjury: return "Hit and Run - No Injury - 20002a,20002b";
        case vcLightViolations: return "Light Violations";
        case vcLoanLicenseToOther: return "Loan Drivers License to Another - 14610a2,14610a5";
        case vcClaimMedicalPayments: return "Claim - Medical Payments";
        case vcMotorVehicleInspection: return "Motor Vehicle Inspection Violation";
        case vcMotorcyclePassengersEquipment: return "Motorcycle/Passengers and Equipment - 27800";
        case vcCANegligentCollision: return "Negligent Collision";
        case vcCANegligentDriving: return "Negligent Driving";
        case vcNoChauffeursLicense: return "No Chauffeurs License";
        case vcNoDriversLicense: return "No Drivers License - 12951a, 12815";
        case vcNoLiabilityInsurance: return "No Liability Insurance in Force - 16457a";
        case vcNoMotorcycleQualification: return "No Motorcycle Qualification - 12500";
        case vcObtainLicenseByMisrepresentation: return "Obtaining License by Misrepresentation - 13004a";
        case vcOpenContainerDriving: return "Open Container - Driving - 23222a";
        case vcOpenContainerPossession: return "Open Container - Possession - 23223,23225";
        case vcOperatingDuringLifeSuspension: return "Operating During Life Suspension";
        case vcOperatingOutOfClassification: return "Operating Out of Classification - 12500b,12500c,12500d";
        case vcOperatingWhereProhibited: return "Operating Where Prohibited";
        case vcUnsafeUnlawfullyEquippedVehicle: return "Unsafe/Unlawfully Equipped Vehicle - 24002";
        case vcOverheightVehicle: return "Overheight Vehicle";
        case vcOverlengthVehicle: return "Overlength Vehicle";
        case vcCAParkingOnRoadway: return "Parking on Roadway";
        case vcPossessionControlledSubstance: return "Possession of Controlled Substance - 23222b";
        case vcIllegalTurnUTurn: return "Illegal Turn/U-Turn - 22102,22103,22104,22105";
        case vcIllegalTurnUTurnAtIntersection: return "Illegal Turn/U-Turn at Intersection - 22100.5";
        case vcCAProtectiveHeadGear: return "Protective Head Gear Violation";
        case vcSpeedContestExhibitionOfSpeed: return "Speed Contest/Exhibition of Speed - 23109a,23109c";
        case vcSpeedContestAidingAndAbetting: return "Speed Contest/Aid, Abet - 23109b, 23109d";
        case vcRecklessDrivingNoInjury: return "Reckless Driving - No Injury - 23103a,23103b";
        case vcRecklessDrivingInjury: return "Reckless Driving - Injury - 23104a";
        case vcSpeeding65AndUnder: return "Speeding - 22348a,22350,22352a,22352b,22351a,22351b";
        case vcSpeedingOver65: return "Speeding Over 65 - 22349";
        case vcSpeedingOver100: return "Speeding Over 100 - 22348b";
        case vcSpeedingTruckTractor: return "Speeding, Truck/Tractor - 22406a";
        case vcSpeedingConstructionZone: return "Speed in a Construction Zone - 22362";
        case vcSpeedingWhileTowing: return "Speeding While Towing - 22406b";
        case vcCommercialSpeedVehicle: return "Commercial Speed Veh - 22406.1(a),22406.1(b)";
        case vcSpeedingInSchoolZone: return "Speeding in a School Zone - 22358.4";
        case vcSquealingScreechingTires: return "Squealing or Screeching Tires";
        case vcCAStealingAuto: return "Auto Theft";
        case vcSuspensionChargeable: return "Suspension (Chargeable)";
        case vcTurnAcrossDividedSection: return "Turned Across Divided Section";
        case vcUnsafeTurn: return "Unsafe Turn - 22107";
        case vcClaimUIM: return "Claim - UIM";
        case vcClaimUM: return "Claim - UM";
        case vcChildPassengerRestraint: return "Child Passenger Restraint - 27360,27360.5,27363b";
        case vcCAUnsafeOperator: return "Unsafe Operator";
        case vcRestrictedSpeedWeatherConditions: return "Restricted Speed/Weather Conditions - 22363";
        case vcUnsafeStartParkStopStanding: return "Unsafe Start, Park, Stop, Standing";
        case vcVehicleEmissionsSuspension: return "Vehicle Emissions Suspension";
        case vcVehicularInjury: return "Vehicular Injury";
        case vcVehicularManslaughterGrossNegligence: return "Manslaughter w/Gross - 191.5a,192c1-192c4,192.3c,192.3d";
        case vcVehicularManslaughterNoGrossNegligence: return "Manslaughter w/o Gross - 192c,192.3a,192.3b";
        case vcViolationOfLicenseRestrictions: return "Violation of License Restrictions - 14603";
        case vcDrivingHoursEquipmentMaintenanceOperation: return "Violating Safety Zone - 34506,34506.3,34506a";
        case vcPermitDriverOutOfClassification: return "Permit Driver Out of Classification - 14606a";
        case vcDrinkingInVehicle: return "Drinking in Vehicle - 23221";
        case vcPossessionOfAlcohol: return "Possession of Alcohol - 23224a,23224b";
        case vcViolationOfPromiseToAppear: return "Violation of Promise to Appear - 40508a,40509.5,42003";
        case vcWrongDirectionAroundTrafficIsland: return "Wrong Direction Around Traffic Island";
        case vcWrongDirectionDividedStreet: return "Wrong Direction Divided Street";
        case vcClaimLiability: return "Claim - Liability";
        case vcClaimCollision: return "Claim - Collision";
        case vcClaimTowing: return "Claim - Towing";
        case vcViolationOfSuspensionDUI: return "Violation of Suspension - DUI - 14601.2a";
        case vcViolationOfRestrictionDUI: return "Violation of Restriction - DUI - 14601.2b";
        case vcFalseStatement: return "False Statement - 20, 31";
        case vcFinancialResponsibility: return "Financial Responsibility - 16028,16020a,16029";
        case vcBrakes: return "Brakes - 26302, 26301.5, 26303";
        case vcLicensePlate: return "License Plate - 5200,5201,5202,5204A";
        case vcExhaustModified: return "Exhaust Modified - 27151A";
        case vcExplosivesTransportation: return "Explosives Transportation - 31602,31602a,31602b,31602c";
        case vcInterfereWithTrafficDevice: return "Interfere with Traffic Device - No Injury - 21464a, 21464b";
        case vcInterfereWithTrafficDeviceInjury: return "Interfere with Traffic Device - Injury - 21464c";
        case vcMaliciousMischiefTampering: return "Malicious Mischief/Tampering - 10852,10853,10854";
        case vcMaliciousActsBodilyHarm: return "Malicious Acts - Bodily Harm - 38318.5b";
        case vcMaliciousActsRemoveMarker: return "Malicious Acts - Remove Marker - 38318.5a";
        case vcThrowingSubstance: return "Throwing Substance - No Injury - 23110a,38318a";
        case vcThrowingSubstanceInjury: return "Throwing Substance - Injury - 23110b, 38318b";
        case vcThrowingLightedSubstance: return "Throwing Lighted Substance - 23111";
        case vcThrowingMatterOnHighway: return "Throwing Matter on Highway - 23112a";
        case vcDisobeyConstructionSigns: return "Construction - Disobey Signs/Controller - 21367b";
        case vcPassingAnimals: return "Passing Animals - 21759";
        case vcPassCarStoppedForPedestrian: return "Pass Car Stopped for Pedestrian - 21951";
        case vcMaximumDesignatedSpeedVehicle: return "Maximum Designated Vehicle Speed - 22406,22407";
        case vcStopAtInoperativeSignal: return "Stop at Inoperative Signal - 21800d";
        case vcTurnProhibitedBySign: return "Turn Prohibited by Sign - 22101d";
        case vcTurnOnRedLight: return "Turn on Red Light - 21453b";
        case vcUseOfTwoWayLeftTurnLane: return "Use of Two-Way Left Turn Lane - 21460.5c,21460.5";
        case vcTurnAcrossBicycleLane: return "Turning Across Bicycle Lane - 21717,21209a";
        case vcYieldOnLeftTurn: return "Yield on Left Turn - 21801a,21801b";
        case vcYieldRightOfWayToBlindPedestrian: return "Yielding Right-Of-Way to Blind Pedestrian - 21963";
        case vcYieldWhenOvertaken: return "Yield when Overtaken - 21753";
        case vcTranportingPersonInTruckLoadSpace: return "Transport Person in Truck Load Space - 23116a";
        case vcUnsafeOverweightLoad: return "Unsafe/Overweight Vehicle Load - 2803a,2803c";
        case vcUnsafeLoadNoPermit: return "Unsafe Vehicle Load - No Permit - 2803b";
        case vcEnterIntersectionWithoutSpace: return "Enter Intersection Without Space - 22526a";
        case vcTurnAtIntersectionWithoutSpace: return "Turn at Intersection Without Space - 22526b";
        case vcAlteredLicensePlates: return "Altered License Plates - 4464";
        case vcDoubleLinesOneBrokenLine: return "Double Lines/One Broken Line - 21460,21460a,24160b";
        case vcDrivingWithParkingLights: return "Driving with Parking Lights - 24800";
        case vcEnteringHighwayFromServiceRoad: return "Entering Highway from Service Road - 21652";
        case vcOnRampExit: return "On-ramp Exit - 21664";
        case vcOpenDoor: return "Open Door - 22517";
        case vcRightOfOncomingVehicle: return "Right of Oncoming Vehicle - 21660";
        case vcThreeLaneHighway: return "Three Lane Highway - 21659";
        case vcViolatingPromiseToCorrect: return "Violating Promise to Correct - 40616";
        case vcUsingWirelessPhone: return "Using Wireless Phone - 23123";
        case vcUsingWirelessPhoneUnder18: return "Using Wireless Phone while Under 18 - 23124";
        case vcTexting: return "Texting - 23123.5";
        case vcTurnLaneUse: return "Turn - Lane Use - 22100a, 22100b";
        case vcYieldToVehicleInIntersection: return "Yield to Vehicle in Intersection - 21800a,21800b,21800c";
        case vcFailureToStop: return "Failure to Stop - 21452, 21455, 21457a";
        case vcDUIDrugsNoInjury: return "DUI, Drugs - No Injury - 23152c";
        case vcFailToYieldEnteringHighway: return "Yield - Entering Hwy - 21804a";
        case vcInsufficientSpaceAtRRCrossing: return "Enter RR Xing Without Sufficient Space - 22526c";
        case vcCommercialSpeed: return "Commercial Speed - 22406.5, 22406c, 22406d, 22406e";
        case vcDrivingUnregistered: return "Driving Unregistered Vehicles";
        case vcLighting: return "Lighting - Fix It Only";
        case vcOtherEquipment: return "Other Equipment";
        case vcTransportingExplosives: return "Transporting Explosives";
        case vcPassingSubjectToSection: return "Passing Subject to Section 22406";
        case vcOtherYield: return "Other Yield";
        case vcSpillingLoad: return "Spilling Load on Highway";
        case vcCommercialChargeable: return "Commercial Chargeable";
        case vcCommercialChargeableMoving: return "Commercial Chargeable Moving";
        case vcCommercialNonChargeable: return "Commercial Non Chargeable";
        case vcCommercialNonChargeableMoving: return "Commercial Non Chargeable Moving";
        case vcDrivingOnLevee: return "Drive on Levee, Canal Bank, etc";
        case vcProhibitedBikePath: return "Motorized Bike Prohibited Bike Path";
        case vcCoastingProhibited: return "Coasting Prohibited";
        case vcRidingInTrailer: return "Unlawful Riding in Trailer";
        case vcOperatingGolfCartOnHighway: return "Op Golf Cart on Hwy/AZ Not = 25";
        case vcClaimPIP: return "PIP Claim";
        case vcFailIgnitionInterlock: return "Failure to Use Ignition Interlock Device - 23575";
        default: return "Invalid Violation " + code.ToString();
      }
    }

    public const int AllOtherStandardCompID = -2147483646;
    public const int AllOtherNonStandardCompID = -2147483647;
    public const int AllOtherNonVoluntaryCompID = -2147483645;

    /// <summary>
    /// valid liability bi limits for AR
    /// </summary>
    public static List<int[]> ValidLiabBILimitsAR = new List<int[]>()
        {
      		new int[] { 25,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
				  new int[] {250, 500},
        };

    /// <summary>
    /// valid unins bi limits for AR
    /// </summary>
    public static List<int[]> ValidUninsBILimitsAR = new List<int[]>()
        {
      		new int[] { 25,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
				  new int[] {250, 500},
        };

    /// <summary>
    /// valid liability bi limits for AZ
    /// </summary>
    public static List<int[]> ValidLiabBILimitsAZ = new List<int[]>()
        {
          new int[] { 15,  30},
          new int[] { 20,  40},
				  new int[] { 25,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
				  new int[] {250, 500},
        };

    /// <summary>
    /// valid unins bi limits for AZ
    /// </summary>
    public static List<int[]> ValidUninsBILimitsAZ = new List<int[]>()
        {
          new int[] { 15,  30},
          new int[] { 20,  40},
				  new int[] { 25,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
				  new int[] {250, 500},
        };

    /// <summary>
    /// valid liability bi limits for CA
    /// </summary>
    public static List<int[]> ValidLiabBILimitsCA = new List<int[]>()
        {
          new int[] {  15,  30},
				  new int[] {  25,  50},
				  new int[] {  50, 100},
				  new int[] { 100, 300},
				  new int[] { 250, 500},
          new int[] { 100,  -1},
          new int[] { 300,  -1},
          new int[] { 500,  -1},
          new int[] {1000,  -1},
        };

    /// <summary>
    /// valid unins bi limits for CA
    /// </summary>
    public static List<int[]> ValidUninsBILimitsCA = new List<int[]>()
        {
          new int[] {  15,  30},
				  new int[] {  25,  50},
          new int[] {  30,  60},
				  new int[] {  50, 100},
				  new int[] { 100, 300},
				  new int[] { 250, 500},
          new int[] { 100,  -1},
          new int[] { 300,  -1},
          new int[] { 500,  -1},
          new int[] {1000,  -1}
        };

    /// <summary>
    /// valid liability bi limits for CO
    /// </summary>
    public static List<int[]> ValidLiabBILimitsCO = new List<int[]>()
        {
				  new int[] { 25,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
				  new int[] {250, 500},
          new int[] {500, 500}
        };

    /// <summary>
    /// valid unins bi limits for CO
    /// </summary>
    public static List<int[]> ValidUninsBILimitsCO = new List<int[]>()
        {
				  new int[] { 25,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
				  new int[] {250, 500},
          new int[] {500, 500}
        };

    /// <summary>
    /// valid liability bi limits for IL
    /// </summary>
    public static List<int[]> ValidLiabBILimitsIL = new List<int[]>()
        {
				  new int[] {  20,  40},
				  new int[] {  25,  50},
          new int[] {  25, 100},
				  new int[] {  30,  60},
				  new int[] {  50, 100},
          new int[] {  50, 200},
				  new int[] { 100, 300},
				  new int[] { 250, 300},
				  new int[] { 250, 500},
          new int[] { 300, 300},
          new int[] { 300, 500},
          new int[] { 500, 500},
          new int[] { 500,1000},
          new int[] { 750, 750},
          new int[] {1000,1000}
        };

    /// <summary>
    /// valid unins bi limits for IL
    /// </summary>
    public static List<int[]> ValidUninsBILimitsIL = new List<int[]>()
        {
				  new int[] {  20,  40},
				  new int[] {  25,  50},
          new int[] {  25, 100},
				  new int[] {  30,  60},
				  new int[] {  50, 100},
          new int[] {  50, 200},
				  new int[] { 100, 300},
				  new int[] { 250, 500},
          new int[] { 300, 300},
          new int[] { 300, 500},
          new int[] { 500, 500},
          new int[] { 500,1000},
          new int[] { 750, 750},
          new int[] {1000,1000}
        };

    /// <summary>
    /// valid liability bi limits for IN
    /// </summary>
    public static List<int[]> ValidLiabBILimitsIN = new List<int[]>()
        {
				  new int[] { 25,  50},
				  new int[] { 30,  60},
				  new int[] { 50,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
				  new int[] {250, 500}
        };

    /// <summary>
    /// valid unins bi limits for IN
    /// </summary>
    public static List<int[]> ValidUninsBILimitsIN = new List<int[]>()
        {
				  new int[] { 25,  50},
				  new int[] { 30,  60},
				  new int[] { 50,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
				  new int[] {250, 500}
        };

    /// <summary>
    /// valid liability bi limits for KS
    /// </summary>
    public static List<int[]> ValidLiabBILimitsKS = new List<int[]>()
        {
				  new int[] { 25,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
          new int[] {250, 500}
        };

    /// <summary>
    /// valid unins bi limits for KS
    /// </summary>
    public static List<int[]> ValidUninsBILimitsKS = new List<int[]>()
        {
				  new int[] { 25,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
          new int[] {250, 500}
        };

    /// <summary>
    /// valid liability bi limits for KY
    /// </summary>
    public static List<int[]> ValidLiabBILimitsKY = new List<int[]>()
        {
				  new int[] { 25,  50},
          new int[] { 25, 100},
          new int[] { 50,  50},
				  new int[] { 50, 100},
          new int[] {100, 100},
				  new int[] {100, 300},
          new int[] {250, 500},
          new int[] {300, 500}
        };

    /// <summary>
    /// valid unins bi limits for KY
    /// </summary>
    public static List<int[]> ValidUninsBILimitsKY = new List<int[]>()
        {
				  new int[] { 25,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
          new int[] {250, 500}
        };

    /// <summary>
    /// valid liability bi limits for LA
    /// </summary>
    public static List<int[]> ValidLiabBILimitsLA = new List<int[]>()
        {
				  new int[] { 15,  30},
				  new int[] { 25,  50},
          new int[] { 50, 100},
				  new int[] {100, 300},
          new int[] {250, 500}
        };

    /// <summary>
    /// valid unins bi limits for LA
    /// </summary>
    public static List<int[]> ValidUninsBILimitsLA = new List<int[]>()
        {
				  new int[] { 15,  30},
				  new int[] { 25,  50},
          new int[] { 50, 100},
				  new int[] {100, 300},
          new int[] {250, 500}
        };

    /// <summary>
    /// valid liability bi limits for MO
    /// </summary>
    public static List<int[]> ValidLiabBILimitsMO = new List<int[]>()
        {
				  new int[] { 25,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
				  new int[] {250, 300},
				  new int[] {250, 500}
        };

    /// <summary>
    /// valid unins bi limits for MO
    /// </summary>
    public static List<int[]> ValidUninsBILimitsMO = new List<int[]>()
        {
				  new int[] { 25,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
				  new int[] {250, 500}
        };

    /// <summary>
    /// valid liability bi limits for NM
    /// </summary>
    public static List<int[]> ValidLiabBILimitsNM = new List<int[]>()
        {
          new int[] {  25,  50 },
          new int[] {  50, 100 },
          new int[] { 100, 300 },
          new int[] { 250, 500 }
        };

    /// <summary>
    /// valid unins bi limits for NM
    /// </summary>
    public static List<int[]> ValidUninsBILimitsNM = new List<int[]>()
        {
          new int[] {  25,  50 },
          new int[] {  50, 100 },
          new int[] { 100, 300 },
          new int[] { 250, 500 }
        };

    /// <summary>
    /// valid liability bi limits for OH
    /// </summary>
    public static List<int[]> ValidLiabBILimitsOH = new List<int[]>()
        {
				  new int[] { 25,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
          new int[] {250, 500}
        };

    /// <summary>
    /// valid unins bi limits for OH
    /// </summary>
    public static List<int[]> ValidUninsBILimitsOH = new List<int[]>()
        {
          new int[] { 12,  25},
          new int[] { 15,  30},
				  new int[] { 25,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
          new int[] {250, 500}
        };

    /// <summary>
    /// valid liability bi limits for OK
    /// </summary>
    public static List<int[]> ValidLiabBILimitsOK = new List<int[]>()
        {
				  new int[] { 25,  50},
				  new int[] { 50, 100},
          new int[] {100, 200},
				  new int[] {100, 300},
				  new int[] {250, 500}
        };

    /// <summary>
    /// valid unins bi limits for OK
    /// </summary>
    public static List<int[]> ValidUninsBILimitsOK = new List<int[]>()
        {
				  new int[] { 25,  50},
				  new int[] { 50, 100},
          new int[] {100, 200},
				  new int[] {100, 300},
				  new int[] {250, 500}
        };

    /// <summary>
    /// valid liability bi limits for TN
    /// </summary>
    public static List<int[]> ValidLiabBILimitsTN = new List<int[]>()
        {
				  new int[] { 25,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
				  new int[] {250, 500}
        };

    /// <summary>
    /// valid unins bi limits for TN
    /// </summary>
    public static List<int[]> ValidUninsBILimitsTN = new List<int[]>()
        {
				  new int[] { 25,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
				  new int[] {250, 500}
        };

    /// <summary>
    /// valid liability bi limits for TX
    /// </summary>
    public static List<int[]> ValidLiabBILimitsTX = new List<int[]>()
        {
				  new int[] { 30,  60},
				  new int[] { 50, 100},
				  new int[] {100, 300},
				  new int[] {250, 500},
				  new int[] {300, 500},
        };

    /// <summary>
    /// valid unins bi limits for TX
    /// </summary>
    public static List<int[]> ValidUninsBILimitsTX = new List<int[]>()
        {
				  new int[] { 30,  60},
				  new int[] { 50, 100},
				  new int[] {100, 300},
				  new int[] {250, 500},
				  new int[] {300, 500},
        };

    /// <summary>
    /// valid liability bi limits for VA
    /// </summary>
    public static List<int[]> ValidLiabBILimitsVA = new List<int[]>()
        {
				  new int[] { 25,  50},
				  new int[] { 30,  60},
				  new int[] { 35,  70},
				  new int[] { 50, 100},
				  new int[] {100, 200},
				  new int[] {100, 300},
				  new int[] {250, 500}
        };

    /// <summary>
    /// valid unins bi limits for VA
    /// </summary>
    public static List<int[]> ValidUninsBILimitsVA = new List<int[]>()
        {
				  new int[] { 25,  50},
				  new int[] { 30,  60},
				  new int[] { 35,  70},
				  new int[] { 50, 100},
				  new int[] {100, 200},
				  new int[] {100, 300},
				  new int[] {250, 500}
        };

    /// <summary>
    /// valid liability bi limits for WI
    /// </summary>
    public static List<int[]> ValidLiabBILimitsWI = new List<int[]>()
        {
          new int[] { 25,  50},
          new int[] { 50, 100},
          new int[] {100, 300},
          new int[] {150, 300},
          new int[] {250, 500},
          new int[] {500, 500}
        };

    /// <summary>
    /// valid unins bi limits for WI
    /// </summary>
    public static List<int[]> ValidUninsBILimitsWI = new List<int[]>()
        {
				  new int[] { 25,  50},
				  new int[] { 50, 100},
				  new int[] {100, 300},
          new int[] {150, 300},
				  new int[] {250, 500},
          new int[] {500, 500}
        };

    /// <summary>
    /// just hiding the default constructor
    /// </summary>
    private AUConstants()
    {
    }

  }
}
