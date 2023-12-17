using E_Commerce_App.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Repository
{
	public class OrderRepository : IOrderRepository
	{
		private readonly AppDbContext context;

        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId , string userRole)
		{
			var orders = await context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Movie).Include(oi => oi.User).ToListAsync();

			if(userRole != "Admin")
			{
				orders = orders.Where(oi => oi.UserId == userId).ToList();
            }

			return orders;
		}

		public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
		{
			var order = new Order()
			{
				UserId = userId,
				Email = userEmailAddress
			};

			await context.Orders.AddAsync(order);
			await context.SaveChangesAsync();

			foreach (var item in items)
			{
				var OrderItem = new OrderItem()
				{
					Amount = item.Amount,
					MovieId = item.Movie.Id,
					OrderId = order.Id,
					Price = item.Movie.Price
				};
				await context.OrderItems.AddAsync(OrderItem);
			}

			await context.SaveChangesAsync();
		}
	}
}
