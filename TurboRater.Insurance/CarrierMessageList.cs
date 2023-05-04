using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurboRater.Insurance
{
  /// <summary>
  /// A list holder for Carrier Message items
  /// </summary>
  [Serializable]
  public class CarrierMessageList : List<CarrierMessage>
  {
    /// <summary>
    /// Default constructor
    /// </summary>
    public CarrierMessageList()
    {
    }

    /// <summary>
    /// Adds an Message item to the list
    /// </summary>
    /// <param name="value">The Message item to add</param>
    /// <returns>Integer index of the new item in the list</returns>
    public new int Add(CarrierMessage value)
    {
      if (AllowDuplicates)
      {
        base.Add(value);
        return this.Count - 1;
      }
      else
      {
        if (!this.Exists(item => value.Equals(item)))
        {
          base.Add(value);
          return this.Count - 1;
        }
      }
      return ITCConstants.InvalidNum;
    }

    /// <summary>
    /// Inserts an Message item into the list
    /// </summary>
    /// <param name="index">Index in the list at which to insert the new Message 
    /// item</param>
    /// <param name="value">The Message item to insert</param>
    public new void Insert(int index, CarrierMessage value)
    {
      if (AllowDuplicates)
        base.Insert(index, value);
      else
      {
        if (!this.Exists(item => value.Equals(item)))
          base.Insert(index, value);
      }
    }

    /// <summary>
    /// Determines whether or not the list allows duplicate messages. A message is 
    /// considered equivalent to another message if the following are all the same:
    /// a) text
    /// b) scope
    /// c) scope type
    /// d) percentage
    /// e) amount
    /// f) code
    /// In the event that a message is the same as one already in the list, the 
    /// new message is not added; no error thrown or anything, but no new message 
    /// in the list
    /// </summary>
    public virtual bool AllowDuplicates
    {
      get { return m_allowDuplicates; }
      set { m_allowDuplicates = value; }
    }

    private bool m_allowDuplicates;
  }
}
