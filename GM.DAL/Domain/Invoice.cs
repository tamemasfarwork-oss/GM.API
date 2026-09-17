using System;
using System.Collections.Generic;

namespace GM.DAL.Domain;

public partial class Invoice
{
    public int InvoicesId { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime SaleDate { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
}
