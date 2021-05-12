using SocketUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServerApp.Comunicacion
{
    public class ServerSocket
    {
        private int puerto;
        private Socket servidor;
        private Socket comCliente;
        private StreamReader reader;
        private StreamWriter writer;
        public ServerSocket(int puerto)
        {
            this.puerto = puerto;
        }

        public bool Iniciar()
        {
            try
            {
                //1. Crear un socket
                this.servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //2. Tomar control del puerto

                this.servidor.Bind(new IPEndPoint(IPAddress.Any, this.puerto));
                //3. Definir cuantos clientes atendere
                this.servidor.Listen(10);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public ClienteSocket ObtenerCliente()
        {
            try
            {
                return new ClienteSocket (this.servidor.Accept());
               
          
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }

}