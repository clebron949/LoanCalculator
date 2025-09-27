namespace LoanCalculator.WebApp.LoanCalculations;

public class LoanParameters(decimal amount, decimal rate, int terms)
{
    public decimal Amount { get; set; } = amount;
    public decimal Rate { get; set; } = rate;
    public int Terms { get; set; } = terms;
    public bool IsFullLoanAmount { get; set; } = true;
        
    public Dictionary<string, object?> ToDictionary()
    {
        if (Rate > 1)
        {
            Rate /= 100; // Convert percentage to decimal if necessary
        }
            
        return new Dictionary<string, object?>
        {
            { "Amount", Amount },
            { "Rate", Rate },
            { "Terms", Terms },
            { "IsFullLoanAmount", IsFullLoanAmount }
        };
    }
}