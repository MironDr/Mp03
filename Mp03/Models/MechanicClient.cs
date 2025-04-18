using System.Text;

namespace Mp03.Models;

public class MechanicClient : Mechanic, IClient
{
    public MechanicClient(int id, string name, string surname, string pesel, string email, string phone, DateTime dateOfBirth, ExpLevel experienceLevel, string clientNumber, DateTime registrationDate) : base(id, name, surname, pesel, email, phone, dateOfBirth, experienceLevel)
    {
        ClientNumber = EmployeeNumber + "MechanicClient";
        RegistrationDate = DateTime.Now;
    }

    public string ClientNumber { get; }
    public DateTime RegistrationDate { get; }
    
   
    
    public Order PlaceOrder(Car car, float basePrice)
    {
        Order order =  new Order(Id, OrderStatus.InProgress, this,  car, basePrice);
        order.ChangeMechanic(this);
        return order;
    }
    
    public override string GetInfo()
    {
        
        StringBuilder sb = new StringBuilder();
        
        sb.AppendLine($"Mechanic: {EmployeeNumber}, Client: {ClientNumber} Experience Level: {ExperienceLevel}");
        sb.AppendLine($"Employment Date: {EmploymentDate}");
        sb.AppendLine($"Date of birth: {DateOfBirth}");
        
        if(MechanicTypes.Contains(MechanicType.EngineSpecialist))
            sb.AppendLine($"Engines Support: {_engines.ToArray()}");
        
        if(MechanicTypes.Contains(MechanicType.Diagnostician))
            sb.AppendLine($"Diagnosis Support: {_diagnosis.ToArray()}");
        
        sb.AppendLine(base.ToString());
        
        return sb.ToString();
    }
}