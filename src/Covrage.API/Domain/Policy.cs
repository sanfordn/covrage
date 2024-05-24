

namespace Covrage.API.Domain;

public class Policy
{
    public string PolicyNumber { get; set; }
    public string PolicyHolder { get; set; }
    public string PolicyType { get; set; }
    public decimal Premium { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid Id { get; internal set; }
}
