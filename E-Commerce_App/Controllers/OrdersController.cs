using E_Commerce_App.Data.Cart;
using E_Commerce_App.Repository;
using E_Commerce_App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Reflection;

namespace E_Commerce_App.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMovieRepository MovieRepository;

        private readonly ShoppingCart ShoppingCart;

        public OrdersController(IMovieRepository MovieRepository , ShoppingCart ShoppingCart)
        {
            this.ShoppingCart = ShoppingCart;
            this.MovieRepository = MovieRepository;
        }
        public IActionResult Index()
        {
            var items = ShoppingCart.GetShoppingCartItems();
            ShoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = ShoppingCart,
                Total = ShoppingCart.GetTotal()
            };



            return View(response);
        }

        public async Task<RedirectToActionResult> AddToShoppingCart(int id)
        {
            var movie = await MovieRepository.GetMovieByIdAsync(id);

            if(movie != null)
            {
                ShoppingCart.AddItemToCart(movie);
            }

            return RedirectToAction("Index","Orders");
        }

        public async Task<RedirectToActionResult> RemoveItemFromShoppingCart(int id)
        {
            var movie = await MovieRepository.GetMovieByIdAsync(id);

            if (movie != null)
            {
                ShoppingCart.RemoveItemFromCart(movie);
            }

            return RedirectToAction("Index", "Orders");
        }


    }


}
