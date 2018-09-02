using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newsletter.Service.Entities
{
    public class Subscription
    {
        [Key]
        public string EmailAddress { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public MarketingSource MarketingSource { get; set; }
        public string Other { get; set; }
        public string Reason { get; set; }
    }

    public enum MarketingSource
    {
        Advert,
        WordOfMouth,
        Other
    }
}