using MensajeroApp.Threads;
using MensajeroModel.DAL;
using MensajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MensajeroApp
{
    partial class Program
    {
      

        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando hilo de comunicacion del Server");
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            HiloServer hiloServer = new HiloServer(puerto);
            Thread t = new Thread(new ThreadStart(hiloServer.Ejecutar));
            t.IsBackground = true;
            t.Start();
            //Iniciar el hilo del server
            while (Menu()) ;
        }
    }
}
