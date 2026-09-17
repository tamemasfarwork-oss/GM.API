using System;
using System.Collections.Generic;

namespace GM.DAL.Domain;

public partial class Trainer
{
    public int TrainersId { get; set; }

    public DateOnly DateWork { get; set; }

    public byte IsActive { get; set; }

    public string CreateBy { get; set; } = null!;

    public decimal SalaryPerMonth { get; set; }

    public string Specialization { get; set; } = null!;

    public decimal PricePerMonthPrivateTrain { get; set; }

    public virtual ICollection<Privatetrain> Privatetrains { get; set; } = new List<Privatetrain>();

    public virtual ICollection<TrainersBranch> TrainersBranches { get; set; } = new List<TrainersBranch>();
}
