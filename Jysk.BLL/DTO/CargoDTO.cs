using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.DAL.Entities;

namespace Jysk.BLL.DTO
{
    public class CargoDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? Product { get; set; }
        public int StorageToId { get; set; }
        public string? StorageTo { get; set; }
        public int StorageFromId { get; set; }
        public string? StorageFrom { get; set; }
        public int Count { get; set; }
        public int EmployeeId { get; set; }
        public string? Employee { get; set; }
    }
}
