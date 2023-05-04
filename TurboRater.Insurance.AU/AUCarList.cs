using System;
using System.Collections;
using System.Collections.Generic;

namespace TurboRater.Insurance.AU
{
  /// <summary>
  /// A list for holding AUCar objects
  /// </summary>
  /// <seealso cref="AUCar">AUCar</seealso>
  [Serializable]
  public class AUCarList
  {
    /// <summary>
    /// returns the number of items in the array list
    /// </summary>
    public virtual int Count
    {
      get { return Items.Count; }
    }

    /// <summary>
    /// The list of items in the AUCar list. This property is just an ArrayList,
    /// so its methods and properties are not type-specific to this class. Don't use this property
    /// directly unless no other method or property of this class will do what you need.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant, IsArrayList = true, ListItemType = typeof(AUCar))]
    public virtual List<AUCar> Items { get; set; }

    /// <summary>
    /// Indexer for this class. Returns an AUCar object
    /// from the list of items.
    /// </summary>
    public virtual AUCar this[int index]
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
          throw new InvalidOperationException("Car list out of bounds");
      }
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public AUCarList()
    {
      Items = new List<AUCar>();
    }

    /// <summary>
    /// Sorts the list of items using the IComparer object passed in
    /// </summary>
    /// <param name="comparer">The object used to compare any two
    /// items in the list</param>
    public virtual void Sort(IComparer<AUCar> comparer)
    {
      Items.Sort(comparer);
    }

    /// <summary>
    /// Adds an AUCar item to the list
    /// </summary>
    /// <param name="value">The AUCar item to add</param>
    /// <returns>Integer index of the new item in the list</returns>
    public virtual int Add(AUCar value)
    {
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
      Items.Add((AUCar)value);
    }

    /// <summary>
    /// Inserts an AUCar item into the list
    /// </summary>
    /// <param name="index">Index in the list at which to insert the new AUCar 
    /// item</param>
    /// <param name="value">The AUCar item to insert</param>
    public virtual void Insert(int index, AUCar value)
    {
      Items.Insert(index, value);
    }

    /// <summary>
    /// Removes the specified AUCar item from the list
    /// </summary>
    /// <param name="value">The AUCar item to remove</param>
    public virtual void Remove(AUCar value)
    {
      Items.Remove(value);
    }

    /// <summary>
    /// Removes the AUCar item from the list at the specified
    /// index in the list.
    /// </summary>
    /// <param name="index">The index in the list of the AUCar
    /// item to remove</param>
    public virtual void RemoveAt(int index)
    {
      Items.RemoveAt(index);
    }

    /// <summary>
    /// Clears out the list of AUCar items
    /// </summary>
    public virtual void Clear()
    {
      Items.Clear();
    }

    /// <summary>
    /// Returns index of car in the list. 
    /// </summary>
    /// <param name="car">car you are looking for the index of</param>
    /// <returns>the index</returns>
    public virtual int IndexOf(AUCar car)
    {
      return Items.IndexOf(car);
    }

    /// <summary>
    /// Returns an enumerator object to loop through the items in the list
    /// </summary>
    /// <returns>An enumerator object to loop through the items in the list</returns>
    public IEnumerator GetEnumerator()
    {
      return Items.GetEnumerator();
    }

    /// <summary>
    /// Sets the premiums for all cars in the list to 0
    /// </summary>
    public void ZeroPremiums()
    {
      foreach (var car in Items)
        car.ZeroPremiums();
    }

    /// <summary>
    /// Turns off all coverage types for all cars except those contained in the "Leave Alone" list. 
    /// This is especially useful for turning off coverage types that don't apply to specific states.
    /// </summary>
    /// <param name="coverageTypesToLeaveAlone">Array of coverage types you want to leave at defaulted or imported value.</param>
    public virtual void RemoveAllCoverageTypesExceptX(CoverageType[] coverageTypesToLeaveAlone)
    {
      foreach (var car in Items)
        car.RemoveAllCoverageTypesExceptX(coverageTypesToLeaveAlone);
    }
  }
}
