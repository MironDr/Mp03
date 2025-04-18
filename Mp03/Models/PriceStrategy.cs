namespace Mp03.Models;

public abstract class PriceStrategy
{
    public float Price { get; set; }

    public abstract float CalculatePrice();

}


public class BasePriceStrategy : PriceStrategy
{
    public BasePriceStrategy(float price)
    {
        Price = price;
    }
    
    public override float CalculatePrice()
    {
        return Price;
    }
}


public class WeekendPriceStrategy : PriceStrategy
{
    private float _discount;
    
    public WeekendPriceStrategy(PriceStrategy priceStrategy, float discount)
    {
        _discount = discount;
        Price = priceStrategy.Price;
    }

    public override float CalculatePrice()
    {
        return Price*(1-_discount);
    }
}

public class UrgentPriceStrategy : PriceStrategy
{
    private float _surcharge;

    public UrgentPriceStrategy(PriceStrategy priceStrategy, float surcharge)
    {
        _surcharge = surcharge;
        Price = priceStrategy.Price;
    }
    
    public override float CalculatePrice()
    {
        return Price+_surcharge;
    }
}