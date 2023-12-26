using Feedback.Web.Entities;

namespace Feedback.Web.Specifications;

using Ardalis.Specification;

public class OrderReviewSpecification : Specification<ReviewEntity>
{
    public OrderReviewSpecification(long orderId)
    {
        Query.Where(review => review.OrderId == orderId);
    }
}
