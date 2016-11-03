using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorODIN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "[+]-> SERVER ODIN V.0.1 <-[+]";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"  ______   ______ _____ _____ __  __    ___  ____ ___ _   _  __     _____   _ ");
            Console.WriteLine(@" / ___\ \ / / ___|_   _| ____|  \/  |  / _ \|  _ \_ _| \ | | \ \   / / _ \ / |");
            Console.WriteLine(@" \___ \\ V /\___ \ | | |  _| | |\/| | | | | | | | | ||  \| |  \ \ / / | | || |");
            Console.WriteLine(@"  ___) || |  ___) || | | |___| |  | | | |_| | |_| | || |\  |   \ V /| |_| || |");
            Console.WriteLine(@" |____/ |_| |____/ |_| |_____|_|  |_|  \___/|____/___|_| \_|    \_(_)\___(_)_|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"                                                                              ");
            Console.WriteLine(@"                              BUILD: V-0.1                                   ");
            Console.WriteLine("Línea de comandos ODIN[+]");
            NET.HandlerCommands Hand = new NET.HandlerCommands();
            Hand.Handler();
            Console.ReadKey();
        }
    }
}
