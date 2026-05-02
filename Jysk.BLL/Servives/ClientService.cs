using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.DTO;
using Jysk.BLL.Interfaces;
using Jysk.DAL.Entities;
using Jysk.DAL.Interfaces;
using Jysk.BLL.Infrastructure;
using LoggerLib;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using AutoMapper;

namespace Jysk.BLL.Servives
{
    public class ClientService : IClientService
    {
        private IUnitOfWork db { get; set; }
        public ClientService(IUnitOfWork db)
        {
            this.db = db;
        }
        public async Task Create(ClientDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Client creation had null entity");
                }
                else
                {
                    var res = new Client
                    {
                        Id = entity.Id,
                        UserId = entity.UserId,
                        Address = entity.Address,
                        Sum = entity.Sum
                    };
                    await db.R_Client.Create(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Client created successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during client creation\nException: " + ex.ToString());
            }
        }
        public async Task Update(ClientDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Client update had null entity");
                }
                else
                {
                    var res = new Client
                    {
                        Id = entity.Id,
                        UserId = entity.UserId,
                        Address = entity.Address,
                        Sum = entity.Sum
                    };
                    db.R_Client.Update(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Client updated successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during client update\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                await db.R_Client.Delete(id);
                await db.Save();
                Logger log = new Logger();
                log.Log("Client deleted successfully");
            }
            catch(Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during client update\nException: " + ex.ToString());
            }
        }
        public async Task<ClientDTO> GetById(int id)
        {
            var res = await db.R_Client.Get(id);
            if (res == null)
            {
                Logger log = new Logger();
                log.Log("Error: GetById Client doesnt exist");
                throw new ValidationException("Client doesnt exist", "");
            }
            return new ClientDTO
            {
                Id = res.Id,
                User = res.User.Name,
                UserId = res.UserId,
                Address = res.Address,
                Sum = res.Sum
            };
        }
        public async Task<IEnumerable<ClientDTO>> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>()
            .ForMember("User", opt => opt.MapFrom(c => c.User.Name)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Client>, IEnumerable<ClientDTO>>(await db.R_Client.GetAll());
        }
    }
}
