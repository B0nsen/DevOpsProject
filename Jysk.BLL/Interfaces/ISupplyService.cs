using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.DTO;

namespace Jysk.BLL.Interfaces
{
    public interface ISupplyService
    {
        Task Create(SupplyDTO entity);
        Task Update(SupplyDTO entity);
        Task Delete(int id);
        Task<SupplyDTO> GetById(int id);
        Task<IEnumerable<SupplyDTO>> GetAll();
    }
}
