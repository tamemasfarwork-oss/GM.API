using GM.DAL.Data;
using GM.DAL.Domin;
using GM.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GM.DAL.Repositories
{
    public class BranchRepository :IBranchRepository
    {
        readonly private  AppDbContext _context;
        private readonly ILogger<BranchRepository> _logger;
        public BranchRepository (AppDbContext context, ILogger<BranchRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AddBranch(Branch branch)
        {
            var result =  await _context.Branches.AddAsync(branch);
            await _context.SaveChangesAsync();
            return true;
        }

        public   async Task<List<Branch>> GetBrnaches()
        {
            _logger.LogInformation(" جلب الفروع "); 
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
