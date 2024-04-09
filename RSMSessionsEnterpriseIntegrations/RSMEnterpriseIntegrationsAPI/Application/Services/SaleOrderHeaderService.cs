namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SaleOrderHeaderService : ISaleOrderHeaderService
    {
        private readonly ISaleOrderHeaderRepository _saleOrderHeaderRepository;
        public SaleOrderHeaderService(ISaleOrderHeaderRepository repository)
        {
            _saleOrderHeaderRepository = repository;
        }

        public async Task<int> UpdateSaleOrderHeader(UpdateSaleOrderHeaderDto saleOrderHeaderDto)
        {
            if (saleOrderHeaderDto is null)
            {
                throw new BadRequestException("Sale Order Header is null.");
            }
            var saleOrderHeader = await ValidateSaleOrderHeaderExistence(saleOrderHeaderDto.SalesOrderId);
            saleOrderHeader.SalesOrderId = saleOrderHeaderDto.SalesOrderId;
            saleOrderHeader.RevisionNumber = saleOrderHeaderDto.RevisionNumber;
            saleOrderHeader.OrderDate = saleOrderHeaderDto.OrderDate;
            saleOrderHeader.DueDate = saleOrderHeaderDto.DueDate;
            saleOrderHeader.SubTotal = saleOrderHeaderDto.SubTotal;
            saleOrderHeader.TaxAmt = saleOrderHeaderDto.TaxAmt;
            saleOrderHeader.Freight = saleOrderHeaderDto.Freight;
            return await _saleOrderHeaderRepository.UpdateSaleOrderHeader(saleOrderHeader);
        }
        public async Task<int> CreateSaleOrderHeader(CreateSaleOrderHeaderDto saleOrderHeaderDto)
        {
            if (saleOrderHeaderDto is null)
            {
                throw new BadRequestException("Sale Order Header is null.");
            }
            SalesOrderHeader saleOrderHeader = new()
            {
                RevisionNumber = saleOrderHeaderDto.RevisionNumber,
                OrderDate = saleOrderHeaderDto.OrderDate,
                DueDate = saleOrderHeaderDto.DueDate,
                CustomerId = saleOrderHeaderDto.CustomerId,
                BillToAddressId = saleOrderHeaderDto.BillToAddressId,
                ShipToAddressId = saleOrderHeaderDto.ShipToAddressId,
                ShipMethodId = saleOrderHeaderDto.ShipMethodId,
                TaxAmt = saleOrderHeaderDto.TaxAmt,
                Freight = saleOrderHeaderDto.Freight,
                SubTotal = saleOrderHeaderDto.SubTotal,
            };
            return await _saleOrderHeaderRepository.CreateSaleOrderHeader(saleOrderHeader);
        }

        public async Task<int> DeleteSaleOrderHeader(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Invalid Sale Order Header Id");
            }
            var saleOrderHeader = await ValidateSaleOrderHeaderExistence(id);
            return await _saleOrderHeaderRepository.DeleteSaleOrderHeader(saleOrderHeader);
        }

        public async Task<IEnumerable<GetSaleOrderHeaderDto>> GetAll(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                throw new BadRequestException("Invalid page number or page size");
            }
            var saleOrderHeaders = await _saleOrderHeaderRepository.GetAll(pageNumber, pageSize);
            List<GetSaleOrderHeaderDto> SalesOrderHeaderDto = [];
            foreach (var saleOrderHeader in saleOrderHeaders)
            {
                GetSaleOrderHeaderDto dto = new()
                {
                    SalesOrderId = saleOrderHeader.SalesOrderId,
                    RevisionNumber = saleOrderHeader.RevisionNumber,
                    OrderDate = saleOrderHeader.OrderDate,
                    DueDate = saleOrderHeader.DueDate,
                    CustomerId = saleOrderHeader.CustomerId,
                    BillToAddressId = saleOrderHeader.BillToAddressId,
                    ShipToAddressId = saleOrderHeader.ShipToAddressId,
                    ShipMethodId = saleOrderHeader.ShipMethodId,
                    SubTotal = saleOrderHeader.SubTotal,
                    TaxAmt = saleOrderHeader.TaxAmt,
                    Freight = saleOrderHeader.Freight,
                };
                SalesOrderHeaderDto.Add(dto);
            }
            return SalesOrderHeaderDto;
        }

        public async Task<GetSaleOrderHeaderDto?> GetSaleOrderHeaderById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Invalid Sale Order Header Id");
            }
            var saleOrderHeader = await ValidateSaleOrderHeaderExistence(id);
            GetSaleOrderHeaderDto dto = new()
            {
                SalesOrderId = saleOrderHeader.SalesOrderId,
                RevisionNumber = saleOrderHeader.RevisionNumber,
                OrderDate = saleOrderHeader.OrderDate,
                DueDate = saleOrderHeader.DueDate,
                CustomerId = saleOrderHeader.CustomerId,
                BillToAddressId = saleOrderHeader.BillToAddressId,
                ShipToAddressId = saleOrderHeader.ShipToAddressId,
                ShipMethodId = saleOrderHeader.ShipMethodId,
                SubTotal = saleOrderHeader.SubTotal,
                TaxAmt = saleOrderHeader.TaxAmt,
                Freight = saleOrderHeader.Freight,
            };
            return dto;
        }

        private async Task<SalesOrderHeader> ValidateSaleOrderHeaderExistence(int id)
        {
            var saleOrderHeader = await _saleOrderHeaderRepository.GetSaleOrderHeaderById(id);
            if (saleOrderHeader is null)
            {
                throw new NotFoundException("Sale Order Header not found.");
            }
            return saleOrderHeader;
        }
    }
}