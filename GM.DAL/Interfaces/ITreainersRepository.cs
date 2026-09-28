using GM.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GM.DAL.Interfaces
{
    public   interface ITreainersRepository
    {
       
        public Task<List<TResult>> GetAllTriner<TResult>(int pagenumber,int pagesiaze,
             Expression<Func<Trainer, TResult>> selector);
        public Task<List<TResult>> SearchByName<TResult>(
    string? term,
    int take,
    Expression<Func<Trainer, TResult>> selector);
    }
}
