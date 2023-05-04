using System;
using System.Collections;

namespace TurboRater.Insurance
{
  /// <summary>
  /// A list holder for PayPlan items
  /// </summary>
  public class PayPlanList : IEnumerable
  {
    /// <summary>
    /// Returns the first pay plan that has the IsDefault flag set to true.
    /// If no pay plan has the IsDefault flag set, then returns a null 
    /// reference.
    /// </summary>
    public virtual PayPlan DefaultPayPlan
    {
      get
      {
        foreach (PayPlan payPlan in Items)
          if (payPlan.IsDefault)
            return payPlan;
        return null;
      }
    }

    /// <summary>
    /// Returns the first pay plan that has the IsSelected flag set to true.
    /// If no pay plan has the IsSelected flag set, then returns a null 
    /// reference.
    /// </summary>
    public virtual PayPlan SelectedPayPlan
    {
      get
      {
        foreach (PayPlan payPlan in Items)
          if (payPlan.IsSelected)
            return payPlan;
        return null;
      }
    }

    /// <summary>
    /// Sorts the list of items using the IComparer object passed in
    /// </summary>
    /// <param name="comparer">The object used to compare any two
    /// items in the list</param>
    public virtual void Sort(System.Collections.IComparer comparer)
    {
      Items.Sort(comparer);
    }

    /// <summary>
    /// Resorts the list of pay plans so that the default plan
    /// (the one that has (IsDefault set to true) is the first one
    /// in the list.
    /// </summary>
    public virtual void PutDefaultFirst()
    {
      PayPlan originalFirstPlan;
      if (Items.Count > 0)
      {
        originalFirstPlan = DefaultPayPlan;
        if (DefaultPayPlan != null)
        {
          int defaultIndex = Items.IndexOf(DefaultPayPlan);
          if ((defaultIndex != 0) && (defaultIndex != -1))
          {
            Items[defaultIndex] = originalFirstPlan;
            Items[0] = DefaultPayPlan;
          }
        }
      }
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public PayPlanList()
    {
      m_items = new System.Collections.ArrayList();
    }

    /// <summary>
    /// Adds an PayPlan item to the list
    /// </summary>
    /// <param name="value">The PayPlan item to add</param>
    /// <returns>Integer index of the new item in the list</returns>
    public virtual int Add(PayPlan value)
    {
      return Items.Add(value);
    }

    /// <summary>
    /// Inserts an PayPlan item into the list
    /// </summary>
    /// <param name="index">Index in the list at which to insert the new PayPlan 
    /// item</param>
    /// <param name="value">The PayPlan item to insert</param>
    public virtual void Insert(int index, PayPlan value)
    {
      Items.Insert(index, value);
    }

    /// <summary>
    /// Removes the specified PayPlan item from the list
    /// </summary>
    /// <param name="value">The PayPlan item to remove</param>
    public virtual void Remove(PayPlan value)
    {
      Items.Remove(value);
    }

    /// <summary>
    /// Removes the PayPlan item from the list at the specified
    /// index in the list.
    /// </summary>
    /// <param name="index">The index in the list of the PayPlan
    /// item to remove</param>
    public virtual void RemoveAt(int index)
    {
      Items.RemoveAt(index);
    }

    /// <summary>
    /// Clears out the list of PayPlan items
    /// </summary>
    public virtual void Clear()
    {
      Items.Clear();
    }

    /// <summary>
    /// returns the number of items in the array list
    /// </summary>
    public virtual int Count
    {
      get { return Items.Count; }
    }

    /// <summary>
    /// The list of items in the PayPlan list. This property is just an ArrayList,
    /// so its methods and properties are not type-specific to this class. Don't use this property
    /// directly unless no other method or property of this class will do what you need.
    /// </summary>
    [PropertyStorage(System.Data.SqlDbType.Variant, IsArrayList = true, ListItemType = typeof(PayPlan))]
    public virtual System.Collections.ArrayList Items
    {
      get { return m_items; }
      set { m_items = value; }
    }

    /// <summary>
    /// Indexer for this class. Returns an PayPlan object
    /// from the list of items.
    /// </summary>
    public virtual PayPlan this[int index]
    {
      get
      {
        if ((index > ITCConstants.InvalidNum) && (index < Items.Count))
        {
          return (PayPlan)(Items[index]);
        }
        else
        {
          return null;
        }
      }
      set
      {
        if ((index > ITCConstants.InvalidNum) && (index < Items.Count))
        {
          Items[index] = value;
        }
        else
        {
          throw new InvalidOperationException("Pay Plan list out of bounds");
        }
      }
    }

    /// <summary>
    /// Returns an enumerator object to loop through the items in the list
    /// </summary>
    /// <returns>An enumerator object to loop through the items in the list</returns>
    public IEnumerator GetEnumerator()
    {
      return new PayPlanEnumerator(this.m_items);
    }

    private System.Collections.ArrayList m_items;


    /// <summary>
    /// This class implements the enumerator capabilities for the PayPlan class
    /// </summary>
    public class PayPlanEnumerator : ITCEnumerator
    {
      /// <summary>
      /// Constructor 
      /// </summary>
      /// <param name="items">An ArrayList of the items to enumerate</param>
      public PayPlanEnumerator(ArrayList items)
        : base(items)
      {
      }
    }//end class PayPlanEnumerator
  }

}
