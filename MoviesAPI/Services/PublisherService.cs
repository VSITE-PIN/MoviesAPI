using MoviesAPI.Data;

namespace MoviesAPI.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }
        public void AddPublisher(PublisherVM publisher)
        {
            var newPublisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(newPublisher);
            _context.SaveChanges();
        }
    }
}
