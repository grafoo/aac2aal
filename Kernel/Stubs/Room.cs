using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Stubs
{
    public class Room
    {
        public int id { get; set; }
        public string type { get; set; }
        public IList<Coordinate> coordinates { get; set; }
        public IList<Metavalues> metavalues { get; set; }
    }
}
