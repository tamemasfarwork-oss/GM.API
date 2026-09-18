using GM.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GM.API.Controllers
{
    public class TypeSubController : Controller
    {
        readonly private ITypeSub _typesub;
        public TypeSubController(ITypeSub typesub)
        {
            _typesub = typesub;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetTypeOfSub")]
        public async Task<IActionResult> GetTypeSub()
        {
            var result = await _typesub.ReadTypeSub();

            if (result != null)
            {   
                return Ok(result);
            }
            else
            {

                return BadRequest();
            }
        }
    }
}
