using GM.BLL.DTOs.SaleDto;
using GM.BLL.Interfaces;
using GM.DAL.Domin;
using GM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Services
{
    public class SaleServies : ISaleServies
    {
        private readonly ISaleRepository _repo;

        public SaleServies(ISaleRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> CreateSaleServies(CreateSaleDto dto)
        {
            // لو نفس المنتج انرسل مرتين، منجمع كمياته
            var items = dto.Items
                .GroupBy(i => i.ProductId)
                .Select(g => new SaleItemDto { ProductId = g.Key, Quantity = g.Sum(x => x.Quantity) })
                .ToList();

            var products = await _repo.GetProductsAsync(
                items.Select(i => i.ProductId).ToList());

            var invoice = new Invoice
            {
                SaleDate = DateTime.UtcNow,
                PaymentMethod = dto.PaymentMethod,
              
            };

            decimal total = 0;

            foreach (var item in items)
            {
                var product = products.FirstOrDefault(p => p.ProductId == item.ProductId)
                    ?? throw new ArgumentException("منتج غير موجود");

                if (product.Quantity < item.Quantity)
                    throw new ArgumentException($"الكمية غير كافية: {product.ProductName}");

                product.Quantity -= item.Quantity;
                total += product.Price * item.Quantity;

                invoice.InvoiceItems.Add(new InvoiceItem
                {
                    ProductId = product.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price,
                   
                });
            }

            invoice.TotalPrice = total;

            await _repo.AddInvoiceAsync(invoice);
            await _repo.SaveChangesAsync();

            return invoice.InvoicesId;
        }
    }
}
