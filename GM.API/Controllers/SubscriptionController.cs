using AutoFixture;
using Bogus;
using GM.BLL.DTOs.SubDtos;
using GM.BLL.DTOs.UserDto;
using GM.BLL.Interfaces;
using GM.DAL.Domain;
using Microsoft.AspNetCore.Mvc;
namespace GM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionController : Controller
    {

        readonly private ISubServies _subServies;
        public SubscriptionController(ISubServies subServies)
        {
            _subServies = subServies;
        }
        [HttpPost("CreateSub")]
        public async Task<IActionResult> CreateSub([FromBody] SubDto subDtoFaker)
        {


            var result = await _subServies.AddSubSubServies(subDtoFaker);
            if (result == true)
            {
                return Ok();
            }
            else
                return BadRequest();
        }

        [HttpGet("GetLastThreeSub")]
        public async Task<IActionResult> GetLastThreeSub()
        {
            var result = await _subServies.GetLastThreeSub();

            return result != null ? Ok(result) : BadRequest();
        }
        [HttpGet("GetAllSubs")]
        public async Task<IActionResult> GetAllSub(int pagenumber, int pagesize)
        {
            var result = await _subServies.GetAllSubs(pagenumber, pagesize);

            return result != null ? Ok(result) : BadRequest();
        }
        [HttpGet("SubUntilEx7days")]
        public async Task<IActionResult> SubUntilEx7days(int days = 7)
        {
            var result = await _subServies.SubscriptionsRemaining7DaysToEXServies(days);
            return result != null ? Ok(result) : BadRequest();

        }
    }
}
