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
        public StatusCode Status { get; set; }
        public string Message { get; set; }
    }

    public enum StatusCode
    {
        DatabaseError = 100,
        RecordNotFound = 101,
        InvalidData = 102,
        Success = 200,
        AlreadySubscribed = 201,
        InternalError = 300
    }
}