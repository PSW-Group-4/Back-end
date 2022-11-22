using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodRequests.Model;
using IntegrationLibrary.BloodBankNews.Model;

namespace IntegrationLibrary.Settings
{
    public class IntegrationDbContext : DbContext
    {
        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<ReportConfiguration> ReportConfigurations { get; set; }
        public DbSet<BloodUsageReport> BloodUsageReports { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<BloodRequest> BloodRequests { get; set; }
        public DbSet<BloodUsage> BloodUsages { get; set; }
        public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
