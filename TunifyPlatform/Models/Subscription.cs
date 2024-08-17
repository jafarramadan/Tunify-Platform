﻿namespace TunifyPlatform.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public string Subscription_Type { get; set; }
        public double Price { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
