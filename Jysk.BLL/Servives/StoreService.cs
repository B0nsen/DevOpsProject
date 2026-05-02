using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerLib;
using Jysk.BLL.Infrastructure;
using Jysk.BLL.Interfaces;
using Jysk.DAL.Interfaces;
using Jysk.BLL.DTO;
using Jysk.DAL.Entities;
using AutoMapper;
using System.Runtime.CompilerServices;

namespace Jysk.BLL.Servives
{
    public class StoreService : IStoreService
    {
        private IUnitOfWork db { get; set; }
        public StoreService(IUnitOfWork db)
        {
            this.db = db;
        }
        public async Task Create(StoreDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Store creation had null entity");
                }
                else
                {
                    var res = new Store
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        HouseNumber = entity.HouseNumber,
                        TotalProductSum = entity.TotalProductSum,
                        StorageId = entity.StorageId,
                        Photo = entity.Photo,
                        WorkHoursId = entity.WorkHoursId,
                    };
                    await db.R_Store.Create(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Store added successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during store creation\nException: " + ex.ToString());
            }
        }
        public async Task Update(StoreDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Store update had null entity");
                }
                else
                {
                    var res = new Store
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        HouseNumber = entity.HouseNumber,
                        TotalProductSum = entity.TotalProductSum,
                        StorageId = entity.StorageId,
                        Photo = entity.Photo,
                        WorkHoursId = entity.WorkHoursId,
                    };
                    db.R_Store.Update(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Store updated successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during store update\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                await db.R_Store.Delete(id);
                await db.Save();
                Logger log = new Logger();
                log.Log("Store deleted successfully");
            }
            catch (Exception ex) 
            {
                Logger log = new Logger();
                log.Log("Error: Exception during store delete\nException: " + ex.ToString());
            }
        }
        public async Task<StoreDTO> GetById(int id)
        {
            var res = await db.R_Store.Get(id);
            if (res == null)
            {
                Logger log = new Logger();
                log.Log("Error: GetById Store doesnt exist");
                throw new ValidationException("Store doesnt exist", "");
            }
            return new StoreDTO
            {
                Id = res.Id,
                Name = res.Name,
                HouseNumber = res.HouseNumber,
                TotalProductSum = res.TotalProductSum,
                StorageId = res.StorageId,
                Storage = res.Storage.Name,
                Photo = res.Photo,
                WorkHoursId = res.WorkHoursId,
                WorkHours = res.WorkHours.Start + "-" + res.WorkHours.End,
            };
        }
        public async Task<IEnumerable<StoreDTO>> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Store, StoreDTO>()
            .ForMember("Storage", opt => opt.MapFrom(c => c.Storage.Name))
            .ForMember("WorkHours", opt => opt.MapFrom(c => c.WorkHours.Start + "-" + c.WorkHours.End)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Store>, IEnumerable<StoreDTO>>(await db.R_Store.GetAll());
        }
    }
}
