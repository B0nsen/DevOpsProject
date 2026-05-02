using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.DAL.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HouseNumber { get; set; }
        public int TotalProductSum { get; set; }
        public int StorageId { get; set; }
        public virtual Storage? Storage { get; set; }
        public string? Photo { get; set; }
        public int WorkHoursId { get; set; }
        public WorkHours? WorkHours { get; set; }
    }
}
