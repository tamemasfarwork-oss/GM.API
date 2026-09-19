using AutoFixture;
using Bogus;
using GM.BLL.DTOs.SubDtos;
using GM.BLL.DTOs.UserDto;
using GM.BLL.Interfaces;
using GM.DAL.Domain;
using Microsoft.AspNetCore.Mvc;
namespace GM.API.Controllers
{
    public class SubscriptionController : Controller
    {

        readonly private ISubServies _subServies;
        public SubscriptionController( ISubServies subServies)
        {
            _subServies = subServies;
        }
        [HttpPost("CreateSub")]
        public async Task<IActionResult> CreateSub(SubDto subDtoFaker)
        {

            //var playerFaker = new Faker<Player>()
            //.RuleFor(p => p.FirstName, f => f.Name.FirstName())
            //.RuleFor(p => p.LastName, f => f.Name.LastName())
            //.RuleFor(p => p.Phone, f => f.Phone.PhoneNumber("079#######"))
            //.RuleFor(p => p.Email, f => f.Internet.Email())
            //.RuleFor(p => p.DateJoin, f => DateOnly.FromDateTime(f.Date.Past(2)))
            //.RuleFor(p => p.Type, f => f.PickRandom("Gym", "Swimming", "Fitness", "Boxing"))
            //.RuleFor(p => p.Active, f => f.PickRandom(0, 1))
            //.RuleFor(p => p.CreateBy, f => f.Name.FullName())
            //.RuleFor(p => p.Subs, f => new List<Sub>()); // ترك قائمة الإشتراكات فارغة لتجنب الدوران اللانهائي

            //// 2. إعداد Faker الخاص بالـ SubDto
            //var subDtoFaker = new Faker<SubDto>()
            //    // تم تجاهل SunId تماماً (لن يُطلب أو يتولد)
            //    .RuleFor(s => s.DateSub, f => DateOnly.FromDateTime(f.Date.Recent(30)))
            //    .RuleFor(s => s.DateEnd, (f, s) => s.DateSub.AddMonths(1)) // جعل تاريخ الانتهاء بعد شهر من البداية
            //    .RuleFor(s => s.PaymentMethod, f => f.PickRandom("Cash", "Visa", "MasterCard", "Apple Pay"))
            //    .RuleFor(s => s.Active, f => f.PickRandom(0, 1))
            //    .RuleFor(s => s.Status, f => f.PickRandom("Active", "Pending", "Expired"))
            //    .RuleFor(s => s.CreateBy, f => f.Name.FullName())
            //    .RuleFor(s => s.TypeSubId, f => f.Random.Number(1, 1))
            //    .RuleFor(s => s.BranchesId, f => f.Random.Number(1, 1))
            //    .RuleFor(s => s.Price, f => f.Finance.Amount(50, 300))
            //    // توليد كائن Player كامل داخل SubDto
            //    .RuleFor(s => s.Player, f => playerFaker.Generate());
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

            return result != null ? Ok(result) :BadRequest() ;
        }
    }
}
