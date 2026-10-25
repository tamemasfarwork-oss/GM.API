using GM.DAL.Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GM.DAL.Interfaces
{
    public interface IPrductRepo
    {
        Task<int> AddProduct(Product product);
        Task <List<Tresult>> GetProducts <Tresult>(int pagenumber,
            int pagesiaze, Expression<Func<Product, Tresult>> selector);

        Task<Product> GetProductsByidRepo(int productid
           );
    }
}
