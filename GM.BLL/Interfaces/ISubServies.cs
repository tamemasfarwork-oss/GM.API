using GM.BLL.DTOs.SubDtos;
using GM.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Interfaces
{
    public interface ISubServies
    {
        Task<bool> AddSubSubServies(SubDto subDto);

        Task<List<SubLastThreeDto>> GetLastThreeSub();
    }
}
