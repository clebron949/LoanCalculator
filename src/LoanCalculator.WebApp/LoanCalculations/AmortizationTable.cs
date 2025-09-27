namespace LoanCalculator.WebApp.LoanCalculations;

public record AmortizationTable(
    string Years,
    string BeginningBalance,
    string YearlyPayment,
    string InterestPaid,
    string PrincipalPaid,
    string RemainingPrincipal,
    string MonthlyPayment,
    string TotalInterestPaid
);
