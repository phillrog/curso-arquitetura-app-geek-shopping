using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponAPI.Model.Context
{
    public class CouponContext : DbContext
    {
        public CouponContext() {}
        public CouponContext(DbContextOptions<CouponContext> options) : base(options) {}

        public DbSet<Coupon> Coupon { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CouponContext).Assembly);

            modelBuilder.Entity<Coupon>().HasData(new Coupon { 
                Id = 1, 
                CouponCode = "DIA_DAS_CRIANCAS_40",
                DiscountAmount = 40
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 2,
                CouponCode = "BLACK_FRIDAY_75",
                DiscountAmount = 75
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
        }

    }
}
