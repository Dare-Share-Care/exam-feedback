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

    public ReviewService(IReadRepository<ReviewEntity> reviewReadRepository, IRepository<ReviewEntity> reviewRepository,
        IOrderService orderService)
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

  


    public async Task SubmitReviewAsync(ReviewDto dto)
    {
        //Get a list of completed orders for the user
        var ordersToReview = await _orderService.GetCompletedOrdersAsync(dto.UserId);

        //Check if the order exists
        if (ordersToReview == null)
        {
            throw new Exception("Order not found");
        }


        //Validate order id exists in ordersToReview
        var orderExists = ordersToReview.Any(x => x.OrderId == dto.OrderId);
        if (!orderExists) throw new Exception("Chosen order did not exist in the list of orders to review");
        // Create a review entity
        var reviewToSubmit = new ReviewEntity()
        {
            UserId = dto.UserId,
            OrderId = dto.OrderId,
            ReviewText = dto.ReviewText,
            ReviewDate = dto.ReviewDate,
            Rating = dto.Rating
        };

        // Save the review to the database
        await _reviewRepository.AddAsync(reviewToSubmit);
        await _reviewRepository.SaveChangesAsync();
    }
    
    public async Task <List<ReviewViewModel>> GetAllReviewsAsync()
    {
        var reviews = await _reviewReadRepository.ListAsync();
        var viewModelsReview = reviews.Select(x => new ReviewViewModel()
        {
            UserId = x.UserId,
            OrderId = x.OrderId,
            ReviewText = x.ReviewText,
            ReviewDate = x.ReviewDate,
            Rating = x.Rating
        }).ToList();
        return viewModelsReview;
    }
    
    
    public async Task <ReviewViewModel> GetReviewByIdAsync(long id)
    {
        var review = await _reviewReadRepository.GetByIdAsync(id);
        var viewModelsReview =  new ReviewViewModel
        {
            UserId = review.UserId,
            OrderId = review.OrderId,
            ReviewText = review.ReviewText,
            ReviewDate = review.ReviewDate,
            Rating = review.Rating
        };
        return viewModelsReview;
    }
    
    
}