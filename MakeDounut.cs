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
        public static async Task<Dounut> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "make")] HttpRequest req,
            ILogger log)
        {
            await Task.Delay(new Random().Next(8, 25));
            return new Dounut();
        }
    }
}
