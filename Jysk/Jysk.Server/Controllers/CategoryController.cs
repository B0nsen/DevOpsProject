using Jysk.BLL.DTO;
using Jysk.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/Category")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService db;
    public CategoryController(ICategoryService db)
    {
        this.db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategory()
    {
        return new ObjectResult(await db.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
    {
        var res = await db.GetById(id);
        if (res == null)
        {
            return NotFound();
        }
        return new ObjectResult(res);
    }
    [HttpPut]
    public async Task<ActionResult<CategoryDTO>> PutCategory(CategoryDTO category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Update(category);
        return Ok(category);
    }
    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> PostCategory(CategoryDTO category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Create(category);
        return Ok(category);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<CategoryDTO>> DeleteCategory(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Delete(id);
        return Ok(id);
    }
}