using GM.BLL.DTOs.TypeDto;
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

        public  async Task<Typesub> FindeAsync(int id)
        {
            return await _typeSub.Find(id);
        }

        public  async Task<List<TypeSubDto>> ReadTypeSub()
        {
            var typesubs = await _typeSub.ReadTypeSun();

            var result =   typesubs.Select(x => new TypeSubDto
            {
                TypeSubId = x.TypeSubId,
                Price = x.Price,
                TimeSpan = x.TimeSpan
                // ضع هنا فقط الحقول الموجودة في DTO، وسيتجاهل تلقائياً الحقل الزائد
            }).ToList();

            return result;
        }
    }
}
