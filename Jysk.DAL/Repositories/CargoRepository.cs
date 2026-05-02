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
    public class CargoRepository : IRepository<Cargo>
    {
        private JyskContext db;
        public CargoRepository(JyskContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Cargo>> GetAll()
        {
            return await db.T_Cargo.Include(o => o.Product).Include(o => o.StorageFrom).Include(o => o.StorageTo).Include(o => o.Employee).Include(o => o.Employee.User).ToListAsync();
        }
        public async Task<Cargo> Get(int id)
        {
            var list = await db.T_Cargo.Include(o => o.Product).Include(o => o.StorageFrom).Include(o => o.StorageTo).Include(o => o.Employee).Include(o => o.Employee.User).Where(a => a.Id == id).ToListAsync();
            Cargo cargo = list.FirstOrDefault();
            if (cargo == null)
            {
                Logger log = new Logger();
                log.Log("Error: Cargo doesnt exist");
            }
            return cargo;
        }
        public async Task Create(Cargo cargo)
        {
            try
            {
                await db.T_Cargo.AddAsync(cargo);
                Logger log = new Logger();
                log.Log("Cargo added into database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during adding cargo into database\nException: " + ex.ToString());
            }
        }
        public void Update(Cargo cargo)
        {
            try
            {
                db.Entry(cargo).State = EntityState.Modified;
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
                Cargo cargo = await db.T_Cargo.FindAsync(id);
                if (cargo != null)
                {
                    db.T_Cargo.Remove(cargo);
                }
                Logger log = new Logger();
                log.Log("Cargo deleted from database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during deleting cargo from database\nException: " + ex.ToString());
            }
        }
    }
}
