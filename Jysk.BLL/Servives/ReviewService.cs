using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.Interfaces;
using Jysk.BLL.Infrastructure;
using Jysk.DAL.Interfaces;
using Jysk.BLL.DTO;
using Jysk.DAL.Entities;
using LoggerLib;
using AutoMapper;

namespace Jysk.BLL.Servives
{
    public class ReviewService : IReviewService
    {
        private IUnitOfWork db { get; set; }
        public ReviewService(IUnitOfWork db)
        {
            this.db = db;
        }
        public async Task Create(ReviewDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Review creation had null entity");
                }
                else
                {
                    var res = new Review
                    {
                        Id = entity.Id,
                        Rating = entity.Rating,
                        Description = entity.Description,
                        ProductId = entity.ProductId
                    };
                    await db.R_Review.Create(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Review added successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during review creation\nException: " + ex.ToString());
            }
        }
        public async Task Update(ReviewDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Review update had null entity");
                }
                else
                {
                    var res = new Review
                    {
                        Id = entity.Id,
                        Rating = entity.Rating,
                        Description = entity.Description,
                        ProductId = entity.ProductId
                    };
                    db.R_Review.Update(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Review updated successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during review update\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                await db.R_Review.Delete(id);
                await db.Save();
                Logger log = new Logger();
                log.Log("Review deleted successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during review delete\nException: " + ex.ToString());
            }
        }
        public async Task<ReviewDTO> GetById(int id)
        {
            var res = await db.R_Review.Get(id);
            if (res == null)
            {
                Logger log = new Logger();
                log.Log("Error: GetById Review doesnt exist");
                throw new ValidationException("Review doesnt exist", "");
            }
            return new ReviewDTO
            {
                Id = res.Id,
                Rating = res.Rating,
                Description = res.Description,
                ProductId = res.ProductId,
                Product = res.Product.Name
            };
        }
        public async Task<IEnumerable<ReviewDTO>> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewDTO>()
            .ForMember("Product", opt => opt.MapFrom(c => c.Product.Name)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Review>, IEnumerable<ReviewDTO>>(await db.R_Review.GetAll());
        }
    }
}
