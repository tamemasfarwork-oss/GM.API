using System;
using System.Collections.Generic;

namespace GM.DAL.Domain;

public partial class Statusofsub
{
    public int StatusOfSub1 { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Sub> Subs { get; set; } = new List<Sub>();
}
