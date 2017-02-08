using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace DNSServer {
    public class DNSServer{

        List<Tuple<String, String>> Log = new List<Tuple<string, string>>();

        private UdpClient udpClient = new UdpClient();

        private long id = 0L;

        private readonly string[] _rootServers = new[] {
            "198.41.0.4",
            "192.228.79.201",
            "192.33.4.12",
            "199.7.91.13",
            "192.203.230.10",
            "192.5.5.241",
            "192.112.36.4",
            "198.97.190.53",
            "192.36.148.17",
            "192.58.128.30",
            "193.0.14.129",
            "",
            "202.12.27.33"
        };

        public string formatTime(Stopwatch stopWatch) {
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",

            ts.Hours, ts.Minutes, ts.Seconds,

            ts.Milliseconds / 10);

            return elapsedTime;
        }

        public void enter(String IpServer, String url) {

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            var x = new DNSDatagram();

            var ep = new IPEndPoint(IPAddress.Parse(IpServer), 53);

            udpClient.Send(x.asByteArray(url), x.asByteArray(url).Length, ep);

            var rc = udpClient.Receive(ref ep);

            int i = 12;

            while (rc[i] != 0) {
                i++;
            }

            i += 6;

            for (int j = 0; j < rc[9]; j++) {

                i += 10;

                int jump = rc[i];

                i += jump+2;


            }
            i += 11;

            String resul = "";
            int w = 0;
            while (true) {
                resul += rc[i];
                i++;
                w++;
                if (w == 4) break;
                resul += ".";
            }

            stopWatch.Stop();

            Tuple<String, String> t = new Tuple<string, string>(ep.ToString(), formatTime(stopWatch));

            Log.Add(t);

            if (rc[7] == 0) enter(resul, url);
            else {
                var k = 44;
                k += rc[k];
                k += 13;
                w = 0;
                resul = "";
                while (true) {
                    resul += rc[k];
                    k++;
                    w++;
                    if (w == 4) break;
                    resul += ".";
                }
                Console.Write("IP Address: ");
                Console.WriteLine(resul);
            }


        }

        public void foo(String rootServer){

            Interlocked.Increment(ref id);

            var x = new DNSDatagram();

            var url = "www.google.com";

            Console.WriteLine("Realizando a tradução do nome: " + url +
                              "\nUtilizando o servidor raiz: " + rootServer + "\n");

            Stopwatch stopWatchTotal = new Stopwatch();

            stopWatchTotal.Start();

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            var ep = new IPEndPoint(IPAddress.Parse(rootServer), 53);

            udpClient.Send(x.asByteArray(url), x.asByteArray(url).Length, ep);

            var rc = udpClient.Receive(ref ep);


            int i = 12;

            while(rc[i] != 0){
                i++;
            }
            i += 6;
            for(int j = 0; j < rc[9]; j++) {

                i += 10;

                int jump = rc[i];

                i += jump+2;

            }

            i += 11;

            String resul = "";
            int w = 0;
            while (true) {
                resul += rc[i];
                i++;
                w++;
                if (w == 4) break;
                resul += ".";
            }

            stopWatch.Stop();

            Tuple<String, String> t = new Tuple<string, string>(ep.ToString(), formatTime(stopWatch));

            Log.Add(t);

            enter(resul, url);

            stopWatchTotal.Stop();
            Console.WriteLine();
            Console.WriteLine("Log para cada consulta");
            Log.ForEach(Console.WriteLine); ;
            Console.WriteLine();
            Console.Write("Tempo total de execucao: ");
            Console.WriteLine(formatTime(stopWatchTotal));



            Console.ReadKey();

        }
    }
}
