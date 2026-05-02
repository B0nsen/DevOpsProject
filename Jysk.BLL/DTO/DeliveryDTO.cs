using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.BLL.DTO
{
    public class DeliveryDTO
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public string? Storage { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
        public int Sum { get; set; }
        public int ManufacturerId { get; set; }
        public string? Manufacturer { get; set; }
    }
}
