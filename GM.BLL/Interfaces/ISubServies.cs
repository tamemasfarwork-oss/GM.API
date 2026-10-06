using GM.BLL.DTOs.SubDtos;
using GM.DAL.Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Interfaces
{
    public interface ISubServies
    {
        Task<bool> AddSubSubServies(SubDto subDto);

        Task<List<SubLastThreeDto>> GetLastThreeSub();
        Task<List<SubGetAll>> GetAllSubs(int pagenumber,int pagesize);
        Task<List<SubscriptionsRemaining7DaysToEXDto>> SubscriptionsRemaining7DaysToEXServies(int days);
        Task<int> GetActiveSubsServies();
        Task<decimal> RevenuesServies();
        public Task<List<MonthRevenueDto>> GetRevenueLast6MonthsServies();
       Task<List<SubEXDto>> SubscriptionsExServies();

        Task<bool> RefrechSubServies(RefrechSub refrechSub);


    }
}
