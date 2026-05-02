using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Rating { get; set; }
        public bool Delivery { get; set; }
        public int ManufacturerId { get; set; }
        public virtual Manufacturer? Manufacturer { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public int Discount { get; set; }
        public string Photo { get; set; }
        public virtual ICollection<Review> ReviewId { get; set; }
        public virtual ICollection<Cargo> CargoId { get; set; }
        public virtual ICollection<WriteOff> WriteOffId { get; set; }
        public virtual ICollection<Supply> SupplyId { get; set; }
    }
}
