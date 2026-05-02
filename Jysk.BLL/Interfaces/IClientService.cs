using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.DTO;

namespace Jysk.BLL.Interfaces
{
    public interface IClientService
    {
        Task Create(ClientDTO entity);
        Task Update(ClientDTO entity);
        Task Delete(int id);
        Task<ClientDTO> GetById(int id);
        Task<IEnumerable<ClientDTO>> GetAll();
    }
}
