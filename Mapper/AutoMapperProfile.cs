using AutoMapper;
using BuyEasy.Models.DataModel;
using BuyEasy.Models.ViewModel;

namespace BuyEasy.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Cart, CartViewModel>().ReverseMap();
        }
    }
}
