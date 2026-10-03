using GM.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DAL.Interfaces
{
    public interface IAuthRepositery
    {
        Task<User?> GetByEmailAsync(string email);

    }
}
