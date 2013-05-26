using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Stubs
{
    public class EventbusMessage
    {
        public string address { get; set; }
        public string mode { get; set; }
        public string bodyType { get; set; }
        public string senderId { get; set; }
        public Type body { get; set; }
    }
}
