using Jysk.BLL.DTO;
using Jysk.BLL.Interfaces;
using LoggerLib;
using Microsoft.AspNetCore.Mvc;

namespace Jysk.Server.Controllers
{
    [ApiController]
    [Route("api/Manufacturer")]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService db;
        public ManufacturerController(IManufacturerService db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManufacturerDTO>>> GetAllManufacturer()
        {
            return new ObjectResult(await db.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ManufacturerDTO>> GetManufacturer(int id)
        {
            var res = await db.GetById(id);
            if (res == null)
            {
                return NotFound();
            }
            return new ObjectResult(res);
        }
        [HttpPut]
        public async Task<ActionResult<ManufacturerDTO>> PutManufacturer(ManufacturerDTO manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Logger log = new Logger();
            log.Log(manufacturer.Id.ToString() + manufacturer.Name);
            await db.Update(manufacturer);
            return Ok(manufacturer);
        }
        [HttpPost]
        public async Task<ActionResult<ManufacturerDTO>> PostManufacturer(ManufacturerDTO manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await db.Create(manufacturer);
            return Ok(manufacturer);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ManufacturerDTO>> DeleteManufacturer(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await db.Delete(id);
            return Ok(id);
        }
    }
}
