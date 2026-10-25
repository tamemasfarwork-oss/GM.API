using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.DTOs.ProductDto
{
    public class AddProductDto
    {

        public string ProductName { get; set; } = null!;
        public string? describe { get; set; }


        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal CostPrice { get; set; }
        public IFormFile? Image { get; set; }

    }
}
