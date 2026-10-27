using GM.BLL.DTOs.SaleDto;
using GM.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GM.API.Controllers

{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SalesController : Controller
    {

        private readonly ISaleServies _saleServies;

        public SalesController(ISaleServies saleServies)
        {
            _saleServies = saleServies;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleDto dto)
        {
           
            try
            {
                var invoiceId = await _saleServies.CreateSaleServies(dto);
                return Ok(new { invoiceId });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

     
    }
}
