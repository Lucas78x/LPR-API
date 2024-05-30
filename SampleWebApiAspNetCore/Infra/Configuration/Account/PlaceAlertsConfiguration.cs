using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleWebApiAspNetCore.Dtos;
using SampleWebApiAspNetCore.Enums;
using System.Linq;

namespace ContextConfiguration.Account
{
    public class PlaceAlertsConfiguration : IEntityTypeConfiguration<PlaceAlertsDTO>
    {
        public void Configure(EntityTypeBuilder<PlaceAlertsDTO> builder)
        {
            builder
                  .ToTable("PlaceAlerts", "LPR")
                  .HasKey(x => x.Id);

            builder
                .Property(x => x.Placa)
                .HasColumnType("varchar")
                .HasMaxLength(8)
                .IsRequired();

            builder
              .Property(x => x.CreateDate)
              .HasColumnType("datetime2")
              .HasDefaultValueSql("getdate()")
              .IsRequired();
        }
    }
}