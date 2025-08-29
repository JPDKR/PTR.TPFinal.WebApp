using Microsoft.EntityFrameworkCore;
using PTR.TPFinal.Domain.Data;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.DTOs.Responses;
using PTR.TPFinal.Services.Repositories.Interfaces;

namespace PTR.TPFinal.Services.Repositories.Implementations
{
    public class AreaRepository(ECommerceApiContext context) : Repository<Area>(context), IAreaRepository
    {
        
    }
}
