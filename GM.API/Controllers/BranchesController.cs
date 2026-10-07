using GM.BLL.DTOs.BranchDto;
using GM.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GM.API.Controllers
{
    public class BranchesController : Controller
    {

        readonly private IBranchServies _branchServies;
        public BranchesController(IBranchServies branchServies)
        {
            _branchServies = branchServies;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("GetAllBranches")]
        public async Task<IActionResult> GetAllBranches()
        {
            var result = await _branchServies.GetBranches();

            if (result.Count > 0 && result != null)
            {
                return Ok(result);
            }
            else
                return BadRequest();
        }
        [HttpPost("addbranch")]
        public async Task<IActionResult> addbranch([FromBody] branchadddto branchadddto)
        {
            var result = await _branchServies.AddBranch(branchadddto);

            if (result)
            {
                return Ok(result);
            }
            else
                return BadRequest();
        }


    }
}
