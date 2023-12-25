using Feedback.Web.Entities;
using Feedback.Web.Interfaces.DomainServices;
using Feedback.Web.Models.Dto;
using Feedback.Web.Models.ViewModels;
using Restaurant.Infrastructure.Interfaces;

namespace Feedback.Web.Services;

public class ReviewService : IReviewService
{
    private readonly IReadRepository<ReviewEntity> _reviewReadRepository;
    private readonly IRepository<ReviewEntity> _reviewRepository;
    private readonly IOrderService _orderService;
    
    public ReviewService(IReadRepository<ReviewEntity> reviewReadRepository, IRepository<ReviewEntity> reviewRepository, IOrderService orderService)
    {
        _reviewReadRepository = reviewReadRepository;
        _reviewRepository = reviewRepository;
        _orderService = orderService;
    }


    public async Task<List<OrderViewModel>> GetOrders()
    {
        var orders = await _orderService.GetCompletedOrdersAsync(1);
        return orders;

    }
    
    public async Task<ReviewViewModel> CreateReviewAsync(ReviewDto dto)
    {
        try
        {
            var createdReview = await _reviewRepository.AddAsync(new ReviewEntity
            {
                UserId = dto.UserId,
                RestaurantId = dto.RestaurantId,
                CourierId = dto.CourierId,
                OrderId = dto.OrderId,
                ReviewText = dto.ReviewText,
                ReviewDate = dto.ReviewDate,
                Rating = dto.Rating
            });

            var reviewDto = new ReviewViewModel()
            {
                UserId = createdReview.UserId,
                RestaurantId = createdReview.RestaurantId,
                CourierId = createdReview.CourierId,
                OrderId = createdReview.OrderId,
                ReviewText = createdReview.ReviewText,
                ReviewDate = createdReview.ReviewDate,
                Rating = createdReview.Rating
            };

            return reviewDto;
        }
        catch (Exception ex)
        {
            //TODO Handle the exception, log it, and consider returning an error response or rethrowing.
            //TODO Example: log.LogError(ex, "Error creating review.");
            throw;
        }
    }

}