using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.Interfaces;
using Jysk.BLL.Infrastructure;
using Jysk.DAL.Interfaces;
using Jysk.BLL.DTO;
using Jysk.DAL.Entities;
using LoggerLib;
using AutoMapper;

namespace Jysk.BLL.Servives
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork db { get; set; }
        public OrderService(IUnitOfWork db) 
        {
            this.db = db; 
        }
        public async Task Create(OrderDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Order creation had null entity");
                }
                else
                {
                    var res = new Order
                    {
                        Id = entity.Id,
                        ProductId = entity.ProductId,
                        Count = entity.Count,
                        ProductionPrice = entity.ProductionPrice,
                        FinalPrice = entity.FinalPrice,
                        MarkUp = entity.MarkUp,
                        UserId = entity.UserId
                    };
                    await db.R_Order.Create(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Order added successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during order creation\nException: " + ex.ToString());
            }
        }
        public async Task Update(OrderDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Order update had null entity");
                }
                else
                {
                    var res = new Order
                    {
                        Id = entity.Id,
                        ProductId = entity.ProductId,
                        Count = entity.Count,
                        ProductionPrice = entity.ProductionPrice,
                        FinalPrice = entity.FinalPrice,
                        MarkUp = entity.MarkUp,
                        UserId = entity.UserId
                    };
                    db.R_Order.Update(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Order updated successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during order update\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                await db.R_Order.Delete(id);
                await db.Save();
                Logger log = new Logger();
                log.Log("Order deleted successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during order delete\nException: " + ex.ToString());
            }
        }
        public async Task<OrderDTO> GetById(int id)
        {
            var res = await db.R_Order.Get(id);
            if (res == null)
            {
                Logger log = new Logger();
                log.Log("Error: GetById Order doesnt exist");
                throw new ValidationException("Order doesnt exist", "");
            }
            return new OrderDTO
            {
                Id = res.Id,
                ProductId = res.ProductId,
                Count = res.Count,
                Product = res.Product.Name,
                ProductionPrice = res.ProductionPrice,
                FinalPrice = res.FinalPrice,
                MarkUp = res.MarkUp,
                UserId = res.UserId,
                User = res.User.Name
            };
        }
        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()
            .ForMember("User", opt => opt.MapFrom(c => c.User.Name))
            .ForMember("Product", opt => opt.MapFrom(c => c.Product.Name)));
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(await db.R_Order.GetAll());
        }
    }
}
