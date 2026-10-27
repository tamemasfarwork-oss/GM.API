using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.DTOs.SaleDto
{
    public class CreateSaleDto
    {
        [Required]
        public string PaymentMethod { get; set; } = null!;

        [MinLength(1)]
        public List<SaleItemDto> Items { get; set; } = new();
    }
}
