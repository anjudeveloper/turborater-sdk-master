using System;
using System.Runtime.Serialization;

namespace TurboRater
{
  /// <summary>
  /// A language translation related exception.
  /// </summary>
  [Serializable]
  public class GlobalizationException : Exception
  {
    /// <summary>
    /// base constructor.
    /// </summary>
    public GlobalizationException()
      : base()
    {
    }

    /// <summary>
    /// constructor.
    /// </summary>
    public GlobalizationException(string message)
      : base(message)
    {
    }

    /// <summary>
    /// constructor.
    /// </summary>
    protected GlobalizationException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    /// <summary>
    /// constructor.
    /// </summary>
    public GlobalizationException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}
