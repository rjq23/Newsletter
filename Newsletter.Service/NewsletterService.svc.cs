using Newsletter.Service.DAL;
using Newsletter.Service.Entities;
using Newsletter.Service.Messages;
using System;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;

namespace Newsletter.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public class NewsletterService : INewsletterService
    {
        private ISubscriptionRepository repository;
        
        public NewsletterService()
        {
            repository = new SubscriptionRepository(new NewsletterContext());
        }

        public NewsletterService(ISubscriptionRepository subscriptionRepository)
        {
            repository = subscriptionRepository;
        }

        public SubscriptionResponse Subscribe(SubscriptionRequest request)
        {
            Subscription subscription = request.Subscription;
            SubscriptionResponse response = new SubscriptionResponse();
            
            try
            {
                if (repository.GetSubscriptionByEmail(request.Subscription.EmailAddress) != null)
                {
                    response.Status = StatusCode.AlreadySubscribed;
                    response.Message = subscription.EmailAddress + " is already subscribed to this newsletter";
                    response.Subscription = subscription;
                    return response;
                }

                repository.AddSubscription(subscription);
            }
            catch (DataException ex)
            {
                Log(ex.Message, ex.StackTrace);
                response.Status = StatusCode.DatabaseError;
                response.Message = "An error occurred while processing the transaction";
                return response;
            }
            catch (Exception ex)
            {
                Log(ex.Message, ex.StackTrace);
                response.Status = StatusCode.InternalError;
                response.Message = "An error has occurred, please try again later";
                return response;
            }

            response.Status = StatusCode.Success;
            response.Message = subscription.EmailAddress + " has successfully subscribed to the newsletter";
            response.Subscription = subscription;

            return response;
        }

        public SubscriptionResponse Unsubscribe(SubscriptionRequest request)
        {
            Subscription subscription = request.Subscription;
            SubscriptionResponse response = new SubscriptionResponse();

            try
            {
                repository.DeleteSubscription(subscription);
            }
            catch (DataException ex)
            {
                Log(ex.Message, ex.StackTrace);
                response.Status = StatusCode.DatabaseError;
                response.Message = "An error occurred while processing the transaction";
                return response;
            }
            catch (Exception ex)
            {
                Log(ex.Message, ex.StackTrace);
                response.Status = StatusCode.InternalError;
                response.Message = "An error has occurred, please try again later";
                return response;
            }

            response.Status = StatusCode.Success;
            response.Message = subscription.EmailAddress + " has unsubscribed.";

            return response;
        }
        public SubscriptionResponse GetSubscription(SubscriptionRequest request)
        {
            Subscription subscription = request.Subscription;
            SubscriptionResponse response = new SubscriptionResponse();

            try
            {
                response.Subscription = repository.GetSubscriptionByEmail(subscription.EmailAddress);
            }
            catch (DataException ex)
            {
                Log(ex.Message, ex.StackTrace);
                response.Status = StatusCode.DatabaseError;
                response.Message = "An error occurred while processing the transaction";
                return response;
            }
            catch (Exception ex)
            {
                Log(ex.Message, ex.StackTrace);
                response.Status = StatusCode.InternalError;
                response.Message = "An error has occurred, please try again later";
                return response;
            }

            if (response.Subscription == null)
            {
                response.Status = StatusCode.RecordNotFound;
                response.Message = subscription + " is not subscribed to this newsletter.";
                return response;
            }

            response.Status = StatusCode.Success;
            response.Message = response.Subscription.EmailAddress + " subscribed to this newsletter on " + response.Subscription.SubscriptionDate.ToShortDateString();
            return response;
        }

        public void Log(string message, string stack)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(string.Format("Message: {0}\nStack: {1}", message, stack), EventLogEntryType.Error);
            }
        }
    }
}
