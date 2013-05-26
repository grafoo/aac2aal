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
        private IList<Coordinate> areaCoordinates {get;set;}
        private IList<Metavalues> metavalues {get;set;}

        /*
        private Device(int id, int type, string category, int roomId, Coordinate coordinate, List<Object> areaCoordinates, Metavalues metavalues) {
            this.id = id;
            this.type = type;
            this.category = category;
            this.roomId = roomId;
            this.areaCoordinates = new List<Coordinate>();
            this.metavalues = new List<Metavalues>();
        }
         */   
    }
}
