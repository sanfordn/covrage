
namespace Covrage.API.Contracts.Requests;

public class CreatePolicyRequest
{
    public string PolicyNumber { get; set; }
    public string PolicyHolder { get; set; }
    public string PolicyType { get; set; }
    public decimal Premium { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
