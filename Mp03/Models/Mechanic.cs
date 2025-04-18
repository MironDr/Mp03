using System.Text;

namespace Mp03.Models;

public enum ExpLevel
{
  Junior,
  Middle,
  Senior
}

public enum MechanicType
{
    Diagnostician,
    EngineSpecialist
}


public class Mechanic : Employee
{
    public Mechanic(int id, string name, string surname, string pesel, string email, string phone, DateTime dateOfBirth, ExpLevel experienceLevel) : base(id, name, surname, pesel, email, phone, dateOfBirth)
    {
        ExperienceLevel = experienceLevel;
    }

    public ExpLevel ExperienceLevel { get; set; }

    public HashSet<MechanicType> MechanicTypes { get; private set; } = new();


    protected List<string> _diagnosis = new();
    
    protected List<string> _engines = new();

    

    public void AddMechanicType(MechanicType type)
    {
        MechanicTypes.Add(type);
    }

    public void AddEngine(string engine)
    {
        if(MechanicTypes.Contains(MechanicType.EngineSpecialist))
            _engines.Add(engine);
    }
    
    public void AddDiagnosis(string diagnosis)
    {
        if(MechanicTypes.Contains(MechanicType.Diagnostician))
            _diagnosis.Add(diagnosis);
    }

    public List<string> GetEngines()
    {
        if(MechanicTypes.Contains(MechanicType.EngineSpecialist))
            return _engines.ToList(); 
        
        _engines.Clear();
        throw new ArgumentException("This mechanic is not engines specialist.");
    }
    
    public List<string> GetDiagnosis()
    {
        if(MechanicTypes.Contains(MechanicType.Diagnostician))
            return _diagnosis.ToList(); 
        
        _diagnosis.Clear();
        throw new ArgumentException("This mechanic is not diagnostician.");
    }

    public void FixCar(Order order)
    {
        Console.WriteLine($"Car {order.Car.Brand} Fixed!");
        order.ChangeStatus(OrderStatus.Completed);
    }
    
    
    public override string GetInfo()
    {
        
        StringBuilder sb = new StringBuilder();
        
        sb.AppendLine($"Mechanic: {EmployeeNumber}, Experience Level: {ExperienceLevel}");
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