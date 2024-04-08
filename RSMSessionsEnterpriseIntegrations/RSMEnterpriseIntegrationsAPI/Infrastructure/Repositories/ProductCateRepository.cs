namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductCateRepository : IProductCateRepository
    {
        private readonly AdvWorksDbContext _context;
        public ProductCateRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateProductCate(ProductCategory productCate)
        {
            await _context.AddAsync(productCate);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteProductCate(ProductCategory productCate)
        {
            _context.Remove(productCate);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetAllProductCate()
        {
            return await _context.Set<ProductCategory>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ProductCategory?> GetProductCateById(int id)
        {
            return await _context.ProductCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductCategoryId == id);
        }

        public async Task<int> UpdateProductCate(ProductCategory productCate)
        {
            _context.Update(productCate);

            return await _context.SaveChangesAsync();
        }
    }
}