﻿namespace GeekShopping.OrderAPI.Model
{
    public class OrderHeader : BaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string? CouponCode { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateTime { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpireMonthYear { get; set; }
        public int CartTotalItens { get; set; }
        public DateTime OrderTime { get; set; }
        public IList<OrderDetail>? OrderDetails { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
