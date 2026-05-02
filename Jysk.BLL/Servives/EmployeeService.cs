using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.DTO;
using Jysk.BLL.Interfaces;
using Jysk.BLL.Infrastructure;
using Jysk.DAL.Entities;
using Jysk.DAL.Interfaces;
using LoggerLib;
using AutoMapper;

namespace Jysk.BLL.Servives
{
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork db { get; set; }
        public EmployeeService(IUnitOfWork db)
        {
            this.db = db;
        }
        public async Task Create(EmployeeDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Employee creation had null entity");
                }
                else
                {
                    var res = new Employee
                    {
                        Id = entity.Id,
                        UserId = entity.UserId,
                        Position = entity.Position,
                        Comment = entity.Comment
                    };
                    await db.R_Employee.Create(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Employee created successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during employee creation\nException: " + ex.ToString());
            }
        }
        public async Task Update(EmployeeDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Employee update had null entity");
                }
                else
                {
                    var res = new Employee
                    {
                        Id = entity.Id,
                        UserId = entity.UserId,
                        Position = entity.Position,
                        Comment = entity.Comment
                    };
                    db.R_Employee.Update(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Employee updated successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during employee update\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                await db.R_Employee.Delete(id);
                await db.Save();
                Logger log = new Logger();
                log.Log("Employee added successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during employee delete\nException: " + ex.ToString());
            }
        }
        public async Task<EmployeeDTO> GetById(int id)
        {
            var res = await db.R_Employee.Get(id);
            if (res == null)
            {
                Logger log = new Logger();
                log.Log("Error: GetById Employee doesnt exist");
                throw new ValidationException("Employee doesnt exist", "");
            }
            return new EmployeeDTO
            {
                Id = res.Id,
                UserId = res.UserId,
                Position = res.Position,
                Comment = res.Comment,
                User = res.User.Name
            };
        }
        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()
            .ForMember("User", opt => opt.MapFrom(c => c.User.Name)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(await db.R_Employee.GetAll());
        }
    }
}
