using GM.BLL.DTOs.TypeDto;
using GM.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Interfaces
{
    public interface ITypeSub
    {
     public      Task<List<TypeSubDto>> ReadTypeSub();
        public Task<Typesub> FindeAsync(int id);
    }
}
