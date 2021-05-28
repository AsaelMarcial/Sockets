using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketCliente
{
    class Cliente
    {
        public void Conectar()
        {
            Socket socketCliente = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint direccionServidor = new IPEndPoint(IPAddress.Parse("127.0.0.1"),1234);

            try
            {
                socketCliente.Connect(direccionServidor);
                Console.WriteLine("Conectado con éxito al servidor... \n");
                string mensaje = "";
                do
                {
                    Console.WriteLine("Ingresa la información para enviar al servidor: ");
                    mensaje = Console.ReadLine();
                    byte[] streamEnvio = Encoding.Default.GetBytes(mensaje);
                    socketCliente.Send(streamEnvio, 0, streamEnvio.Length, 0);

                } while (!mensaje.ToLower().Equals("salir"));

                socketCliente.Close();
                Console.WriteLine("Conexión cerrada con el servidor...");

            }
            catch (Exception e)
            {

                Console.WriteLine("Error de conexión al servidor " + e.Message);
            }
        }
    }
}
