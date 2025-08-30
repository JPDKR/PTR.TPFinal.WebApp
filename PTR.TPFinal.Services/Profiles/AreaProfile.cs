using AutoMapper;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.DTOs.Responses;

namespace PTR.TPFinal.Services.Profiles
{
    public class AreaProfile : Profile
    {
        public AreaProfile()
        {
            CreateMap<CreateAreaRequestDto, Area>().ReverseMap();
            CreateMap<Area, AreaResponseDto>().ReverseMap();
        }
    }
}