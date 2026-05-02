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
    public class EmployeeRepository : IRepository<Employee>
    {
        private JyskContext db;
        public EmployeeRepository(JyskContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await db.T_Employee.Include(o=>o.User).ToListAsync();
        }
        public async Task<Employee> Get(int id)
        {
            var list = await db.T_Employee.Include(o => o.User).Where(a => a.Id == id).ToListAsync();
            Employee employee = list.FirstOrDefault();
            if (employee == null)
            {
                Logger log = new Logger();
                log.Log("Error: Employee doesnt exist");
            }
            return employee;
        }
        public async Task Create(Employee employee)
        {
            try
            {
                await db.T_Employee.AddAsync(employee);
                Logger log = new Logger();
                log.Log("Employee added into database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during adding employee into database\nException: " + ex.ToString());
            }
            
        }
        public void Update(Employee employee)
        {
            try
            {
                db.Entry(employee).State = EntityState.Modified;
                Logger log = new Logger();
                log.Log("Employee updated in database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during updating employee in database\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                Employee employee = await db.T_Employee.FindAsync(id);
                if (employee != null)
                {
                    db.T_Employee.Remove(employee);
                }
                Logger log = new Logger();
                log.Log("Employee deleted from database successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during deleting employee from database\nException: " + ex.ToString());
            }
        }
    }
}
