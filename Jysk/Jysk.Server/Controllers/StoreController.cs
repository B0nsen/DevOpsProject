using Jysk.BLL.DTO;
using Jysk.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/Store")]
public class StoreController : ControllerBase
{
    private readonly IStoreService db;
    public StoreController(IStoreService db)
    {
        this.db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StoreDTO>>> GetAllStore()
    {
        return new ObjectResult(await db.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<StoreDTO>> GetStore(int id)
    {
        var res = await db.GetById(id);
        if (res == null)
        {
            return NotFound();
        }
        return new ObjectResult(res);
    }
    [HttpPut]
    public async Task<ActionResult<StoreDTO>> PutStore(StoreDTO store)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Update(store);
        return Ok(store);
    }
    [HttpPost]
    public async Task<ActionResult<StoreDTO>> PostStore(StoreDTO store)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Create(store);
        return Ok(store);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<StoreDTO>> DeleteStore(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Delete(id);
        return Ok(id);
    }
}