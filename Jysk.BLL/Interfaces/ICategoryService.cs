using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.DTO;

namespace Jysk.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task Create(CategoryDTO entity);
        Task Update(CategoryDTO entity);
        Task Delete(int id);
        Task<CategoryDTO> GetById(int id);
        Task<IEnumerable<CategoryDTO>> GetAll();
    }
}
