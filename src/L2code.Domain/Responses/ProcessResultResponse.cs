namespace L2code.Domain.Responses
{
    public class ProcessResultResponse
    {
        public List<OrderResponse> Orders { get; set; } = new List<OrderResponse>();
    }
}