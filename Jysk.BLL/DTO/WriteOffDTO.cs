using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.BLL.DTO
{
    public class WriteOffDTO
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int EmployeeId { get; set; }
        public string? Employee { get; set; }
        public int StorageId { get; set; }
        public string? Storage { get; set; }
        public int ProductId { get; set; }
        public string? Product { get; set; }
        public string Reason { get; set; }
        public int Sum { get; set; }
    }
}
