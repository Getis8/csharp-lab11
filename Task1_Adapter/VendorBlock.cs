namespace Lab_11;

public record DmsCoordinate(int Degrees, int Minutes, double Seconds, char Hemisphere);

public class VendorTelematicsBlock
{
    public string CarNumber { get; }
    public double TankCapacityLiters { get; }
    private readonly DmsCoordinate _lat;
    private readonly DmsCoordinate _lon;
    private readonly double _fuelLiters;

    public VendorTelematicsBlock(string carNumber, DmsCoordinate lat, DmsCoordinate lon,
        double fuelLiters, double tankCapacityLiters)
    {
        CarNumber = carNumber;
        _lat = lat;
        _lon = lon;
        _fuelLiters = fuelLiters;
        TankCapacityLiters = tankCapacityLiters;
    }

    // Інші назви методів і формати
    public DmsCoordinate ReadLatitudeDms() => _lat;
    public DmsCoordinate ReadLongitudeDms() => _lon;
    public double ReadFuelLiters() => _fuelLiters;
}