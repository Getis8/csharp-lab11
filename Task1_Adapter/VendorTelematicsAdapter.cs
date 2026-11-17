namespace Lab_11;

public class VendorTelematicsAdapter : IFleetTelematics
{
    private readonly VendorTelematicsBlock _block;

    public VendorTelematicsAdapter(VendorTelematicsBlock block)
    {
        _block = block ?? throw new ArgumentNullException(nameof(block));
    }

    public string Plate => _block.CarNumber;

    public GeoPoint GetPosition()
    {
        var latDms = _block.ReadLatitudeDms();
        var lonDms = _block.ReadLongitudeDms();
        double lat = ToDecimalDegrees(latDms);
        double lon = ToDecimalDegrees(lonDms);

        Log.Write("Адаптер",
            $"{Plate}: прочитано DMS з блока виробника, переведено в {lat:F4}, {lon:F4}");
        return new GeoPoint(lat, lon);
    }

    public double GetFuelPercent()
    {
        double liters = _block.ReadFuelLiters();
        double percent = Math.Round(liters / _block.TankCapacityLiters * 100, 1);

        Log.Write("Адаптер",
            $"{Plate}: блок виробника віддав {liters} л з {_block.TankCapacityLiters} л, переведено в {percent:F1}%");
        return percent;
    }

    private static double ToDecimalDegrees(DmsCoordinate c)
    {
        double value = c.Degrees + c.Minutes / 60.0 + c.Seconds / 3600.0;
        return c.Hemisphere is 'S' or 'W' ? -value : value;
    }
}