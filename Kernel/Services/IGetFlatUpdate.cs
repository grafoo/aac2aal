using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel.Stubs;

namespace Kernel.Services
{
    interface IGetFlatUpdate
    {
        Task<EventbusMessage> GetFlatConfig();
    }
}
