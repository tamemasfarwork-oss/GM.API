using System;
using System.Collections.Generic;

namespace GM.DAL.Domain;

public partial class TrainersBranch
{
    public int TrainersBranchesId { get; set; }

    public int BranchesId { get; set; }

    public int TrainersId { get; set; }

    public virtual Branch Branches { get; set; } = null!;

    public virtual Trainer Trainers { get; set; } = null!;
}
