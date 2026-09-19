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
        public SubServies(ISubRepository subRepository)
        {
            _subRepository = subRepository;
        }
        public async Task<bool> AddSubSubServies(SubDto subDto)
        {
            var sub = new Sub
            {
                Player = new Player
                {
                    FirstName = subDto.Player.FirstName,
                    Active = 1,
                    DateJoin = DateOnly.FromDateTime(DateTime.Now),
                    LastName = subDto.Player.LastName,
                    Phone = subDto.Player.Phone,
                    CreateBy = "ahmed",
                    Type = subDto.Player.Type


                },
                Active = 1,
                BranchesId = subDto.BranchesId,
                CreateBy = subDto.CreateBy,
                Status = subDto.Status,
                DateEnd = subDto.DateEnd,
                DateSub = DateOnly.FromDateTime(DateTime.Now),
                PaymentMethod = subDto.PaymentMethod,
                TypeSubId = subDto.TypeSubId,
                Price = subDto.Price,

            };

            return await _subRepository.AddSub(sub);
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
    }
}
