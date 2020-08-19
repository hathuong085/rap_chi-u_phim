using System;
using System.Collections.Generic;
using System.Text;

namespace Cimena.Domain.Requests.Event
{
   public class CreateEvent
    {
        public string NameEvent { get; set; }
        public string TitleEvent { get; set; }
        public string ImageEvent { get; set; }
        public string LinkEvent { get; set; }
    }
}
