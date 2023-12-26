using Feedback.Web.Interfaces.DomainServices;
using Feedback.Web.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Feedback.Web.Controller;

[ApiController]
[Route("api/[controller]")]

public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;
    
    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }
    
    [HttpPost("submit-review")]
    public async Task<IActionResult> CreateReview([FromBody] ReviewDto dto)
    {
        await _reviewService.SubmitReviewAsync(dto);
        return Ok();
    }
    
    [HttpGet("get-orders")]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _reviewService.GetOrders();
        return Ok(orders);
    }
    
}