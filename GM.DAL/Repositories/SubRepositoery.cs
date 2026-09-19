using GM.DAL.Data;
using GM.DAL.Domain;
using GM.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DAL.Repositories
{
    public class SubRepositoery:ISubRepository
    {
        readonly private AppDbContext _context;

        public SubRepositoery(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
   public   async  Task<bool> AddSub(Sub sub)
        {

            var SubAdd =  await _context.AddAsync(sub);
            var result = await _context.SaveChangesAsync();

            return   result>0;

        }

        public  async Task<List<Sub>> GetLastThreeSub()
        {
            return await _context.Subs
               .Include(s => s.Player)
               .Include(s => s.Branches)
               .Include(s => s.TypeSub)
               .OrderByDescending(s => s.SunId)
               .Take(3)
               .AsNoTracking() // لتسريع الاستعلام لأنه للقراءة فقط
               .ToListAsync();
        }
    }
}
