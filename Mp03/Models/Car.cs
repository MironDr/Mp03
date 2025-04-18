using System.Security.Cryptography;

namespace Mp03.Models;

public enum EngineType
{
    Diesel,
    Electric,
}

public abstract class Car
{
    public string VinNumber { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int YearOfProduction { get; set; }
    public int Mileage { get; set; }

    public EngineType EngineType { get; set; }
    
    //
    public float? EngineCapacity { get; set; }
    public float? Co2Emission { get; set; }

    public bool? IsEmissionNormal()
    {
        return Co2Emission < 35.5f;
    }
    //
    
    //
    public float? BatteryCapacity { get; set; }
    public float? ChargingSpeed { get; set; }

    public float? CalculateChargeTime()
    {
        return BatteryCapacity / ChargingSpeed;
    }
    //
    
    public Car(string brand, string model, int yearOfProduction, int mileage, EngineType engineType)
    {
        VinNumber = RandomNumberGenerator.GetHexString(15);
        Brand = brand;
        Model = model;
        YearOfProduction = yearOfProduction;
        Mileage = mileage;
        EngineType = engineType;
    }
    
    public int CalculateAge()
    {
        return DateTime.Now.Year - YearOfProduction;
    }
    
    
    
}