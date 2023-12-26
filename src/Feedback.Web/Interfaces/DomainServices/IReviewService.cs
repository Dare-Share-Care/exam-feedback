using Feedback.Web.Models.Dto;
using Feedback.Web.Models.ViewModels;

namespace Feedback.Web.Interfaces.DomainServices;

public interface IReviewService
{
    Task SubmitReviewAsync(ReviewDto dto);
    
    Task<List<OrderViewModel>> GetOrders();

}