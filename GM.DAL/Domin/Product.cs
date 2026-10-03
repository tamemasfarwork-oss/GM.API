using System;
using System.Collections.Generic;

namespace GM.DAL.Domin;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public decimal CostPrice { get; set; }

    public int? ClubId { get; set; }

    public virtual Club? Club { get; set; }

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
}
