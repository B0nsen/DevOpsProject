using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Jysk.BLL.DTO;
using Jysk.BLL.Interfaces;
using Jysk.DAL.Entities;
using Jysk.DAL.Interfaces;
using Jysk.BLL.Infrastructure;
using LoggerLib;
using AutoMapper;

namespace Jysk.BLL.Servives
{
    public class ProductService : IProductService
    {
        private IUnitOfWork db { get; set; }
        public ProductService(IUnitOfWork db)
        {
            this.db = db;
        }
        public async Task Create(ProductDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Product creation had null entity");
                }
                else
                {
                    var res = new Product
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Description = entity.Description,
                        Price = entity.Price,
                        Rating = entity.Rating,
                        Delivery = entity.Delivery,
                        ManufacturerId = entity.ManufacturerId,
                        CategoryId = entity.CategoryId,
                        Discount = entity.Discount,
                        Photo = entity.Photo
                    };
                    await db.R_Product.Create(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Product added successfully");
                }
            }
            catch (Exception ex)
            {
                {
                    Logger log = new Logger();
                    log.Log("Error: Exception during product creation\nException: " + ex.ToString());
                }
            }
        }
        public async Task Update(ProductDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Product update had null entity");
                }
                else
                {
                    var res = new Product
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Description = entity.Description,
                        Price = entity.Price,
                        Rating = entity.Rating,
                        Delivery = entity.Delivery,
                        ManufacturerId = entity.ManufacturerId,
                        CategoryId = entity.CategoryId,
                        Discount = entity.Discount,
                        Photo = entity.Photo
                    };
                    db.R_Product.Update(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Product updated successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during product update\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                await db.R_Product.Delete(id);
                await db.Save();
                Logger log = new Logger();
                log.Log("Product deleted successfully");
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during product update\nException: " + ex.ToString());
            }
        }
        public async Task<ProductDTO> GetById(int id)
        {
            var res = await db.R_Product.Get(id);
            if (res == null)
            {
                Logger log = new Logger();
                log.Log("Error: GetById Product doesnt exist");
                throw new ValidationException("Cargo doesnt exist", "");
            }
            return new ProductDTO
            {
                Id = res.Id,
                Name = res.Name,
                Description = res.Description,
                Price = res.Price,
                Rating = res.Rating,
                Delivery = res.Delivery,
                ManufacturerId = res.ManufacturerId,
                Manufacturer = res.Manufacturer.Name,
                CategoryId = res.CategoryId,
                Category = res.Category.Name,
                Discount = res.Discount,
                Photo = res.Photo
            };
        }
        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()
            .ForMember("Manufacturer", opt => opt.MapFrom(c => c.Manufacturer.Name))
            .ForMember("Category", opt => opt.MapFrom(c => c.Category.Name)));
            var mapper = new Mapper(config);
            var test = await db.R_Product.Get(1);
            //Console.WriteLine(test.Manufacturer.Name);
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(await db.R_Product.GetAll());
        }
    }
}
