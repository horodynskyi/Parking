using Microsoft.Extensions.Options;
using Parking.BLL.Interfaces;
using Parking.BLL.Options;
using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.BLL.Services;

public class PaymentService:TwilioService,IPaymentService
{
    private readonly IPaymentRepository _repository;
    public PaymentService(IOptions<TwilioOptions> options, IPaymentRepository repository) : base(options)
    {
        _repository = repository;
    }

    public void SendSms(string text, string phoneNumber)
    {
        SendNotification(text, phoneNumber);
    }

    public async Task Create(Payment payment)
    {
        await _repository.Create(payment);
    }

    public async Task<IEnumerable<Payment>> Get()
    {
        return await _repository.Get();
    }

    public async Task<Payment> GetById(long id)
    {
        return await _repository.GetById(id);
    }

    public async Task Update(Payment payment)
    {
        await _repository.Update(payment);
    }

    public async Task Delete(long id)
    {
        await _repository.Delete(id);
    }
}