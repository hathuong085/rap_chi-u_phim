using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Models.Showing
{
    public class TimeShow
    {
        public int TimeId { get; set; }
        public string StartTime { get; set; }
        public int ShowingId { get; set; }
    }
}
