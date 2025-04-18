// See https://aka.ms/new-console-template for more information

using Mp03.Models;

Console.WriteLine("---- Klasa  abstrakcyjna i  polimorficzne  wołanie metod ----");

Person person = new Mechanic(1, "John", "Smith", "12345678901", "john@example.com", "123-456-789", new DateTime(1990, 1, 1), ExpLevel.Senior);
Console.WriteLine(person.GetInfo()); 

Console.WriteLine("\n---- Overlapping ----");

Mechanic mechanic = new Mechanic(2, "Anna", "Brown", "98765432109", "anna@example.com", "987-654-321",
    new DateTime(1985, 5, 10), ExpLevel.Middle);
mechanic.AddMechanicType(MechanicType.EngineSpecialist);
mechanic.AddMechanicType(MechanicType.Diagnostician);
mechanic.AddEngine("V8 Engine");
mechanic.AddDiagnosis("ECU Fault");
Console.WriteLine("Engines: " + string.Join(", ", mechanic.GetEngines()));
Console.WriteLine("Diagnoses: " + string.Join(", ", mechanic.GetDiagnosis()));

Console.WriteLine("\n---- Wielodziedziczenie ----");

MechanicClient mechanicClient = new MechanicClient(3, "Bob", "Taylor", "56473829100", "bob@example.com", "555-555-555",
    new DateTime(1992, 3, 5), ExpLevel.Junior, "CL12345", DateTime.Now);
Console.WriteLine(mechanicClient.GetInfo());

Console.WriteLine("\n---- Wieloaspektowe ----");

Sedan sedan = new Sedan("Toyota", "Camry", 2020, 40000, EngineType.Diesel, 4, 450);
sedan.EngineCapacity = 2.5f;
sedan.Co2Emission = 34f;
Console.WriteLine($"Sedan {sedan.Brand} is emission normal: {sedan.IsEmissionNormal()}");

Suv suv = new Suv("Jeep", "Cherokee", 2019, 60000, EngineType.Diesel, true, 14.5f);
Console.WriteLine($"SUV {suv.Brand} is road legal: {suv.IsRoadLegal()}");

Console.WriteLine("\n---- Dynamiczne ----");

Order order = mechanicClient.PlaceOrder(sedan, 1000);
Console.WriteLine($"Base Price: {order.PriceStrategy.CalculatePrice()}");

order.PriceStrategy = new UrgentPriceStrategy(order.PriceStrategy, 250);
Console.WriteLine($"Urgent Price: {order.PriceStrategy.CalculatePrice()}");

order.PriceStrategy = new WeekendPriceStrategy(order.PriceStrategy, 0.1f);
Console.WriteLine($"Weekend Discounted Price: {order.PriceStrategy.CalculatePrice()}");

Console.WriteLine("\n---- Naprawa samochodu ----");
order.StartWork();

Console.WriteLine($"Order status: {order.Status}");