using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Extensions;

namespace MusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player(new SongsExtensions.ClassicSkin());
            player.Load(@"C:\Users\annaf\Desktop\anna\ITAcademyPlayer");

            player.SongStartedEvent += ShowInfo;
            player.SongsListChangedEvent += ShowInfo;

            player.Play();
            player.Unlock();

            player.Play();
            player.VolumeUp();


            player.Songs[1].Liking();
            player.Songs[2].Disliking();

            player.Play();
            player.VolumeDown();

            player.Songs = SongsExtensions.FilterByGenre(player.Songs);


            player.Play();
            player.VolumeChange(50);
            SongsExtensions.Shuffle(player.Songs);

            player.Play();
            player.Locked();


            player.Stop();         
                                

            Console.ReadLine();
        }

        private static void ShowInfo(List<Song> songs, Song playingSong, bool locked, int volume)
        {
            Console.Clear();// remove old data

            //Render the list of songs
            foreach (var song in songs)
            {
                if (playingSong == song)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(song.Name);//Render current song in other color.
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(song.Name);
                }
            }

            //Render status bar
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Volume is: {volume}. Locked: {locked}");
            Console.ResetColor();
        }

  
    }
}
