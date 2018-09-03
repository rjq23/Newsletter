using Newsletter;
using Newsletter.Models;
using Newsletter.NewsletterService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Newsletter.Controllers
{
    public class HomeController : Controller
    {
        private INewsletterService service;
        public HomeController(INewsletterService newsletterService)
        {
            service = newsletterService;
        }

        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Subscribe(SubscriptionModel model)
        {
            if (ModelState.IsValid)
            {
                SubscriptionRequest request = new SubscriptionRequest();
                SubscriptionResponse response = new SubscriptionResponse();

                Subscription subscription = new Subscription();
                subscription.EmailAddress = model.EmailAddress;
                subscription.SubscriptionDate = DateTime.Now;
                subscription.MarketingSource = MapMarketingSource(model.MarketingSource);
                subscription.Other = model.Other;
                subscription.Reason = model.Reason;

                request.Subscription = subscription;

                try
                {
                    response = service.GetSubscription(request);
                    if (response.Status.Equals(StatusCode.RecordNotFound))
                    {
                        response = service.Subscribe(request);
                    }

                    if (response.Status != StatusCode.Success)
                    {
                        model.Subscribed = false;
                        model.Message = response.Message;
                        return View("Index", model);
                    }
                    
                    model.Subscribed = true;
                    model.Message = response.Message;
                }
                catch(Exception ex)
                {
                    Log(ex.Message, ex.StackTrace);
                    return View("Error");
                }
            }

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Unsubscribe(SubscriptionModel model)
        {
            if (ModelState.IsValid)
            {
                SubscriptionRequest request = new SubscriptionRequest();
                SubscriptionResponse response = new SubscriptionResponse();

                Subscription subscription = new Subscription();
                subscription.EmailAddress = model.EmailAddress;
                subscription.SubscriptionDate = model.SubscriptionDate;
                subscription.MarketingSource = MapMarketingSource(model.MarketingSource);
                subscription.Other = model.Other;
                subscription.Reason = model.Reason;
                
                request.Subscription = subscription;

                try
                {
                    response = service.Unsubscribe(request);
                    if (response.Status != StatusCode.Success)
                    {
                        model.Subscribed = true;
                        model.Message = response.Message;
                        return View("Index", model);
                    }
                }
                catch (Exception ex)
                {
                    Log(ex.Message, ex.StackTrace);
                    return View("Error");
                }

                model.Subscribed = false;
                model.Message = response.Message;
            }

            return View("Index", model);
        }

        private NewsletterService.MarketingSource MapMarketingSource(Models.MarketingSource marketingSource)
        {
            switch (marketingSource)
            {
                case Models.MarketingSource.Advert:
                    return NewsletterService.MarketingSource.Advert;

                case Models.MarketingSource.WordOfMouth:
                    return NewsletterService.MarketingSource.WordOfMouth;

                case Models.MarketingSource.Other:
                    return NewsletterService.MarketingSource.Other;

                default:
                    return NewsletterService.MarketingSource.Other;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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