using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.DTOs.PlayerDto
{
    public class GetPlayerDto
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Phone { get; set; } = null!;


        public DateOnly DateJoin { get; set; }

        //نوع الرياضة أو النشاط:
        public string Type { get; set; } = null!;

    }
}
