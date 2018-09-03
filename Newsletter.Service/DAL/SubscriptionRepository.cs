using Newsletter.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Newsletter.Service.DAL
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private NewsletterContext context;
        public SubscriptionRepository(NewsletterContext newsletterContext)
        {
            context = newsletterContext;
        }

        public IEnumerable<Subscription> GetSubscriptions()
        {
            var query = from subscriptions in context.Subscriptions
                        select subscriptions;

            return query.ToList();
        }

        public Subscription GetSubscriptionByEmail(string emailAddress)
        {
            var query = from subscription in context.Subscriptions
                        where subscription.EmailAddress.Equals(emailAddress)
                        select subscription;
            
            return query.FirstOrDefault();
        }

        public void AddSubscription(Subscription subscription)
        {
            context.Subscriptions.Add(subscription);
            context.SaveChanges();
        }

        public void DeleteSubscription(Subscription subscription)
        {
            context.Subscriptions.Attach(subscription);
            context.Subscriptions.Remove(subscription);
            context.SaveChanges();
        }

    }
}