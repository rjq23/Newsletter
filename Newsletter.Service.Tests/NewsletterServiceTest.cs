using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newsletter.Service.DAL;
using Newsletter.Service.Entities;
using Newsletter.Service.Messages;

namespace Newsletter.Service.Tests
{
    [TestClass]
    public class NewsletterServiceTest
    {
        [TestMethod]
        public void GetSubscription()
        {
            Subscription subscription = CreateSubscriptionData("testemail@email.com");
            var mockDbSet = GetMockDbSet(subscription);
            var mockContext = new Mock<NewsletterContext>();
            mockContext.Setup(m => m.Subscriptions).Returns(mockDbSet.Object);

            SubscriptionRepository repository = new SubscriptionRepository(mockContext.Object);
            NewsletterService newsletterService = new NewsletterService(repository);

            SubscriptionRequest request = new SubscriptionRequest();
            request.Subscription = subscription;
            SubscriptionResponse response = newsletterService.GetSubscription(request);

            Assert.AreEqual(response.Status, StatusCode.Success);
            Assert.IsNotNull(response.Subscription);
            Assert.AreEqual(response.Subscription.EmailAddress, request.Subscription.EmailAddress);
        }

        [TestMethod]
        public void GetSubsciptionNotSubscribed()
        {
            Subscription subscription = CreateSubscriptionData("testemail@email.com");
            var mockDbSet = GetMockDbSet(subscription);
            var mockContext = new Mock<NewsletterContext>();
            mockContext.Setup(m => m.Subscriptions).Returns(mockDbSet.Object);

            SubscriptionRepository repository = new SubscriptionRepository(mockContext.Object);
            NewsletterService newsletterService = new NewsletterService(repository);

            SubscriptionRequest request = new SubscriptionRequest();
            request.Subscription = CreateSubscriptionData("newemail@gmail.com");
            SubscriptionResponse response = newsletterService.GetSubscription(request);

            Assert.AreEqual(response.Status, StatusCode.RecordNotFound);
            Assert.IsNull(response.Subscription);
        }

        [TestMethod]
        public void Subscribe()
        {
            Subscription subscription = CreateSubscriptionData("testemail@email.com");
            var mockDbSet = GetMockDbSet(subscription);
            var mockContext = new Mock<NewsletterContext>();
            mockContext.Setup(m => m.Subscriptions).Returns(mockDbSet.Object);
            
            SubscriptionRepository repository = new SubscriptionRepository(mockContext.Object);
            NewsletterService newsletterService = new NewsletterService(repository);

            SubscriptionRequest request = new SubscriptionRequest();
            request.Subscription = CreateSubscriptionData("newemail@email.com");
            SubscriptionResponse response = newsletterService.Subscribe(request);

            mockDbSet.Verify(m => m.Add(It.IsAny<Subscription>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(response.Status, StatusCode.Success);
            Assert.IsNotNull(response.Subscription);
            Assert.AreEqual(response.Subscription.EmailAddress, request.Subscription.EmailAddress);
        }

        [TestMethod]
        public void SubscribeAlreadySubscribed()
        {
            Subscription subscription = CreateSubscriptionData("testemail@email.com");
            var mockDbSet = GetMockDbSet(subscription);
            var mockContext = new Mock<NewsletterContext>();
            mockContext.Setup(m => m.Subscriptions).Returns(mockDbSet.Object);

            SubscriptionRepository repository = new SubscriptionRepository(mockContext.Object);
            NewsletterService newsletterService = new NewsletterService(repository);

            SubscriptionRequest request = new SubscriptionRequest();
            request.Subscription = subscription;
            SubscriptionResponse response = newsletterService.Subscribe(request);
            
            mockDbSet.Verify(m => m.Add(It.IsAny<Subscription>()), Times.Never());
            mockContext.Verify(m => m.SaveChanges(), Times.Never());
            Assert.AreEqual(response.Status, StatusCode.AlreadySubscribed);
            Assert.IsNotNull(response.Subscription);
            Assert.AreEqual(response.Subscription.EmailAddress, request.Subscription.EmailAddress);
        }

        [TestMethod]
        public void Unsubscribe()
        {
            Subscription subscription = CreateSubscriptionData("testemail@email.com");
            var mockDbSet = GetMockDbSet(subscription);
            var mockContext = new Mock<NewsletterContext>();
            mockContext.Setup(m => m.Subscriptions).Returns(mockDbSet.Object);

            SubscriptionRepository repository = new SubscriptionRepository(mockContext.Object);
            NewsletterService newsletterService = new NewsletterService(repository);

            SubscriptionRequest request = new SubscriptionRequest();
            request.Subscription = subscription;
            SubscriptionResponse response = newsletterService.Unsubscribe(request);

            mockDbSet.Verify(m => m.Remove(It.IsAny<Subscription>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(response.Status, StatusCode.Success);
            Assert.IsNull(response.Subscription);
        }

        public Mock<DbSet<Subscription>> GetMockDbSet(Subscription subscription)
        {
            var tempData = new List<Subscription>
            {
                subscription
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Subscription>>();
            mockDbSet.As<IQueryable<Subscription>>().Setup(m => m.Provider).Returns(tempData.Provider);
            mockDbSet.As<IQueryable<Subscription>>().Setup(m => m.Expression).Returns(tempData.Expression);
            mockDbSet.As<IQueryable<Subscription>>().Setup(m => m.ElementType).Returns(tempData.ElementType);
            mockDbSet.As<IQueryable<Subscription>>().Setup(m => m.GetEnumerator()).Returns(() => tempData.GetEnumerator());
            return mockDbSet;
        }
        

        public Subscription CreateSubscriptionData(string emailAddress)
        {
            Subscription subscription = new Subscription();
            subscription.EmailAddress = emailAddress;
            subscription.MarketingSource = MarketingSource.Advert;
            subscription.Other = "";
            subscription.Reason = "Subscription Reason";
            subscription.SubscriptionDate = DateTime.Now;
            return subscription;
        }
    }
}
