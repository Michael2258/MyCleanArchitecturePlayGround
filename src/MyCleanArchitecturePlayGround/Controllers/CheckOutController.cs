using Microsoft.AspNetCore.Mvc;
using MyCleanArchitecturePlayGround.Presenters.Orders.QueryHandlers;

namespace MyCleanArchitecturePlayGround.Web.Controllers
{
    [Route("[controller]")]
    public class CheckOutController : ControllerBase
    {
        private readonly OrderCheckOutQuery _orderCheckOutQuery;

        public CheckOutController(OrderCheckOutQuery orderCheckOutQuery)
        {
            _orderCheckOutQuery = orderCheckOutQuery;
        }

        [HttpGet]
        [Route("detail")]
        public async Task<IActionResult> GetCheckOutDetail([FromQuery] Guid orderId)
        {
            var request = new CheckOutDetailQueryRequest()
            {

            };
            var response = await _orderCheckOutQuery.GetCheckOutDetail(request);
            return Ok(response);
        }
    }
}
