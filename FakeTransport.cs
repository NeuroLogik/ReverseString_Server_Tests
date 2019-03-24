using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Test
{
    class FakeTransport : ITransport
    {
        byte[] data;

        public void Bind(string address, int port)
        {

        }

        public byte[] Receive()
        {
            return data;
        }

        public bool Send(byte[] data)
        {
            return true;
        }

        public void SetFakeTransportData(byte[] data)
        {
            this.data = data;
        }
    }
}
