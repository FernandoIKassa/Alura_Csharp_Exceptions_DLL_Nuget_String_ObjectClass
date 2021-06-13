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
            ContaCorrente conta = new ContaCorrente(123, 123456);


            Console.WriteLine(conta.Agencia);
            Console.WriteLine(conta.Numero);

            DateTime dataFimPagamento = new DateTime(2022, 02, 12);
            DateTime dataCorrente = DateTime.Today;

            Console.WriteLine(dataFimPagamento);
            Console.WriteLine(dataCorrente);

            TimeSpan diferenca = dataFimPagamento - dataCorrente;
            
            string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);
            Console.WriteLine(mensagem);


            Console.ReadLine();
        }
    }
}
