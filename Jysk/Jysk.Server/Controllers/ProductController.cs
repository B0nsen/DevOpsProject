using Jysk.BLL.DTO;
using Jysk.BLL.Interfaces;
using Jysk.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/Product")]
public class ProductController : ControllerBase
{
    private readonly IProductService db;
    public ProductController(IProductService db)
    {
        this.db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProduct()
    {
        return new ObjectResult(await db.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetProduct(int id)
    {
        var res = await db.GetById(id);
        if (res == null)
        {
            return NotFound();
        }
        return new ObjectResult(res);
    }
    [HttpPut]
    public async Task<ActionResult<ProductDTO>> PutProduct(ProductDTO product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Update(product);
        return Ok(product);
    }
    [HttpPost]
    public async Task<ActionResult<ProductDTO>> PostProduct(ProductDTO product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Create(product);
        return Ok(product);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<ProductDTO>> DeleteProduct(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Delete(id);
        return Ok(id);
    }
}