using GM.BLL.DTOs.PlayerDto;
using GM.BLL.DTOs.TrainersDto;
using GM.BLL.Interfaces;
using GM.DAL.Interfaces;
using GM.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Services
{
    public class TrinersServies : ITrinersServies
    {
        private readonly ITreainersRepository _treainersRepository;

       public    TrinersServies(ITreainersRepository treainersRepository)
        {
            _treainersRepository = treainersRepository;
        }
        public  async Task<List<TrianerDtos>> GetAllTriner(int pagenumber, int pagesiaze)
        {
            var result = await  _treainersRepository.GetAllTriner(pagenumber,pagesiaze,
                s=>new TrianerDtos
                {
                    TrainersId=s.TrainersId,
                    fullname=s.FullName,
                    SalaryPerMonth=s.SalaryPerMonth,
                    DateWork=s.DateWork,
                    CreateBy=s.CreateBy,
                    Specialization=s.Specialization,
                    IsActive=s.IsActive,
                    PricePerMonthPrivateTrain=s.PricePerMonthPrivateTrain
                    
                });

            return result;
        }

       


        public async Task<List<TrinerLockupdto>> SerchBynameServies(string? searchTerm)
        {
            var term = searchTerm?.Trim();

            // نبعت للـ DataAccess الشكل اللي بدنا ياه مباشرة: DTO فيه الرقم والاسم
            return await _treainersRepository.SearchByName(term, 10, p => new TrinerLockupdto
            {
                Trinerid = p.TrainersId,
                Fullname = p.FullName
            });
        }
    }
}
