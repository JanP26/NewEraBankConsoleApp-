using System;
namespace NewEraBankConsoleApp;

public abstract class Card
{
    public string CardNumber { get; private set; }
    public BankAccount AssociatedAccount { get; private set; }

    public Card(string cardNumber, BankAccount associatedAccount)
    {
        CardNumber = cardNumber;
        AssociatedAccount = associatedAccount;
    }

    public abstract void MakePayment(decimal amount);
    public abstract void ShowInfo();
}