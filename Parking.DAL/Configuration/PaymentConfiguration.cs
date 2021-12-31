using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.DAL.Models;

namespace Parking.DAL.Configuration;

public class PaymentConfiguration:IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.RegistrId);
        builder.HasOne(x => x.TariffId);
    }
}