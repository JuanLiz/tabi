﻿using Microsoft.EntityFrameworkCore;
using Tabi.Model;

namespace Tabi.Context
{
    public class TabiContext : DbContext
    {
        // All DbSet goes here
        public DbSet<Crop> Crops { get; set; }
        public DbSet<CropState> CropStates { get; set; }
        public DbSet<CropType> CropTypes { get; set; }
        public DbSet<CropManagement> CropManagements { get; set; }
        public DbSet<CropManagementType> CropManagementTypes { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Harvest> Harvests { get; set; }
        public DbSet<HarvestPayment> HarvestPayments { get; set; }
        public DbSet<HarvestState> HarvestStates { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<SlopeType> SlopeTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Convert to singular table names
            modelBuilder.Entity<Crop>().ToTable("Crop");
            modelBuilder.Entity<CropState>().ToTable("CropState");
            modelBuilder.Entity<CropType>().ToTable("CropType");
            modelBuilder.Entity<CropManagement>().ToTable("CropManagement");
            modelBuilder.Entity<CropManagementType>().ToTable("CropManagementType");
            modelBuilder.Entity<DocumentType>().ToTable("DocumentType");
            modelBuilder.Entity<Farm>().ToTable("Farm");
            modelBuilder.Entity<Harvest>().ToTable("Harvest");
            modelBuilder.Entity<HarvestPayment>().ToTable("HarvestPayment");
            modelBuilder.Entity<HarvestState>().ToTable("HarvestState");
            modelBuilder.Entity<Lot>().ToTable("Lot");
            modelBuilder.Entity<PaymentType>().ToTable("PaymentType");
            modelBuilder.Entity<SlopeType>().ToTable("SlopeType");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<UserType>().ToTable("UserType");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure lazy loading (auto relationships)
            optionsBuilder.UseLazyLoadingProxies();
        }

        public TabiContext(DbContextOptions<TabiContext> options) : base(options)
        {
        }

    }
}
