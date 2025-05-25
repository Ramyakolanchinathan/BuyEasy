using System.Collections.Generic;
using AutoMapper;
using BuyEasy.Models;
using BuyEasy.Repositories;

namespace BuyEasy.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var products = _repo.GetAll();
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public ProductViewModel GetProductById(int id)
        {
            var product = _repo.GetById(id);
            return _mapper.Map<ProductViewModel>(product);
        }
    }
}
