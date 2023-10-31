﻿// <auto-generated />
using System;
using GeekShopping.OrderAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GeekShopping.OrderAPI.Migrations
{
    [DbContext(typeof(OrderContext))]
    partial class OrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GeekShopping.OrderAPI.Model.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OrderHeaderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("product_name");

                    b.HasKey("Id");

                    b.HasIndex("OrderHeaderId");

                    b.ToTable("order_detail", (string)null);
                });

            modelBuilder.Entity("GeekShopping.OrderAPI.Model.OrderHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("card_number");

                    b.Property<int>("CartTotalItens")
                        .HasColumnType("int")
                        .HasColumnName("total_itens");

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("coupon_code");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("purchase_date");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("discount_amount");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ExpireMonthYear")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("expiry_month_year");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("last_name");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("order_time");

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("phone_number");

                    b.Property<decimal>("PurchaseAmount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("purchase_amount");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("order_header", (string)null);
                });

            modelBuilder.Entity("GeekShopping.OrderAPI.Model.OrderDetail", b =>
                {
                    b.HasOne("GeekShopping.OrderAPI.Model.OrderHeader", "OrderHeader")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderHeaderId")
                        .IsRequired();

                    b.Navigation("OrderHeader");
                });

            modelBuilder.Entity("GeekShopping.OrderAPI.Model.OrderHeader", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
