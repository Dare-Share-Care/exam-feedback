using Feedback.Web.Data;
using Feedback.Web.Entities;
using Restaurant.Infrastructure.Interfaces;

namespace Feedback.Web.Types;

public class QueryType : ObjectType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.Field("reviews")
            .Type<ListType<ReviewType>>() // Assuming you have a ReviewType
            .Resolve(context =>
            {
                var dbContext = context.Service<ReviewContext>();
                return dbContext.Reviews.ToList();
            });
        
        descriptor.Field("review")
            .Argument("id", a => a.Type<NonNullType<IdType>>())
            .Type<ReviewType>()
            .Resolve(context =>
            {
                var reviewId = context.ArgumentValue<long>("id"); // Assuming the ID is an integer
                var reviewRepository = context.Service<IRepository<ReviewEntity>>();
                return reviewRepository.GetByIdAsync(reviewId); // Replace with your method to fetch a review by ID
            });
    }
}
