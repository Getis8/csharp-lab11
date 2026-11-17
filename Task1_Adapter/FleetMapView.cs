namespace Lab_11;

public class FleetMapView
{
    public void Show(IEnumerable<IFleetTelematics> cars)
    {
        foreach (var car in cars)
        {
            var p = car.GetPosition();
            Log.Write("Карта парку",
                $"{car.Plate}: {p.Latitude:F4}, {p.Longitude:F4}, пального {car.GetFuelPercent():F1}%");
        }
    }
}