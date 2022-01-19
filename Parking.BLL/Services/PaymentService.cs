using FluentValidation;
using Microsoft.Extensions.Options;
using Parking.BLL.Helpers;
using Parking.BLL.Interfaces;
using Parking.BLL.Options;
using Parking.BLL.Params;
using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.BLL.Services;

public class PaymentService:BaseService<Payment>,IPaymentService
{
    private readonly IPaymentRepository _repository;
    private readonly ITwilioService _twilioService;
    
    
    public PaymentService(IOptions<TwilioOptions> options, IPaymentRepository repository, 
        ITwilioService twilioService, ISortHelper<Payment> sortHelper,IValidator<Payment> validator) : base(validator,sortHelper)
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
        await _repository.Complete();
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
        var payments = await paymentParams.FiltrExpr(_repository);
        var sorted = SortHelper.ApplySort(payments.AsQueryable(),paymentParams.OrderBy,paymentParams.Asending);
        return PageHelper<Payment>.ToPagedList(sorted,paymentParams);
    }
}