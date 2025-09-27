namespace LoanCalculator.WebApp.LoanCalculations;

public record LoanResults(
    double Amount,
    double Rate,
    int Terms,
    string TotalInterest,
    string MonthlyPayment,
    string YearlyPayment,
    List<AmortizationTable> AmortizationTable
);
