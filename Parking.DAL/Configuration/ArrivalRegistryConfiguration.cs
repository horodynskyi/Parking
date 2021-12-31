using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.DAL.Models;

namespace Parking.DAL.Configuration;

public class ArrivalRegistryConfiguration:IEntityTypeConfiguration<Arrival>
{
    public void Configure(EntityTypeBuilder<Arrival> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Car).WithMany();
    }
}