using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.DTO
{
    public class LegendsBirthdaysDto
    {
        public LegendsBirthdaysDto()
        {
            data = new List<LegentList>();
        }
        public string title { get; set; }
        public string type { get; set; }
        public List<LegentList> data { get; set; }
    }

    public class LegentList
    {
        public string birth_date { get; set; }
        public string playerName { get; set; }
        public string description { get; set; }
        public string imageThumnail { get; set; }
    }
}
