using FluentValidation;
using Microsoft.Extensions.Options;
using Parking.BLL.Helpers;
using Parking.BLL.Interfaces;
using Parking.BLL.Options;
using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.BLL.Services;

public class UserService:BaseService<User>,IUserService
{
    private readonly IUserRepository _repository;
    private readonly ITwilioService _twilioService;
    
    public UserService(IOptions<TwilioOptions> options, IUserRepository repository, ITwilioService twilioService,IValidator<User> validator,ISortHelper<User> sortHelper) 
        : base(validator,sortHelper)
    {
        _repository = repository;
        _twilioService = twilioService;
    }
    public void SendSms(string text, string phoneNumber)
    {
        _twilioService.SendNotification(text, phoneNumber);
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