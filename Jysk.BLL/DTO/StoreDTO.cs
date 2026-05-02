using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.BLL.DTO
{
    public class StoreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HouseNumber { get; set; }
        public int TotalProductSum { get; set; }
        public int StorageId { get; set; }
        public string? Storage { get; set; }
        public string? Photo { get; set; }
        public int WorkHoursId { get; set; }
        public string? WorkHours { get; set; }
    }
}
