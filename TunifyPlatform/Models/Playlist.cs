﻿namespace TunifyPlatform.Models
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public int Id { get; set; }

        public string Playlist_Name { get; set; }
        public DateTime Created_Date { get; set; }

        public ICollection<PlaylistSongs> playlistSongs { get; set; }

    }
}
