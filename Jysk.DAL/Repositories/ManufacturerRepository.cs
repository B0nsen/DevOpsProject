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
    public class ManufacturerRepository : IRepository<Manufacturer>
    {
        private JyskContext db;
        public ManufacturerRepository(JyskContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Manufacturer>> GetAll()
        {
            return await db.T_Manufacturer.ToListAsync();
        }
        public async Task<Manufacturer> Get(int id)
        {
            Manufacturer manufacturer = await db.T_Manufacturer.FindAsync(id);
            if (manufacturer == null)
            {
                Logger log = new Logger();
                log.Log("Error: Manufacturer doesnt exist " + id);
            }
            return manufacturer;
        }
        public async Task Create(Manufacturer manufacturer)
        {
            try
            {
                await db.T_Manufacturer.AddAsync(manufacturer);
                Logger log = new Logger();
                log.Log("Manufacturer added into database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during adding manufacturer into database\nException: " + ex.ToString());
            }
        }
        public void Update(Manufacturer manufacturer)
        {
            try
            {
                db.Entry(manufacturer).State = EntityState.Modified;
                Logger log = new Logger();
                log.Log("Manufacturer updated in database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during updating manufacturer in database\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                Manufacturer manufacturer = await db.T_Manufacturer.FindAsync(id);
                if (manufacturer != null)
                {
                    db.T_Manufacturer.Remove(manufacturer);
                }
                Logger log = new Logger();
                log.Log("Manufacturer deleted from database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during deleting manufacturer from database\nException: " + ex.ToString());
            }
        }
    }
}
