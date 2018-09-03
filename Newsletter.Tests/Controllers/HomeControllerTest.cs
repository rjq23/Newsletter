using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newsletter;
using Newsletter.Controllers;
using Newsletter.Models;
using Newsletter.NewsletterService;

namespace Newsletter.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var mockServiceClient = new Mock<INewsletterService>();
            HomeController controller = new HomeController(mockServiceClient.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SubscribeSuccess()
        {
            var mockServiceClient = new Mock<INewsletterService>();
            SubscriptionResponse getSubscriptionResponse = new SubscriptionResponse();
            getSubscriptionResponse.Status = StatusCode.RecordNotFound;
            getSubscriptionResponse.Message = "Subscription not found";

            mockServiceClient.Setup(service => service.GetSubscription(It.IsAny<SubscriptionRequest>())).Returns(getSubscriptionResponse);

            SubscriptionResponse subscribeResponse = new SubscriptionResponse();
            subscribeResponse.Status = StatusCode.Success;
            subscribeResponse.Message = "Subscribed successfully";
            subscribeResponse.Subscription = CreateServiceSubscription();

            mockServiceClient.Setup(service => service.Subscribe(It.IsAny<SubscriptionRequest>())).Returns(subscribeResponse);

            HomeController controller = new HomeController(mockServiceClient.Object);
            SubscriptionModel model = CreateModelData();
            ViewResult result = controller.Subscribe(model) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(controller.ModelState.IsValid);
            Assert.IsTrue(model.Subscribed);
            Assert.AreEqual(model.Message, subscribeResponse.Message);
        }

        [TestMethod]
        public void SubscribeAlreadySubscribed()
        {
            var mockServiceClient = new Mock<INewsletterService>();
            SubscriptionResponse response = new SubscriptionResponse();
            response.Status = StatusCode.Success;
            response.Message = "You are already subscribed";
            response.Subscription = CreateServiceSubscription();
            mockServiceClient.Setup(service => service.GetSubscription(It.IsAny<SubscriptionRequest>())).Returns(response);

            var controller = new HomeController(mockServiceClient.Object);
            SubscriptionModel model = CreateModelData();
            ViewResult result = controller.Subscribe(model) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(model.Subscribed);
            Assert.AreEqual(model.Message, response.Message);
        }

        [TestMethod]
        public void SubscriptionFail()
        {
            var mockServiceClient = new Mock<INewsletterService>();
            SubscriptionResponse response = new SubscriptionResponse();
            response.Status = StatusCode.InternalError;
            response.Message = "An error has occurred";
            mockServiceClient.Setup(service => service.GetSubscription(It.IsAny<SubscriptionRequest>())).Returns(response);

            var controller = new HomeController(mockServiceClient.Object);
            SubscriptionModel model = CreateModelData();
            ViewResult result = controller.Subscribe(model) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsFalse(model.Subscribed);
            Assert.AreEqual(model.Message, response.Message);
        }

        [TestMethod]
        public void UnsubscribeSuccess()
        {
            var mockServiceClient = new Mock<INewsletterService>();
            SubscriptionResponse response = new SubscriptionResponse();
            response.Status = StatusCode.Success;
            response.Message = "Successfully unsubscribed";

            mockServiceClient.Setup(service => service.Unsubscribe(It.IsAny<SubscriptionRequest>())).Returns(response);
            HomeController controller = new HomeController(mockServiceClient.Object);
            SubscriptionModel model = CreateModelData();
            ViewResult unsubscribe = controller.Unsubscribe(model) as ViewResult;

            Assert.IsNotNull(unsubscribe);
            Assert.IsTrue(controller.ModelState.IsValid);
            Assert.IsFalse(model.Subscribed);
            Assert.AreEqual(model.Message, response.Message);
        }

        [TestMethod]
        public void UnsubscribeFail()
        {
            var mockServiceClient = new Mock<INewsletterService>();
            SubscriptionResponse response = new SubscriptionResponse();
            response.Status = StatusCode.InternalError;
            response.Message = "An error has occurred";

            mockServiceClient.Setup(service => service.Unsubscribe(It.IsAny<SubscriptionRequest>())).Returns(response);

            var controller = new HomeController(mockServiceClient.Object);
            SubscriptionModel model = CreateModelData();
            ViewResult result = controller.Unsubscribe(model) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(controller.ModelState.IsValid);
            Assert.IsTrue(model.Subscribed);
            Assert.AreEqual(model.Message, response.Message);
        }
        
        [TestMethod]
        public void About()
        {
            // Arrange
            var mockServiceClient = new Mock<INewsletterService>();
            HomeController controller = new HomeController(mockServiceClient.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            var mockServiceClient = new Mock<INewsletterService>();
            HomeController controller = new HomeController(mockServiceClient.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        public SubscriptionModel CreateModelData()
        {
            SubscriptionModel model = new SubscriptionModel();
            model.EmailAddress = "example@email.com";
            model.MarketingSource = Models.MarketingSource.Advert;
            model.Other = "";
            model.Reason = "Subscription Reason";
            model.SubscriptionDate = DateTime.Now;
            return model;
        }
        
        private Subscription CreateServiceSubscription()
        {
            Subscription subscription = new Subscription
            {
                EmailAddress = "example@email.com",
                MarketingSource = NewsletterService.MarketingSource.Advert,
                Other = "",
                Reason = "Subscription Reason",
                SubscriptionDate = DateTime.Now
            };

            return subscription;
        }
    }
}
