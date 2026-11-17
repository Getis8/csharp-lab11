namespace Lab_11;

public static partial class DemoRunner
{
    public static void RunDecorator()
    {
        Log.Section("Завдання 4. Decorator: додаткові опції поїздки");

        ITrip plain = new BasicTrip(30);
        Print("Звичайна", plain);

        ITrip family = new SecondDriverOption(new ChildSeatOption(new FullInsuranceOption(new BasicTrip(30))));
        Print("Сімейна", family);

        ITrip trip = new RoofBoxOption(new OutOfCityOption(new BasicTrip(30)));
        Print("За місто", trip);
    }

    private static void Print(string title, ITrip trip)
    {
        decimal cost = trip.CalculateCost();        // розрахунок у журналі йде перед підсумком
        Log.Write("Поїздка",
            $"{title}: {trip.Describe()}; {trip.PricePerMinute:F2} грн/хв; разом {cost:F2} грн");
    }
}