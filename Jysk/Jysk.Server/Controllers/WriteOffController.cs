using Jysk.BLL.DTO;
using Jysk.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/WriteOff")]
public class WriteOffController : ControllerBase
{
    private readonly IWriteOffService db;
    public WriteOffController(IWriteOffService db)
    {
        this.db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WriteOffDTO>>> GetAllWriteOff()
    {
        return new ObjectResult(await db.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<WriteOffDTO>> GetWriteOff(int id)
    {
        var res = await db.GetById(id);
        if (res == null)
        {
            return NotFound();
        }
        return new ObjectResult(res);
    }
    [HttpPut]
    public async Task<ActionResult<WriteOffDTO>> PutWriteOff(WriteOffDTO writeOff)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Update(writeOff);
        return Ok(writeOff);
    }
    [HttpPost]
    public async Task<ActionResult<WriteOffDTO>> PostWriteOff(WriteOffDTO writeOff)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Create(writeOff);
        return Ok(writeOff);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<WriteOffDTO>> DeleteWriteOff(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Delete(id);
        return Ok(id);
    }
}