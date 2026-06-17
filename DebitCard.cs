using System;
namespace NewEraBankConsoleApp;

public class DebitCard : Card
{
    public DebitCard(string cardNumber, BankAccount associatedAccount)
        : base(cardNumber, associatedAccount)
    {
    }

    public override void MakePayment(decimal amount)
    {
        Console.WriteLine($"[KARTA DEBETOWA] Autoryzacja karty {CardNumber} na kwotę {amount} PLN...");
        AssociatedAccount.Withdraw(amount);
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Karta Debetowa | Nr: {CardNumber} | Podpięta pod konto: {AssociatedAccount.AccountNumber}");
    }
}