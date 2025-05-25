using System.Collections.Generic;
using BuyEasy.Models;
using BuyEasy.Models.DataModel;

namespace BuyEasy.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
    }
}
