using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.DTO;

namespace Jysk.BLL.Interfaces
{
    public interface IStorageService
    {
        Task Create(StorageDTO entity);
        Task Update(StorageDTO entity);
        Task Delete(int id);
        Task<StorageDTO> GetById(int id);
        Task<IEnumerable<StorageDTO>> GetAll();
    }
}
