using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.DAL.Entities
{
    public class WriteOff
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
        public int StorageId { get; set; }
        public virtual Storage? Storage { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public string Reason { get; set; }
        public int Sum { get; set; }
    }
}
