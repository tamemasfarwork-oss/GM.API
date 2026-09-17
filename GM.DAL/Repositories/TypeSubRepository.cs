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
    public class TypeSubRepository:ITypeSubRepository
    {

        readonly private AppDbContext _context;
        public TypeSubRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<Typesub>> ReadTypeSun()
        {
            var ListOfTypeSub= await _context.Typesubs
                .AsNoTracking()
                .ToListAsync();

            return ListOfTypeSub;
           
        }
    }
}
