using GM.DAL.Data;
using GM.DAL.Domin;
using GM.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DAL.Repositories
{
    public class TypeSubRepository : ITypeSubRepository
    {

        readonly private AppDbContext _context;
        public TypeSubRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Typesub typesub)
        {
            var result =await  _context.Typesubs.AddAsync(typesub);
            await _context.SaveChangesAsync();
            return typesub.TypeSubId;
        }

        public  async Task<Typesub> Find(int type_id)
        {
            var typesup = await  _context.Typesubs.FindAsync(type_id);
            return  typesup;
        }

        public async Task<List<Typesub>> ReadTypeSun()
        {
            var ListOfTypeSub = await _context.Typesubs
                .AsNoTracking()
                
              
                
                .ToListAsync();

            return ListOfTypeSub;
           
        }

        public async Task<bool> UpdateAsync(Typesub typesub)
        {
            _context.Entry(typesub).State = EntityState.Modified;

            // حفظ التغييرات في قاعدة البيانات
            var rowsAffected = await _context.SaveChangesAsync();

            // إرجاع true إذا تم تعديل صف واحد على الأقل
            return rowsAffected > 0;
        }
    }
}
