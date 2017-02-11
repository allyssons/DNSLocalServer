using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DNSServer {
    class Program {
        static void Main(string[] args){

            int opt = 0;

            while(opt != 14) {

                Console.WriteLine("Selecione o servidor raiz que deseja utilizar: ");
                Console.WriteLine("1  - 198.41.0.4");
                Console.WriteLine("2  - 192.228.79.201");
                Console.WriteLine("3  - 192.33.4.12");
                Console.WriteLine("4  - 199.7.91.13");
                Console.WriteLine("5  - 192.203.230.10");
                Console.WriteLine("6  - 192.5.5.241");
                Console.WriteLine("7  - 192.112.36.4");
                Console.WriteLine("8  - 198.97.190.53");
                Console.WriteLine("9  - 192.36.148.17");
                Console.WriteLine("10 - 192.58.128.30");
                Console.WriteLine("11 - 193.0.14.129");
                Console.WriteLine("12 - 199.7.83.42");
                Console.WriteLine("13 - 202.12.27.33");
                Console.WriteLine("14 - Não executar com nenhum servidor e encerrar o programa");

                opt = Convert.ToInt32(Console.ReadLine());

                String rootServer = "";

                switch (opt) {
                    case 1:
                        rootServer = "198.41.0.4";
                        break;
                    case 2:
                        rootServer = "192.228.79.201";
                        break;
                    case 3:
                        rootServer = "192.33.4.12";
                        break;
                    case 4:
                        rootServer = "199.7.91.13";
                        break;
                    case 5:
                        rootServer = "192.203.230.10";
                        break;
                    case 6:
                        rootServer = "192.5.5.241";
                        break;
                    case 7:
                        rootServer = "192.112.36.4";
                        break;
                    case 8:
                        rootServer = "198.97.190.53";
                        break;
                    case 9:
                        rootServer = "192.36.148.17";
                        break;
                    case 10:
                        rootServer = "192.58.128.30";
                        break;
                    case 11:
                        rootServer = "193.0.14.129";
                        break;
                    case 12:
                        rootServer = "199.7.83.42";
                        break;
                    case 13:
                        rootServer = "202.12.27.33";
                        break;
                    case 14:
                        continue;
                }
                var k = new DNSServer();
                Console.Clear();
                k.foo(rootServer);
            }
        }
    }
}
