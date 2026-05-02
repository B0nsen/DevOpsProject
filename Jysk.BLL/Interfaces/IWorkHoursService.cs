using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.DTO;

namespace Jysk.BLL.Interfaces
{
    public interface IWorkHoursService
    {
        Task Create(WorkHoursDTO entity);
        Task Update(WorkHoursDTO entity);
        Task Delete(int id);
        Task<WorkHoursDTO> GetById(int id);
        Task<IEnumerable<WorkHoursDTO>> GetAll();
    }
}
