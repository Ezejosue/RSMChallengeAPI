namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;

    public interface IProductCateService
    {
        Task<GetProductCateDto?> GetProductCateById(int id);
        Task<IEnumerable<GetProductCateDto>> GetAll();
        Task<int> CreateProductCate(CreateProductCateDto productCateDto);
        Task<int> UpdateProductCate(UpdateProductCateDto productCateDto);
        Task<int> DeleteProductCate(int id);
    }
}