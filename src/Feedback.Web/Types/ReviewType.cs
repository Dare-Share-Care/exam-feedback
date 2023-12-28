using Feedback.Web.Entities;

namespace Feedback.Web.Types;

public class ReviewType : ObjectType<ReviewEntity>
{
    protected override void Configure(IObjectTypeDescriptor<ReviewEntity> descriptor)
    {
        descriptor.Field(r => r.OrderId).Type<NonNullType<IdType>>();
        descriptor.Field(r => r.UserId).Type<NonNullType<IdType>>();
        descriptor.Field(r => r.ReviewText).Type<NonNullType<StringType>>();
        descriptor.Field(r => r.ReviewDate).Type<NonNullType<DateTimeType>>();
        descriptor.Field(r => r.Rating).Type<NonNullType<IntType>>();
        
        // Add other fields as needed
    }
    
}