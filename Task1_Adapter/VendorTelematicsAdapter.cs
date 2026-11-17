namespace Lab_11;

public class VendorTelematicsAdapter : IFleetTelematics
{
    private readonly VendorTelematicsBlock _block;

    public VendorTelematicsAdapter(VendorTelematicsBlock block)
    {
        _block = block ?? throw new ArgumentNullException(nameof(block));
    }

    public string Plate => _block.CarNumber;

    public GeoPoint GetPosition() =>
        new(ToDecimalDegrees(_block.ReadLatitudeDms()), ToDecimalDegrees(_block.ReadLongitudeDms()));

    public double GetFuelPercent() =>
        Math.Round(_block.ReadFuelLiters() / _block.TankCapacityLiters * 100, 1);

    private static double ToDecimalDegrees(DmsCoordinate c)
    {
        double value = c.Degrees + c.Minutes / 60.0 + c.Seconds / 3600.0;
        return c.Hemisphere is 'S' or 'W' ? -value : value;
    }
}