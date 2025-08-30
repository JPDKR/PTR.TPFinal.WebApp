using AutoMapper;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.DTOs.Responses;
using PTR.TPFinal.Services.Interfaces;
using PTR.TPFinal.Services.Repositories.Interfaces;

namespace PTR.TPFinal.Services.Services
{
    public class AreaService(IMapper mapper, IAreaRepository areaRepository) : IAreaService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAreaRepository _areaRepository = areaRepository;

        public AreaResponseDto Create(CreateAreaRequestDto request)
        {
            Area requestArea = _mapper.Map<Area>(request);
            Area createdArea = _areaRepository.Create(requestArea);
            return _mapper.Map<AreaResponseDto>(createdArea);
        }

        public void Delete(int id)
        {
            _areaRepository.Delete(id);
        }

        public IEnumerable<AreaResponseDto> GetAll()
        {
            var Areas = _areaRepository.GetAll();
            return _mapper.Map<IEnumerable<AreaResponseDto>>(Areas);
        }

        public AreaResponseDto GetById(int id)
        {
            Area? Area = _areaRepository.GetById(id);
            return _mapper.Map<AreaResponseDto>(Area);
        }
    }
}