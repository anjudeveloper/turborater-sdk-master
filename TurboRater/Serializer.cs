using System;
using System.IO;
using System.Xml.Serialization;

namespace TurboRater
{
  /// <summary>
  /// Provides utilities for easily serializing objects.
  /// </summary>
  public sealed class Serializer
  {
    /// <summary>
    /// Just hiding the default constructor
    /// </summary>
    private Serializer()
    {
    }

    /// <summary>
    /// Takes an object that is serializable and writes it to an XML string.
    /// </summary>
    /// <param name="objectToSerialize">The object to convert to XML.</param>
    /// <param name="extraTypes">a System.Type array of additional object types to serialize.</param>
    /// <param name="serializer">If you've created/cached your own serializer object in your client, you can pass
    /// it in this parameter to prevent this method from creating a new one with each call.</param>
    /// <returns>A string of XML data representing the object passed in.</returns>
    public static string SerializeToXMLString(object objectToSerialize, Type[] extraTypes, XmlSerializer serializer = null)
    {
      XmlSerializer xml = serializer;
      if (xml == null)
      {
        if (extraTypes != null)
          xml = new XmlSerializer(objectToSerialize.GetType(), extraTypes);
        else
          xml = new XmlSerializer(objectToSerialize.GetType());
      }
      MemoryStream stream = new MemoryStream();
      xml.Serialize(stream, objectToSerialize);
      stream.Seek(0, SeekOrigin.Begin);
      StreamReader reader = new StreamReader(stream);
      return reader.ReadToEnd();
    }

    /// <summary>
		/// Takes an object that is serializable and writes it to an XML string.
		/// </summary>
		/// <param name="objectToSerialize">The object to convert to XML.</param>
		/// <returns>A string of XML data representing the object passed in.</returns>
		public static string SerializeToXMLString(object objectToSerialize)
    {
      return SerializeToXMLString(objectToSerialize, null);
    }

    /// <summary>
    /// Creates an object and loads its data from a serialized XML data string.
    /// </summary>
    /// <param name="xmlValue">The XML data to use to populate the new object.</param>
    /// <param name="objectType">The type of the object to create.</param>
    /// <param name="extraTypes">a System.Type array of additional object types to serialize.</param>
    /// <param name="serializer">If you've created/cached your own serializer object in your client, you can pass
    /// it in this parameter to prevent this method from creating a new one with each call.</param>
    /// <returns>A new object containing the data from the XML string.</returns>
    public static object DeserializeFromXMLString(string xmlValue, Type objectType, Type[] extraTypes, XmlSerializer serializer = null)
    {
      XmlSerializer xml = serializer;
      if (xml == null)
      {
        if (extraTypes != null)
          xml = new XmlSerializer(objectType, extraTypes);
        else
          xml = new XmlSerializer(objectType);
      }
      return xml.Deserialize(new StringReader(xmlValue));
    }

    /// <summary>
    /// Creates an object and loads its data from a serialized XML data string.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="xmlValue">The XML data to use to populate the new object.</param>
    /// <param name="extraTypes">a System.Type array of additional object types to serialize.</param>
    /// <param name="serializer">Optional pre-made serializer.  If null or not specified, a new one is created.</param>
    /// <returns>A new object containing the data from the XML string.</returns>
    public static T DeserializeFromXMLString<T>(string xmlValue, Type[] extraTypes, XmlSerializer serializer = null)
    {
      XmlSerializer xml = serializer;
      if (xml == null)
      {
        if (extraTypes != null)
          xml = new XmlSerializer(typeof(T), extraTypes);
        else
          xml = new XmlSerializer(typeof(T));
      }
      return (T)xml.Deserialize(new StringReader(xmlValue));
    }

    /// <summary>
    /// Creates an object and loads its data from a serialized XML data string.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="xmlValue">The XML data to use to populate the new object.</param>
    /// <returns>A new object containing the data from the XML string.</returns>
    public static T DeserializeFromXMLString<T>(string xmlValue)
    {
      return DeserializeFromXMLString<T>(xmlValue, null);
    }

    /// <summary>
    /// Creates an object and loads its data from a serialized XML data string.
    /// </summary>
    /// <param name="xmlValue">The XML data to use to populate the new object.</param>
    /// <param name="objectType">The type of the object to create.</param>
    /// <returns>A new object containing the data from the XML string.</returns>
    public static object DeserializeFromXMLString(string xmlValue, Type objectType)
    {
      return DeserializeFromXMLString(xmlValue, objectType, null);
    }
  }
}
