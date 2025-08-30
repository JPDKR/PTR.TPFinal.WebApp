using AutoMapper;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.Interfaces;
using PTR.TPFinal.Services.NoSQLRepositories.Interfaces;

namespace PTR.TPFinal.Services.Services
{
    public class ShoppingCartService(IShoppingCartRepository reviewRepository, IMapper mapper) : IShoppingCartService
    {
        private readonly IShoppingCartRepository _reviewRepository = reviewRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<ShoppingCart>> GetAllAsync(string fieldName, string fieldValue)
        {
            return await _reviewRepository.FindAsync(fieldName, fieldValue);
        }

        public async Task<ShoppingCart?> GetByIdAsync(string id)
        {
            return await _reviewRepository.FindByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(ShoppingCart review, string id)
        {
            return await _reviewRepository.UpdateAsync(review, id);
        }

        public async Task DeleteAsync(string id)
        {
            await _reviewRepository.DeleteAsync(id);
        }

        public async Task<decimal> AddToShoppingCartAsync(CreateShoppingCartRequestDto request)
        {
            var newShoppingCart = _mapper.Map<ShoppingCart>(request);
            return await _reviewRepository.AddToShoppingCartAsync(newShoppingCart, request.PartialPrice);
        }
    }
}