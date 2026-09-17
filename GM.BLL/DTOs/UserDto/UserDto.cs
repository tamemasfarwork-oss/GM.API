using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.DTOs.UserDto
{
    public class UserDto
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
    }
}
