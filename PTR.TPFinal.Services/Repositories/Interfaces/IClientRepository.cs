using PTR.TPFinal.Domain.Auth;
using PTR.TPFinal.Domain.Models;

namespace PTR.TPFinal.Services.Repositories.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        bool CheckIfClientExists(int userId);
        Task<Client?> ValidateClient(AuthenticationRequestDto authRequestBody);
    }
}
