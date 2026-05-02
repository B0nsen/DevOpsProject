using Jysk.BLL.DTO;
using Jysk.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/Delivery")]
public class DeliveryController : ControllerBase
{
    private readonly IDeliveryService db;
    public DeliveryController(IDeliveryService db)
    {
        this.db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DeliveryDTO>>> GetDelivery()
    {
        return new ObjectResult(await db.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<DeliveryDTO>> GetDelivery(int id)
    {
        var res = await db.GetById(id);
        if (res == null)
        {
            return NotFound();
        }
        return new ObjectResult(res);
    }
    [HttpPut]
    public async Task<ActionResult<DeliveryDTO>> PutDelivery(DeliveryDTO delivery)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Update(delivery);
        return Ok(delivery);
    }
    [HttpPost]
    public async Task<ActionResult<DeliveryDTO>> PostDelivery(DeliveryDTO delivery)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Create(delivery);
        return Ok(delivery);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<DeliveryDTO>> DeleteDelivery(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Delete(id);
        return Ok(id);
    }
}