using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TurboRater
{
  /// <summary>
  /// Summary description for IndexLib.
  /// </summary>
  public sealed class IndexLib
  {
    /// <summary>
    /// This variable is used by the realtime server to force checking the lengths of arrays against their enum partners. This
    /// was done as a result of needing to be able to easily find every single module that improperly overrides an array, but without 
    /// making them fail to rate. ontime req#1805
    /// </summary>
    public static bool ForceValidateArrayLengthsFromEnum;

    /// <summary>
    /// Hiding default constructor
    /// </summary>
    private IndexLib()
    {
    }

    /// <summary>
    /// An exception thrown when there is an error assigning one array reference to another; used in real-time rating.
    /// </summary>
    [Serializable]
    public class InvalidArrayAssignmentException : ApplicationException
    {
      public InvalidArrayAssignmentException()
        : base()
      {
      }
      public InvalidArrayAssignmentException(string message)
        : base(message)
      {
      }
      public InvalidArrayAssignmentException(string message, Exception innerException)
        : base(message, innerException)
      {
      }
      protected InvalidArrayAssignmentException(SerializationInfo info, StreamingContext context)
        : base(info, context)
      {
      }
    }

    /// <summary>
    /// Retrieves the index of an integer within an array.
    /// </summary>
    /// <param name="value">integer value we're looking for.</param>
    /// <param name="searchList">the array we're searching in.</param>
    /// <param name="indexToReturn">the index of the value.</param>
    /// <returns>true if value found, otherwise false.</returns>
    public static bool GetIntegerIndex(int value, int[] searchList, out int indexToReturn)
    {
      indexToReturn = ITCConstants.InvalidNum;
      for (int index = 0; index < searchList.Length; index++)
      {
        if (value == searchList[index])
        {
          indexToReturn = index;
          break;
        }
      }
      return (indexToReturn != ITCConstants.InvalidNum);
    }

    public static bool GetIntegerRangeIndex(int value, int[,] searchList, out int indexToReturn)
    {
      indexToReturn = ITCConstants.InvalidNum;
      for (int index = 0; index < searchList.Length; index++)
      {
        if ((value >= searchList[index, 0]) && (value <= searchList[index, 1]))
        {
          indexToReturn = index;
          break;
        }
      }
      return (indexToReturn != ITCConstants.InvalidNum);
    }

    /// <summary>
    /// Retrieves the index of a string within an array.
    /// </summary>
    /// <param name="value">string value we're looking for.</param>
    /// <param name="searchList">the array we're searching in.</param>
    /// <param name="indexToReturn">the index of the value.</param>
    /// <returns>true if value found, otherwise false.</returns>
    public static bool GetStringIndex(string value, string[] searchList, out int indexToReturn)
    {
      indexToReturn = ITCConstants.InvalidNum;
      for (int index = 0; index < searchList.Length; index++)
      {
        if (value.Trim().ToUpper() == searchList[index].Trim().ToUpper())
        {
          indexToReturn = index;
          break;
        }
      }
      return (indexToReturn != ITCConstants.InvalidNum);
    }

    /// <summary>
    /// Retrieves the index of a string within an array.
    /// </summary>
    /// <param name="value">integer value we're looking for.</param>
    /// <param name="searchList">the array we're searching in.</param>
    /// <param name="defaultValue">The default index position to use if the item isnot found.</param>
    /// <returns>index of the item within the array if found, otherwise the defaultValue.</returns>
    public static int GetStringIndex(string value, string[] searchList, int defaultValue)
    {
      int indexToReturn = defaultValue;
      if (value != null)
      {
        for (int index = 0; index < searchList.Length; index++)
        {
          if (value.Trim().ToUpper() == searchList[index].Trim().ToUpper())
          {
            indexToReturn = index;
            break;
          }
        }
      }
      return indexToReturn;
    }

    /// <summary>
    /// Finds a date/time value within an array of date/time values. Note that
    /// this finds the nearest date less than or equal to the date passed in, so it
    /// doesn't have to be an exact match. It is assumed that this date/time array
    /// is already sorted chronologically from newest down to oldest.
    /// </summary>
    /// <param name="value">the value to search for.</param>
    /// <param name="searchList">the array of values to search in.</param>
    /// <param name="indexToReturn">the index of the value within searchList.</param>
    /// <returns>True if the date was found, otherwise false.</returns>
    public static bool GetDateIndex(DateTime value, DateTime[] searchList, out int indexToReturn)
    {
      indexToReturn = ITCConstants.InvalidNum;
      for (int index = 0; index < searchList.Length; index++)
      {
        if (value > searchList[index])
        {
          indexToReturn = index;
          break;
        }
      }
      return (indexToReturn != ITCConstants.InvalidNum);
    }

    /// <summary>
    /// converts an enumeration variable to its string value representation. this string
    /// value comes from an array of strings that you pass in and must have the same number
    /// of members as the enumeration.
    /// </summary>
    /// <param name="enumValue">The enum for which to retrieve the string value.</param>
    /// <param name="enumValues">The array of string values for the enumeration.</param>
    /// <returns>The string value representation of an enumeration.</returns>
    public static string EnumToArrayValue(Object enumValue, string[] enumValues)
    {
      return enumValues[(int)enumValue];
    }

    /// <summary>
    /// Returns the enumeration value for a passed in string value. The string value
    /// must be a member of the list enumValues, which is an array that matches up string
    /// values with your enumeration.
    /// </summary>
    /// <param name="enumType">The enumeration type. Ex: typeof(ITC.Utilities.USState)</param>
    /// <param name="enumValue">The enumeration variable. Ex: InsuredAddress.State</param>
    /// <param name="enumValues">The string array of enumeration string values. Ex: 
    /// ITC.Utilities.Constants.StateNames</param>
    /// <returns>An enumeration variable that corresponds to the string value passed in.</returns>
    public static Object ArrayValueToEnum(Type enumType, string enumValue, string[] enumValues)
    {
      int valueIndex;
      if (GetStringIndex(enumValue, enumValues, out valueIndex))
      {
        return Enum.Parse(enumType, valueIndex.ToString());
      }
      else //if enum value not found, return the first enum value from the list
        return Enum.Parse(enumType, Enum.GetNames(enumType)[0]);
    }

    /// <summary>
    /// Finds the index of the first int in a list that is greater than the specified value.
    /// </summary>
    /// <param name="lookupVal">The int value to find.</param>
    /// <param name="groups">The groups to search.</param>
    /// <param name="index">The index of the value if found.</param>
    /// <param name="baseIndex">The base index, for example 0 or 1 based.</param>
    /// <returns>The index of the int within the groups.</returns>
    public static bool GetGroupIntegerIndex(int lookupVal, IList<int> groups, out int index, int baseIndex = 0)
    {
      bool result = false;
      int valueIndex = 0;
      foreach (int value in groups)
      {
        if (lookupVal <= value)
        {
          result = true;
          break;
        }
        valueIndex++;
      }
      valueIndex += baseIndex;
      if (!result)
        valueIndex = baseIndex;
      index = valueIndex;
      return result;
    }

  }
}
