using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleWebApiAspNetCore.Dtos;
using SampleWebApiAspNetCore.Enums;
using System.Linq;

namespace ContextConfiguration.Account
{
    public class AccountConfiguration : IEntityTypeConfiguration<AccountDTO>
    {
        public void Configure(EntityTypeBuilder<AccountDTO> builder)
        {
            builder
                  .ToTable("Account", "LPR")
                  .HasKey(x => x.Id);

            builder
                .Property(x => x.Username)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.Password)
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();


            builder
                .Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

            builder
               .Property(x => x.Registro)
               .HasColumnType("varchar")
               .HasMaxLength(150)
               .IsRequired();


            builder
                .Property(x => x.Type)
                .HasConversion(new ValueConverter<CadastroTypeEnum, int>(
                    x => (int)x,
                    x => (CadastroTypeEnum)x))
                .HasColumnType("int")
                .HasDefaultValue(CadastroTypeEnum.Default)
                .IsRequired();

            builder
                .Property(x => x.CreateDate)
                .HasColumnType("datetime2")
                .HasDefaultValueSql("getdate()")
                .IsRequired();
        }
    }
}
