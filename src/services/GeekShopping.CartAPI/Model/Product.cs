﻿namespace GeekShopping.CartAPI.Model
{
    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }

        public ICollection<CartDetail> CartDetails { get; set; }
    }
}
