namespace RSMEnterpriseIntegrationsAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductCateController : ControllerBase
    {
        private readonly IProductCateService _service;

        public ProductCateController(IProductCateService service)
        {
            _service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProductCateDto createProductCateDto)
        {
            return Ok(await _service.CreateProductCate(createProductCateDto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductCateDto updateProductCateDto)
        {
            return Ok(await _service.UpdateProductCate(updateProductCateDto));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            return Ok(await _service.GetProductCateById(id));
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteProductCate(id));
        }

    }
}