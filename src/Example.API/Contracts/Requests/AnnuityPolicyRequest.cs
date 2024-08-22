namespace Example.API.Contracts.Requests;

public class AnnuityPolicyRequest : PolicyRequest
{
    public decimal AnnuityAmount { get; set; }
}
