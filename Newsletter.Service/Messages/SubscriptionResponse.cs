using Newsletter.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Newsletter.Service.Messages
{
    public class SubscriptionResponse
    {
        public Subscription Subscription { get; set; }
        public List<Subscription> Subscriptions { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }
    }
}