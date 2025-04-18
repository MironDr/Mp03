namespace Mp03.Models;

public class Suv : Car
{
    public bool IsAllWheelDrive { get; set; }
    public float Mass { get; set; }
    
    private static readonly float MaxMass = 15;
    
    public Suv(string brand, string model, int yearOfProduction, int mileage, EngineType engineType, bool isAllWheelDrive, float mass) : base(brand, model, yearOfProduction, mileage, engineType)
    {
        Mass = mass;
        IsAllWheelDrive = isAllWheelDrive;
    }

    public bool IsRoadLegal()
    {
        return Mass <= MaxMass;
    }
    
}