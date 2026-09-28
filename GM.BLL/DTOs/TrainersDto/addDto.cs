using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.BLL.DTOs.TrainersDto
{
    public class addDto
    {

        public int PlayerId { get; set; }
        public int TrainerId { get; set; }
        public decimal PricePerMonth { get; set; }
        public decimal ClubShare { get; set; }
        public int privid { get; set; }
    }
}
