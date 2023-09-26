﻿namespace GeekShopping.Web.Models
{
    public class CartDetailViewModel
    {
        public int Id { get; set; }
        public int CartHeaderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public ProductViewModel Product { get; set; }

        public decimal Ammount()
        {
            return (Product.Price * Count);
        }
    }
}
