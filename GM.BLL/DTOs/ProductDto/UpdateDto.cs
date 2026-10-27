using GM.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.DTOs.ProductDto
{
    public  class UpdateDto
    {

        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal CostPrice { get; set; }
        public IFormFile?  ImageUrl { get; set; }
        public string? describetion { get; set; }
    }
}
