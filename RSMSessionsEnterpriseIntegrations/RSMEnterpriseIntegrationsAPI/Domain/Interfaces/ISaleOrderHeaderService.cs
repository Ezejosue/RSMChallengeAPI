namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{

    using RSMEnterpriseIntegrationsAPI.Application.DTOs;


    public interface ISaleOrderHeaderService
    {
        Task<GetSaleOrderHeaderDto?> GetSaleOrderHeaderById(int id);
        Task<IEnumerable<GetSaleOrderHeaderDto>> GetAll(int pageNumber, int pageSize);
        Task<int> CreateSaleOrderHeader(CreateSaleOrderHeaderDto saleOrderHeaderDto);
        Task<int> UpdateSaleOrderHeader(UpdateSaleOrderHeaderDto saleOrderHeaderDto);
        Task<int> DeleteSaleOrderHeader(int id);
    }
}