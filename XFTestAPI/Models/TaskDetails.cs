using System;
using Newtonsoft.Json;

namespace XFTestAPI.Models
{
    public class TaskDetails
    {
        [JsonProperty("taskId")]
        public string VisitTaskId { get; set; }

        [JsonProperty("taskId")]
        public Guid TaskId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("isTemplate")]
        public bool IsTemplate { get; set; }

        [JsonProperty("timesInMinutes")]
        public long TimesInMinutes { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("paymentTypeId")]
        public Guid PaymentTypeId { get; set; }

        [JsonProperty("createDateUtc")]
        public DateTimeOffset CreateDateUtc { get; set; }

        [JsonProperty("lastUpdateDateUtc")]
        public DateTimeOffset LastUpdateDateUtc { get; set; }

        [JsonProperty("paymentTypes")]
        public string PaymentTypes { get; set; }
    }
}
