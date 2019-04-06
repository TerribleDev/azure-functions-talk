using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace azure_functions_talk
{
    public static class GetBatter
    {
        [FunctionName("GetBatter")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "batter")] HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult( new Batter() { Id = Guid.NewGuid().ToString() } );
        }
    }
}
