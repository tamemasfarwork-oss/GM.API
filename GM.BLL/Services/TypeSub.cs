using GM.BLL.DTOs.TypeDto;
using GM.BLL.Interfaces;
using GM.DAL.Domin;
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

        public async Task<int> AddTypeSubServies(TypeSubAddDto typeSubAddDto)
        {

            return await _typeSub.AddAsync(new Typesub
            {
                Price = typeSubAddDto.Price,
                TimeSpan = typeSubAddDto.TimeSpan,
                DurationMonths = typeSubAddDto.DurationMonths
            });
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

        public async Task<bool> UpdateTypeSubServies(TypeSubAddDto typeSubAddDto)
        {
            var update = new Typesub
            {
                TypeSubId = typeSubAddDto.TypeSubId,
                Price = typeSubAddDto.Price,
                // إذا كان TimeSpan في الـ DTO من نوع TimeSpan والكيان string استخدم .ToString()
                TimeSpan = typeSubAddDto.TimeSpan?.ToString() ?? "",
                DurationMonths = typeSubAddDto.DurationMonths
            };
            return  await _typeSub.UpdateAsync(update);
            
        }
    }
}
