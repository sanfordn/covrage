
namespace Example.API.Contracts.Requests;

public abstract class PolicyRequest
{
    public string PolicyNumber { get; internal set; }
    public string PolicyType { get; internal set; }
    public DateTime EffectiveDate { get; internal set; }
    public string PolicyStatus { get; internal set; }
}
