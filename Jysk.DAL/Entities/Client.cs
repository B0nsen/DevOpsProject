using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.DAL.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string Address { get; set; }
        public int Sum { get; set; }
        public virtual ICollection<Order> OrderId { get; set; }
    }
}
