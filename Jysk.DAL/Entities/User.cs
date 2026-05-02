using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jysk.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public ICollection<Client> ClientId { get; set; }
        public ICollection<Employee> EmployeeId { get; set; }
    }
}
