using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.DTOs
{
    public class PlayerSearchFilter
    {
        public string? Name { get; set; }          // يبحث بالاسم الكامل
        public string? Type { get; set; }          // لو عندك Enum اجعله PlayerType?
        public string? Email { get; set; }          // يبحث بالإيميل

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => PageSize == 0 ? 0 : (int)Math.Ceiling(TotalCount / (double)PageSize);
    }
}
