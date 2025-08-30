using AutoMapper;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.DTOs.Responses;

namespace PTR.TPFinal.Services.Profiles
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<CreateShoppingCartRequestDto, ShoppingCart>()
                .ForMember(o => o.PaymentMethod, opt => opt.MapFrom(src => (int)src.PaymentType))
                .ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartResponseDto>().ReverseMap();
        }
    }
}
