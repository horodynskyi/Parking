using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.DAL.Models;

namespace Parking.DAL.Configuration;

public class CarConfiguration:IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(d => d.User)
            .WithMany(p => p.Cars)
            .HasForeignKey( d=> d.UserId)
            .OnDelete(DeleteBehavior.SetNull);
        /*builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.User);*/
    }
}