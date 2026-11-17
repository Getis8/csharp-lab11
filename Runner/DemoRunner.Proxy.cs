namespace Lab_11;

public static partial class DemoRunner
{
    public static void RunProxy()
    {
        Log.Section("Завдання 3. Proxy: керування авто через віддалений сервер");

        var real = new RemoteCarControl("CE1234AA");
        ICarControl car = new CarControlProxy(real, "CE1234AA", renter: "Ткачук");  // застосунок бачить лише інтерфейс

        Log.Write("Застосунок", car.OpenDoors("Ткачук").Message);
        Log.Write("Застосунок", car.OpenDoors("Шевченко").Message);

        Log.Write("Журнал", "Команди:");
        foreach (var entry in ((CarControlProxy)car).Journal)
            Log.Write("Журнал", entry);
        Log.Write("Журнал", $"Звернень до сервера: {real.ServerCalls}");
    }
}