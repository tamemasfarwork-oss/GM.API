using GM.BLL.DTOs.PlayerDto;
using GM.BLL.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GM.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private IPlayerService _PlayerService;// interfaceهون بينفذ هاد لمن  يوصل طلب لعندي ليه عملت انا وعذبت حالي
                                              //    مشان اقلل الاعتماديه واتعامل بشكل مجرد تمام مع الطبقة يلي بل بزنس يعني مشان احقق مبادئ ال soild Dبتحديد 
                                              //PROGRAM.CS واعدل عليه  لو انا حاطه ومستخدمه بل وكنتولر عطول هيك رح ارجع اعيد كلشي واتاكد منه من اول اما لو من اول مخليه مجرد انا بس رح اروح ل PALYER  وعملت نفس الحركه  بل بزنس مع الداتا اكسيس لاير  فرضا انا قررت  اغير كلاس ال 
                                              //وبعدل عل builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
                                                //وهيك بكل بساطه بيتعدل وانا مطمن 
        public PlayersController(IPlayerService playerService)
        {
            _PlayerService = playerService;
        }

       
        

        [HttpPost("create")]
        public async Task<ActionResult> Create(CreatePalyerDto createplayerDto)
        {
            var playerid = await _PlayerService.Create(createplayerDto);

            if (playerid < 0)
            {
                return BadRequest("Failed to create player.");
            }

            return Ok(playerid);
        }
        [HttpPut("Updateplayer")]
        public async Task<ActionResult> UpdatePlayer(UpdatePlayerDto updateplayerDto)
        {
            var result = await _PlayerService.Update(updateplayerDto);
            if (result) {

                return Ok("Updated succedeed");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("DisActivePlayer")]
        public async Task<IActionResult> Delete(int id) {
            var result = await _PlayerService.DisactivePlayer(id);

            if (result)
            {
                return Ok(" player disactive");
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpGet("GetAllPlayers")]
        public async Task<IActionResult> GetAllPlayers()
        {
           
            var result = await _PlayerService.GetPlayers();
            return result!= null ? Ok(result) : BadRequest();
        }
    }
}
