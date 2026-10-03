using System;
using System.Collections.Generic;

namespace GM.DAL.Domin;

public partial class Typesub
{
    public int TypeSubId { get; set; }

    public decimal Price { get; set; }

    public string TimeSpan { get; set; } = null!;

    public int DurationMonths { get; set; }

    public int? ClubId { get; set; }

    public virtual Club? Club { get; set; }

    public virtual ICollection<Sub> Subs { get; set; } = new List<Sub>();
}
