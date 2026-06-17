using System;
namespace NewEraBankConsoleApp;

public class CreditCard : Card
{
    public decimal CreditLimit { get; private set; }
    public decimal UsedCredit { get; private set; }

    public CreditCard(string cardNumber, BankAccount associatedAccount, decimal creditLimit = 2000m)
        : base(cardNumber, associatedAccount)
    {
        CreditLimit = creditLimit;
        UsedCredit = 0m;
    }

    public override void MakePayment(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Kwota płatności musi być większa od zera.");
        }
        else if (UsedCredit + amount > CreditLimit)
        {
            decimal available = CreditLimit - UsedCredit;
            Console.WriteLine($"Transakcja odrzucona. Przekroczono limit. Dostępny limit: {available} PLN.");
        }
        else
        {
            UsedCredit += amount;
            Console.WriteLine($"Płatność udana. Wykorzystany limit: {UsedCredit} / {CreditLimit} PLN.");
        }
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Karta Kredytowa | Nr: {CardNumber} | Dostępny limit: {CreditLimit - UsedCredit} PLN | Zadłużenie: {UsedCredit} PLN/{CreditLimit} PLN");
    }
}