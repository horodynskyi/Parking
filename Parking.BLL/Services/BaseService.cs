using FluentValidation;
using FluentValidation.Results;
using Parking.BLL.Interfaces;

namespace Parking.BLL.Services;

public class BaseService<T>:IBaseService<T>
{
    private readonly IValidator<T> _validator;

    public BaseService(IValidator<T> validator)
    {
        _validator = validator;
    }

    public async Task<ValidationResult> Validation(T entity)
    {
        return await _validator.ValidateAsync(entity);
    }
}