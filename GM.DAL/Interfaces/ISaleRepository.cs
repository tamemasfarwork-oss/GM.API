using GM.DAL.Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DAL.Interfaces
{
    public interface ISaleRepository
    {
        Task<List<Product>> GetProductsAsync(List<int> ids);
        Task AddInvoiceAsync(Invoice invoice);
        Task SaveChangesAsync();
    }
}
