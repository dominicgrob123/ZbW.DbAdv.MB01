namespace CodeFirst.VidApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore.Design;
    public class Video
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        //public ICollection<VideoGenre>? VideoGenres { get; set; }

        // New foreign key property
        public byte GenreId { get; set; }

        // Navigation property for genre
        public Genre? Genre { get; set; }

        public Classification Classification { get; set; }
        // Add collection navigation for many-to-many with Tags
        public ICollection<VideoTag>? VideoTags { get; set; }
    }
}
