namespace Lab_11;

public class DriverLicenseService
{
    public bool Verify(string client)
    {
        Log.Write("Посвідчення", $"Перевірено посвідчення водія клієнта {client}");
        return true;
    }
}

public class PaymentService
{
    public bool HoldFunds(string client, decimal amount)
    {
        Log.Write("Платежі", $"Заблоковано {amount:F0} грн на картці клієнта {client}");
        return true;
    }
}

public class ReservationService
{
    public void Reserve(string plate, string client) =>
        Log.Write("Резервування", $"Авто {plate} зарезервоване для {client}");
}

public class DoorLockService
{
    public void Unlock(string plate) =>
        Log.Write("Двері", $"Двері {plate} розблоковано");
}

public class TelematicsService
{
    public void Enable(string plate) =>
        Log.Write("Телематика", $"Телематику {plate} увімкнено");
}

public class InsuranceService
{
    public void Insure(string plate, string client) =>
        Log.Write("Страхування", $"Поїздку {client} на {plate} застраховано");
}