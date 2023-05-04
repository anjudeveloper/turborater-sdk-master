using System;

namespace TurboRater.Insurance.HO
{
  /// <summary>
  /// a homeowners quote
  /// </summary>
  [Serializable]
  public class HOQuote : InsQuote
  {
    /// <summary>
    /// The notes on the quote. 
    /// </summary>
    public override InsNoteList Notes
    {
      get { return base.Notes; }
      set { base.Notes = value; }
    }

  }
}
