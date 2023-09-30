namespace GeekShopping.CouponAPI.Model
{
    public class Coupon 
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
