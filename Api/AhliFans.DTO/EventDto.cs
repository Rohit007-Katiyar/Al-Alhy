using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.DTO
{
    public class EventDto
    {
        public string title { get; set; }
        public string type { get; set; }
        public string event_startdate { get; set; }
        public string event_enddate { get; set; }
        public string location { get; set; }
        public string event_time { get; set; }
        public string eventName { get; set; }
        public string description { get; set; }
        public string imageThumnail { get; set; }
    }
}
