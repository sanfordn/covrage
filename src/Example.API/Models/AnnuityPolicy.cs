using Covrage;

namespace Example.API.Models
{
    public class AnnuityPolicy : Policy
    {
        public override string? PolicyType { get; set; } = "Annuity";
        public decimal CashValue { get; set; }
    }
}
