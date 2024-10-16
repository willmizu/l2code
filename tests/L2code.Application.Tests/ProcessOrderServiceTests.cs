using Xunit;
using Assert = Xunit.Assert;

namespace L2code.Application.Tests
{
    [Collection(nameof(ProcessOrderServiceCollection))]
    public class ProcessOrderServiceTests
    {
        private readonly FixtureService _fixture;

        public ProcessOrderServiceTests(FixtureService fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "ProcessOrderService - ProductsThatDoNotFitInAvailableBoxes")]
        public void ProcessOrderService_ProductsThatDoNotFitInAvailableBoxes()
        {
            var service = _fixture.GetProcessOrderService();
            var requestMock = _fixture.CreateOrderRequestProductNotFitInAvailableBoxes();

            var result = service.ProcessingOrders(requestMock);

            Assert.NotNull(result);
            var orderResponse = Assert.Single(result.Orders);
            var boxResponse = Assert.Single(orderResponse.Boxes);
            Assert.Equal("Produto não cabe em nenhuma caixa disponível", boxResponse.Observacao);
        }

        [Fact(DisplayName = "ProcessOrderService - Sucess")]
        public void ProcessOrderService_Sucess()
        {
            var service = _fixture.GetProcessOrderService();
            var requestMock = _fixture.CreateOrderRequest();

            var result = service.ProcessingOrders(requestMock);

            Assert.NotNull(result);
            var orderReponse = result.Orders.First();
            Assert.Contains(orderReponse.Boxes, b => b.Name == "Caixa 1");
        }

        [Fact(DisplayName = "ProcessOrderService - Sucess - OrderHasTwoBoxes")]
        public void ProcessOrderService_Sucess_HasTwoBoxes()
        {
            var service = _fixture.GetProcessOrderService();
            var requestMock = _fixture.CreateOrderRequestOrderInTwoBoxes();

            var result = service.ProcessingOrders(requestMock);

            Assert.NotNull(result);
            var orderReponse = result.Orders.First();
            Assert.Equal(2, orderReponse.Boxes.Count);
        }
    }
}