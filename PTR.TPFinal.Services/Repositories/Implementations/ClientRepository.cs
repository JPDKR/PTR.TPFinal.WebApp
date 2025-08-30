using Microsoft.EntityFrameworkCore;
using PTR.TPFinal.Domain.Auth;
using PTR.TPFinal.Domain.Data;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.Repositories.Interfaces;

namespace PTR.TPFinal.Services.Repositories.Implementations
{
    public class ClientRepository(ECommerceApiContext context) : Repository<Client>(context), IClientRepository
    {
        public bool CheckIfClientExists(int userId)
        {
            return _context.Clients.Any(u => u.Id == userId);
        }

        public async Task<Client?> ValidateClient(AuthenticationRequestDto authRequestBody)
        {
            return await _context.Clients.FirstOrDefaultAsync
                (x => x.ECommerceName == authRequestBody.ECommerceName
                && x.Password == authRequestBody.Password);
        }
    }
}