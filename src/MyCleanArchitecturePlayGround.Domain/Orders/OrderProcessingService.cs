using MyCleanArchitecturePlayGround.Domain.Orders.Repositories;

namespace MyCleanArchitecturePlayGround.Domain.Orders
{
    public interface IOrderProcessingService
    {

    }

    public class OrderProcessingService : IOrderProcessingService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderProcessingService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
    }
}