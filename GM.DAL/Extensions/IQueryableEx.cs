using GM.DAL.Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GM.DAL.NewFolder
{
    public static class QueryExtensions
    {
        public static IQueryable<T> WhereIf<T>(
            this IQueryable<T> query,
            bool condition,
            Expression<Func<T, bool>> predicate)// هون bool لانه هو شرط    سوف يطبق على كل لاعب يعني 
            /// p => p.Type == c.Type على كل لاعب سوف يطبق   اما  condition هو هل اصلا رح احط هل فلتره ام لا 
            => condition ? query.Where(predicate) : query;

       public static IQueryable<T> MyownOrderBY<T,Tresult>(this IQueryable<T> VALUE,
           bool _Isdis, Expression<Func<T, Tresult>> predecate) =>
           _Isdis ? VALUE.OrderByDescending(predecate) : VALUE;

      


        public static int countplayers
             (this List<Player> query, Func<Player, bool> predicate)
        {
            return query.Count(predicate);
        }
    }
}
