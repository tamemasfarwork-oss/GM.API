using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.DTOs.SaleDto
{
    public class SaleItemDto
    {
        public int ProductId { get; set; }

        [Range(1, 10000)]
        public int Quantity { get; set; }
    }
}
