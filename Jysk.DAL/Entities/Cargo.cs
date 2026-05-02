using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.DAL.Entities
{
    public class Cargo
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int StorageToId { get; set; }
        public virtual Storage? StorageTo { get; set; }
        public int StorageFromId { get; set; }
        public virtual Storage? StorageFrom { get; set; }
        public int Count { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
