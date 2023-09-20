namespace GeekShopping.Web.Models
{
    public class CartHeaderViewModel 
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }

        public ICollection<CartDetailViewModel> CartDetails { get; set; }
    }
}
