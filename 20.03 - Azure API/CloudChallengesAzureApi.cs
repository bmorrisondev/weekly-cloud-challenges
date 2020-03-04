using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using brianmmdev.weeklychallenges.azureapi.utils;

namespace brianmmdev.weeklychallenges.azureapi
{
    public static class CloudChallengesAzureApi
    {
        static string[] months = new string[] {
            "jan",
            "feb",
            "mar",
            "apr",
            "may",
            "jun",
            "jul",
            "aug",
            "sep",
            "oct",
            "nov",
            "dec"
        };

        [FunctionName("CloudChallengesAzureApi")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string monthName = req.Query["name"];
            string monthNumberQueryParam = req.Query["monthNumber"];
            int monthNumber = 0;
            if(int.TryParse(monthNumberQueryParam, out int parsedMonthNumber))
            {
                monthNumber = parsedMonthNumber - 1;
            }

            // string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // dynamic data = JsonConvert.DeserializeObject(requestBody);
            // name = name ?? data?.name;

            // string responseMessage = string.Empty;
            // if(string.IsNullOrEmpty(name))
            // {
            //     responseMessage = "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.";
            // }
            // else
            // {
            //     responseMessage = $"Hello, {name}. This HTTP triggered function executed successfully.";
            // }

            var responseMessage = string.Empty;
            if(monthNumber == 0)
            {
                var helpers = new Helpers();
                monthNumber = helpers.RangedPRNG(0, months.Length);
            }
            else if(monthNumber < 0 || 11 < monthNumber)
            {
                return new BadRequestObjectResult("monthNumber must be between 1 & 12.");
            }
            responseMessage = $"Your month is {months[(int)monthNumber]}";
            return new OkObjectResult(responseMessage);
        }
    }
}
