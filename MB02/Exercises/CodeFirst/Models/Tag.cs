using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.VidApp.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        // Navigation property for many-to-many with Videos
        public ICollection<VideoTag>? VideoTags { get; set; }
    }
}
