﻿namespace TunifyPlatform.Models
{
    public class PlaylistSongs
    {
        public int PlaylistSongsId { get; set; }
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }

    }
}
