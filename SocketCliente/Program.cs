using System;

namespace SocketCliente
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente();
            cliente.Conectar();
        }
    }
}
