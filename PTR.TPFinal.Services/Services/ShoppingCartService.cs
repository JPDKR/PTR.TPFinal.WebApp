using AutoMapper;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.Repositories.Interfaces;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.DTOs.Responses;
using PTR.TPFinal.Services.Interfaces;

namespace PTR.TPFinal.Services.Services
{
    //public class ShoppingCartService(IMapper mapper, IShoppingCartRepository shoppingCartRepository) : IShoppingCartService
    //{
    //    private readonly IMapper _mapper = mapper;
    //    private readonly IShoppingCartRepository _shoppingCartRepository = shoppingCartRepository;

    //    public ShoppingCartResponseDto Create(CreateShoppingCartRequestDto request)
    //    {
    //        ShoppingCart requestShoppingCart = _mapper.Map<ShoppingCart>(request);
    //        ShoppingCart createdShoppingCart = _shoppingCartRepository.Create(requestShoppingCart);
    //        return _mapper.Map<ShoppingCartResponseDto>(createdShoppingCart);
    //    }

    //    public void Delete(int id)
    //    {
    //        _shoppingCartRepository.Delete(id);
    //    }

    //    public IEnumerable<ShoppingCartResponseDto> GetAll()
    //    {
    //        var ShoppingCarts = _shoppingCartRepository.GetAll();
    //        return _mapper.Map<IEnumerable<ShoppingCartResponseDto>>(ShoppingCarts);
    //    }

    //    public ShoppingCartResponseDto GetById(int id)
    //    {
    //        ShoppingCart? ShoppingCart = _shoppingCartRepository.GetById(id);
    //        return _mapper.Map<ShoppingCartResponseDto>(ShoppingCart);
    //    }
    //}
}
