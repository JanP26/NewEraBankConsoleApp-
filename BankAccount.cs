using System;
namespace NewEraBankConsoleApp;

public class BankAccount
{
    public string AccountNumber { get; private set; }
    public Client Owner { get; private set; }
    public decimal Balance { get; protected set; }

    public BankAccount(string accountNumber, Client owner, decimal initialBalance = 0m)
    {
        AccountNumber = accountNumber;
        Owner = owner;
        if (initialBalance >= 0)
        {
            Balance = initialBalance;
        }
        else
        {
            Balance = 0m;
        }

    }

    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Kwota wpłaty musi być większa od zera.");
        }
        else
        {
            Balance += amount;
            Console.WriteLine(
                $"[WPŁATA] Pomyślnie wpłacono {amount} PLN na konto {AccountNumber}. Aktualne saldo: {Balance} PLN");
        }
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Kwota wypłaty musi być większa od zera.");
        }
        else if (Balance < amount)
        {
            Console.WriteLine($"Błąd: Brak wystarczających środków na koncie {AccountNumber}. Dostępne: {Balance}PLN.");
        }
        else
        {
            Balance -= amount;
            Console.WriteLine(
                $"[WYPŁATA] Pomyślnie wypłacono {amount} PLN z konta {AccountNumber}. Pozostałe saldo: {Balance} PLN");
        }
    }

    public void TransferTo(BankAccount targetAccount, decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Kwota przelewu musi być większa od zera.");
            
        }
        else if (Balance < amount)
        {
            Console.WriteLine($"Błąd: Przelew odrzucony. Brak środków na koncie {AccountNumber} (Dostępne: {Balance} PLN).");
            
        }
        else
        { 
            Balance -= amount;
            targetAccount.Balance += amount;
            Console.WriteLine(
                $"[PRZELEW] Przelano {amount} PLN z konta {AccountNumber} na konto {targetAccount.AccountNumber}.");
        }
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Konto standardowe | Nr: {AccountNumber} | Saldo: {Balance} PLN");
    }
}


