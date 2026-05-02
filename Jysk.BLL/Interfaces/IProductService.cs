using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.DTO;

namespace Jysk.BLL.Interfaces
{
    public interface IProductService
    {
        Task Create(ProductDTO entity);
        Task Update(ProductDTO entity);
        Task Delete(int id);
        Task<ProductDTO> GetById(int id);
        Task<IEnumerable<ProductDTO>> GetAll();
    }
}
