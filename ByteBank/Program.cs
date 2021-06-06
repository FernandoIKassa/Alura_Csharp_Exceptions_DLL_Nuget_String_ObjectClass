using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {

            //Teste de Transferir com saldo insuficiente
            try
            {
                ContaCorrente conta = new ContaCorrente(123, 24356);
                ContaCorrente conta2 = new ContaCorrente(321, 786435);

                conta2.Transferir(200, conta);
            }
            catch (SaldoInsuficienteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Exceção do tipo SaldoInsuficienteException");
            }

            
            //Teste de Sacar com valores negativos
            try
            {
                /*ContaCorrente conta = new ContaCorrente(5678, 12987);
                conta.Sacar(-500);*/
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Argumento com problema: " + e.ParamName);
                Console.WriteLine("Ocorreu uma exceção do tipo ArgumentException");
                Console.WriteLine(e.Message);
                
            }

            //Teste de Sacar quando saldo é inferior ao valor a ser sacado
            try
            {
               /* ContaCorrente contaCorrente = new ContaCorrente(123, 456456);
                contaCorrente.Depositar(100);
                contaCorrente.Sacar(400);*/
            }
            catch (SaldoInsuficienteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Exceção do tipo SaldoInsuficienteException");
            }

            //Teste argumentos 0 para agencia e numero
            try
            {
                //ContaCorrente conta = new ContaCorrente(0, 0);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ParamName);
            }

            //Teste de divisao com zero
            try
            {
                //Metodo();

            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }


            Console.ReadLine();
        }

        public static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }
            catch (Exception)
            {
                Console.WriteLine("Exceção com número = " + numero + " e divisor = " + divisor);
                throw;
            }

        }

        static void Metodo()
        {
            try
            {
                TestaDivisao(0);
            }
            catch (NullReferenceException excecao)
            {
                Console.WriteLine(excecao.Message);
                Console.WriteLine(excecao.StackTrace);
                //https://docs.microsoft.com/en-us/visualstudio/debugger/managing-exceptions-with-the-debugger?view=vs-2019
            }
        }

        static void TestaDivisao(int divisor)
        {
            Dividir(10, divisor);
        }
    }
}
