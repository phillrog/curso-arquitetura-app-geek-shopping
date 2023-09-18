using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekShopping.CartAPI.Model.Mappings
{
    public class CartDetailMapping : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.ToTable("cart_detail");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CartHeaderId);
            builder.Property(x => x.ProductId);
            builder.Property(x => x.Count);

            builder.HasOne(d => d.Product)
                .WithMany(d => d.CartDetails)
                .HasForeignKey(d => d.ProductId);

            builder.HasOne(d => d.CartHeader)
                .WithMany(d => d.CartDetails)
                .HasForeignKey(d => d.CartHeaderId);
        }
    }
}
