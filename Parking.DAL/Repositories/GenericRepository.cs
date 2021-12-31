using Microsoft.EntityFrameworkCore;
using Parking.DAL.Interface;

namespace Parking.DAL.Repositories;

public class GenericRepository<TEntity,TId>:IGenericRepository<TEntity,TId> where TEntity:class
{
    protected readonly DataContext Context;
    protected readonly DbSet<TEntity> DbSet;

    public GenericRepository(DataContext context)
    {
        Context = context;
        DbSet = Context.Set<TEntity>();
    }

    public async Task Create(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    public virtual async Task<IEnumerable<TEntity>> Get()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task<TEntity> GetById(TId id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public async Task Delete(TId id)
    {
        var entity = await GetById(id);
        DbSet.Remove(entity);
    }

    public async Task Complete()
    {
        await Context.SaveChangesAsync();
    }
}