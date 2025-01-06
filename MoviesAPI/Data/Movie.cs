namespace MoviesAPI.Data
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public List<MovieDirector> MovieDirectors { get; set; }
    }
}
