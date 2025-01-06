using MoviesAPI.Data;

namespace MoviesAPI.Services
{
    public class DirectorsServices
    {
    
            private AppDbContext _context;
            public DirectorsServices(AppDbContext context)
            {
                _context = context;
            }
            public void AddDirector(DirectorVM director)
            {
                var newDirector = new Director()
                {
                    FullName = director.FullName,
                };
                _context.Directors.Add(newDirector);
                _context.SaveChanges();
            }
        }
}
