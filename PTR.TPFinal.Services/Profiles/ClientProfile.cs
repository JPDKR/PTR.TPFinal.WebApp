using AutoMapper;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.DTOs.Responses;

namespace PTR.TPFinal.Services.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<CreateClientRequestDto, Client>()
                .ForMember(o => o.Phone, d => d.MapFrom(s => s.PhoneNumber))
                .ReverseMap();
            CreateMap<Client, ClientResponseDto>()
                .ForMember(o => o.PhoneNumber, d => d.MapFrom(s => s.Phone))
                .ReverseMap();
        }
    }
}