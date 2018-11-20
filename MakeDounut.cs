using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;

namespace azure_functions_talk
{
    
    public static class MakeDounut
    {
        [FunctionName("MakeDounut")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "/make")] HttpRequest req,
            ILogger log)
        {
            Thread.Sleep(new Random().Next(8, 25));
            return new OkObjectResult(new Dounut());
        }
    }
}
