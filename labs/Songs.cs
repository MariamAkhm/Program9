using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs
{
    class Songs
    {
        private string name;
        private string author;
        private Songs last_song;
        public Songs() { }
        public Songs(string name, string author)
        {
            this.name = name;
            this.author = author;
            last_song = null;
        }
        public Songs(string name, string author, Songs last_song) { }
        public static void Search(List<Songs> songs)
        {
            bool isFounded = false;
            for (int i = 0; i < songs.Count; i++)
            {
                for (int j = 1; j < songs.Count - 1; j++)
                {
                    if (songs[i] != null && songs[j] != null)
                    {
                        if (songs[i].Equals(songs[j]) && i != j)
                        {
                            isFounded = true;
                            Console.WriteLine($"Совпали песни под номерами {i + 1} и {j + 1}, Название {songs[i].name} , автор {songs[i].author} ");
                            songs[i] = null;
                        }
                    }
                }
                if (isFounded)
                {
                    Search(songs);
                }
            }

        }
        public static string Title(Songs song)
        {
            return $"{song.name} {song.author}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Songs)
            {
                if ($"{this.name} {this.author}" == Songs.Title(obj as Songs))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
