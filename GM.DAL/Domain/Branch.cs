using System;
using System.Collections.Generic;

namespace GM.DAL.Domain;

public partial class Branch
{
    public int BranchesId { get; set; }

    public string BranchName { get; set; } = null!;

    public string BranchAddres { get; set; } = null!;

    public string BranchManger { get; set; } = null!;

    public virtual ICollection<Sub> Subs { get; set; } = new List<Sub>();

    public virtual ICollection<TrainersBranch> TrainersBranches { get; set; } = new List<TrainersBranch>();
}
