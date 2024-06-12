

using ContextConfiguration.Account;
using Microsoft.EntityFrameworkCore;
using SampleWebApiAspNetCore.Dtos;

namespace Infrastructure
{
    public partial class DatabaseContext
    {
        public DbSet<AccountDTO> Account { get; set; }
        public DbSet<PlaceAlertsDTO> Alerts { get; set; }
        
        internal static void AccountEntityConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountConfiguration());
            builder.ApplyConfiguration(new PlaceAlertsConfiguration());
            builder.ApplyConfiguration(new PlaceAlertsConfiguration());
        }
    }
}