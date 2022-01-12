using Parking.DAL.Models;

namespace Parking.DAL.Interface;

public interface IPaymentRepository:IGenericRepository<Payment,long>
{
    Task<IEnumerable<Payment>> GetPaymentsInRange(DateTime start, DateTime end);
}