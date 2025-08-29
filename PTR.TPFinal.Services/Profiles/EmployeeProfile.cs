using AutoMapper;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.DTOs.Responses;

namespace PTR.TPFinal.Services.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, CreateEmployeeRequestDto>()
                .ForMember(o => o.AreaId, opt => opt.MapFrom(src => src.Area.Id))
                .ReverseMap();
            CreateMap<Employee, EmployeeResponseDto>()
                .ReverseMap();
        }
    }
}
