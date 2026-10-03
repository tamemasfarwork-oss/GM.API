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
    public class AuthRepositery : IAuthRepositery
    {

        private readonly AppDbContext _context;   // اسم الـ DbContext عندك
        public AuthRepositery(AppDbContext context) => _context = context;
        public Task<User?> GetByEmailAsync(string email) =>
        _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
    }
}
