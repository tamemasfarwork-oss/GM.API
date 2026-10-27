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
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _db;

        public SaleRepository(AppDbContext db)
        {
            _db = db;
        }

        public Task<List<Product>> GetProductsAsync(List<int> ids)
        {
            return _db.Products
                .Where(p => ids.Contains(p.ProductId))
                .ToListAsync();
        }

        public async Task AddInvoiceAsync(Invoice invoice)
        {
            await _db.Invoices.AddAsync(invoice);
        }

        public Task SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}
