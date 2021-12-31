using Microsoft.EntityFrameworkCore;
using Parking.DAL.Configuration;
using Parking.DAL.Models;

namespace Parking.DAL;

public sealed class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Tariff> Tariffs { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Arrival> DriveRegistries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        modelBuilder.ApplyConfiguration(new ArrivalRegistryConfiguration());
        modelBuilder.ApplyConfiguration(new TariffConfiguration());
        modelBuilder.ApplyConfiguration(new StatusConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}