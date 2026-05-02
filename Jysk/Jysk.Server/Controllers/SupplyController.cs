using Jysk.BLL.DTO;
using Jysk.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/Supply")]
public class SupplyController : ControllerBase
{
    private readonly ISupplyService db;
    public SupplyController(ISupplyService db)
    {
        this.db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SupplyDTO>>> GetAllSupply()
    {
        return new ObjectResult(await db.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<SupplyDTO>> GetSupply(int id)
    {
        var res = await db.GetById(id);
        if (res == null)
        {
            return NotFound();
        }
        return new ObjectResult(res);
    }
    [HttpPut]
    public async Task<ActionResult<SupplyDTO>> PutSupply(SupplyDTO supply)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Update(supply);
        return Ok(supply);
    }
    [HttpPost]
    public async Task<ActionResult<SupplyDTO>> PostSupply(SupplyDTO supply)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Create(supply);
        return Ok(supply);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<SupplyDTO>> DeleteSupply(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Delete(id);
        return Ok(id);
    }
}