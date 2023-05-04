using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboRater.Insurance;

namespace SdkRater.RateUtilityLib
{
  public class ClientsList
  {
    /// <summary>
    /// Individual policy's insured's first name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Individual policy's insured's last name
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Individual policy's email address
    /// </summary>
    public string EmailAddress { get; set; }

    /// <summary>
    /// Individual policy's phone number
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Individual policy's policy id associated with the policy
    /// </summary>
    public int PolicyId { get; set; }

    /// <summary>
    /// Individual policy's date quoted
    /// </summary>
    public DateTimeOffset DateQuoted { get; set; }

    /// <summary>
    /// Individual policy's effective date
    /// </summary>
    public DateTimeOffset EffectiveDate { get; set; }

    /// <summary>
    /// Individual policy's last quoted date
    /// </summary>
    public DateTimeOffset LastQuotedDate { get; set; }

    /// <summary>
    /// Individual policy's quote number
    /// </summary>
    public int QuoteNumber { get; set; }

    /// <summary>
    /// Individual policy's Line of Business
    /// </summary>
    public InsuranceLine Lob { get; set; }

    /// <summary>
    /// might need to be bounded for checkboxen to work
    /// </summary>
    public bool Selected { get; set; }
  }
}
