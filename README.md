# NewEraBankConsoleApp - Konsolowa Aplikacja Bankowa

Projekt to prosta aplikacja bankowa(konsolowa), napisana w języku C# przy pomocy programu JetBrains Rider. Aplikacja wykorzystuje kilka klas współpracujących ze sobą i wykorzystuje  podstawawowe elementy programowania obiektowego: klasy, obiekty, konstruktory, właściwości, metody, hermetyzację oraz relacje między klasami.

Aplikacja symuluje podstawowe operacje bankowe typu (obsługa wielu klientów, kont oraz kart płatniczych).

---

##  Wykorzystane elementy OOP :

1. **Hermetyzacja :** Wrażliwe dane systemowe, takie jak saldo konta (`Balance`) czy limity kart, są chronione przed bezpośrednią modyfikacją z zewnątrz za pomocą modyfikatorów dostępu (`private set`, `protected set`- może dziedziczyć). Zmiana stanu konta może odbywać się wyłącznie poprzez dedykowane metody walidujące (`Deposit`, `Withdraw`).

2. **Dziedziczenie :** - Klasa `SavingsAccount` dziedziczy po bazowej klasie `BankAccount`.
   - Klasy `DebitCard` oraz `CreditCard` dziedziczy po abstrakcyjnej klasie bazowej `Card`.

3. **Polimorfizm :** Wykorzystanie metod wirtualnych (`virtual`) oraz ich nadpisywania (`override`) m.in. w metodzie `ShowInfo()` oraz `Withdraw()`, co umożliwia różne zachowanie obiektów 

4. **Abstrakcja :** Klasa `Card` została zdefiniowana jako klasa abstrakcyjna (`public abstract class Card`), wymuszając na klasach pochodnych('DebitCard' i 'CreditCard') implementację kluczowych metod, takich jak `MakePayment()`.

---

## 📋 Główne Funkcjonalności

Program po uruchomieniu pokazuje menu konsolowe obsługujące następujące operacje:
1. **Dodawanie nowego klienta** do systemu (dodanie do istniejących klientów w `List<Client>`).

2. **Przeglądanie listy klientów** zarejestrowanych w systemie.

3. **Tworzenie kont bankowych** dla wybranych klientów (obsługa kont standardowych oraz oszczędnościowych z oprocentowaniem).

4. **Wydawanie kart płatniczych** przypisanych do konkretnego konta (debetowe korzystające ze środków konta oraz kredytowe z ustalonym limitem do wykorzystania ).

5. **Wpłata gotówki** na konto (nie można wpłacić kwot ujemych kwot ujemnych).

6. **Wypłata gotówki** z konta (weryfikacją czy jest wystarczająco środków na koncie).

7. **Przelew wychodzący i przychodzący** pomiędzy dwoma kontami w systemie.

8. **Płatność kartą** (debetową lub kredytową)** sprawdza czy limity lub saldo pozwala 

9. **Podgląd szczegółów profilu klienta** – zebrane informacje po podaniu ID klienta typu dane osobowe klienta, listę wszystkich jego kont oraz przypisanych do nich kart wraz z aktualnymi saldami.
10. **Kapitalizacja odsetek** – nalicza ile odsetek zostało naliczonych i jaki jest łączny stan konta

---

##  Struktura klas w projekcie wg zasady 1 klasa = 1 plik cs. :

- `Program.cs` - Główna klasa sterująca, zawierająca pętlę menu, kolekcje list obiektów oraz metody obsługi wejścia/wyjścia.
- `Client.cs` - dane klienta (ID, Imię, Nazwisko, Adres).
- `BankAccount.cs` - Klasa bazowa dla rachunków bankowych (obsługa wpłat, wypłat, przelewów).
- `SavingsAccount.cs` - Klasa konta oszczędnościowego rozszerzająca bazowe konto o stopę procentową i mechanizm dopisywania odsetek.
- `Card.cs` - Abstrakcyjna klasa bazowa dla reszty kart
- `DebitCard.cs` - klasa  karta debetowa(dziedzicząca z klasy bazowej "Card") autoryzująca transakcje na powiązanym koncie.
- `CreditCard.cs` -  klasa karta kredytowa(dziedzicząca z klasy bazowej "Card"), która ma  własny limit do wykorzystania 
---

## Jak uruchomić aplikację?

1. Otwórz program **JetBrains Rider** lub **Visual Studio** lub **Visual Studio Code**
2. Wybierz kolejno Open => Open Folder => znajdź na dysku folder z repozytorium "NewEraBankConsoleApp"
4. Uruchom aplikację(konsolę) za pomocą przycisku **Run** 

  Na starcie aplikacji na samym początku automatycznie uruchamiana jest metoda "SeedData()", która "ładuje" do system 10 przykładowych klientów(dane osobowe, rodzaj konta itd.) co pozwala od razu testować różne operacji bankowe bez konieczności ręcznego wprowadzania danych z klawiatury.


## Jan Piróg
Nr albumu 16565