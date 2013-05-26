using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Stubs
{
    public sealed class Body
    {
        public int id { get; set; }
        public IList<Device> devices { get; set; }
        public IList<Room> rooms { get; set; }
        public IList<object> doors { get; set; }
        public IList<Metavalues> metavalues { get; set; }
    }
}
