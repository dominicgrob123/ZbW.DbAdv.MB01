using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.VidApp.Models
{
    public class VideoTag
    {
            public int VideoId { get; set; }
            public Video? Video { get; set; }

            public int TagId { get; set; }
            public Tag? Tag { get; set; }
        
    }
}
