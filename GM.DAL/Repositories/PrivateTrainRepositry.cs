using GM.DAL.Data;
using GM.DAL.Domin;
using GM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DAL.Repositories
{
    public class PrivateTrainRepositry : IPrivateTrainRepository
    {
        private readonly AppDbContext _context;
         public PrivateTrainRepositry(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<int> AddPrivateTrain(Privatetrain privatetrain)
        {
        
           await _context.Privatetrains.AddAsync(privatetrain);
            await _context.SaveChangesAsync();
            return privatetrain.PrivateTrainId;   // الـ id اللي ولّدته القاعدة
        
    }
    }
}
