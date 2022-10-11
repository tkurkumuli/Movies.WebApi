using Core.Domain.Commons;

namespace Core.Domain.Entities
{
    public class User2Movie : BaseEntity
    {
        public Guid Id { get; set; }
        public string MovieId { get; set; }
        public Movie Movie { get; set; }
        public Guid UserId { get; set; }
        public bool IsWatched { get; set; }
       
    }
}
