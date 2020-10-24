using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OptionsNetCore.Core.Options.Redis;

namespace OptionsNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RedisOptions _redisOptions;

        public HomeController(IOptions<RedisOptions> options, ILogger<HomeController> logger)
        {
            this._logger = logger;
            this._redisOptions = options.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this._redisOptions);
        }
    }
}
