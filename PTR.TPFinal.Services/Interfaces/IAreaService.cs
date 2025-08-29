using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.DTOs.Responses;

namespace PTR.TPFinal.Services.Interfaces
{
    public interface IAreaService
    {
        IEnumerable<AreaResponseDto> GetAll();
        AreaResponseDto GetById(int id);
        AreaResponseDto Create(CreateAreaRequestDto request);
        void Delete(int id);
    }
}
