using System;
using System.Collections.Generic;
using System.Text;
using UESAN.ECOMMERCE.CORE.Core.DTOs;
using UESAN.ECOMMERCE.CORE.Core.Entities;
using UESAN.ECOMMERCE.CORE.Core.Interfaces;

namespace UESAN.ECOMMERCE.CORE.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductListDTO>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            var productsDTO = new List<ProductListDTO>();

            foreach (var product in products)
            {
                var dto = new ProductListDTO();
                dto.Id = product.Id;
                dto.Description = product.Description;
                dto.Price = product.Price ?? 0;
                dto.ImageUrl = product.ImageUrl;
                dto.Stock = product.Stock ?? 0;
                dto.Category = new CategoryListDTO
                {
                    Id = product.Category?.Id ?? 0,
                    Description = product.Category?.Description
                };

                productsDTO.Add(dto);
            }

            return productsDTO;
        }

        public async Task<ProductListDTO> GetProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            var dto = new ProductListDTO();
            dto.Id = product.Id;
            dto.Description = product.Description;
            dto.Price = product.Price ?? 0;
            dto.ImageUrl = product.ImageUrl;
            dto.Stock = product.Stock ?? 0;
            dto.Category = new CategoryListDTO
            {
                Id = product.Category?.Id ?? 0,
                Description = product.Category?.Description
            };

            return dto;
        }

        public async Task<bool> CreateProduct(ProductCreateDTO productCreateDTO)
        {
            var product = new Product();
            product.Description = productCreateDTO.Description;
            product.ImageUrl = productCreateDTO.ImageUrl;
            product.Stock = productCreateDTO.Stock;
            product.Price = productCreateDTO.Price;
            product.Discount = productCreateDTO.Discount;
            product.CategoryId = productCreateDTO.CategoryId;
            product.IsActive = true;

            return await _productRepository.CreateProduct(product);
        }

        public async Task<bool> UpdateProduct(ProductUpdateDTO productUpdateDTO)
        {
            var product = new Product();
            product.Id = productUpdateDTO.Id;
            product.Description = productUpdateDTO.Description;
            product.ImageUrl = productUpdateDTO.ImageUrl;
            product.Stock = productUpdateDTO.Stock;
            product.Price = productUpdateDTO.Price;
            product.Discount = productUpdateDTO.Discount;
            product.CategoryId = productUpdateDTO.CategoryId;

            return await _productRepository.UpdateProduct(product);
        }

        public async Task<bool> DeleteProduct(ProductDeleteDTO productDeleteDTO)
        {
            return await _productRepository.DeleteProduct(productDeleteDTO.Id);
        }
    }
}
