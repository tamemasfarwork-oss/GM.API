using GM.BLL.DTOs.TrainersDto;
using GM.BLL.Interfaces;
using GM.DAL.Domin;
using GM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Services
{
    public class PrivateTrainServies : IPrivateTrainServies
    {
        private readonly IPrivateTrainRepository _privateTrainRepository;
        public PrivateTrainServies(IPrivateTrainRepository privateTrainRepository)
        {
            _privateTrainRepository = privateTrainRepository;
        }
        public async Task<int> addServies(addDto addDto)
        {
            var result = new Privatetrain
            {
                PlayerId=addDto.PlayerId,
                TrainersId=addDto.TrainerId,
                Status="active",
                PricePerMonth=addDto.PricePerMonth,
                DateStart = DateOnly.FromDateTime(DateTime.Now), // or DateTime.Now if the type is DateTime
                TheClubsShare=addDto.ClubShare,
                

            };
            return await _privateTrainRepository.AddPrivateTrain(result);
        }
    }
}
