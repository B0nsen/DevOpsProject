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
    public class SupplyService : ISupplyService
    {
        private IUnitOfWork db { get; set; }
        public SupplyService(IUnitOfWork db)
        {
            this.db = db;
        }
        public async Task Create(SupplyDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Supply creation had null entity");
                }
                else
                {
                    var res = new Supply
                    {
                        Id = entity.Id,
                        ProductId = entity.ProductId,
                        Count = entity.Count
                    };
                    Logger log = new Logger();
                    log.Log("Supply added successfully" + entity.Id + " " + entity.ProductId + " " + entity.Count);
                    await db.R_Supply.Create(res);
                    await db.Save();
                    
                    
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during supply creation\nException: " + ex.ToString());
            }
        }
        public async Task Update(SupplyDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Supply update had null entity");
                }
                else
                {
                    var res = new Supply
                    {
                        Id = entity.Id,
                        ProductId = entity.ProductId,
                        Count = entity.Count
                    };
                    db.R_Supply.Update(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Supply updated successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during supply update\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                await db.R_Supply.Delete(id);
                await db.Save();
                Logger log = new Logger();
                log.Log("Supply deleted successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during supply delete\nException: " + ex.ToString());
            }
        }
        public async Task<SupplyDTO> GetById(int id)
        {
            var res = await db.R_Supply.Get(id);
            if (res == null)
            {
                Logger log = new Logger();
                log.Log("Error: GetById Supply doesnt exist");
                throw new ValidationException("Supply doesnt exist", "");
            }
                return new SupplyDTO
                {
                    Id = res.Id,
                    ProductId = res.ProductId,
                    Count = res.Count,
                    Product = res.Product.Name
                };
        }
        public async Task<IEnumerable<SupplyDTO>> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Supply, SupplyDTO>()
            .ForMember("Product", opt => opt.MapFrom(c => c.Product.Name)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Supply>, IEnumerable<SupplyDTO>>(await db.R_Supply.GetAll());
        }
    }
}
