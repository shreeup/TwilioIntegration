using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSMessenger.BL.Entities
{
    public class SMSMessage
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Message { get; set; }
    }
}
