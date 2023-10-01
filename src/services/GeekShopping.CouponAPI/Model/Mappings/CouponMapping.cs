using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekShopping.CouponAPI.Model.Mappings
{
    public class CouponMapping : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.ToTable("coupon");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.CouponCode).HasColumnName("coupon_name").HasMaxLength(30).IsRequired();
            builder.Property(p => p.DiscountAmount).HasColumnName("discount_amount").HasPrecision(18,2).IsRequired();
            
        }
    }
}
