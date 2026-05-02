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
    public class ManufacturerService : IManufacturerService
    {
        private IUnitOfWork db { get; set; }
        public ManufacturerService(IUnitOfWork db) 
        {
            this.db = db; 
        }
        public async Task Create(ManufacturerDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Manufacturer creation had null entity");
                }
                else
                {
                    var res = new Manufacturer
                    {
                        Id = entity.Id,
                        Name = entity.Name
                    };
                    await db.R_Manufacturer.Create(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Manufacturer added successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during manufacturer creation\nException: " + ex.ToString());
            }
        }
        public async Task Update(ManufacturerDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Manufacturer update had null entity");
                }
                else
                {
                    var res = new Manufacturer
                    {
                        Id = entity.Id,
                        Name = entity.Name
                    };
                    db.R_Manufacturer.Update(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Manufacturer updated successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during manufacturer update\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                await db.R_Manufacturer.Delete(id);
                await db.Save();
                Logger log = new Logger();
                log.Log("Manufacturer deleted successfully" + id);
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during manufacturer delete\nException: " + ex.ToString());
            }
        }
        public async Task<ManufacturerDTO> GetById(int id)
        {
            Logger log1 = new Logger();
            log1.Log("TEST" + id.ToString());
            var res = await db.R_Manufacturer.Get(id);
            if (res == null)
            {
                Logger log = new Logger();
                log.Log("Error: GetById Manufacturer doesnt exist");
                throw new ValidationException("Manufacturer doesnt exist", "");
            }
            return new ManufacturerDTO
            {
                Id = res.Id,
                Name = res.Name
            };
        }
        public async Task<IEnumerable<ManufacturerDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Manufacturer, ManufacturerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Manufacturer>, IEnumerable<ManufacturerDTO>>(await db.R_Manufacturer.GetAll());
        }
    }
}
