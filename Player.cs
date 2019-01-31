using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Extensions;

namespace MusicPlayer
{
    public class Player
    {
        const int MIN_VOLUME = 0;
        const int MAX_VOLUME = 100;

        private bool _isLocked;

        private bool _isPlaying;

        private int _volume;

        public bool Playing
        {
            get
            {
                return _isPlaying;
            }
        }
        
        public int Volume
        {
            get
            {
                return _volume;
            }

            private set
            {
                if (value < MIN_VOLUME)
                {
                    _volume = MIN_VOLUME;
                }
                else if (value > MAX_VOLUME)
                {
                    _volume = MAX_VOLUME;
                }
                else
                {
                    _volume = value;
                }
            }
        }



        public List<Song> Songs { get;  set; } = new List<Song>();

        public void VolumeUp()
        {
            if (_isLocked == false)
            {
                Volume++;
            }
        }

        public void VolumeDown()
        {
            if (_isLocked == false)
            {
                Volume--;
            }
        }

        public void VolumeChange(int step)
        {
            if (_isLocked == false)
            {
                Volume += step;
            }
        }

        public void Play()
        {
            if (_isLocked)
            {
                return;
            }
            _isPlaying = true;
            for (int i = 0; i < Songs.Count; i++)
            {
                Songs[i].Name = SongsExtensions.Cutting(Songs[i].Name);
                if (Songs[i].Like.HasValue)
                {
                    if (Songs[i].Like == true)
                    {                                          
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Player is playing: {Songs[i].Name}, duration: {Songs[i].Duration}");
                        System.Threading.Thread.Sleep(1000);
                        Console.ResetColor();
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Player is playing: {Songs[i].Name}, duration: {Songs[i].Duration}");
                        System.Threading.Thread.Sleep(1000);
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.WriteLine($"Player is playing: {Songs[i].Name}, duration: {Songs[i].Duration}");
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        public void Stop()
        {
            if (_isLocked)
            {
                return;
            }
            _isPlaying = false;
            Console.WriteLine("Player has stopped");
        }

        public void Locked()
        {
            _isLocked = true;
            Console.WriteLine("Player is locked");
        }
        public void Unlock()
        {
            _isLocked = false;
            Console.WriteLine("Player is unlocked");
        }

        public void Add(params Song[] songArr)
        {
            Songs.AddRange(songArr);
        }

        public void Shuffle()
        {
            Random rnd = new Random();

            for (int i = Songs.Count - 1; i >= 0; i--)
            {
                var song = Songs[rnd.Next(Songs.Count - 1)];
                Songs.Remove(song);
                Songs.Add(song);
            }

        }
        public void Sort()
        {
            Songs.Sort();
        }

    }
}

    
