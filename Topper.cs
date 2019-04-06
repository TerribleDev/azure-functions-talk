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

namespace azure_functions_talk
{
    public static class Topper
    {
        private static List<Toppings> flavors = new List<Toppings>() {
            Toppings.blackberry,
            Toppings.bostonCreme,
            Toppings.choco,
            Toppings.strawberry,
            Toppings.vanilla
        };
        public static string GetTopping() {
            return Enum.GetName(typeof(Toppings), flavors[new Random().Next(flavors.Count)]);
        }
        [FunctionName("Topper")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] Fried req,
            ILogger log)
        {
            await Task.Delay(50);
            return new OkObjectResult(new CompleteDounut() { Topping = GetTopping(), Id = req.Id, Done = req.Done  });
        }
    }
}
