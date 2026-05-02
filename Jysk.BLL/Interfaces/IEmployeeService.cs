using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.DTO;

namespace Jysk.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task Create(EmployeeDTO entity);
        Task Update(EmployeeDTO entity);
        Task Delete(int id);
        Task<EmployeeDTO> GetById(int id);
        Task<IEnumerable<EmployeeDTO>> GetAll();
    }
}
