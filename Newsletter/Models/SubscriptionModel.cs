using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newsletter.Models
{
    public class SubscriptionModel
    {
        [Required(ErrorMessage = "Email Address is a required field.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address. E.g. example@gmail.com")]
        public string EmailAddress { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public MarketingSource MarketingSource { get; set; }
        public string Other { get; set; }
        public string Reason { get; set; }
        public bool Subscribed { get; set; }
        public string Message { get; set; }
    }

    public enum MarketingSource
    {
        [Display(Name = "Advert")]
        Advert,
        [Display(Name ="Word of Mouth")]
        WordOfMouth,
        [Display(Name = "Other")]
        Other
    }
}