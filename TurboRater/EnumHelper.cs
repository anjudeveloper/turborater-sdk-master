using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace TurboRater
{
  /// <summary>
  /// Contains static helper methods for dealing with enumerated types.
  /// Specifically, it will allow you to get the "Description" attribute
  /// value for display in a drop-down list type of entry. Might do other
  /// things in the future :)
  /// </summary>
  public sealed class EnumHelper
  {
    /// <summary>
    /// Same as the .net function Enum.Parse, except you can specify a default result
    /// if the value string doesn't match any of the enumerated values.
    /// </summary>
    /// <param name="enumType">The System.Type of the enumeration</param>
    /// <param name="value">A string containing the name or value to convert</param>
    /// <param name="ignoreCase">If true, ignore case; otherwise, regard case. </param>
    /// <param name="defaultValue">The default value to return if the value passed in
    /// does not match one of the enumeration values</param>
    /// <returns>An object of type enumType whose value is represented by value. (or the defaultvalue)</returns>
    public static Object Parse(Type enumType, string value, bool ignoreCase, Object defaultValue)
    {
      try
      {
        return Enum.Parse(enumType, value, ignoreCase);
      }
      catch
      {
        return defaultValue;
      }
    }

    /// <summary>
    /// Get the description attribute for one enum value
    /// </summary>
    /// <param name="value">Enum value</param>
    /// <returns>The description attribute of an enum, if any</returns>
    public static string GetDescription(Enum value)
    {
      FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
      DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
      return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
    }

    /// <summary>
    /// gets the value of the named attribute type for the specified enum value.
    /// </summary>
    /// <param name="value">Enum value.</param>
    /// <param name="attributeType">The attribute type. For example, DescriptionAttribute.</param>
    /// <param name="valuePropertyName">The name of the property within the attribute type that containes the value we're looking for.</param>
    /// <returns>The specified attribute value or null if not present.</returns>
    public static Object GetAttributeValue(Enum value, Type attributeType, string valuePropertyName)
    {
      FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
      Object[] attributes = fieldInfo.GetCustomAttributes(false);
      if (attributes != null && attributes.Length > 0)
      {
        foreach (var attribute in attributes)
        {
          if (attribute.GetType() == attributeType)
          {
            var property = attribute.GetType().GetProperty(valuePropertyName);
            if (property != null)
              return property.GetValue(attribute, null);
          }
        }
      }
      return null;
    }

    /// <summary>
    /// Gets all descriptions for an enum type.
    /// </summary>
    /// <param name="enumType">The type of the enum.</param>
    /// <returns>All description attributes for the enum.</returns>
    public static IList<string> GetDescriptions(Type enumType)
    {
      List<string> result = new List<string>();
      foreach (Enum enumValue in Enum.GetValues(enumType))
        result.Add(GetDescription(enumValue));
      return result;
    }

    /// <summary>
    /// Gets a list of key/value pairs for an enum, using the description attribute as value
    /// </summary>
    /// <param name="enumType">typeof(your enum type)</param>
    /// <returns>A list of KeyValuePairs with enum values and descriptions</returns>
    public static List<KeyValuePair<string, string>> GetValuesAndDescription(System.Type enumType)
    {
      List<KeyValuePair<string, string>> kvPairList = new List<KeyValuePair<string, string>>();

      foreach (Enum enumValue in Enum.GetValues(enumType))
      {
        kvPairList.Add(new KeyValuePair<string, string>(enumValue.ToString(), GetDescription(enumValue)));
      }

      return kvPairList;
    }

    /// <summary>
    /// hiding the default constructor
    /// </summary>
    private EnumHelper()
    {
    }

  }

}
