﻿using System.Reflection;
using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodRequests.Model;
using IntegrationLibrary.BloodSubscriptionResponses.Model;
using IntegrationLibrary.BloodSubscriptions;
using IntegrationLibrary.EntityConfigurations;
using IntegrationLibrary.TenderApplications.Model;
using IntegrationLibrary.Tenders.Model;
using Microsoft.EntityFrameworkCore;

namespace IntegrationLibrary.Settings
{
    public class IntegrationDbContext : DbContext
    {
        public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options) : base(options)
        {
        }

        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<ReportConfiguration> ReportConfigurations { get; set; }
        public DbSet<BloodUsageReport> BloodUsageReports { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<BloodRequest> BloodRequests { get; set; }
        public DbSet<BloodUsage> BloodUsages { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<BloodSubscription> BloodSubscription { get; set; }
        public DbSet<TenderApplication> TenderApplications { get; set; }
        public DbSet<BloodSubscriptionResponse> BloodSubscriptionRepsponce { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new BloodUsageConfiguration());
            modelBuilder.ApplyConfiguration(new BloodRequestConfiguration());
            modelBuilder.ApplyConfiguration(new TenderConfiguration());
            modelBuilder.ApplyConfiguration(new BloodSubscriptionConfiguration());
        }
    }
}