using Core.Domain.Commons;

namespace Core.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Id { get; set; }
        public string ResultType { get; set; }
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<User2Movie> User2Movies { get; set; }


        public Movie()
        {
            User2Movies = new HashSet<User2Movie>();
        }
    }
}
