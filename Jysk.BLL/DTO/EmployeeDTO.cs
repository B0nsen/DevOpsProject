using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.BLL.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? User { get; set; }
        public string Position { get; set; }
        public string Comment { get; set; }
    }
}
