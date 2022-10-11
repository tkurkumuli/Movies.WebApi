using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class User2MovieConfiguration : IEntityTypeConfiguration<User2Movie>
    {
        public void Configure(EntityTypeBuilder<User2Movie> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.MovieId).IsRequired();
            builder.Property(x => x.IsWatched);


            builder
              .HasOne(x => x.Movie)
              .WithMany(x => x.User2Movies)
              .HasForeignKey(x => x.MovieId)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
