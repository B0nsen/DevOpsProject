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
    public class WriteOffRepository : IRepository<WriteOff>
    {
        private JyskContext db;
        public WriteOffRepository(JyskContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<WriteOff>> GetAll()
        {
            return await db.T_WriteOff.Include(o => o.Employee).Include(o => o.Employee.User).Include(o => o.Product).Include(o => o.Storage).ToListAsync();
        }
        public async Task<WriteOff> Get(int id)
        {
            var list = await db.T_WriteOff.Include(o => o.Employee).Include(o => o.Employee.User).Include(o => o.Product).Include(o => o.Storage).Where(a => a.Id == id).ToListAsync();
            WriteOff writeOff = list.FirstOrDefault();
            if (writeOff == null)
            {
                Logger log = new Logger();
                log.Log("Error: WriteOff doesnt exist");
            }
            return writeOff;
        }
        public async Task Create(WriteOff writeOff)
        {
            try
            {
                await db.T_WriteOff.AddAsync(writeOff);
                Logger log = new Logger();
                log.Log("WriteOff added into database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during adding WriteOff into database\nException: " + ex.ToString());
            }
            
        }
        public void Update(WriteOff writeOff)
        {
            try
            {
                db.Entry(writeOff).State = EntityState.Modified;
                Logger log = new Logger();
                log.Log("WriteOff updated in database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during updating WriteOff in database\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                WriteOff writeOff = await db.T_WriteOff.FindAsync(id);
                if (writeOff != null)
                {
                    db.T_WriteOff.Remove(writeOff);
                }
                Logger log = new Logger();
                log.Log("WriteOff deleted from database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during deleting WriteOff from database\nException: " + ex.ToString());
            }
            
        }
    }
}
