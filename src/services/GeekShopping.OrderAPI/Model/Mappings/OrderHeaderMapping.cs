using GeekShopping.OrderAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekShopping.CartAPI.Model.Mappings
{
    public class OrderHeaderMapping : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.ToTable("order_header");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.UserId).HasColumnName("user_id").HasMaxLength(150);
            builder.Property(x => x.CouponCode).HasColumnName("coupon_code").HasMaxLength(500).HasDefaultValue(null);
            builder.Property(x => x.PurchaseAmount).HasColumnName("purchase_amount");
            builder.Property(x => x.DiscountAmount).HasColumnName("discount_amount");
            builder.Property(x => x.FirstName).HasColumnName("FirstName").HasMaxLength(255);
            builder.Property(x => x.LastName).HasColumnName("last_name").HasMaxLength(255);
            builder.Property(x => x.DateTime).HasColumnName("purchase_date");
            builder.Property(x => x.OrderTime).HasColumnName("order_time");
            builder.Property(x => x.Phone).HasColumnName("phone_number").HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(500);
            builder.Property(x => x.CardNumber).HasColumnName("card_number").HasMaxLength(50);
            builder.Property(x => x.CVV).HasMaxLength(4);
            builder.Property(x => x.ExpireMonthYear).HasColumnName("expiry_month_year").HasMaxLength(4);
            builder.Property(x => x.CartTotalItens).HasColumnName("total_itens");

            builder.HasMany(d => d.OrderDetails).WithOne(p => p.OrderHeader).HasForeignKey(f => f.OrderHeaderId);
        }
    }
}
