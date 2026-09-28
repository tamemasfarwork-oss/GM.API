using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.DTOs.TrainersDto
{
    public class TrianerDtos
    {
        public string fullname { get; set; }

        public int TrainersId { get; set; }

        public DateOnly DateWork { get; set; }

        public byte IsActive { get; set; }

        public string CreateBy { get; set; } = null!;

        public decimal SalaryPerMonth { get; set; }

        public string Specialization { get; set; } = null!;

        public decimal PricePerMonthPrivateTrain { get; set; }
    }
}
