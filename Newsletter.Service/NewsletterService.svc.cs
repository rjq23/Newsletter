using Newsletter.Service.DAL;
using Newsletter.Service.Entities;
using Newsletter.Service.Messages;
using System;

namespace Newsletter.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class NewsletterService : INewsletterService
    {
        public SubscriptionResponse Subscribe(SubscriptionRequest request)
        {
            SubscriptionResponse response = new SubscriptionResponse();
            Subscription subscription = request.Subscription;

            using (var context = new NewsletterContext())
            {
                SubscriptionRepository repository = new SubscriptionRepository(context);
                repository.AddSubscription(subscription);
                response.Result = true;
                response.Message = subscription.EmailAddress + " has successfully subscribed to the newsletter";
                response.Subscription = subscription;

                return response;
            }
        }

        public SubscriptionResponse Unsubscribe(SubscriptionRequest request)
        {
            Subscription subscription = request.Subscription;
            SubscriptionResponse response = new SubscriptionResponse();

            using (var context = new NewsletterContext())
            {
                SubscriptionRepository repository = new SubscriptionRepository(context);
                repository.DeleteSubscription(subscription);
                response.Result = true;
                response.Message = subscription.EmailAddress + " has unsubscribed.";

                return response;
            }
        }
        public SubscriptionResponse GetSubscription(SubscriptionRequest request)
        {
            Subscription subscription = request.Subscription;
            SubscriptionResponse response = new SubscriptionResponse();

            using (var context = new NewsletterContext())
            {
                SubscriptionRepository repository = new SubscriptionRepository(context);
                response.Subscription = repository.GetSubscriptionByEmail(subscription.EmailAddress);
            }

            if (response.Subscription == null)
            {
                response.Result = false;
                response.Message = subscription + " is not subscribed to this newsletter.";
                return response;
            }

            response.Result = true;
            return response;
        }
    }
}
