using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Artist
    {

        public enum SongGenres
        {
            DefaultGenre,
            Rock,
            Pop,
            Hiphop,
            Jazz,
            Blues,
            Counry,
            Metal
        }

        public SongGenres Genre;
        public string Name;

        public Artist(): this("Default artist", SongGenres.DefaultGenre)
        {
        }

        public Artist(string name): this(name, SongGenres.DefaultGenre)
        {
        }

        public Artist(string name, SongGenres genre)
        {
            this.Name = name;
            this.Genre = genre;
        }
    }
}
