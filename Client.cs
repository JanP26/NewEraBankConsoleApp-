using System;   
namespace NewEraBankConsoleApp;

public class Client
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Address { get; private set; }

    public Client(int id, string firstName, string lastName, string address)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"[ID: {Id}] {FirstName} {LastName}, Adres: {Address}");
    }
}