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
    public class UserRepository : IRepository<User>
    {
        private JyskContext db;
        public UserRepository(JyskContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await db.T_User.ToListAsync();
        }
        public async Task<User> Get(int id)
        {
            User user = await db.T_User.FindAsync(id);
            if (user == null)
            {
                Logger log = new Logger();
                log.Log("Error: User doesnt exist");
            }
            return user;
        }
        public async Task Create(User user)
        {
            try
            {
                await db.T_User.AddAsync(user);
                Logger log = new Logger();
                log.Log("User added into database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during adding user into database\nException: " + ex.ToString());
            }
            
        }
        public void Update(User user)
        {
            try
            {
                db.Entry(user).State = EntityState.Modified;
                Logger log = new Logger();
                log.Log("User updated in database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during updating user in database\nException: " + ex.ToString());
            }
            
        }
        public async Task Delete(int id)
        {
            try
            {
                User user = await db.T_User.FindAsync(id);
                if (user != null)
                {
                    db.T_User.Remove(user);
                }
                Logger log = new Logger();
                log.Log("User deleted from database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during deleting user from database\nException: " + ex.ToString());
            }
            
        }
    }
}
