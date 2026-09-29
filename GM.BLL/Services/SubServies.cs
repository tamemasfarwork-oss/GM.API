using GM.BLL.DTOs.SubDtos;
using GM.BLL.Interfaces;
using GM.DAL.Domain;
using GM.DAL.Interfaces;
using GM.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
                DateEnd = today.AddMonths(1),
                DateSub = DateOnly.FromDateTime(DateTime.Now),
                PaymentMethod = subDto.PaymentMethod,
                TypeSubId = subDto.TypeSubId,
                Price = typesub.Price,
                PlayerId=subDto.PlayerId

            };

            return await _subRepository.AddSub(sub);
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
                endsub=Convert.ToInt32( s.TypeSub.TimeSpan),
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
    }
}
