using E_Commerce_App.Models;

namespace E_Commerce_App.Repository
{
	public interface IOrderRepository
	{
		Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);

		Task<List<Order>> GetOrdersByUserIdAsync(string userId);

	}
}
