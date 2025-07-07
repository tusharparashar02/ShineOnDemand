using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ServicePackage> ServicePackages { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<AddOn> AddOns { get; set; }
        public DbSet<OrderAddOn> OrderAddOns { get; set; }
        public DbSet<PaymentReceipt> PaymentReceipts { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Leaderboard> Leaderboards { get; set; }
        public DbSet<WashRequest> WashRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .HasKey(c => c.CarNumber);

            modelBuilder.Entity<OrderAddOn>().HasKey(oa => new { oa.OrderId, oa.AddOnId });

            {
                modelBuilder.Entity<Order>()
                .HasOne(o => o.Car)
                .WithMany()
                .HasForeignKey(o => o.CarNumber)
                .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Order>()
                    .HasOne(o => o.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(o => o.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<Order>()
                    .HasOne(o => o.Washer)
                    .WithMany()
                    .HasForeignKey(o => o.WasherId)
                    .OnDelete(DeleteBehavior.Restrict);

                modelBuilder
                    .Entity<OrderAddOn>()
                    .HasOne(oa => oa.Order)
                    .WithMany(o => o.OrderAddOns)
                    .HasForeignKey(oa => oa.OrderId);

                modelBuilder
                    .Entity<OrderAddOn>()
                    .HasOne(oa => oa.AddOn)
                    .WithMany(a => a.OrderAddOns)
                    .HasForeignKey(oa => oa.AddOnId);
                modelBuilder
                    .Entity<WashRequest>()
                    .HasOne(wr => wr.User)
                    .WithMany()
                    .HasForeignKey(wr => wr.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                modelBuilder
                    .Entity<WashRequest>()
                    .HasOne(wr => wr.Washer)
                    .WithMany()
                    .HasForeignKey(wr => wr.WasherId)
                    .OnDelete(DeleteBehavior.Restrict);
                modelBuilder
                    .Entity<Car>()
                    .HasKey(c => c.CarNumber);
                modelBuilder.Entity<WashRequest>()
                    .HasOne(wr => wr.Car)
                    .WithMany()
                    .HasForeignKey(wr => wr.CarNumber)
                    .OnDelete(DeleteBehavior.Restrict);
                modelBuilder
                    .Entity<WashRequest>()
                    .HasOne(wr => wr.Package)
                    .WithMany()
                    .HasForeignKey(wr => wr.PackageId);
                modelBuilder
                    .Entity<Rating>()
                    .HasOne(r => r.Order)
                    .WithMany()
                    .HasForeignKey(r => r.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);
                modelBuilder
                    .Entity<Rating>()
                    .HasOne(r => r.Washer)
                    .WithMany()
                    .HasForeignKey(r => r.WasherId)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}