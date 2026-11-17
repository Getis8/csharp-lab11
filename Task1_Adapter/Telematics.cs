namespace Lab_11;

public record GeoPoint(double Latitude, double Longitude);

// Target: власний інтерфейс карти парку
public interface IFleetTelematics
{
    string Plate { get; }
    GeoPoint GetPosition();
    double GetFuelPercent();
}

// Старі блоки: вже підтримують наш інтерфейс
public class NativeTelematics : IFleetTelematics
{
    private readonly GeoPoint _position;
    private readonly double _fuelPercent;

    public string Plate { get; }

    public NativeTelematics(string plate, double lat, double lon, double fuelPercent)
    {
        Plate = plate;
        _position = new GeoPoint(lat, lon);
        _fuelPercent = fuelPercent;
    }

    public GeoPoint GetPosition() => _position;
    public double GetFuelPercent() => _fuelPercent;
}