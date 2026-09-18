using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.DTOs.TypeDto
{
    public class TypeSubDto
    {

        public int TypeSubId { get; set; }

        public decimal Price { get; set; }

        public string TimeSpan { get; set; } = null!;
    }
}
