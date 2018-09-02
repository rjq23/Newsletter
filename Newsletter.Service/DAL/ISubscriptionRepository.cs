using Newsletter.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newsletter.Service.DAL
{
    public interface ISubscriptionRepository
    {
        IEnumerable<Subscription> GetSubscriptions();
        Subscription GetSubscriptionByEmail(string emailAddress);
        void AddSubscription(Subscription subscription);
        void DeleteSubscription(Subscription subscription);
        void UpdateSubscription(Subscription subscription);

    }
}
