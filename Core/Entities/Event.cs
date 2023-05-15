using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Event
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string BackGroundUrl { get; private set; }

        public string ThumbnailUrl { get; private set; }

        public ICollection<EventIteration> Iterations { get; private set; }


        public Event(string name ,string type , string backGroundUrl,string thumbnailUrl)
        {
            Name = name;
            Type = type;
            BackGroundUrl = backGroundUrl;
            ThumbnailUrl = thumbnailUrl;
            Iterations = new List<EventIteration>();
        }
        private Event() { 
        }

        
    }
}
