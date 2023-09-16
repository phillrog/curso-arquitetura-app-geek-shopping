namespace GeekShopping.Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }

        public string SubstringName() => Name.Length < 24 ? Name : $"{Name.Substring(0, 21)} ...";
        public string SubstringDescription() => Description.Length < 355 ? Name : $"{Name.Substring(0, 352)} ...";
    }
}
