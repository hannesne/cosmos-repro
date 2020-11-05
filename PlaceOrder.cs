using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Functions
{
    public static class PlaceOrder
    {
        [FunctionName("PlaceOrder")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "PlaceOrder")] HttpRequest req,
            [CosmosDB(
                databaseName: "Inventory",
                collectionName: "Orders",
                ConnectionStringSetting = "CosmosDBConnection")]out dynamic orderDocument,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            StreamReader reader = new StreamReader(req.Body);
            string bodyString = reader.ReadToEnd();
            Order data = JsonConvert.DeserializeObject<Order>(bodyString);
            Guid documentId = Guid.NewGuid();
            orderDocument = new
            {
                id = documentId,
                totalPrice = data.TotalPrice,
                orderDate = DateTimeOffset.Now,
                status = "Active"
            };
            return new OkObjectResult(new
            {
                id = documentId
            });
        }
    }
}
