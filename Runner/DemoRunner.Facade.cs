namespace Lab_11;

public static partial class DemoRunner
{
    public static void RunFacade()
    {
        Log.Section("Завдання 2. Facade: початок поїздки");

        var doors = new DoorLockService();   // підсистема доступна й окремо
        var facade = new TripFacade(
            new DriverLicenseService(), new PaymentService(), new ReservationService(),
            doors, new TelematicsService(), new InsuranceService());

        new MobileApp(facade).StartTrip("Ткачук", "CE1234AA");
        new DispatcherConsole(facade).StartTrip("Мельник", "CE2345BB");

        Log.Write("Підтримка", "Віддалене розблокування дверей без початку поїздки");
        doors.Unlock("CE3456CC");
    }
}