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
    public class RequestPacketTest
    {
        [TestMethod]
        public void TobytesTest()
        {
            byte[] data = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x82, 0xA6, 0x06, 0xBC, 0x61, 0x4E, 0x01, 0x00, 0xB0 };

            HartSDK.RequestPacket p = new HartSDK.RequestPacket();
            p.LongOrShort = 1;
            p.Address = 163321766222;
            p.Command = 0x01;

            byte[] tob = p.ToBytes();
            Assert.IsTrue(tob != null);
            Assert.IsTrue(tob.Length == data.Length);
            for (int i = 0; i < tob.Length; i++)
            {
                Assert.IsTrue(tob[i] == data[i]);
            }
        }
    }
}
