namespace RSMEnterpriseIntegrationsAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class SaleOrderHeaderController : ControllerBase
    {
        private readonly ISaleOrderHeaderService _service;

        public SaleOrderHeaderController(ISaleOrderHeaderService service)
        {
            _service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateSaleOrderHeaderDto saleOrderHeader)
        {
            return Ok(await _service.CreateSaleOrderHeader(saleOrderHeader));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateSaleOrderHeaderDto saleOrderHeader)
        {
            return Ok(await _service.UpdateSaleOrderHeader(saleOrderHeader));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            return Ok(await _service.GetAll(pageNumber, pageSize));
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            return Ok(await _service.GetSaleOrderHeaderById(id));
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteSaleOrderHeader(id));
        }

    }
}