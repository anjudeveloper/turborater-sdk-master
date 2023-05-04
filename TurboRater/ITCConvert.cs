using System;
using System.Data.SqlClient;
using System.Text;

namespace TurboRater
{
  /// <summary>
  /// A conversion struct to handle conversions.
  /// </summary>
  public struct ITCConvert
  {
    /// <summary>
    /// Minimum date value acceptable to sql server.
    /// </summary>
    public static readonly DateTime SQL_MIN_DATE = Convert.ToDateTime("01/01/1753");

    /// <summary>
    /// Maximum date value acceptable to sql server.
    /// </summary>
    public static readonly DateTime SQL_MAX_DATE = Convert.ToDateTime("12/31/9999");

    /// <summary>
    /// Converts any SqlDataReader object to a csv list containing all the fields/records.
    /// </summary>
    /// <param name="reader">The SqlDataReader object that you want to convert.</param>
    /// <returns>The CSV output, representing the SqlDataReader object</returns>
    public static string SqlDataReaderToCSV(SqlDataReader reader)
    {
      string tempString = "";
      while (reader.Read())
      {
        string tempLine = "";
        for (int colIndex = 0; colIndex < reader.FieldCount; colIndex++)
        {
          tempLine += reader[colIndex].ToString();
          if (colIndex < (reader.FieldCount - 1))
            tempLine += ",";
        }
        tempString += tempLine + "\n\r";
      }
      return tempString;
    }

    /// <summary>
    /// Converts the object to a DateTime. If conversion fails, returns the 
    /// default value passed into it.
    /// </summary>
    /// <param name="convertValue">The object value to convert to a DateTime.</param>
    /// <param name="defaultValue">The value to return if the conversion fails.</param>
    /// <returns>The converted value exceot in the event of an exception or a DBNull which will return the defaulted value.</returns>
    public static DateTime ToDateTime(Object convertValue, DateTime defaultValue)
    {
      try
      {
        bool isNull = convertValue == null || Convert.IsDBNull(convertValue);
        if (!isNull)
        {
          string stringValue = convertValue.ToString().Trim();
          if (!String.IsNullOrEmpty(stringValue) && (!stringValue.Equals("/  /")))
          {
            DateTime value;
            bool isDateTime = DateTime.TryParse(stringValue, out value);
            if (isDateTime)
              return value;
            else
              return defaultValue;
          }
          else
          {
            return defaultValue;
          }
        }
        else
        {
          return defaultValue;
        }
      }
      catch
      {
        return defaultValue;
      }
    }

    /// <summary>
    /// Converts the object to a boolean value. If the conversion fails or the value is
    /// a DBNull, it returns the default value passed in. 
    /// </summary>
    /// <param name="convertValue">The object value to convert to a boolean.</param>
    /// <param name="defaultValue">The value to return if the conversion fails.</param>
    /// <returns>The converted value except in the event of an exception or a DBNull which will return the defaulted value.</returns>
    public static bool ToBoolean(Object convertValue, bool defaultValue)
    {
      try
      {
        if (!Convert.IsDBNull(convertValue))
        {
          return Convert.ToBoolean(convertValue);
        }
        else
        {
          return defaultValue;
        }
      }
      catch
      {
        return defaultValue;
      }
    }

    /// <summary>
    /// Converts the objects value to an int32 value if possible. Returns the default value if 
    /// not.
    /// </summary>
    /// <param name="convertValue">The object value to convert to an integer.</param>
    /// <param name="defaultValue">The value to return if the conversion fails.</param>
    /// <returns>The converted value except in the event of an exception or a DBNull which will return the defaulted value.</returns>
    public static int ToInt32(Object convertValue, int defaultValue)
    {
      try
      {
        if (!Convert.IsDBNull(convertValue) && (convertValue != null))
        {
          int num;
          bool isNum = Int32.TryParse(convertValue.ToString(), out num);
          if (isNum)
            return num;
          else
            return defaultValue;
        }
        else
        {
          return defaultValue;
        }
      }
      catch
      {
        return defaultValue;
      }
    }

    /// <summary>
    /// Converts the objects value to an int64 value if possible. Returns the default value if 
    /// not.
    /// </summary>
    /// <param name="convertValue">The object value to convert to a long.</param>
    /// <param name="defaultValue">The value to return if the conversion fails.</param>
    /// <returns>The converted value except in the event of an exception or a DBNull which will return the defaulted value.</returns>
    public static long ToInt64(Object convertValue, long defaultValue)
    {
      try
      {
        if (!Convert.IsDBNull(convertValue) && (convertValue != null))
        {
          long num;
          bool isNum = Int64.TryParse(convertValue.ToString(), out num);
          if (isNum)
            return num;
          else
            return defaultValue;
        }
        else
        {
          return defaultValue;
        }
      }
      catch
      {
        return defaultValue;
      }
    }

    /// <summary>
    /// Converts the objects value to a decimal value if possible. Returns the default value if 
    /// not.
    /// </summary>
    /// <param name="convertValue">The object value to convert to a long.</param>
    /// <param name="defaultValue">The value to return if the conversion fails.</param>
    /// <returns>The converted value except in the event of an exception or a DBNull which will return the defaulted value.</returns>
    public static decimal ToDecimal(Object convertValue, decimal defaultValue)
    {
      try
      {
        if (Convert.IsDBNull(convertValue) || (convertValue == null)) return defaultValue;

        decimal num;
        var isNum = decimal.TryParse(convertValue.ToString(), out num);
        return isNum ? num : defaultValue;
      }
      catch
      {
        return defaultValue;
      }
    }

    /// <summary>
    /// Converts the objects value to a Guid value if possible. Returns the default value if 
    /// not.
    /// </summary>
    /// <param name="convertValue">The object value to convert to a Guid.</param>
    /// <param name="defaultValue">The value to return if the conversion fails.</param>
    /// <returns>The converted value except in the event of an exception or a DBNull which will return the defaulted value.</returns>
    public static Guid ToGuid(object convertValue, Guid defaultValue)
    {
      try
      {
        if (!Convert.IsDBNull(convertValue))
        {
          return new Guid(convertValue.ToString());
        }
        else
        {
          return defaultValue;
        }
      }
      catch
      {
        return defaultValue;
      }
    }


    /// <summary>
    /// Converts the objects value to a nullable Guid value if possible. Returns the default value if not.
    /// Note that if the convertValue is null or DBNull.Value, the result will be null regardless of what the defaultValue is.
    /// </summary>
    /// <param name="convertValue">The object value to convert to a Guid.</param>
    /// <param name="defaultValue">The value to return if the conversion fails.</param>
    /// <returns>The converted value except in the event of an exception or a DBNull which will return the defaulted value.</returns>
    public static Guid? ToNullableGuid(object convertValue, Guid? defaultValue)
    {
      try
      {
        if (convertValue == null || Convert.IsDBNull(convertValue))
          return null;
        else
          return new Guid(convertValue.ToString());
      }
      catch
      {
        return defaultValue;
      }
    }

    /// <summary>
    /// Converts the objects value to a double value if possible. Returns the default value if 
    /// not.
    /// </summary>
    /// <param name="convertValue">The object value to convert to a double.</param>
    /// <param name="defaultValue">The value to return if the conversion fails.</param>
    /// <returns>The converted value except in the event of an exception or a DBNull which will return the defaulted value.</returns>
    public static double ToDouble(Object convertValue, double defaultValue)
    {
      try
      {
        if (!Convert.IsDBNull(convertValue) && (convertValue != null))
        {
          double num;
          bool isNum = Double.TryParse(convertValue.ToString(), out num);
          if (isNum)
            return num;
          else
            return defaultValue;
        }
        else
        {
          return defaultValue;
        }
      }
      catch
      {
        return defaultValue;
      }
    }

    /// <summary>
    /// Parses an enumerated value based on the specified enumerated type. If the 
    /// string value does not match a proper enumerated field, then the defaultValue
    /// is used
    /// </summary>
    /// <param name="enumType">The type of enumeration. Ex: typeof(Relation)</param>
    /// <param name="enumValue">The enumeration string value. Ex: "Relation"</param>
    /// <param name="defaultValue">The default value to use if the conversion 
    /// fails. Ex: NamedInsured</param>
    /// <returns>The enumeration value</returns>
    public static Object ToEnum(Type enumType, string enumValue, Object defaultValue)
    {
      try
      {
        return Enum.Parse(enumType, enumValue, true);
      }
      catch
      {
        return defaultValue;
      }
    }

    /// <summary>
    /// Converts the objects value to a type string or returns the default value if it can't be converted.
    /// </summary>
    /// <param name="convertValue">The object value to convert to a string.</param>
    /// <param name="defaultValue">The value to return if the conversion fails.</param>
    /// <returns>The converted value except in the event of an exception or a DBNull which will return the defaulted value.</returns>
    public static string ToString(Object convertValue, string defaultValue)
    {
      try
      {
        if (!Convert.IsDBNull(convertValue))
        {
          return Convert.ToString(convertValue);
        }
        else
        {
          return defaultValue;
        }
      }
      catch
      {
        return defaultValue;
      }
    }

    /// <summary>
    /// Returns a Y or N for the boolean value passed in. Default return in N.
    /// </summary>
    /// <param name="convertValue">Boolean value.</param>
    /// <returns>String - "Y" or "N".</returns>
    public static string BoolToYN(bool convertValue)
    {
      if (convertValue) { return "Y"; }

      return "N";
    }

    /// <summary>
    /// Returns a Yes or No for the boolean value passed in. Default return in No.
    /// </summary>
    /// <param name="convertValue">Boolean value.</param>
    /// <returns>String - "Yes" or "No".</returns>
    public static string BoolToYesNo(bool convertValue)
    {
      if (convertValue) { return "Yes"; }

      return "No";
    }

    /// <summary>
    /// Returns true or false for a Y/N value.
    /// </summary>
    /// <param name="convertValue">string Y or N</param>
    /// <returns>bool</returns>
    public static bool YNToBool(string convertValue)
    {
      if (convertValue.ToUpper() == "Y") { return true; }

      return false;
    }

    /// <summary>
    /// Returns true or false for a Y/N value.
    /// </summary>
    /// <param name="convertValue">char Y or N</param>
    /// <returns>bool</returns>
    public static bool YNToBool(char convertValue)
    {
      if (convertValue.ToString().ToUpper() == "Y") { return true; }

      return false;
    }

    /// <summary>
    /// Returns true or false for a Yes/No value.
    /// </summary>
    /// <param name="convertValue">string Yes or No</param>
    /// <returns>bool</returns>
    public static bool YesNoToBool(string convertValue)
    {
      if (convertValue.ToUpper() == "YES") { return true; }

      return false;
    }

    /// <summary>
    /// Fixes a string value such that it can be inserted directly into sql statements.
    /// Basically all this does is (if the string is a null value, return the value
    /// DBNull.Value. If the string is an actual string, then this returns the string)
    /// </summary>
    /// <param name="value">The string value that we're gonna fix</param>
    /// <returns>The sql "fixed" string value</returns>
    public static Object SQLFixString(string value)
    {
      if (value == null)
        return DBNull.Value;
      else
        return value;
    }

    /// <summary>
    /// Makes sure a date/time value is within the parameters acceptable by 
    /// SQL Server.
    /// </summary>
    /// <param name="sourceDate">The date you want to check</param>
    /// <returns>The fixed date; that is, between the acceptable
    /// sql server min/max date values</returns>
    public static DateTime SQLFixDate(DateTime sourceDate)
    {
      if (sourceDate < SQL_MIN_DATE)
        return SQL_MIN_DATE;
      if (sourceDate > SQL_MAX_DATE)
        return SQL_MAX_DATE;
      return sourceDate;
    }

    /// <summary>
    /// Creates a split string value of the array values passed in.
    /// </summary>
    /// <param name="convertValue">The array of values</param>
    /// <param name="delimiter">The value to use as a delimiter.</param>
    /// <returns>String</returns>
    public static string ToSplitString(Array convertValue, string delimiter)
    {
      StringBuilder Result = new StringBuilder("");

      try
      {
        foreach (byte Value in convertValue)
        {
          Result.Append(Value.ToString() + delimiter.ToString());
        }

        //Remove the last delimiter
        Result.Remove(Result.Length, 1);
      }
      catch
      {
        //eat the exception
      }

      return Result.ToString();
    }

    /// <summary>
    /// Convert a USState enum to an integer CMP product number.
    /// </summary>
    /// <param name="state">The state you want the cmp product number for.</param>
    /// <returns>int productnumber</returns>
    public static int USStateToProductNumber(USState state)
    {
      //Using switch here because it's faster then if/then
      switch (state)
      {
        case USState.Texas:
          return 1940;
        case USState.Oklahoma:
          return 2428;
        case USState.Illinois:
          return 2621;
        case USState.Indiana:
          return 2792;
        case USState.Colorado:
          return 2840;
        case USState.Missouri:
          return 2915;
        case USState.Ohio:
          return 2958;
        case USState.Tennessee:
          return 3065;
        case USState.Kentucky:
          return 3112;
        case USState.Virginia:
          return 3159;
        case USState.Kansas:
          return 3426;
        case USState.Arkansas:
          return 3506;
        case USState.Wisconsin:
          return 3543;
        case USState.Louisiana:
          return 3941;
        case USState.Arizona:
          return 4091;
        case USState.NewMexico:
          return 4146;
        case USState.California:
          return 4252;
        case USState.Nevada:
          return 4515;
        case USState.NorthCarolina:
          return 4577;
        case USState.Oregon:
          return 4579;
        case USState.Utah:
          return 4575;
        case USState.Florida:
          return 4576;
        case USState.Michigan:
          return 4578;
        case USState.Alaska:
          return 4596;
        case USState.Alabama:
          return 4591;
        case USState.Connecticut:
          return 4590;
        case USState.DistrictOfColumbia:
          return 4607;
        case USState.Delaware:
          return 4597;
        case USState.Georgia:
          return 4592;
        case USState.Hawaii:
          return 4598;
        case USState.Iowa:
          return 4593;
        case USState.Idaho:
          return 4582;
        case USState.Massachusetts:
          return 4588;
        case USState.Maryland:
          return 4584;
        case USState.Maine:
          return 4599;
        case USState.Minnesota:
          return 4587;
        case USState.Mississippi:
          return 4594;
        case USState.Montana:
          return 4600;
        case USState.NorthDakota:
          return 4602;
        case USState.Nebraska:
          return 4589;
        case USState.NewHampshire:
          return 4601;
        case USState.NewJersey:
          return 4586;
        case USState.NewYork:
          return 4581;
        case USState.Pennsylvania:
          return 4585;
        case USState.RhodeIsland:
          return 4603;
        case USState.SouthCarolina:
          return 1982;
        case USState.SouthDakota:
          return 4604;
        case USState.Vermont:
          return 4605;
        case USState.Washington:
          return 4580;
        case USState.WestVirginia:
          return 4595;
        case USState.Wyoming:
          return 4606;
        default:
          return -1;
      }
    }

    /// <summary>
    /// Returns the state enum for the specified state abbreviation
    /// </summary>
    /// <param name="stateAbbrev">abbreviation for a state...ex: TX for Texas</param>
    /// <returns>The enum value</returns>
    public static USState StateAbbrevToEnum(string stateAbbrev)
    {
      if (String.IsNullOrEmpty(stateAbbrev))
        return USState.NoneSelected;
      int index = Array.IndexOf(ITCConstants.StateAbbreviations, stateAbbrev.ToUpper()); //Added the ToUpper to remove case sensitivity
      if (index == -1)
        return USState.NoneSelected;
      else
        return (USState)index;
    }

    /// <summary>
    /// Returns the state enum for the specified state name
    /// </summary>
    /// <param name="stateName">name of a state...ex: Texas</param>
    /// <returns>The enum value</returns>
    public static USState StateNameToEnum(string stateName)
    {
      int index = Array.IndexOf(ITCConstants.StateNames, stateName);
      if (index == -1)
        return USState.NoneSelected;
      else
        return (USState)index;
    }

    /// <summary>
    /// Returns a USState name for the CMPProduct number passed in.
    /// </summary>
    /// <param name="productNumber">The CMPProduct to convert.</param>
    /// <returns>The string value of the state name.</returns>
    public static string CMPProductNumberToUSStateName(int productNumber)
    {
      return ITCConstants.StateNames[(int)CMPProductNumberToUSState(productNumber)];
    }

    /// <summary>
    /// Returns a USState value for the CMPProduct number passed in.
    /// </summary>
    /// <param name="productNumber">The CMPProduct to convert.</param>
    /// <returns>USState.</returns>
    public static USState CMPProductNumberToUSState(int productNumber)
    {
      //Using switch here because it's faster then if/then
      switch (productNumber)
      {
        case 1940:
          return USState.Texas;
        case 2428:
          return USState.Oklahoma;
        case 2621:
          return USState.Illinois;
        case 2792:
          return USState.Indiana;
        case 2840:
          return USState.Colorado;
        case 2915:
          return USState.Missouri;
        case 2958:
          return USState.Ohio;
        case 3065:
          return USState.Tennessee;
        case 3112:
          return USState.Kentucky;
        case 3159:
          return USState.Virginia;
        case 3426:
          return USState.Kansas;
        case 3506:
          return USState.Arkansas;
        case 3543:
          return USState.Wisconsin;
        case 3941:
          return USState.Louisiana;
        case 4091:
          return USState.Arizona;
        case 4146:
          return USState.NewMexico;
        case 4252:
          return USState.California;
        case 4515:
          return USState.Nevada;
        case 4577:
          return USState.NorthCarolina;
        case 4579:
          return USState.Oregon;
        case 4575:
          return USState.Utah;
        case 4576:
          return USState.Florida;
        case 4578:
          return USState.Michigan;
        case 4596:
          return USState.Alaska;
        case 4591:
          return USState.Alabama;
        case 4590:
          return USState.Connecticut;
        case 4607:
          return USState.DistrictOfColumbia;
        case 4597:
          return USState.Delaware;
        case 4592:
          return USState.Georgia;
        case 4598:
          return USState.Hawaii;
        case 4593:
          return USState.Iowa;
        case 4582:
          return USState.Idaho;
        case 4588:
          return USState.Massachusetts;
        case 4584:
          return USState.Maryland;
        case 4599:
          return USState.Maine;
        case 4587:
          return USState.Minnesota;
        case 4594:
          return USState.Mississippi;
        case 4600:
          return USState.Montana;
        case 4602:
          return USState.NorthDakota;
        case 4589:
          return USState.Nebraska;
        case 4601:
          return USState.NewHampshire;
        case 4586:
          return USState.NewJersey;
        case 4581:
          return USState.NewYork;
        case 4585:
          return USState.Pennsylvania;
        case 4603:
          return USState.RhodeIsland;
        case 1982:
          return USState.SouthCarolina;
        case 4604:
          return USState.SouthDakota;
        case 4605:
          return USState.Vermont;
        case 4580:
          return USState.Washington;
        case 4595:
          return USState.WestVirginia;
        case 4606:
          return USState.Wyoming;

        default:
          return USState.NoneSelected;
      }
    }

    /// <summary>
    /// Convert a USState abbrev to an integer CMP product number.
    /// </summary>
    /// <param name="stateAbbrev">The state you want the cmp product number for.</param>
    /// <returns>int productnumber</returns>
    public static int StateAbbrevToProductNumber(string stateAbbrev)
    {
      //Using switch here because it's faster then if/then
      switch (stateAbbrev.ToUpper())
      {
        case "TX":
          return 1940;
        case "OK":
          return 2428;
        case "IL":
          return 2621;
        case "IN":
          return 2792;
        case "CO":
          return 2840;
        case "MO":
          return 2915;
        case "OH":
          return 2958;
        case "TN":
          return 3065;
        case "KY":
          return 3112;
        case "VA":
          return 3159;
        case "KS":
          return 3426;
        case "AR":
          return 3506;
        case "WI":
          return 3543;
        case "LA":
          return 3941;
        case "AZ":
          return 4091;
        case "NM":
          return 4146;
        case "CA":
          return 4252;
        case "NV":
          return 4515;
        case "NC":
          return 4577;
        case "OR":
          return 4579;
        case "UT":
          return 4575;
        case "FL":
          return 4576;
        case "MI":
          return 4578;
        case "AK":
          return 4596;
        case "AL":
          return 4591;
        case "CT":
          return 4590;
        case "DC":
          return 4607;
        case "DE":
          return 4597;
        case "GA":
          return 4592;
        case "HI":
          return 4598;
        case "IA":
          return 4593;
        case "ID":
          return 4582;
        case "MA":
          return 4588;
        case "MD":
          return 4584;
        case "ME":
          return 4599;
        case "MN":
          return 4587;
        case "MS":
          return 4594;
        case "MT":
          return 4600;
        case "ND":
          return 4602;
        case "NE":
          return 4589;
        case "NH":
          return 4601;
        case "NJ":
          return 4586;
        case "NY":
          return 4581;
        case "PA":
          return 4585;
        case "RI":
          return 4603;
        case "SC":
          return 1982;
        case "SD":
          return 4604;
        case "VT":
          return 4605;
        case "WA":
          return 4580;
        case "WV":
          return 4595;
        case "WY":
          return 4606;
        default:
          return -1;
      }
    }
    /// <summary>
    /// Converts the objects value to a float value if possible. Returns the default value if 
    /// not.
    /// </summary>
    /// <param name="convertValue">The object value to convert to a float.</param>
    /// <param name="defaultValue">The value to return if the conversion fails.</param>
    /// <returns>The converted value except in the event of an exception or a DBNull which will return the defaulted value.</returns>
    public static float ToFloat(Object convertValue, float defaultValue)
    {
      try
      {
        if (!Convert.IsDBNull(convertValue) && (convertValue != null))
        {
          float num;
          bool isNum = float.TryParse(convertValue.ToString(), out num);
          if (isNum)
            return num;
          else
            return defaultValue;
        }
        else
        {
          return defaultValue;
        }
      }
      catch
      {
        return defaultValue;
      }
    }

  }
}
