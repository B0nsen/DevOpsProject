using Jysk.BLL.DTO;
using Jysk.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/Employee")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService db;
    public EmployeeController(IEmployeeService db)
    {
        this.db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployee()
    {
        return new ObjectResult(await db.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
    {
        var res = await db.GetById(id);
        if (res == null)
        {
            return NotFound();
        }
        return new ObjectResult(res);
    }
    [HttpPut]
    public async Task<ActionResult<EmployeeDTO>> PutEmployee(EmployeeDTO employee)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Update(employee);
        return Ok(employee);
    }
    [HttpPost]
    public async Task<ActionResult<EmployeeDTO>> PostEmployee(EmployeeDTO employee)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Create(employee);
        return Ok(employee);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<EmployeeDTO>> DeleteEmployee(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Delete(id);
        return Ok(id);
    }
}