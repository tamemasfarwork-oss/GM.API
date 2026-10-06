using AutoFixture;
using Bogus;
using GM.BLL.DTOs.SubDtos;
using GM.BLL.DTOs.UserDto;
using GM.BLL.Interfaces;
using GM.DAL.Domin;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> SubUntilEx7days()
        {
            var result = await _subServies.SubscriptionsRemaining7DaysToEXServies(7);
            return result != null ? Ok(result) : BadRequest();

        }
        [HttpGet("GetActiveSub")]
        public async Task<IActionResult> GetActiveSub()
        {
            var result = await _subServies.GetActiveSubsServies();
            return result >=0 ? Ok(result) : BadRequest();

        }
        [HttpGet("Revenues")]
        public  async Task<IActionResult> Revenues()
        {

            var result = await _subServies.RevenuesServies();
            return result >= 0 ? Ok(result) : BadRequest();
        }
        [HttpGet("RevenueLast6Months")]
        public async Task<ActionResult<List<MonthRevenueDto>>> RevenueLast6Months()
        {
            var result = await _subServies.GetRevenueLast6MonthsServies();
            return Ok(result);
        }

        [HttpGet("SubEX")]
        public async Task<ActionResult> SubEX()
        {
            var result = await _subServies.SubscriptionsExServies();
            return Ok(result);
        }

        [HttpPost("renewsub")]
       
        public async Task<ActionResult> renewsub(RefrechSub refrechSub)
        {
            var result = await _subServies.RefrechSubServies(refrechSub);
            return Ok(result);
        }

    }
}
