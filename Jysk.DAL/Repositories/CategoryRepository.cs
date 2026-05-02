using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Jysk.DAL.EF;
using Jysk.DAL.Entities;
using Jysk.DAL.Interfaces;
using LoggerLib;
using Microsoft.EntityFrameworkCore;

namespace Jysk.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private JyskContext db;
        public CategoryRepository(JyskContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await db.T_Category.ToListAsync();
        }
        public async Task<Category> Get(int id)
        {
            Category category = await db.T_Category.FindAsync(id);
            if (category == null)
            {
                Logger log = new Logger();
                log.Log("Error: Category doesnt exist");
            }
            return category;
        }
        public async Task Create(Category category)
        {
            try
            {
                await db.T_Category.AddAsync(category);
                Logger log = new Logger();
                log.Log("Category added into database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during adding category into database\nException: " + ex.ToString());
            }
            
        }
        public void Update(Category category)
        {
            try
            {
                db.Entry(category).State = EntityState.Modified;
                Logger log = new Logger();
                log.Log("Category updated in database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during updating category in database\nException: " + ex.ToString());
            }
            
        }
        public async Task Delete(int id)
        {
            try
            {
                Category category = await db.T_Category.FindAsync(id);
                if (category != null)
                {
                    db.T_Category.Remove(category);
                }
                Logger log = new Logger();
                log.Log("Category deleted from database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during deleting category from database\nException: " + ex.ToString());
            }
            
        }
    }
}
