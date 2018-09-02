using Newsletter;
using Newsletter.Models;
using Newsletter.NewsletterService;
using System;
using System.Collections.Generic;
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
                    if (response.Result == true && response.Subscription != null)
                     {
                        model.Subscribed = true;
                        model.Message = subscription.EmailAddress + " is already subscribed to this newsletter";

                        return View("Index", model);
                    }
                    
                    response = service.Subscribe(request);
                    if (response.Result == true && response.Subscription != null)
                    {
                        model.Subscribed = true;
                        model.Message = model.EmailAddress + " has successfully subscribed to the newsletter";

                        return View("Index", model);
                    }
                }
                catch
                {
                    return View("Error");
                }

                model.Subscribed = false;
                model.Message = "Unable to process subscription, please try again later.";
                // Log
            }

            return View("Index", model);
            
        }

        [HttpPost]
        public ActionResult Unsubscribe(SubscriptionModel model)
        {
            if (ModelState.IsValid)
            {
                SubscriptionRequest request = new SubscriptionRequest();

                Subscription subscription = new Subscription();
                subscription.EmailAddress = model.EmailAddress;
                subscription.SubscriptionDate = model.SubscriptionDate;
                subscription.MarketingSource = MapMarketingSource(model.MarketingSource);
                subscription.Other = model.Other;
                subscription.Reason = model.Reason;
                request.Subscription = subscription;

                try
                {
                    SubscriptionResponse response = service.Unsubscribe(request);
                    if (response.Result == true && response.Subscription == null)
                    {
                        model.Subscribed = false;
                        model.Message = model.EmailAddress + " has successfully unsubscribed. Please come back soon.";

                        return View("Index", model);
                    }
                }
                catch
                {
                    return View("Error");
                }

                model.Subscribed = true;
                model.Message = "Unable to process subscription, please try again later.";
                // Log

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
    }
}