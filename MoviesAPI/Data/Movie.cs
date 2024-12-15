namespace MoviesAPI.Data
{
    public class Movie
    {
        public string Name { get; internal set; }
        public int Year { get; internal set; }
        public bool IsSeen { get; internal set; }
        public string Genre { get; internal set; }
        public string Author { get; internal set; }
        public string CoverPictureURL { get; internal set; }
        public DateTime DateAdded { get; internal set; }
        public int Id { get; internal set; }

        public class Book
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Year { get; set; }
            public bool IsSeen { get; set; } 
            public string Genre { get; set; }
            public string Author { get; set; }
            public string CoverPictureURL { get; set; }
            public DateTime DateAdded { get; set; }
        }
    }
}
