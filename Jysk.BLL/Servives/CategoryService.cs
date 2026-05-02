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
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork db { get; set; }
        public CategoryService(IUnitOfWork db)
        {
            this.db = db;
        }

        public async Task Create(CategoryDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Category creation had null entity");
                }
                else
                {
                    var res = new Category
                    {
                        Id = entity.Id,
                        Name = entity.Name
                    };
                    await db.R_Category.Create(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Category added successfully");
                }
            }
            catch(Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during category creation\nException: " + ex.ToString());
            }
        }

        public async Task Update(CategoryDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: Category creation had null entity");
                }
                else
                {
                    var res = new Category
                    {
                        Id = entity.Id,
                        Name = entity.Name
                    };
                    db.R_Category.Update(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("Category updated successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during category update\nException: " + ex.ToString());
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await db.R_Category.Delete(id);
                await db.Save();
                Logger log = new Logger();
                log.Log("Category deleted successfully");
            }
            catch(Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during category delete\nException: " + ex.ToString());
            }
        }
        public async Task<CategoryDTO> GetById(int id)
        {
            var res = await db.R_Category.Get(id);
            if (res == null)
            {
                Logger log = new Logger();
                log.Log("Error: GetById Category doesnt exist");
                throw new ValidationException("Category doesnt exist", "");
            }
            return new CategoryDTO
            {
                Id = res.Id,
                Name = res.Name
            };
        }
        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(await db.R_Category.GetAll());
        }
    }
}
