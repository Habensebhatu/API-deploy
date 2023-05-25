using System;
using Data_Access_Layer.Context;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<UserEntityModel> User { get; set; }
        public DbSet<CustomerEntityModel> Client { get; set; }
        public DbSet<RepairEntityModel> Repair { get; set; }
        public DbSet<WorkActivitiesEntityModel> WorkActivities { get; set; }
        public DbSet<StatusOverviewEntityModel> StatusOverview { get; set; }

        public MyDbContext()
        {

        }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=WatchMasterDB;User Id=sa;Password=Admin@123;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkActivitiesEntityModel>()
                .Property(p => p.priceExclVat)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<WorkActivitiesEntityModel>()
                .Property(p => p.priceInclVat)
                .HasColumnType("decimal(18,2)");

            // Add any other configuration for your entities here

            base.OnModelCreating(modelBuilder);
        }
    }
}


