using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Email.Model.Context
{
    public class EmailContext : DbContext
    {
        public EmailContext() {}
        public EmailContext(DbContextOptions<EmailContext> options) : base(options) {}

        public DbSet<EmailLog> EmailLogs{ get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmailContext).Assembly);
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
