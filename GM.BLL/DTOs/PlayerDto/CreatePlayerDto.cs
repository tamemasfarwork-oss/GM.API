using GM.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.DTOs.PlayerDto
{
    public class CreatePalyerDto
    {
        public int PlayerId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string? Email { get; set; }

        public DateOnly DateJoin { get; set; }

        public string Type { get; set; } = null!;

        public int Active { get; set; }





    }
}
