using System.Collections.Generic;
using System.Linq;
using BuyEasy.Models;
using BuyEasy.Models.DataModel;

namespace BuyEasy.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAll() => _dbContext.Products.ToList();
        public Product GetById(int id) => _dbContext.Products.Find(id);
    }
}
