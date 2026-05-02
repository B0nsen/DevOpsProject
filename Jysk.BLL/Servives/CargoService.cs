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
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Jysk.BLL.Servives
{
    public class CargoService : ICargoService
    {
        private IUnitOfWork db { get; set; }
        public CargoService(IUnitOfWork db)
        {
            this.db = db;
        }
        public async Task Create(CargoDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Cargo creation had null entity");
                }
                else
                {
                    var res = new Cargo
                    {
                        Id = entity.Id,
                        Count = entity.Count,
                        EmployeeId = entity.EmployeeId,
                        ProductId = entity.ProductId,
                        StorageFromId = entity.StorageFromId,
                        StorageToId = entity.StorageToId
                    };
                    await db.R_Cargo.Create(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Cargo added successfully");
                }  
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during cargo creation\nException: " + ex.ToString());
            }
        }
        public async Task Update(CargoDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Cargo update had null entity");
                }
                else
                {
                    var res = new Cargo
                    {
                        Id = entity.Id,
                        Count = entity.Count,
                        EmployeeId = entity.EmployeeId,
                        ProductId = entity.ProductId,
                        StorageFromId = entity.StorageFromId,
                        StorageToId = entity.StorageToId
                    };
                    db.R_Cargo.Update(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Cargo updated successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during cargo update\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                await db.R_Cargo.Delete(id);
                await db.Save();
                Logger log = new Logger();
                log.Log("Cargo deleted successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during cargo delete\nException: " + ex.ToString());
            }
        }
        public async Task<CargoDTO> GetById(int id)
        {
            var res = await db.R_Cargo.Get(id);
            if(res == null)
            {
                Logger log = new Logger();
                log.Log("Error: GetById Cargo doesnt exist");
                throw new ValidationException("Cargo doesnt exist", "");
            }
            return new CargoDTO
            {
                Id = res.Id,
                Count = res.Count,
                EmployeeId = res.EmployeeId,
                ProductId = res.ProductId,
                StorageFromId = res.StorageFromId,
                StorageToId = res.StorageToId,
                StorageFrom = res.StorageFrom.Name,
                StorageTo = res.StorageTo.Name,
                Product = res.Product.Name,
                Employee = res.Employee.User.Name
            };
        }
        public async Task<IEnumerable<CargoDTO>> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Cargo, CargoDTO>()
            .ForMember("Product", opt => opt.MapFrom(c => c.Product.Name))
            .ForMember("StorageFrom", opt => opt.MapFrom(c => c.StorageFrom.Name))
            .ForMember("StorageTo", opt => opt.MapFrom(c => c.StorageTo.Name))
            .ForMember("Employee", opt => opt.MapFrom(c=>c.Employee.User.Name)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Cargo>, IEnumerable<CargoDTO>>(await db.R_Cargo.GetAll());
        }
    }
}
