namespace MoviesAPI.Model
{
    public class MovieVM
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public bool IsSeen { get; set; } 
        public string Genre { get; set; }
        public string Author { get; set; }
        public string CoverPictureURL { get; set; }
    }
}

