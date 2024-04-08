namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    public interface IProductCateRepository
    {
        Task<ProductCategory?> GetProductCateById(int id);
        Task<IEnumerable<ProductCategory>> GetAllProductCate();
        Task<int> CreateProductCate(ProductCategory productCate);
        Task<int> UpdateProductCate(ProductCategory productCate);
        Task<int> DeleteProductCate(ProductCategory productCate);
    }
}