using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sampleProjectUsingRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PubController : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">
        /// value that set in Channel 
        ///</param>
        /// <returns></returns>
        public async Task<IActionResult> publisher(string name)
        {
            var redis = StackExchange.Redis.ConnectionMultiplexer.Connect("localhost:6379");
            var pubChannel = redis.GetSubscriber();
            pubChannel.Publish("Helloservice", name);
            return Ok();
        }
    }
}