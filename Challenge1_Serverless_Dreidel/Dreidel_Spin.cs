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

namespace Challenge1_Serverless_Dreidel
{
    public static class Dreidel_Spin
    {
        [FunctionName("Dreidel_Spin")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {

            List<KeyValuePair<string, object>> dreidel = new List<KeyValuePair<string, object>>();

            dreidel.Add(new KeyValuePair<string, object>("Nun", "נ"));
            dreidel.Add(new KeyValuePair<string, object>("Gimmel", "ג"));
            dreidel.Add(new KeyValuePair<string, object>("Hay", "ה"));
            dreidel.Add(new KeyValuePair<string, object>("Shin", "ש"));

            return (ActionResult)new OkObjectResult(dreidel[new Random().Next(dreidel.Count)]);
        }
    }
}
