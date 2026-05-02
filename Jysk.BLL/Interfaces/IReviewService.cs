using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.DTO;

namespace Jysk.BLL.Interfaces
{
    public interface IReviewService
    {
        Task Create(ReviewDTO entity);
        Task Update(ReviewDTO entity);
        Task Delete(int id);
        Task<ReviewDTO> GetById(int id);
        Task<IEnumerable<ReviewDTO>> GetAll();
    }
}
