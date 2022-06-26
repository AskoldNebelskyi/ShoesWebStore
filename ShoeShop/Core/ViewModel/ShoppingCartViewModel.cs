using ShoeShop.Core.Interfaces;

namespace ShoeShop.Core.ViewModel
{
    public class ShoppingCartViewModel
    {
        public IShoppingCartService ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        public int ShoppingCartItemsTotal { get; set; }
    }
}
