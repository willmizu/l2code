using L2code.Domain.Interfaces;
using L2code.Domain.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace L2code.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProcessOrderController : ControllerBase
    {
        private readonly IProcessOrderService _productService;
        private readonly ILogger<ProcessOrderController> _logger;

        public ProcessOrderController(ILogger<ProcessOrderController> logger,
            IProcessOrderService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderRequest orders)
        {
            var result = _productService.ProcessingOrders(orders);

            return Ok(result);
        }
    }
}