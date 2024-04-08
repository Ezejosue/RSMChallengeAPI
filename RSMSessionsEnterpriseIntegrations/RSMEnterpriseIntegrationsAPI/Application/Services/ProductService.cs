namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository repository)
        {
            _productRepository = repository;
        }

        public async Task<int> UpdateProduct(UpdateProductDto productDto)
        {
            if (productDto is null)
            {
                throw new BadRequestException("Product is null.");
            }
            var product = await ValidateProductExistence(productDto.ProductId);
            product.Name = productDto.Name;
            product.ProductNumber = productDto.ProductNumber;
            product.Color = productDto.Color;
            product.SafetyStockLevel = productDto.SafetyStockLevel;
            product.ReorderPoint = productDto.ReorderPoint;
            product.StandardCost = productDto.StandardCost;
            product.ListPrice = productDto.ListPrice;
            product.DaysToManufacture = productDto.DaysToManufacture;
            return await _productRepository.UpdateProduct(product);
        }

        public async Task<int> CreateProduct(CreateProductDto productDto)
        {
            if (productDto is null)
            {
                throw new BadRequestException("Product is null.");
            }
            Product product = new()
            {
                Name = productDto.Name,
                ProductNumber = productDto.ProductNumber,
                Color = productDto.Color,
                SafetyStockLevel = productDto.SafetyStockLevel,
                ReorderPoint = productDto.ReorderPoint,
                StandardCost = productDto.StandardCost,
                ListPrice = productDto.ListPrice,
                DaysToManufacture = productDto.DaysToManufacture,
            };
            return await _productRepository.CreateProduct(product);
        }

        public async Task<int> DeleteProduct(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("ProductId is not valid.");
            }
            var product = await ValidateProductExistence(id);
            return await _productRepository.DeleteProduct(product);
        }

        public async Task<IEnumerable<GetProductDto>> GetAll()
        {
            var products = await _productRepository.GetAllProducts();
            List<GetProductDto> ProductsDto = [];
            foreach (var product in products)
            {
                GetProductDto dto = new GetProductDto()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    ProductNumber = product.ProductNumber,
                    Color = product.Color,
                    SafetyStockLevel = product.SafetyStockLevel,
                    StandardCost = product.StandardCost,
                    ListPrice = product.ListPrice,
                };
                ProductsDto.Add(dto);

            }


            return ProductsDto;
        }

        public async Task<GetProductDto?> GetProductById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("ProductId is not valid.");
            }
            var product = await ValidateProductExistence(id);
            GetProductDto dto = new()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                ProductNumber = product.ProductNumber,
                Color = product.Color,
                SafetyStockLevel = product.SafetyStockLevel,
                StandardCost = product.StandardCost,
                ListPrice = product.ListPrice,
            };

            return dto;
        }

        private async Task<Product> ValidateProductExistence(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product is null)
            {
                throw new NotFoundException("Product not found.");
            }

            return product;
        }
    }
}