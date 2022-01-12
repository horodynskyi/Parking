using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Parking.DAL;

namespace Parking.BLL.Validators;

public class GenericValidator<TEntity>:AbstractValidator<TEntity> where TEntity:class
{
    protected readonly DataContext Context;
    public GenericValidator(DataContext context)
    {
        Context = context;
    }

    public async Task<bool> IsExist<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class
    {
        return await Context.Set<TEntity>().ContainsAsync(entity, cancellationToken);
    }

    public async Task<bool> IsNotExist<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class
    {
        return !await Context.Set<TEntity>().ContainsAsync(entity, cancellationToken);
    }
}