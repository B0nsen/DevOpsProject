using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.BLL.DTO
{
    public class SupplyDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? Product { get; set; }
        public int Count { get; set; }
    }
}
