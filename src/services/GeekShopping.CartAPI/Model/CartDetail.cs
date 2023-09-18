using GeekShopping.CartAPI.Model.Base;

namespace GeekShopping.CartAPI.Model
{
    public class CartDetail : BaseEntity
    {
        public int CartHeaderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public CartHeader CartHeader { get; set; }
        public Product Product { get; set; }
    }
}
