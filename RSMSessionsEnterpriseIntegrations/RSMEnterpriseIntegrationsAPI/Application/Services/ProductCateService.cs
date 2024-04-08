namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;


    public class ProductCateService : IProductCateService
    {
        private readonly IProductCateRepository _productCateRepository;
        public ProductCateService(IProductCateRepository repository)
        {
            _productCateRepository = repository;
        }


        public async Task<int> CreateProductCate(CreateProductCateDto createProductCateDto)
        {
            if (createProductCateDto is null)
            {
                throw new BadRequestException("Product category is null.");
            }
            ProductCategory productCate = new()
            {
                Name = createProductCateDto.Name
            };
            return await _productCateRepository.CreateProductCate(productCate);
        }

        public async Task<int> UpdateProductCate(UpdateProductCateDto updateProductCateDto)
        {
            if (updateProductCateDto is null)
            {
                throw new BadRequestException("Product category is null.");
            }
            var productCate = await ValidateProductCateExistence(updateProductCateDto.ProductCategoryId);
            productCate.Name = updateProductCateDto.Name;
            return await _productCateRepository.UpdateProductCate(productCate);
        }

        public async Task<int> DeleteProductCate(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }
            var productCate = await ValidateProductCateExistence(id);
            return await _productCateRepository.DeleteProductCate(productCate);
        }

        public async Task<IEnumerable<GetProductCateDto>> GetAll()
        {
            var productCates = await _productCateRepository.GetAllProductCate();
            List<GetProductCateDto> productCatesDto = new();

            foreach (var productCate in productCates)
            {
                GetProductCateDto dto = new()
                {
                    ProductCategoryId = productCate.ProductCategoryId,
                    Name = productCate.Name
                };
                productCatesDto.Add(dto);
            }

            return productCatesDto;
        }

        public async Task<GetProductCateDto?> GetProductCateById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }
            var productCate = await ValidateProductCateExistence(id);
            GetProductCateDto dto = new()
            {
                ProductCategoryId = productCate.ProductCategoryId,
                Name = productCate.Name
            };
            return dto;
        }

        private async Task<ProductCategory> ValidateProductCateExistence(int id)
        {
            var productCate = await _productCateRepository.GetProductCateById(id);
            if (productCate is null)
            {
                throw new NotFoundException("Product category not found.");
            }
            return productCate;
        }
    }
}