using System;
using Newtonsoft.Json;
namespace Inventory.Functions
{
    public class Order
    {
        [JsonProperty("id")]
        public Guid Id {get; set; }
        [JsonProperty("totalPrice")]
        public double TotalPrice { get; set; }
        
        [JsonProperty("orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}