using AutoMapper;
using full_ecommerce.Data.Models;
using full_ecommerce.DTO;

namespace full_ecommerce.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cart, CartDto>().ReverseMap();
        }
    }
}
