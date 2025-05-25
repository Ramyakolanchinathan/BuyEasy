using System.Collections.Generic;
using BuyEasy.Models;

namespace BuyEasy.Services
{
    public interface ICartService
    {
        List<CartViewModel> GetCartItems();
        void AddToCart(int productId, int quantity);
    }
}
