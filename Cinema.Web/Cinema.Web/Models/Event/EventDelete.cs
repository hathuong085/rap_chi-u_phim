using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Models.Event
{
    public class EventDelete : Event
    {
        public bool IsDeleted { get; set; }
    }
}
