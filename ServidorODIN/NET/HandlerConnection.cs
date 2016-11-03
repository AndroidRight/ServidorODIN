using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ServidorODIN.NET
{
    public class HandlerConnection
    {
        private Socket HandlerSender;
        private IPEndPoint IPS;
        private bool WhileCicle;
        private int Receive_cool;
        public void ConnectionHandler(string ip, int port)
        {
            HandlerSender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            IPS = new IPEndPoint(IPAddress.Parse(ip), port);

            string texto;
            byte[] textoEnviar;
            byte[] ByRec = ByRec = new byte[255];
            try
            {

                HandlerSender.Bind(IPS);
                HandlerSender.Listen(100);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Server Side Iniciado (ODIN) .. (Esperando Conexiones...)");
                Socket Tools = HandlerSender.Accept();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Conexión establecida con el cliente <->"); 
                int a = Tools.Receive(ByRec, 0, ByRec.Length, 0);
                Array.Resize(ref ByRec, a);
     
                WhileCicle = true;
                while (WhileCicle)
                {
                    texto = Console.ReadLine(); //leemos el texto ingresado
                    textoEnviar = Encoding.Default.GetBytes(texto); //pasamos el texto a array de bytes
                    Receive_cool = Tools.Send(textoEnviar, 0, textoEnviar.Length, 0); // y lo enviamos
                    Console.WriteLine("Enviado exitosamente");
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("ERROR HANDLER SOCKET: {0}", e.ToString());
            }

        }
    
}
}
