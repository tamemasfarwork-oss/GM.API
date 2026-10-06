using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.DTOs.SubDtos
{
    public class RefrechSub
    {
       
            public int OldSubId { get; set; }
            public int TypeSubId { get; set; }       // النوع الجديد (غالباً نفس القديم)
            public DateOnly? StartDate { get; set; } // اختياري
        public string createdby { get; set; } = null!;
        public  string paymentmethod { get; set; } = null!;
        public int?  BranchesId { get; set; } // اختياري
    }
}
