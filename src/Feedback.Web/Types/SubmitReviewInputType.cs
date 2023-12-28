using Feedback.Web.Models.Dto;

public class SubmitReviewInputType : InputObjectType<ReviewDto>
{
    protected override void Configure(IInputObjectTypeDescriptor<ReviewDto> descriptor)
    {
        descriptor.Field(r => r.UserId).Type<NonNullType<IdType>>();
        descriptor.Field(r => r.OrderId).Type<NonNullType<IdType>>();
        descriptor.Field(r => r.ReviewText).Type<NonNullType<StringType>>();
        descriptor.Field(r => r.Rating).Type<NonNullType<IntType>>();

        // You can add other fields as necessary.
    }
}