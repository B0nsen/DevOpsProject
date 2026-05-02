using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.DTO;

namespace Jysk.BLL.Interfaces
{
    public interface IWriteOffService
    {
        Task Create(WriteOffDTO entity);
        Task Update(WriteOffDTO entity);
        Task Delete(int id);
        Task<WriteOffDTO> GetById(int id);
        Task<IEnumerable<WriteOffDTO>> GetAll();

    }
}
