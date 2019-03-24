using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Server.Test
{
    class TestServer
    {
        Server server;
        FakeTransport transport;

        [SetUp]
        public void Setup()
        {
            transport = new FakeTransport();
            server = new Server(transport);
        }

        [Test]
        public void TestDataProcessing()
        {
            byte[] data = Encoding.UTF8.GetBytes("Bella pe te");
            transport.SetFakeTransportData(data);
            server.SingleStep();
            Assert.That(new string(Encoding.UTF8.GetChars(server.ReversedData)), Is.EqualTo("et ep alleB"));
        }

        [Test]
        public void TestDataLengthMatch()
        {
            byte[] data = Encoding.UTF8.GetBytes("Bella pe te");
            transport.SetFakeTransportData(data);
            server.SingleStep();
            Assert.That(server.ReceivedDdata.Length, Is.EqualTo(server.ReversedData.Length));
        }
    }
}
