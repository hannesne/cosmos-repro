using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
namespace Inventory.Functions
{
    public static class GetOrderDetails
    {
        [FunctionName("GetOrderDetails")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetOrderDetails/{id:guid}")] HttpRequest req,
            [CosmosDB(
                databaseName: "Inventory",
                collectionName: "Orders",
                ConnectionStringSetting = "CosmosDBConnection",
                Id = "{id}",
                PartitionKey = "{id}")] Order order,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult(order);
        }
    }
}