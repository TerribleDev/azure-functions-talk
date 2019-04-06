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
    public class Dounut
    {
        private static List<string> flavors = new List<string>() {
            Enum.GetName(typeof(Toppings), Toppings.blackberry), Enum.GetName(typeof(Toppings), Toppings.bostonCreme), Enum.GetName(typeof(Toppings), Toppings.choco), Enum.GetName(typeof(Toppings), Toppings.strawberry), Enum.GetName(typeof(Toppings), Toppings.vanilla)
        };
        public string Flavor { get; set; } = RandomFlavor();
        public static string RandomFlavor()
        {
            return flavors[new Random().Next(flavors.Count)];
        }
    }
}