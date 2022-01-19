using FluentValidation;
using FluentValidation.Results;
using Parking.BLL.Helpers;
using Parking.BLL.Interfaces;
using Parking.DAL.Interface;
using Parking.DAL.Models;

namespace Parking.BLL.Services;

public class BaseService<T>:IBaseService<T> where T:class
{
    private readonly IValidator<T> _validator;
    protected readonly ISortHelper<T> SortHelper;
    public BaseService(IValidator<T> validator, ISortHelper<T> sortHelper)
    {
        _validator = validator;
        SortHelper = sortHelper;
    }

    public async Task<ValidationResult> Validation(T entity)
    {
        return await _validator.ValidateAsync(entity);
    }
}