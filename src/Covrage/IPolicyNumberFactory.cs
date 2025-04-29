namespace Covrage;

public interface IPolicyNumberFactory
{
    string? GeneratePolicyNumber(Policy policy);
}
