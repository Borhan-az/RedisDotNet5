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
    public class DistributedCachingController : ControllerBase
    {
        private readonly IDistributedCache cache;
        private readonly ILogger logger;

        /// <summary>
        /// This is Get and set in Redis with Microsoft Distributed Caching
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="logger"></param>
        public DistributedCachingController(IDistributedCache cache, ILogger logger)
        {
            this.cache = cache;
            this.logger = logger;
        }
        public async Task<IActionResult> GetKey(string name)
        {
            logger.LogInformation("Get record from redis started");
            var _cache = await cache.GetAsync(name);

            if (_cache is null)
                return BadRequest();
            return Ok(_cache);
        }
        public async Task<IActionResult> SetValue(string key, string value)
        {
            logger.LogInformation("set record to redis started");
            await cache.SetStringAsync(key, value);
            return Ok(value);
        }

        public async Task<IActionResult> RemoveKey(string key)
        {
            logger.LogInformation("remove record from redis started");
            await cache.RemoveAsync(key);
            return Ok();
        }

    }
}