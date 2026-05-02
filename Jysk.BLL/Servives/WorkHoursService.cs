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
    public class WorkHoursService : IWorkHoursService
    {
        private IUnitOfWork db { get; set; }
        public WorkHoursService(IUnitOfWork db) 
        {
            this.db = db; 
        }
        public async Task Create(WorkHoursDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: WorkHours creation had null entity");
                }
                else
                {
                    var res = new WorkHours
                    {
                        Id = entity.Id,
                        Day = entity.Day,
                        Start = entity.Start,
                        End = entity.End,
                    };
                    await db.R_WorkHours.Create(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("WorkHours added successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during WorkHours creation\nException: " + ex.ToString());
            }
        }
        public async Task Update(WorkHoursDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    Logger log = new Logger();
                    log.Log("Error: WorkHours update had null entity");
                }
                else
                {
                    var res = new WorkHours
                    {
                        Id = entity.Id,
                        Day = entity.Day,
                        Start = entity.Start,
                        End = entity.End,
                    };
                    db.R_WorkHours.Update(res);
                    await db.Save();
                    Logger log = new Logger();
                    log.Log("WorkHours updated successfully");
                }
            }
            catch (Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during WorkHours update\nException: " + ex.ToString());
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                await db.R_WorkHours.Delete(id);
                await db.Save();
                Logger log = new Logger();
                log.Log("WorkHours deleted successfully");
            }
            catch(Exception ex)
            {
                Logger log = new Logger();
                log.Log("Error: Exception during WorkHours delete\nException: " + ex.ToString());
            }
        }
        public async Task<WorkHoursDTO> GetById(int id)
        {
            var res = await db.R_WorkHours.Get(id);
            if (res == null)
            {
                Logger log = new Logger();
                log.Log("Error: GetById WorkHours doesnt exist");
                throw new ValidationException("WorkHours doesnt exist", "");
            }
            return new WorkHoursDTO
            {
                Id = res.Id,
                Day = res.Day,
                Start = res.Start,
                End = res.End,
            };
        }
        public async Task<IEnumerable<WorkHoursDTO>> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<WorkHours, WorkHoursDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<IEnumerable<WorkHours>, IEnumerable<WorkHoursDTO>>(await db.R_WorkHours.GetAll());
        }
    }
}
