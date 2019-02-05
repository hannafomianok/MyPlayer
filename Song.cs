using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    [Serializable]
    public class Song : IComparable
    {
        public int Duration;
        public string Name;
        public string Path;
        public Artist Artist;
        public Album Album;
        public bool? Like;

        public Song()
        {
        }

        public void Liking()
        {
            Like = true;
        }
        
        public void Disliking()
        {
            Like = false;
        }

        public int CompareTo(object obj)
        {
            return this.Name?.CompareTo((obj as Song)?.Name) ?? 0;
        }
    }
}
