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
    public static class Fryer
    {
        [FunctionName("Fryer")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] Batter req,
            ILogger log)
        {
            await Task.Delay(100);
            return new OkObjectResult(new Fried() { Id = req.Id });
        }
    }
}
