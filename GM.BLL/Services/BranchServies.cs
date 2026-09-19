using GM.BLL.DTOs.BranchDto;
using GM.BLL.Interfaces;
using GM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Services
{
    public class BranchServies:IBranchServies
    {
        readonly private IBranchRepository _branchRepository;
        public BranchServies(IBranchRepository branchRepository)
        {
                _branchRepository = branchRepository;
        }

    public async    Task<List<BranchDto>> GetBranches()
        {
            var Branches =  await _branchRepository.GetBrnaches();

            var result = Branches.Select(s => new BranchDto
            {
                BranchesId = s.BranchesId,
                BranchAddres = s.BranchAddres,
                BranchName = s.BranchName,

            })
                .ToList();
            if (result.Count > 0)
                return result;
            else
                return null;

            

           
        }
    }
}
