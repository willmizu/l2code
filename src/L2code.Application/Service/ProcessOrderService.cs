using L2code.Domain.Interfaces;
using L2code.Domain.Models;
using L2code.Domain.Request;
using L2code.Domain.Responses;
using L2code.Utils;

namespace L2code.Application
{
    public class ProcessOrderService : IProcessOrderService
    {
        public ProcessOrderService()
        { }

        public ProcessResultResponse ProcessingOrders(OrderRequest request)
        {
            var availableBoxes = AvailableBoxes.GetBoxes();
            var response = new ProcessResultResponse();

            foreach (var order in request.Orders)
            {
                var orderResponse = new OrderResponse().Create(order);

                foreach (var product in order.Products)
                {
                    var selectedBoxResponse = FindSelectedBoxResponse(order, orderResponse, product);

                    if (selectedBoxResponse == null)
                    {
                        selectedBoxResponse = TryFindNewBox(availableBoxes, product);
                        orderResponse.Boxes.Add(selectedBoxResponse);
                    }
                    selectedBoxResponse.Products.Add(product.ProductId);
                }

                response.Orders.Add(orderResponse);
            }

            return response;
        }

        private BoxResponse FindSelectedBoxResponse(Order order, OrderResponse orderResponse, Product product)
        {
            return orderResponse.Boxes.FirstOrDefault(b =>
                b.Box.Volume() >= product.Measures.Volume() &&
                (b.Products.Sum(pId => order.Products.First(prod => prod.ProductId == pId).Measures.Volume()) + product.Measures.Volume()) <= b.Box.Volume());
        }

        private BoxResponse TryFindNewBox(IEnumerable<Box> availableBoxes, Product product)
        {
            var box = availableBoxes.FirstOrDefault(b => b.Volume() >= product.Measures.Volume());
            if (box != null)
            {
                return new BoxResponse { Box = box, Name = box.Name, Products = new List<string>() };
            }

            return new BoxResponse
            {
                Name = string.Empty,
                Observacao = "Produto não cabe em nenhuma caixa disponível",
                Products = new List<string>()
            };
        }
    }
}