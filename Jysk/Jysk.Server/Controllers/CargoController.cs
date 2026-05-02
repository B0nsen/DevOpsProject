using Jysk.BLL.DTO;
using Jysk.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/Cargo")]
public class CargoController : ControllerBase
{
    private readonly ICargoService db;
    public CargoController(ICargoService db)
    {
        this.db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CargoDTO>>> GetAllCargo()
    {
        return new ObjectResult(await db.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<CargoDTO>> GetCargo(int id)
    {
        var res = await db.GetById(id);
        if (res == null)
        {
            return NotFound();
        }
        return new ObjectResult(res);
    }
    [HttpPut]
    public async Task<ActionResult<CargoDTO>> PutCargo(CargoDTO cargo)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Update(cargo);
        return Ok(cargo);
    }
    [HttpPost]
    public async Task<ActionResult<CargoDTO>> PostCargo(CargoDTO cargo)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Create(cargo);
        return Ok(cargo);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<CargoDTO>> DeleteCargo(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Delete(id);
        return Ok(id);
    }
}