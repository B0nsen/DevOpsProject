using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.BLL.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public string? Product { get; set; }
    }
}
