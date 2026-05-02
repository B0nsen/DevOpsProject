using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Jysk.BLL.DTO;
using Jysk.BLL.Infrastructure;
using Jysk.BLL.Interfaces;
using Jysk.DAL.Entities;
using Jysk.DAL.Interfaces;
using LoggerLib;

namespace Jysk.BLL.Servives
{
    public class UserService : IUserService
    {
        private IUnitOfWork db { get; set; }
        public UserService(IUnitOfWork db)
        {
            this.db = db;
        }
        public async Task Create(UserDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: User creation had null entity");
                }
                else
                {
                    var res = new User
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Email = entity.Email,
                        Password = entity.Password,
                        Surname = entity.Surname,
                        Phone = entity.Phone
                    };
                    await db.R_User.Create(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("User added successfully");
                }
            }
            catch(Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during user creation\nException: " + ex.ToString());
            }
        }
        public async Task Update(UserDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: User update had null entity");
                }
                else
                {
                    var res = new User
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Email = entity.Email,
                        Password = entity.Password,
                        Surname = entity.Surname,
                        Phone = entity.Phone
                    };
                    db.R_User.Update(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("User updated successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during user update\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                await db.R_User.Delete(id);
                await db.Save();
                Logger log = new Logger();
                log.Log("User deleted successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during user delete\nException: " + ex.ToString());
            }
        }
        public async Task<UserDTO> GetById(int id)
        {
            var res = await db.R_User.Get(id);
            if (res == null)
            {
                Logger log = new Logger();
                log.Log("Error: GetById Cargo doesnt exist");
                throw new ValidationException("Cargo doesnt exist", "");
            }
            return new UserDTO
            {
                Id = res.Id,
                Name = res.Name,
                Email = res.Email,
                Password = res.Password,
                Surname = res.Surname,
                Phone = res.Phone
            };
        }
        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User,UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(await db.R_User.GetAll());
        }
    }
}
