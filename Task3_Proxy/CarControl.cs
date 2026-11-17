namespace Lab_11;

public record CommandResult(bool Success, string Message);

// Спільний інтерфейс для Real Subject і Proxy
public interface ICarControl
{
    CommandResult OpenDoors(string client);
    CommandResult StartEngine(string client);
    CommandResult Honk(string client);
}

// Real Subject: повільний виклик віддаленого сервера
public class RemoteCarControl : ICarControl
{
    private readonly string _plate;
    public int ServerCalls { get; private set; }

    public RemoteCarControl(string plate) => _plate = plate;

    public CommandResult OpenDoors(string client) => Send("відкрити двері");
    public CommandResult StartEngine(string client) => Send("увімкнути двигун");
    public CommandResult Honk(string client) => Send("посигналити");

    private CommandResult Send(string command)
    {
        Log.Write("Сервер виробника", $"Команда «{command}» для {_plate} (повільний виклик)");
        Thread.Sleep(150);
        ServerCalls++;
        return new(true, $"Команда «{command}» виконана");
    }
}