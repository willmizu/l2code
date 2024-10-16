using L2code.Domain.Request;
using L2code.Domain.Responses;

namespace L2code.Domain.Interfaces
{
    public interface IProcessOrderService
    {
        ProcessResultResponse ProcessingOrders(OrderRequest orders);
    }
}