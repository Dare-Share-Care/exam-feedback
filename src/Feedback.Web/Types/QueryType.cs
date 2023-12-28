using Feedback.Web.Data;

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
    }
}
