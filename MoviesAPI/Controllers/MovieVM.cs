namespace MoviesAPI.Controllers
{
    public class MovieVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsViewed { get; set; }
        public DateTime? DateViewed { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string CoverPictureURL { get; set; }

    }
}