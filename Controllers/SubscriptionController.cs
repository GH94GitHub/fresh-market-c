using FreshMarket.Dtos;
using FreshMarket.Services;
using Microsoft.AspNetCore.Mvc;

namespace FreshMarket.Controllers
{
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionService _subscriptionService;

        public SubscriptionController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        //todo: update user subscription
        //PUT "/api/users/{id}/subscription
        [Route("api/users/{userId:int}/subscription")]
        public async Task<ActionResult<SubscriptionDto>> UpdateSubscription(int userId, SubscriptionDto subscriptionDto)
        {
            try
            {
                await _subscriptionService.UpdateSubscription(userId, subscriptionDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(ex.Message);
            }

            return Ok();
        }
        
    }
}
