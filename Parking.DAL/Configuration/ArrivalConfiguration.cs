using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.DAL.Models;

namespace Parking.DAL.Configuration;

public class ArrivalConfiguration:IEntityTypeConfiguration<Arrival>
{
    public void Configure(EntityTypeBuilder<Arrival> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(d => d.Car)
            .WithMany(p => p.Arrivals)
            .HasForeignKey(d => d.CarId)
            .OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(d => d.Status)
            .WithMany(p => p.Arrivals)
            .HasForeignKey(p => p.StatusId)
            .OnDelete(DeleteBehavior.SetNull);
        
    }
}