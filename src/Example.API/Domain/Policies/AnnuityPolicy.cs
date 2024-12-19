using Covrage;

namespace Example.API.Domain.Policies;

public class AnnuityPolicy : Policy
{
    // Parameterless constructor for deserialization
    public AnnuityPolicy() { }

    public string PolicyOwner { get; set; }
}
