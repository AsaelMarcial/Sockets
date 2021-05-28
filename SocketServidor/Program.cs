using System;

namespace SocketServidor
{
    class Program
    {
        static void Main(string[] args)
        {
            Servidor servidor = new Servidor();
            servidor.Iniciar();
        }
    }
}
