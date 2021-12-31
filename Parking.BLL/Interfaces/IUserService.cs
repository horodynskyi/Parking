using Parking.DAL.Models;

namespace Parking.BLL.Interfaces;

public interface IUserService:ITwilioService
{
    void SendSms(string text, string phoneNumber);
    Task Create(User user);
    Task<IEnumerable<User>> Get();
    Task<User> GetById(long id);
    Task Update(User user);
    Task Delete(long id);
}