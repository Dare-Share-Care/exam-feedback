using Ardalis.Specification.EntityFrameworkCore;
using Feedback.Web.Data;
using Restaurant.Infrastructure.Interfaces;

namespace Restaurant.Infrastructure.Data;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
{
    public readonly ReviewContext ReviewContext;

    public EfRepository(ReviewContext reviewContext) : base(reviewContext) =>
        this.ReviewContext = reviewContext;
}