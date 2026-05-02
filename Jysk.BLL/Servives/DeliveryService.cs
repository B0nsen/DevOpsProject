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
    public class DeliveryService : IDeliveryService
    {
        private IUnitOfWork db { get; set; }
        public DeliveryService(IUnitOfWork db)
        {
            this.db = db;
        }
        public async Task Create(DeliveryDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Delivery creation had null entity");
                }
                else
                {
                    var res = new Delivery
                    {
                        Id = entity.Id,
                        StorageId = entity.StorageId,
                        Date = entity.Date,
                        Comment = entity.Comment,
                        Status = entity.Status,
                        Sum = entity.Sum,
                        ManufacturerId = entity.ManufacturerId
                    };
                    await db.R_Delivery.Create(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Delivery added successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during delivery creation\nException: " + ex.ToString());
            }
        }
        public async Task Update(DeliveryDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Delivery update had null entity");
                }
                else
                {
                    var res = new Delivery
                    {
                        Id = entity.Id,
                        StorageId = entity.StorageId,
                        Date = entity.Date,
                        Comment = entity.Comment,
                        Status = entity.Status,
                        Sum = entity.Sum,
                        ManufacturerId = entity.ManufacturerId
                    };
                    db.R_Delivery.Update(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Delivery updated successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during delivery update\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                await db.R_Delivery.Delete(id);
                await db.Save();
                Logger log = new Logger();
                log.Log("Delivery deleted successfully");
            }
            catch(Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during delivery delete\nException: " + ex.ToString());
            }
        }
        public async Task<DeliveryDTO> GetById(int id)
        {
            var res = await db.R_Delivery.Get(id);
            if (res == null)
            {
                Logger log = new Logger();
                log.Log("Error: GetById Delivery doesnt exist");
                throw new ValidationException("Cargo doesnt exist", "");
            }
            return new DeliveryDTO
            {
                Id = res.Id,
                Status = res.Status,
                Sum = res.Sum,
                StorageId = res.StorageId,
                Storage = res.Storage.Name,
                Comment = res.Comment,
                Date = res.Date,
                Manufacturer = res.Manufacturer.Name,
                ManufacturerId = res.ManufacturerId,
            };
        }
        public async Task<IEnumerable<DeliveryDTO>> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Delivery, DeliveryDTO>()
            .ForMember("Storage", opt => opt.MapFrom(c => c.Storage.Name))
            .ForMember("Manufacturer", opt => opt.MapFrom(c => c.Manufacturer.Name)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Delivery>, IEnumerable<DeliveryDTO>>(await db.R_Delivery.GetAll());
        }
    }
}
