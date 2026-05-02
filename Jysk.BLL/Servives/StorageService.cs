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
    public class StorageService : IStorageService
    {
        private IUnitOfWork db { get; set; }
        public StorageService(IUnitOfWork db) 
        {
            this.db = db; 
        }
        public async Task Create(StorageDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Storage creation had null entity");
                }
                else
                {
                    var res = new Storage
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Address = entity.Address,
                        Sum = entity.Sum,
                    };
                    await db.R_Storage.Create(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Storage added successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during storage creation\nException: " + ex.ToString());
            }
        }
        public async Task Update(StorageDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Storage update had null entity");
                }
                else
                {
                    var res = new Storage
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Address = entity.Address,
                        Sum = entity.Sum,
                    };
                    db.R_Storage.Update(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Storage updated successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during storage update\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                await db.R_Storage.Delete(id);
                await db.Save();
                Logger log = new Logger();
                log.Log("Storage deleted successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during storage delete\nException: " + ex.ToString());
            }
        }
        public async Task<StorageDTO> GetById(int id)
        {
            var res = await db.R_Storage.Get(id);
            if (res == null)
            {
                Logger log = new Logger();
                log.Log("Error: GetById Storage doesnt exist");
                throw new ValidationException("Storage doesnt exist", "");
            }
            return new StorageDTO
            {
                Id = res.Id,
                Name = res.Name,
                Address = res.Address,
                Sum = res.Sum,
            };
        }
        public async Task<IEnumerable<StorageDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Storage, StorageDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Storage>, IEnumerable<StorageDTO>>(await db.R_Storage.GetAll());
        }
    }
}
