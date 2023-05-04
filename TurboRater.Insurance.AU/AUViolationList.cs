using System;
using System.Collections;
using System.Collections.Generic;
using TurboRater;
using TurboRater.Insurance.AU;

namespace TurboRater.Insurance.AU
{
  /// <summary>
  /// Holds a list of AUViolation objects
  /// </summary>
  /// <seealso cref="AUViolation">AUViolation</seealso>
  [Serializable]
  public class AUViolationList
  {
    /// <summary>
    /// returns the number of items in the array list
    /// </summary>
    public virtual int Count
    {
      get { return Items.Count; }
    }

    /// <summary>
    /// The list of items in the AUViolation list. This property is just an ArrayList,
    /// so its methods and properties are not type-specific to this class. Don't use this property
    /// directly unless no other method or property of this class will do what you need.
    /// </summary>
    public virtual List<AUViolation> Items { get; set; }

    /// <summary>
    /// Copies an Array to Items.
    /// </summary>
    /// <param name="violationList">The Array to copy.</param>
    public virtual void CopyTo(AUViolation[] violationList)
    {
      Items.CopyTo(violationList);
    }

    /// <summary>
    /// Copies a list to Items. 
    /// </summary>
    /// <param name="violationList">The List to copy</param>
    public virtual void CopyTo(List<AUViolation> violationList)
    {
      Items.CopyTo(violationList.ToArray());
    }

    /// <summary>
    /// Indexer for this class. Returns an AUViolation object
    /// from the list of items.
    /// </summary>
    public virtual AUViolation this[int index]
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
          throw new InvalidOperationException("Violation list out of bounds");
      }
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public AUViolationList()
    {
      Items = new List<AUViolation>();
    }

    /// <summary>
    /// Sorts the list of items using the IComparer object passed in
    /// </summary>
    /// <param name="comparer">The object used to compare any two
    /// items in the list</param>
    public virtual void Sort(IComparer<AUViolation> comparer)
    {
      Items.Sort(comparer);
    }

    /// <summary>
    /// Adds an AUViolation item to the list
    /// </summary>
    /// <param name="value">The AUViolation item to add</param>
    /// <returns>Integer index of the new item in the list</returns>
    public virtual int Add(AUViolation value)
    {
      Items.Add(value);
      return Items.Count - 1;
    }

    /// <summary>
    /// Inserts an AUViolation item into the list
    /// </summary>
    /// <param name="index">Index in the list at which to insert the new AUViolation
    /// item</param>
    /// <param name="value">The AUViolation item to insert</param>
    public virtual void Insert(int index, AUViolation value)
    {
      Items.Insert(index, value);
    }

    /// <summary>
    /// Removes the specified AUViolation item from the list
    /// </summary>
    /// <param name="value">The AUViolation item to remove</param>
    public virtual void Remove(AUViolation value)
    {
      Items.Remove(value);
    }

    /// <summary>
    /// Exposing IndexOf from inner generic list. 
    /// </summary>
    /// <param name="violation"></param>
    /// <returns></returns>
    public virtual int IndexOf(AUViolation violation)
    {
      return Items.IndexOf(violation);
    }

    /// <summary>
    /// Removes the AUViolation item from the list at the specified
    /// index in the list.
    /// </summary>
    /// <param name="index">The index in the list of the AUViolation
    /// item to remove</param>
    public virtual void RemoveAt(int index)
    {
      Items.RemoveAt(index);
    }

    /// <summary>
    /// Clears out the list of AUViolation items
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

