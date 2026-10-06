using GM.BLL.DTOs.SubDtos;
using GM.BLL.Interfaces;
using GM.DAL.Domin;
using GM.DAL.Interfaces;
using GM.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Services
{
    public class SubServies : ISubServies
    {

        readonly private ISubRepository _subRepository;
        readonly private ITypeSub _typesub;
        public SubServies(ISubRepository subRepository,ITypeSub typeSub)
        {
            _subRepository = subRepository;
            _typesub = typeSub;
        }
        public async Task<bool> AddSubSubServies(SubDto subDto)
        {
            var typesub =  await _typesub.FindeAsync(subDto.TypeSubId);
            var today = DateOnly.FromDateTime(DateTime.Now);
            var sub = new Sub
            {
              
                Active = 1,
                BranchesId = subDto.BranchesId,
                CreateBy ="tamim",
                //subDto.CreateBy,
                Status = "Active",
                DateEnd = today.AddMonths(typesub.DurationMonths),
                DateSub = DateOnly.FromDateTime(DateTime.Now),
                PaymentMethod = subDto.PaymentMethod,
                TypeSubId = subDto.TypeSubId,
                Price = typesub.Price,
                PlayerId=subDto.PlayerId

            };

            return await _subRepository.AddSub(sub);
        }

        public  async Task<int> GetActiveSubsServies()
        {
            var result = await  _subRepository.GetActiveSubs();

            return result >= 0 ? result : 0;
        }

        public async Task<List<SubGetAll>> GetAllSubs(int pagenumber,int pagesize)
        {
            return await _subRepository.GetSubscriptions(s => new SubGetAll
            {
                subid = s.SunId,
                startsub=s.DateSub,
                branchname=s.Branches.BranchName,
                price=s.TypeSub.Price,
                fullname=s.Player.FirstName+' '+s.Player.LastName,
                endsub=s.DateEnd,
                status=s.Status


            }, pagenumber, pagesize);
        }

        public async Task<List<SubLastThreeDto>> GetLastThreeSub()
        {
            var subs = await _subRepository.GetLastThreeSub();
            var result = subs.Select(s => new SubLastThreeDto
            {
                SubId = s.SunId,
                DateSub = s.DateSub,
                DateEnd = s.DateEnd,
                Price = s.Price,
                Status = s.Status,
                PlayerId = s.PlayerId,
                PlayerName = s.Player.FirstName,
                BranchName = s.Branches.BranchName,
                TypeName = s.TypeSub.TimeSpan
            }).ToList();

            return result;
        }

        public async Task<decimal> RevenuesServies()
        {


            return await _subRepository.Revenues();
        }

        public  async Task<List<SubscriptionsRemaining7DaysToEXDto>> SubscriptionsRemaining7DaysToEXServies(int days=7)
        {
            return await _subRepository.SubscriptionsRemaining7DaysToEX(s => new SubscriptionsRemaining7DaysToEXDto
            {
                Status = s.Status,
                DateSub = s.DateSub,
                DateEnd=s.DateEnd,
                Fullname=s.Player.FirstName+' '+s.Player.LastName,
                BranchName=s.Branches.BranchName,
                CreateBy=s.CreateBy,
                Price=s.Price
                
               

            },days);

        }
        public async Task<List<MonthRevenueDto>> GetRevenueLast6MonthsServies()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var start = new DateOnly(today.Year, today.Month, 1).AddMonths(-5);

            var data = await _subRepository.GetRevenueByMonthAsync(start);

            return Enumerable.Range(0, 6)
                .Select(i => start.AddMonths(i))
                .Select(d => new MonthRevenueDto
                {
                    Year = d.Year,
                    Month = d.Month,
                    Total = data.FirstOrDefault(x => x.Year == d.Year && x.Month == d.Month)?.Total ?? 0
                })
                .ToList();
        }

        public async Task<List<SubEXDto>> SubscriptionsExServies()
        {
            var result = await _subRepository.SubscriptionsEx(s => new SubEXDto
            {
                subid = s.SunId,
                dateend = s.DateEnd,
                nameplayer = s.Player.FirstName + ' ' + s.Player.LastName
            });
            return result;
        }

        public async Task<bool> RefrechSubServies(RefrechSub refrechSub)
        {
            var old = await _subRepository.GetSubbyid(refrechSub.OldSubId);
            if (old == null)
                throw new Exception("Old subscription not found.");

            if (old.Status == "Expired")
                throw new Exception("This subscription was already renewed.");   // يمنع التجديد المزدوج

            var typesub = await _typesub.FindeAsync(refrechSub.TypeSubId);
            if (typesub == null)
                throw new Exception("Subscription type not found.");

            var today = DateOnly.FromDateTime(DateTime.Today);

            // DateOnly عادي: إما ما أرسله العميل، أو اليوم التالي لنهاية القديم (إن ما زال ساري)، أو اليوم
            DateOnly start = refrechSub.StartDate
                             ?? (old.DateEnd >= today ? old.DateEnd.AddDays(1) : today);

            var newSub = new Sub
            {
                PlayerId = old.PlayerId,
                TypeSubId = typesub.TypeSubId,
                DateSub = start,
                PaymentMethod = refrechSub.paymentmethod,
                CreateBy=refrechSub.createdby,
                Price = typesub.Price,
                DateEnd = start.AddMonths(typesub.DurationMonths),
                Status = "Active",
                BranchesId= refrechSub.BranchesId ?? old.BranchesId,
                   Active=1,
                   

                // ClubId يُختم تلقائياً من التوكن
            };

            old.Status = "Expired";  
            old.Active=0;
            // متتبَّع، فيُحفظ مع الإضافة في نفس SaveChanges

            return await _subRepository.AddSub(newSub);
        }
    }
}
