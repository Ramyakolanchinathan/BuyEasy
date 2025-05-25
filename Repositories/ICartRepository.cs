using System.Collections.Generic;
using BuyEasy.Models;
using BuyEasy.Models.DataModel;

namespace BuyEasy.Repositories
{
    public interface ICartRepository
    {
        List<Cart> GetAll();
        void Add(int productId, int quantity);
    }
}
