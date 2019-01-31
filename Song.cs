﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Song
    {
        public int Duration;
        public string Name;
        public string Lyrics;
        public Artist Artist;
        public Album Album;
        public bool? Like;


        public void Liking()
        {
            Like = true;
        }
        
        public void Disliking()
        {
            Like = false;
        }
    }
}
