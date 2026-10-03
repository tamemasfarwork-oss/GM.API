using System;
using System.Collections.Generic;

namespace GM.DAL.Domin;

public partial class Player
{
    public int PlayerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public DateOnly DateJoin { get; set; }

    public string Type { get; set; } = null!;

    public int Active { get; set; }

    public string CreateBy { get; set; } = null!;

    public int? ClubId { get; set; }

    public virtual Club? Club { get; set; }

    public virtual ICollection<Privatetrain> Privatetrains { get; set; } = new List<Privatetrain>();

    public virtual ICollection<Sub> Subs { get; set; } = new List<Sub>();
}
