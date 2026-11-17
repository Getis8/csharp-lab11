namespace Lab_11;

public class MobileApp
{
    private readonly TripFacade _facade;
    public MobileApp(TripFacade facade) => _facade = facade;

    public void StartTrip(string client, string plate)
    {
        Log.Write("Застосунок", $"Початок поїздки: {client}, {plate}");
        Log.Write("Застосунок", _facade.StartTrip(client, plate).Message);
    }
}

public class DispatcherConsole
{
    private readonly TripFacade _facade;
    public DispatcherConsole(TripFacade facade) => _facade = facade;

    public void StartTrip(string client, string plate)
    {
        Log.Write("Диспетчер", $"Початок поїздки: {client}, {plate}");
        Log.Write("Диспетчер", _facade.StartTrip(client, plate).Message);
    }
}