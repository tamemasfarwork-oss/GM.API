using GM.BLL.DTOs.TrainersDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Interfaces
{
    public interface IPrivateTrainServies
    {
        Task<int> addServies(addDto addDto);
    }
}
