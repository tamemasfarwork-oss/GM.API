using GM.DAL.Data;
using GM.DAL.Domin;
using GM.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GM.DAL.Repositories
{
    public class TrinersRepositoery : ITreainersRepository
    {
        private readonly AppDbContext _Context;

      public  TrinersRepositoery(AppDbContext appDbContext)
        {
            _Context = appDbContext;
        }
       

        public  async Task<List<TResult>> GetAllTriner<TResult>(int pagenumber, int pagesiaze, Expression<Func<
            Trainer, TResult>> selector)
        {

            var trainers = await _Context.Trainers
              .AsNoTracking()
              .OrderBy(s => s.TrainersId)
              .Skip((pagenumber - 1) * pagesiaze)
              .Take(pagesiaze)
              .Select(selector)
              .ToListAsync();

            return trainers;
        }

        public async Task<List<TResult>> SearchByName<TResult>(
    string? term,
    int take,
    Expression<Func<Trainer, TResult>> selector) // الشكل اللي بدنا ياه، جاي من الـ Business
        {
            var query = _Context.Trainers.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(t => (t.FullName.Contains(term)));
            }

            return await query
                .OrderBy(t => t.FullName)
                .Take(take)
                .Select(selector)   // EF بيترجمه لـ SQL، فبيجيب بس الأعمدة اللي بالـ selector
                .ToListAsync();
        }
    }
}
