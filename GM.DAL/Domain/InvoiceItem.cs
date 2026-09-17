using System;
using System.Collections.Generic;

namespace GM.DAL.Domain;

public partial class InvoiceItem
{
    public int InvoiceItemsId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public int InvoicesId { get; set; }

    public int ProductId { get; set; }

    public virtual Invoice Invoices { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
