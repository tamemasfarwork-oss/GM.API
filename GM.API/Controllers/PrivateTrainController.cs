using GM.BLL.DTOs.TrainersDto;
using GM.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GM.API.Controllers
{
    public class PrivateTrainController : Controller
    {
        private readonly IPrivateTrainServies _privateTrainServies;
        public PrivateTrainController(IPrivateTrainServies privateTrainServies)
        {
            _privateTrainServies = privateTrainServies;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult>AddPrivate([FromBody]addDto addDto)
        {
            var result = await _privateTrainServies.addServies(addDto);
            return result != null ? Ok(addDto.privid) : BadRequest("ل");
        }
    }
}
