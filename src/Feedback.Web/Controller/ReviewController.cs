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
    
    
    [HttpGet("get-all-reviews")]
    public async Task<IActionResult> GetAllReviews()
    {
        var reviews = await _reviewService.GetAllReviewsAsync();
        return Ok(reviews);
    }
    
    [HttpGet("get-review-by-id/{id}")]
    public async Task<IActionResult> GetReviewById(long id)
    {
        var review = await _reviewService.GetReviewByIdAsync(id);
        return Ok(review);
    }
    
}