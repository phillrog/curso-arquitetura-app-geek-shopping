namespace GeekShopping.CartAPI.Data.ValueObjects
{
    public class CartHeaderVO 
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string? CouponCode { get; set; }
    }
}
