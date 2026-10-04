using GM.DAL.Domin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Interfaces
{
    public interface ITokenService
    {
        (string Token, DateTime ExpiresAt) Create(User user);

    }
}
