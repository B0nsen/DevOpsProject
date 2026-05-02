using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.DTO;

namespace Jysk.BLL.Interfaces
{
    public interface IOrderService
    {
        Task Create(OrderDTO entity);
        Task Update(OrderDTO entity);
        Task Delete(int id);
        Task<OrderDTO> GetById(int id);
        Task<IEnumerable<OrderDTO>> GetAll();
    }
}
