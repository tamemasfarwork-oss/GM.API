using GM.BLL.DTOs.ProductDto;
using GM.BLL.Interfaces;
using GM.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace GM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        readonly private IproductServies _iproductServies;
        public ProductController(IproductServies iproductServies) => _iproductServies = iproductServies;

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] AddProductDto dto)
        {
            var id = await _iproductServies.AddProductServies(dto);
            return id > 0 ? Ok(id) : BadRequest();
        }
    }
}
