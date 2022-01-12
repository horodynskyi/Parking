using Parking.DAL.Models;

namespace Parking.BLL.Interfaces;

public interface IUserService:IBaseService<User>
{
    void SendSms(string text, string phoneNumber);
    Task Create(User user);
    Task<IEnumerable<User>> Get();
    Task<User> GetById(long id);
    Task Update(User user);
    Task Delete(long id);
}