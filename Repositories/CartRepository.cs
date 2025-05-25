using System.Collections.Generic;
using System.Linq;
using BuyEasy.Models;
using BuyEasy.Models.DataModel;
using Microsoft.EntityFrameworkCore;

namespace BuyEasy.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _dbContext;

        public CartRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Cart> GetAll()
        {
            return _dbContext.Carts.Include(c => c.Product).ToList();
        }

        public void Add(int productId, int quantity)
        {
            var cartItem = new Cart { ProductId = productId, Quantity = quantity };
            _dbContext.Carts.Add(cartItem);
            _dbContext.SaveChanges();
        }
    }
}
