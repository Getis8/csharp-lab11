namespace Lab_11;

public class TripFacade
{
    private const decimal HoldAmount = 500m;

    private readonly DriverLicenseService _license;
    private readonly PaymentService _payment;
    private readonly ReservationService _reservation;
    private readonly DoorLockService _doors;
    private readonly TelematicsService _telematics;
    private readonly InsuranceService _insurance;

    public TripFacade(DriverLicenseService license, PaymentService payment, ReservationService reservation,
        DoorLockService doors, TelematicsService telematics, InsuranceService insurance)
    {
        _license = license;
        _payment = payment;
        _reservation = reservation;
        _doors = doors;
        _telematics = telematics;
        _insurance = insurance;
    }

    // Єдине місце з правильним порядком кроків
    public OperationResult StartTrip(string client, string plate)
    {
        Log.Write("Фасад",
            $"Початок поїздки {client} на {plate}: передаю підсистемам у єдиному порядку (посвідчення, платіж, резерв, двері, телематика, страхування)");

        if (!_license.Verify(client))
            return new(false, "Посвідчення недійсне");
        if (!_payment.HoldFunds(client, HoldAmount))
            return new(false, "Не вдалося заблокувати кошти");

        _reservation.Reserve(plate, client);
        _doors.Unlock(plate);
        _telematics.Enable(plate);
        _insurance.Insure(plate, client);

        return new(true, $"Поїздку {client} на {plate} розпочато");
    }
}