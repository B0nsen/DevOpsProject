using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.DTO;

namespace Jysk.BLL.Interfaces
{
    public interface IDeliveryService
    {
        Task Create(DeliveryDTO entity);
        Task Update(DeliveryDTO entity);
        Task Delete(int id);
        Task<DeliveryDTO> GetById(int id);
        Task<IEnumerable<DeliveryDTO>> GetAll();
    }
}
