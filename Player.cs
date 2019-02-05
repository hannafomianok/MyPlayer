using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Extensions;
using System.IO;
using System.Xml.Serialization;

namespace MusicPlayer
{
    public class Player
    {

        public Player(SongsExtensions.ISkin skin)
        {
            this.skin = skin;
        }

        public SongsExtensions.ISkin skin;


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

        public List<Song> Songs { get; set; } = new List<Song>();
        public Song PlayingSong { get; private set; }

        public event Action<List<Song>, Song, bool, int> SongsListChangedEvent;
        public event Action<List<Song>, Song, bool, int> SongStartedEvent;
        public event Action<List<Song>, Song, bool, int> VolumeChangedEvent;

        public void VolumeUp()
        {
            if (_isLocked == false)
            {
                Volume++;
            }

            VolumeChangedEvent?.Invoke(null, null, _isLocked, _volume);
        }

        public void VolumeDown()
        {
            if (_isLocked == false)
            {
                Volume--;
            }

            VolumeChangedEvent?.Invoke(null, null, _isLocked, _volume);

        }

        public void VolumeChange(int step)
        {
            if (_isLocked == false)
            {
                Volume += step;
            }

            VolumeChangedEvent?.Invoke(Songs, PlayingSong, _isLocked, _volume);

        }

        public void Load(string source)
        {
            var direcInfo = new DirectoryInfo(source);

            if (direcInfo.Exists)
            {
                var files = direcInfo.GetFiles();
                foreach (var file in files)
                {
                    var song = new Song
                    {
                        Path = file.FullName,
                        Name = file.Name
                    };

                    Songs.Add(song);
                }
            }

            SongsListChangedEvent?.Invoke(Songs, PlayingSong, _isLocked, _volume);
        }

        public void Play()
        {
            if (!_isLocked && Songs.Count > 0)
            {
                _isPlaying = true;
            }

            if (_isPlaying)
            {
                foreach (var song in Songs)
                {
                    PlayingSong = song;
                    SongStartedEvent?.Invoke(Songs, song, _isLocked, _volume);

                    using (System.Media.SoundPlayer player = new System.Media.SoundPlayer())
                    {
                        player.SoundLocation = PlayingSong.Path;
                        player.PlaySync();
                    }
                }
            }

            _isPlaying = false;
        }

        public bool Stop()
        {
            if (!_isLocked)
            {
                _isPlaying = false;
            }
            return _isPlaying;
        }

        public void Clear()
        {
            Songs.Clear();
        }

        public void Locked()
        {
            _isLocked = true;
        }
        public void Unlock()
        {
            _isLocked = false;
        }

        public void Sort()
        {
            Songs.Sort();
        }

        public void SaveAsPlaylist()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Song[]));

            using (FileStream writer = new FileStream("c://XMLFile.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(writer, Songs);
            }
        }

        public void LoadPlaylist()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Song[]));
            Song result;

            using (FileStream writer = new FileStream("c://XMLFile.xml", FileMode.OpenOrCreate))
            {
                result = (Song)xmlSerializer.Deserialize(writer);
            }
        }

     
    }
}

    
