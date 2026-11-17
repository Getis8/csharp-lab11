namespace Lab_11;

// Decorator: той самий інтерфейс + посилання на обгорнутий об'єкт
public abstract class TripOptionDecorator : ITrip
{
    protected readonly ITrip Inner;

    protected TripOptionDecorator(ITrip inner) =>
        Inner = inner ?? throw new ArgumentNullException(nameof(inner));

    protected abstract string OptionName { get; }
    protected abstract decimal Surcharge { get; }   // надбавка за хвилину

    public int Minutes => Inner.Minutes;
    public decimal PricePerMinute => Inner.PricePerMinute + Surcharge;
    public string Describe() => $"{Inner.Describe()} + {OptionName}";

    public decimal CalculateCost()
    {
        decimal inner = Inner.CalculateCost();      // спершу рахує обгорнутий об'єкт
        decimal extra = Minutes * Surcharge;
        Log.Write($"Опція «{OptionName}»", $"додає {extra:F2} грн до {inner:F2} грн обгорнутого об'єкта");
        return inner + extra;
    }
}

public class FullInsuranceOption : TripOptionDecorator
{
    public FullInsuranceOption(ITrip inner) : base(inner) { }
    protected override string OptionName => "повне страхування";
    protected override decimal Surcharge => 0.80m;
}

public class ChildSeatOption : TripOptionDecorator
{
    public ChildSeatOption(ITrip inner) : base(inner) { }
    protected override string OptionName => "дитяче крісло";
    protected override decimal Surcharge => 0.30m;
}

public class SecondDriverOption : TripOptionDecorator
{
    public SecondDriverOption(ITrip inner) : base(inner) { }
    protected override string OptionName => "другий водій";
    protected override decimal Surcharge => 0.50m;
}

public class OutOfCityOption : TripOptionDecorator
{
    public OutOfCityOption(ITrip inner) : base(inner) { }
    protected override string OptionName => "за межі міста";
    protected override decimal Surcharge => 1.20m;
}

public class RoofBoxOption : TripOptionDecorator
{
    public RoofBoxOption(ITrip inner) : base(inner) { }
    protected override string OptionName => "багажник на дах";
    protected override decimal Surcharge => 0.60m;
}