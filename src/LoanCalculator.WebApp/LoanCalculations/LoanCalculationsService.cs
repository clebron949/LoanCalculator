using System;

namespace LoanCalculator.WebApp.LoanCalculations;

public enum LoanTerm
{
    Monthly,
    Yearly,
}

public class LoanCalculationsService
{
    public LoanResults CalculateLoan(
        double amount,
        double rate,
        int terms,
        LoanTerm term = LoanTerm.Monthly
    )
    {
        var amortizationTable = new List<AmortizationTable>();
        var beginningBalance = amount;
        var totalInterestPaid = 0.00;
        var monthlyPayment = CalculateMonthlyPayment(amount, rate, terms);
        var yearlyPayment = CalculateYearlyPayment(amount, rate, terms);
        
        for (var i = 0; i < terms; i++)
        {
            var interestPaid = beginningBalance * rate;
            totalInterestPaid += interestPaid;
            
            var principalPaid = yearlyPayment - interestPaid;
            var remainingPrincipal = beginningBalance - principalPaid;
            remainingPrincipal = (remainingPrincipal < 1) ? 0 : remainingPrincipal;
            
            var item = new AmortizationTable(
                Years: $"{i+1}",
                BeginningBalance: "$" + beginningBalance.ToString("N"),
                YearlyPayment: "$" + yearlyPayment.ToString("N"),
                InterestPaid: "$" + interestPaid.ToString("N"),
                PrincipalPaid: "$" + principalPaid.ToString("N"),
                RemainingPrincipal: "$" + remainingPrincipal.ToString("N"),
                MonthlyPayment: "$" + monthlyPayment.ToString("N"),
                TotalInterestPaid: "$" + totalInterestPaid.ToString("N")
            );
            amortizationTable.Add(item);
            beginningBalance = remainingPrincipal;
        }
        
        return new LoanResults(
            Amount: amount,
            Rate: rate,
            Terms: terms,
            MonthlyPayment: monthlyPayment.ToString("C2"),
            YearlyPayment: yearlyPayment.ToString("C2"),
            TotalInterest: totalInterestPaid.ToString("C2"),
            AmortizationTable: amortizationTable
        );
    }
    
    private static double CalculateMonthlyPayment(double amount, double rate, int terms) =>
        amount / 12 * ((rate * Math.Pow(1 + rate, terms)) / (Math.Pow(1 + rate, terms) - 1));

    private static double CalculateYearlyPayment(double amount, double rate, int terms) =>
        amount * ((rate * Math.Pow(1 + rate, terms)) / (Math.Pow(1 + rate, terms) - 1));
}
