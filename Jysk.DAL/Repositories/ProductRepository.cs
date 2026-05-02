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
    public class ProductRepository : IRepository<Product>
    {
        private JyskContext db;
        public ProductRepository(JyskContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await db.T_Product.Include(o => o.Manufacturer).Include(o=>o.Category).ToListAsync();
        }
        public async Task<Product> Get(int id)
        {
            var list = await db.T_Product.Include(o => o.Manufacturer).Include(o => o.Category).Where(a => a.Id == id).ToListAsync();
            Product product = list.FirstOrDefault();
            if (product == null)
            {
                Logger log = new Logger();
                log.Log("Error: Product doesnt exist");
            }
            return product;
        }
        public async Task Create(Product product)
        {
            try
            {
                await db.T_Product.AddAsync(product);
                Logger log = new Logger();
                log.Log("Product added into database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during adding product into database\nException: " + ex.ToString());
            }
            
        }
        public void Update(Product product)
        {
            try
            {
                db.Entry(product).State = EntityState.Modified;
                Logger log = new Logger();
                log.Log("Product updated in database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during updating product in database\nException: " + ex.ToString());
            }
            
        }
        public async Task Delete(int id)
        {
            try
            {
                Product product = await db.T_Product.FindAsync(id);
                if (product != null)
                {
                    db.T_Product.Remove(product);
                }
                Logger log = new Logger();
                log.Log("Product deleted from database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during deleting product from database\nException: " + ex.ToString());
            }
            
        }
    }
}
