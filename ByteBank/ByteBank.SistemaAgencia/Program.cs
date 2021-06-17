using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "pagina?argumentos";
            string argumentos = url.Substring(7);

            Console.WriteLine(url);
            Console.WriteLine(argumentos);

            
            Console.ReadLine();
        }
    }
}
