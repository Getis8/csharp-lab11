namespace Lab_11;

// Component
public interface ITrip
{
    int Minutes { get; }
    decimal PricePerMinute { get; }
    string Describe();
    decimal CalculateCost();
}

// Concrete Component
public class BasicTrip : ITrip
{
    public const decimal BasePricePerMinute = 3.00m;

    public int Minutes { get; }
    public decimal PricePerMinute => BasePricePerMinute;

    public BasicTrip(int minutes) => Minutes = minutes;

    public string Describe() => $"Поїздка {Minutes} хв";

    public decimal CalculateCost()
    {
        decimal cost = Minutes * PricePerMinute;
        Log.Write("Базова поїздка", $"{Minutes} хв × {PricePerMinute:F2} = {cost:F2} грн");
        return cost;
    }
}