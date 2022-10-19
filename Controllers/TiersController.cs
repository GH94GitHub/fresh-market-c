using FreshMarket.Models;
using FreshMarket.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreshMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiersController : ControllerBase
    {
        private readonly TierService _tierService;

        public TiersController(TierService tierService)
        {
            _tierService = tierService;
        }

        [HttpGet]
        [Route("")]
        public Tier[] GetAllTiers()
        {
            return _tierService.GetAllTiers();
        }
    }
}
