namespace Feedback.Web.Models.ViewModels;

public class OrderViewModel
{
    public long UserId { get; set; }
    public long OrderId { get; set; }
    public string TimeCreated { get; set; }
    public string Status { get; set; }
    public float Total { get; set; }
    
    public List<OrderLineViewModel> OrderLines { get; set; }
}