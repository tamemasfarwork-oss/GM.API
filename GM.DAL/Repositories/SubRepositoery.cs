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
    public class SubRepositoery:ISubRepository
    {

        public record MonthRevenue(int Year, int Month, decimal Total);
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

        public async Task<List<TResult>> SubscriptionsRemaining7DaysToEX<TResult>(
     Expression<Func<Sub, TResult>> selector, int days = 7)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var limit = today.AddDays(days);

            return await _context.Subs
                .AsNoTracking()
                .Where(s => s.DateEnd >= today && s.DateEnd <= limit)
                .OrderBy(s => s.DateEnd)
                .Select(selector)
                .ToListAsync();
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

        public  async Task<List<TResult>> GetSubscriptions<TResult>(Expression<Func<Sub, TResult>> selector, int pageNumber, int pagesize)
        {
            var bagesub =  await  _context.Subs
                .AsNoTracking()
                .OrderBy(s => s.SunId)
                .Skip((pageNumber - 1) * pagesize)
                .Take(pagesize)
                .Select(selector)
                
                .ToListAsync();
            return bagesub;


        }

        public async Task<int> GetActiveSubs()
        {
            var result = await _context.Subs
                .Where(s => s.Status == "Active")
                .CountAsync();
            return result;
        }


        public async Task<decimal> Revenues()
        {

            var today = DateOnly.FromDateTime(DateTime.Today);
            var firstDay = new DateOnly(today.Year, today.Month, 1);
            var nextMonth = firstDay.AddMonths(1);

            return await _context.Subs
                .AsNoTracking()
                .Where(s => s.DateSub >= firstDay && s.DateSub < nextMonth)
                .SumAsync(s => s.Price);
        }

       

            public async Task<List<MonthRevenue>> GetRevenueByMonthAsync(DateOnly from)
        {
                       return await _context.Subs
                .AsNoTracking()
                .Where(s => s.DateSub >= from)
                .GroupBy(s => new { s.DateSub.Year, s.DateSub.Month })
                .Select(g => new MonthRevenue(g.Key.Year, g.Key.Month, g.Sum(s => s.Price)))
                .ToListAsync();
        }

        public async Task<List<TResult>> SubscriptionsEx<TResult>(Expression<Func<Sub, TResult>> selector)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var result = await _context.Subs
                .AsNoTracking()
                .Where(s => s.DateEnd <today && s.Status == "Active")
                .Select(selector)
                .ToListAsync();
            return result;

        }

        public async Task<Sub> GetSubbyid(int subid)
        {
            return await _context.Subs.FirstOrDefaultAsync(s => s.SunId == subid);
        }


    }
}
