using System;
using System.Collections.Generic;

namespace GM.DAL.Domain;

public partial class Privatetrain
{
    public int PrivateTrainId { get; set; }

    public DateOnly DateStart { get; set; }

    public string Status { get; set; } = null!;

    public decimal PricePerMonth { get; set; }

    public decimal TheClubsShare { get; set; }

    public int TrainersId { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual Trainer Trainers { get; set; } = null!;
}
