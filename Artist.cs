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

        public Artist()
        {
            this.Name = "Default artist";
            this.Genre = SongGenres.DefaultGenre;
        }

        public Artist(string name)
        {
            this.Name = name;
            this.Genre = SongGenres.DefaultGenre;
        }

        public Artist(string name, SongGenres genre)
        {
            this.Name = name;
            this.Genre = genre;
        }
    }
}
