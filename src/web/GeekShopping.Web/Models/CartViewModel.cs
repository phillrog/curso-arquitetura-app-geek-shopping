namespace GeekShopping.Web.Models
{
    public class CartViewModel
    {
        public CartHeaderViewModel CartHeader { get; set; }
        private IEnumerable<CartDetailViewModel> _cartDetails;

        public IEnumerable<CartDetailViewModel> CartDetails
        {
            get { if (_cartDetails == null) _cartDetails = new List<CartDetailViewModel>(); return _cartDetails; }
            set { _cartDetails = value; }
        }

        public void CalcPurchaseAmount()
        {
            if (CartHeader != null)
            {
                foreach (var detail in CartDetails)
                {
                    CartHeader.PurchaseAmount += detail.Ammount();
                }

                CartHeader.PurchaseAmount -= CartHeader.DiscountAmount;
            }
        }
    }
}
