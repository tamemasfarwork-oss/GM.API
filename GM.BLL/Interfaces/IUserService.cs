using GM.BLL.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Interfaces
{
    public interface IUserService
    {
         Task<bool> Register(UserDto userDto);
    }
}
