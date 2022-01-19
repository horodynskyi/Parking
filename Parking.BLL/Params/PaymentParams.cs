using System.Collections.Immutable;
using System.Linq.Expressions;
using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.BLL.Params;

public class PaymentParams:QueryStringParameters
{
    public PaymentParams()
    {
        OrderBy = "sum";
    }

    public int? MinSum { get; set; } = 0;
    public int? MaxSum { get; set; } = 0;
    public int? MinDate { get; set; } = 0;
    public int? MaxDate { get; set; } = 0;
    public bool ValidSumRange() => MinSum<MaxSum;
    public bool ValidDateRange() => MinDate < MaxDate;
    
    
    public async Task<IEnumerable<Payment>> FiltrExpr(IPaymentRepository repository)
    {
        if (ValidSumRange() && ValidDateRange())
            return await repository
                .FindByCondition(x => x.Sum >= MinSum && x.Sum <= MaxSum 
                                                      && DateTime.Parse(x.EndPark).Month<=MaxDate && DateTime.Parse(x.EndPark).Month>=MinDate);
        if (ValidDateRange() && !ValidSumRange())
            return await repository
                .FindByCondition(x =>DateTime.Parse(x.EndPark).Month<=MaxDate && DateTime.Parse(x.EndPark).Month>=MinDate);
        if (!ValidDateRange() && ValidSumRange())
            return await repository
                .FindByCondition(x => x.Sum >= MinSum && x.Sum <= MaxSum);
        return await repository.Get();
    }
}