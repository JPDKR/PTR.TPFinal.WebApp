using AutoMapper;
using PTR.TPFinal.Domain.Models;
using PTR.TPFinal.Services.Repositories.Interfaces;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.DTOs.Responses;
using PTR.TPFinal.Services.Interfaces;

namespace PTR.TPFinal.Services.Services
{
    public class ProductService(IMapper mapper, IProductRepository productRepository) : IProductService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IProductRepository _productRepository = productRepository;

        public ProductResponseDto Create(CreateProductRequestDto request)
        {
            Product requestProduct = _mapper.Map<Product>(request);
            Product createdProduct = _productRepository.CreateProduct(requestProduct);
            return _mapper.Map<ProductResponseDto>(createdProduct);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public IEnumerable<ProductResponseDto> GetAll()
        {
            var Products = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductResponseDto>>(Products);
        }

        public ProductResponseDto GetById(int id)
        {
            Product? Product = _productRepository.GetById(id);
            return _mapper.Map<ProductResponseDto>(Product);
        }
    }
}
