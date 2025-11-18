namespace CodeFirst.VidApp
{
    using CodeFirst.VidApp.Models;
    using Microsoft.EntityFrameworkCore;

    public class VidAppContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Tag> Tags { get; set; }  // new DbSet for tags

        // No join DbSet needed if preferred. Including for explicit control:
        public DbSet<VideoTag> VideoTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship
            modelBuilder.Entity<VideoTag>()
                .HasKey(vt => new { vt.VideoId, vt.TagId });

            modelBuilder.Entity<VideoTag>()
                .HasOne(vt => vt.Video)
                .WithMany(v => v.VideoTags)
                .HasForeignKey(vt => vt.VideoId);

            modelBuilder.Entity<VideoTag>()
                .HasOne(vt => vt.Tag)
                .WithMany(t => t.VideoTags)
                .HasForeignKey(vt => vt.TagId);

            // Include existing one-to-many Video-Genre if needed
            modelBuilder.Entity<Video>()
                .HasOne(v => v.Genre)
                .WithMany()
                .HasForeignKey(v => v.GenreId);
        }
    }
}
