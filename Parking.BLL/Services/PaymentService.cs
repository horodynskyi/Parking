using Microsoft.Extensions.Options;
using Parking.BLL.Helpers;
using Parking.BLL.Interfaces;
using Parking.BLL.Options;
using Parking.BLL.Params;
using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.BLL.Services;

public class PaymentService:IPaymentService
{
    private readonly IPaymentRepository _repository;
    private readonly ITwilioService _twilioService;
    public PaymentService(IOptions<TwilioOptions> options, IPaymentRepository repository, ITwilioService twilioService)
    {
        _repository = repository;
        _twilioService = twilioService;
    }

    public void SendSms(string text, string phoneNumber)
    {
        _twilioService.SendNotification(text, phoneNumber);
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

    public async Task<IEnumerable<Payment>> Get(PaymentParams paymentParams)
    {
        var payments = await _repository.FindByCondition(x => x.Sum >= paymentParams.MinSum && x.Sum <= paymentParams.MaxSum && x.EndPark.Year <= paymentParams.maxDate);
        return PageHelper<Payment>.ToPagedList(payments,paymentParams);
    }
}