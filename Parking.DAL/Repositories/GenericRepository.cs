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

    public async Task<IEnumerable<TEntity>> Get()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<TEntity> GetById(TId id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task Update(TEntity entity)
    {
        DbSet.Update(entity);
        await Context.SaveChangesAsync();
    }

    public async Task Delete(TId id)
    {
        var entity = await GetById(id);
        DbSet.Remove(entity);
        await Context.SaveChangesAsync();
    }
}