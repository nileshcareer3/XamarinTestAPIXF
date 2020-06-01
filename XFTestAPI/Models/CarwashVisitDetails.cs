using System;
using Newtonsoft.Json;

namespace XFTestAPI.Models
{
    public partial class CarwashVisitDetails
    {
        [JsonProperty("visitId")]
        public Guid VisitId { get; set; }

        [JsonProperty("homeBobEmployeeId")]
        public Guid HomeBobEmployeeId { get; set; }

        [JsonProperty("houseOwnerId")]
        public Guid HouseOwnerId { get; set; }

        [JsonProperty("isBlocked")]
        public bool IsBlocked { get; set; }

        [JsonProperty("startTimeUtc")]
        public DateTimeOffset StartTimeUtc { get; set; }

        [JsonProperty("endTimeUtc")]
        public DateTimeOffset EndTimeUtc { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("isReviewed")]
        public bool IsReviewed { get; set; }

        [JsonProperty("isFirstVisit")]
        public bool IsFirstVisit { get; set; }

        [JsonProperty("isManual")]
        public bool IsManual { get; set; }

        [JsonProperty("visitTimeUsed")]
        public long VisitTimeUsed { get; set; }

        [JsonProperty("rememberToday")]
        public bool RememberToday { get; set; }

        [JsonProperty("houseOwnerFirstName")]
        public string HouseOwnerFirstName { get; set; }

        [JsonProperty("houseOwnerLastName")]
        public string HouseOwnerLastName { get; set; }

        [JsonProperty("houseOwnerMobilePhone")]
        public string HouseOwnerMobilePhone { get; set; }

        [JsonProperty("houseOwnerAddress")]
        public string HouseOwnerAddress { get; set; }

        [JsonProperty("houseOwnerZip")]
        public long HouseOwnerZip { get; set; }

        [JsonProperty("houseOwnerCity")]
        public string HouseOwnerCity { get; set; }

        [JsonProperty("houseOwnerLatitude")]
        public double HouseOwnerLatitude { get; set; }

        [JsonProperty("houseOwnerLongitude")]
        public double HouseOwnerLongitude { get; set; }

        [JsonProperty("isSubscriber")]
        public bool IsSubscriber { get; set; }

        [JsonProperty("rememberAlways")]
        public bool RememberAlways { get; set; }

        [JsonProperty("professional")]
        public string Professional { get; set; }

        [JsonProperty("visitState")]
        public string VisitState { get; set; }

        [JsonProperty("stateOrder")]
        public long StateOrder { get; set; }

        [JsonProperty("expectedTime")]
        public string ExpectedTime { get; set; }



    }
}

