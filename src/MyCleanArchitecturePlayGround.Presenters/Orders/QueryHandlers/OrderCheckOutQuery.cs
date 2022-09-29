using MyCleanArchitecturePlayGround.Infrastructure;

namespace MyCleanArchitecturePlayGround.Presenters.Orders.QueryHandlers
{
    public interface IOrderCheckOutQuery
    {
        Task<CheckOutDetailQueryResponse> GetCheckOutDetail(CheckOutDetailQueryRequest request);
    }

    public class OrderCheckOutQuery : IOrderCheckOutQuery
    {
        private readonly ApplicationDbContext applicationDbContext;

        public OrderCheckOutQuery(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<CheckOutDetailQueryResponse> GetCheckOutDetail(CheckOutDetailQueryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}