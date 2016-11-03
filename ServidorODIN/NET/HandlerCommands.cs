using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace ServidorODIN.NET
{
    public class HandlerCommands
    {  
        public Readers ODIN = new Readers();

        public void Handler()
        {
            Console.WriteLine("línea de comandos principal...");
            string CMD = Console.ReadLine();
            switch (CMD)
            {
                case "iniciar":
                    {
                        Console.WriteLine("[+] -> INICIANDO... <- [+]");
                         ODIN.StreamReaders();
                        break;
                    }
                case "update":
                    {
                        ODIN.Update();
                        break;
                    }            
                case "host":
                    {
                        ODIN.Host();
                        break;
                    }
            }
            
        }
    }
}
