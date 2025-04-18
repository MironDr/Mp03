namespace Mp03.Models;

public enum OrderStatus
{
    Completed,
    Canceled,
    InProgress
}

public class Order
{
    public int Id { get; set; }
    public DateTime DateOrder { get; set; }
    public OrderStatus Status { get; set; }
    public IClient Client { get; set; }
    public Car Car { get; set; }
    public Mechanic? Mechanic { get; set; }
    
    public PriceStrategy PriceStrategy { get; set; }

    public Order(int id, OrderStatus status, IClient client, Car car, float basePrice)
    {
        Id = id;
        DateOrder = DateTime.Now;
        Status = status;
        Client = client;
        Car = car;
        PriceStrategy = new BasePriceStrategy(basePrice);
    }

    public void StartWork()
    {
        if (Mechanic == null)
        {
            Console.WriteLine("Mechanic is missing");
            return;
        }
            
        Mechanic.FixCar(this);
            
    }
    
    public void ChangeMechanic(Mechanic mechanic)
    {
        Mechanic = mechanic;
    }

    public void ChangeStatus(OrderStatus status)
    {
        Status = status;
    }
    
}