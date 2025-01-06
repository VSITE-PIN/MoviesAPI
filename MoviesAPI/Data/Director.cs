namespace MoviesAPI.Data
{
    public class Director
    {

            public int Id { get; set; }
            public string FullName { get; set; }

            public List<MovieDirector> MovieDirectors { get; set; }

    }
}
