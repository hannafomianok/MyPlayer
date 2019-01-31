using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Extensions;

namespace MusicPlayer.Extensions
{
    static class SongsExtensions
    {

        static public string Cutting(this string name)
        {
            name = name.Substring(0, 4)
                       .Insert(4, "...");
            return name;
        }

        static public List<Song> Shuffle(this List<Song> songs)
        {
            Random rnd = new Random();

            for (int i = songs.Count - 1; i >= 0; i--)
            {
                var song = songs[rnd.Next(songs.Count - 1)];
                songs.Remove(song);
                songs.Add(song);
            }
            return songs;
        }

    }
}
