using Jysk.BLL.DTO;
using Jysk.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/WorkHours")]
public class WorkHoursController : ControllerBase
{
    private readonly IWorkHoursService db;
    public WorkHoursController(IWorkHoursService db)
    {
        this.db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WorkHoursDTO>>> GetAllWorkHours()
    {
        return new ObjectResult(await db.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<WorkHoursDTO>> GetWorkHours(int id)
    {
        var res = await db.GetById(id);
        if (res == null)
        {
            return NotFound();
        }
        return new ObjectResult(res);
    }
    [HttpPut]
    public async Task<ActionResult<WorkHoursDTO>> PutWorkHours(WorkHoursDTO workHours)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Update(workHours);
        return Ok(workHours);
    }
    [HttpPost]
    public async Task<ActionResult<WorkHoursDTO>> PostWorkHours(WorkHoursDTO workHours)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Create(workHours);
        return Ok(workHours);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<WorkHoursDTO>> DeleteWorkHours(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Delete(id);
        return Ok(id);
    }
}