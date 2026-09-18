using GM.BLL.Interfaces;
using GM.DAL.Domain;
using GM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.Services
{
    public class TypeSub : ITypeSub
    {

        readonly private ITypeSubRepository _typeSub;
        public TypeSub(ITypeSubRepository typeSub)
        {
            _typeSub = typeSub;
        }
      public  async Task<List<Typesub>> ReadTypeSub()
        {


            return await _typeSub.ReadTypeSun();
        }
    }
}
