﻿namespace TunifyPlatform.Models
{
    public class Users
    {
        public int UsersId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime Join_Date { get; set; }
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        public ICollection<Playlist> Playlists { get; set; }
        
    }
}
