using Newsletter.Service.Entities;
using Newsletter.Service.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Newsletter.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface INewsletterService
    {
        [OperationContract]
        SubscriptionResponse Subscribe(SubscriptionRequest request);

        [OperationContract]
        SubscriptionResponse Unsubscribe(SubscriptionRequest request);

        [OperationContract]
        SubscriptionResponse GetSubscription(SubscriptionRequest request);
    }
}
