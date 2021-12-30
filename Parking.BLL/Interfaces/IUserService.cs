namespace Parking.BLL.Interfaces;

public interface IUserService
{
    Task SendSms(string text, string phoneNumber);
}