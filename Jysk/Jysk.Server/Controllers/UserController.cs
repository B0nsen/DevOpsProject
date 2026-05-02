using Jysk.BLL.DTO;
using Jysk.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/User")]
public class UserController : ControllerBase
{
    private readonly IUserService db;
    public UserController(IUserService db)
    {
        this.db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUser()
    {
        return new ObjectResult(await db.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetUser(int id)
    {
        var res = await db.GetById(id);
        if (res == null)
        {
            return NotFound();
        }
        return new ObjectResult(res);
    }
    [HttpPut]
    public async Task<ActionResult<UserDTO>> PutUser(UserDTO user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Update(user);
        return Ok(user);
    }
    [HttpPost]
    public async Task<ActionResult<UserDTO>> PostUser(UserDTO user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Create(user);
        return Ok(user);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<UserDTO>> DeleteUser(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Delete(id);
        return Ok(id);
    }
}