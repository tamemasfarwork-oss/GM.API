using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.DTOs.PlayerDto
{
    public class PlayerListDto
    {
        public int PlayerID { get; set; }
        public string FullName { get; set; } = "";
        public string? Type { get; set; }
        public string? Email { get; set; }
    }
}
