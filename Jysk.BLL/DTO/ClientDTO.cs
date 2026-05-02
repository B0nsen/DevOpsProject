using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.BLL.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string? User { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public int Sum { get; set; }
    }
}
