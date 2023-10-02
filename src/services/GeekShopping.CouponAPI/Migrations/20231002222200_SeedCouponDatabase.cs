using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeekShopping.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedCouponDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "coupon",
                columns: new[] { "Id", "coupon_name", "discount_amount" },
                values: new object[,]
                {
                    { 1, "DIA_DAS_CRIANCAS_40", 40m },
                    { 2, "BLACK_FRIDAY_75", 75m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "coupon",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "coupon",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
