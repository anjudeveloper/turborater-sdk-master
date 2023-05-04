using System;
using System.Collections;
using System.Text;

namespace TurboRater.Insurance.DataTransformation
{
  /// <summary>
  /// A list holder for TT2Tag items
  /// </summary>
  public class TT2TagList : IEnumerable
  {

    /// <summary>
    /// Default constructor
    /// </summary>
    public TT2TagList()
    {
      Items = new System.Collections.ArrayList();
    }

    /// <summary>
    /// Is the list sorted? Default is no. Note that to sort the list,
    /// you must call the sort method. Just setting this property to true
    /// will not do anything regarding sorting the list.
    /// Also, after sorting the list any subsequent addition of new tags 
    /// will make the list no longer sorted.
    /// </summary>
    public bool Sorted
    {
      get { return m_sorted; }
      set { m_sorted = value; }
    }

    /// <summary>
    /// Overrides the default ToString method to return the tags as a string
    /// </summary>
    /// <returns>String</returns>
    public override string ToString()
    {
      StringBuilder TT2Strings = new StringBuilder();

      try
      {
        //Build the TT2Response string
        foreach (TT2Tag tag in this.Items)
          TT2Strings.Append(tag.TagLine + "\r\n");
      }
      catch
      {
        throw;
      }

      //Return the result
      return TT2Strings.ToString();
    }

    /// <summary>
    /// Sorts the list of items using the IComparer object passed in
    /// </summary>
    /// <param name="comparer">The object used to compare any two
    /// items in the list</param>
    public virtual void Sort(System.Collections.IComparer comparer)
    {
      Items.Sort(comparer);
      m_sorted = true;
    }

    /// <summary>
    /// Adds an TT2Tag item to the list
    /// </summary>
    /// <param name="tagName">The name of the tag</param>
    /// <param name="tagScope">The scope type of the tag</param>
    /// <param name="scopeNum">The scope of the tag</param>
    /// <param name="values">The values contained in the tag item</param>
    /// <returns>Integer index of the new item in the list</returns>
    public virtual int Add(string tagName, ItemScope tagScope,
      int scopeNum, params object[] values)
    {
      TT2Tag tag = new TT2Tag();
      tag.TagName = tagName;
      tag.TagScope = tagScope;
      tag.ScopeNum = scopeNum;
      foreach (object value in values)
        tag.Values.Add(value);
      m_sorted = false;
      return Items.Add(tag);
    }

    /// <summary>
    /// Adds an TT2Tag item to the list
    /// </summary>
    /// <param name="tagName">The name of the tag</param>
    /// <param name="tagScope">The scope type of the tag</param>
    /// <param name="secondaryScope">The secondary scope type of the tag</param>
    /// <param name="scopeNum">The scope of the tag</param>
    /// <param name="secondaryScopeNum">The secondary scope of the tag</param>
    /// <param name="values">The values contained in the tag item</param>
    /// <returns>Integer index of the new item in the list</returns>
    public virtual int Add(string tagName, ItemScope tagScope, ItemScope secondaryScope,
      int scopeNum, int secondaryScopeNum, params object[] values)
    {
      TT2Tag tag = new TT2Tag();
      tag.TagName = tagName;
      tag.TagScope = tagScope;
      tag.ScopeNum = scopeNum;
      tag.SecondaryScope = secondaryScope;
      tag.SecondaryScopeNum = secondaryScopeNum;
      foreach (object value in values)
        tag.Values.Add(value);
      m_sorted = false;
      return Items.Add(tag);
    }

    /// <summary>
    /// Adds an TT2Tag item to the list
    /// </summary>
    /// <param name="value">The TT2Tag item to add</param>
    /// <returns>Integer index of the new item in the list</returns>
    public virtual int Add(TT2Tag value)
    {
      m_sorted = false;
      return Items.Add(value);
    }

    /// <summary>
    /// Inserts an TT2Tag item into the list
    /// </summary>
    /// <param name="index">Index in the list at which to insert the new TT2Tag 
    /// item</param>
    /// <param name="value">The TT2Tag item to insert</param>
    public virtual void Insert(int index, TT2Tag value)
    {
      m_sorted = false;
      Items.Insert(index, value);
    }

    /// <summary>
    /// Removes the specified TT2Tag item from the list
    /// </summary>
    /// <param name="value">The TT2Tag item to remove</param>
    public virtual void Remove(TT2Tag value)
    {
      m_sorted = false;
      Items.Remove(value);
    }

    /// <summary>
    /// Removes the TT2Tag item from the list at the specified
    /// index in the list.
    /// </summary>
    /// <param name="index">The index in the list of the TT2Tag
    /// item to remove</param>
    public virtual void RemoveAt(int index)
    {
      m_sorted = false;
      Items.RemoveAt(index);
    }

    /// <summary>
    /// Clears out the list of TT2Tag items
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
    /// The list of items in the TT2Tag list. This property is just an ArrayList,
    /// so its methods and properties are not type-specific to this class. Don't use this property
    /// directly unless no other method or property of this class will do what you need.
    /// </summary>
    public virtual System.Collections.ArrayList Items
    {
      get { return m_items; }
      set { m_items = value; }
    }

    /// <summary>
    /// Indexer for this class. Returns a TT2Tag object
    /// from the list of items.
    /// </summary>
    public virtual TT2Tag this[int index]
    {
      get
      {
        if ((index > ITCConstants.InvalidNum) && (index < Items.Count))
          return (TT2Tag)(Items[index]);
        else
          return null;
      }
      set
      {
        if ((index > ITCConstants.InvalidNum) && (index < Items.Count))
          Items[index] = value;
        else
          throw new InvalidOperationException("TT2 Tag list out of bounds");
      }
    }

    /// <summary>
    /// Indexer for this class. Returns an TT2Tag object
    /// from the list of items. Note that this will return the first tag
    /// that matches the name passed in, regardless of scope. If no tag 
    /// with that name exists, this will return null.
    /// Note that if the list is sorted, this will use a binary search algorithm
    /// to speed things up.
    /// Ex: Ex: ‘MyTT2List[“totalpolicypremium”]’
    /// </summary>
    public virtual TT2Tag this[string name]
    {
      get
      {
        string upperName = name.ToUpper();
        if ((this.m_sorted) && (Items.Count >= 10))
        {
          int low = 0;
          int high = Items.Count - 1;
          int currentIndex = low + (high - low) / 2;
          while (low <= high)
          {
            currentIndex = (low + high) / 2;
            TT2Tag currentTag = (TT2Tag)Items[currentIndex];
            string upperTag = currentTag.TagName.ToUpper();
            int compareVal = upperTag.CompareTo(upperName);
            if (compareVal > 0) high = currentIndex - 1;
            else if (compareVal < 0) low = currentIndex + 1;
            else return currentTag;
          }
          return null; //nothing matched so return null
        }
        else
        {
          foreach (TT2Tag tag in Items)
            if (tag.TagName.Trim().Equals(upperName, StringComparison.OrdinalIgnoreCase))
              return tag;
          return null;
        }
      }
    }

    /// <summary>
    /// Returns an enumerator object to loop through the items in the list
    /// </summary>
    /// <returns>An enumerator object to loop through the items in the list</returns>
    public IEnumerator GetEnumerator()
    {
      return new TT2TagEnumerator(this.m_items);
    }

    private System.Collections.ArrayList m_items;
    private bool m_sorted;


    /// <summary>
    /// This class implements the enumerator capabilities for the TT2Tag class
    /// </summary>
    public class TT2TagEnumerator : ITCEnumerator
    {
      /// <summary>
      /// Constructor
      /// </summary>
      /// <param name="items">An ArrayList of the items to enumerate</param>
      public TT2TagEnumerator(ArrayList items)
        : base(items)
      {
      }

    }//end class CompanyQuestionEnumerator

  }//end class CompanyQuestionList
}
