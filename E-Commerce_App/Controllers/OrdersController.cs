﻿using E_Commerce_App.Data.Cart;
using E_Commerce_App.Repository;
using E_Commerce_App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Reflection;
using System.Security.Claims;

namespace E_Commerce_App.Controllers
{
    
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IMovieRepository MovieRepository;

        private readonly ShoppingCart ShoppingCart;
        private readonly IOrderRepository OrderRepository;

        public OrdersController(IMovieRepository MovieRepository , ShoppingCart ShoppingCart , IOrderRepository OrderRepository)
        {
            this.ShoppingCart = ShoppingCart;
            this.OrderRepository = OrderRepository;
            this.MovieRepository = MovieRepository;
        }

        public async Task<IActionResult> ListAllOrders()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = await OrderRepository.GetOrdersByUserIdAndRoleAsync(userId , userRole);

            return View(orders);
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

        public async Task<IActionResult> CompleteOrder()
        {
            var items = ShoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await OrderRepository.StoreOrderAsync(items, userId, userEmailAddress);
            await ShoppingCart.ClearShoppingCartAsync();

            return View();
        }

    }


}
