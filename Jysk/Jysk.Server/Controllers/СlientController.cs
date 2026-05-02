using Jysk.BLL.DTO;
using Jysk.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/Client")]
public class ClientController : ControllerBase
{
    private readonly IClientService db;
    public ClientController(IClientService db)
    {
        this.db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDTO>>> GetAllClient()
    {
        return new ObjectResult(await db.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ClientDTO>> GetClient(int id)
    {
        var res = await db.GetById(id);
        if (res == null)
        {
            return NotFound();
        }
        return new ObjectResult(res);
    }
    [HttpPut]
    public async Task<ActionResult<ClientDTO>> PutClient(ClientDTO client)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Update(client);
        return Ok(client);
    }
    [HttpPost]
    public async Task<ActionResult<ClientDTO>> PostClient(ClientDTO client)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Create(client);
        return Ok(client);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<ClientDTO>> DeleteClient(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Delete(id);
        return Ok(id);
    }
}