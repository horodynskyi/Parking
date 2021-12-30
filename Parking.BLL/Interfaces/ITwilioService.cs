namespace Parking.BLL.Interfaces;

public interface ITwilioService
{
    string SendNotification(string text, string phoneNumber);
}