﻿namespace MoviesAPI.Data
{
    public class MovieVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }

        public int PublisherId { get; set; }

        public List<int> DirectorIds { get; set; }
    }
}
