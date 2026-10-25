using GM.BLL.DTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Interfaces
{
   public interface  IproductServies
    {

        Task<int> AddProductServies(AddProductDto addProductDto); 
    }
}
