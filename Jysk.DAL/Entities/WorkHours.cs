using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.DAL.Entities
{
    public class WorkHours
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public virtual ICollection<Store> Store { get; set; }
    }
}
