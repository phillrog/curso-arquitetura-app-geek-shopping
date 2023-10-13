namespace GeekShopping.OrderAPI.Model
{
    public class OrderDetail : BaseEntity
    {
        public int OrderHeaderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
