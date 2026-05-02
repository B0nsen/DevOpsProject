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
    public class WriteOffService : IWriteOffService
    {
        private IUnitOfWork db { get; set; }
        public WriteOffService(IUnitOfWork db) 
        {
            this.db = db; 
        }
        public async Task Create(WriteOffDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: WriteOff creation had null entity");
                }
                else
                {
                    var res = new WriteOff
                    {
                        Id = entity.Id,
                        Date = entity.Date,
                        EmployeeId = entity.EmployeeId,
                        StorageId = entity.StorageId,
                        ProductId = entity.ProductId,
                        Reason = entity.Reason,
                        Sum = entity.Sum
                    };
                    await db.R_WriteOff.Create(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("WriteOff added successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during WriteOff creation\nException: " + ex.ToString());
            }
        }
        public async Task Update(WriteOffDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: WriteOff update had null entity");
                }
                else
                {
                    var res = new WriteOff
                    {
                        Id = entity.Id,
                        Date = entity.Date,
                        EmployeeId = entity.EmployeeId,
                        StorageId = entity.StorageId,
                        ProductId = entity.ProductId,
                        Reason = entity.Reason,
                        Sum = entity.Sum
                    };
                    db.R_WriteOff.Update(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("WriteOff updated successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during WriteOff update\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                await db.R_WriteOff.Delete(id);
                await db.Save();
                Logger log = new Logger();
                log.Log("WriteOff deleted successfully");
            }
            catch(Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during WriteOff update\nException: " + ex.ToString());
            }
        }
        public async Task<WriteOffDTO> GetById(int id)
        {
            var res = await db.R_WriteOff.Get(id);
            if (res == null)
            {
                Logger log = new Logger();
                log.Log("Error: GetById Cargo doesnt exist");
                throw new ValidationException("Cargo doesnt exist", "");
            }
            return new WriteOffDTO
            {
                Id = res.Id,
                Date = res.Date,
                EmployeeId = res.EmployeeId,
                Employee = res.Employee.User.Name,
                StorageId = res.StorageId,
                Storage = res.Storage.Name,
                ProductId = res.ProductId,
                Product = res.Product.Name,
                Reason = res.Reason,
                Sum = res.Sum
            };
        }
        public async Task<IEnumerable<WriteOffDTO>> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<WriteOff,WriteOffDTO>()
            .ForMember("Employee", opt => opt.MapFrom(c => c.Employee.User.Name))
            .ForMember("Storage", opt => opt.MapFrom(c => c.Storage.Name))
            .ForMember("Product", opt => opt.MapFrom(c => c.Product.Name)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<WriteOff>, IEnumerable<WriteOffDTO>>(await db.R_WriteOff.GetAll());
        }
    }
}
