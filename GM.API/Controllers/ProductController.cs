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

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromForm] AddProductDto dto)
        {
            var id = await _iproductServies.AddProductServies(dto);
            return id > 0 ? Ok(id) : BadRequest();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetProducts(int pagenumber, int pagesize)
        {
            var result = await _iproductServies.GetItemsServies(pagenumber,pagesize);
            return result !=null ? Ok(result) : BadRequest();
        }

        [HttpPost("GetByID")]
        public async Task<IActionResult> GetProduct(int productid)
        {
            var result = await _iproductServies.GetProductByIDServies(productid);
            return result != null ? Ok(result) : BadRequest();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateDto Upproduct)
        {
            var result = await _iproductServies.UpdateServies(Upproduct);
            return result != false ? Ok(result) : BadRequest();
        }
    }

}
