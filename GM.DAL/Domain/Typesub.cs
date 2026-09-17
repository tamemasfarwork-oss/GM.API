using System;
using System.Collections.Generic;

namespace GM.DAL.Domain;

public partial class Typesub
{
    public int TypeSubId { get; set; }

    public decimal Price { get; set; }

    public string TimeSpan { get; set; } = null!;

    public virtual ICollection<Sub> Subs { get; set; } = new List<Sub>();
}
