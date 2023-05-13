using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string BackGroundUrl { get; set; }

        public string ThumbnailUrl { get; set;}


        private ICollection<EventIteration> _iterations; 
        
    }
}
