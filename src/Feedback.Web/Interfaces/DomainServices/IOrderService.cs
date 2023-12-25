using Feedback.Web.Models.ViewModels;

namespace Feedback.Web.Interfaces.DomainServices;

public interface IOrderService
{
    Task<List<OrderViewModel>> GetCompletedOrdersAsync(long userId);
}