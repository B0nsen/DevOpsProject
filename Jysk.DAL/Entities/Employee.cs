using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string Position { get; set; }
        public string Comment { get; set; }
        public virtual ICollection<WriteOff> WriteOffId { get; set; }
        public virtual ICollection<Cargo> CargoId { get; set; }
    }
}
