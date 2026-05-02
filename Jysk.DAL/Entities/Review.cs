using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.DAL.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
