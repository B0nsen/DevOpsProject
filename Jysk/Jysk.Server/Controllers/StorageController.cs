using Jysk.BLL.DTO;
using Jysk.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/Storage")]
public class StorageController : ControllerBase
{
    private readonly IStorageService db;
    public StorageController(IStorageService db)
    {
        this.db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StorageDTO>>> GetAllStorage()
    {
        return new ObjectResult(await db.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<StorageDTO>> GetStorage(int id)
    {
        var res = await db.GetById(id);
        if (res == null)
        {
            return NotFound();
        }
        return new ObjectResult(res);
    }
    [HttpPut]
    public async Task<ActionResult<StorageDTO>> PutStorage(StorageDTO storage)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Update(storage);
        return Ok(storage);
    }
    [HttpPost]
    public async Task<ActionResult<StorageDTO>> PostStorage(StorageDTO storage)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Create(storage);
        return Ok(storage);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<StorageDTO>> DeleteStorage(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Delete(id);
        return Ok(id);
    }
}