using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sampleProjectUsingRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly IDistributedCache cache;
        private readonly ILogger logger;

        public RedisController(IDistributedCache cache, ILogger logger )
        {
            this.cache = cache;
            this.logger = logger;
        }
        public async Task<IActionResult> GetRedis(string name)
        {
            var _cache = cache.Get(name);

            if (_cache is null)
                return BadRequest();

            return Ok(_cache);
        }
    }
}