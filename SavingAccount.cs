using System;
namespace NewEraBankConsoleApp;

public class SavingsAccount : BankAccount
{
    public decimal InterestRate { get; private set; } 

    public SavingsAccount(string accountNumber, Client owner, decimal initialBalance = 0m, decimal interestRate = 0.04m)
        : base(accountNumber, owner, initialBalance)
    {
        InterestRate = interestRate;
    }

    public void ApplyInterest()
    {
        decimal interest = Balance * InterestRate;
        Balance += interest;
        Console.WriteLine($" Naliczono odsetki roczne ({InterestRate}) w kwocie {interest} dla konta {AccountNumber}. Nowe saldo: {Balance}");
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Konto Oszczędnościowe | Nr: {AccountNumber} | Saldo: {Balance} PLN | Oprocentowanie: {InterestRate * 100}%");
    }
}
