namespace Mp03.Models;

public class Sedan : Car
{
    public int DoorsCount { get; set; }
    public float TrunkCapacity { get; set; }
    
    public Sedan(string brand, string model, int yearOfProduction, int mileage, EngineType engineType, int doorsCount, float trunkCapacity) : base(brand, model, yearOfProduction, mileage, engineType)
    {
        DoorsCount = doorsCount;
        TrunkCapacity = trunkCapacity;
    }

    public float GetCapacity()
    {
        return DoorsCount * 50 + TrunkCapacity;
    }
    
}