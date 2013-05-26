using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Stubs
{
    public class Device
    {
        public int id { get; set; }
        public int type { get; set; }
        public string category { get; set; }
        public int roomId { get; set; }
        public Coordinate coordinate { get; set; }
        public List<object> areaCoordinates { get; set; }
        public Metavalues metavalues { get; set; }
    }
}
