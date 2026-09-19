using GM.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.DTOs.SubDtos
{
    public class SubDto
    {
        public int SunId { get; set; }

        public DateOnly DateSub { get; set; }

        public DateOnly DateEnd { get; set; }

        public string PaymentMethod { get; set; } = null!;

        public int Active { get; set; }

        public string Status { get; set; } = null!;

        public string CreateBy { get; set; } = null!;

        public int PlayerId { get; set; }

        public int TypeSubId { get; set; }

        public int BranchesId { get; set; }

        public decimal Price { get; set; }
        public virtual Player Player { get; set; } = null!;

    }
}
