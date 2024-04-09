namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SaleOrderHeaderRepository : ISaleOrderHeaderRepository
    {
        private readonly AdvWorksDbContext _context;
        public SaleOrderHeaderRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateSaleOrderHeader(SalesOrderHeader saleOrderHeader)
        {

            await _context.AddAsync(saleOrderHeader);

            int result = await _context.SaveChangesAsync();


            return result;
        }

        public async Task<int> DeleteSaleOrderHeader(SalesOrderHeader saleOrderHeader)
        {
            _context.Remove(saleOrderHeader);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SalesOrderHeader>> GetAll(int pageNumber, int pageSize)
        {
            return await _context.SalesOrderHeaders
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<SalesOrderHeader?> GetSaleOrderHeaderById(int id)
        {
            return await _context.SalesOrderHeaders
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.SalesOrderId == id);
        }

        public async Task<int> UpdateSaleOrderHeader(SalesOrderHeader saleOrderHeader)
        {
            _context.Update(saleOrderHeader);

            return await _context.SaveChangesAsync();
        }
    }
}