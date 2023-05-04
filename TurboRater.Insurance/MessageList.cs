using System;
using System.Collections.Generic;

namespace TurboRater.Insurance
{
  /// <summary>
  /// A list holder for Message items
  /// </summary>
  [Serializable]
  public class MessageList : List<Message>
  {

    /// <summary>
    /// Constructor. Allows you to associate a policy with the message list.
    /// </summary>
    /// <param name="forPolicy">The policy that owns this list of messages</param>
    public MessageList(InsPolicy forPolicy)
    {
      this.Policy = forPolicy;
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public MessageList()
    {
    }


    /// <summary>
    /// Adds an Message item to the list
    /// </summary>
    /// <param name="value">The Message item to add</param>
    /// <returns>Integer index of the new item in the list</returns>
    public new int Add(Message value)
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
    public new void Insert(int index, Message value)
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
    /// The policy that owns this message list
    /// </summary>
    public virtual InsPolicy Policy
    {
      get { return m_policy; }
      set { m_policy = value; }
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
    private InsPolicy m_policy;

  }//end class MessageList

}
