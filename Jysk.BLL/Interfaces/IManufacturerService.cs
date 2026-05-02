using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.DTO;

namespace Jysk.BLL.Interfaces
{
    public interface IManufacturerService
    {
        Task Create(ManufacturerDTO entity);
        Task Update(ManufacturerDTO entity);
        Task Delete(int id);
        Task<ManufacturerDTO> GetById(int id);
        Task<IEnumerable<ManufacturerDTO>> GetAll();
    }
}
