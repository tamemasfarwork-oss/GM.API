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
    public class ProductRepo : IPrductRepo
    {

        readonly private AppDbContext _context;

      public  ProductRepo(AppDbContext context) => _context = context;
        public async Task<int> AddProduct(Product product)
        {
            var add = await _context.AddAsync(product);
            var result = await _context.SaveChangesAsync();

            return product.ProductId;
        }

        public async Task<List<Tresult>> GetProducts<Tresult>(int pagenumber, int pagesiaze, Expression<Func<Product, Tresult>> selector)
        {

            var result = await _context.Products
                .AsNoTracking()
                .OrderBy(s => s.ProductId)
                .Skip((pagenumber - 1) * pagesiaze)
                .Take(pagesiaze)
                .Select(selector)
                .ToListAsync();
            return result;
           
        }

      

        public async Task<Product> GetProductsByidRepo(int productid)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productid);
        }
    }
}
