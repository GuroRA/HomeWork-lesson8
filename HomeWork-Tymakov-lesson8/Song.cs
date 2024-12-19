namespace HomeWork_Tymakov_lesson8
{
    public class Song
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public Song Prev { get; set; }

        public Song(string name, string author, Song prev)
        {
            Name = name;
            Author = author;
            Prev = prev;
        }
        public Song(string name, string author)
        {
            Name = name;
            Author = author;
            Prev = null;
        }

        public Song()
        {
            Name = "";
            Author = "";
            Prev = null;
        }

        public string Title()
        {
            return $"Название песни: {Name}\nИмя исполнителя: {Author}\n";
        }

        public void GetPreviousSong(Song song)
        {
            Prev = song;
        }
        public override bool Equals(object d)
        {
            if (d is Song song)
            {
                return song.Title() == Prev.Title();
            }
            return false;
        }
    }
}
