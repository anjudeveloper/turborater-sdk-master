using System;
using TurboRater;
using System.Collections;
using System.Collections.Generic;

namespace TurboRater.Insurance.AU
{
  /// <summary>
  /// Represents a list of AUDriver objects.
  /// This is a wrapper class that adds some custom functionality to generic lists. 
  /// </summary>
  public class AUDriverList
  {
    /// <summary>
    /// returns the number of items in the array list
    /// </summary>
    public virtual int Count
    {
      get { return Items.Count; }
    }

    /// <summary>
    /// The list of items in the AUDriver list. This property is just an ArrayList,
    /// so its methods and properties are not type-specific to this class. Don't use this property
    /// directly unless no other method or property of this class will do what you need.
    /// </summary>
    public virtual List<AUDriver> Items { get; set; }

    /// <summary>
    /// Indexer for this class. Returns an AUDriver object
    /// from the list of items.
    /// </summary>
    public virtual AUDriver this[int index]
    {
      get
      {
        if ((index > ITCConstants.InvalidNum) && (index < Items.Count))
          return Items[index];

        return null;
      }
      set
      {
        if ((index > ITCConstants.InvalidNum) && (index < Items.Count))
          Items[index] = value;
        else
          throw new InvalidOperationException("Driver list out of bounds");
      }
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public AUDriverList()
    {
      Items = new List<AUDriver>();
    }

    /// <summary>
    /// Sorts the list of items using the IComparer object passed in
    /// </summary>
    /// <param name="comparer">The object used to compare any two
    /// items in the list</param>
    public virtual void Sort(IComparer<AUDriver> comparer)
    {
      Items.Sort(comparer);
    }

    /// <summary>
    /// Adds an AUDriver item to the list
    /// </summary>
    /// <param name="value">The AUDriver item to add</param>
    /// <returns>Integer index of the new item in the list</returns>
    public virtual int Add(AUDriver value)
    {
      var highestDriverId = 0;
      foreach (var driver in Items)
        if (driver.DriverID > highestDriverId)
          highestDriverId = driver.DriverID;
      value.DriverID = highestDriverId + 1;
      Items.Add(value);
      return Items.Count - 1;
    }

    /// <summary>
    /// DO NOT USE! This is only here so we can use xml serialization
    /// </summary>
    /// <param name="value">stuff</param>
    [Obsolete("DO NOT USE! This is only here so we can use xml serialization.")]
    public void Add(Object value)
    {
      Items.Add((AUDriver)value);
    }


    /// <summary>
    /// Exposing index of for the wrapper class. 
    /// </summary>
    /// <param name="driver"></param>
    /// <returns></returns>
    public virtual int IndexOf(AUDriver driver)
    {
      return Items.IndexOf(driver);
    }

    /// <summary>
    /// Inserts an AUDriver item into the list
    /// </summary>
    /// <param name="index">Index in the list at which to insert the new AUDriver 
    /// item</param>
    /// <param name="value">The AUDriver item to insert</param>
    public virtual void Insert(int index, AUDriver value)
    {
      var highestDriverId = 0;
      foreach (var driver in Items)
        if (driver.DriverID > highestDriverId)
          highestDriverId = driver.DriverID;
      value.DriverID = highestDriverId + 1;
      Items.Insert(index, value);
    }

    /// <summary>
    /// Removes the specified AUDriver item from the list
    /// </summary>
    /// <param name="value">The AUDriver item to remove</param>
    public virtual void Remove(AUDriver value)
    {
      Items.Remove(value);
    }

    /// <summary>
    /// Removes the AUDriver item from the list at the specified
    /// index in the list.
    /// </summary>
    /// <param name="index">The index in the list of the AUDriver
    /// item to remove</param>
    public virtual void RemoveAt(int index)
    {
      Items.RemoveAt(index);
    }

    /// <summary>
    /// Clears out the list of AUDriver items
    /// </summary>
    public virtual void Clear()
    {
      Items.Clear();
    }

    /// <summary>
    /// Returns an enumerator object to loop through the items in the list
    /// </summary>
    /// <returns>An enumerator object to loop through the items in the list</returns>
    public IEnumerator GetEnumerator()
    {
      return Items.GetEnumerator();
    }
  }
}
