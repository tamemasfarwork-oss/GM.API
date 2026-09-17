using System;
using System.Collections.Generic;

namespace GM.DAL.Domain;

public partial class Sub
{
    public int SunId { get; set; }

    public DateOnly DateSub { get; set; }

    public DateOnly DateEnd { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public int Active { get; set; }

    public string Status { get; set; } = null!;

    public string CreateBy { get; set; } = null!;

    public int PlayerId { get; set; }

    public int TypeSubId { get; set; }

    public int BranchesId { get; set; }

    public int StatusOfSub { get; set; }

    public virtual Branch Branches { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;

    public virtual Statusofsub StatusOfSubNavigation { get; set; } = null!;

    public virtual Typesub TypeSub { get; set; } = null!;
}
