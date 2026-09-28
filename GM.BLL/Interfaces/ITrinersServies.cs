using GM.BLL.DTOs.TrainersDto;
using GM.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Interfaces
{
    public interface ITrinersServies
    {
        public Task<List<TrianerDtos>> GetAllTriner(int pagenumber, int pagesiaze);
        public Task<List<TrinerLockupdto>> SerchBynameServies(string? searchTerm);

    }
}
