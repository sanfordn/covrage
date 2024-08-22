/* This class is a generic representation of an insurance policy. 
 * It will support many types of insurance policies, such as auto, home, and life insurance.
 * It will also support many types of investment policies, such as annuities and retirement accounts.
 * This class will be the base class for many different types of policies consumers will create. 
 */
namespace Covrage;
// This abstract class represents a generic insurance policy.
public abstract class Policy
{
    // The unique identifier for the policy.
    protected string PolicyNumber { get; set; }
    // The type of policy.
    protected string PolicyType { get; set; }
    // The policy effective date.
    protected DateTime EffectiveDate { get; set; }
    // The policy status.
    protected string PolicyStatus { get; set; }
}
