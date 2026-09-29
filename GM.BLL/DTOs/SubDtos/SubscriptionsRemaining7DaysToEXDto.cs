using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.DTOs.SubDtos
{
    public class SubscriptionsRemaining7DaysToEXDto
    {
        public DateOnly DateSub { get; set; }

        public DateOnly DateEnd { get; set; }
        public string Status { get; set; } = null!;

        public string CreateBy { get; set; } = null!;

      

        public decimal Price { get; set; }
        public string Fullname { get; set; }
        public string BranchName { get; set; }
    }
}
