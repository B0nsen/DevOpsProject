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
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Jysk.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private JyskContext db;
        public OrderRepository(JyskContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Order>> GetAll()
        {
            return await db.T_Order.Include(o => o.Product).Include(o => o.User).ToListAsync();
        }
        public async Task<Order> Get(int id)
        {
            var list = await db.T_Order.Include(o => o.Product).Include(o => o.User).Where(a => a.Id == id).ToListAsync();
            Order order = list.FirstOrDefault();
            if (order == null)
            {
                Logger log = new Logger();
                log.Log("Error: Order doesnt exist");
            }
            return order;
        }
        public async Task Create(Order order)
        {
            try
            {
                await db.T_Order.AddAsync(order);
                Logger log = new Logger();
                log.Log("Order added into database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during adding order into database\nException: " + ex.ToString());
            }
            
        }
        public void Update(Order order)
        {
            try
            {
                db.Entry(order).State = EntityState.Modified;
                Logger log = new Logger();
                log.Log("Order updated in database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during updating order in database\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                Order order = await db.T_Order.FindAsync(id);
                if (order != null)
                {
                    db.T_Order.Remove(order);
                }
                Logger log = new Logger();
                log.Log("Order deleted from database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during deleting order from database\nException: " + ex.ToString());
            }
            
        }
    }
}
