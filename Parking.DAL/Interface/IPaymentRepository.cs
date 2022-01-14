using System.Linq.Expressions;
using Parking.DAL.Models;

namespace Parking.DAL.Interface;

public interface IPaymentRepository:IGenericRepository<Payment,long>
{
    Task<IEnumerable<Payment>> GetPaymentsInRange(DateTime start, DateTime end);
    Task<IEnumerable<Payment>> FindByCondition(Expression<Func<Payment, bool>> expression);
}