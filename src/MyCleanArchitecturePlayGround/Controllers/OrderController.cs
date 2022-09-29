using Microsoft.AspNetCore.Mvc;
using MyCleanArchitecturePlayGround.Domain.Orders;

namespace MyCleanArchitecturePlayGround.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly OrderProcessingService _orderProcessingService;

        public OrderController(OrderProcessingService orderProcessingService)
        {
            _orderProcessingService = orderProcessingService;
        }
    }
}