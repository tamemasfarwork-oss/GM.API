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

    // ... باقي الخصائص
    public int PlayerId { get; set; }
    public Player Player { get; set; } = null!;

    public virtual Trainer Trainers { get; set; } = null!;

  


}
