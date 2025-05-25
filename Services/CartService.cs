using System.Collections.Generic;
using AutoMapper;
using BuyEasy.Models;
using BuyEasy.Repositories;

namespace BuyEasy.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repo;
        private readonly IMapper _mapper;
        public CartService(ICartRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public List<CartViewModel> GetCartItems()
        {
            var cartEntities = _repo.GetAll();
            return _mapper.Map<List<CartViewModel>>(cartEntities);
        }

        public void AddToCart(int productId, int quantity) => _repo.Add(productId, quantity);
    }
}
