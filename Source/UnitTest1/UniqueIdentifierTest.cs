using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest1
{
    /// <summary>
    /// RequestPacketTest 的摘要说明
    /// </summary>
    [TestClass]
    public class UniqueIdentifierTest
    {
        [TestMethod]
        public void ConvertTest()
        {
            HartSDK.UniqueIdentifier uid = new HartSDK.UniqueIdentifier { ManufactureID = 0x16, ManufactureDeviceType = 0x7C, DeviceID = 201785 };
            long lng = uid.ConvertToLongAddress();
            Assert.IsTrue(lng == 0x167C031439);
        }
    }
}
