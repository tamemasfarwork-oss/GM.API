using GM.DAL.Data;
using GM.DAL.Domin;
using GM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
