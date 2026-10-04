using GM.DAL.Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static GM.DAL.Repositories.SubRepositoery;

namespace GM.DAL.Interfaces
{
    public interface ISubRepository
    {
        Task<bool> AddSub(Sub sub);
        Task<List<Sub>> GetLastThreeSub();
        public Task<List<TResult>> GetSubscriptions<TResult>(
    Expression<Func<Sub, TResult>> selector,int pageNumber , int pagesize);
        Task<List<TResult>> SubscriptionsRemaining7DaysToEX<TResult>(
    Expression<Func<Sub, TResult>> selector,int days);
        Task<int> GetActiveSubs();
        Task<decimal> Revenues();
        Task<List<MonthRevenue>> GetRevenueByMonthAsync(DateOnly from);
        Task<List<TResult>> SubscriptionsEx<TResult>(
   Expression<Func<Sub, TResult>> selector);
    }
   
}
