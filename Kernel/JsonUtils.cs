﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Kernel.Stubs;
using System.IO;

namespace Kernel
{
    class JsonUtils
    {
        

        public String converttoJson(Object o)
        {
            
            return null;
        }

        public void convertfromJson(String json)
        {
            //String json = Windows.Storage.FileIO.ReadTextAsync
            //EventbusMessage ebm = JsonConvert.DeserializeObject<EventbusMessage>
            //StorageFolder storageFolder = KnownFolders.DocumentsLibrary;

            


        }

        public async void m()
        {
            var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(@"json.txt");
            var stream = await file.OpenReadAsync();
            var rdr = new StreamReader(stream.AsStream());

            Task.Run(() =>
            {
                var contents = rdr.ReadToEnd();
            });
        }


        static void Main(string[] args)
        {
            
            
        }
    }
}


/*
 * JSON STRING REQUESTED_FLAT_CONFIG
{"address":"demoClient","mode":"send","bodyType":"at.ac.ait.hbs.homer.core.common.flat.Flat","senderId":"HOME_CONTROL_SERVICE","body":{"id":1,"devices":[{"id":1,"type":11,"category":"SENSOR","roomId":1,"coordinate":{"index":0,"x":1622.0,"y":825.0},"areaCoordinates":[],"metavalues":{"HARDWARE_ID":{"key":"HARDWARE_ID","type":"NUMERIC","value":"23"},"CONFIGURATION":{"key":"CONFIGURATION","type":"STRING","value":"Microwave "},"MANUFACTURER":{"key":"MANUFACTURER","type":"STRING","value":"EATON"},"GATEWAY":{"key":"GATEWAY","type":"NUMERIC","value":"1"}}},{"id":4,"type":10,"category":"SENSOR","roomId":1,"coordinate":{"index":0,"x":1636.0,"y":950.0},"areaCoordinates":[],"metavalues":{"HARDWARE_ID":{"key":"HARDWARE_ID","type":"NUMERIC","value":"7"},"CONFIGURATION":{"key":"CONFIGURATION","type":"STRING","value":"Cups cupboard "},"MANUFACTURER":{"key":"MANUFACTURER","type":"STRING","value":"EATON"},"GATEWAY":{"key":"GATEWAY","type":"NUMERIC","value":"1"}}},{"id":5,"type":0,"category":"SENSOR","roomId":1,"coordinate":{"index":0,"x":1323.0,"y":827.0},"areaCoordinates":[],"metavalues":{"HARDWARE_ID":{"key":"HARDWARE_ID","type":"NUMERIC","value":"8"},"CONFIGURATION":{"key":"CONFIGURATION","type":"STRING","value":"Fridge "},"MANUFACTURER":{"key":"MANUFACTURER","type":"STRING","value":"EATON"},"GATEWAY":{"key":"GATEWAY","type":"NUMERIC","value":"1"}}},{"id":6,"type":0,"category":"SENSOR","roomId":1,"coordinate":{"index":0,"x":1470.0,"y":950.0},"areaCoordinates":[],"metavalues":{"HARDWARE_ID":{"key":"HARDWARE_ID","type":"NUMERIC","value":"20"},"CONFIGURATION":{"key":"CONFIGURATION","type":"STRING","value":"Plates cupboard "},"MANUFACTURER":{"key":"MANUFACTURER","type":"STRING","value":"EATON"},"GATEWAY":{"key":"GATEWAY","type":"NUMERIC","value":"1"}}},{"id":8,"type":11,"category":"SENSOR","roomId":1,"coordinate":{"index":0,"x":1260.0,"y":825.0},"areaCoordinates":[],"metavalues":{"HARDWARE_ID":{"key":"HARDWARE_ID","type":"NUMERIC","value":"1"},"CONFIGURATION":{"key":"CONFIGURATION","type":"STRING","value":"dishwasher 1"},"MANUFACTURER":{"key":"MANUFACTURER","type":"STRING","value":"EATON"},"GATEWAY":{"key":"GATEWAY","type":"NUMERIC","value":"1"}}},{"id":10,"type":11,"category":"SENSOR","roomId":1,"coordinate":{"index":0,"x":1561.0,"y":825.0},"areaCoordinates":[],"metavalues":{"HARDWARE_ID":{"key":"HARDWARE_ID","type":"NUMERIC","value":"12"},"CONFIGURATION":{"key":"CONFIGURATION","type":"STRING","value":"Freezer 1"},"MANUFACTURER":{"key":"MANUFACTURER","type":"STRING","value":"EATON"},"GATEWAY":{"key":"GATEWAY","type":"NUMERIC","value":"1"}}},{"id":11,"type":10,"category":"SENSOR","roomId":1,"coordinate":{"index":0,"x":1335.0,"y":951.0},"areaCoordinates":[],"metavalues":{"HARDWARE_ID":{"key":"HARDWARE_ID","type":"NUMERIC","value":"5"},"CONFIGURATION":{"key":"CONFIGURATION","type":"STRING","value":"Pans cupboard 1"},"MANUFACTURER":{"key":"MANUFACTURER","type":"STRING","value":"EATON"},"GATEWAY":{"key":"GATEWAY","type":"NUMERIC","value":"1"}}},{"id":12,"type":11,"category":"SENSOR","roomId":1,"coordinate":{"index":0,"x":1474.0,"y":823.0},"areaCoordinates":[],"metavalues":{"HARDWARE_ID":{"key":"HARDWARE_ID","type":"NUMERIC","value":"14"},"CONFIGURATION":{"key":"CONFIGURATION","type":"STRING","value":"Washingmachine 2"},"MANUFACTURER":{"key":"MANUFACTURER","type":"STRING","value":"EATON"},"GATEWAY":{"key":"GATEWAY","type":"NUMERIC","value":"1"}}},{"id":13,"type":10,"category":"SENSOR","roomId":1,"coordinate":{"index":0,"x":1228.0,"y":953.0},"areaCoordinates":[],"metavalues":{"HARDWARE_ID":{"key":"HARDWARE_ID","type":"NUMERIC","value":"6"},"CONFIGURATION":{"key":"CONFIGURATION","type":"STRING","value":"groceries cupboard 2"},"MANUFACTURER":{"key":"MANUFACTURER","type":"STRING","value":"EATON"},"GATEWAY":{"key":"GATEWAY","type":"NUMERIC","value":"1"}}},{"id":1,"type":1001,"category":"ACTUATOR","roomId":1,"coordinate":{"index":0,"x":1392.0,"y":888.0},"areaCoordinates":[],"metavalues":{"HARDWARE_ID":{"key":"HARDWARE_ID","type":"NUMERIC","value":"-1"},"CONFIGURATION":{"key":"CONFIGURATION","type":"STRING","value":"test123"},"MANUFACTURER":{"key":"MANUFACTURER","type":"STRING","value":"KNX"}}},{"id":2,"type":1001,"category":"ACTUATOR","roomId":1,"coordinate":{"index":0,"x":1142.0,"y":906.0},"areaCoordinates":[],"metavalues":{"MANUFACTURER":{"key":"MANUFACTURER","type":"STRING","value":"ARC"}}},{"id":15,"type":10,"category":"SENSOR","roomId":3,"coordinate":{"index":0,"x":1516.0,"y":648.0},"areaCoordinates":[],"metavalues":{"HARDWARE_ID":{"key":"HARDWARE_ID","type":"NUMERIC","value":"3464"},"MANUFACTURER":{"key":"MANUFACTURER","type":"STRING","value":"EATON"},"GATEWAY":{"key":"GATEWAY","type":"NUMERIC","value":"1"}}},{"id":2,"type":10,"category":"SENSOR","roomId":5,"coordinate":{"index":0,"x":940.0,"y":326.0},"areaCoordinates":[],"metavalues":{"HARDWARE_ID":{"key":"HARDWARE_ID","type":"NUMERIC","value":"18"},"CONFIGURATION":{"key":"CONFIGURATION","type":"STRING","value":"Hall-Toilet door 5"},"MANUFACTURER":{"key":"MANUFACTURER","type":"STRING","value":"EATON"},"GATEWAY":{"key":"GATEWAY","type":"NUMERIC","value":"1"}}},{"id":3,"type":0,"category":"SENSOR","roomId":5,"coordinate":{"index":0,"x":942.0,"y":500.0},"areaCoordinates":[],"metavalues":{"HARDWARE_ID":{"key":"HARDWARE_ID","type":"NUMERIC","value":"9"},"CONFIGURATION":{"key":"CONFIGURATION","type":"STRING","value":"Hall-Bathroom door "},"MANUFACTURER":{"key":"MANUFACTURER","type":"STRING","value":"EATON"},"GATEWAY":{"key":"GATEWAY","type":"NUMERIC","value":"1"}}},{"id":7,"type":10,"category":"SENSOR","roomId":5,"coordinate":{"index":0,"x":1102.0,"y":111.0},"areaCoordinates":[],"metavalues":{"HARDWARE_ID":{"key":"HARDWARE_ID","type":"NUMERIC","value":"17"},"CONFIGURATION":{"key":"CONFIGURATION","type":"STRING","value":"frontdoor 1"},"MANUFACTURER":{"key":"MANUFACTURER","type":"STRING","value":"EATON"},"GATEWAY":{"key":"GATEWAY","type":"NUMERIC","value":"1"}}},{"id":14,"type":10,"category":"SENSOR","roomId":5,"coordinate":{"index":0,"x":1104.0,"y":434.0},"areaCoordinates":[],"metavalues":{"HARDWARE_ID":{"key":"HARDWARE_ID","type":"NUMERIC","value":"13"},"CONFIGURATION":{"key":"CONFIGURATION","type":"STRING","value":"Hall-Bedroom door 2"},"MANUFACTURER":{"key":"MANUFACTURER","type":"STRING","value":"EATON"},"GATEWAY":{"key":"GATEWAY","type":"NUMERIC","value":"1"}}},{"id":9,"type":11,"category":"SENSOR","roomId":7,"coordinate":{"index":0,"x":753.0,"y":304.0},"areaCoordinates":[],"metavalues":{"HARDWARE_ID":{"key":"HARDWARE_ID","type":"NUMERIC","value":"24"},"CONFIGURATION":{"key":"CONFIGURATION","type":"STRING","value":"ToiletFlush 1"},"MANUFACTURER":{"key":"MANUFACTURER","type":"STRING","value":"EATON"},"GATEWAY":{"key":"GATEWAY","type":"NUMERIC","value":"1"}}}],"rooms":[{"id":1,"type":"MDC_AI_LOCATION_KITCHEN","coordinates":[{"index":1,"x":1108.0,"y":982.0},{"index":2,"x":1108.0,"y":802.0},{"index":3,"x":1677.0,"y":802.0},{"index":4,"x":1677.0,"y":982.0}],"metavalues":{"DESCRIPTION":{"key":"DESCRIPTION","type":"STRING","value":"Kitchen"}}},{"id":3,"type":"MDC_AI_LOCATION_BEDROOM","coordinates":[{"index":1,"x":1109.0,"y":802.0},{"index":2,"x":1677.0,"y":802.0},{"index":3,"x":1677.0,"y":397.0},{"index":4,"x":1112.0,"y":397.0}],"metavalues":{"DESCRIPTION":{"key":"DESCRIPTION","type":"STRING","value":"Sleeping room"}}},{"id":4,"type":"MDC_AI_LOCATION_LIVINGROOM","coordinates":[{"index":1,"x":1112.0,"y":982.0},{"index":2,"x":500.0,"y":982.0},{"index":3,"x":500.0,"y":253.0},{"index":4,"x":738.0,"y":253.0},{"index":5,"x":738.0,"y":545.0},{"index":6,"x":1112.0,"y":545.0}],"metavalues":{"DESCRIPTION":{"key":"DESCRIPTION","type":"STRING","value":"Living room"}}},{"id":5,"type":"MDC_AI_LOCATION_HALL","coordinates":[{"index":1,"x":933.0,"y":545.0},{"index":2,"x":933.0,"y":17.0},{"index":3,"x":1112.0,"y":17.0},{"index":4,"x":1112.0,"y":545.0}],"metavalues":{"DESCRIPTION":{"key":"DESCRIPTION","type":"STRING","value":"Hall"}}},{"id":6,"type":"MDC_AI_LOCATION_SHOWERROOM","coordinates":[{"index":1,"x":738.0,"y":545.0},{"index":2,"x":738.0,"y":357.0},{"index":3,"x":933.0,"y":357.0},{"index":4,"x":933.0,"y":545.0}],"metavalues":{"DESCRIPTION":{"key":"DESCRIPTION","type":"STRING","value":"Bathroom"}}},{"id":7,"type":"MDC_AI_LOCATION_TOILET","coordinates":[{"index":1,"x":738.0,"y":357.0},{"index":2,"x":738.0,"y":253.0},{"index":3,"x":933.0,"y":253.0},{"index":4,"x":933.0,"y":357.0}],"metavalues":{"DESCRIPTION":{"key":"DESCRIPTION","type":"STRING","value":"Toilet"}}},{"id":8,"type":"MDC_AI_LOCATION_STUDY","coordinates":[{"index":1,"x":585.0,"y":253.0},{"index":2,"x":585.0,"y":-30.0},{"index":3,"x":933.0,"y":-30.0},{"index":4,"x":933.0,"y":253.0}],"metavalues":{"DESCRIPTION":{"key":"DESCRIPTION","type":"STRING","value":"Student room"}}}],"doors":[{"id":2,"coordinates":[{"index":1,"x":1112.0,"y":506.0},{"index":2,"x":1112.0,"y":425.0}],"rooms":[{"id":3},{"id":5}]},{"id":4,"coordinates":[{"index":1,"x":933.0,"y":493.0},{"index":2,"x":933.0,"y":408.0}],"rooms":[{"id":5},{"id":6}]},{"id":3,"coordinates":[{"index":1,"x":973.0,"y":545.0},{"index":2,"x":1070.0,"y":545.0}],"rooms":[{"id":4},{"id":5}]},{"id":5,"coordinates":[{"index":1,"x":933.0,"y":332.0},{"index":2,"x":933.0,"y":269.0}],"rooms":[{"id":5},{"id":7}]},{"id":1,"coordinates":[{"index":1,"x":1112.0,"y":943.0},{"index":2,"x":1112.0,"y":850.0}],"rooms":[{"id":1}]},{"id":6,"coordinates":[{"index":1,"x":933.0,"y":155.0},{"index":2,"x":933.0,"y":65.0}],"rooms":[{"id":5},{"id":8}]}],"metavalues":{"DESCRIPTION":{"key":"DESCRIPTION","type":"STRING","value":"Demo Flat"},"ADDRESS":{"key":"ADDRESS","type":"STRING"},"GATEWAYS":{"key":"GATEWAYS","type":"JSON","value":"[{\"gatewayId\":1,\"serialNr\":1234567,\"description\":\"dummy gateway\"}]"}}}}
*/