using FluentValidation.Results;
using Parking.DAL.Models;

namespace Parking.BLL.Interfaces;

public interface IBaseService<T>
{
    Task<ValidationResult> Validation(T entity);
}