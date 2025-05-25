using System.Collections.Generic;
using BuyEasy.Models;

namespace BuyEasy.Services
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetAllProducts();
        ProductViewModel GetProductById(int id);
    }
}
