using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensajeroModel.DAL;
using MensajeroModel.DTO;
using SocketUtils;

namespace MensajeroApp.Threads
{
    public class HiloCliente
    {
        private ClienteSocket cliente;
        private IMensajesDAL dal = MensajesDALFactory.CreateDal();
        public HiloCliente(ClienteSocket cliente)
        {
            this.cliente = cliente;
        }

        public void Ejecutar()
        {
            string nombre, detalle;
            do
            {
                cliente.Escribir("Ingrese nombre:");
                nombre = cliente.Leer().Trim();


            } while (nombre == string.Empty);

            do
            {
                cliente.Escribir("Ingrese mensaje:");
                detalle = cliente.Leer().Trim();


            } while (detalle == string.Empty);
            Mensaje m = new Mensaje()
            {
                Nombre = nombre,
                Detalle = detalle,
                Tipo = "TCP"
            };
            lock (dal)
            {
                dal.Save(m);
            }
            cliente.CerrarConexion();
        }
    }
}
