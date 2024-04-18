using Microsoft.EntityFrameworkCore;
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

        public TabiContext(DbContextOptions<TabiContext> options) : base(options)
        {
        }

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

            // Filter entities with IsActive = true
            modelBuilder.Entity<Crop>().HasQueryFilter(c => c.IsActive);
            modelBuilder.Entity<CropManagement>().HasQueryFilter(c => c.IsActive);
            modelBuilder.Entity<CropManagementType>().HasQueryFilter(c => c.IsActive);
            modelBuilder.Entity<CropState>().HasQueryFilter(c => c.IsActive);
            modelBuilder.Entity<CropType>().HasQueryFilter(c => c.IsActive);
            modelBuilder.Entity<DocumentType>().HasQueryFilter(c => c.IsActive);
            modelBuilder.Entity<Farm>().HasQueryFilter(c => c.IsActive);
            modelBuilder.Entity<Harvest>().HasQueryFilter(c => c.IsActive);
            modelBuilder.Entity<HarvestPayment>().HasQueryFilter(c => c.IsActive);
            modelBuilder.Entity<HarvestState>().HasQueryFilter(c => c.IsActive);
            modelBuilder.Entity<Lot>().HasQueryFilter(c => c.IsActive);
            modelBuilder.Entity<PaymentType>().HasQueryFilter(c => c.IsActive);
            modelBuilder.Entity<SlopeType>().HasQueryFilter(c => c.IsActive);
            modelBuilder.Entity<User>().HasQueryFilter(c => c.IsActive);
            modelBuilder.Entity<UserType>().HasQueryFilter(c => c.IsActive);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure lazy loading (auto relationships)
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
