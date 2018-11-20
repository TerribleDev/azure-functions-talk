using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;

namespace azure_functions_talk
{
    public static class DozenPlz
    {
        public static HttpClient client = new HttpClient();
        
        [FunctionName("DozenPlz")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "dozen")] HttpRequest req,
            ILogger log)
        {
            var baseUrl = Environment.GetEnvironmentVariable("baseUrl");
            try
            {
                var tasks = Enumerable.Range(0, 12).Select(a => client.GetStringAsync(baseUrl + "/api/make"));
            await Task.WhenAll(tasks);
            var dozen = tasks
            .Select(a => JsonConvert.DeserializeObject<Dounut>(a.Result))
            .Select(a => a.Flavor)
            .ToList();
            return new OkObjectResult("Your dounuts sir! " + String.Join(' ', dozen));
            }
            catch(Exception e) {
                log.LogError(e, "Error processing!");
                throw;
            }
            
        }
    }
}
