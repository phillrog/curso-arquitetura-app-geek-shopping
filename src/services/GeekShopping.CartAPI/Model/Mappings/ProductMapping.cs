using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekShopping.CartAPI.Model.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Price).HasPrecision(18,2).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.CategoryName).HasColumnName("category_name").HasMaxLength(50);
            builder.Property(p => p.ImageURL).HasColumnName("image_url").HasMaxLength(300);            
        }
    }
}
