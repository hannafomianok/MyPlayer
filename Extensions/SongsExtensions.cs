using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Extensions;

namespace MusicPlayer.Extensions
{
    public static class SongsExtensions
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

        public interface ISkin
        {
            void Clear();
            void Render(string str);
        }

        public class ClassicSkin : ISkin
        {
            public void Clear()
            {
                Console.Clear();
            }

            public void Render(string str)
            {
                Console.WriteLine(str);
            }
        }

        public class ColorSkin : ISkin
        {
            ConsoleColor color;
            public ColorSkin(ConsoleColor col)
            {
                col = color;
            }
            public void Clear()
            {
                Console.Clear();
            }

            public void Render(string str)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(str);
                Console.ResetColor();
            }
        }

        public class ColorSkin2 : ISkin
        {
            public void Clear()
            {
                Console.Clear();

                for (int i = 0; i < 30; i++)
                {
                    char c = '\u058D';
                    Console.WriteLine(c);

                }
            }

            public void Render(string str)
            {
                Random rand = new Random();
                Console.ForegroundColor = (ConsoleColor)rand.Next(0, 15);
                Console.WriteLine(str);
                Console.ResetColor();
            }
        }



        public static List<Song> FilterByGenre(List<Song> songs)
        {
            var filtered = from item in songs
                           where item.Artist.Genre != Artist.SongGenres.Metal
                           select item;

            foreach (var i in filtered)
                songs.Remove(i);

            return songs;

        }

    }
}
