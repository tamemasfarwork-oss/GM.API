using GM.BLL.DTOs.TypeDto;
using GM.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
   
    public class TypeSubController : Controller
    {
        readonly private ITypeSub _typesub;





       
        public TypeSubController(ITypeSub typesub)
        {
            _typesub = typesub;
        }


        [HttpPut("UpdateTypeOfSub")]
        public async Task<IActionResult> UpdateTypeOfSub(TypeSubAddDto typeSubAddDto)
        {
            var result = await _typesub.UpdateTypeSubServies(typeSubAddDto);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("AddTypeOfSub")]
        public async Task<IActionResult> AddTypeOfSub(TypeSubAddDto typeSubAddDto)
        {
            var result = await _typesub.AddTypeSubServies(typeSubAddDto);
            if (result > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
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
