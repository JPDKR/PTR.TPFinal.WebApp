using AutoMapper;
using PTR.TPFinal.Domain.Auth;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.Repositories.Interfaces;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.DTOs.Responses;
using PTR.TPFinal.Services.Interfaces;

namespace PTR.TPFinal.Services.Services
{
    public class ClientService(IMapper mapper, IClientRepository clientRepository) : IClientService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IClientRepository _clientRepository = clientRepository;

        public async Task<ClientResponseDto> Authenticate(AuthenticationRequestDto request)
        {
            Client? Client = await _clientRepository.ValidateClient(request) ?? throw new Exception("Usuario o contraseña incorrecta.");
            return _mapper.Map<ClientResponseDto>(Client);
        }

        public ClientResponseDto Create(CreateClientRequestDto request)
        {
            Client requestClient = _mapper.Map<Client>(request);
            Client createdClient = _clientRepository.Create(requestClient);
            return _mapper.Map<ClientResponseDto>(createdClient);
        }

        public void Delete(int id)
        {
            _clientRepository.Delete(id);
        }

        public IEnumerable<ClientResponseDto> GetAll()
        {
            var clients = _clientRepository.GetAll();
            return _mapper.Map<IEnumerable<ClientResponseDto>>(clients);
        }

        public ClientResponseDto GetById(int id)
        {
            Client? client = _clientRepository.GetById(id);
            return _mapper.Map<ClientResponseDto>(client);
        }
    }
}
