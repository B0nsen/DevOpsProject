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
    public class DeliveryRepository : IRepository<Delivery>
    {
        private JyskContext db;
        public DeliveryRepository(JyskContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Delivery>> GetAll()
        {
            return await db.T_Delivery.Include(o => o.Storage).Include(o => o.Manufacturer).ToListAsync();
        }
        public async Task<Delivery> Get(int id)
        {
            var list = await db.T_Delivery.Include(o => o.Storage).Include(o => o.Manufacturer).Where(a => a.Id == id).ToListAsync();
            Delivery delivery = list.FirstOrDefault();
            if (delivery == null)
            {
                Logger log = new Logger();
                log.Log("Error: Delivery doesnt exist");
            }
            return delivery;
        }
        public async Task Create(Delivery delivery)
        {
            try
            {
                await db.T_Delivery.AddAsync(delivery);
                Logger log = new Logger();
                log.Log("Delivery added into database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during adding delivery into database\nException: " + ex.ToString());
            }
            
        }
        public void Update(Delivery delivery)
        {
            try
            {
                db.Entry(delivery).State = EntityState.Modified;
                Logger log = new Logger();
                log.Log("Cargo updated in database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during updating cargo in database\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                Delivery delivery = await db.T_Delivery.FindAsync(id);
                if (delivery != null)
                {
                    db.T_Delivery.Remove(delivery);
                }
                Logger log = new Logger();
                log.Log("Delivery deleted from database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during deleting delivery from database\nException: " + ex.ToString());
            }
        }
    }
}
