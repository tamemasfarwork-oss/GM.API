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
        Task<List<GetItemsDto>> GetItemsServies(int pagenumber, int pagesize);
        Task<int> AddProductServies(AddProductDto addProductDto);

        Task<GetItemsDto> GetProductByIDServies(int productsid);

        Task<bool> UpdateServies(UpdateDto itemsDto);
    }
}
