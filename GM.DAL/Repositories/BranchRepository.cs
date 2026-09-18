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
    public class BranchRepository :IBranchRepository
    {
        readonly private  AppDbContext _context;
        public BranchRepository (AppDbContext context)
        {
            _context = context;
        }
     public   async Task<List<Branch>> GetBrnaches()
        {
            
            var  branches = await _context
                .Branches
                .AsNoTracking()
                .ToListAsync();
            if (branches != null)
                return branches;
            else
                return null;

        }

    }
}
