using Newsletter.Service.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Newsletter.Service.DAL
{
    public class NewsletterContext : DbContext
    {
        public NewsletterContext() : base("Newsletter")
        {

        }

        public DbSet<Subscription> Subscriptions { get; set; }

    }
}