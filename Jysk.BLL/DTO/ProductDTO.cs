using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.BLL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Rating { get; set; }
        public bool Delivery { get; set; }
        public int ManufacturerId { get; set; }
        public string? Manufacturer { get; set; }
        public int CategoryId { get; set; }
        public string? Category { get; set; }
        public int Discount { get; set; }
        public string Photo { get; set; }
    }
}
