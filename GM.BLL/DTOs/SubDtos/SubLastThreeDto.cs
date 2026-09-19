using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.DTOs.SubDtos
{
    public class SubLastThreeDto
    {
        public int SubId { get; set; }
        public DateOnly DateSub { get; set; }
        public DateOnly DateEnd { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = null!;
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } = null!;
        public string BranchName { get; set; } = null!;
        public string TypeName { get; set; } = null!;
    }
}
