using GeekShopping.OrderAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekShopping.CartAPI.Model.Mappings
{
    public class OrderDetailMapping : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("order_detail");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.OrderHeaderId);
            builder.Property(x => x.ProductId);
            builder.Property(x => x.ProductName).HasColumnName("product_name");
            builder.Property(x => x.Count);

            builder.HasOne(d => d.OrderHeader)
                .WithMany(d => d.OrderDetails)
                .HasForeignKey(d => d.OrderHeaderId);
        }
    }
}
