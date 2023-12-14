using E_Commerce_App.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_App.ViewComponents
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart ShoppingCart;

        public ShoppingCartSummary(ShoppingCart ShoppingCart)
        {
            this.ShoppingCart = ShoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var count = ShoppingCart.GetShoppingCartItems().Count();
            return View(count);
        }
    }
}
