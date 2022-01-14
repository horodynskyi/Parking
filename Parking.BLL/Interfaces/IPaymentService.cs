using Parking.BLL.Params;
using Parking.DAL.Models;

namespace Parking.BLL.Interfaces;

public interface IPaymentService
{
    void SendSms(string text, string phoneNumber);
    Task Create(Payment payment);
    Task<IEnumerable<Payment>> Get();
    Task<Payment> GetById(long id);
    Task Update(Payment payment);
    Task Delete(long id);
    Task<IEnumerable<Payment>> Get(PaymentParams arrivalParams);
}