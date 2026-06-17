namespace NewEraBankConsoleApp;

internal class Program
    {
        private static List<Client> clients = new List<Client>();
        private static List<BankAccount> accounts = new List<BankAccount>();
        private static List<Card> cards = new List<Card>();

        
        private static int nextClientId = 1;
        private static int nextAccountNum = 1001;
        private static int nextCardNum = 2001;

        static void Main(string[] args)
        {
            
            SeedData();       

            bool running = true;
            while (running)
            {
                
                Console.WriteLine("\n=====================================");
                Console.WriteLine("    WITAMY W NEW ERA BANK");
                
                Console.WriteLine("=====================================");
                Console.WriteLine("1. Dodaj klienta");
                Console.WriteLine("2. Pokaż listę klientów");
                Console.WriteLine("3. Dodaj konto bankowe klientowi");
                Console.WriteLine("4. Dodaj kartę płatniczą do konta");
                Console.WriteLine("5. Wpłać pieniądze na konto");
                Console.WriteLine("6. Wypłać pieniądze z konta");
                Console.WriteLine("7. Wyślij przelew bankowy");
                Console.WriteLine("8. Zapłać / Wypłać kartą");
                Console.WriteLine("9. Pokaż pełne szczegóły profilu klienta");
                Console.WriteLine("k. Kapitalizacja odsetek (Konta oszczędnościowe)");
                Console.WriteLine("0. Zakończ program");
                Console.Write("\nWybierz opcję: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": AddClient(); break;
                    case "2": ShowAllClients(); break;
                    case "3": AddAccount(); break;
                    case "4": AddCard(); break;
                    case "5": DepositMoney(); break;
                    case "6": WithdrawMoney(); break;
                    case "7": SendTransfer(); break;
                    case "8": PayWithCard(); break;
                    case "9": ShowClientDetails(); break;
                    case "k": case "K": RunInterestCapitalization(); break;
                    case "0": running = false; Console.WriteLine("Dziękujemy za skorzystanie z New Era Bank!"); break;
                    default: Console.WriteLine("Niepoprawna opcja menu. Spróbuj ponownie."); break;
                }
            }
        }

        private static void SeedData()
        {
            Client client1 = new Client(nextClientId++, "Jan", "Kowalski", "Warszawa 01-100");
            Client client2 = new Client(nextClientId++, "Anna", "Nowak", "Kraków 31-334");
            Client client3 = new Client(nextClientId++, "Piotr", "Wiśniewski", "Łódź 90-001");
            Client client4 = new Client(nextClientId++, "Maria", "Wójcik", "Wrocław 50-001");
            Client client5 = new Client(nextClientId++, "Tomasz", "Kowalczyk", "Poznań 60-001");
            Client client6 = new Client(nextClientId++, "Agnieszka", "Kamińska", "Gdańsk 80-001");
            Client client7 = new Client(nextClientId++, "Michał", "Lewandowski", "Katowice 40-001");
            Client client8 = new Client(nextClientId++, "Magdalena", "Zielińska", "Białystok 15-001");
            Client client9 = new Client(nextClientId++, "Krzysztof", "Szymański", "Lublin 20-001");
            Client client10 = new Client(nextClientId++, "Katarzyna", "Dąbrowska", "Bydgoszcz 85-001");

            clients.Add(client1);
            clients.Add(client2);
            clients.Add(client3);
            clients.Add(client4);
            clients.Add(client5);
            clients.Add(client6);
            clients.Add(client7);
            clients.Add(client8);
            clients.Add(client9);
            clients.Add(client10);

            BankAccount acc1 = new BankAccount($"PL{nextAccountNum++}", client1, 1500m);
            SavingsAccount acc2 = new SavingsAccount($"PL{nextAccountNum++}", client2, 5000m, 0.05m);
            BankAccount acc3 = new BankAccount($"PL{nextAccountNum++}", client3, 300m);
            SavingsAccount acc4 = new SavingsAccount($"PL{nextAccountNum++}", client4, 12000m, 0.04m);
            BankAccount acc5 = new BankAccount($"PL{nextAccountNum++}", client5, 2750m);
            SavingsAccount acc6 = new SavingsAccount($"PL{nextAccountNum++}", client6, 8400m, 0.06m);
            BankAccount acc7 = new BankAccount($"PL{nextAccountNum++}", client7, 150m);
            SavingsAccount acc8 = new SavingsAccount($"PL{nextAccountNum++}", client8, 18000m, 0.05m);
            BankAccount acc9 = new BankAccount($"PL{nextAccountNum++}", client9, 4200m);
            SavingsAccount acc10 = new SavingsAccount($"PL{nextAccountNum++}", client10, 900m, 0.03m);

            accounts.Add(acc1);
            accounts.Add(acc2);
            accounts.Add(acc3);
            accounts.Add(acc4);
            accounts.Add(acc5);
            accounts.Add(acc6);
            accounts.Add(acc7);
            accounts.Add(acc8);
            accounts.Add(acc9);
            accounts.Add(acc10);

            cards.Add(new DebitCard($"{nextCardNum++}", acc1));
            cards.Add(new CreditCard($"{nextCardNum++}", acc1, 2000m));
            cards.Add(new DebitCard($"{nextCardNum++}", acc2));
            cards.Add(new DebitCard($"{nextCardNum++}", acc3));
            cards.Add(new DebitCard($"{nextCardNum++}", acc4));
            cards.Add(new CreditCard($"{nextCardNum++}", acc4, 5000m));
            cards.Add(new DebitCard($"{nextCardNum++}", acc5));
            cards.Add(new CreditCard($"{nextCardNum++}", acc6, 3000m));
            cards.Add(new DebitCard($"{nextCardNum++}", acc7));
            cards.Add(new DebitCard($"{nextCardNum++}", acc8));
            cards.Add(new CreditCard($"{nextCardNum++}", acc8, 10000m));
            cards.Add(new DebitCard($"{nextCardNum++}", acc9));
            cards.Add(new DebitCard($"{nextCardNum++}", acc10));
        }

        private static void AddClient()
        {
            Console.Write("Podaj imię klienta: ");
            string firstName = Console.ReadLine();
            Console.Write("Podaj nazwisko klienta: ");
            string lastName = Console.ReadLine();
            Console.Write("Podaj adres zamieszkania: ");
            string address = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("Imię i nazwisko nie mogą być puste.");
                return;
            }

            Client newClient = new Client(nextClientId++, firstName, lastName, address);
            clients.Add(newClient);
            Console.WriteLine($"Prawidłowo dodano klienta {firstName} {lastName} o ID: {newClient.Id}");
        }

        private static void ShowAllClients()
        {
            Console.WriteLine("--- LISTA KLIENTÓW BANKU ---");
            if (clients.Count == 0)
            {
                Console.WriteLine("Brak zarejestrowanych klientów w systemie.");
                return;
            }
            foreach (var client in clients)
            {
                client.ShowInfo();
            }
        }

        private static void AddAccount()
        {
            ShowAllClients();
            Console.Write(" Podaj ID klienta, dla którego chcesz utworzyć konto: ");
            if (!int.TryParse(Console.ReadLine(), out int clientId)) return;

            Client client = clients.Find(c => c.Id == clientId);
            if (client == null)
            {
                Console.WriteLine("Nie znaleziono klienta o podanym ID.");
                return;
            }

            Console.WriteLine("Wybierz typ konta:\n1. Konto Standardowe\n2. Konto Oszczędnościowe");
            Console.Write("Wybór: ");
            string type = Console.ReadLine();

            Console.Write("Podaj kwotę pierwszej wpłaty (początkowej): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal initialDeposit)) return;

            string generatedNumber = $"PL{nextAccountNum++}";
            BankAccount newAccount;

            if (type == "2")
            {
                newAccount = new SavingsAccount(generatedNumber, client, initialDeposit, 0.04m);
            }
            else
            {
                newAccount = new BankAccount(generatedNumber, client, initialDeposit);
            }

            accounts.Add(newAccount);
            Console.WriteLine($" Poprawnie Utworzono konto {generatedNumber} dla klienta {client.FirstName} {client.LastName}.");
        }

        private static void AddCard()
        {
            Console.Write("Podaj numer konta (początek PL + cztery cyfry), do którego przypisać kartę: ");
            string accNum = Console.ReadLine().ToUpper();

            BankAccount account = accounts.Find(a => a.AccountNumber == accNum);
            if (account == null)
            {
                Console.WriteLine("Nie odnaleziono konta o tym numerze.");
                return;
            }

            Console.WriteLine("Wybierz typ karty:\n1. Karta Debetowa\n2. Karta Kredytowa");
            Console.Write("Wybór: ");
            string type = Console.ReadLine();

            string cardNum = $"{nextCardNum++}";
            Card newCard;

            if (type == "2")
            {
                Console.Write("Podaj limit dla karty kredytowej: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal limit)) return;
                newCard = new CreditCard(cardNum, account, limit);
            }
            else
            {
                newCard = new DebitCard(cardNum, account);
            }

            cards.Add(newCard);
            Console.WriteLine($" Poprawnie wygenerowano kartę nr {cardNum} powiązaną z kontem {account.AccountNumber}.");
        }

        private static void DepositMoney()
        {
            Console.Write("Podaj numer konta docelowego: ");
            string accNum = Console.ReadLine().ToUpper();
            BankAccount account = accounts.Find(a => a.AccountNumber == accNum);

            if (account == null)
            {
                Console.WriteLine("Konto nie istnieje.");
                return;
            }

            Console.Write("Podaj kwotę do wpłaty: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                account.Deposit(amount);
            }
        }

        private static void WithdrawMoney()
        {
            Console.Write("Podaj numer konta, z którego chcesz wypłacić: ");
            string accNum = Console.ReadLine().ToUpper();
            BankAccount account = accounts.Find(a => a.AccountNumber == accNum);

            if (account == null)
            {
                Console.WriteLine("Konto nie istnieje.");
                return;
            }

            Console.Write("Podaj kwotę do wypłaty: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                account.Withdraw(amount);
            }
        }

        private static void SendTransfer()
        {
            Console.Write("Podaj numer konta ŹRÓDŁOWEGO (z którego wysłać): ");
            string sourceNum = Console.ReadLine().ToUpper();
            BankAccount sourceAcc = accounts.Find(a => a.AccountNumber == sourceNum);

            if (sourceAcc == null)
            {
                Console.WriteLine("Konto źródłowe nie istnieje.");
                return;
            }

            Console.Write("Podaj numer konta DOCELOWEGO (odbiorcy): ");
            string targetNum = Console.ReadLine().ToUpper();
            BankAccount targetAcc = accounts.Find(a => a.AccountNumber == targetNum);

            if (targetAcc == null)
            {
                Console.WriteLine("Błąd: Konto docelowe nie istnieje.");
                return;
            }

            Console.Write("Podaj kwotę przelewu: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                sourceAcc.TransferTo(targetAcc, amount);
            }
        }

        private static void PayWithCard()
        {
            Console.Write("Podaj numer karty ");
            string cardNum = Console.ReadLine();
            Card card = cards.Find(c => c.CardNumber == cardNum);

            if (card == null)
            {
                Console.WriteLine("Karta nie została znaleziona.");
                return;
            }

            Console.Write("Podaj kwotę transakcji kartą: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                card.MakePayment(amount);
            }
        }

        private static void ShowClientDetails()
        {
            ShowAllClients();
            Console.Write("\nPodaj ID klienta, którego profil chcesz przejrzeć: ");
            if (!int.TryParse(Console.ReadLine(), out int clientId)) return;

            Client client = clients.Find(c => c.Id == clientId);
            if (client == null)
            {
                Console.WriteLine("Nie znaleziono takiego klienta.");
                return;
            }

            
            Console.WriteLine($"\n--- PROFIL KLIENTA: {client.FirstName.ToUpper()} {client.LastName.ToUpper()} ---");
            client.ShowInfo();

            Console.WriteLine("\nPOSIADANE KONTA:");
            List<BankAccount> clientAccounts = accounts.FindAll(a => a.Owner.Id == clientId);
            if (clientAccounts.Count == 0) Console.WriteLine(" -> Brak otwartych kont.");
            
            foreach (var acc in clientAccounts)
            {
                Console.Write(" -> ");
                acc.ShowInfo();

               
                List<Card> accountCards = cards.FindAll(c => c.AssociatedAccount.AccountNumber == acc.AccountNumber);
                if (accountCards.Count > 0)
                {
                    Console.WriteLine("   Przypisane karty płatnicze:");
                    foreach (var card in accountCards)
                    {
                        Console.Write("     * ");
                        card.ShowInfo();
                    }
                }
            }
            Console.WriteLine("--------------------------------------------");
        }

        private static void RunInterestCapitalization()
        {
            Console.WriteLine("Kapitalizacja odsetek dla kont oszczędnościowych:");
            foreach (var acc in accounts)
            {
                if (acc is SavingsAccount savings)
                {
                    savings.ApplyInterest();
                }
            }
        }
    }