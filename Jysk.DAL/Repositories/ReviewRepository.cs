using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.DAL.EF;
using Jysk.DAL.Entities;
using Jysk.DAL.Interfaces;
using LoggerLib;
using Microsoft.EntityFrameworkCore;

namespace Jysk.DAL.Repositories
{
    public class ReviewRepository : IRepository<Review>
    {
        private JyskContext db;
        public ReviewRepository(JyskContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Review>> GetAll()
        {
            return await db.T_Review.Include(o => o.Product).ToListAsync();
        }
        public async Task<Review> Get(int id)
        {
            var list = await db.T_Review.Include(o => o.Product).Where(a => a.Id == id).ToListAsync();
            Review review = list.FirstOrDefault();
            if (review == null)
            {
                Logger log = new Logger();
                log.Log("Error: Review doesnt exist");
            }
            return review;
        }
        public async Task Create(Review review)
        {
            try
            {
                await db.T_Review.AddAsync(review);
                Logger log = new Logger();
                log.Log("Review added into database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during adding review into database\nException: " + ex.ToString());
            }
            
        }
        public void Update(Review review)
        {
            try
            {
                db.Entry(review).State = EntityState.Modified;
                Logger log = new Logger();
                log.Log("Review updated in database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during updating review in database\nException: " + ex.ToString());
            }
            
        }
        public async Task Delete(int id)
        {
            try
            {
                Review review = await db.T_Review.FindAsync(id);
                if (review != null)
                {
                    db.T_Review.Remove(review);
                }
                Logger log = new Logger();
                log.Log("Review deleted from database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during deleting review from database\nException: " + ex.ToString());
            }
            
        }
    }
}
