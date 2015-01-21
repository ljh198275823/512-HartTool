using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HartTool
{
    interface IHartCommunication
    {
        HartSDK.HartDevice HartDevice { get; set; }
        void ReadData();
    }
}
