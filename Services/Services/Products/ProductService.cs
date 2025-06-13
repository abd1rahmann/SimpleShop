using AutoMapper;
using BusinessLogicLayer.Repositories.Products;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> CreateProductAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            var created = await _repository.CreateAsync(product);
            return _mapper.Map<ProductDto>(created);
        }

        public async Task<bool> UpdateProductAsync(int id, UpdateProductDto dto)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return false;

            _mapper.Map(dto, product);
            return await _repository.UpdateAsync(product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
