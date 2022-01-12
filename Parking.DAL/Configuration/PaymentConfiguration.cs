using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.DAL.Models;

namespace Parking.DAL.Configuration;

public class PaymentConfiguration:IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(d => d.Arrival)
            .WithMany(p => p.Payments)
            .HasForeignKey(d => d.ArrivalId)
            .OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(d => d.Tariff)
            .WithMany(p => p.Payments)
            .HasForeignKey(d => d.TariffId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}