using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketServidor
{
    class Servidor
    {
        public void Iniciar()
        {
            Socket sockertServer = new Socket(AddressFamily.InterNetwork, 
                SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint direccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"),1234);
            sockertServer.Bind(direccion);
            sockertServer.Listen(1);
            Console.WriteLine("Servidor escuchando peticiones");

            //Aceptando socket cliente
            Socket socketClienteRemoto = sockertServer.Accept();
            IPEndPoint infoCliente = (IPEndPoint)socketClienteRemoto.RemoteEndPoint;
            Console.WriteLine("Cliente conectado con IP {0} en puerto {1}", 
                infoCliente.Address, infoCliente.Port);

            string mensaje = "";
            //string informacion = "";
            
            do
            {
                byte[] entrada = new byte[255];
                int datos = socketClienteRemoto.Receive(entrada, 0, entrada.Length, 0);
                Array.Resize(ref entrada, datos);
                mensaje = Encoding.Default.GetString(entrada);
                Console.WriteLine("El cliente escribio: " + mensaje);

            } while (!mensaje.ToLower().Equals("salir"));

            sockertServer.Close();
            Console.WriteLine("Servidor desconectado...");
        }
    }
}
