using PTR.TPFinal.Domain.Auth;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.DTOs.Responses;

namespace PTR.TPFinal.Services.Interfaces
{
    public interface IClientService
    {
        IEnumerable<ClientResponseDto> GetAll();
        ClientResponseDto GetById(int id);
        ClientResponseDto Create(CreateClientRequestDto request);
        Task<ClientResponseDto> Authenticate(AuthenticationRequestDto request);
        void Delete(int id);
    }
}