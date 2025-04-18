using System.Security.Cryptography;
using System.Text;

namespace Mp03.Models;

public interface IClient
{
    public string ClientNumber { get; }
    public DateTime RegistrationDate { get; }
    
    public Order PlaceOrder(Car car, float basePrice);
}

public class Client : Person, IClient
{
    public Client(int id, string name, string surname, string pesel, string email, string phone) : base(id, name, surname, pesel, email, phone)
    {
        RegistrationDate = DateTime.Now;
        ClientNumber = $"{Id}{Name![0]}{Surname![0]}{RandomNumberGenerator.GetHexString(5)}";
    }

    public string ClientNumber { get; init; }
    public DateTime RegistrationDate { get; init; }
    
    
    public Order PlaceOrder(Car car, float basePrice)
    {
        return new Order(Id, OrderStatus.InProgress, this,  car, basePrice);
    }


  
    
    public override string GetInfo()
    {
        StringBuilder sb = new StringBuilder();
        
        sb.AppendLine($"Client: {ClientNumber}");
        sb.AppendLine($"Registration Date: {RegistrationDate}");
        sb.AppendLine(base.ToString());
        
        return sb.ToString();
    }
}