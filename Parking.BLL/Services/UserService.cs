using Microsoft.Extensions.Options;
using Parking.BLL.Interfaces;
using Parking.BLL.Options;
using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.BLL.Services;

public class UserService:TwilioService,IUserService
{
    private readonly IUserRepository _repository;
    public UserService(IOptions<TwilioOptions> options, IUserRepository repository) : base(options)
    {
        _repository = repository;
    }
    public void SendSms(string text, string phoneNumber)
    {
        SendNotification(text, phoneNumber);
    }

    public async Task Create(User user)
    {
        await _repository.Create(user);
        await _repository.Complete();
    }

    public async Task<IEnumerable<User>> Get()
    {
        return await _repository.Get();
    }

    public async Task<User> GetById(long id)
    {
        return await _repository.GetById(id);
    }

    public async Task Update(User user)
    {
        await _repository.Update(user);
        await _repository.Complete();
    }

    public async Task Delete(long id)
    {
        await _repository.Delete(id);
        await _repository.Complete();
    }

    
}