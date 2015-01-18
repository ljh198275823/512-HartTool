using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HartTool
{
    interface IHartCommunication
    {
        HartSDK.HartComport HartComport { get; set; }
        HartSDK.UniqueIdentifier CurrentDevice { get; set; }
    }
}
