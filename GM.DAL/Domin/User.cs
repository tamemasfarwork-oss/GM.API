using System;
using System.Collections.Generic;

namespace GM.DAL.Domin;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumaer { get; set; } = null!;

    public int Age { get; set; }

    public string? Adress { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte IsActive { get; set; }

    public int? ClubId { get; set; }

    public virtual Club? Club { get; set; }
}
