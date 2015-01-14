using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest1
{
    [TestClass]
    public class PacketQueueTest
    {
        [TestMethod]
        public void CanDequeue()
        {
            HartSDK.PacketQueue que = new HartSDK.PacketQueue();
            HartSDK.ResponsePacket p = que.Dequeue();
            Assert.IsTrue(p == null);

            que.AppendData(new byte[] { 0xFF, 0xFF, 0x82, 0xA6, 0x06, 0xBC, 0x61, 0x4E, 0x01, 0x00, 0xB0 });
            p = que.Dequeue();
            Assert.IsTrue(p != null);
            Assert.IsTrue(!p.IsValid);  //请求帧的数据不能通过返回帧的有效性检测
            p = que.Dequeue();
            Assert.IsTrue(p == null);

            que.AppendData(new byte[] { 0xFF, 0xFF });
            que.AppendData(new byte[] { 0xFF, 0xFF, 0x86, 0xA6, 0x06, 0xBC, 0x61, 0x4E, 0x01, 0x07, 0x00, 0x00, 0x06, 0x40, 0xB0, 0x00, 0x00, 0x45 });
            p = que.Dequeue();
            Assert.IsTrue(p != null);
            Assert.IsTrue(p.IsValid);
            p = que.Dequeue();
            Assert.IsTrue(p == null);

            que.AppendData(new byte[] { 0xFF, 0xFF, 0x56, 0x25 });
            que.AppendData(new byte[] { 0xFF, 0xFF, 0x86, 0xA6, 0x06, 0xBC, 0x61, 0x4E, 0x01, 0x07, 0x00, 0x00, 0x06, 0x40, 0xB0, 0x00, 0x00, 0x45 });
            p = que.Dequeue();
            Assert.IsTrue(p != null);
            Assert.IsTrue(p.IsValid);
            p = que.Dequeue();
            Assert.IsTrue(p == null);

            que.AppendData(new byte[] { 0xFF, 0xFF, 0x56, 0x25 });
            que.AppendData(new byte[] { 0xFF, 0xFF, 0x86, 0xA6, 0x06, 0xBC, 0x61, 0x4E, 0x01, 0x07, 0x00, 0x00, 0x06, 0x40, 0xB0, 0x00, 0x00, 0x45 });
            que.AppendData(new byte[] { 0x5, 0x1, 0x02 });
            que.AppendData(new byte[] { 0xFF, 0xFF, 0x82, 0xA6, 0x06, 0xBC, 0x61, 0x4E, 0x01, 0x00, 0xB0 });
            p = que.Dequeue();
            Assert.IsTrue(p != null);
            Assert.IsTrue(p.IsValid);
            p = que.Dequeue();
            Assert.IsTrue(p != null);
            Assert.IsTrue(!p.IsValid);  //请求帧的数据不能通过返回帧的有效性检测

            que.AppendData(new byte[] { 0xFF, 0xFF, 0x56, 0x25 });
            que.AppendData(new byte[] { 0xFF, 0xFF, 0x86, 0xA6, 0x06, 0xBC, 0x61, 0x4E, 0x01, 0x07, 0x00, 0x00, 0x06, 0x40, 0xB0, 0x00, 0x00, 0x45 });
            p = que.Dequeue();
            Assert.IsTrue(p != null);
            Assert.IsTrue(p.IsValid);
            Assert.IsTrue(p.DataContent != null);
            Assert.IsTrue(p.DataContent.Length == 5);
        }
    }
}
