using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.DTO;

namespace Jysk.BLL.Interfaces
{
    public interface IStoreService
    {
        Task Create(StoreDTO entity);
        Task Update(StoreDTO entity);
        Task Delete(int id);
        Task<StoreDTO> GetById(int id);
        Task<IEnumerable<StoreDTO>> GetAll();
    }
}
