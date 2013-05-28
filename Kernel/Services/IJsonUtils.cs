using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel.Stubs;

namespace Kernel.Services
{
    public interface IJsonUtils
    {
        String converttoJson(Object o);
        EventbusMessage convertfromJson(string jsonString);
           
    }
}
