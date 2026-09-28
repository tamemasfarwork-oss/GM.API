using GM.BLL.Interfaces;
using GM.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace GM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrinerController : Controller
    {
        private readonly ITrinersServies _trinersServies;

    public    TrinerController(ITrinersServies trinersServies)
        {
            _trinersServies = trinersServies;
        }

        [HttpGet("GetAllTriner")]
        public async Task<IActionResult> GetAllTriner([FromQuery] int pagenmuber, [FromQuery]  int pagesize)
        {
            var result =  await _trinersServies.GetAllTriner(pagenmuber, pagesize);
            return result != null ? Ok(result) : BadRequest();
        }
        [HttpGet("Lookup")]
        public async Task<ActionResult> Lookup([FromQuery] string? searchTerm)
        {
            var result = await _trinersServies.SerchBynameServies(searchTerm);
            return Ok(result);
        }
    }
}
