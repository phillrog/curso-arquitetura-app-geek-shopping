using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekShopping.Email.Model.Mappings
{
    public class EmailMapping : IEntityTypeConfiguration<EmailLog>
    {
        public void Configure(EntityTypeBuilder<EmailLog> builder)
        {
            builder.ToTable("email_logs");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Email);
            builder.Property(x => x.Log);
            builder.Property(x => x.SentDate).HasColumnName("sent_date");
            
        }
    }
}
