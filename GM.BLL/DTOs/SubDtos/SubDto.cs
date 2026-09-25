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
        
            public string PaymentMethod { get; set; } = null!;
            public int PlayerId { get; set; }
            public int TypeSubId { get; set; }
            public int BranchesId { get; set; }

        

    }
}
