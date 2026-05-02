using Jysk.BLL.DTO;
using Jysk.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/Review")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService db;
    public ReviewController(IReviewService db)
    {
        this.db = db;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAllReview()
    {
        return new ObjectResult(await db.GetAll());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewDTO>> GetReview(int id)
    {
        var res = await db.GetById(id);
        if (res == null)
        {
            return NotFound();
        }
        return new ObjectResult(res);
    }
    [HttpPut]
    public async Task<ActionResult<ReviewDTO>> PutReview(ReviewDTO review)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Update(review);
        return Ok(review);
    }
    [HttpPost]
    public async Task<ActionResult<ReviewDTO>> PostReview(ReviewDTO review)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Create(review);
        return Ok(review);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<ReviewDTO>> DeleteReview(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await db.Delete(id);
        return Ok(id);
    }
}