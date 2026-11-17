namespace Lab_11;

public static partial class DemoRunner
{
    public static void RunAdapter()
    {
        Log.Section("Завдання 1. Adapter: телематика нового постачальника");

        var block = new VendorTelematicsBlock("CE5678EE",
            new DmsCoordinate(48, 17, 29.4, 'N'),
            new DmsCoordinate(25, 56, 25.1, 'E'),
            fuelLiters: 21, tankCapacityLiters: 42);

        Log.Write("Блок виробника",
            $"Вихідні дані: lat 48°17'29.4\"N, lon 25°56'25.1\"E, пальне {block.ReadFuelLiters()} л з {block.TankCapacityLiters} л");

        var cars = new List<IFleetTelematics>
        {
            new NativeTelematics("CE1234AA", 48.2915, 25.9403, 80),
            new NativeTelematics("CE2345BB", 48.3012, 25.9211, 55),
            new VendorTelematicsAdapter(block)      // нове авто через адаптер
        };

        new FleetMapView().Show(cars);              // карта працює з усіма однаково
    }
}