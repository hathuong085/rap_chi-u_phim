using System;
using System.Collections.Generic;
using System.Text;

namespace Cimena.Domain.Responses.Event
{
   public class EventDelete:Event
    {
        public bool IsDeleted { get; set; }
    }
}
