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

        public Player(Skin skin)
        {
            this.skin = skin;
        }

        public Skin skin;       


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
                //Songs[i].Name = SongsExtensions.Cutting(Songs[i].Name);
                if (Songs[i].Like.HasValue)
                {
                    if (Songs[i].Like == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        skin.Render(Songs[i].Name);                       
                        //Console.WriteLine($"Player is playing: {Songs[i].Name}, duration: {Songs[i].Duration}");
                        System.Threading.Thread.Sleep(1000);
                        Console.ResetColor();
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        skin.Render(Songs[i].Name);
                        //Console.WriteLine($"Player is playing: {Songs[i].Name}, duration: {Songs[i].Duration}");
                        System.Threading.Thread.Sleep(1000);
                        Console.ResetColor();
                    }
                }
                else
                {
                    skin.Render(Songs[i].Name);
                    //Console.WriteLine($"Player is playing: {Songs[i].Name}, duration: {Songs[i].Duration}");
                    System.Threading.Thread.Sleep(1000);
                }
            }
            skin.Clear();
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

    public abstract class Skin
    {
        public abstract void Clear();
        public abstract void Render(string str);
    }

    public class ClassicSkin: Skin
    {
        public override void Clear()
        {
            Console.Clear();
        }

        public override void Render(string str)
        {
            Console.WriteLine(str);
        }
    }

    public class ColorSkin : Skin
    {
        ConsoleColor color;
        public ColorSkin(ConsoleColor col)
        {
            col = color;
        }
        public override void Clear()
        {
            Console.Clear();
        }

        public override void Render(string str)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }
    }

    public class ColorSkin2 : Skin
    {
        public override void Clear()
        {
            Console.Clear();

            for (int i = 0; i < 30; i++)
            {
                char c = '\u058D';
                Console.WriteLine(c);

            }
        }

        public override void Render(string str)
        {
            Random rand = new Random();
            Console.ForegroundColor = (ConsoleColor)rand.Next(0, 15);
            Console.WriteLine(str);
            Console.ResetColor();
        }
    }
}

    
