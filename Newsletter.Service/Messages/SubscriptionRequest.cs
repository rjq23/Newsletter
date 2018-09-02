using Newsletter.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Newsletter.Service.Messages
{
    public class SubscriptionRequest
    {
        public Subscription Subscription { get; set; }
    }
}