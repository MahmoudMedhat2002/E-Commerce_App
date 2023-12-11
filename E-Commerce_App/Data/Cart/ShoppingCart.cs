using E_Commerce_App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace E_Commerce_App.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext context { get; set; }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            this.context = context;
        }

        public void AddItemToCart(Movie movie)
        {
            var shoppingcartitem = context.ShoppingCartItems.FirstOrDefault(n => n.ShoppingCartId == ShoppingCartId && n.Movie.Id == movie.Id);
            if (shoppingcartitem == null)
            {
                ShoppingCartItem sci = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };

                context.ShoppingCartItems.Add(sci);
            }
            else
            {
                shoppingcartitem.Amount++;
            }
            context.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingcartitem = context.ShoppingCartItems.FirstOrDefault(n => n.ShoppingCartId == ShoppingCartId && n.Movie.Id == movie.Id);
            if (shoppingcartitem != null)
            {
                if(shoppingcartitem.Amount > 1)
                {
                    shoppingcartitem.Amount--;
                }
                else
                {
                    context.ShoppingCartItems.Remove(shoppingcartitem);
                }
            }
            context.SaveChanges();
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(s => s.Movie).ToList());
        }

        public double GetTotal()
        {
            var total = context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Movie.Price * n.Amount).Sum();
            return total;
        }
    }
}
