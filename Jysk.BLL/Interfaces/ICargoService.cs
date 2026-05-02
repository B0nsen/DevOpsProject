using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.DTO;

namespace Jysk.BLL.Interfaces
{
    public interface ICargoService
    {
        Task Create(CargoDTO entity);
        Task Update(CargoDTO entity);
        Task Delete(int id);
        Task<CargoDTO> GetById(int id);
        Task<IEnumerable<CargoDTO>> GetAll();
    }
}
