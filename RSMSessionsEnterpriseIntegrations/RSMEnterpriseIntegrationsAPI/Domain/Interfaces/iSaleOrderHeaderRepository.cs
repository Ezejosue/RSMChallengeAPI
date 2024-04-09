namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    using RSMEnterpriseIntegrationsAPI.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISaleOrderHeaderRepository
    {
        Task<SalesOrderHeader?> GetSaleOrderHeaderById(int id);
        Task<IEnumerable<SalesOrderHeader>> GetAll(int pageNumber, int pageSize);
        Task<int> CreateSaleOrderHeader(SalesOrderHeader saleOrderHeader);
        Task<int> UpdateSaleOrderHeader(SalesOrderHeader saleOrderHeader);
        Task<int> DeleteSaleOrderHeader(SalesOrderHeader saleOrderHeader);
    }
}