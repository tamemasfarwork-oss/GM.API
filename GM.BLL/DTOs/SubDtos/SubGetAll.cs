using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.DTOs.SubDtos
{
    public class SubGetAll
    {
     public      int subid { get; set; }
     public    decimal price { get; set; }
     public   string fullname { get; set; }
     public   string status { get; set; }
     public   string branchname { get; set; }
     public   DateOnly startsub { get; set; }
     public int endsub { get; set; }

    }
}
