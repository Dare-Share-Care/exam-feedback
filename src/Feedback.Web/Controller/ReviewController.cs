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
    
    [HttpPost("create-review")]
    public async Task<IActionResult> CreateReview([FromBody] ReviewDto dto)
    {
        var review = await _reviewService.CreateReviewAsync(dto);
        return Ok(review);
    }
    
    [HttpGet("get-orders")]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _reviewService.GetOrders();
        return Ok(orders);
    }
    
}