using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DNSServer {
    class DNSDatagram {
        private short id;
        private short flags = 0x00;
        private short questionCount = 0x100;
        private short answersCount = 0;
        private short NSCount = 0;
        private short ARCount = 0;
        private byte[] body =
            {0x04, 0x70, 0x6c, 0x61, 0x79, 0x06, 0x67, 0x6f, 0x6f, 0x67, 0x6c, 0x65, 0x03, 0x63, 0x6f, 0x6d, 0x00, 0x00, 0x01, 0x00, 0x01};

        public static byte[] GetBytesInt16(short argument) {
            return BitConverter.GetBytes(argument);
        }


        public byte[] asByteArray(String url)
        {
            //body = GetBytesInt16(url);
            List<Byte> l = new List<byte>();
            l.AddRange(GetBytesInt16(0x100));
            l.AddRange(GetBytesInt16(flags));
            l.AddRange(GetBytesInt16(questionCount));
            l.AddRange(GetBytesInt16(answersCount));
            l.AddRange(GetBytesInt16(NSCount));
            l.AddRange(GetBytesInt16(ARCount));
            l.AddRange(body);
            return l.ToArray();
        }
    }
}
