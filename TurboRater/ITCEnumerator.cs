using System;
using System.Collections;

namespace TurboRater
{
  /// <summary>
  /// ITC's base class for implementing an Enumerator object
  /// </summary>
  public class ITCEnumerator : IEnumerator
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="items">An ArrayList of the items to enumerate</param>
    public ITCEnumerator(ArrayList items)
    {
      this.items = items;
      index = ITCConstants.InvalidNum;
    }

    /// <summary>
    /// Returns the currently selected object from the list. 
    /// </summary>
    /// <throws>InvalidOperationException if the item is out of bounds of the list</throws>
    public object Current
    {
      get
      {
        if (this.index == ITCConstants.InvalidNum)
          throw new InvalidOperationException("You must call MoveNext before you use Current.");
        if (this.index >= items.Count)
          throw new InvalidOperationException("You have moved past the end of the collection.");
        return this.items[index];
      }
    }

    /// <summary>
    /// Moves the currently selected object to the next item in the list
    /// </summary>
    /// <returns>True if the item is within the bounds of the list, otherwise false</returns>
    public bool MoveNext()
    {
      index++;
      return (index < items.Count);
    }

    /// <summary>
    /// Resets the index back to before the first item in the list
    /// </summary>
    public void Reset()
    {
      this.index = ITCConstants.InvalidNum;
    }

    private ArrayList items;
    private int index;
  }
}
