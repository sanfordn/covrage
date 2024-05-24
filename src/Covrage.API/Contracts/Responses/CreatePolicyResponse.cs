

namespace Covrage.API.Contracts.Responses;


public class CreatePolicyResponse
{
    public string PolicyNumber { get; set; }
    public string PolicyHolder { get; set; }
    public string PolicyType { get; set; }
    public decimal Premium { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
