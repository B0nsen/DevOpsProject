using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.DAL.Entities
{
    public class Storage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Sum { get; set; }
        public ICollection<Cargo> CargoFromId { get; set; }
        public ICollection<Cargo> CargoToId { get; set; }
        public ICollection<Store> StoreId { get; set; }
        public ICollection<Delivery> DeliveryId { get; set; }
    }
}
