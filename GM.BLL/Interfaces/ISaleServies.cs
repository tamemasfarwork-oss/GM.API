using GM.BLL.DTOs.SaleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Interfaces
{
    public interface ISaleServies
    {
        Task<int> CreateSaleServies(CreateSaleDto dto);
    }
}
