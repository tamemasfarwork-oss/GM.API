using System;
using System.Collections.Generic;

namespace GM.DAL.Domin;

public partial class Club
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateOnly? SubscriptionEnd { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual ICollection<Privatetrain> Privatetrains { get; set; } = new List<Privatetrain>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Sub> Subs { get; set; } = new List<Sub>();

    public virtual ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();

    public virtual ICollection<TrainersBranch> TrainersBranches { get; set; } = new List<TrainersBranch>();

    public virtual ICollection<Typesub> Typesubs { get; set; } = new List<Typesub>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
