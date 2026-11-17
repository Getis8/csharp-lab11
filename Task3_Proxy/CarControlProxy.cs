namespace Lab_11;

// Protection Proxy + журнал команд
public class CarControlProxy : ICarControl
{
    private readonly ICarControl _real;
    private readonly string _plate;
    private readonly string _renter;
    private readonly List<string> _journal = new();

    public IReadOnlyList<string> Journal => _journal;

    public CarControlProxy(ICarControl real, string plate, string renter)
    {
        _real = real ?? throw new ArgumentNullException(nameof(real));
        _plate = plate;
        _renter = renter;
    }

    public CommandResult OpenDoors(string client) =>
        Execute(client, "відкрити двері", _real.OpenDoors);
    public CommandResult StartEngine(string client) =>
        Execute(client, "увімкнути двигун", _real.StartEngine);
    public CommandResult Honk(string client) =>
        Execute(client, "посигналити", _real.Honk);

    private CommandResult Execute(string client, string command, Func<string, CommandResult> action)
    {
        if (client != _renter)
        {
            _journal.Add($"{client}: {command} - ВІДМОВА");
            Log.Write("Proxy", $"{client} намагається «{command}» на {_plate}: Ви не є орендарем цього авто");
            return new(false, "Ви не є орендарем цього авто");   // сервер не викликається
        }

        _journal.Add($"{client}: {command} - передано на сервер");
        Log.Write("Proxy", $"{client}: «{command}» на {_plate}, передаємо на сервер");
        return action(client);
    }
}