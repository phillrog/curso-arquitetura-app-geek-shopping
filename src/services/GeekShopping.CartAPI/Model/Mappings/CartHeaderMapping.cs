﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekShopping.CartAPI.Model.Mappings
{
    public class CartHeaderMapping : IEntityTypeConfiguration<CartHeader>
    {
        public void Configure(EntityTypeBuilder<CartHeader> builder)
        {
            builder.ToTable("cart_header");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.UserId).HasMaxLength(150);
            builder.Property(x => x.CouponCode).HasMaxLength(500).HasDefaultValue(null);
        }
    }
}
