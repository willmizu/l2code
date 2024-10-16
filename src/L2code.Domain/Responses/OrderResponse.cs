using L2code.Domain.Models;

namespace L2code.Domain.Responses
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public List<BoxResponse> Boxes { get; set; } = new List<BoxResponse>();

        public OrderResponse Create(Order order)
        {
            return new OrderResponse { OrderId = order.OrderId, Boxes = new List<BoxResponse>() };
        }
    }
}