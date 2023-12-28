using Feedback.Web.Entities;
using Feedback.Web.Interfaces.DomainServices;
using Feedback.Web.Models.Dto;
using Restaurant.Infrastructure.Interfaces;

namespace Feedback.Web.Types;

public class MutationType : ObjectType
{
    
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
    
        descriptor.Field("submitReview")
            .Argument("input", a => a.Type<NonNullType<SubmitReviewInputType>>())
            .Type<NonNullType<ReviewType>>() 
            .Resolve(async context =>
            {
                var input = context.ArgumentValue<ReviewDto>("input");
                var orderService = context.Service<IOrderService>(); // Assuming this is your service
                var reviewRepository = context.Service<IRepository<ReviewEntity>>(); // Assuming this is your repository

                // Business logic from SubmitReviewAsync
                var ordersToReview = await orderService.GetCompletedOrdersAsync(input.UserId);
                if (ordersToReview == null)
                {
                    throw new Exception("Order not found");
                }

                var orderExists = ordersToReview.Any(x => x.OrderId == input.OrderId);
                if (!orderExists) throw new Exception("Chosen order did not exist in the list of orders to review");

                var reviewToSubmit = new ReviewEntity
                {
                    UserId = input.UserId,
                    OrderId = input.OrderId,
                    ReviewText = input.ReviewText,
                    ReviewDate = DateTime.UtcNow,
                    Rating = input.Rating
                };

                 await reviewRepository.AddAsync(reviewToSubmit);
                 await reviewRepository.SaveChangesAsync();
                     
                     
                return reviewToSubmit;
            });
    }
}